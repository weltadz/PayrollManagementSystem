namespace server.Model;

public class EmployeeDeduction
{
    public Guid EmployeeDeductionId { get; set; }

    public decimal Amount { get; set; }

    public Guid EmployeeId { get; set; }

    // Navigation
    public Employee Employee { get; set; } = null!;

    public Guid DeductionTypeId { get; set; }

    // Navigation
    public DeductionType DeductionType { get; set; } = null!;
}