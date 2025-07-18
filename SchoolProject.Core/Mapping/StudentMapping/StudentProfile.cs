using AutoMapper;

namespace SchoolProject.Core;

public partial class StudentProfile : Profile
{
    public StudentProfile()
    {
        GetStudentListMapping();
        GetStudentByIdMapping();
        AddStudentCommandMapping();
        EditStudentCommandMapping();
    }
}
