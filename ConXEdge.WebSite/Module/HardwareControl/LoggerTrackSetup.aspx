<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggerTrackSetup.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.HardwareControl.LoggerTrackSetup" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-en.js" type="text/javascript"></script>
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/icon.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .btn78
        {
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class='t2'>
            <tr>
                <td colspan="7">POUR DETAILS</td>
            </tr>
            <tr>
                <th colspan="2">Project ID: </th>
                <td colspan="5">
                    <asp:Label ID="ProjectName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="2">Pour ID: </th>
                <td colspan="5">
                    <asp:Label ID="PourName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7"></td>
            </tr>
            <tr>
                <th colspan="2">Date Started: </th>
                <td>
                    <asp:Label ID="CreateDate" runat="server" Text=""></asp:Label>
                </td>
                <th rowspan="3">Product Used: </th>
                <th colspan="2">Supplier: </th>
                <td>
                    <asp:Label ID="Supplier" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th rowspan="2">Pour Details:</th>
                <th>Volume (m3):</th>
                <td>
                    <asp:Label ID="PourVolume" runat="server" Text=""></asp:Label>
                </td>
                <th rowspan="2">Product:</th>
                <th>Code:</th>
                <td>
                    <asp:Label ID="ProductCode" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Setup By:</th>
                <td>
                    <asp:Label ID="SetupBy" runat="server" Text=""></asp:Label>
                </td>
                <th>Description:</th>
                <td>
                    <asp:Label ID="ProductDescription" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7"></td>
            </tr>
            <tr>
                <th>Levels：</th>
                <td> 
                    <asp:ListBox ID="Levels" runat="server"></asp:ListBox>
                </td>
                <th>Maturity Method:</th>
                <td>
                     <asp:Label ID="MaturityMethod" runat="server" Text=""></asp:Label> 
                </td>
                <th>Email:</th>
                <td colspan="2">
                     <asp:Label ID="Email" runat="server" Text=""></asp:Label> 
                </td>
            </tr>
            <tr>
                <td colspan="7"></td>
            </tr>
            <tr>
                <th colspan="7" align="left">
                    &nbsp;Default Pour Targets:
                </th>
                <%=DefaultTarget%>
            </tr>
            <tr>
                <td colspan="7"></td>
            </tr>
            <tr>
                <th colspan="2">Stop Recording When:</th>
                <td colspan="3"> 
                    <asp:Label ID="StopType" runat="server" Text=""></asp:Label> 
                </td>
                <th>X Hours:</th>
                <td>
                    <asp:Label ID="XHours" runat="server" Text=""></asp:Label> 
                </td>
            </tr>
        </table>
        <div></div>
        <%=TableDetails %>
    </form>
</body>
</html>
