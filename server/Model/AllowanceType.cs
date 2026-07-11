using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class AllowanceType
{
    public Guid AllowanceTypeId { get; set; }

    [Required]
    [MaxLength(60)]
    public string Name { get; set; } = string.Empty;

    public bool IsTaxable { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<EmployeeAllowance> EmployeeAllowances { get; set;} = new List<EmployeeAllowance>();

    public ICollection<PayrollAllowance> PayrollAllowances { get; set;} = new List<PayrollAllowance>(); 

}