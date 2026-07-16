using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class Employee
{
    public Guid EmployeeId { get; set; }

    [Required]
    [MaxLength(20)]
    public string EmployeeNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(60)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(60)]
    public string? MiddleName { get; set; }

    [Required]
    [MaxLength(60)]
    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    [MaxLength(60)]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly HireDate { get; set; }

    public decimal BasicSalary { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Attendance> Attendances { get; set;} = new List<Attendance>();

    public ICollection<EmployeeAllowance> EmployeeAllowances { get; set;} = new List<EmployeeAllowance>();

    public ICollection<EmployeeDeduction> EmployeeDeductions { get; set;} = new List<EmployeeDeduction>();

    public ICollection<Payroll> Payrolls { get; set;} = new List<Payroll>();

    public Guid DepartmentId { get; set; }

    // Navigation
    public Department Department { get; set; } = null!;

    public Guid? UserId { get; set; }

    // Navigation
    public User? User { get; set; }

    public Guid PositionId { get; set;}

    //Navigation
    public Position Position { get; set;} = null!;

    public Guid EmploymentTypeId { get; set;}

    //Navigation
    public EmploymentType EmploymentType { get; set;} = null!;

    public Guid AttendanceStatusId {get; set;}

    //Navigation
    public AttendanceStatus AttendanceStatus { get; set;} = null!;

    public Guid EmploymentStatusId { get; set;}

    //Navigation
    public EmploymentStatus EmploymentStatus { get; set;} = null!;

    public Guid PayFrequencyId { get; set;}

    //Navigation
    public PayFrequency PayFrequency { get; set;} = null!;

    public Guid PayrollStatusId { get; set;}

    //Navigation
    public PayrollStatus PayrollStatus { get; set;} = null!;

    public Guid SalaryTypeId { get; set;}

    //Navigation
    public SalaryType SalaryType { get; set;} = null!;
}