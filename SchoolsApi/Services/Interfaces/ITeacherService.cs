using SchoolApi.Contracts.Models;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace SchoolApi.Core.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<bool> AddTeacher(Teacher teacher);
        Task<Teacher> GetTeacherByName(string name);
    }
}
