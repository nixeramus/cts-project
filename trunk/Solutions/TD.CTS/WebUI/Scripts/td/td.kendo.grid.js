initializer.getfilters = function () { return {}; };

function kendo_grid_init(grid, isMain, filterRow) {
    grid.find(".k-grid-add.td-grid-button").click(function () { kendo_grid_createrow(grid); });

    if (filterRow) {
        grid.find(".k-grid-header .k-grid-header-wrap table thead").append(filterRow);
        grid.find(".td-grid-filter").click(function () { kendo_grid_reload(grid); });
        grid.find(".td-grid-clearfilter").click(function () { kendo_grid_clearfilters(grid); });
    }

    if (isMain) {
        SetContentBlock(grid.find(".k-grid-content"));
    }
}

function kendo_grid_getfilters() {
    return initializer.getfilters();
}

function kendo_grid_createrow(grid) {
    kgrid = grid.data("kendoGrid");
    kgrid.addRow();
}

function kendo_grid_reload(grid) {
    kgrid = grid.data("kendoGrid");
    kgrid.dataSource.read();
}

function kendo_grid_clearfilters(grid) {
    grid.find(".k-filter-row .k-textbox.td-filter-input").val("");
    grid.find(".k-filter-row .k-datepicker .k-input").val("");
    grid.find(".k-filter-row .k-dropdown .td-filter-input").each(function () {
        $(this).data("kendoDropDownList").value("");
    });
    $(".k-filter-row .td-filter-checkbox input:checkbox").prop("checked", false);
    kendo_grid_reload(grid);
}

function kendo_grid_error_handler(e) {
    if (e.errors) {
        var message = "Errors:\n";
        $.each(e.errors, function (key, value) {
            if ('errors' in value) {
                $.each(value.errors, function () {
                    message += this + "\n";
                });
            }
        });
        ShowError(message);
        return;
    }
    AjaxError(e.xhr);
}

function kendo_grid_onrowedit(e) {
    e.container.find("a.k-grid-edit").closest("td").html('<a class="k-button k-button-icontext k-primary k-grid-update td-grid-button" href="#" title="Обновить"><span class="k-icon k-update td-grid-button-image"></span></a>' +
                '<a class="k-button k-button-icontext k-grid-cancel td-grid-button" href="#" title="Отмена"><span class="k-icon k-cancel td-grid-button-image"></span></a>');
}

function kendo_grid_onpopupedit(e) {
    e.container.find("a.k-grid-update").html("<span class='k-icon k-update'></span>Сохранить");
    e.container.find("a.k-grid-cancel").html("<span class='k-icon k-cancel'></span>Отменить");
}

function kendo_grid_resizeColumn(grid, index, width) {
    //$("#grid .k-grid-header-wrap").find("colgroup col") //header
    grid.find(".k-grid-header colgroup col")
       .eq(index)
       .css({ width: width });

    //$("#grid .k-grid-content").find("colgroup col") //content
    grid.find(".k-grid-content colgroup col")
       .eq(index)
       .css({ width: width });
}