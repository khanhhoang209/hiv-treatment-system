using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("TestResult")]
    public class TestResult
    {
        public Guid Id { get; set; }
        public DateTime TestDate { get; set; }
        public string Result { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public Guid MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;
        public Guid TypeId { get; set; }
        public Type Type { get; set; } = null!;
        public Guid? ArvRegimentId { get; set; }
        public ArvRegimen ArvRegimen { get; set; } = null!;
    }
}
