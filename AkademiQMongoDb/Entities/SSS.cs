using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.Entities
{
    public class SSS
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SSSId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
