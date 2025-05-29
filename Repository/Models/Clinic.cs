using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Clinics")]
    public class Clinic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [InverseProperty("Clinic")]
        public ICollection<DoctorClinic> DoctorClinics { get; set; }

        [InverseProperty("Clinic")]
        public ICollection<StaffClinic> StaffClinics { get; set; }
    }
}
