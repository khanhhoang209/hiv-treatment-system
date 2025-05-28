using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("MedicalRecords")]
    public class MedicalRecord
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }
        //public Guid PrescriptionId { get; set; }
        public decimal ExaminationFee { get; set; }


        [ForeignKey("UserId")]
        [InverseProperty("MedicalRecords")]
        public virtual ApplicationUser User { get; set; }
        

        [ForeignKey("DoctorId")]
        [InverseProperty("MedicalRecords")]
        public virtual Doctor Doctor { get; set; }

        [InverseProperty("MedicalRecord")]
        public virtual Prescription Prescription { get; set; }


        [InverseProperty("MedicalRecord")]
        public ICollection<TestResult> TestResults { get; set; }


        [InverseProperty("MedicalRecord")]
        public ICollection<Order> Orders { get; set; }
    }
}
