using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Common.Kendo.Mvc5
{
    public static partial class HtmlTemplates
    {
        public const string AddCommandTemplate = @"<a class=""k-button k-button-icontext k-grid-add td-grid-button"" title=""Добавить"" href=""javascript: void(0)""><span class=""k-icon k-add td-grid-button-image""></span></a>";
        public const string EditCommandTemplate = @"<a class=""k-button k-button-icontext k-grid-edit td-grid-button"" href=""\#"" title=""Изменить""><span class=""k-icon k-edit td-grid-button-image""></span></a>";
        public const string DeleteCommandTemplate = @"<a class=""k-button k-button-icontext k-grid-delete td-grid-button"" href=""\#"" title=""Удалить""><span class=""k-icon k-delete td-grid-button-image""></span></a>";

        public static string AllRowCommandsTemplate { get { return EditCommandTemplate + Environment.NewLine + DeleteCommandTemplate; } }
    }
}
