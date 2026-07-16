using System.ComponentModel.DataAnnotations;

namespace server.Model;

public class PayFrequency
{
    public Guid PayFrequencyId { get; set;}

    public string Name { get; set;} = string.Empty;

    public bool IsActive { get; set;} = true;

    public ICollection<Employee> Employees { get; set;} = new List<Employee>();
}