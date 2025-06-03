using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Role")]
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string NormalizedName { get; set; } = null!;

        [InverseProperty("Role")]
        public ICollection<ApplicationUser> Users { get; set; } = null!;
    }
}
