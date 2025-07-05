using AutoMapper;
using SchoolProject.Data;

namespace SchoolProject.Core;

public partial class StudentProfile : Profile
{
    public StudentProfile()
    {
        GetStudentListMapping();
        GetStudentByIdMapping();
        AddStudentCommandMapping();
    }
}
