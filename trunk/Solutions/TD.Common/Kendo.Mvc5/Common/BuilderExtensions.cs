using Kendo.Mvc.UI.Fluent;

namespace TD.Common.Kendo.Mvc5.Common
{
    public static class BuilderExtensions
    {
        public static ImageButtonBuilder ImageButton(this WidgetFactory factory)
        {
            return new ImageButtonBuilder();
        }

        public static ImageButtonSetBuilder ImageButtonSet(this WidgetFactory factory)
        {
            return new ImageButtonSetBuilder();
        }
    }
}
