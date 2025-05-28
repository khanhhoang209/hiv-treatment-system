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
        [Key]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public bool IsActice { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Doctor")]
        public virtual Employee Employee { get; set; }

        [InverseProperty("Doctor")]
        public ICollection<Appointment> Appointments { get; set; }

        [InverseProperty("Doctor")]
        public ICollection<MedicalRecord> MedicalRecords { get; set; }

        [InverseProperty("Doctor")]
        public ICollection<DoctorClinic> DoctorClinics { get; set; }

        [InverseProperty("Doctor")]
        public ICollection<Order> Orders { get; set; }
    }
}
