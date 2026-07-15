namespace server.DTOs;

public class UpdateDepartmentRequestDto
{
    public Guid DepartmentId { get; set;}

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}