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
        [Key]
        public Guid Id { get; set; }
        public Guid MedicalRecordId { get; set; }
        public Guid TypeId { get; set; }
        public Guid? ArvRegimentId { get; set; }
        public decimal BoughtPrice { get; set; }

        [ForeignKey("MedicalRecordId")]
        [InverseProperty("TestResults")]
        public virtual MedicalRecord MedicalRecord { get; set; }

        [ForeignKey("TypeId")]
        [InverseProperty("TestResults")]
        public virtual Type Type { get; set; }

        [ForeignKey("ArvRegimentId")]
        [InverseProperty("TestResults")]
        public virtual ArvRegimen ArvRegimen { get; set; }
    }
}
