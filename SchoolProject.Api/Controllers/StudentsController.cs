using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("/students/list")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var response = await _mediator.Send(new GetNewStudentListQuery());
            return Ok(response);
        }

        [HttpGet("/student/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }
    }
}
