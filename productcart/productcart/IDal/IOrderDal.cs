using productcart.Dto;

namespace productcart.IDal
{
    public interface IOrderDal
    {
        public Task<orderDto> CreateOrder(orderDto Orderdto);
        public Task CancelOrder(int OrderId);
        public Task<orderinfoDto> FetchOrderById(int OrderId);
        public Task<orderinfoDto> FetchOrderByOrderNumber(string OrderId);

        public Task<allorderDto> FetchAllOrderByUser(int userId);

    }
}
