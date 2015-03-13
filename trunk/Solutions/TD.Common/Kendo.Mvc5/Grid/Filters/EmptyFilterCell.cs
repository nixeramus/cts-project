using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class EmptyFilterCell : FilterCell
    {
        public EmptyFilterCell() : base(String.Empty)
        { }

        public override string HtmlString(HtmlHelper helper, string nameFormat)
        {
            return String.Empty;
        }

       internal override void AddProperty(StringBuilder builder)
        {}
    }
}
