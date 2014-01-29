<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PourAdd.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.PourAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pour Add</title>
 <base target="_self" />
 <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="../../JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js"></script>
 <script type="text/javascript" src="../../JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-zh_CN.js"></script>
 <script src="../../JavaScript/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
 <link href="../../JavaScript/jquery-easyui-1.2.2/themes/icon.css" rel="stylesheet" type="text/css" />
 <link href="../../JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
 <script src="../../JavaScript/Common/NewCommon.js" type="text/javascript"></script>

 <script type="text/javascript">
     $(document).ready(function () {
         //加载项目
         $('#ddlProject').combobox({
             url: 'OperationHandler.aspx?sType=getProject&rand=' + new Date().toString(),
             valueField: '_projectid',
             textField: '_projectname',
             editable: false,
             onSelect: function () {
                 var selectValue = $(this).combobox('getValue');
                 $("#hdProject").val(selectValue);
             },
             onLoadSuccess: function () {
             }
         });

         //加载Product
         $('#ddlProduct').combobox({
             url: 'OperationHandler.aspx?sType=getProduct&rand=' + new Date().toString(),
             valueField: '_productid',
             textField: '_code',
             editable: false,
             onSelect: function () {
                 $("#hdProduct").val($(this).combobox('getValue'));
             },
             onLoadSuccess: function () {
             }
         });

         //加载Maturity Method
         $('#ddlMaturityMethod').combobox({
             url: 'OperationHandler.aspx?sType=getMaturityMethod&rand=' + new Date().toString(),
             valueField: 'value',
             textField: 'text',
             editable: false,
             onSelect: function () {
                 $("#hdMaturityMethod").val($(this).combobox('getValue'));
             },
             onLoadSuccess: function () {
             }
         });

         //加载Contact
         $('#ddlContact').combobox({
             url: 'OperationHandler.aspx?sType=getContact&rand=' + new Date().toString(),
             valueField: '_contactid',
             textField: '_contact',
             editable: false,
             onSelect: function () {
                 $("#hdContact").val($(this).combobox('getValue'));
             },
             onLoadSuccess: function () {
             }
         });

         //加载Stop Recording When
         $('#ddlStopType').combobox({
             url: 'OperationHandler.aspx?sType=getStopType&rand=' + new Date().toString(),
             valueField: 'value',
             textField: 'text',
             editable: false,
             onSelect: function () {
                 $("#hdStopType").val($(this).combobox('getValue'));
             },
             onLoadSuccess: function () {
             }
         });

         //加载Pour Type
         $('#ddlPourType').combobox({
             url: 'OperationHandler.aspx?sType=getPourType&rand=' + new Date().toString(),
             valueField: 'value',
             textField: 'text',
             editable: false,
             onSelect: function () {
                 $("#hdPourType").val($(this).combobox('getValue'));
             },
             onLoadSuccess: function () {
             }
         });
     });

     //提交验证
     function CheckInput() {
         if ($("#Name").val() == "") {
             alert("Please input pour name！");
             return false;
         }
         if ($("#hdProject").val() == "") {
             alert("Please select project！");
             return false;
         }
         if ($("#txtCreateDate").val() == "") {
             alert("Please input create date！");
             return false;
         }
         if ($("#Volume").val() == "") {
             alert("Please input pour volume！");
             return false;
         }
         if (!newCommon.checkInt($("#Volume").val())) {
             alert("Pour volume must be integer！");
             return false;
         }
         if ($("#SetupBy").val() == "") {
             alert("Please input setup by！");
             return false;
         }
         if ($("#Started").val() == "") {
             alert("Please input started！");
             return false;
         }
         if ($("#Finished").val() == "") {
             alert("Please input finished！");
             return false;
         }
         if ($("#hdMaturityMethod").val() == "") {
             alert("Please select maturity method！");
             return false;
         }         
         if ($("#hdProduct").val() == "") {
             alert("Please select product！");
             return false;
         }
         if ($("#hdContact").val() == "") {
             alert("Please select contact！");
             return false;
         }
         if ($("#hdStopType").val() == "") {
             alert("Please select Stop Recording When！");
             return false;
         }
         if($("#hdStopType").val() == "3" || $("#hdStopType").val() == "4" )
         {
             if ($("#XHours").val() == "") {
                alert("Please input X Hours！");
                return false;
             }
             if (!newCommon.checkInt($("#XHours").val())) {
                 alert("X Hours must be integer！");
                 return false;
             }
         }
         if ($("#hdPourType").val() == "") {
             alert("Please select pour type！");
             return false;
         }        
         return true;
     }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="p_nav" width="100%">
         <a href="PourList.aspx">Pour</a> >> Pour Add
    </div>
      <table class="t2">
        <tr>
            <th>
                Pour Name:
            </th>
            <td>
               <asp:TextBox ID="Name" runat="server" MaxLength="50" ></asp:TextBox>
            </td>
            <th>
                Project:
            </th>
            <td>
                <select id="ddlProject" class="easyui-combobox" style="width: 150px;" panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdProject" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                Create Date:
            </th>
            <td>
                <input id="txtCreateDate" class="editbox" style="width: 120px" type="text" runat="server"
                        onfocus="this.blur();WdatePicker({lang:'en',dateFmt:'dd/MM/yyyy'})" />
            </td>
            <th>
                Pour Volume:
            </th>
            <td>
                <asp:TextBox ID="Volume" runat="server" MaxLength="10" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Setup By:
            </th>
            <td>
                <asp:TextBox ID="SetupBy" runat="server" MaxLength="50" ></asp:TextBox>
            </td>
            <th>
                Started:
            </th>
            <td>
                <input id="Started" class="editbox" style="width: 120px" type="text" runat="server"
                        onfocus="this.blur();WdatePicker({lang:'en',dateFmt:'dd/MM/yyyy HH:mm:ss'})" />
            </td>
        </tr>
        <tr>
            <th>
                Finished:
            </th>
            <td>
                <input id="Finished" class="editbox" style="width: 120px" type="text" runat="server"
                        onfocus="this.blur();WdatePicker({lang:'en',dateFmt:'dd/MM/yyyy HH:mm:ss'})" />
            </td>
            <th>
                Maturity Method:
            </th>
            <td>
                <select id="ddlMaturityMethod" class="easyui-combobox" style="width: 150px;"
                    panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdMaturityMethod" runat="server" />
            </td>
        </tr>
        <tr>            
            <th>
                Product:
            </th>
            <td>
                <select id="ddlProduct" class="easyui-combobox" style="width: 150px;"
                    panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdProduct" runat="server" />
            </td>
            <th>
                Contact:
            </th>
            <td>
                <select id="ddlContact" class="easyui-combobox" style="width: 150px;"
                    panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdContact" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                Stop Recording:
            </th>
            <td>
                <select id="ddlStopType" class="easyui-combobox" style="width: 350px;"
                    panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdStopType" runat="server" />
            </td>
            <th>
                X Hours:
            </th>
            <td>
                <asp:TextBox ID="XHours" runat="server" MaxLength="4" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Pour Type:
            </th>
            <td>
                <select id="ddlPourType" class="easyui-combobox" style="width: 350px;"
                    panelheight="150px" required="true" runat="server">
                </select>
                <asp:HiddenField ID="hdPourType" runat="server" />
            </td>
            <th>
            </th>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" >
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
