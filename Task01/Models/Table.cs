using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Models
{
    internal class Table
    {
        public string? Schema { get; set; }
        public string? Name { get; set; }

        public override string ToString() => Schema! + "." + Name!;

    }
}
