﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pour2LocationTargetEdit.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.Pour2LocationTargetEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pour Location Target Edit</title>
    <base target="_self" />
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/Common/NewCommon.js" type="text/javascript"></script>     
</head>
<script type="text/javascript">
    //提交验证
    function CheckInput() {
        if ($("#Target").val() == "") {
            alert("Please input Target！");
            return false;
        }
        if (!newCommon.checkInt($("#Target").val())) {
            alert("Target must be integer！");
            return false;
        }
        return true;
    }

    function Return() {
        window.location.href = "Pour2LocationTargetList.aspx?pid=" + $("#hfPourID").val() + "&rand=" + new Date().toString();
    }
</script>
<body>
    <form id="form1" runat="server">
    <div class="p_nav" width="100%">
         <a href="javascript:Return();">Pour Location Target</a> >>  Pour Location Target Edit
    </div>
      <table class="t2">
        <tr>
            <th style="width:100px;">
                Purpose:
                <asp:HiddenField ID="hfpid" runat="server" />
                <asp:HiddenField ID="hfPourID" runat="server" />
            </th>
            <td>
               <asp:TextBox ID="Purpose" runat="server" MaxLength="50" Enabled ="false" ></asp:TextBox>
            </td>
        </tr>
        <tr> 
            <th style="width:100px;">
                EA Target:
            </th>
            <td>
               <asp:TextBox ID="Target" runat="server" MaxLength="50" ></asp:TextBox>
            </td>            
        </tr>        
        <tr>
            <td align="center" colspan="2" >
                <asp:Button ID="btnSave" runat="server" ValidationGroup="ItemAdd" class="btn78" Text="Save" 
                OnClientClick="javascript:return CheckInput();" onclick="btnSave_Click">
                </asp:Button>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>