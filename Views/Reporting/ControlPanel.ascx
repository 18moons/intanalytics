<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
                <embed src="/DxAnalytics/Content/Flashes/AnyChart.swf?XMLFile=/DxAnalytics/Xml/ControlPanelVisits" width="100%" height="400px" wmode="transparent"></embed>

                <script type="text/javascript"> swfobject.registerObject("reportSwf"); </script>

                <style type="text/css">
                    
                    #report_info { position: relative; height: 7em; }
                    
                    #report_info li 
                    {
                      position:relative;
                      list-style-type:none;
                      display: inline;
                      font-size: 12px;
                      clear:left;
                    }
                    
                    #info_left
                    {
                        position: relative;
                        float: left;
                        text-align: left;
                        margin: 0 2em 0 2em;
                        width: 18.5%;
                    }
                    
                    #info_right
                    {
                        position: relative;
                        text-align: left;
                        margin: 0 2em 0 2em;
                    }
                    
                    #info_left div label { margin-right: 1em; }
                    #info_right div span { margin-right: 1em; }
                                        
                </style>
                    <div class="wrap"></div>


