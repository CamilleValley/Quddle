<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowList.aspx.cs" Inherits="FreeQ_WA.Views.ShowList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 600px; text-align:left; overflow:hidden; padding: 10px 30px 30px 10px;">

    <h2>Here is the list of participants:</h2>

    <div class="spaceBBefore spaceBAfter">
    <asp:GridView ID="GridView_Participants" runat="server">
    </asp:GridView>
    </div>
    <div runat="server" id="invalidQueue" class="divInvalidQueue">
    The requested Queue doesn't exist or you aren't its administrator.
    </div>
    </div>
    </form>
</body>
</html>
