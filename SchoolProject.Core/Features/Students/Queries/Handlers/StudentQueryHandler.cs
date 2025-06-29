using AutoMapper;
using MediatR;
using SchoolProject.Core.Basis;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data;
using SchoolProject.Services;

namespace SchoolProject.Core;

public class StudentQueryHandler(IStudentService _studentService, IMapper _mapper) : ResponseHandler,
    IRequestHandler<GetNewStudentListQuery, Response<List<GetStudentListResponse>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>
{
    #region Methods
    public async Task<Response<List<GetStudentListResponse>>> Handle(GetNewStudentListQuery request,
    CancellationToken cancellationToken)
    {
        var studentList = await _studentService.GetStudentsAsync();
        var studentRes = _mapper.Map<List<GetStudentListResponse>>(studentList);
        return Success(studentRes);
    }

    public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentByIdAsync(request.Id);
        if (student is null) return NotFound<GetStudentByIdResponse>("");
        
        var res = _mapper.Map<GetStudentByIdResponse>(student);
        return Success(res);
    }
    #endregion

}
