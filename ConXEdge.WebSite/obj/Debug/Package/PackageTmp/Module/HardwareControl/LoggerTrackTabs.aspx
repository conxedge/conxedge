<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggerTrackTabs.aspx.cs" Inherits="ConXEdge.WebSite.Module.HardwareControl.LoggerTrackTabs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-en.js" type="text/javascript"></script>
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/icon.css" rel="stylesheet" type="text/css" />
</head>
 <script type="text/javascript">
     var pid="<%=pid %>"

     $(document).ready(function () {
         $("#itemSetup").attr("src", "LoggerTrackSetup.aspx?pid=" + pid + "&rand=" + new Date().toString());
         $("#itemDashBoard").attr("src", "LoggerTrackDashBoard.aspx?pid=" + pid + "&rand=" + new Date().toString());         

         $('#tabs').tabs({
             border: false,
             onSelect: function (title) {
                 if (title == "Temp ver Elapsed Time") {
                     $("#itemChart1").attr("src", "LoggerTrackChart1.aspx?pid=" + pid + "&rand=" + new Date().toString());
                 }
                 else if (title == "EA ver Elapsed Time") {
                     $("#itemChart2").attr("src", "LoggerTrackChart2.aspx?pid=" + pid + "&rand=" + new Date().toString());
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
            <div title="Pour-Element Setup" style="padding: 3px;">
               <iframe id="itemSetup" frameborder="0" src=""
                style="width: 100%; float:none;overflow:auto; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div>
            <div title="Dash Board" style="padding: 3px;">
                <iframe id="itemDashBoard" frameborder="0" src=""
                style="width: 100%; float: left;overflow: hidden; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div> 
            <div title="Temp ver Elapsed Time" style="padding: 3px;">
                <iframe id="itemChart1" frameborder="0" src=""
                style="width: 100%; float: left;overflow: hidden; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div>    
            <div title="EA ver Elapsed Time" style="padding: 3px;">
                <iframe id="itemChart2" frameborder="0" src=""
                style="width: 100%; float: left;overflow: hidden; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
            </div>           
        </div>
        </form>
    </body>
</html>
