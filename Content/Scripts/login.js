function LoadMessage() {
    var string = '<div id="loading" class="loading"><div class="img">Carregando...</div> <div class="bg"></div></div>';
    return string;
}

function AuthenticationResponse(objJson, textStatus) {
    if (objJson.Status == "OK")
        window.location = "/DxAnalytics/Home/Index/";
    else {
        $("#loading").remove();
        $("#alert > div > h3").html(objJson.Status);
        $("#alert > div > h4").html(objJson.Message);
        $("#alert").attr("style", "display:block;");
        $("#upass").val("");
    }
}

function ValidateForm(){
    if(($("#uname").val().length == 0) || ($("#upass").val().length == 0)){
        $("#alert > div > h3").html("Alerta");
        $("#alert > div > h4").html("Todos os campos devem ser preenchidos.");
        $("#alert").attr("style", "display:block;");
        return false;
    }
    return true;
}

function Authentication(){
    $("#alert").attr("style", "display:none;");
    var frm = $("form#formLogin");
    $(".bodyContainer").prepend(LoadMessage());
    $.post(frm.attr("action"), frm.serialize(), AuthenticationResponse, "json");
}

$(document).ready(function () {
    $("#login").click(function () {
        if(ValidateForm()) Authentication();
    });

    $("#alertClose").click(function () {
        $("#alert").attr("style", "display:none;");
    });

    $(document).keyup(function (e) {
        //if (e.keyCode == 13) if (ValidateForm()) Authentication();
    });
});