using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Common.Data.Attributes
{
    public class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
