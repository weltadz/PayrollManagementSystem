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

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.EmploymentType)
            .WithMany(et => et.Employees)
            .HasForeignKey(e => e.EmploymentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.AttendanceStatus)
            .WithMany(att => att.Employees)
            .HasForeignKey(e => e.AttendanceStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.EmploymentStatus)
            .WithMany(et => et.Employees)
            .HasForeignKey(e => e.EmploymentStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.PayFrequency)
            .WithMany(pf => pf.Employees)
            .HasForeignKey(e => e.PayFrequencyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.PayrollStatus)
            .WithMany(ps => ps.Employees)
            .HasForeignKey(e => e.PayrollStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.SalaryType)
            .WithMany(st => st.Employees)
            .HasForeignKey(e => e.SalaryTypeId)
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
            .HasOne(p => p.PayrollStatus)
            .WithMany(ps => ps.Payrolls)
            .HasForeignKey(p => p.PayrollStatusId)
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

        modelBuilder.Entity<Department>()
            .HasIndex(d => d.Name)
            .IsUnique();

        modelBuilder.Entity<Position>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<EmploymentType>()
            .HasIndex(et => et.Name)
            .IsUnique();

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.AttendanceStatus)
            .WithMany(att => att.Attendances)
            .HasForeignKey(a => a.AttendanceStatusId)
            .OnDelete(DeleteBehavior.Restrict);    
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

    public DbSet<Position> Positions => Set<Position>();

    public DbSet<EmploymentType> EmploymentTypes => Set<EmploymentType>();

    public DbSet<AttendanceStatus> AttendanceStatuses => Set<AttendanceStatus>();

    public DbSet<EmploymentStatus> EmploymentStatuses => Set<EmploymentStatus>();

    public DbSet<PayFrequency> PayFrequencies => Set<PayFrequency>();

    public DbSet<PayrollStatus> PayrollStatuses => Set<PayrollStatus>();

    public DbSet<SalaryType> SalaryTypes => Set<SalaryType>();
}