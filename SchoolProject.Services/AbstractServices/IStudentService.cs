using SchoolProject.Data;

namespace SchoolProject.Services;

public interface IStudentService
{
    Task<List<Student>> GetStudentsAsync();
    Task<Student> GetStudentByIdAsync(int studentId);
    Task<Student> GetStudentByIdWithNoIncludesAsync(int studentId);
    public Task<string> AddStudentAsync(Student student);
    bool IsNameExist(string name);
    Task<bool> IsNameExistAsyncExcludeSelf(string name, int id);
    Task<string> EditStudent(Student student);
    Task<string> DeleteSrudent(Student student);
    IQueryable<Student> GetStudentQuery();
    IQueryable<Student> GetStudentQueryWithSearch(string search);
}
