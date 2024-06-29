using AutoMapper;
using OnlineStore.BLL.DTOs;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;


namespace OnlineStore.BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderItemDTO>> GetAllOrderItemsAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems);
        }

        public async Task<OrderItemDTO> GetOrderItemByIdAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public async Task AddOrderItemAsync(OrderItemDTO orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            await _orderItemRepository.AddAsync(orderItem);
        }

        public async Task UpdateOrderItemAsync(int id, OrderItemDTO orderItemDto)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemDto);
            orderItem.OrderItemId = id;
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }
    }
}
