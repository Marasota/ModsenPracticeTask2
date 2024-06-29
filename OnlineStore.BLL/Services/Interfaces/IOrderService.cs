using OnlineStore.BLL.DTOs;


namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(int userId);
        Task AddOrderAsync(OrderDTO orderDto);
        Task UpdateOrderAsync(int id, OrderDTO orderDto);
        Task DeleteOrderAsync(int id);
    }
}
