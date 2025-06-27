using MediatR;
using SchoolProject.Core.Basis;
using SchoolProject.Data;

namespace SchoolProject.Core;

public class GetNewStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
{

}
