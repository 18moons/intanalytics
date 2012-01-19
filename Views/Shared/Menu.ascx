<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
        <!-- BEGIN PANEL (MENU) -->
        <div id="panel">
            <ul id="menu">
                <li>
                    <a href="/DxAnalytics/Home/Index" class="header"><div id="img_panel">&nbsp;</div>Control Panel</a>
                </li>
                <li>
                    <a href="#" class="header"><div id="img_visit">&nbsp;</div>Users</a>
                    <ul class="submenu">
                        <li><a href="/DxAnalytics/Home/UsersOverview">&middot;&nbsp;Overview</a></li>
                        <li><a href="/DxAnalytics/Home/UsersActivations">&middot;&nbsp;Subscription vs Activation</a></li>
                        <li><a href="/DxAnalytics/Home/UsersPreferences">&middot;&nbsp;User Preferences</a></li>
                        <li><a href="/DxAnalytics/Home/UseProfiles">&middot;&nbsp;User Profiles</a></li>
                        <li><a href="/DxAnalytics/Home/UserRecurrence">&middot;&nbsp;Access Recurrence</a></li>
                        <%--<li><a class="last beta" href="/DxAnalytics/Home/UserBehaviour">&middot;&nbsp;User Behavior</a></li>--%>
                    </ul>
                </li>
                <li>
                    <a href="#" class="header"><div id="img_conte">&nbsp;</div>Media Contents</a>
                    <ul class="submenu">
                        <li><a href="/DxAnalytics/Home/MediaPerformance">&middot;&nbsp;Media Performance</a></li>
                        <li><a href="/DxAnalytics/Home/PlaylistPerformance">&middot;&nbsp;Playlist Performance</a></li>
                        <li><a href="/DxAnalytics/Home/PlaylistPositionPerformance">&middot;&nbsp;Position Performance</a></li>
                    </ul>
                </li>
            </ul>
        </div>
        <!-- END PANEL (MENU) -->
