<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConXEdge.WebSite.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ConXEdge</title>
    <link href="Style/global.css" rel="stylesheet" type="text/css" />
    <link href="Style/login.css" rel="stylesheet" type="text/css" />
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/Common/NewCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        //提交验证
        function CheckInput() {
            if ($("#txtUserName").val() == "") {
                alert("Please input user name！");
                return false;
            }
            if ($("#txtPwd").val() == "") {
                alert("Please input password！");
                return false;
            }
            return true;
        }
     </script>
</head>
<body class="login">
<div id = "login-wrapper" class = "png_bg">
    <div id = "login-top">
        <h1>Conxedge</h1>
        <h3>By HMT<h3>
    </div>
    <div id = "login-content">
                                                                                                                                                                                                   <form id="form1" runat="server">
                <p>
                    <label>Username</label>
                    <asp:TextBox ID="txtUserName" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                </p>
                <p>
                    <label>Password</label>
                    <asp:TextBox ID="txtPwd" runat="server" Width="200px" TextMode="Password" MaxLength="50"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="javascript:return CheckInput();" 
                                    onclick="btnLogin_Click" />
                </p>
                <p>
                    <asp:HyperLink ID="FindPwd" runat="server">Forgot password?</asp:HyperLink>
                </p>
                
          </form>
     </div>
</div>
<div id = "dummy" />
<div id = "dummy2" />
</body>
</html>
