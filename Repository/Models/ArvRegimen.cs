using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    [Table("ArvRegimen")]
    public class ArvRegimen
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Level { get; set; }

        [InverseProperty("ArvRegimen")]
        public ICollection<TestResult>? TestResults { get; set; } = null!;

        [InverseProperty("ArvRegimen")]
        public ICollection<ComboMedicine>? ComboMedicines { get; set; } = null!;
    }
}
