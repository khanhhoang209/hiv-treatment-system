using System.ComponentModel.DataAnnotations;

namespace Service.DTOs;

public class PrescriptionMedicineDto
{
    public Guid PrescriptionId { get; set; }
    public Guid MedicineId { get; set; }
    public string MedicineName { get; set; } = null!;
    public string MedicineDescription { get; set; } = null!;
    public decimal MedicinePrice { get; set; }
    public int Quantity { get; set; }
    public int Dosage { get; set; }
    public string Instructions { get; set; } = null!;
    public int SumOfMedicationTime { get; set; }
    public decimal BoughtPrice { get; set; }
    public decimal TotalPrice => Quantity * BoughtPrice;
}

public class CreatePrescriptionMedicineDto
{
    [Required(ErrorMessage = "Medicine ID is required")]
    public Guid MedicineId { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Dosage is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Dosage must be greater than 0")]
    public int Dosage { get; set; }
    
    [Required(ErrorMessage = "Instructions are required")]
    [StringLength(500, ErrorMessage = "Instructions cannot exceed 500 characters")]
    public string Instructions { get; set; } = null!;
    
    [Required(ErrorMessage = "Sum of medication time is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Sum of medication time must be greater than 0")]
    public int SumOfMedicationTime { get; set; }
    
    [Required(ErrorMessage = "Bought price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Bought price must be greater than 0")]
    public decimal BoughtPrice { get; set; }
}

public class UpdatePrescriptionMedicineDto
{
    [Required(ErrorMessage = "Prescription ID is required")]
    public Guid PrescriptionId { get; set; }
    
    [Required(ErrorMessage = "Medicine ID is required")]
    public Guid MedicineId { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Dosage is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Dosage must be greater than 0")]
    public int Dosage { get; set; }
    
    [Required(ErrorMessage = "Instructions are required")]
    [StringLength(500, ErrorMessage = "Instructions cannot exceed 500 characters")]
    public string Instructions { get; set; } = null!;
    
    [Required(ErrorMessage = "Sum of medication time is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Sum of medication time must be greater than 0")]
    public int SumOfMedicationTime { get; set; }
    
    [Required(ErrorMessage = "Bought price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Bought price must be greater than 0")]
    public decimal BoughtPrice { get; set; }
}
