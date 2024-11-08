using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SchoolsApi.Models
{
    public class School
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Course> Courses { get; set; }

        public School()
        {
            Courses = new List<Course>();
        }
    }
}
