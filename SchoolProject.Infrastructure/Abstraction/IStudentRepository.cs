using SchoolProject.Data;

namespace SchoolProject.Infrastructure;

public interface IStudentRepository
{
    Task<List<Student>> GetStudentsAsync();
}
