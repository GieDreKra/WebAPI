using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPIApp.Models
{
    public class School:Entity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
