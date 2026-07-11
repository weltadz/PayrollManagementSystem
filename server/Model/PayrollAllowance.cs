namespace server.Model;

public class PayrollAllowance
{
    public Guid PayrollAllowanceId { get; set; }

    public decimal Amount { get; set; }

    public Guid PayrollId { get; set; }

    // Navigation
    public Payroll Payroll { get; set; } = null!;

    public Guid AllowanceTypeId { get; set; }

    //Navigation
    public AllowanceType AllowanceType { get; set; } = null!;
}