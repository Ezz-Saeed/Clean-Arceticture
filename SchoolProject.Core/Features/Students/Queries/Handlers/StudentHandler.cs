using MediatR;
using SchoolProject.Data;
using SchoolProject.Services;

namespace SchoolProject.Core;

public class StudentHandler(IStudentService _studentService) : IRequestHandler<GetNewStudentListQuery, List<Student>>
{
    #region Methods
    public async Task<List<Student>> Handle(GetNewStudentListQuery request, CancellationToken cancellationToken)
    {
        return await _studentService.GetStudentsAsync();
    }
    #endregion

}
