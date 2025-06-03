using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Clinic")]
    public class Clinic
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
            
        [InverseProperty("Clinic")]
        public ICollection<DoctorClinic> DoctorClinics { get; set; } = null!;

        [InverseProperty("Clinic")]
        public ICollection<StaffClinic> StaffClinics { get; set; } = null!;
    }
}
