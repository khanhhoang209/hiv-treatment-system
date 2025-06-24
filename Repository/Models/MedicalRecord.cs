using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("MedicalRecord")]
    public class MedicalRecord
    {
        public Guid Id { get; set; }
        public DateTime RecordDate { get; set; }
        public string Diagnosis { get; set; } = null!;
        public string Treatment { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public Prescription Prescription { get; set; } = null!;
        public ICollection<TestResult> TestResults { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
    }
}
