using AutoMapper;
using MediatR;
using SchoolProject.Core.Basis;
using SchoolProject.Data;
using SchoolProject.Services;

namespace SchoolProject.Core;

public class StudentHandler(IStudentService _studentService, IMapper _mapper) : ResponseHandler,
IRequestHandler<GetNewStudentListQuery, Response<List<GetStudentListResponse>>>
{
    #region Methods
    public async Task<Response<List<GetStudentListResponse>>> Handle(GetNewStudentListQuery request,
    CancellationToken cancellationToken)
    {
        var studentList = await _studentService.GetStudentsAsync();
        var studentRes = _mapper.Map<List<GetStudentListResponse>>(studentList);
        return Success(studentRes);
    }
    #endregion

}
