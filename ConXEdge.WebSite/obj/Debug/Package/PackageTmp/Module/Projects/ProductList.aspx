<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.Projects.ProductList" %>
<%@ Register assembly="ConXEdge.PagerBar" namespace="ConXEdge.Common.PagerBar" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product List</title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
 
        function addItem() {
            url = "ProductAdd.aspx?rTime=" + (new Date().toString());

            //打开模态窗口进行添加
            //var result = showModalDialog(url, 'Product Add', 'dialogWidth:600px;dialogHeight:200px;center:yes;help:no;resizable:no;status:no;scroll:yes');
            //window.location.reload();
            window.location.href = url;
        }
        function editItem(pid) {
            url = "ProductEdit.aspx?pid=" + pid + "&rTime=" + (new Date().toString());
            //打开模态窗口进行修改
            //var result = showModalDialog(url, 'Product Edit', 'dialogWidth:600px;dialogHeight:200px;center:yes;help:no;resizable:no;status:no;scroll:yes');            
            //window.location.reload();
            window.location.href = url;
        }

        //删除信息
        function Delete(pid) {
            if (confirm("Do you confirm to delete product?")) { 
                $.post("OperationHandler.aspx",
                { sType: "delProduct", pid: pid, sDate: new Date().toString() },
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
         Code：<input id="Code" name="Code" type="text" value="<%=Request.QueryString["Code"]%>" />
        <input id="Button2" type="button" value="Query" onclick="javascript:form1.submit()" />
        </form>
    </div>
    <table id="ListArea" border="0" cellpadding="0" cellspacing="0" class="t1 c1" width="98%">
        <thead>
            <tr>
                <th align="center" width="6%">
                    Order
                </th>
                <th align="center"  width="15%">
                    Code
                </th>
                <th align="center" width="20%">
                    Supplier
                </th>
                <th align="center">
                    Description
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
                        &nbsp;<%#Eval("Code")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("Supplier")%></td>
                    <td align="center" class="tc">
                        &nbsp;<%#Eval("Description")%></td>
                    <td align="center" class="tc">
                        &nbsp;<a href='javascript:editItem("<%#Eval("ProductID").ToString()%>");'>Edit </a>&nbsp;
                        <a href='javascript:Delete("<%#Eval("ProductID").ToString()%>");'>Delete </a>
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
