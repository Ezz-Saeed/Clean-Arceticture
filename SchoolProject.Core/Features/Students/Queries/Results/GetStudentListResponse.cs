﻿namespace SchoolProject.Core;

public class GetStudentListResponse
{
    public int StudID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string? DepartmentName { get; set; }
    public int? DID { get; set; }
}
