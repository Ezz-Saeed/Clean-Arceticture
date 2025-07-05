using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(d=>d.DID, opt=>opt.MapFrom(s=>s.DepartmentId));
        }
    }
}
