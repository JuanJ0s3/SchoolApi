using SchoolsApi.Models;

namespace SchoolApi.Core.Services.Interfaces
{
    public interface ISchoolService
    {
        Task<bool> AddSchool(School school);
        Task<School> GetSchoolAsync(string id);
        Task<bool> DeleteSchoolByName(string name);
    }
}
