using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    private readonly DbSet<Student> _students;
    public StudentRepository(AppDbContext context):base(context)
    {
        _students = context.Students;
    }
    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _students.Include(s=>s.Department).ToListAsync();
    }
}
