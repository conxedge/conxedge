﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project2LoggerAdd.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.Project2LoggerAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logger Add</title>
 <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="p_nav" width="100%">
         Projects >> Logger Add
    </div>
      <table class="t2">
        <tr>
            <th>
                Logger Code:
                <asp:HiddenField ID="hfpid" runat="server" />
            </th>
            <td>
                <asp:DropDownList ID="ddlLogger" AutoPostBack="true" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ItemAdd" ForeColor="Red" 
                ControlToValidate="ddlLogger" runat="server" ErrorMessage="Please select logger code！"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" >
                <asp:Button ID="btnSave" runat="server" ValidationGroup="ItemAdd" class="btn78" Text="Save" onclick="btnSave_Click">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" class="btn78" Text="Cancel" 
                    onclick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
