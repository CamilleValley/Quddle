<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Public.aspx.cs" Inherits="FreeQ_WA.Views.Public" %>
<%@ Register src="~/Views/ShowCurrentTicket.ascx" tagname="ShowCurrentTicket" tagprefix="ucSCT" %>
<%@ Register src="~/Views/ShowTicketPicker.ascx" tagname="ShowTicketPicker" tagprefix="ucSTP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
	<link media="screen" rel="stylesheet" href="colorbox.css" />
	<script src="../colorbox/jquery-1.4.1.min.js"></script>
	<script src="../colorbox/jquery.colorbox.js"></script>
    <script src="../Scripts/JScripts.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>
    <title></title>
</head>
<body>
    <form id="formPublic" runat="server">
        <div class="mainViews">
            <div class="divCurrentTicket">
            <ucSCT:ShowCurrentTicket id="ShowCurrentTicket" runat="server"></ucSCT:ShowCurrentTicket>
            </div>
            <div class="divTicketPicker">
                <div style="margin-bottom: 70px">
                <ucSTP:ShowTicketPicker id="ShowTicketPicker" runat="server"></ucSTP:ShowTicketPicker>
                </div>
                <div id="addressNotFound" runat="server">The address wasn't found.</div>
                <div id="divMap" runat="server">
                    <div id='mapDiv'></div>
                    <script type="text/javascript">
                        function GetMap() {
                            var map = new Microsoft.Maps.Map(document.getElementById("mapDiv"), { credentials: "AiIo0eq8yDzQx40gwHidcSJzTIZjanj36I5v_xVhbNCuB-3GTeJ0tkTM2c7exntM", width: 270, height: 270 });

                            // Retrieve the location of the map center
                            var center = map.getCenter();

                            map.entities.clear();
                            var pushpin = new Microsoft.Maps.Pushpin(map.getCenter(), null);
                            map.entities.push(pushpin);
                            pushpin.setLocation(new Microsoft.Maps.Location(<%=HttpContext.Current.Session["lat"]%>, <%=HttpContext.Current.Session["lon"]%>)); 
                        }

                        $(document).ready(function () {
                            GetMap();
                        });
                    </script>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
