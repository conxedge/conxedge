﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pour2LocationList.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.Projects.Pour2LocationList" %>
<%@ Register assembly="ConXEdge.PagerBar" namespace="ConXEdge.Common.PagerBar" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pour Location List</title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .btn78
        {
            height: 21px;
        }
    </style>
</head>
<body>
        <script type="text/javascript">
            var pourid = "<%=pourid %>";

            function addItem() {
                url = "Pour2LocationAdd.aspx?pourid=" + pourid + "&rTime=" + (new Date().toString());
                window.location.href = url;
            }

            function editItem(pid) {
                url = "Pour2LocationEdit.aspx?pourid=" + pourid + "&pid=" + pid + "&rTime=" + (new Date().toString());
                window.location.href = url;
            }

            function SetTarget(pid) {
                url = "Pour2LocationTargetList.aspx?pid=" + pid + "&rTime=" + (new Date().toString());
                window.location.href = url;
            }

            //删除信息
            function Delete(pid) {
                if (confirm("Do you confirm to delete pour location?")) {
                    $.post("OperationHandler.aspx",
                { sType: "delPour2Location", pid: pid, sDate: new Date().toString() },
                function (result) {
                    if (result == "") {
                        window.location.reload();
                    }
                    else {
                        alert(result);
                    }

                });
                }
            }
    </script>
    <table id="ListArea" border="0" cellpadding="0" cellspacing="0" class="t1 c1" width="98%">
        <thead>
            <tr>
                <th align="center" width="6%">
                    Order
                </th>
                <th align="center" width="10%">
                    LocationID
                </th>
                <th align="center">
                    LocationDescription
                </th>
                <th align="center" width="15%">
                    Details
                </th>
                <th align="center" width="10%">
                    Logger
                </th>
                <th align="center" width="10%">
                    Channel No.
                </th>
                <th align="center" width="20%">
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
                        &nbsp;<%#Eval("LocationID")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("LocationDescription")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("Details")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("LoggerCode")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("ChannelNo")%></td>
                    <td align="center" class="tc">
                        &nbsp;<a href='javascript:editItem("<%#Eval("ID").ToString()%>");'>Edit </a>&nbsp;
                        <a href='javascript:Delete("<%#Eval("ID").ToString()%>");'>Delete </a>&nbsp;
                        <a href='javascript:SetTarget("<%#Eval("ID").ToString()%>");'>Edit Target </a>&nbsp;
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" class="t1" style="margin-top: 2px;">
        <tr>
            <td style="border: 0px; text-align: left;">
                <input id="Button3" class="btn78" type="button" value="Add" onclick="addItem();" />
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