using AutoMapper;
using MediatR;
using SchoolProject.Core.Basis;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data;
using SchoolProject.Services;
using System.Linq.Expressions;

namespace SchoolProject.Core;

public class StudentQueryHandler(IStudentService _studentService, IMapper _mapper) : ResponseHandler,
    IRequestHandler<GetNewStudentListQuery, Response<List<GetStudentListResponse>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>,
    IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetNewStudentPaginatedListResponse>>

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

    public async Task<PaginatedResult<GetNewStudentPaginatedListResponse>>
        Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Student, GetNewStudentPaginatedListResponse>> expressiom = stu =>
        new GetNewStudentPaginatedListResponse(stu.StudID, stu.Name, stu.Address, stu.Department.DName);

        var studentQuery = _studentService.GetStudentQuery();
        var studentQueryWithSearch = _studentService.GetStudentQueryWithSearch(request.Search);
        var paginatedResult = await studentQueryWithSearch.Select(expressiom).ToPaginatedListAsync(request.PageNumber, request.PageSize);
        return paginatedResult;
    }
    #endregion

}
