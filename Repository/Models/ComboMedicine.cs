using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("ComboMedicines")]
    public class ComboMedicine
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ArvRegimenId { get; set; }
        public Guid MedicineId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ArvRegimenId")]
        [InverseProperty("ComboMedicines")]
        public virtual ArvRegimen ArvRegimen { get; set; }

        [ForeignKey("MedicineId")]
        [InverseProperty("ComboMedicines")]
        public virtual Medicine Medicine { get; set; }
    }
}
