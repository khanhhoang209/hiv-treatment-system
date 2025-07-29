using System.ComponentModel.DataAnnotations;

namespace Service.DTOs;

public class PrescriptionDto
{
    public Guid Id { get; set; }
    public DateTime PrescriptionDate { get; set; }
    public string Notes { get; set; } = null!;
    public Guid MedicalRecordId { get; set; }
    public string PatientName { get; set; } = null!;
    public string DoctorName { get; set; } = null!;
    public string Diagnosis { get; set; } = null!;
    public List<PrescriptionMedicineDto> PrescriptionMedicines { get; set; } = new();
}

public class CreatePrescriptionDto
{
    [Required(ErrorMessage = "Medical Record ID is required")]
    public Guid MedicalRecordId { get; set; }
    
    [Required(ErrorMessage = "Prescription date is required")]
    public DateTime PrescriptionDate { get; set; }
    
    [Required(ErrorMessage = "Notes are required")]
    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
    public string Notes { get; set; } = null!;
    
    public List<CreatePrescriptionMedicineDto> Medicines { get; set; } = new();
}

public class UpdatePrescriptionDto
{
    [Required(ErrorMessage = "ID is required")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Prescription date is required")]
    public DateTime PrescriptionDate { get; set; }
    
    [Required(ErrorMessage = "Notes are required")]
    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
    public string Notes { get; set; } = null!;
    
    public List<CreatePrescriptionMedicineDto> Medicines { get; set; } = new();
}
