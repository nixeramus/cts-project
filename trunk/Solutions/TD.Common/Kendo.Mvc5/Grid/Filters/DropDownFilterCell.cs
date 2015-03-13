using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using System.Collections;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class DropDownFilterCell : FilterCell
    {
        private IEnumerable data;

        private string dataFieldValue;

        private string dataFieldText;

        public DropDownFilterCell(string name, IEnumerable data, string dataFieldValue, string dataFieldText)
            : base(name)
        {
            this.data = data;
            this.dataFieldValue = dataFieldValue;
            this.dataFieldText = dataFieldText;
        }

        public override string HtmlString(HtmlHelper helper, string nameFormat)
        {
            return helper.Kendo().DropDownList()
                .Name(string.Format(nameFormat, Name))
                .HtmlAttributes(new { @class = "td-filter-input" })
                .BindTo(data)
                .DataTextField(dataFieldText)
                .DataValueField(dataFieldValue)
                .OptionLabel("Все")
                .ToHtmlString();
        }
    }
}
