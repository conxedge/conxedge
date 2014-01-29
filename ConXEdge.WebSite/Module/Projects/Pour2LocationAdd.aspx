<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pour2LocationAdd.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.Pour2LocationAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pour Location Add</title>
 <base target="_self" />
  <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../../JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../../JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-zh_CN.js"></script>
 <script src="../../JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
 <link href="../../JavaScript/jquery-easyui-1.2.2/themes/icon.css" rel="stylesheet" type="text/css" />
 <link href="../../JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
 <script src="../../JavaScript/Common/NewCommon.js" type="text/javascript"></script>
</head>
 <script type="text/javascript">
     var projectid = "<%=projectId %>"
     var pourType = "<%=PourType %>"
     var pid = "<%=PourID %>"

     $(document).ready(function () {
         //加载Logger
         $('#ddlLogger').combobox({
             url: 'OperationHandler.aspx?sType=getLogger&projectid=' + projectid + '&rand=' + new Date().toString(),
             valueField: '_loggerid',
             textField: '_loggercode',
             editable: false,
             onSelect: function () {
                 var selectValue = $(this).combobox('getValue');
                 $("#hdLogger").val(selectValue);
                 if (pourType == '2') {
                     LoadLoggingStart();
                 }
             },
             onLoadSuccess: function () {

             }
         });

         //加载ChannelNo
         $('#ddlChannelNo').combobox({
             url: 'OperationHandler.aspx?sType=getChannelNo&rand=' + new Date().toString(),
             valueField: 'value',
             textField: 'text',
             editable: false,
             onSelect: function () {
                 var selectValue = $(this).combobox('getValue');
                 $("#hdChannelNo").val(selectValue);
                 if (pourType == '2') {
                     LoadLoggingStart();
                 }
             },
             onLoadSuccess: function () {
             }
         });

         //加载Monitor Type
         $('#ddlMonitorType').combobox({
             url: 'OperationHandler.aspx?sType=getMonitorType&rand=' + new Date().toString(),
             valueField: 'value',
             textField: 'text',
             editable: false,
             onSelect: function () {
                 var selectValue = $(this).combobox('getValue');
                 $("#hdMonitorType").val(selectValue);
             },
             onLoadSuccess: function () {
             }
         });
     });

     function LoadLoggingStart() {
         var loggerID = $("#hdLogger").val();
         var channelID = $("#hdChannelNo").val();
         $('#ddlLoggingStart').combobox("clear");
         $("#hdLoggingStart").val('');

         if (loggerID != "" && channelID != "") {
             //加载Logging Start
             $('#ddlLoggingStart').combobox({
                 url: 'OperationHandler.aspx?sType=getLoggingStart&LoggerID=' + loggerID + '&ChannelID='
                        + channelID + '&rand=' + new Date().toString(),
                 valueField: 'value',
                 textField: 'text',
                 editable: false,
                 onSelect: function () {
                     var selectValue = $(this).combobox('getValue');
                     $("#hdLoggingStart").val(selectValue);
                 },
                 onLoadSuccess: function () {
                 }
             });
         }
     }

     //提交验证
     function CheckInput() {
         if ($("#LocationID").val() == "") {
             alert("Please input location id！");
             return false;
         }
         if ($("#Details").val() == "") {
             alert("Please input details！");
             return false;
         }
         if ($("#hdLogger").val() == "") {
             alert("Please select logger！");
             return false;
         }
         if ($("#hdChannelNo").val() == "") {
             alert("Please select channel no！");
             return false;
         }
         if ($("#hdMonitorType").val() == "") {
             alert("Please select Monitor Type！");
             return false;
         }
         if (pourType == '2' && $("#hdLoggingStart").val() == "") {
             alert("Please select Logging Start！");
             return false;
         }
         if ($("#LocationDescription").val() == "") {
             alert("Please input Location Description！");
             return false;
         }

         return true;
     }

     function Return() {
         window.location.href = "Pour2LocationList.aspx?pid=" + $("#hfpid").val() + "&rand=" + new Date().toString();
     }
    </script>
<body>
    <form id="form1" runat="server">
    <div class="p_nav" width="100%">
         <a href="javascript:Return();">Pour Location</a> >>  Pour Location Add
    </div>
      <table class="t2">
        <tr>
            <th style="width:100px;">
                LocationID:
                <asp:HiddenField ID="hfpid" runat="server" />
            </th>
            <td>
               <asp:TextBox ID="LocationID" runat="server" MaxLength="50" ></asp:TextBox>
            </td>
            <th style="width:100px;">
                Details:
            </th>
            <td>
               <asp:TextBox ID="Details" runat="server" MaxLength="50" ></asp:TextBox>
            </td>            
        </tr>
        <tr>            
            <th>
                Logger:
            </th>
            <td>
                <select id="ddlLogger" class="easyui-combobox" style="width: 150px;" panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdLogger" runat="server" />
            </td>
            <th>
                Channel No.:
            </th>
            <td>
                <select id="ddlChannelNo" class="easyui-combobox" style="width: 150px;" panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdChannelNo" runat="server" />
            </td>
        </tr>
        <tr>            
            <th>
                Monitor Type:
            </th>
            <td>
                <select id="ddlMonitorType" class="easyui-combobox" style="width: 150px;" panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdMonitorType" runat="server" />
            </td>
            <th>
                Location Description:
            </th>
            <td>
                <asp:TextBox ID="LocationDescription" runat="server" MaxLength="50" ></asp:TextBox>
                <asp:HiddenField ID="hdLoggingStart" runat="server" />
            </td>
        </tr>
        <%=strLoggingStarted%>
        <tr>
            <td align="center" colspan="4" >
                <asp:Button ID="btnSave" runat="server" ValidationGroup="ItemAdd" class="btn78" Text="Save" 
                OnClientClick="javascript:return CheckInput();" onclick="btnSave_Click">
                </asp:Button>
<%--                <asp:Button ID="btnCancel" runat="server" class="btn78" Text="Cancel" 
                    onclick="btnCancel_Click"></asp:Button>--%>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
