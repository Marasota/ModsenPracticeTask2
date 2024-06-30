using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.DTOs;
using OnlineStore.BLL.Services.Interfaces;

namespace OnlineStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id);
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderItem(OrderItemDTO orderItemDto)
        {
            await _orderItemService.AddOrderItemAsync(orderItemDto);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItemDto.Id }, orderItemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItemDTO orderItemDto)
        {
            await _orderItemService.UpdateOrderItemAsync(id, orderItemDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _orderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }
    }
}
