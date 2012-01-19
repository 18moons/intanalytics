<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

            <div style="float:left;width:50%">
                <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/AudioPreferences" width="100%" height="300" wmode="transparent"></embed>
                <script type="text/javascript">
                    swfobject.registerObject("reportSwf");
                </script>
            </div>
            <div style="float:right;width:49%;">
                <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/SubtitlePreferences" width="100%" height="300" wmode="transparent"></embed>
                <script type="text/javascript">
                    swfobject.registerObject("reportSwf");
                </script>
            </div>
            <div style="width:100%;">
                <embed id="reportSwf" src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/QualityPreferences" width="100%" height="300" wmode="transparent"></embed>
                <script type="text/javascript">
                    swfobject.registerObject("reportSwf");
                </script>
            </div>
            <div class="wrap"></div>
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#txtDtStart").css("display", "none");
                    $("#txtDtFinish").css("display", "none");
                    $(".labelData").css("display", "none");
                });
            </script>