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
        public Guid Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; }
        public Guid MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
