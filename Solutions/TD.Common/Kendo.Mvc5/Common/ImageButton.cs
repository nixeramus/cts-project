using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Web.Routing;

namespace TD.Common.Kendo.Mvc5.Common
{
    public class ImageButton
    {
        internal ImageButton()
        {
            Tag = ButtonTag.button;
            Url = "javascript: void(0)";
            HtmlAttributes = new RouteValueDictionary();
        }

        public ButtonTag Tag { get; set; }
        
        public string Url { get; set; }
        
        public string Title { get; set; }

        public string CssClass { get; set; }

        public string ImageCssClass { get; set; }

        public string Name { get; set; }

        public IDictionary<string, object> HtmlAttributes { get; private set; }

        public string ToHtmlString()
        {
            TagBuilder buttonTag = new TagBuilder(Tag.ToString());

            buttonTag.AddCssClass("k-button k-button-icontext td-grid-button");
            if (CssClass.HasValue())
                buttonTag.AddCssClass(CssClass.Trim());
            
            if (Name.HasValue())
            {
                buttonTag.MergeAttribute("name", Name);
                buttonTag.GenerateId(Name);
            }
            
            if (Title.HasValue())
                buttonTag.MergeAttribute("title", Title);

            if (Tag == ButtonTag.a)
                buttonTag.MergeAttribute("href", Url.HasValue() ? Url : "javascript: void(0)");

            if (HtmlAttributes.Count > 0)
                buttonTag.MergeAttributes(HtmlAttributes);

            var imageTag = new TagBuilder("span");
            imageTag.AddCssClass("k-icon td-grid-button-image");
            if (ImageCssClass.HasValue())
                imageTag.AddCssClass(ImageCssClass);

            buttonTag.InnerHtml = imageTag.ToString();

            return buttonTag.ToString();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
    }

    public enum ButtonTag
    {
        button,
        a
    }
}
