﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggerAdd.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.LoggerAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logger Add</title>
    <base target="_self" />
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
     <script src="../../JavaScript/Common/NewCommon.js" type="text/javascript"></script>
     <script type="text/javascript">
         //提交验证
         function CheckInput() {
             if ($("#Code").val() == "") {
                 alert("Please input Code！");
                 return false;
             }
             if ($("#SerialNumber").val() == "") {
                 alert("Please input Serial Number！");
                 return false;
             }
             return true;
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="p_nav" width="100%">
         <a href="LoggerList.aspx"> Logger </a> >> Logger Add
    </div>
      <table class="t2">
        <tr>
            <th>
                Logger Code:
            </th>
            <td>
               <asp:TextBox ID="Code" runat="server" MaxLength="50" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Serial Number:
            </th>
            <td>
               <asp:TextBox ID="SerialNumber" runat="server" MaxLength="50" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" >
                <asp:Button ID="btnSave" runat="server" ValidationGroup="ItemAdd" class="btn78" Text="Save" 
                OnClientClick="javascript:return CheckInput();" onclick="btnSave_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" class="btn78" Text="Return" 
                    onclick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>