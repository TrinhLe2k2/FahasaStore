using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace FahasaStoreAPI.Repositories.Implementations
{
    public class BookRecommendationSystem : IBookRecommendationSystem
    {
        protected readonly FahasaStoreDBContext _context;
        protected readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        private ConcurrentDictionary<int, double[]> _bookFeatureVectors = new ConcurrentDictionary<int, double[]>();
        private readonly IQueryable<RSProduct> _rsProductContext;
        private List<RSProduct> rSProducts = new List<RSProduct>();

        // Tạo một mảng các ký tự đặc biệt bạn muốn loại bỏ
        private readonly char[] punctuationChars = { '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', '{', ']', '}', '\\', '|', ';', ':', '\'', '"', '<', ',', '>', '.', '/', '?' };
        private readonly string[] stopWords = {
                "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín", "mười",
                "và", "hoặc", "của", "trong", "ở", "tới", "đến", "cho", "về", "với", "cùng", "là",
                "được", "từ", "đi", "điều", "này", "đó"
            };

        public BookRecommendationSystem(FahasaStoreDBContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
            _rsProductContext = _context.Books.AsNoTracking().ProjectTo<RSProduct>(_mapper.ConfigurationProvider);
        }

        public async Task InitializeFeatureVectorsAsync()
        {
            var CacheKeyRSProduct = "rSProductsList";
            if (!_cache.TryGetValue(CacheKeyRSProduct, out List<RSProduct> rSProductsList))
            {
                rSProductsList = await _rsProductContext.Take(100).ToListAsync();

                // Lưu kết quả vào cache với thời gian tồn tại (1 giờ)
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1));

                _cache.Set(CacheKeyRSProduct, rSProductsList, cacheEntryOptions);
            }
            rSProducts = rSProductsList;

            var CacheKeyFeatureVectors = "CacheKeyFeatureVectors";
            if (!_cache.TryGetValue(CacheKeyFeatureVectors, out ConcurrentDictionary<int, double[]> featureVectors))
            {
                
                featureVectors = new ConcurrentDictionary<int, double[]>();

                // Group by relevant properties
                var groupedProducts = rSProducts
                    .GroupBy(r => new
                    {
                        r.AuthorName,
                        r.SubcategoryName,
                        r.CoverTypeName
                    });

                var parallelOptions = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount // Sử dụng số lượng luồng bằng số lượng lõi CPU
                };

                Parallel.ForEach(groupedProducts, group =>
                {
                    // Calculate the feature vector once for the entire group
                    var representativeProduct = group.First(); // Lấy một đại diện từ nhóm
                    var featureVector = FeatureVectorAsync(representativeProduct).Values.First();

                    // Apply the same feature vector to all products in the group
                    foreach (var rSProduct in group)
                    {
                        featureVectors[rSProduct.Id] = featureVector;
                    }
                });

                // Lưu kết quả vào cache với thời gian tồn tại (1 giờ)
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1));

                _cache.Set(CacheKeyFeatureVectors, featureVectors, cacheEntryOptions);
            }

            _bookFeatureVectors = featureVectors;
        }

        public async Task<PagedVM<BookExtend>> FindSimilarBooks(int bookId, int pageNumber, int pageSize)
        {
            await InitializeFeatureVectorsAsync();
            // Ensure the feature vectors are initialized
            if (_bookFeatureVectors == null || !_bookFeatureVectors.Any())
            {
                throw new InvalidOperationException("Feature vectors are not initialized. Call InitializeFeatureVectorsAsync() first.");
            }

            //if (!_bookFeatureVectors.ContainsKey(bookId))
            //{
            //    throw new ArgumentException("Book ID not found in feature vectors.", nameof(bookId));
            //}

            //var targetVector = _bookFeatureVectors[bookId];
            var targetProduct = await _rsProductContext.FirstOrDefaultAsync(p => p.Id == bookId);
            if (targetProduct == null)
            {
                throw new ArgumentException("Book ID not found in feature vectors.", nameof(bookId));
            }
            var targetVector = FeatureVectorAsync(targetProduct).Values.First();

            var similarBooksDictionary = new ConcurrentDictionary<int, double>();

            // Compute cosine similarity in parallel
            Parallel.ForEach(_bookFeatureVectors.Keys, otherBookId =>
            {
                if (otherBookId == bookId) return;

                var otherVector = _bookFeatureVectors[otherBookId];
                var similarity = ComputeCosineSimilarity(targetVector, otherVector);
                similarBooksDictionary[otherBookId] = similarity;
            });

            var similarBooksDictionary2 = similarBooksDictionary.OrderByDescending(e => e.Value);

            var similarBookIdsPageList = similarBooksDictionary
                .OrderByDescending(e => e.Value)
                .Select(e => e.Key)
                .ToPagedList(pageNumber, pageSize);
            var paged0 = MethodsHelper.GetPaged(similarBookIdsPageList);

            // Retrieve the book details in one query
            var similarBooksPageList = await _context.Books.AsNoTracking().ProjectTo<BookExtend>(_mapper.ConfigurationProvider)
                .Where(b => similarBookIdsPageList.Contains(b.Id))
                .ToPagedListAsync(pageNumber, pageSize);

            var paged = MethodsHelper.GetPaged(similarBooksPageList);
            paged.PagedNavigation.TotalItemCount = paged0.PagedNavigation.TotalItemCount;
            paged.PagedNavigation.PageCount = paged0.PagedNavigation.PageCount;
            paged.PagedNavigation.HasNextPage = paged0.PagedNavigation.HasNextPage;
            paged.PagedNavigation.HasPreviousPage = paged0.PagedNavigation.HasPreviousPage;
            paged.PagedNavigation.IsFirstPage = paged0.PagedNavigation.IsFirstPage;
            paged.PagedNavigation.IsLastPage = paged0.PagedNavigation.IsLastPage;
            paged.PagedNavigation.StartPage = paged0.PagedNavigation.StartPage;
            paged.PagedNavigation.EndPage = paged0.PagedNavigation.EndPage;

            return paged;
        }

        public async Task<PagedVM<BookExtend>> FindSimilarBooksBasedOnCart(List<int> bookIdsInCart, int pageNumber, int pageSize, string aggregationMethod = "average")
        {
            await InitializeFeatureVectorsAsync();
            // Ensure the feature vectors are initialized
            if (_bookFeatureVectors == null || !_bookFeatureVectors.Any())
            {
                throw new InvalidOperationException("Feature vectors are not initialized. Call InitializeFeatureVectorsAsync() first.");
            }

            // Ensure all book IDs in the cart exist in the feature vectors
            if (!bookIdsInCart.All(id => _bookFeatureVectors.ContainsKey(id)))
            {
                throw new ArgumentException("One or more book IDs in the cart are not found in feature vectors.");
            }

            if (!bookIdsInCart.Any())
            {
                return MethodsHelper.GetPaged(await _context.Books.AsNoTracking().ProjectTo<BookExtend>(_mapper.ConfigurationProvider).OrderByDescending(book => book.CreatedAt).ToPagedListAsync(pageNumber, pageSize));
            }

            var cartVectors = bookIdsInCart.Select(id => _bookFeatureVectors[id]);
            double[] aggregateVector;

            switch (aggregationMethod.ToLower())
            {
                case "average":
                    aggregateVector = AverageFeatureVectors(cartVectors);
                    break;
                case "max":
                    aggregateVector = MaxPoolingFeatureVectors(cartVectors);
                    break;
                case "min":
                    aggregateVector = MinPoolingFeatureVectors(cartVectors);
                    break;
                default:
                    aggregateVector = AggregateFeatureVectors(cartVectors);
                    break;
            }

            var cartBookIds = new HashSet<int>(bookIdsInCart);
            var similarBooksDictionary = new Dictionary<int, double>();

            foreach (var otherBookId in _bookFeatureVectors.Keys)
            {
                if (cartBookIds.Contains(otherBookId))
                {
                    continue;
                }

                var otherVector = _bookFeatureVectors[otherBookId];
                var similarity = ComputeCosineSimilarity(aggregateVector, otherVector);
                similarBooksDictionary[otherBookId] = similarity;
            }

            var similarBookIds = similarBooksDictionary
                .OrderByDescending(e => e.Value)
                .Select(e => e.Key)
                .ToPagedList(pageNumber, pageSize);

            var paged0 = MethodsHelper.GetPaged(similarBookIds);

            var similarBooksPageList = await _context.Books.AsNoTracking().ProjectTo<BookExtend>(_mapper.ConfigurationProvider)
                .Where(b => similarBookIds.Contains(b.Id))
                .ToPagedListAsync(pageNumber, pageSize);

            var paged = MethodsHelper.GetPaged(similarBooksPageList);
            paged.PagedNavigation.TotalItemCount = paged0.PagedNavigation.TotalItemCount;
            paged.PagedNavigation.PageCount = paged0.PagedNavigation.PageCount;
            paged.PagedNavigation.HasNextPage = paged0.PagedNavigation.HasNextPage;
            paged.PagedNavigation.HasPreviousPage = paged0.PagedNavigation.HasPreviousPage;
            paged.PagedNavigation.IsFirstPage = paged0.PagedNavigation.IsFirstPage;
            paged.PagedNavigation.IsLastPage = paged0.PagedNavigation.IsLastPage;
            paged.PagedNavigation.StartPage = paged0.PagedNavigation.StartPage;
            paged.PagedNavigation.EndPage = paged0.PagedNavigation.EndPage;

            return paged;
        }

        private Dictionary<int, double[]> FeatureVectorAsync(RSProduct rSProduct)
        {
            var combinedString = $"{rSProduct.AuthorName} {rSProduct.SubcategoryName} {rSProduct.CoverTypeName}";
            var words = PreprocessText(combinedString).Split(' ');
            var featureVector = new double[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                featureVector[i] = ComputeTFIDF(words[i], words);
            }

            return new Dictionary<int, double[]> { { rSProduct.Id, featureVector } };
        }

        private string PreprocessText(string text)
        {
            foreach (var punctuationChar in punctuationChars)
            {
                text = text.Replace(punctuationChar, ' ');
            }

            text = text.ToLower();
            var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(word => !stopWords.Contains(word));
            return string.Join(" ", words);
        }

        private double ComputeTF(string term, string[] words)
        {
            int termFrequency = words.Count(w => w.Equals(term, StringComparison.OrdinalIgnoreCase));
            return Math.Round((double)termFrequency / words.Length, 4);
        }

        private double ComputeIDF(string term)
        {
            int documentFrequency = rSProducts.Count(rSProduct => PreprocessText($"{rSProduct.AuthorName} {rSProduct.SubcategoryName} {rSProduct.CoverTypeName}").Split(' ').Contains(term));
            if (documentFrequency == 0)
            {
                return 0.0;
            }
            double idfValue = Math.Log((double)rSProducts.Count() / documentFrequency);
            return Math.Round(idfValue, 4);
        }

        private double ComputeTFIDF(string term, string[] words)
        {
            var tf = ComputeTF(term, words);
            var idf = ComputeIDF(term);
            return Math.Round(tf * idf, 4);
        }

        private double[] AverageFeatureVectors(IEnumerable<double[]> vectors)
        {
            int vectorLength = vectors.First().Length;
            var averageVector = new double[vectorLength];
            int count = vectors.Count();

            foreach (var vector in vectors)
            {
                for (int i = 0; i < vectorLength; i++)
                {
                    averageVector[i] += vector[i];
                }
            }

            for (int i = 0; i < vectorLength; i++)
            {
                averageVector[i] /= count;
            }

            return averageVector;
        }

        private double[] MaxPoolingFeatureVectors(IEnumerable<double[]> vectors)
        {
            int vectorLength = vectors.First().Length;
            var maxVector = new double[vectorLength];

            foreach (var vector in vectors)
            {
                for (int i = 0; i < vectorLength; i++)
                {
                    maxVector[i] = Math.Max(maxVector[i], vector[i]);
                }
            }

            return maxVector;
        }

        private double[] MinPoolingFeatureVectors(IEnumerable<double[]> vectors)
        {
            int vectorLength = vectors.First().Length;
            var minVector = new double[vectorLength];

            for (int i = 0; i < vectorLength; i++)
            {
                minVector[i] = double.MaxValue;
            }

            foreach (var vector in vectors)
            {
                for (int i = 0; i < vectorLength; i++)
                {
                    minVector[i] = Math.Min(minVector[i], vector[i]);
                }
            }

            return minVector;
        }

        private double[] AggregateFeatureVectors(IEnumerable<double[]> vectors)
        {
            int vectorLength = vectors.First().Length;
            var aggregateVector = new double[vectorLength];

            foreach (var vector in vectors)
            {
                for (int i = 0; i < vectorLength; i++)
                {
                    aggregateVector[i] += vector[i];
                }
            }

            return aggregateVector;
        }

        // Tính tích vô hướng của hai vector.
        private double DotProduct(double[] vectorA, double[] vectorB)
        {
            return vectorA.Zip(vectorB, (a, b) => a * b).Sum();
        }

        // Tính toán độ dài (norm) của một vector.
        private double Norm(double[] vector)
        {
            return Math.Sqrt(vector.Sum(x => x * x));
        }

        private void AdjustVectors(ref double[] vectorA, ref double[] vectorB)
        {
            // Lấy độ dài của cả hai vector
            int lengthA = vectorA.Length;
            int lengthB = vectorB.Length;

            // Nếu độ dài không bằng nhau, điều chỉnh độ dài
            if (lengthA != lengthB)
            {
                // Độ dài lớn hơn làm chuẩn
                int targetLength = Math.Max(lengthA, lengthB);

                // Điều chỉnh vector A
                if (lengthA < targetLength)
                {
                    Array.Resize(ref vectorA, targetLength);
                }

                // Điều chỉnh vector B
                if (lengthB < targetLength)
                {
                    Array.Resize(ref vectorB, targetLength);
                }
            }
        }

        // Tính cosine similarity
        private double ComputeCosineSimilarity(double[] vectorA, double[] vectorB)
        {
            // Điều chỉnh độ dài của vector để chúng có cùng độ dài
            AdjustVectors(ref vectorA, ref vectorB);

            // Tính toán cosine similarity
            var dotProduct = DotProduct(vectorA, vectorB);
            var normA = Norm(vectorA);
            var normB = Norm(vectorB);

            // Bảo đảm không chia cho 0
            if (normA == 0 || normB == 0)
            {
                return 0.0;
            }
            var cosineSimilarity = dotProduct / (normA * normB);
            return cosineSimilarity;
        }

    }
}
