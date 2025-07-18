using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data;

namespace SchoolProject.Core
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(d => d.DID, opt => opt.MapFrom(s => s.DepartmentId))
                .ForMember(d => d.StudID, opt => opt.MapFrom(s => s.Id));
        }
    }
}
