using SchoolApi.Contracts.Models;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task AddStudent(Student student);
        Task<Student> GetStudent(string id);
        Task<bool> DeleteStudentByDocument(string document);
    }
}
