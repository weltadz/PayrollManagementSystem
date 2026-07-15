namespace server.DTOs;

public class GetPositionResponseDto
{
    public Guid PositionId { get; set;}

    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;}
}