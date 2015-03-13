function kendo_validation_showSummary() {
    var summary = $(".validation-summary-errors ul");
    if (summary.length == 1) {
        summary.hide();

        var text = "";
        summary.find("li").each(function () {
            text = text + "<br/>" + $(this).text();
        });

        if (text.length > 0) {
            text = text.substring(5);
        }

        if(text.length > 0)
            $(".validation-summary-errors").html('<span class="k-widget k-tooltip k-tooltip-validation k-invalid-msg summary-validation-error" data-for="" data-valmsg-for="" id="Summary_validationMessage" role="alert"><span class="k-icon k-warning"> </span>' + text + '</span>');
    }
}