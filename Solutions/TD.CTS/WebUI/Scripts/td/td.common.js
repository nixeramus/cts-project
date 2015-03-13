var initializer = {
    minHeight: 200
};

function MenuItemHoverIn() {
	$(this).addClass("k-state-hover");
}

function MenuItemHoverOut() {
	$(this).removeClass("k-state-hover");
}

function ThemeMenuClick(){
	var theme = $(this).find("#Theme").val();

	$().redirect(initializer.changeThemeUrl, { "theme": theme, "url": $(location).attr('href') });
}

function ChangePasswordMenuClick() {
    $().redirect(initializer.changeThemeUrl, { "theme": theme, "url": $(location).attr('href') });
}

function CreateUlList(source, field) {
    var html = "<ul>";

    for (var i = 0; i < source.length; i++) {
        html += "<li>" + source[i][field] + "</li>";
    }

    html += "</ul>";

    return html;
}

function StretchBlock(block) {
    var windowHeight = $(window).height();

    var top = block.offset().top;
    var blockBottom = top + block.height();

    var end = $(".td-endPage");

    var footerHeight = end.offset().top - blockBottom;
    
    var height = windowHeight - top - footerHeight;

    if (height > initializer.minHeight) {
        block.height(height);
        //block.css("maxHeight", height + "px")
    } else {
        block.height(initializer.minHeight);
    }
}

function SetContentBlock(block){
    StretchBlock(block);
    $(window).bind("resize", function () {
        StretchBlock(block);
    });
}