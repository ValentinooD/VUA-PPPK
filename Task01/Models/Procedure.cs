using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Models
{
    internal class Procedure
    {
        public string? Name { get; set; }
        public string? Definition { get; set; }

        public override string ToString() => Name!;
    }
}
