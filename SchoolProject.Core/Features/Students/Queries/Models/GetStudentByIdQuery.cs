using MediatR;
using SchoolProject.Core.Basis;
using SchoolProject.Core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentByIdResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
