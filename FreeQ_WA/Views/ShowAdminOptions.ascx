<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowAdminOptions.ascx.cs" Inherits="FreeQ_WA.Views.ShowAdminOptions" %>

<div runat="server" id="divAdminOptions">
    <div class="spaceBAfter">
        <asp:LinkButton ID="LinkButtonNext" CssClass="bigButton" runat="server" onclick="LinkButtonNext_Click">    
        <div class="left"></div>
        <div class="center">Next ticket</div>
        <div class="right"></div>
        </asp:LinkButton>
    </div>
    <div class="spaceBBefore spaceBAfter">
        <asp:LinkButton ID="LinkButtonCancel" CssClass="bigButton" runat="server" onclick="LinkButtonCancel_Click">    
        <div class="left"></div>
        <div class="center">Cancel current ticket</div>
        <div class="right"></div>
        </asp:LinkButton>
    </div>
    <div class="spaceBBefore">
        <a href="/Views/ShowList.aspx?id=<%=Request.QueryString["id"] %>" class="bigButton ColorBoxClass">
            <div class="left"></div>
            <div class="center">Show list of participants</div>
            <div class="right"></div>
        </a>
        </div>
</div>