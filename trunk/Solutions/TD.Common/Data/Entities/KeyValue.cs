using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Common.Data.Entities
{
    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }
    }
}
