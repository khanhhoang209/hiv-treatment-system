using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]   
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTimeOffset HiredAt { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Employees")]
        public ApplicationUser User { get; set; }

        [InverseProperty("Employee")]
        public ICollection<Qualification> Qualifications { get; set; }

        [InverseProperty("Employee")]
        public Doctor Doctor { get; set; }

        [InverseProperty("Employee")]
        public Staff Staff { get; set; }
    }
}
