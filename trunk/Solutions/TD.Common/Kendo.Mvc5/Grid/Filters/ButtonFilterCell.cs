using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Kendo.Mvc5.Common;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class ButtonFilterCell : FilterCell
    {
        public ButtonFilterCell() : base(String.Empty)
        { }

        public override string HtmlString(System.Web.Mvc.HtmlHelper helper, string nameFormat)
        {
            return ImageButtonSetBuilder.NewSet()
                .Add(ImageButtonBuilder.GridFilter())
                .Add(ImageButtonBuilder.GridClearFilter())
                .ToHtmlString();
        }

        internal override void AddProperty(StringBuilder builder)
        {}
    }
}
