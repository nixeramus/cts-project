function customGroupValidation(validationGroup) {
    if (validationGroup === undefined || validationGroup == null) {
        validationGroup = ""; // Default group is an empty string
    }

    var clientIDs = Telerik.Sitefinity.Web.UI.Fields.FormManager._validationGroupMappings[validationGroup];
    var result = true;
    var violationMessages = [];
    if (clientIDs) {
        var iter = clientIDs.length;
        while (iter--) {
            var fieldControl = $find(clientIDs[iter]);
            var isValid = fieldControl.validate();
            if (!isValid) {
                var msgs = fieldControl.get_violationMessages();
                var count = msgs.length;
                while (count--) {
                    // create an error message
                    violationMessages.push(fieldControl.get_title() + ": " + msgs[count]);
                }
                result = false;
            }
        }
    }
    // Error summary handling    
    if (result) {
        if (jQuery("#errorSummary").length == 1) {
            jQuery("#errorSummary").hide();
        }
    }
    else // if there is an error in validation
    {
        var errorElement;
        if (jQuery("#errorSummary").length == 1) {
            errorElement = jQuery("#errorSummary");
        }
        else {
            // Create a new dom element that will contain the summary
            errorElement = jQuery("<div id='errorSummary'></div>");
            errorElement.insertBefore(jQuery("#PublicWrapper").children(":first"));
        }

        var error = violationMessages.join("<br />");
        errorElement[0].innerHTML = error;
        errorElement.show();
    }
    return result;
}

function loadHandler(e) {
    Kendo.Sitefinity.Web.UI.Fields.FormManager.validateGroup = customGroupValidation;
}

$(document).ready(function () {
    loadHandler();
});