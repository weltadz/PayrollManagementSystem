using System.ComponentModel.DataAnnotations;
using server.Model.Enums;

namespace server.Model;

public class Attendance
{
    public Guid AttendanceId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public TimeOnly? TimeIn { get; set; }

    public TimeOnly? TimeOut { get; set; }

    public decimal RegularHours { get; set; }

    public decimal OvertimeHours { get; set; }

    public int LateMinutes { get; set; }

    public int UndertimeMinutes { get; set; }

    public AttendanceStatus AttendanceStatus { get; set;}

    public Guid EmployeeId { get; set; }

    // Navigation
    public Employee Employee { get; set; } = null!;
}