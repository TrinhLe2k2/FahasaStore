using AutoMapper;
using AutoMapper.QueryableExtensions;
using FahasaStore.Models;
using FahasaStoreAPI.Areas.Base;
using FahasaStoreAPI.Constants;
using FahasaStoreAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FahasaStoreAPI.Areas.Customer
{
    #region Address
    public interface ICustomerAddressRepository : ICustomerBaseRepository<Address, AddressDetail, AddressExtend, AddressBase>
    {
    }

    public class CustomerAddressRepository : CustomerBaseRepository<Address, AddressDetail, AddressExtend, AddressBase>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(FahasaStoreDBContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<AddressDetail> AddAsync(AddressBase model, int userId)
        {
            model.UserId = userId;
            if (model.Default)
            {
                var existingDefaults = await _context.Addresses
                    .Where(e => e.UserId == userId && e.Default)
                    .ToListAsync();

                foreach (var def in existingDefaults)
                {
                    def.Default = false;
                    _context.Entry(def).State = EntityState.Modified;
                }
            }

            var entity = _mapper.Map<Address>(model);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<AddressDetail>(entity);
        }

        public override  async Task DeleteAsync(int id, int userId)
        {
            var entity = await _context.Addresses.AsNoTracking().FirstAsync(e => e.Id.Equals(id) && e.UserId.Equals(userId));
            if (entity.Default)
            {
                var newDefault = await _context.Addresses
                    .FirstOrDefaultAsync(e => !e.Default && e.UserId.Equals(userId) && !e.Id.Equals(id));
                if (newDefault != null)
                {
                    newDefault.Default = true;
                    _context.Entry(newDefault).State = EntityState.Modified;
                }
            }

            _dbSet.Remove(_mapper.Map<Address>(entity));
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateAsync(AddressBase model)
        {
            if (model.Default)
            {
                var existingDefaults = await _context.Addresses
                    .Where(e => e.UserId.Equals(model.UserId) && e.Default)
                    .ToListAsync();

                foreach (var def in existingDefaults)
                {
                    def.Default = false;
                    _context.Entry(def).State = EntityState.Modified;
                }
            }
            var entity = _mapper.Map<Address>(model);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
    #endregion

    #region Order
    public interface ICustomerOrderRepository : ICustomerBaseRepository<Order, OrderDetail, OrderExtend, OrderBase>
    {
        Task<OrderDetail?> CancelAsync(int orderId, int userId);
    }

    public class CustomerOrderRepository : CustomerBaseRepository<Order, OrderDetail, OrderExtend, OrderBase>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(FahasaStoreDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override async Task<OrderDetail> AddAsync(OrderBase model, int userId)
        {
            model.UserId = userId;
            model.IsComplete = false;

            Order entity = _mapper.Map<Order>(model);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            var cartItems = await _context.CartItems
                .ProjectTo<CartItemDetail>(_mapper.ConfigurationProvider)
                .Where(ci => model.CartItemIds.Contains(ci.Id) && ci.UserId == userId)
                .ToListAsync();

            foreach (var cartItem in cartItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    UserId = userId,
                    OrderId = entity.Id,
                    BookId = cartItem.BookId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Book != null ? cartItem.Book.Price : 0,
                    DiscountPercentage = cartItem.Book != null ? cartItem.Book.DiscountPercentage : 0
                };
                await _context.OrderItems.AddAsync(orderItem);
            }

            var orderStatus = new OrderStatus
            {
                OrderId = entity.Id,
                StatusId = 1
            };
            await _context.OrderStatuses.AddAsync(orderStatus);

            var notify = new Notification
            {
                NotificationTypeId = 2,
                UserId = userId,
                Title = $"To User {userId}: Order #{entity.Id}",
                Content = $"Your order #{entity.Id} has been successfully placed and is being processed.",
                IsRead = false
            };
            await _context.Notifications.AddAsync(notify);
            await _context.SaveChangesAsync();

            var cartItems2 = await _context.CartItems
                .Where(ci => model.CartItemIds.Contains(ci.Id) && ci.UserId == userId)
                .ToListAsync();
            _context.CartItems.RemoveRange(cartItems2);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDetail>(entity);
        }

        public async Task<OrderDetail?> CancelAsync(int orderId, int userId)
        {
            var order = await _context.Orders
                .ProjectTo<OrderDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id.Equals(orderId) && e.UserId.Equals(userId));

            if (order.CountOrderStatuses <= 2)
            {
                var status = await _context.Statuses
                    .ProjectTo<StatusBase>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(e => e.Name.Equals(OrderStatusConst.Cancelled));

                if (status == null)
                {
                    var newStatus = new Status
                    {
                        Name = OrderStatusConst.Cancelled
                    };
                    _context.Statuses.Add(newStatus);
                    await _context.SaveChangesAsync();

                    status = _mapper.Map<StatusBase>(newStatus);
                }

                var os = new OrderStatus
                {
                    OrderId = orderId,
                    StatusId = status.Id
                };
                _context.OrderStatuses.Add(os);

                var notify = new Notification
                {
                    NotificationTypeId = 2,
                    UserId = userId,
                    Title = $"To User {userId}: Order #{orderId}",
                    Content = $"Your order #{orderId} has been successfully canceled.",
                    IsRead = false
                };
                await _context.Notifications.AddAsync(notify);

                await _context.SaveChangesAsync();

                var reOrder = await _context.Orders
                .ProjectTo<OrderDetail>(_mapper.ConfigurationProvider)
                .FirstAsync(e => e.Id.Equals(orderId) && e.UserId.Equals(userId));
                return reOrder;
            }
            return null;
        }
    }
    #endregion

    #region OrderItem
    public interface ICustomerOrderItemRepository : ICustomerBaseRepository<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>
    {
    }

    public class CustomerOrderItemRepository : CustomerBaseRepository<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>, ICustomerOrderItemRepository
    {
        public CustomerOrderItemRepository(FahasaStoreDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
    #endregion

    #region CartItem
    public interface ICustomerCartItemRepository : ICustomerBaseRepository<CartItem, CartItemDetail, CartItemDetail, CartItemBase>
    {
    }

    public class CustomerCartItemRepository : CustomerBaseRepository<CartItem, CartItemDetail, CartItemDetail, CartItemBase>, ICustomerCartItemRepository
    {
        public CustomerCartItemRepository(FahasaStoreDBContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<CartItemDetail> AddAsync(CartItemBase model, int userId)
        {
            model.UserId = userId;
            var existingBookInCart = await _context.CartItems
                .FirstOrDefaultAsync(e => e.BookId.Equals(model.BookId) && e.CartId.Equals(model.CartId));
            if (existingBookInCart == null)
            {
                return await base.AddAsync(model, userId);
            }
            existingBookInCart.Quantity = model.Quantity;
            _context.Entry(existingBookInCart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<CartItemDetail>(existingBookInCart);
        }
    }
    #endregion

    #region Review
    public interface ICustomerReviewRepository : ICustomerBaseRepository<Review, ReviewDetail, ReviewExtend, ReviewBase>
    {
    }

    public class CustomerReviewRepository : CustomerBaseRepository<Review, ReviewDetail, ReviewExtend, ReviewBase>, ICustomerReviewRepository
    {
        public CustomerReviewRepository(FahasaStoreDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
    #endregion

    #region Favourite
    public interface ICustomerFavouriteRepository : ICustomerBaseRepository<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>
    {
    }

    public class CustomerFavouriteRepository : CustomerBaseRepository<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>, ICustomerFavouriteRepository
    {
        public CustomerFavouriteRepository(FahasaStoreDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
    #endregion

}
