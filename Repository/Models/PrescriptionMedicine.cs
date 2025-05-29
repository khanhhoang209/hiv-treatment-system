using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("PrescriptionMedicines")]
    public class PrescriptionMedicine
    {
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public string Instructions { get; set; }
        public DateTimeOffset MedicationTime { get; set; }
        public decimal BoughtPrice { get; set; }
    }
}
