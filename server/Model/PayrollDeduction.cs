namespace server.Model;

public class PayrollDeduction
{
    public Guid PayrollDeductionId { get; set; }

    public decimal Amount { get; set; }

    public Guid PayrollId { get; set; }

    //Navigation
    public Payroll Payroll { get; set; } = null!;

    public Guid DeductionTypeId { get; set; }

    //Navigation
    public DeductionType DeductionType { get; set; } = null!;
}