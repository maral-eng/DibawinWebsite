onload = function () {
    var e = document.getElementById('Price');

    e.oninput = myHandler;
    e.onpropertychange = e.oninput; // for IE8
    
    function myHandler() {
        document.getElementById('Price_out').innerHTML = `${e.value.toPersianLetter()} تومان`;
    }
};

$(function () {

    'use strict'

    $(".sidebar-toggle").click(function () {
        $(".logo-mini").toggleClass("logo-mini-show");
    });

    $("select#multiDrop1").change(function () {
        $(multiText1).val($(this).val());
    });
    $("select#multiDrop2").change(function () {
        $(multiText2).val($(this).val());
    });
    $("select#multiDrop3").change(function () {
        $(multiText3).val($(this).val());
    });

    $("#pdpBig1, #pdpBig2").persianDatepicker({
        cellWidth: 38,
        cellHeight: 20,
        fontSize: 13
    });
    $("#Price").keypress(function (e) {
        var keyCode = e.which;
        /*
          8 - (backspace)
          32 - (space)
          48-57 - (0-9)Numbers
          46 - (dot)
        */
        if (keyCode == 46) {
            $(this).val($(this).val() + "000")
        }
        if ((keyCode != 8 || keyCode == 32) && (keyCode < 48 || keyCode > 57)) {
            return false;
        }
    })
    $(document).ready(function () {
        //Localize Prices
        $(".local-price").each(function () {
            $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"))
        })
    })
});