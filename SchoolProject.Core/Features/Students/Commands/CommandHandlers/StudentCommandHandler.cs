using AutoMapper;
using MediatR;
using SchoolProject.Core.Basis;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data;
using SchoolProject.Services;

namespace SchoolProject.Core.Features.Students.Commands.CommandHandlers
{
    public class StudentCommandHandler(IStudentService _studentService, IMapper _mapper) :
        ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>
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

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student is null) return NotFound<string>($"Student with ID {request.Id} does not exist!");

            var mappedStudent = _mapper.Map<Student>(request);

            var result = await _studentService.AddStudentAsync(student);
            if (result == "success") return Success("Student updated successfully");

            return BadRequest<string>();
        }
    }
}
