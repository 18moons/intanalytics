<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Register Assembly="MibClient2.Web" Namespace="MibClient2.Web.Components" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br" xml:lang="pt-br">
    <head runat="server">
        <title>..:: MiB Analytics : Access Control ::..</title>
        <meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
        <meta http-equiv="cache-control" content="no-cache" />
		<meta http-equiv="Content-Language" content="pt-br" />
		<meta name="author" content="LabOne - http://www.labone.net" />
        <meta name="language" content="portuguese" />
        <meta name="distribution" content="Global" />
	    <meta name="robots" content="index, follow"/>
	    <meta name="rating" content="General" />
	    <meta name="geo.placename" content="São Paulo" />
	    <meta name="geo.region" content="São Paulo" />
	    <meta name="geo.country" content="Brasil" />
	    <meta name="dc.language" content="pt" />
        <cc1:MibCssCompressor ID="MibCssCompressor" CompressionMode="CompressAndJoin" runat="server" />
        <cc1:MibJsCompressor ID="MibJsCompressor" CompressionMode="CompressAndJoin" runat="server" />
        <link rel="Stylesheet" type="text/css" href="/DxAnalytics/Content/styles/login.css" />
        <script language="javascript" type="text/javascript" src="/DxAnalytics/Content/scripts/login.js"></script>
    </head>
    <body>
        <div class="bodyContainer">
            <div id="alert" class="alert" style="display:none;">
                <div class="content">
                    <h3></h3>
                    <h4></h4>
                    <a id="alertClose" href="#" title="Ok" class="btnDefault" style="left: 45%">ok</a>
                </div>
                <div class="bg"></div>
            </div>
            <div class="content">
                <div class="login">
                    <div class="title">
                        <h1>MiB Analytics</h1>
                        <h2>Please enter your username and password to begin.</h2>
                    </div>
                    <div class="form">
                        <form id="formLogin" action="<%= Url.Action("Authenticator","Account") %>">
                            <fieldset>
                                <label>Username:</label>
                                <input id="uname" name="uname" type="text" value="" class="textfield" />
                            </fieldset>
                            <fieldset>
                                <label>Password:</label>
                                <input id="upass" name="upass" type="password" value="" class="textfield" />
                            </fieldset>
                            <fieldset>
                                <a href="#" id="login" title="Entrar" class="btnDefault"> Enter </a>
                            </fieldset>           
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </body>
</html>
