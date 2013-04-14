<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FreeQ_WA.Views.Admin" %>
<%@ Register src="~/Views/ShowCurrentTicket.ascx" tagname="ShowCurrentTicket" tagprefix="ucSCT" %>
<%@ Register src="~/Views/ShowTicketPicker.ascx" tagname="ShowTicketPicker" tagprefix="ucSTP" %>
<%@ Register src="~/Views/ShowAdminOptions.ascx" tagname="ShowAdminOptions" tagprefix="ucSAO" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"> 
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
	<link media="screen" rel="stylesheet" href="colorbox.css" />
	<script src="../Colorbox/jquery-1.4.1.min.js"></script>
	<script src="../Colorbox/jquery.colorbox.js"></script>
    <script src="../Scripts/JScripts.js" type="text/javascript"></script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="main">
            <div runat="server" id="adminDiv">
                <div class="divCurrentTicket">
                <ucSCT:ShowCurrentTicket id="ShowCurrentTicket" runat="server"></ucSCT:ShowCurrentTicket>
                </div>
                <div class="divOptions">
                    <div class="spaceBAfter">
                    <ucSTP:ShowTicketPicker id="ShowTicketPicker" runat="server"></ucSTP:ShowTicketPicker>
                    </div>
                    <div class="spaceBBefore spaceBAfter">
                    <ucSAO:ShowAdminOptions id="ShowAdminOptions" runat="server"></ucSAO:ShowAdminOptions>
                    </div>
                    <div class="spaceBBefore">
                        <a href="/default.aspx" class="bigButton">
                            <div class="left"></div>
                            <div class="center">Quddle.org</div>
                            <div class="right"></div>
                        </a>
                    </div>
                </div>
            </div>
            <div runat="server" id="invalidQueue" class="divInvalidQueue">
            The requested Queue doesn't exist or you aren't its administrator.
            </div>
        </div>
    </form>
</body>
</html>
