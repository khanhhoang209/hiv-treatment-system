using System.ComponentModel.DataAnnotations;

namespace Repository.Constants;

public enum MedicationTime
{
    [Display(Name = "buổi sáng")]
    Morning = 1,
    [Display(Name = "buổi trưa")]
    Noon = 2,
    [Display(Name = "buổi chiều")]
    Evening = 4,
    [Display(Name = "buổi tối")]
    Night = 8
}