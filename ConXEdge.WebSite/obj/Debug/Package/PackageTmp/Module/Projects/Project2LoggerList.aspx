<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project2LoggerList.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.Projects.Project2LoggerList" %>
<%@ Register assembly="ConXEdge.PagerBar" namespace="ConXEdge.Common.PagerBar" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Logger List</title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .btn78
        {
            height: 21px;
        }
    </style>
</head>
    <script type="text/javascript">
        var pid = "<%=pid %>";
        function addItem() {
            url = "Project2LoggerAdd.aspx?pid=" + pid + "&rTime=" + (new Date().toString());

            //打开模态窗口进行添加
            var result = showModalDialog(url, 'Logger Add', 'dialogWidth:600px;dialogHeight:200px;center:yes;help:no;resizable:no;status:no;scroll:yes');
            window.location.reload();
        }

        //删除信息
        function Delete(loggerid) {
            if (confirm("Do you confirm to delete logger?")) {
                $.post("OperationHandler.aspx",
                { sType: "delProject2Logger", pid: loggerid, sDate: new Date().toString() },
                function (result) {
                    if (result == "") {
                        window.location.reload();
                    }
                    else {
                        alert(msg);
                    }

                });
            }
        }
    </script>
<body>
    <div class="p_nav" width="100%">
         <a href="ProjectList.aspx"> Project </a> : <%=ProjectName%> >> Logger
    </div>
    <table id="ListArea" border="0" cellpadding="0" cellspacing="0" class="t1 c1" width="98%">
        <thead>
            <tr>
                <th align="center" width="6%">
                    Order
                </th>
                <th align="center">
                    Logger Code
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
                        &nbsp;<%#Eval("loggercode")%></td>
                    <td align="center" class="tc">
                        &nbsp;<a href='javascript:Delete("<%#Eval("id").ToString()%>");'>Delete </a>
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
