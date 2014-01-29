<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PourEditTabs.aspx.cs" 
Inherits="ConXEdge.WebSite.Module.Projects.PourEditTabs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-en.js" type="text/javascript"></script>
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/icon.css" rel="stylesheet" type="text/css" />
</head>
 <script type="text/javascript">
     var pid = "<%=pid %>";

     $(document).ready(function () {
         $("#itemBaseInfo").attr("src", "PourEdit.aspx?pid=" + pid + "&rand=" + new Date().toString());
         $("#itemTarget").attr("src", "Pour2TargetList.aspx?pid=" + pid + "&rand=" + new Date().toString());
         $("#itemLocation").attr("src", "Pour2LocationList.aspx?pid=" + pid + "&rand=" + new Date().toString());
         $("#itemLevels").attr("src", "Pour2LevelList.aspx?pid=" + pid + "&rand=" + new Date().toString());

         $('#tabs').tabs({
             border: false,
             onSelect: function (title) {
                 if (title == "Default Pour Target") {
                     $("#itemTarget").attr("src", "Pour2TargetList.aspx?pid=" + pid + "&rand=" + new Date().toString());
                 }
                 else if (title == "Location") {
                     $("#itemLocation").attr("src", "Pour2LocationList.aspx?pid=" + pid + "&rand=" + new Date().toString());
                 }
                 else if (title == "Levels") {
                     $("#itemLevels").attr("src", "Pour2LevelList.aspx?pid=" + pid + "&rand=" + new Date().toString());
                 }
             }
         });
     });

     //设置iframe自适应高度(/*兼容FF/IE9/IE8/IE7/IE6*) 
     function iframeResize(iframe) {
         try {
             //var iframe = document.getElementById(frameid); //("contentFrame");
             var idocumentElement = iframe.document.documentElement;
             var ih = Math.max(idocumentElement.scrollHeight, idocumentElement.clientHeight);

             if (ih > 250) {
                 iframe.height = ih - 55;
             }
             else {
                 iframe.height = 250;
             }
         }
         catch (e) {
             window.status = 'Error: ' + e.number + '; ' + e.description;
         }
     }
    </script>
    <body>
        <form id="form1" runat="server">
        <div id="tabs" class="easyui-tabs" plain="true">      
            <div title="Base Info" style="padding: 3px;">
               <iframe id="itemBaseInfo" frameborder="0" src=""
                style="width: 100%; float:none;overflow:auto; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div>
            <div title="Default Pour Target" style="padding: 3px;">
                <iframe id="itemTarget" frameborder="0" src=""
                style="width: 100%; float: left;overflow: hidden; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div> 
            <div title="Location" style="padding: 3px;">
                <iframe id="itemLocation" frameborder="0" src=""
                style="width: 100%; float: left;overflow: hidden; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div>    
            <div title="Levels" style="padding: 3px;">
                <iframe id="itemLevels" frameborder="0" src=""
                style="width: 100%; float: left;overflow: hidden; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div>           
        </div>
        </form>
    </body>
</html>

