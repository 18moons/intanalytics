$(document).ready(function () {
    //$("#panel").corners();
    var dates = $("#txtDtStart, #txtDtFinish").datepicker({
        defaultDate: "+1w",
        changeMonth: true,
        dateFormat: 'dd/mm/yy',
        numberOfMonths: 2,
        onSelect: function (selectedDate) {
            var option = this.id == "txtDtStart" ? "minDate" : "maxDate",
					instance = $(this).data("datepicker");
            date = $.datepicker.parseDate(
						instance.settings.dateFormat ||
						$.datepicker._defaults.dateFormat,
						selectedDate, instance.settings);
            dates.not(this).datepicker("option", option, date);
        }
    });
    initMenu();
    $("#alertClose").click(function () {
        $("#alert").attr("style", "display:none;");
    });
});

/* JQUERY ACCORDION MENU LEFT */
function initMenu() {
    $('#menu ul').hide();
    //$('#menu ul:first').show();
    $('#menu li a').click(function () {
        var checkElement = $(this).next();
        if ((checkElement.is('ul')) && (checkElement.is(':visible'))) return false;
        if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
            $('#menu ul:visible').slideUp('normal');
            checkElement.slideDown('normal');
            return false;
        }
    });
}

function LoadMessage() {
    var string = '<div id="loading" class="loading"><div class="img">Carregando...</div> <div class="bg"></div></div>';
    return string;
}