function RenderTemplate(templateId, data) {
    var templateContent = $("#" + templateId).html();
    var template = kendo.template(templateContent);
    var html = kendo.render(template, data1);
    return html;
}

function kendo_error_handler(e) {
    if (e.errors) {
        var message = "";
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

    