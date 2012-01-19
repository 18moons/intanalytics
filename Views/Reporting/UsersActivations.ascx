<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
                <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/UsersSubscriptions" width="100%" height="300" wmode="transparent"></embed>
                <script type="text/javascript">
                    swfobject.registerObject("reportSwf");
                </script>
                <embed id="reportSwf2" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/ProfilesPerUser" width="60%" height="300" wmode="transparent"></embed>
                <script type="text/javascript">
                    swfobject.registerObject("reportSwf2");
                </script>
                <embed id="reportSwf3" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/ActivatedKeys" width="39%" height="300" wmode="transparent"></embed>
                <script type="text/javascript">
                    swfobject.registerObject("reportSwf3");
                </script>
                <div class="wrap">&nbsp;</div>
