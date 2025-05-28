using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("DoctorClinics")]
    public class DoctorClinic
    {

        public Guid DoctorId { get; set; }
        public Guid ClinicId { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }

        [ForeignKey("DoctorId")]
        [InverseProperty("DoctorClinics")]
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("ClinicId")]
        [InverseProperty("DoctorClinics")]
        public virtual Clinic Clinic { get; set; }
    }
}
