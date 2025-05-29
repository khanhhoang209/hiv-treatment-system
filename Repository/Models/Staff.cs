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
        public Guid Id { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<StaffClinic> StaffClinics { get; set; }
    }
}
