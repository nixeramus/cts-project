using Kendo.Mvc.UI.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Kendo.Mvc5.Common;

namespace TD.Common.Kendo.Mvc5.Grid
{
    public class GridCrudCommandsColumnBuilder<T>
        where T : class
    {
        private GridTemplateColumnBuilder<T> templateColumnBuilder;
        private RowCommandType? rowCommandType;

        internal GridCrudCommandsColumnBuilder(GridTemplateColumnBuilder<T> templateColumnBuilder)
        {
            templateColumnBuilder.Width(80).HeaderTemplate(" ").ClientTemplate(" ");
            this.templateColumnBuilder = templateColumnBuilder;
            rowCommandType = null;
        }

        public GridCrudCommandsColumnBuilder<T> All()
        {
            templateColumnBuilder.HeaderTemplate(ImageButtonBuilder.GridAdd().ToHtmlString());
            templateColumnBuilder.ClientTemplate(ImageButtonSetBuilder.NewSet()
                .Add(ImageButtonBuilder.GridEdit())
                .Add(ImageButtonBuilder.GridDelete())
                .ToHtmlString());
            rowCommandType = RowCommandType.All;

            return this;
        }

        public GridCrudCommandsColumnBuilder<T> Add()
        {
            templateColumnBuilder.HeaderTemplate(ImageButtonBuilder.GridAdd().ToHtmlString());

            return this;
        }

        public GridCrudCommandsColumnBuilder<T> Edit()
        {
            if (rowCommandType == null)
            {
                templateColumnBuilder.ClientTemplate(ImageButtonBuilder.GridEdit().ToHtmlString());
                rowCommandType = RowCommandType.Edit;
                return this;
            }

            if (rowCommandType == RowCommandType.Delete)
            {
                templateColumnBuilder.ClientTemplate(ImageButtonSetBuilder.NewSet()
                .Add(ImageButtonBuilder.GridEdit())
                .Add(ImageButtonBuilder.GridDelete())
                .ToHtmlString());
                rowCommandType = RowCommandType.All;
            }

            return this;
        }

        public GridCrudCommandsColumnBuilder<T> Delete()
        {
            if (rowCommandType == null)
            {
                templateColumnBuilder.ClientTemplate(ImageButtonBuilder.GridDelete().ToHtmlString());
                rowCommandType = RowCommandType.Delete;
                return this;
            }

            if (rowCommandType == RowCommandType.Edit)
            {
                templateColumnBuilder.ClientTemplate(ImageButtonSetBuilder.NewSet()
                    .Add(ImageButtonBuilder.GridEdit())
                    .Add(ImageButtonBuilder.GridDelete())
                    .ToHtmlString());
                rowCommandType = RowCommandType.All;
            }

            return this;
        }

        public GridCrudCommandsColumnBuilder<T> Width(int pixelWidth)
        {
            templateColumnBuilder.Width(pixelWidth);

            return this;
        }

        public GridCrudCommandsColumnBuilder<T> Width(string value)
        {
            templateColumnBuilder.Width(value);

            return this;
        }

        public GridCrudCommandsColumnBuilder<T> HeaderHtmlAttributes(object attributes)
        {
            templateColumnBuilder.HeaderHtmlAttributes(attributes);

            return this;
        }

        public GridCrudCommandsColumnBuilder<T> HtmlAttributes(object attributes)
        {
            templateColumnBuilder.HtmlAttributes(attributes);

            return this;
        }
    }

    internal enum RowCommandType
    {
        All,
        Edit,
        Delete
    }
}
