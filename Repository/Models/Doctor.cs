using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Doctors")]
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Specialization { get; set; }
        public string LicenseNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorClinic> DoctorClinics { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
