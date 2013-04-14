<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowTicketPicker.ascx.cs" Inherits="FreeQ_WA.Views.ShowTicketPicker" %>

<div runat="server" id="divTicketP">
<a href="/Views/GetTicket.aspx?id=<%=Request.QueryString["id"] %>" class="bigButton ColorBoxClass" id="ticketP">
    <div class="left"></div>
    <div class="center">Get a ticket!</div>
    <div class="right"></div>
</a>
</div>