using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    [Table("DoctorClinic")]
    public class DoctorClinic
    {
        public Guid DoctorId { get; set; }
        public Guid ClinicId { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }

        [ForeignKey("DoctorId")]
        [InverseProperty("DoctorClinics")]
        public virtual Doctor Doctor { get; set; } = null!;

        [ForeignKey("ClinicId")]
        [InverseProperty("DoctorClinics")]
        public virtual Clinic Clinic { get; set; } = null!;
    }
}
