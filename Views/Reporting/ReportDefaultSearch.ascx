<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
                <div id="report_title">
                    <label class="reptitle"><%= ViewData["ReportTitle"] %></label>
                </div>
                <% MibClient2.Web.Tools.MibCookie ck = new MibClient2.Web.Tools.MibCookie("userData"); %>
                    <div id="report_search">
                        <ul>
                            <li>
                                <label>
                                    Subscription:</label>
                                <select id="filter" style="width: 130px;">
                                    <option value="0" selected="selected">All</option>
                                    <% foreach(DXAnalytics.Models.SubscriptionPlan plan in DXAnalytics.Models.SubscriptionPlan.GetAllPlans()) { %>
                                    <option value="<%= plan.ID %>"><%= plan.Name %></option>
                                    <% } %>
                                </select>
                            </li>
                            <li>
                                <labels=" class="labelData">
                                    Start:</label>
                                <input type="text" id="txtDtStart" name="txtDtStart" style="width: 100px;" value="" />
                            </li>
                            <li>
                                <label class="labelData">
                                    End:</label>
                                <input type="text" id="txtDtFinish" name="txtDtFinish" style="width: 100px;" value="" />
                            </li>
                            <li><a href="javascript:;" onclick="SetDataCookie()" id="SendFilter"><strong>Ir</strong></a> </li>
                        </ul>
                    </div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $("#txtDtStart").val('<%=ck.GetString("start") %>');
                        $("#txtDtFinish").val('<%=ck.GetString("finish") %>');
                        $("#filter").val('<%=ck.GetString("filter") %>');
                    });
                </script>
