using AkademiQMongoDb.Dtos.OrderDto;
using AkademiQMongoDb.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OrderList()
        {
            var values = await _orderService.GetAllOrderAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            System.Diagnostics.Debug.WriteLine($"Gelen Ürün: {createOrderDto.ProductName}, Fiyat: {createOrderDto.Price}");

            createOrderDto.OrderDate = DateTime.UtcNow.AddHours(3);
            createOrderDto.IsCompleted = false;

            await _orderService.CreateOrderAsync(createOrderDto);
            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction("OrderList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(string id)
        {
            var value = await _orderService.GetOrderByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _orderService.UpdateOrderAsync(updateOrderDto);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> CompleteOrder(string id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order != null)
            {
                // Basit bir eşleme yaparak durumu true yapıyoruz
                var updateDto = new UpdateOrderDto
                {
                    OrderId = order.OrderId,
                    CustomerName = order.CustomerName,
                    CustomerEmail = order.CustomerEmail,
                    ProductName = order.ProductName,
                    Price = order.Price,
                    Address = order.Address,
                    OrderDate = order.OrderDate,
                    IsCompleted = true
                };
                await _orderService.UpdateOrderAsync(updateDto);
            }
            return RedirectToAction("OrderList");
        }

    }
}
