using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Common.Kendo.Mvc5.Common
{
    public class ImageButtonSetBuilder
    {
        public static ImageButtonSetBuilder NewSet()
        {
            return new ImageButtonSetBuilder();
        }

        private List<ImageButtonBuilder> buttons;

        internal ImageButtonSetBuilder()
        {
            buttons = new List<ImageButtonBuilder>();
        }

        public ImageButtonSetBuilder Add(ImageButtonBuilder button)
        {
            buttons.Add(button);
            return this;
        }

        public string ToHtmlString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var button in buttons)
                sb.Append(button.ToHtmlString());

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
    }

    
}
