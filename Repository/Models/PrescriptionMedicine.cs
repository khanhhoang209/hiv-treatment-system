using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("PrescriptionMedicine")]
    public class PrescriptionMedicine
    {
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; } = null!;
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
        public int Quantity { get; set; }
        public string Dosage { get; set; } = null!;
        public string Instructions { get; set; } = null!;
        public DateTimeOffset MedicationTime { get; set; }
        public decimal BoughtPrice { get; set; }
    }
}
