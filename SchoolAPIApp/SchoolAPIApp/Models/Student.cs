using SchoolAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPIApp
{
    public class Student:Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SchoolId { get; set; }

      
    }
}
