using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class ApplicationUser
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = null!;
    public string Status { get; set; } = null!;
    public Guid RoleId { get; set; }    
    public Role Role { get; set; } = null!;
    public ICollection<Employee> Employees { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; } = null!;
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = null!;
    public ICollection<UserNotification> UserNotifications { get; set; } = null!;
}