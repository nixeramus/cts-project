function RenderTemplate(templateId, data) {
    var templateContent = $("#" + templateId).html();
    var template = kendo.template(templateContent);
    var html = kendo.render(template, data1);
    return html;
}

    