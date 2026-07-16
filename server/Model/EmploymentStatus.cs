using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class EmploymentStatus
{
    public Guid EmploymentStatusId { get; set;}

    [Required]
    [MaxLength(60)]
    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;} = true;

    public ICollection<Employee> Employees { get; set;} = new List<Employee>();
}