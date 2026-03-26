using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.Entities
{
    public class Subscriber
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubscriberId { get; set; }
        public string Email { get; set; }
        public DateTime SubscriptionDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public bool IsActive { get; set; } = true;
    }
}
