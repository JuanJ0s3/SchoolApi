using SchoolApi.Contracts.Models;
using SchoolApi.Core.Services.Interfaces;
using SchoolApi.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SchoolApi.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> AddStudent(Student student)
        {
            await _studentRepository.AddStudent(student);
            return true;
        }

        public async Task<Student> GetStudentAsync(string id)
        {
            return await _studentRepository.GetStudent(id);
        }

        public async Task<bool> DeleteStudentByDocument(string document)
        {
            return await _studentRepository.DeleteStudentByDocument(document);
        }
    }
}
