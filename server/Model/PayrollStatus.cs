using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class PayrollStatus
{
    public Guid PayrollStatusId { get; set;}

    [Required]
    [MaxLength(60)]
    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;} = true;

    public ICollection<Employee> Employees { get; set;} = new List<Employee>();

    public ICollection<Payroll> Payrolls { get; set;} = new List<Payroll>();
}