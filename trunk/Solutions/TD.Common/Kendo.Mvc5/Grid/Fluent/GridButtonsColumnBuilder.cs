using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Common.Kendo.Mvc5.Grid.Fluent
{
    public class GridButtonsColumnBuilder : GridColumnBuilderBase<IGridColumn, GridButtonsColumnBuilder>
    {
        public GridButtonsColumnBuilder(IGridColumn column) : base(column)
        {
        }
    }
}
