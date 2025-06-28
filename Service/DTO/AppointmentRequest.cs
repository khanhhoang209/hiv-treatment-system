using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class AppointmentRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày khám")]
        [Display(Name = "Ngày khám")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn bác sĩ")]
        [Display(Name = "Bác sĩ")]
        public Guid DoctorId { get; set; }
    }
}
