using SchoolProject.Data;
using SchoolProject.Infrastructure;

namespace SchoolProject.Services;

public class StudentService(IStudentRepository _studentRepository) : IStudentService
{
    #region Methods
    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _studentRepository.GetStudentsAsync();
    }
    #endregion
}
