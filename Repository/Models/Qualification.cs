using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Qualifications")]
    public class Qualification
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string DegreeName { get; set; }
        public string Description { get; set; }
        public string Faculty { get; set; }
        public string Major { get; set; }
        public string Grade { get; set; }
        public string Institution { get; set; }
        public DateTimeOffset IssuedAt { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Qualifications")]
        public virtual Employee Employee { get; set; }
    }
}
