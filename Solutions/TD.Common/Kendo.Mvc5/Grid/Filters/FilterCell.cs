using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public abstract class FilterCell
    {
        public FilterCell(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract string HtmlString(HtmlHelper helper, string nameFormat);

        internal virtual void AddProperty(StringBuilder builder)
        {
            builder.AppendFormat(@"{0}: $(""#{0}Filter"").val(), ", Name);
        }
    }
}
