
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;

namespace SchoolProject.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Subject> Subjects { get; set; }
}
