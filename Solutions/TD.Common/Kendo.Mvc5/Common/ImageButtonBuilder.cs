using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using TD.Common.Web.Mvc;

namespace TD.Common.Kendo.Mvc5.Common
{
    public class ImageButtonBuilder
    {
        public static ImageButtonBuilder Custom()
        {
            return new ImageButtonBuilder(); 
        }

        public static ImageButtonBuilder GridAdd()
        {
            return new ImageButtonBuilder()
                .Tag(ButtonTag.a)
                .AddCssClass("k-grid-add")
                .Title("Добавить")
                .ImageCssClass("k-add");
        }

        public static ImageButtonBuilder GridEdit()
        {
            return new ImageButtonBuilder()
                .Tag(ButtonTag.a)
                .Url("\\#")
                .AddCssClass("k-grid-edit")
                .Title("Изменить")
                .ImageCssClass("k-edit");
        }

        public static ImageButtonBuilder GridDelete()
        {
            return new ImageButtonBuilder()
                .Tag(ButtonTag.a)
                .Url("\\#")
                .AddCssClass("k-grid-delete")
                .Title("Удалить")
                .ImageCssClass("k-delete");
        }

        public static ImageButtonBuilder GridFilter()
        {
            return new ImageButtonBuilder()
                .Tag(ButtonTag.a)
                .AddCssClass("td-grid-filter")
                .Title("Применить фильтр")
                .ImageCssClass("k-filter");
        }

        public static ImageButtonBuilder GridClearFilter()
        {
            return new ImageButtonBuilder()
                .Tag(ButtonTag.a)
                .AddCssClass("td-grid-clearfilter")
                .Title("Снять фильтр")
                .ImageCssClass("k-clear-filter");
        }

        private ImageButton component;

        internal ImageButtonBuilder()
        {
            component = new ImageButton();
        }

        public ImageButtonBuilder Tag(ButtonTag tag)
        {
            component.Tag = tag;
            return this;
        }

        public ImageButtonBuilder Url(string url)
        {
            component.Url = url;

            return this;
        }

        public ImageButtonBuilder Title(string title)
        {
            component.Title = title;

            return this;
        }

        public ImageButtonBuilder AddCssClass(string cssClass)
        {
            component.CssClass += " " + cssClass;

            return this;
        }

        public ImageButtonBuilder ImageCssClass(string cssClass)
        {
            component.ImageCssClass = cssClass;

            return this;
        }

        public ImageButtonBuilder Name(string name)
        {
            component.Name = name;

            return this;
        }

        public ImageButtonBuilder HtmlAttributes(object attributes)
        {
            return HtmlAttributes(attributes.ToDictionary());
        }

        public ImageButtonBuilder HtmlAttributes(IDictionary<string, object> attributes)
        {
            component.HtmlAttributes.Clear();
            component.HtmlAttributes.Merge(attributes);

            return this;
        }

        public string ToHtmlString()
        {
            return component.ToHtmlString();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
    }

    
}
