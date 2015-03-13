using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System.Collections;

namespace TD.Common.Kendo.Mvc5.Grid.Filters
{
    public class FilterRow
    {
        //public string JavaScriptFunctionName { get; set; }

        public FilterRow(HtmlHelper helper)
        {
            this.helper = helper;

            //JavaScriptFunctionName = "GetFilters";
        }

        private HtmlHelper helper;

        private List<FilterCell> cells = new List<FilterCell>();

        public void AddCell(FilterCell cell)
        {
            cells.Add(cell);
        }

        //public FilterRow AddTextCell(string name)
        //{
        //    cells.Add( 
        //        helper.Kendo().TextBox()
        //        .Name(name)
        //        .HtmlAttributes(new { @class = "td-filter-input"})
        //        .ToHtmlString());
                        
        //    return this;
        //}

        //public FilterRow AddDropDownCell(string name, IEnumerable data, string dataTextField, string dataValueField)
        //{
        //    cells.Add(helper.Kendo().DropDownList()
        //        .Name(name)
        //        .HtmlAttributes(new { @class = "td-filter-input" })
        //        .BindTo(data)
        //        .DataTextField(dataTextField)
        //        .DataValueField(dataValueField)
        //        .OptionLabel("Все")
        //        .ToHtmlString());

        //    return this;
        //}

        //public FilterRow AddButtonsCell()
        //{
        //    cells.Add(@"<a class=""k-button k-button-icontext td-grid-filter td-grid-button"" title=""Применить фильтр"" href=""javascript: void(0)""><span class=""k-icon k-filter td-grid-button-image""></span></a>" +
        //        @"<a class=""k-button k-button-icontext td-grid-clearfilter td-grid-button"" title=""Снять фильтр"" href=""javascript: void(0)""><span class=""k-icon k-clear-filter td-grid-button-image""></span></a>");

        //    return this;
        //}

        public string HtmlFilterRow()
        {
            var builder = new TagBuilder("tr");

            builder.AddCssClass("k-filter-row");

            StringBuilder stringBuilder = new StringBuilder();

            foreach(var cell in cells)
            {
                stringBuilder.Append("<th>");
                stringBuilder.Append(cell.HtmlString(helper, "{0}Filter"));
                stringBuilder.Append("</th>");
            }

            stringBuilder.Append("<script> initializer.getfilters = function() { return { ");

            foreach (var cell in cells)
            {
                cell.AddProperty(stringBuilder);                    
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            stringBuilder.Append(" }; }; </script>");

            stringBuilder
                .Replace(Environment.NewLine, "' +" + Environment.NewLine + "'")
                .Replace("</script>", "</scr'+'ipt>");
            
            builder.InnerHtml = stringBuilder.ToString();

            return MvcHtmlString.Create(builder.ToString()).ToHtmlString();
        }


    }
}
