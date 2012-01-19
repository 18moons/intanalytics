<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% System.Data.DataSet dsUsers = ViewData["ElegibleUsers"] as System.Data.DataSet; %>
<% for(int i=0;i<dsUsers.Tables[0].Rows.Count;i++) { %>
                <embed id="reportSwf<%= i %>" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/UserBehaviour?id=<%= dsUsers.Tables[0].Rows[i]["ID"] %>" width="100%" height="300" wmode="transparent"></embed>
                <script type="text/javascript">
                    swfobject.registerObject("reportSwf<%= i %>");
                </script>
<% } %>