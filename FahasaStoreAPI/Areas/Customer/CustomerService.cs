using FahasaStore.Models;
using FahasaStoreAPI.Areas.Base;
using FahasaStoreAPI.Areas.Customer;
using FahasaStoreAPI.Models.Entities;

namespace FahasaStoreAPI.Areas.Customer
{
    #region Address
    public interface ICustomerAddressService : ICustomerBaseService<Address, AddressDetail, AddressExtend, AddressBase>
    {
    }

    public class CustomerAddressService : CustomerBaseService<Address, AddressDetail, AddressExtend, AddressBase>, ICustomerAddressService
    {
        public CustomerAddressService(ICustomerAddressRepository customerAddressRepository) : base(customerAddressRepository)
        {
        }
    }
    #endregion

    #region Order
    public interface ICustomerOrderService : ICustomerBaseService<Order, OrderDetail, OrderExtend, OrderBase>
    {
        Task<ApiResponse<OrderDetail>> CancelAsync(int orderId, int userId);
    }

    public class CustomerOrderService : CustomerBaseService<Order, OrderDetail, OrderExtend, OrderBase>, ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;
        public CustomerOrderService(ICustomerOrderRepository customerOrderRepository) : base(customerOrderRepository)
        {
            _customerOrderRepository = customerOrderRepository;
        }

        public async Task<ApiResponse<OrderDetail>> CancelAsync(int orderId, int userId)
        {
            try
            {
                var result = await _customerOrderRepository.CancelAsync(orderId, userId);
                if (result == null)
                {
                    return new ApiResponse<OrderDetail>(status: 500, error: true, message: "Cancel Failed", data: null);
                }
                return new ApiResponse<OrderDetail>(status: 200, error: false, message: "Cancelled successfully", data: result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrderDetail>(status: 500, error: true, message: ex.Message, data: null);
            }
        }
    }
    #endregion

    #region OrderItem
    public interface ICustomerOrderItemService : ICustomerBaseService<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>
    {
    }

    public class CustomerOrderItemService : CustomerBaseService<OrderItem, OrderItemDetail, OrderItemExtend, OrderItemBase>, ICustomerOrderItemService
    {
        public CustomerOrderItemService(ICustomerOrderItemRepository customerOrderItemRepository) : base(customerOrderItemRepository)
        {
        }
    }
    #endregion

    #region CartItem
    public interface ICustomerCartItemService : ICustomerBaseService<CartItem, CartItemDetail, CartItemDetail, CartItemBase>
    {
    }

    public class CustomerCartItemService : CustomerBaseService<CartItem, CartItemDetail, CartItemDetail, CartItemBase>, ICustomerCartItemService
    {
        public CustomerCartItemService(ICustomerCartItemRepository customerCartItemRepository) : base(customerCartItemRepository)
        {
        }
    }
    #endregion

    #region Review
    public interface ICustomerReviewService : ICustomerBaseService<Review, ReviewDetail, ReviewExtend, ReviewBase>
    {
    }

    public class CustomerReviewService : CustomerBaseService<Review, ReviewDetail, ReviewExtend, ReviewBase>, ICustomerReviewService
    {
        public CustomerReviewService(ICustomerReviewRepository customerReviewRepository) : base(customerReviewRepository)
        {
        }
    }
    #endregion

    #region Favourite
    public interface ICustomerFavouriteService : ICustomerBaseService<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>
    {
    }

    public class CustomerFavouriteService : CustomerBaseService<Favourite, FavouriteDetail, FavouriteExtend, FavouriteBase>, ICustomerFavouriteService
    {
        public CustomerFavouriteService(ICustomerFavouriteRepository customerFavouriteRepository) : base(customerFavouriteRepository)
        {
        }
    }
    #endregion

}

// Extend: private readonly ICustomerOrderRepository _customerOrderRepository;