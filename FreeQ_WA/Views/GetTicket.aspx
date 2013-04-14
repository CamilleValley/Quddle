<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetTicket.aspx.cs" Inherits="FreeQ_WA.Views.GetTicket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div runat="server" id="divGetTicket" style="height: 400px; width: 600px; text-align:left; overflow:hidden; padding: 10px 30px 30px 10px;">

    <h2>Here is your ticket</h2>
	<h3 class="spaceBAfter">Please note the following details:</h3>

    Here is your ticket number: <asp:Label ID="lblTicketIncr" runat="server" Text="Label"></asp:Label><br />
    Please note your password, you will be asked for it: <asp:Label ID="lblTicketPwd" runat="server" Text="Label"></asp:Label><br /><br />

    <asp:ScriptManager ID="ScriptManagerLogin" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanelReminder" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
        <h3 class="spaceBAfter">Reminder email:</h3>
        If you would like to be informed when your turn is about to come, please give us the email address to which we should send the reminder:<br />
        <br />
        <asp:TextBox ID="alertEmailTxtBox" runat="server" MaxLength="100" CssClass="inputText"></asp:TextBox>
        <asp:Button ID="ButtonAlertEmail" CssClass="bigButton" runat="server" 
            Text="Activate reminder" onclick="ButtonAlert_Click" />
        <br /><br /><br />
        <div runat="server" id="alertActivated" visible="false">The reminder has been activated</div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</form>
</body>
</html>
