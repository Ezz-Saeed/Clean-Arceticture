using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Controllers;
using SchoolProject.Core;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace MyApp.Namespace
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentsController : AppControllerBase
    {
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var response = await Mediator.Send(new GetNewStudentListQuery());
            return Ok(response);
        }

        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create(AddStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
