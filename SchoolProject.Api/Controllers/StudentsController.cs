using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
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

        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> Edit(EditStudentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
