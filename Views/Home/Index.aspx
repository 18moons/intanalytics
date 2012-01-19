<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript" src="/DxAnalytics/Content/scripts/jquery.cookie.js"></script>
    <script language="javascript" type="text/javascript" src="/DxAnalytics/Content/scripts/home.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- BEGIN BODY CONTENT -->
    <div id="content">
        <% Html.RenderPartial("Menu"); %>
        <!-- BEGIN REPORTS -->
        <div id="reports">
            <div id="report_main">
                <% Html.RenderPartial("~/Views/Reporting/ReportDefaultSearch.ascx"); %>
            </div>
            <div id="report_content">
                <% Html.RenderAction(ViewData["ReportAction"].ToString(), "Reporting"); %>
            </div>
        </div>
        <!-- END REPORTS -->
    </div>
    <!-- END BODY CONTENT -->
</asp:Content>