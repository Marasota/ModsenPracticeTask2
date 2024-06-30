using OnlineStore.BLL.DTOs;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDTO>> GetAllOrderItemsAsync();
        Task<OrderItemDTO> GetOrderItemByIdAsync(int id);
        Task AddOrderItemAsync(OrderItemDTO orderItemDto);
        Task UpdateOrderItemAsync(int id, OrderItemDTO orderItemDto);
        Task DeleteOrderItemAsync(int id);
    }
}
