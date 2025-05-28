using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Medicines")]
    public class Medicine
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [InverseProperty("Medicine")]
        public ICollection<ComboMedicine> ComboMedicines { get; set; }

        [InverseProperty("Medicine")]
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
