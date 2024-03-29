﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactAdd.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.ContactAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Add</title>
    <base target="_self" />
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
     <script src="../../JavaScript/Common/NewCommon.js" type="text/javascript"></script>
     <script type="text/javascript">
         //提交验证
         function CheckInput() {
             if ($("#Contact").val() == "") {
                 alert("Please input Contact！");
                 return false;
             }
             if ($("#Email").val() == "") {
                 alert("Please input Email！");
                 return false;
             }
             return true;
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="p_nav" width="100%">
         <a href="ContactList.aspx"> Contact </a> >> Contact Add
    </div>
      <table class="t2">
        <tr>
            <th>
                Contact:
            </th>
            <td>
               <asp:TextBox ID="Contact" runat="server" MaxLength="50" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Email:
            </th>
            <td>
               <asp:TextBox ID="Email" runat="server" MaxLength="50" ></asp:TextBox>
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
