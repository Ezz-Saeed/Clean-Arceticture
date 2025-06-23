using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;

namespace SchoolProject.Infrastructure;

public class StudentRepository(AppDbContext _context) : IStudentRepository
{
    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }
}
