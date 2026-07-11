namespace server.Model;

public class PayrollPeriod
{
    public Guid PayrollPeriodId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public DateOnly PayDate { get; set; }

    public ICollection<Payroll> Payrolls { get; set;} = new List<Payroll>();
}