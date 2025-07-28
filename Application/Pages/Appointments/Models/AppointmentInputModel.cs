namespace Application.Pages.Appointments.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class AppointmentInputModel
{
    [Required(ErrorMessage = "Vui lòng chọn ngày khám")]
    [Display(Name = "Ngày khám")]
    public DateTime AppointmentDate { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn bác sĩ")]
    [Display(Name = "Bác sĩ")]
    public Guid DoctorId { get; set; }
    
    [Required(ErrorMessage = "Vui lòng điền ghi chú")]
    [Display(Name = "Ghi chú")]
    public string? Notes { get; set; }

    // Hidden fields
    public string Status { get; set; } = "Pending";
}