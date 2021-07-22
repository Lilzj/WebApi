using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.DTO
{
    public class AddEmployeeDTO
    {
        [Required(ErrorMessage = "Employee name is a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characte")]
        public string name { get; set; }

        [Required(ErrorMessage = "Age is a required field")]
        public int Age { get; set; }

        [Required(ErrorMessage = "position is a required field")]
        [MaxLength(20, ErrorMessage = "Maximum length for the position is 20 characte")]
        public string Position { get; set; }
    }
}
