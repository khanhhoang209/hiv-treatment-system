using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

[Table("ApplicationUsers")]
public class ApplicationUser 
{
    [Key]
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; }

    [InverseProperty("User")]
    public ICollection<Employee> Employees { get; set; }

    [InverseProperty("User")]
    public ICollection<Appointment> Appointments { get; set; }

    [InverseProperty("User")]
    public ICollection<MedicalRecord> MedicalRecords { get; set; }

    [InverseProperty("User")]
    public ICollection<Order> Orders { get; set; }
}