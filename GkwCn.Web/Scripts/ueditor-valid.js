

$(function () {
    
    var editor = new UE.ui.Editor();
    editor.render($(".ud").attr("id"));

    $("form").submit(function () {
        var $form = $(this);
        var contentValid = editor && editor.getContent().length >= 10;
        if (contentValid)
            $(".uderror").text("");
        else
            $(".uderror").text($(".uderror").data("title") + " 字段不能小于10个字符。");
        if ($form.valid() && contentValid)
            return true;
    });
});