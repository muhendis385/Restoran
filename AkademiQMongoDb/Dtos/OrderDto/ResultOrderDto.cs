namespace AkademiQMongoDb.Dtos.OrderDto
{
    public class ResultOrderDto
    {
        public string OrderId { get; set; } // MongoDB ID'si
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; } // Sipariş teslim edildi mi?

    }
}
