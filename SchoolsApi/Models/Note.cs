using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SchoolsApi.Models
{
    public class Note
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Value { get; set; }
        public string Matter { get; set; }
        public string Date { get; set; }
    }
}
