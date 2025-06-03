using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Staff")]
    public class Staff
    {
        public Guid Id { get; set; }
        public string Position { get; set; } = null!;
        public string Department { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public ICollection<StaffClinic> StaffClinics { get; set; } = null!;
    }
}
