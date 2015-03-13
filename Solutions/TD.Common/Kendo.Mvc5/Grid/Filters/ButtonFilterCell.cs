using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class ButtonFilterCell : FilterCell
    {
        public ButtonFilterCell() : base(String.Empty)
        { }

        public override string HtmlString(System.Web.Mvc.HtmlHelper helper, string nameFormat)
        {
            return @"<a class=""k-button k-button-icontext td-grid-filter td-grid-button"" title=""Применить фильтр"" href=""javascript: void(0)""><span class=""k-icon k-filter td-grid-button-image""></span></a>" +
                @"<a class=""k-button k-button-icontext td-grid-clearfilter td-grid-button"" title=""Снять фильтр"" href=""javascript: void(0)""><span class=""k-icon k-clear-filter td-grid-button-image""></span></a>";
        }

        internal override void AddProperty(StringBuilder builder)
        {}
    }
}
