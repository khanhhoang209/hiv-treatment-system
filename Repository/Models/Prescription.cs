using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Prescriptions")]
    public class Prescription
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MedicalRecordId { get; set; }

        [ForeignKey("MedicalRecordId")]
        [InverseProperty("Prescription")]
        public virtual MedicalRecord MedicalRecord { get; set; }

        [InverseProperty("Prescription")]
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
