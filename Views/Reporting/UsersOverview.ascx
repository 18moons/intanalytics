<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Register Assembly="MibClient2.Web" Namespace="MibClient2.Web.Components" TagPrefix="mib" %>

<mib:MibCssCompressor ID="MibCssCompressor" CompressionMode="CompressAndJoin" runat="server" />
<link href="/DxAnalytics/Content/Styles/user_overview.css" rel="stylesheet" type="text/css" />

<div id="UserOverview_UsersSubscriptions">
    <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/ControlPanelVisits"
    width="100%" height="300" wmode="transparent"></embed>
</div>

<div style="height:600px">
<div id="painel_user_audience_left" style="">
    <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/UserAudience"
    width="100%" height="600" wmode="transparent"></embed>
</div>
<div id="painel_user_audience_right">
    <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/SessionTimming"
    width="100%" height="300" wmode="transparent"></embed>

    <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/lastlogin"
    width="100%" height="300" wmode="transparent"></embed>

</div>
</div>


<script type="text/javascript">
    swfobject.registerObject("reportSwf");
</script>
