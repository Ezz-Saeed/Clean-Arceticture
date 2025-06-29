using SchoolProject.Data;

namespace SchoolProject.Services;

public interface IStudentService
{
    Task<List<Student>> GetStudentsAsync();
    Task<Student> GetStudentByIdAsync(int studentId);
}
