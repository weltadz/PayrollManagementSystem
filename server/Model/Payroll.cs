using server.Model.Enums;

namespace server.Model;

public class Payroll
{
    public Guid PayrollId { get; set; }

    public decimal BasicPay { get; set; }

    public decimal TotalAllowances { get; set; }

    public decimal TotalDeductions { get; set; }

    public decimal GrossPay { get; set; }

    public decimal NetPay { get; set; }

    public PayrollStatus PayrollStatus { get; set;} = PayrollStatus.Draft;

    public ICollection<PayrollAllowance> PayrollAllowances { get; set;} = new List<PayrollAllowance>();

    public ICollection<PayrollDeduction> PayrollDeductions { get; set;} = new List<PayrollDeduction>();

    public Guid EmployeeId { get; set; }

    // Navigation
    public Employee Employee { get; set; } = null!;

    public Guid PayrollPeriodId { get; set; }

    // Navigation
    public PayrollPeriod PayrollPeriod { get; set; } = null!;
}