using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Order")]
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid MedicalRecordId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTimeOffset CreateAt { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Orders")]
        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey("DoctorId")]
        [InverseProperty("Orders")]
        public virtual Doctor Doctor { get; set; } = null!;

        [ForeignKey("MedicalRecordId")]
        [InverseProperty("Orders")]
        public virtual MedicalRecord MedicalRecord { get; set; } = null!;
    }
}
