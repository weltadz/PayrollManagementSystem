using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.EmployeeNumber)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .Property(e => e.BasicSalary)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EmployeeAllowance>()
            .Property(e => e.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<EmployeeAllowance>()
            .HasIndex(ea => new
            {
                ea.EmployeeId,
                ea.AllowanceTypeId
            })
            .IsUnique();

        modelBuilder.Entity<EmployeeDeduction>()
            .Property(e => e.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<EmployeeDeduction>()
            .HasIndex(ed => new
            {
                ed.EmployeeId,
                ed.DeductionTypeId
            })
            .IsUnique();

        modelBuilder.Entity<Payroll>()
            .Property(e => e.BasicPay)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payroll>()
            .Property(e => e.TotalAllowances)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payroll>()
            .Property(e => e.TotalDeductions)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payroll>()
            .Property(e => e.GrossPay)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payroll>()
            .Property(e => e.NetPay)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payroll>()
            .HasOne(p => p.Employee)
            .WithMany(e => e.Payrolls)
            .HasForeignKey(p => p.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payroll>()
            .HasOne(p => p.PayrollPeriod)
            .WithMany(pp => pp.Payrolls)
            .HasForeignKey(p => p.PayrollPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payroll>()
            .HasIndex(p => new
            {
                p.EmployeeId,
                p.PayrollPeriodId
            })
            .IsUnique();

        modelBuilder.Entity<PayrollAllowance>()
            .Property(e => e.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<PayrollDeduction>()
            .Property(e => e.Amount)
            .HasPrecision(18, 2);
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Attendance> Attendances => Set<Attendance>();

    public DbSet<AllowanceType> AllowanceTypes => Set<AllowanceType>();

    public DbSet<EmployeeAllowance> EmployeeAllowances => Set<EmployeeAllowance>();

    public DbSet<DeductionType> DeductionTypes => Set<DeductionType>();

    public DbSet<EmployeeDeduction> EmployeeDeductions => Set<EmployeeDeduction>();

    public DbSet<PayrollPeriod> PayrollPeriods => Set<PayrollPeriod>();

    public DbSet<Payroll> Payrolls => Set<Payroll>();

    public DbSet<PayrollAllowance> PayrollAllowances => Set<PayrollAllowance>();

    public DbSet<PayrollDeduction> PayrollDeductions => Set<PayrollDeduction>();
}