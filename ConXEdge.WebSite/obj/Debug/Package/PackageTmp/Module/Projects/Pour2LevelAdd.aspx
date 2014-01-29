<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pour2LevelAdd.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.Pour2LevelAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Level Add</title>
    <base target="_self" />
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
     <script src="../../JavaScript/Common/NewCommon.js" type="text/javascript"></script>     
</head>
<script type="text/javascript">
    function Return() {
        window.location.href = "Pour2LevelList.aspx?pid=" + $("#hfpid").val() + "&rand=" + new Date().toString();
    }
</script>
<body>
    <form id="form1" runat="server">
    <div class="p_nav" width="100%">
         <a href="javascript:Return();">Pour Level</a> >>  Level Add
    </div>
      <table class="t2">
        <tr>
            <th>
                Level:
                <asp:HiddenField ID="hfpid" runat="server" />
            </th>
            <td>
                <asp:DropDownList ID="ddlLevel" AutoPostBack="true" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ItemAdd" ForeColor="Red" 
                ControlToValidate="ddlLevel" runat="server" ErrorMessage="Please select level！"></asp:RequiredFieldValidator>
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
