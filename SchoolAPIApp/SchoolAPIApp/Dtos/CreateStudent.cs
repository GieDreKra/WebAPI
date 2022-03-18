using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPIApp.Dtos
{
    public class CreateStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SchoolId { get; set; }
    }
}
