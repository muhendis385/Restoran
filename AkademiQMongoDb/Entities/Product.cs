using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public int TotalTime { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
    }
}
