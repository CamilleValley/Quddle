<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowCurrentTicket.ascx.cs" Inherits="FreeQ_WA.Views.ShowCurrentTicket" %>
<%@ Register src="~/Views/ShowCurrentTicketDetails.ascx" tagname="ShowTicketDetails" tagprefix="ucSTD" %>

<asp:ScriptManager ID="ScriptManager_PM" runat="server">
</asp:ScriptManager>
<asp:Timer ID="Timer_PM" runat="server" Interval="5000" OnTick="Timer_PM_Tick">
</asp:Timer>
<asp:UpdatePanel ID="UpdatePanel_PM" UpdateMode="Conditional" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer_PM" EventName="Tick" />
    </Triggers>
    <ContentTemplate>
        <div runat="server" id="queueName" class="divQueueName">
        </div>
        <div runat="server" id="currentTicketNumber" class="divCurrentTicketNumber">
        </div>
        <div runat="server" id="expectedHandlingTime" class="divExpectedHandlingTime">
        </div>
        <div runat="server" id="invalidQueue" class="divInvalidQueue">
        The requested Queue doesn't exist.
        </div>
        <div runat="server" id="activeDateOver" class="divInvalidQueue">
        This Queue is no more active.
        </div>
        <div id="TicketDetails" runat="server">
            <ucSTD:ShowTicketDetails id="ShowTicketPicker" runat="server"></ucSTD:ShowTicketDetails>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
