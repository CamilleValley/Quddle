<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FreeQ_WS.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>
        </script> 
        <script type="text/javascript">
            var map = null;

            function GetMap() {
                map = new Microsoft.Maps.Map(document.getElementById('myMap'), { credentials: 'AiIo0eq8yDzQx40gwHidcSJzTIZjanj36I5v_xVhbNCuB-3GTeJ0tkTM2c7exntM' });
                map.AttachEvent("ondoubleclick", AddPushpin);
                map.LoadMap(new VELatLong(59.43655681809183, 24.75275516510011),
                        15, VEMapStyle.Road, false);
            }

            onload = GetMap;
        </script>

        <div id="myMap" class="mapLayer"></div>
        <div id="routeLayer">
            <table id="routeTable">
                <tr>
                <th>LAT</th>
                <th>LON</th>

                </tr>
            </table>
        </div>
        <div style="clear:both;">&nbsp;</div>

    </div>
    </form>
</body>
</html>

