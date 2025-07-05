using AutoMapper;
using MediatR;
using SchoolProject.Core.Basis;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data;
using SchoolProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.CommandHandlers
{
    public class StudentCommandHandler(IStudentService _studentService, IMapper _mapper) : 
        ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var result = await _studentService.AddStudentAsync(student);

            if (result == "exist")
                return UnprocessableEntity<string>($"Student with name {student.Name} alredy exists!");

            else if (result == "success") return Created("Student addedsuccessfully.");

            else return BadRequest<string>();
        }
    }
}
