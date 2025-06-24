using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Prescription")]
    public class Prescription
    {
        public Guid Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; } = null!;
        public Guid MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = null!;
    }
}
