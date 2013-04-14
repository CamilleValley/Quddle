<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="FreeQ_WA.Queues.Confirmation" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div runat="server" id="confirmationCreation">
    <h2>Thanks</h2>
	<h3 class="spaceBAfter">Your Queue was successfully created!</h3>
    </div>

    <div runat="server" id="viewLinks">
    <h2>Queue links</h2>
    </div>

    <ul>
        <li>
	        <h4 class="spaceCBefore spaceEAfter">Link for a display screen</h4>
	        <p class="h5">Use this link to display the current ticket on a screen.</p>
	        <p class="h5 spaceEAfter"><a id="participationLink" name="participationLink" href="http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Views/PublicMinimal.aspx") %>?id=<%= Session["NewQueue"].ToString() %>">http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Views/PublicMinimal.aspx")%>?id=<%= Session["NewQueue"].ToString() %></a></p>
        </li>
        <li>
	        <h4 class="spaceCBefore spaceEAfter">Link to the participants</h4>
	        <p class="h5">Send this link to the participants.</p>
	        <p class="h5 spaceEAfter"><a id="displayLink" name="displayLink" href="http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Views/Public.aspx") %>?id=<%= Session["NewQueue"].ToString() %>">http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Views/Public.aspx") %>?id=<%= Session["NewQueue"].ToString() %></a></p>
        </li>
        <li>
	        <h4 class="spaceCBefore spaceEAfter">Link to administrate the Queue</h4>
	        <p class="h5">Keep preciously this link and use it to administrate the Queue.</p>
	        <p class="h5 spaceEAfter"><a id="adminLink" name="adminLink" href="http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Queues/Admin.aspx") %>?id=<%= Session["NewQueue"].ToString() %>&showDetails=1">http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Queues/Admin.aspx")%>?id=<%= Session["NewQueue"].ToString() %>&showDetails=1</a></p>
        </li>
        <li>
	        <h4 class="spaceEAfter">HTML code of the Widget</h4>
	        <p class="h5">Add the following HTML code to your website: <input type="text" class="inputText" value='<iframe height="200px" width="275px" scrolling="no" frameborder="0" src="<%=Page.ResolveUrl("~/Views/Widget.aspx") %>?id=<%= Session["NewQueue"].ToString() %>"></iframe>' /></p>
	        <p class="h5 spaceCAfter">
                
                Link to the Widget: <a id="widgetLink" name="widgetLink" href="http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Views/Widget.aspx") %>?id=<%= Session["NewQueue"].ToString() %>">http://<%=Request.Url.Authority %><%=Page.ResolveUrl("~/Views/Widget.aspx") %>?id=<%= Session["NewQueue"].ToString() %></a>
            </p>
        </li>
    </ul>

    <h4>Comment: all "views" can be customized / branded on demand ; just contact us by <a href="mailto:camille.valley@gmail.com">email</a></h4>

</asp:Content>
