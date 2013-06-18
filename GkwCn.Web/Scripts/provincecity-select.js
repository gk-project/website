
$(function () {

    function initCitys(pv) {
        $.post("/provincecity/getcity", { pname: pv }, function (d) {
            var html = '<option value="0">请选择</option>', temp = '<option value="{id}" {select}>{text}</option>', cd = $(".citydrop");
            $.each(d, function (i, o) {
                html += temp.replace("{id}", o.text).replace("{text}", o.text).replace("{select}", cd.val() == o.text ? 'selected="selected"' : "");
            });
            cd.children().remove();
            cd.append($(html));
        }, "json");
    }

    var province = $(".provincedrop").val();
    if (province) {
        initCitys(province);
    }

    $(".provincedrop").change(function (e) {
        var $pv = $(e.target), $c = $(".citydrop");
        $c.removeAttr("value");
        initCitys($pv.val());
    });

    //$(".provincedrop").change(function (e) {
    //    var $p = $(".province"), $pv = $(e.target), $c = $(".city");
    //    $p.val($pv.val());
    //    $c.removeAttr("value");
    //    initCitys($pv.val());
    //});

    //$(".citydrop").change(function (e) {
    //    var $c = $(".city"), $cv = $(e.target);
    //    $c.val($cv.val());
    //});

    //$(".address").focus(function (e) {
    //    var $a = $(e.target);
    //    if (!$a.val()) {
    //        $a.val($(".provincedrop option:selected").text() + "省" + $(".citydrop option:selected").text() + "市");
    //    }
    //})

});