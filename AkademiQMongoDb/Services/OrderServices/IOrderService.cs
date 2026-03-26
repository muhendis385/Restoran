using AkademiQMongoDb.Dtos.OrderDto;
namespace AkademiQMongoDb.Services.OrderServices
{
    
        public interface IOrderService
        {
            // Tüm siparişleri listelemek için (Admin Paneli)
            Task<List<ResultOrderDto>> GetAllOrderAsync();

            // Yeni bir sipariş oluşturmak için (UI Tarafı)
            Task CreateOrderAsync(CreateOrderDto createOrderDto);

            // Belirli bir siparişi silmek için (Admin Paneli)
            Task DeleteOrderAsync(string id);

            // Sipariş detayını görmek istersen (Opsiyonel)
            Task<GetByIdOrderDto> GetOrderByIdAsync(string id);

            // Siparişi "Tamamlandı" olarak işaretlemek veya güncellemek için
            Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);
        }
    }

