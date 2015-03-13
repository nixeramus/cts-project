using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using Kendo.Mvc.UI;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class CheckBoxFilterCell : FilterCell
    {
        public string Text { get; set; }

        public CheckBoxFilterCell(string name, string text)
            :base(name)
        {
            Text = text;
        }

        public override string HtmlString(System.Web.Mvc.HtmlHelper helper, string nameFormat)
        {
            return @"<label class=""td-filter-input k-header td-filter-checkbox"">"
                + helper.CheckBox(string.Format(nameFormat, Name)).ToHtmlString()
                + Text + "</label>";
        }

        internal override void AddProperty(StringBuilder builder)
        {
            builder.AppendFormat(@"{0}: $(""#{0}Filter"").is("":checked""), ", Name);
        }
    }
}
