using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Kendo.Mvc5.Common;

namespace TD.Common.Kendo.Mvc5.Grid.Columns
{
    public class GridButtonsColumn<T> : GridColumnBase<T>, IGridButtonsColumn where T : class
    {
        public GridButtonsColumn(Grid<T> grid) : base(grid)
        {
            Width = "80px";
            ButtonSet = new ImageButtonSetBuilder();
            HeaderButtonSet = new ImageButtonSetBuilder();
            Template = model => { };
        }

        public ImageButtonSetBuilder ButtonSet
        {
            get;
            private set;
        }

        public ImageButtonSetBuilder HeaderButtonSet
        {
            get;
            private set;
        }

        protected override IGridDataCellBuilder CreateEditBuilderCore(IGridHtmlHelper htmlHelper)
        {
            return CreateDisplayBuilderCore(htmlHelper);
        }
        
        protected override IGridDataCellBuilder CreateInsertBuilderCore(IGridHtmlHelper htmlHelper)
        {
            return CreateDisplayBuilderCore(htmlHelper);
        }

        private void SetTemplates()
        {
            ClientTemplate = ButtonSet.ToHtmlString();
            HeaderTemplate.Html = HeaderButtonSet.ToHtmlString();
        }

        protected override IGridCellBuilder CreateHeaderBuilderCore()
        {
            SetTemplates();
            return base.CreateHeaderBuilderCore();
        }
    }
}
