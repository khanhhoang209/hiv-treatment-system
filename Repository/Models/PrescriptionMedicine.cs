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
        [Key]
        public Guid MedicineId { get; set; } // FK đến Medicine
        public Guid PrescriptionId { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset MedicationTime { get; set; }
        public decimal BoughtPrice { get; set; }

        [ForeignKey("MedicineId")]
        [InverseProperty("PrescriptionMedicines")]
        public virtual Medicine Medicine { get; set; }


        [ForeignKey("PrescriptionId")]
        [InverseProperty("PrescriptionMedicines")]
        public virtual Prescription Prescription { get; set; }
    }
}
