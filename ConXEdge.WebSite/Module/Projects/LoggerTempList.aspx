<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggerTempList.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.Projects.LoggerTempList" %>
<%@ Register assembly="ConXEdge.PagerBar" namespace="ConXEdge.Common.PagerBar" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Logger Temp List</title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-zh_CN.js"></script>
    <script src="../../JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
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
         Project Name：<input id="ProjectName" name="ProjectName" type="text" value="<%=Request.QueryString["ProjectName"]%>" />
         &nbsp;&nbsp;Pour Name：<input id="PourName" name="PourName" type="text" value="<%=Request.QueryString["PourName"]%>" />
         &nbsp;&nbsp;Logger Code：<input id="LoggerCode" name="LoggerCode" type="text" value="<%=Request.QueryString["LoggerCode"]%>" />
         &nbsp;&nbsp;Date from：<input id="StartTime" name="StartTime" class="editbox" style="width: 120px" type="text"
          onfocus="this.blur();WdatePicker({lang:'en',dateFmt:'dd/MM/yyyy'})" value="<%=Request.QueryString["StartTime"]%>" />
         &nbsp;to&nbsp;<input id="EndTime" name="EndTime" class="editbox" style="width: 120px" type="text"
          onfocus="this.blur();WdatePicker({lang:'en',dateFmt:'dd/MM/yyyy'})" value="<%=Request.QueryString["EndTime"]%>" />
        <input id="Button2" type="button" value="Query" onclick="javascript:form1.submit()" />
        </form>
    </div>
    <table id="ListArea" border="0" cellpadding="0" cellspacing="0" class="t1 c1" width="98%">
        <thead>
            <tr>
                <th align="center" width="6%">
                    Order
                </th>
                <th align="left" width="10%">
                    Logger Code
                </th>
                <th align="left" width="10%">
                    Channel No
                </th>
                <th align="left" width="15%">
                    Current Time
                </th>
                <th align="left" width="6%">
                    Temp
                </th>
                <th align="left" width="25%">
                    Pour Name
                </th>
                <th align="left">
                    Project Name
                </th>
            </tr>
        </thead>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center" class="tc">
                        &nbsp;<%#Container.ItemIndex+1 %></td>
                    <td align="left" class="tc">
                        &nbsp;<%#Eval("loggercode")%></td>
                    <td align="left" class="tc">
                        &nbsp;<%#Eval("channelno")%></td>
                    <td align="left" class="tc">
                        &nbsp;<%#((DateTime)Eval("currenttime")).ToString("dd/MM/yyyy HH:mm") %></td>
                    <td align="left" class="tc">
                        &nbsp;<%#Eval("temp")%></td>
                    <td align="left" class="tc">
                        &nbsp;<%#Eval("pourname")%></td>
                    <td align="left" class="tc">
                        &nbsp;<%#Eval("projectname")%></td>
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
</body>
</html>
