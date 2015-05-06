using Kendo.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Common.Kendo.Mvc5.Common;
using TD.Common.Kendo.Mvc5.Grid.Columns;

namespace TD.Common.Kendo.Mvc5.Grid.Fluent
{
    public class GridButtonsColumnFactory<T> : IHideObjectMembers where T : class
    {
        public GridButtonsColumnFactory(GridButtonsColumn<T> column)
        {
            Column = column;
        }

        private GridButtonsColumn<T> Column
        {
            get;
            set;
        }

        /// <summary>
        /// Defines a edit button.
        /// </summary>
        /// <returns></returns>
        public ImageButtonBuilder Edit()
        {
            var button = ImageButtonBuilder.GridEdit();

            Column.ButtonSet.Add(button);

            return button;
        }

        /// <summary>
        /// Defines a delete button.
        /// </summary>
        /// <returns></returns>
        public ImageButtonBuilder Delete()
        {
            var button = ImageButtonBuilder.GridDelete();

            Column.ButtonSet.Add(button);

            return button;
        }

        /// <summary>
        /// Defines a add button.
        /// </summary>
        /// <returns></returns>
        public ImageButtonBuilder Add()
        {
            var button = ImageButtonBuilder.GridAdd();

            Column.HeaderButtonSet.Add(button);

            return button;
        }
                
        /// <summary>
        /// Defines a custom button.
        /// </summary>
        /// <returns></returns>
        public ImageButtonBuilder Custom()
        {
            var button = ImageButtonBuilder.Custom();

            Column.ButtonSet.Add(button);

            return button;
        }

        /// <summary>
        /// Defines a header custom button.
        /// </summary>
        /// <returns></returns>
        public ImageButtonBuilder HeaderCustom()
        {
            var button = ImageButtonBuilder.Custom();

            Column.HeaderButtonSet.Add(button);

            return button;
        }

        /// <summary>
        /// Defines a filter button.
        /// </summary>
        /// <returns></returns>
        public ImageButtonBuilder Filter()
        {
            var button = ImageButtonBuilder.GridFilter();

            Column.HeaderButtonSet.Add(button);

            return button;
        }

        /// <summary>
        /// Defines a clear filter button.
        /// </summary>
        /// <returns></returns>
        public ImageButtonBuilder ClearFilter()
        {
            var button = ImageButtonBuilder.GridClearFilter();

            Column.HeaderButtonSet.Add(button);

            return button;
        }

        public ImageButtonBuilder AddButton(ImageButtonBuilder button)
        {
            Column.ButtonSet.Add(button);

            return button;
        }

        public ImageButtonBuilder AddHeaderButton(ImageButtonBuilder button)
        {
            Column.HeaderButtonSet.Add(button);

            return button;
        }
    }
}
