using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.Dtos.SubscribeDto
{
    public class CreateSubscriberDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Email { get; set; }
        public DateTime SubscriptionDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public bool IsActive { get; set; } = true;
    }
}
