namespace AkademiQMongoDb.Dtos.OrderDto
{
    public class CreateOrderDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now; // Varsayılan anlık tarih
        public bool IsCompleted { get; set; } = false; // Yeni sipariş varsayılan olarak "Tamamlanmadı"
    }
}

