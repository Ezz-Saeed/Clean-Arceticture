using AutoMapper;
using SchoolProject.Data;

namespace SchoolProject.Core;

public partial class StudentProfile : Profile
{
    public StudentProfile()
    {
        // CreateMap<Student, GetStudentListResponse>()
        // .ForMember(d=>d.DepartmentName, opt=>opt.MapFrom(s=>s.Department.DName));
        GetStudentListMapping();
    }
}
