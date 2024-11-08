using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SchoolsApi.Models;

namespace SchoolApi.Contracts.Models
{
    public class Student
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Document {  get; set; }
        public string Email { get; set; }
        public Position Studentposition { get; set; }
        public List<Note> Notes { get; set; }

        public Student()
        {
            Notes = new List<Note>();
        }
    }
}
