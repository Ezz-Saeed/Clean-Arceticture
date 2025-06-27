using MediatR;
using SchoolProject.Data;

namespace SchoolProject.Core;

public class GetNewStudentListQuery : IRequest<List<GetStudentListResponse>>
{

}
