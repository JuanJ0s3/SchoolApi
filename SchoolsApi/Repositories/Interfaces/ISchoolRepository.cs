using SchoolApi.Contracts.Models;
using SchoolsApi.Models;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Repositories.Interfaces
{
    public interface ISchoolRepository
    {
        Task AddSchool(School school);
        Task<School> GetSchoolById(string id);
        Task<bool> DeleteSchoolByName(string name);
    }
}
