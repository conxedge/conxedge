<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggerTrackList.aspx.cs"
 Inherits="ConXEdge.WebSite.Module.HardwareControl.LoggerTrackList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../../JavaScript/zTree/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../JavaScript/zTree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script src="../../JavaScript/zTree/js/jquery.ztree.all-3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //设置iframe自适应高度(/*兼容FF/IE9/IE8/IE7/IE6*) 
        function iframeResize(iframe) {
            try {
                //var iframe = document.getElementById(frameid); //("contentFrame");
                var idocumentElement = iframe.document.documentElement;
                var ih = Math.min(idocumentElement.scrollHeight, idocumentElement.clientHeight);

                if (ih > 405) {
                    iframe.height -= 5;
                    iframe.height = ih - 33;
                }
                else {
                    iframe.height = 405 - 33;
                }
            }
            catch (e) {
                window.status = 'Error: ' + e.number + '; ' + e.description;
            }
        }
    </script>
</head>
<body>
    <div style="width: 100%; height: 80px; " id="p_div">
        <iframe id="itemtree" frameborder="0" src="LoggerTrackTree.aspx"
            style="width: 12%; float: left;overflow: hidden; border: 1px solid #617775;" onload="iframeResize(this);"></iframe>
        <iframe id="itemlist" frameborder="0" scrolling="yes"  src="" onload="iframeResize(this);"
            style="float: right; width:87%"></iframe>
    </div>
</body>
</html>