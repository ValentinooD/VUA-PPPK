using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Models
{
    public class Professor : Person
    {
        public string? Degree { get; set; }
        public double Salary { get; set; }
    }
}
