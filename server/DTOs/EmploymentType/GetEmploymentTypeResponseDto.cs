namespace server.DTOs;

public class GetEmploymentTypeResponseDto
{
    public Guid EmploymentTypeId { get; set;}

    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;}
}