<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="FreeQ_WA.Account.Manage" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>My account</h2>
	<h3 class="spaceBAfter">Manage your Queues</h3>

    <div class="spaceBAfter" id="NoQueue" runat="server">
    You have no queue.
    <br />
    <br />
    <a href="../queues/ShowWizard.aspx" class="bigButton">
        <div class="left"></div>
        <div class="center">Create one</div>
        <div class="right"></div>
    </a>
    </div>
    <div id="QueueList" runat="server">
        <div>
        <asp:DropDownList ID="DropDownList_Queues" runat="server">
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="btnQueueView" runat="server" Text="View links" 
            CssClass="BoutonStandard" onclick="btnQueueView_Click" />
        &nbsp;
        <asp:Button ID="btnQueueSelect" runat="server" Text="Edit" 
            onclick="btnQueueSelect_Click" CssClass="BoutonStandard" />
        &nbsp;<asp:Button ID="btnQueueDisable" runat="server" Text="Disable" 
                onclick="btnQueueDisable_Click" CssClass="BoutonStandard" />
        </div>
        <div class="spaceBBefore">
        <asp:DetailsView ID="DetailsView_Queue" runat="server" Height="50px" Width="125px">
        </asp:DetailsView>
        </div>
    </div>
</asp:Content>
