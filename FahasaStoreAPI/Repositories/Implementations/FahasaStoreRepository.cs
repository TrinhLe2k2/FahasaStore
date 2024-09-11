using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Helpers;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.ViewModels;
using FahasaStoreAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;
using X.PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FahasaStoreAPI.Repositories.Implementations
{
    public class FahasaStoreRepository : IFahasaStoreRepository
    {
        private readonly FahasaStoreDBContext _context;
        private readonly IMapper _mapper;
        private readonly IBookRecommendationSystem _bookRecommendationSystem;

        public FahasaStoreRepository(FahasaStoreDBContext context, IMapper mapper, IBookRecommendationSystem bookRecommendationSystem)
        {
            _context = context;
            _mapper = mapper;
            _bookRecommendationSystem = bookRecommendationSystem;
        }

        public async Task<FlashSaleDetail?> FlashSaleTodayAsync(int pageNumber, int pageSize)
        {
            var today = DateTime.Today;

            var flashSaleToday = await _context.FlashSales.AsNoTracking()
                .ProjectTo<FlashSaleDetail>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.StartDate <= today && e.EndDate >= today);
            return flashSaleToday;
        }

        public async Task<PagedVM<BookExtend>> TrendingBooks(string trendingBy, int pageNumber, int pageSize)
        {
            var startDate = DateTime.Today;
            var endDate = DateTime.Today;
            switch (trendingBy)
            {
                case TrendingBy.Monthly:
                    endDate = startDate.AddMonths(1);
                    break;
                case TrendingBy.Yearly:
                    endDate = startDate.AddYears(1);
                    break;
                default:
                    endDate = startDate.AddDays(1);
                    break;
            }

            var trendingBooks = await _context.Books.AsNoTracking()
                .Where(b => b.OrderItems.Any(oi => oi.Order != null && oi.Order.CreatedAt >= startDate && oi.Order.CreatedAt <= endDate))
                .ProjectTo<BookExtend>(_mapper.ConfigurationProvider)
                .OrderByDescending(b => b.Solded)
                .ToPagedListAsync(pageNumber, pageSize);
                                      
            return MethodsHelper.GetPaged(trendingBooks);
        }

        public async Task<PagedVM<BookExtend>> TopSellingBooksByCategory(int categoryId, int pageNumber, int pageSize)
        {
            var topSellingBooks = await _context.Books.AsNoTracking()
                .Where(b => b.Subcategory != null && b.Subcategory.CategoryId == categoryId)
                .ProjectTo<BookExtend>(_mapper.ConfigurationProvider)
                .OrderByDescending(b => b.Solded)
                .ToPagedListAsync(pageNumber, pageSize);

            return MethodsHelper.GetPaged(topSellingBooks);
        }

        public async Task<DataOptionsFilterBook> DataOptionsFilterBook()
        {
            var categories = await _context.Categories.AsNoTracking()
                .ProjectTo<CategoryDetail>(_mapper.ConfigurationProvider)
                .OrderBy(c => c.Name)
                .ToListAsync();

            var partnerTypes = await _context.PartnerTypes.AsNoTracking()
                .ProjectTo<PartnerTypeDetail>(_mapper.ConfigurationProvider)
                .OrderBy(c => c.Name)
                .ToListAsync();
            var authors = await _context.Authors.AsNoTracking()
                .ProjectTo<AuthorExtend>(_mapper.ConfigurationProvider).OrderBy(c => c.Name)
                .ToListAsync();
            var coverTypes = await _context.CoverTypes.AsNoTracking()
                .ProjectTo<CoverTypeExtend>(_mapper.ConfigurationProvider).OrderBy(c => c.TypeName)
                .ToListAsync();
            var dimensions = await _context.Dimensions.AsNoTracking()
                .ProjectTo<DimensionExtend>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var dataOptionsFilterBook = new DataOptionsFilterBook
            {
                Categories = categories,
                PartnerTypes = partnerTypes,
                Authors = authors,
                CoverTypes = coverTypes,
                Dimensions = dimensions
            };
            return dataOptionsFilterBook;
        }

        public async Task<ResultFilterBook> FilterBook(OptionsFilterBook optionsFilterBook)
        {
            var query = _context.Books.AsNoTracking().AsQueryable();
            #region step 1: Filter Book
            if (optionsFilterBook.CategoryId.HasValue)
            {
                query = query.Where(b => b.Subcategory != null && b.Subcategory.CategoryId == optionsFilterBook.CategoryId.Value);
            }

            if (optionsFilterBook.SubcategoryId.HasValue)
            {
                query = query.Where(b => b.SubcategoryId == optionsFilterBook.SubcategoryId.Value);
            }

            if (optionsFilterBook.AuthorId.HasValue)
            {
                query = query.Where(b => b.AuthorId == optionsFilterBook.AuthorId.Value);
            }

            if (optionsFilterBook.PartnerTypeId.HasValue)
            {
                query = query.Where(b => b.BookPartners.Any(bp => bp.Partner != null && bp.Partner.PartnerTypeId == optionsFilterBook.PartnerTypeId.Value));
            }

            if (optionsFilterBook.PartnerId.HasValue)
            {
                query = query.Where(b => b.BookPartners.Any(bp => bp.PartnerId == optionsFilterBook.PartnerId.Value));
            }

            if (optionsFilterBook.CoverTypeId.HasValue)
            {
                query = query.Where(b => b.CoverTypeId == optionsFilterBook.CoverTypeId.Value);
            }

            if (optionsFilterBook.DimensionId.HasValue)
            {
                query = query.Where(b => b.DimensionId == optionsFilterBook.DimensionId.Value);
            }

            #endregion

            #region step 2: Filter BookExtend
            var queryForBookDto = query.ProjectTo<BookExtend>(_mapper.ConfigurationProvider);

            if (optionsFilterBook.MinPrice.HasValue)
            {
                queryForBookDto = queryForBookDto.Where(b => b.CurrentPrice >= optionsFilterBook.MinPrice.Value);
            }

            if (optionsFilterBook.MaxPrice.HasValue)
            {
                queryForBookDto = queryForBookDto.Where(b => b.CurrentPrice <= optionsFilterBook.MaxPrice.Value);
            }

            if (!string.IsNullOrEmpty(optionsFilterBook.SearchName))
            {
                queryForBookDto = queryForBookDto.Where(b => b.Name.Contains(optionsFilterBook.SearchName));
            }

            #endregion

            #region step 3: OrderBy
            if (!string.IsNullOrEmpty(optionsFilterBook.SortBy) && typeof(BookExtend).GetProperty(optionsFilterBook.SortBy) != null)
            {
                if (optionsFilterBook.SortDescending)
                {
                    queryForBookDto = queryForBookDto.OrderByDescending(e => EF.Property<object>(e, optionsFilterBook.SortBy));
                }
                else
                {
                    queryForBookDto = queryForBookDto.OrderBy(e => EF.Property<object>(e, optionsFilterBook.SortBy));
                }
            }
            else
            {
                queryForBookDto = queryForBookDto.OrderBy(e => e.Id);
            }
            #endregion
            var pageListBook = await queryForBookDto.ToPagedListAsync(optionsFilterBook.PageNumber, optionsFilterBook.PageSize);
            var result = new ResultFilterBook
            {
                optionsFilterBook = optionsFilterBook,
                books = MethodsHelper.GetPaged(pageListBook)
            };
            return result;
        }

        public async Task<VoucherExtend?> GetVoucherDetailsByIdAsync(int voucherId)
        {
            var result = await _context.Vouchers
                .ProjectTo<VoucherExtend>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Id == voucherId);
            return result;
        }

        public async Task<VoucherExtend?> ApplyVoucherAsync(string code, int intoMoney)
        {
            var result = await _context.Vouchers
                .ProjectTo<VoucherExtend>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(e => e.Code == code && e.MinOrderAmount <= intoMoney);
            return result;
        }

        public async Task<PagedVM<VoucherExtend>> GetVouchersAsync(int pageNumber, int pageSize, int intoMoney = 0)
        {
            var today = DateTime.Today;

            // Bắt đầu với truy vấn cơ bản
            var query = _context.Vouchers
                .ProjectTo<VoucherExtend>(_mapper.ConfigurationProvider)
                .Where(e => e.StartDate <= today && e.EndDate >= today && e.CountOrders < e.UsageLimit);

            // Nếu intoMoney có giá trị, thêm điều kiện lọc vào truy vấn
            if (!intoMoney.Equals(0))
            {
                query = query.Where(e => e.MinOrderAmount <= intoMoney);
            }
            var pageList = await query
            .OrderByDescending(e => e.CreatedAt)
            .ToPagedListAsync(pageNumber, pageSize);

            return MethodsHelper.GetPaged(pageList);
        }

        public async Task<HomeIndexVM> DataForHomeIndex(int numBanner, int numMenu, int numFS, int numTrend, int numCategory, int numTopSelling, int numPartner)
        {
            var bannerPageList = await _context.Banners.AsNoTracking()
                .ProjectTo<BannerExtend>(_mapper.ConfigurationProvider)
                .OrderByDescending(e => e.CreatedAt)
                .ToPagedListAsync(1, numBanner);

            var menuPageList = await _context.Menus.AsNoTracking()
                .ProjectTo<MenuExtend>(_mapper.ConfigurationProvider)
                .OrderByDescending(e => e.CreatedAt)
                .ToPagedListAsync(1, numMenu);

            var flashSaleToday = await FlashSaleTodayAsync(1, numFS);

            var trendOfMonthPageVM = await TrendingBooks(TrendingBy.Monthly, 1, numTrend);
            var trendOfYearPageVM = await TrendingBooks(TrendingBy.Yearly, 1, numTrend);

            var categoryPageList = await _context.Categories.AsNoTracking()
                .ProjectTo<CategoryExtend>(_mapper.ConfigurationProvider)
                .OrderBy(e => e.CreatedAt)
                .ToPagedListAsync(1, numCategory);

            var topSellingBooksByCategoryPageVM = await TopSellingBooksByCategory(categoryPageList.First().Id, 1, numTopSelling);

            var partnerPageList = await _context.Partners.AsNoTracking()
                .ProjectTo<PartnerExtend>(_mapper.ConfigurationProvider)
                .OrderBy(e => e.CreatedAt)
                .ToPagedListAsync(1, numPartner);

            var result = new HomeIndexVM
            {
                BannerPaged = MethodsHelper.GetPaged(bannerPageList),
                MenuPaged = MethodsHelper.GetPaged(menuPageList),
                FlashSaleToday = flashSaleToday,
                TrendOfMonthPaged = trendOfMonthPageVM,
                TrendOfYearPaged = trendOfYearPageVM,
                CategoryPaged = MethodsHelper.GetPaged(categoryPageList),
                TopSellingBooksByCategoryPaged = topSellingBooksByCategoryPageVM,
                PartnerPaged = MethodsHelper.GetPaged(partnerPageList)
            };
            return result;
        }

        public async Task<HomeProductVM> DataForHomeProduct(int bookId)
        {
            var bookDetail = await _context.Books.AsNoTracking()
                .ProjectTo<BookDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id == bookId);

            var similarBooks = await _bookRecommendationSystem.FindSimilarBooks(bookId, 1, 20);

            var reviewsBook = await _context.Reviews.AsNoTracking()
                .Where(e => e.BookId == bookId)
                .ProjectTo<ReviewExtend>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(1, 10);

            return new HomeProductVM
            {
                Book = bookDetail, SimilarBooks = similarBooks, reviews = MethodsHelper.GetPaged(reviewsBook)
            };
        }

        public async Task<PagedVM<ReviewExtend>> ProductReviews(int bookId, int pageNumber, int pageSize)
        {
            var reviewsBook = await _context.Reviews.AsNoTracking()
                .Where(e => e.BookId == bookId)
                .ProjectTo<ReviewExtend>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(pageNumber, pageSize);
            return MethodsHelper.GetPaged(reviewsBook);
        }

        public async Task<HomeLayoutVM> DataForHomeLayout(int numCategory, int numPlatform, int numTopic)
        {
            var websiteDetail = await _context.Websites.AsNoTracking()
                .ProjectTo<WebsiteDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Default);

            var categoryPageList = await _context.Categories.AsNoTracking()
                .ProjectTo<CategoryDetail>(_mapper.ConfigurationProvider)
                .OrderBy(e => e.CreatedAt)
                .ToPagedListAsync(1, numCategory);

            var platformPageList = await _context.Platforms.AsNoTracking()
                .ProjectTo<PlatformExtend>(_mapper.ConfigurationProvider)
                .OrderByDescending(e => e.CreatedAt)
                .ToPagedListAsync(1, numPlatform);

            var topicPageList = await _context.Topics.AsNoTracking()
                .ProjectTo<TopicDetail>(_mapper.ConfigurationProvider)
                .OrderBy(e => e.CreatedAt)
                .ToPagedListAsync(1, numTopic);
            return new HomeLayoutVM
            {
                Website = websiteDetail,
                CategoryPaged = MethodsHelper.GetPaged(categoryPageList),
                PlatformPaged = MethodsHelper.GetPaged(platformPageList),
                TopicPaged = MethodsHelper.GetPaged(topicPageList)
            };
        }

        public async Task<PagedVM<PaymentMethodExtend>> GetPaymentMethodsAsync(int pageNumber, int pageSize)
        {
            var paymentMethodPageList = await _context.PaymentMethods.AsNoTracking()
                .ProjectTo<PaymentMethodExtend>(_mapper.ConfigurationProvider)
                .Where(e => e.Active)
                .ToPagedListAsync(pageNumber, pageSize);
            return MethodsHelper.GetPaged(paymentMethodPageList);
        }
    }
}
