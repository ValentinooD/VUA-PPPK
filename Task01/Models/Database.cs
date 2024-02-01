using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.Models
{
    internal class Database
    {

        public string? Name { get; set; } // nullable
        public override string ToString() => Name!;
    }
}
