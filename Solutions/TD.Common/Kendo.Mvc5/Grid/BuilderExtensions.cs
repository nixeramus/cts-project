using Kendo.Mvc.UI.Fluent;
using System;
using System.Collections;
using System.Linq.Expressions;
using TD.Common.Kendo.Mvc5.Grid.Filters;
//using TD.Common.Web.Mvc.UserSettings.Grid;

namespace TD.Common.Kendo.Mvc5.Grid
{
    public static class BuilderExtensions
    {
        public static GridBuilder<T> Init<T>(this GridBuilder<T> builder, string name) where T : class
        {
            return builder
                .Name(name)
                .Pageable()
                .Sortable()
                .Scrollable()
                .Resizable(r => r.Columns(true))
                .Reorderable(r => r.Columns(true));
        }

        public static GridTemplateColumnBuilder<T> CrudCommands<T>(this GridColumnFactory<T> factory) where T : class
        {
            return factory.Template(model => {})
                .Width(80)
                .ClientTemplate(
@"<a class=""k-button k-button-icontext k-grid-edit td-grid-button"" href=""\#"" title=""Изменить""><span class=""k-icon k-edit td-grid-button-image""></span></a>
<a class=""k-button k-button-icontext k-grid-delete td-grid-button"" href=""\#"" title=""Удалить""><span class=""k-icon k-delete td-grid-button-image""></span></a>")
                .HeaderTemplate(
@"<a class=""k-button k-button-icontext k-grid-add td-grid-button"" title=""Добавить"" href=""javascript: void(0)""><span class=""k-icon k-add td-grid-button-image""></span></a>");
        }

        public static GridTemplateColumnBuilder<T> CrudCommands<T>(this GridColumnFactory<T> factory, FilterRow filterRow) where T : class
        {
            filterRow.AddCell(new ButtonFilterCell());
            return factory.CrudCommands();
        }

        public static GridBoundColumnBuilder<TModel> Bound<TModel, TValue>(this GridColumnFactory<TModel> factory, 
            Expression<Func<TModel, TValue>> expression, 
            FilterRow filterRow) where TModel : class
        {
            GridBoundColumnBuilder<TModel> builder = factory.Bound(expression);

            filterRow.AddCell(new TextFilterCell(builder.Column.Member));
            
            return builder;
        }

        public static GridBoundColumnBuilder<TModel> ForeignKey<TModel, TValue>(this GridColumnFactory<TModel> factory,
            Expression<Func<TModel, TValue>> expression,
            IEnumerable data, 
            string dataFieldValue,
            string dataFieldText,
            FilterRow filterRow) where TModel : class
        {
            GridBoundColumnBuilder<TModel> builder = factory.ForeignKey(expression, data, dataFieldValue, dataFieldText);

            filterRow.AddCell(new DropDownFilterCell(builder.Column.Member, data, dataFieldValue, dataFieldText));

            return builder;
        }

        /*
        public static GridBuilder<T> LoadSettings<T>(this GridBuilder<T> gridBuilder, UserGridSettings settings) where T : class
        {
            gridBuilder.Name(settings.Name);

            var grid = gridBuilder.ToComponent();

            if (settings.PageSize.HasValue)
                grid.DataSource.PageSize = settings.PageSize.Value;

            //if (settings.Columns.KeyMemberName.HasValue())
            //    gridBuilder.DataKeys(keys => keys.Add(settings.Columns.KeyMemberName));

            //gridBuilder.Columns(columns => columns.LoadSettings(settings.Columns));

            //if (settings.PageSize.HasValue)
            //    gridBuilder.Pageable(paging => paging.PageSize(settings.PageSize.Value));

            //if (settings.SortSettings != null)
            //{
            //    if (settings.SortedColumns.Count > 0)
            //    {
            //        gridBuilder.Sortable(s => s
            //            .AllowUnsort(settings.SortSettings.AllowUnsort)
            //            .SortMode(settings.SortSettings.SortMode)
            //            .OrderBy(o => settings.SortedColumns.ForEach(x => o.Add(x.Name).Order(x.Direction))));
            //    }
            //    else
            //    {
            //        gridBuilder.Sortable(s => s
            //            .AllowUnsort(settings.SortSettings.AllowUnsort)
            //            .SortMode(settings.SortSettings.SortMode));
            //    }
            //}

            //if (settings.Scrollable)
            //    gridBuilder.Scrollable(s => s.Height(settings.Height));

            //gridBuilder
            //    .Resizable(r => r.Columns(settings.Resizable))
            //    .Reorderable(r => r.Columns(settings.Reorderable))
            //    .ColumnContextMenu(m => m.Enabled(settings.ColumnContextMenu));


            //gridBuilder.ClientEvents(events => events.OnError("GridAjaxError"));
            

            return gridBuilder;
        }
        
                public static void LoadSettings<T>(this GridColumnFactory<T> factory, ColumnSettingsCollection columns) where T : class
                {
                    foreach (var column in columns)
                    {
                        var boundColumn = column as BoundColumnSettings;
                        if (boundColumn != null)
                        {
                            factory.Bound(boundColumn);
                            continue;
                        }

                        var commandColumn = column as CommandColumnSettings;
                        if (commandColumn != null)
                        {
                            factory.Command(commandColumn);
                        }
                    }
                }

                public static GridBoundColumnBuilder<T> Bound<T>(this GridColumnFactory<T> factory, BoundColumnSettings settings) where T : class
                {
                    GridBoundColumnBuilder<T> builder = settings.MemberType == null ? factory.Bound(settings.MemberName) : factory.Bound(settings.MemberType, settings.MemberName);

                    IGridBoundColumn column = builder.Column;

                    if (settings.ClientFooterTemplate.HasValue())
                    {
                        builder.ClientFooterTemplate(settings.ClientFooterTemplate);
                    }

                    if (settings.ClientGroupFooterTemplate.HasValue())
                    {
                        builder.ClientFooterTemplate(settings.ClientGroupFooterTemplate);
                    }

                    if (settings.ClientGroupHeaderTemplate.HasValue())
                    {
                        builder.ClientFooterTemplate(settings.ClientGroupHeaderTemplate);
                    }

                    if (settings.ClientTemplate.HasValue())
                    {
                        builder.ClientTemplate(settings.ClientTemplate);
                    }

                    if (settings.EditorTemplateName.HasValue())
                    {
                        builder.EditorTemplateName(settings.EditorTemplateName);
                    }

                    column.Encoded = settings.Encoded;

                    column.Filterable = settings.Filterable;

                    if (settings.FooterHtmlAttributes != null)
                    {
                        builder.FooterHtmlAttributes((IDictionary<string, object>)settings.FooterHtmlAttributes);
                    }

                    if (settings.FooterTemplate.HasValue())
                    {
                        builder.FooterTemplate(settings.FooterTemplate);
                    }

                    if (settings.Format.HasValue())
                    {
                        builder.Format(settings.Format);
                    }

                    column.Groupable = settings.Groupable;

                    if (settings.HeaderHtmlAttributes != null)
                    {
                        builder.HeaderHtmlAttributes((IDictionary<string, object>)settings.HeaderHtmlAttributes);
                    }

                    if (settings.HeaderTemplate.HasValue())
                    {
                        builder.HeaderTemplate(settings.HeaderTemplate);
                    }

                    column.Hidden = settings.Hidden;

                    if (settings.HtmlAttributes != null)
                    {
                        builder.HtmlAttributes((IDictionary<string, object>)settings.HtmlAttributes);
                    }

                    column.IncludeInContextMenu = settings.IncludeInContextMenu;

                    column.ReadOnly = settings.ReadOnly;

                    column.Sortable = settings.Sortable;

                    if (settings.Title.HasValue())
                    {
                        builder.Title(settings.Title);
                    }

                    column.Visible = settings.Visible;

                    if (settings.Width.HasValue())
                    {
                        builder.Width(settings.Width);
                    }
                    return builder;
                }

                public static GridActionColumnBuilder Command<T>(this GridColumnFactory<T> factory, CommandColumnSettings settings) where T : class
                {
                    GridActionColumnBuilder builder = factory.Command(commands => settings.Commands.ForEach(commands.Create));

                    IGridColumn column = builder.Column;

                    if (settings.ClientFooterTemplate.HasValue())
                    {
                        builder.ClientFooterTemplate(settings.ClientFooterTemplate);
                    }

                    if (settings.FooterHtmlAttributes != null)
                    {
                        builder.FooterHtmlAttributes((IDictionary<string, object>)settings.FooterHtmlAttributes);
                    }

                    if (settings.FooterTemplate.HasValue())
                    {
                        builder.FooterTemplate(settings.FooterTemplate);
                    }

                    if (settings.HeaderHtmlAttributes != null)
                    {
                        builder.HeaderHtmlAttributes((IDictionary<string, object>)settings.HeaderHtmlAttributes);
                    }

                    if (settings.HeaderTemplate.HasValue())
                    {
                        builder.HeaderTemplate(settings.HeaderTemplate);
                    }

                    column.Hidden = settings.Hidden;

                    if (settings.HtmlAttributes != null)
                    {
                        builder.HtmlAttributes((IDictionary<string, object>)settings.HtmlAttributes);
                    }

                    column.IncludeInContextMenu = settings.IncludeInContextMenu;

                    if (settings.Title.HasValue())
                    {
                        builder.Title(settings.Title);
                    }

                    column.Visible = settings.Visible;

                    if (settings.Width.HasValue())
                    {
                        builder.Width(settings.Width);
                    }

                    return builder;
                }

                public static void Create<T>(this GridActionCommandFactory<T> factory, Command command) where T : class
                {
                    var editCommand = command as EditCommand;
                    if (editCommand != null)
                    {
                        GridEditActionCommandBuilder builder = factory.Edit();

                        builder.ButtonType(editCommand.ButtonType);

                        if (editCommand.Text.HasValue())
                        {
                            builder.Text(editCommand.Text);
                        }

                        if (editCommand.HtmlAttributes != null)
                        {
                            builder.HtmlAttributes((IDictionary<string, object>)editCommand.HtmlAttributes);
                        }

                        if (editCommand.ImageHtmlAttributes != null)
                        {
                            builder.ImageHtmlAttributes((IDictionary<string, object>)editCommand.ImageHtmlAttributes);
                        }

                        if (editCommand.InsertText.HasValue())
                        {
                            builder.InsertText(editCommand.InsertText);
                        }

                        if (editCommand.UpdateText.HasValue())
                        {
                            builder.UpdateText(editCommand.UpdateText);
                        }

                        if (editCommand.CancelText.HasValue())
                        {
                            builder.CancelText(editCommand.CancelText);
                        }
                        return;
                    }

                    if (command is DeleteCommand)
                    {
                        GridDeleteActionCommandBuilder builder = factory.Delete();

                        builder.ButtonType(command.ButtonType);

                        if (command.Text.HasValue())
                        {
                            builder.Text(command.Text);
                        }

                        if (command.HtmlAttributes != null)
                        {
                            builder.HtmlAttributes((IDictionary<string, object>)command.HtmlAttributes);
                        }

                        if (command.ImageHtmlAttributes != null)
                        {
                            builder.ImageHtmlAttributes((IDictionary<string, object>)command.ImageHtmlAttributes);
                        }
                        return;
                    }

                    var customCommand = command as CustomCommand;
                    if (customCommand != null)
                    {
                        GridCustomActionCommandBuilder<T> builder = factory.Custom(customCommand.Name);

                        builder.ButtonType(customCommand.ButtonType);

                        if (customCommand.Text.HasValue())
                        {
                            builder.Text(customCommand.Text);
                        }

                        if (customCommand.HtmlAttributes != null)
                        {
                            builder.HtmlAttributes((IDictionary<string, object>)customCommand.HtmlAttributes);
                        }

                        if (customCommand.ImageHtmlAttributes != null)
                        {
                            builder.ImageHtmlAttributes((IDictionary<string, object>)customCommand.ImageHtmlAttributes);
                        }

                        if (customCommand.ActionName.HasValue())
                        {
                            builder.Action(customCommand.ActionName, customCommand.ControllerName, customCommand.RouteValues);
                        }

                        builder.Ajax(customCommand.Ajax);

                        builder.SendDataKeys(customCommand.SendDataKeys);

                        builder.SendState(customCommand.SendState);
                
                        return;
                    }

                    if (command is SelectCommand)
                    {
                        GridSelectActionCommandBuilder builder = factory.Select();

                        builder.ButtonType(command.ButtonType);

                        if (command.Text.HasValue())
                        {
                            builder.Text(command.Text);
                        }

                        if (command.HtmlAttributes != null)
                        {
                            builder.HtmlAttributes((IDictionary<string, object>)command.HtmlAttributes);
                        }

                        if (command.ImageHtmlAttributes != null)
                        {
                            builder.ImageHtmlAttributes((IDictionary<string, object>)command.ImageHtmlAttributes);
                        }
                    }
                }
         */
    }
}
