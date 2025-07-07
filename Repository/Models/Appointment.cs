using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Appointment")]
    public class Appointment
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Vui lòng chọn ngày khám")]
        [Display(Name = "Ngày khám")]
        public DateTime AppointmentDate { get; set; }
        
        public string Status { get; set; } = null!;
        
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng chọn bác sĩ")]
        [Display(Name = "Bác sĩ")]
        public Guid DoctorId { get; set; }  
        public Doctor Doctor { get; set; } = null!;
        
        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
