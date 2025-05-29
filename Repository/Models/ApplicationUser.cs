using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class ApplicationUser
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Status { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<MedicalRecord> MedicalRecords { get; set; }
    public ICollection<Order> Orders { get; set; }
}