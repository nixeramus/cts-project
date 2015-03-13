using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.CTS.MockData
{
    public static class GenerateHelper
    {
        public static HashSet<int> NextSet(this Random random, int count, int min = 0, int max = int.MaxValue)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < count; i++)
            {
                var index = random.Next(min, max);
                while (set.Contains(index))
                {
                    index = random.Next(min, max); ;
                }
                set.Add(index);
            }

            return set;
        }
    }
}
