using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Models
{
    public class Course
    {
        public int IDCourse { get; set; }
        public string? Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int IDPerson { get; set; }

        public Person Person { get; set; }
    }
}
