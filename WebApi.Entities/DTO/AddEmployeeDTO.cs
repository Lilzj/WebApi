using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entities.DTO
{
    public class AddEmployeeDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }
}
