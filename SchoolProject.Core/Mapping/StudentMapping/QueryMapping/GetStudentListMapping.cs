using SchoolProject.Data;

namespace SchoolProject.Core;

public partial class StudentProfile
{
    public void GetStudentListMapping()
    {
         CreateMap<Student, GetStudentListResponse>()
        .ForMember(d=>d.DepartmentName, opt=>opt.MapFrom(s=>s.Department.DName));
    }
}      

