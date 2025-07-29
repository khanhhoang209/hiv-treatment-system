using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Constants;

namespace Repository.Models
{
    [Table("PrescriptionMedicine")]
    public class PrescriptionMedicine
    {
        [Key, Column(Order = 0)]
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; } = null!;
        
        [Key, Column(Order = 1)]
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
        
        public int Quantity { get; set; }
        public int Dosage { get; set; }
        public string Instructions { get; set; } = null!;
        public int SumOfMedicationTime { get; set; }
        public decimal BoughtPrice { get; set; }
    }
}
