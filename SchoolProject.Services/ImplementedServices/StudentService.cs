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
                        .Include(s => s.Department)
                        .Where(s => s.StudID.Equals(studentId))
                        .FirstOrDefaultAsync();
        return student!;
    }

    public async Task<string> AddStudentAsync(Student student)
    {
        await _studentRepository.AddAsync(student);
        return "success";
    }

    public bool IsNameExist(string name)
    {
        var existingStudent = _studentRepository.GetTableNoTracking().Where(s => s.Name == name).FirstOrDefault();
        return existingStudent != null;
    }

    public async Task<bool> IsNameExistAsyncExcludeSelf(string name, int id)
    {
        var existingStudent = await _studentRepository.GetTableNoTracking()
            .Where(s => s.Name.Equals(name) & !s.StudID.Equals(id)).FirstOrDefaultAsync();

        return existingStudent is not null;
    }

    public async Task<string> EditStudent(Student student)
    {
        await _studentRepository.UpdateAsync(student);
        return "success";
    }

    public async Task<string> DeleteSrudent(Student student)
    {
        var transaction = _studentRepository.BeginTransaction();
        try
        {
            await _studentRepository.DeleteAsync(student);
            transaction.Commit();
            return "success";
        }
        catch
        {
            transaction.Rollback();
            return "failed";
        }
    }

    public async Task<Student> GetStudentByIdWithNoIncludesAsync(int studentId)
    {
        return await _studentRepository.GetByIdAsync(studentId);
    }

    #endregion
}
