using Microsoft.EntityFrameworkCore;
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

    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var student = await _studentRepository.GetTableNoTracking()
                        .Include(s=>s.Department)
                        .Where(s=> s.StudID.Equals(studentId))
                        .FirstOrDefaultAsync();
        return student!;
    }

    public async Task<string> AddStudentAsync(Student student)
    {
        var existingStudent = _studentRepository.GetTableNoTracking().Where(s=>s.Name == student.Name).FirstOrDefault();
        if (existingStudent is not null) return $"exist";

        await _studentRepository.AddAsync(student);
        return "success";
    }

    #endregion
}
