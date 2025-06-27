using SchoolProject.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<List<Student>> GetStudentsAsync();
}
