using SchoolProject.Core.Features.Students.Queries.Results;
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
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentByIdResponse>()
                .ForMember(d=>d.DepartmentName, opt=>opt.MapFrom(s=>s.Department.DName));
        }
    }
}
