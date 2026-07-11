namespace server.Model;

public class EmployeeAllowance
{
    public Guid EmployeeAllowanceId { get; set; }

    public decimal Amount { get; set; }

    public bool IsActive { get; set; } = true;

    public Guid EmployeeId { get; set; }

    // Navigation
    public Employee Employee { get; set; } = null!;

    public Guid AllowanceTypeId { get; set; }

    // Navigation
    public AllowanceType AllowanceType { get; set; } = null!;
}