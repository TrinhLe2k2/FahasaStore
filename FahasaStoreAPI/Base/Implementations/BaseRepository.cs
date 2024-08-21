using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using X.PagedList;

namespace FahasaStoreAPI.Base.Implementations
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
    {
        protected readonly FahasaStoreDBContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(FahasaStoreDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public virtual async Task<TEntity?> FindByIdAsync(TKey id)
        {
            IQueryable<TEntity> query = QueryableForGetByIdAsync();
            var result = await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
            return result;
        }
        public virtual async Task<TEntity?> FindByIdHaveListAsync(TKey id, List<AttributeCollection> attributeCollection)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking().AsQueryable();
            var virtualProperties = typeof(TEntity)
                .GetProperties()
                .Where(p => p.GetMethod.IsVirtual && !p.GetMethod.IsFinal);

            foreach (var property in virtualProperties)
            {
                if (IsCollectionProperty(property))
                {
                    if (attributeCollection.FirstOrDefault(a => a.AttributeCollectionName.ToLower() == property.Name.ToLower()) != null)
                    {
                        query = query.Include(property.Name);
                    }
                }
                else
                {
                    query = query.Include(property.Name);
                }
            }

            var result = await query.FirstOrDefaultAsync(e => e.Id.Equals(id));

            // Nếu có kết quả (không phải null)
            if (result != null)
            {
                // Lấy tất cả các thuộc tính ảo của đối tượng TEntity có kiểu là collection (trừ string)
                var collectionProperties = typeof(TEntity)
                    .GetProperties()
                    .Where(p => p.GetMethod.IsVirtual && IsCollectionProperty(p));

                // Duyệt qua tất cả các thuộc tính collection
                foreach (var property in collectionProperties)
                {
                    var attribute = attributeCollection.FirstOrDefault(a => a.AttributeCollectionName.ToLower() == property.Name.ToLower());

                    if (attribute != null && attribute.take > 0)
                    {
                        var propertyType = property.PropertyType;
                        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                        {
                            var itemType = propertyType.GetGenericArguments().First();
                            var collectionType = typeof(List<>).MakeGenericType(itemType);
                            var value = property.GetValue(result) as IEnumerable<object>;

                            if (value != null)
                            {
                                // Giới hạn số lượng phần tử của collection
                                var limitedCollection = value.Take(attribute.take).ToList();

                                // Tạo một instance của collection đúng loại
                                var newCollection = Activator.CreateInstance(collectionType) as System.Collections.IList;

                                if (newCollection != null)
                                {
                                    foreach (var item in limitedCollection)
                                    {
                                        newCollection.Add(item);
                                    }

                                    // Cập nhật thuộc tính collection với danh sách đã giới hạn
                                    property.SetValue(result, newCollection);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
        public virtual async Task<bool> ExistsAsync(TKey id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Equals(id)) != null;
        }
        public virtual async Task<IPagedList<TEntity>> FilterAsync(FilterOptions filterOptions)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking().AsQueryable();
            var virtualProperties = typeof(TEntity)
                .GetProperties()
                .Where(p => p.GetMethod.IsVirtual && !p.GetMethod.IsFinal && !IsCollectionProperty(p));

            foreach (var property in virtualProperties)
            {
                query = query.Include(property.Name);
            }

            if (filterOptions.Filters != null && filterOptions.Filters.Count > 0)
            {
                foreach (var filter in filterOptions.Filters)
                {
                    string key = filter.Key;
                    string? value = filter.Value;
                    string typeOfKey = filter.TypeOfKey;
                    string comparisonOperator = filter.ComparisonOperator;

                    if (!string.IsNullOrEmpty(key) && typeof(TEntity).GetProperty(key) != null && !string.IsNullOrEmpty(value))
                    {
                        switch (typeOfKey.ToLower())
                        {
                            case "string":
                                if (comparisonOperator == "=")
                                {
                                    query = query.Where($"{key}.Contains(@0)", value);
                                }
                                break;
                            case "int":
                                if (int.TryParse(value, out int intValue))
                                {
                                    switch (comparisonOperator)
                                    {
                                        case "=":
                                            query = query.Where($"{key} == @0", intValue);
                                            break;
                                        case "<=":
                                            query = query.Where($"{key} <= @0", intValue);
                                            break;
                                        case ">=":
                                            query = query.Where($"{key} >= @0", intValue);
                                            break;
                                    }
                                }
                                break;
                            case "datetime":
                                if (DateTime.TryParse(value, out DateTime dateValue))
                                {
                                    switch (comparisonOperator)
                                    {
                                        case "=":
                                            query = query.Where($"{key} == @0", dateValue);
                                            break;
                                        case "<=":
                                            query = query.Where($"{key} <= @0", dateValue);
                                            break;
                                        case ">=":
                                            query = query.Where($"{key} >= @0", dateValue);
                                            break;
                                        case "<":
                                            query = query.Where($"{key} < @0", dateValue);
                                            break;
                                        case ">":
                                            query = query.Where($"{key} > @0", dateValue);
                                            break;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(filterOptions.SortField) && typeof(TEntity).GetProperty(filterOptions.SortField) != null)
            {
                query = query.OrderBy($"{filterOptions.SortField} {(filterOptions.OrderByDescending ? "desc" : "asc")}");
            }
            else
            {
                query = query.OrderBy(e => e.Id);
            }

            var result = await query.ToPagedListAsync(filterOptions.PageNumber, filterOptions.PageSize);

            List<AttributeCollection> attributeCollection = filterOptions.AttributeCollectionInclude;

            if (attributeCollection.Any())
            {
                // Lặp qua tất cả các thuộc tính trong attributeCollection
                foreach (var attr in attributeCollection)
                {
                    // Lấy thuộc tính của TEntity dựa trên tên thuộc tính trong attributeCollection
                    var property = typeof(TEntity).GetProperty(attr.AttributeCollectionName);

                    if (property != null && attr.take > 0 && IsCollectionProperty(property))
                    {
                        // Lấy kiểu của thuộc tính
                        var propertyType = property.PropertyType;

                        // Kiểm tra xem thuộc tính có phải là ICollection hay không
                        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                        {
                            // Lấy kiểu của các phần tử trong ICollection
                            var itemType = propertyType.GetGenericArguments().First();

                            // Tạo kiểu danh sách cụ thể cho itemType
                            var collectionType = typeof(List<>).MakeGenericType(itemType);

                            // Lặp qua tất cả các item trong kết quả
                            foreach (var item in result)
                            {
                                // Tạo một danh sách mới với kiểu cụ thể
                                var newCollection = Activator.CreateInstance(collectionType) as System.Collections.IList;

                                if (newCollection != null)
                                {
                                    // Đảm bảo rằng item được theo dõi để có thể truy xuất dữ liệu
                                    _context.Entry(item).State = EntityState.Unchanged;

                                    // Tạo IQueryable dựa trên thuộc tính của item và giới hạn số lượng phần tử
                                    var newIcollection = await _context.Entry(item)
                                                         .Collection(property.Name)
                                                         .Query()
                                                         .Take(attr.take)
                                                         .ToDynamicListAsync();

                                    // Chuyển đổi và thêm từng phần tử từ danh sách động vào danh sách mới
                                    foreach (var dynamicItem in newIcollection)
                                    {
                                        // Chuyển đổi phần tử từ kiểu dynamic sang kiểu cụ thể của itemType
                                        var specificItem = Convert.ChangeType(dynamicItem, itemType);
                                        newCollection.Add(specificItem);
                                    }

                                    // Gán danh sách mới cho thuộc tính tương ứng của item
                                    property.SetValue(item, newCollection);
                                }
                            }
                        }
                    }
                }
            }


            return result;
        }
        protected bool IsCollectionProperty(PropertyInfo property)
        {
            if (property.PropertyType.IsGenericType)
            {
                var genericTypeDefinition = property.PropertyType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(ICollection<>))
                {
                    return true;
                }
            }
            return false;
        }
        protected IQueryable<TEntity> Queryable()
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking().AsQueryable();
            var virtualProperties = typeof(TEntity)
                .GetProperties()
                .Where(p => p.GetMethod.IsVirtual && !p.GetMethod.IsFinal && !IsCollectionProperty(p));

            foreach (var property in virtualProperties)
            {
                query = query.Include(property.Name);
            }

            return query;
        }
        protected virtual IQueryable<TEntity> QueryableForGetByIdAsync()
        {
            return Queryable();
        }
        protected virtual IQueryable<TEntity> QueryableForFilterAsync()
        {
            return Queryable();
        }
    }
}
