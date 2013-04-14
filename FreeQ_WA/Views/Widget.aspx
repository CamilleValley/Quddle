<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Widget.aspx.cs" Inherits="FreeQ_WA.Views.Widget" %>
<%@ Register src="~/Views/ShowCurrentTicket.ascx" tagname="ShowCurrentTicket" tagprefix="ucSCT" %>
<%@ Register src="~/Views/ShowTicketPicker.ascx" tagname="ShowTicketPicker" tagprefix="ucSTP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/ShowSmallView.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
	<link media="screen" rel="stylesheet" href="colorbox.css" />
	<script src="../colorbox/jquery-1.4.1.min.js"></script>
	<script src="../colorbox/jquery.colorbox.js"></script>
    <script src="../Scripts/JScripts.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainDiv">
            <div>
            <ucSCT:ShowCurrentTicket id="ShowCurrentTicket" runat="server"></ucSCT:ShowCurrentTicket>
            </div>
            <div>
                <div style="margin-bottom: 70px">
                <ucSTP:ShowTicketPicker id="ShowTicketPicker" runat="server"></ucSTP:ShowTicketPicker>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
