using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04.Utils
{
    public static class CollectionsExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> newItems)
        {
            foreach (T item in newItems)
            {
                collection.Add(item);
            }
        }
    }
}
