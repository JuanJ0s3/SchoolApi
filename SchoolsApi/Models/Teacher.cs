using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SchoolsApi.Models
{
    public class Teacher 
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
    }
}
