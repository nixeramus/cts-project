using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class DateRangeFilterCell : FilterCell
    {
        public DateRangeFilterCell(string name)
            : base(name)
        {

        }

        public override string HtmlString(HtmlHelper helper, string nameFormat)
        {
            return @"<span class=""td-filter-input k-header"">с " + 
                helper.Kendo().DatePicker()
                    .Name(string.Format(nameFormat, Name + "Begin"))
                    //.HtmlAttributes(new { @class = "td-filter-input" })
                    .ToHtmlString()
                + " по " +
                helper.Kendo().DatePicker()
                    .Name(string.Format(nameFormat, Name + "End"))
                    //.HtmlAttributes(new { @class = "td-filter-input" })
                    .ToHtmlString()
               + "</span>";
        }

        internal override void AddProperty(StringBuilder builder)
        {
            builder.AppendFormat(@"{0}Begin: $(""#{0}BeginFilter"").val(), ", Name);
            builder.AppendFormat(@"{0}End: $(""#{0}EndFilter"").val(), ", Name);
        }
    }
}
