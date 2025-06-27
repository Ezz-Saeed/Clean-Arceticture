using AutoMapper;
using MediatR;
using SchoolProject.Data;
using SchoolProject.Services;

namespace SchoolProject.Core;

public class StudentHandler(IStudentService _studentService, IMapper _mapper) : 
IRequestHandler<GetNewStudentListQuery, List<GetStudentListResponse>>
{
    #region Methods
    public async Task<List<GetStudentListResponse>> Handle(GetNewStudentListQuery request,
    CancellationToken cancellationToken)
    {
        var studentList = await _studentService.GetStudentsAsync();
        var studentRes = _mapper.Map<List<GetStudentListResponse>>(studentList);
        return studentRes;
    }
    #endregion

}
