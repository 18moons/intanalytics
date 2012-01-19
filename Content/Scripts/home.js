function SetDataCookie() {
    var cookieStr = "userData=";
    cookieStr += "filter=" + $("#filter").val();
    cookieStr += "&start="+$("#txtDtStart").val();
    cookieStr += "&finish="+$("#txtDtFinish").val();
    cookieStr += "; path=/DxAnalytics";
    document.cookie = cookieStr;
    document.location.reload();
}