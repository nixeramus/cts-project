using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Kendo.Mvc5.Common;

namespace TD.Common.Kendo.Mvc5.Grid.Columns
{
    interface IGridButtonsColumn : IGridColumn
    {
        ImageButtonSetBuilder ButtonSet
        {
            get;
        }

        ImageButtonSetBuilder HeaderButtonSet
        {
            get;
        }
    }
}
