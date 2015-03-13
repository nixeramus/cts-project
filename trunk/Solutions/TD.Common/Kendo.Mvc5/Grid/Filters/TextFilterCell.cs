using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class TextFilterCell : FilterCell
    {
        public TextFilterCell(string name)
            : base(name)
        {

        }

        public override string HtmlString(HtmlHelper helper, string nameFormat)
        {
            return helper.Kendo().TextBox()
                    .Name(string.Format(nameFormat, Name))
                    .HtmlAttributes(new { @class = "td-filter-input" })
                    .ToHtmlString();
        }
    }
}
