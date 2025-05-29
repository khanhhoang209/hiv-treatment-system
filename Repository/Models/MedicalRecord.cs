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
        public Guid Id { get; set; }
        public DateTime RecordDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Notes { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Prescription Prescription { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
