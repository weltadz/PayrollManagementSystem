namespace server.DTOs;

public class UpdateAttendanceStatusRequestDto
{
    public Guid AttendanceStatusId { get; set;}

    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;}
}