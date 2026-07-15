namespace server.DTOs;

public class GetDepartmentResponseDto
{
    public Guid DepartmentId { get; set;}

    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;}
}