﻿var initializer = {
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

    var endBlock = $(".td-endPage");

    var footerHeight = endBlock.offset().top - blockBottom;
    
    var height = windowHeight - top - footerHeight;

    if (height > initializer.minHeight) {
        block.height(height);
        //block.css("maxHeight", height + "px")
    } else {
        block.height(initializer.minHeight);
    }
}

function GetEmptyHeight(lastBlock) {
    var windowHeight = $(window).height();
    var endBottom = lastBlock.offset().top + lastBlock.height();
    return windowHeight - endBottom;
}
function StretchContentBlock(contentBlock, endBlock) {
    var windowHeight = $(window).height();
    var endBottom = endBlock.offset().top + endBlock.height();
    var contentHeight = contentBlock.height();
    contentBlock.height(contentHeight + windowHeight - endBottom);
}

function SetContentBlock(block){
    StretchBlock(block);
    $(window).bind("resize", function () {
        StretchBlock(block);
    });
}

function StretchGrid(conteiner, grid) {
    var conteinerTop = conteiner.offset().top;
    var gridTop = grid.offset().top;
    var conteinerHeight = conteiner.height() - gridTop + conteinerTop;

    var gridHeight = grid.height();

    var delta = conteinerHeight - gridHeight;

    var gridContent = grid.find(">.k-grid-content");
    var contentHeight = gridContent.height() + delta - 2;

    gridContent.height(contentHeight);
    grid.find(">.k-grid-content-locked").height(contentHeight);
}

function AjaxError(e) {
    var errorContent = $("#errorContent", e.responseText);
    if (errorContent.length) {
        ShowErrorWindow(errorContent);
        return;
    }
    ShowError("В процессе обработки запроса произошла ошибка");
}

function ShowError(message) {
    var errorContent = $("<div style='text-align:center;color:Red;vertical-align:middle;font-weight:500;font-size:large;'>" + message + "</div>");
    ShowErrorWindow(errorContent);
}