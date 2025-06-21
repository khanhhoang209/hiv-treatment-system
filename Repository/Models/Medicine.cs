using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [InverseProperty("Medicine")]
        public ICollection<ComboMedicine> ComboMedicines { get; set; }  = null!;

        [InverseProperty("Medicine")]
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = null!;
    }
}
