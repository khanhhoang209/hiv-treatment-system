using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("TestResults")]
    public class TestResult
    {
        public Guid Id { get; set; }
        public DateTime TestDate { get; set; }
        public string Result { get; set; }
        public string Notes { get; set; }
        public Guid MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public Guid TypeId { get; set; }
        public Type Type { get; set; }
        public Guid ArvRegimentId { get; set; }
        public ArvRegimen ArvRegimen { get; set; }
    }
}
