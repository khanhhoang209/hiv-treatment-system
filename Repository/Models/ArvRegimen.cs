using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("ArvRegimens")]
    public class ArvRegimen
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        [InverseProperty("ArvRegimen")]
        public ICollection<TestResult> TestResults { get; set; }

        [InverseProperty("ArvRegimen")]
        public ICollection<ComboMedicine> ComboMedicines { get; set; }
    }
}
