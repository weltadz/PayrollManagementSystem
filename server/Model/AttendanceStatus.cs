using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class AttendanceStatus
{
    public Guid AttendanceStatusId { get; set;}

    [Required]
    [MaxLength(60)]
    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;} = true;

    public ICollection<Employee> Employees { get; set;} = new List<Employee>();

    public ICollection<Attendance> Attendances { get; set;} = new List<Attendance>();
}

