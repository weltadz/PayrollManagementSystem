using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class DeductionType
{
    public Guid DeductionTypeId { get; set; }

    [Required]
    [MaxLength(60)]
    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<EmployeeDeduction> EmployeeDeductions { get; set;} = new List<EmployeeDeduction>();

    public ICollection<PayrollDeduction> PayrollDeductions { get; set;} = new List<PayrollDeduction>();
}