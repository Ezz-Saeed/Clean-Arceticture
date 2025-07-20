namespace SchoolProject.Core.Features.Students.Queries.Results
{
    public class GetNewStudentPaginatedListResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? DepartmentName { get; set; }

        public GetNewStudentPaginatedListResponse(int studID, string name, string address, string? departmentName)
        {
            StudID = studID;
            Name = name;
            Address = address;
            DepartmentName = departmentName;
        }
    }
}
