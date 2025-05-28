using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Staffs")]
    public class Staff
    {
        [Key]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public bool IsActice { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Staff")]
        public virtual Employee Employee { get; set; }

        [InverseProperty("Staff")]
        public ICollection<StaffClinic> StaffClinics { get; set; }
    }
}
