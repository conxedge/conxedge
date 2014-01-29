<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pour2LocationTargetList.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.Projects.Pour2LocationTargetList" %>
<%@ Register assembly="ConXEdge.PagerBar" namespace="ConXEdge.Common.PagerBar" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pour Location Target List</title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .btn78
        {
            height: 21px;
        }
    </style>
</head>
<script type="text/javascript">
    function editItem(pid) {
        url = "Pour2LocationTargetEdit.aspx?pid=" + pid + "&rTime=" + (new Date().toString());
        window.location.href = url;
    }

    function Return() {
        window.location.href = "Pour2LocationList.aspx?pid=" + $("#hfpid").val() + "&rand=" + new Date().toString();
    }
</script>
<body>
    <form runat="server">
    <div class="p_nav" width="100%">
         <a href="javascript:Return();">Pour Location</a> >>  Pour Location Target List
    </div>
    <asp:HiddenField ID="hfpid" runat="server" />
    <table id="ListArea" border="0" cellpadding="0" cellspacing="0" class="t1 c1" width="98%">
        <thead>
            <tr>
                <th align="center" width="6%">
                    Order
                </th>
                <th align="center">
                    Purpose
                </th>
                <th align="center" width="20%">
                    Default Target
                </th>
                <th align="center" width="20%">
                    EA Target
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
                        &nbsp;<%#Eval("Purpose")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("DefaultTarget")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("Target")%></td>
                    <td align="center" class="tc">
                        &nbsp;<a href='javascript:editItem("<%#Eval("ID").ToString()%>");'>Edit </a>&nbsp;
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" class="t1" style="margin-top: 2px;">
        <tr>
            <td style="border: 0px; text-align: right;">
                <div id="pagenav">
                    <cc1:PagerBar ID="PagerBar1" runat="server" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
