﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardList.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.HardwareControl.DashBoardList" %>
<%@ Register assembly="ConXEdge.PagerBar" namespace="ConXEdge.Common.PagerBar" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dash Board List</title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript"> 
        function viewItem(pid) {
            url = "LoggerTrackTabs.aspx?pid=" + pid + "&rand=" + new Date().toString();
            window.location.href = url;
        }
    </script>
    <style type="text/css">
        .btn78
        {
            height: 21px;
        }
    </style>
</head>
<body>
    <div style="float: left; margin-top: 5px; margin-bottom: 5px; margin-left: 5px">
       
        <form id="form1" runat="server" method="get">
         Pour Name：<input id="Name" name="Name" type="text" value="<%=Request.QueryString["Name"]%>" />
        <input id="Button2" type="button" value="Query" onclick="javascript:form1.submit()" />
        </form>
    </div>
    <table id="ListArea" border="0" cellpadding="0" cellspacing="0" class="t1 c1" width="98%">
        <thead>
            <tr>
                <th align="center" width="6%">
                    Order
                </th>
                <th align="center" width="10%">
                    Pour Name
                </th>
                <th align="center" width="10%">
                    Project Name
                </th>
                <th align="center" width="8%">
                    Create Date
                </th>
                <th align="center" width="6%">
                    Volume
                </th>
                <th align="center" width="10%">
                    Setup By
                </th>
                <th align="center" width="18%">
                    Stop Recording
                </th>
                <th align="center" width="14%">
                    Pour Type
                </th>
                <th align="center">
                    Operation
                </th>
            </tr>
        </thead>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center" class="tc">
                        &nbsp;<%#Container.ItemIndex+1 %></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("pourname")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("projectname")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#((DateTime)Eval("createdate")).ToString("dd/MM/yyyy") %></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("pourvolume")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("setupby")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#ConvertStopType((string)Eval("stoptype"))%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#ConvertPourType((string)Eval("pourtype"))%></td>
                    <td align="center" class="tc">
                        &nbsp;<a href='javascript:viewItem("<%#Eval("PourID").ToString()%>");'>View DashBoard</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" class="t1" style="margin-top: 2px;">
        <tr>
            <td style="border: 0px; text-align: left;">
                <input id="Button1" class="btn78" type="button" value="Add" onclick="addItem();" />
            </td>
            <td style="border: 0px; text-align: right;">
                <div id="pagenav">
                    <cc1:PagerBar ID="PagerBar1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</body>
</html>
