using SchoolApi.Contracts.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SchoolsApi.Models
{
    public class Course
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public Teacher AssignedTeacher { get; set; }
        public List<Student> EnrolledStudents { get; set; }

        public Course()
        {
            EnrolledStudents = new List<Student>();
        }
    }
}
