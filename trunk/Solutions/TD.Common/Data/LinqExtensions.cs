using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Common.Data
{
    public static class LinqExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            int index = 0;

            foreach(var item in items)
            {
                if (predicate(item))
                    return index;

                index++;
            }

            return -1;
        }
    }
}
