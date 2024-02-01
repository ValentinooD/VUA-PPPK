using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04.Models
{
    public class BlobDirectory
    {
        public int IDDirectory { get; set; }
        public string Name { get; set; }

        public override string ToString()
            => Name;
    }
}
