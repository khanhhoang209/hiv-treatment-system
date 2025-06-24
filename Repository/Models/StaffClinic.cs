using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    [Table("StaffClinic")]
    public class StaffClinic
    {
        public Guid StaffId { get; set; }
        public Guid ClinicId { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }

        [ForeignKey("StaffId")]
        [InverseProperty("StaffClinics")]
        public virtual Staff Staff { get; set; } = null!;

        [ForeignKey("ClinicId")]
        [InverseProperty("StaffClinics")]
        public virtual Clinic Clinic { get; set; } = null!;
    }
}
