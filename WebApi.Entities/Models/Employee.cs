using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Employee name is a required")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characte")]
        public string name { get; set; }

        [Required(ErrorMessage ="Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Employee position is a required")]
        [MaxLength(20, ErrorMessage = "Maximum length for the position is 20 characte")]
        public string Position { get; set; }

        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; }
        public Company Compnay { get; set; }

    }
}
