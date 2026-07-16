namespace server.DTOs;

public class CreateEmploymentTypeRequestDto
{
    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;}
}