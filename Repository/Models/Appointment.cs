using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTimeOffset ScheduledAt { get; set; }
        public string Reason { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsOnline { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Appointments")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("DoctorId")]
        [InverseProperty("Appointments")]
        public virtual Doctor Doctor { get; set; }
    }
}
