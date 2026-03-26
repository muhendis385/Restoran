using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.Entities
{
    public class AboutList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutListId { get; set; }
        public string Title { get; set; }
        public string IconUrl { get; set; }
    }
}
