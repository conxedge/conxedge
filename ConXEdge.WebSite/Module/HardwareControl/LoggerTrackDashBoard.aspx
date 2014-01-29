<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggerTrackDashBoard.aspx.cs"
    Inherits="ConXEdge.WebSite.Module.HardwareControl.LoggerTrackDashBoard" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-en.js" type="text/javascript"></script>
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JavaScript/jquery-easyui-1.2.2/themes/icon.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .btn78
        {
            height: 21px;
        }
    </style>
</head>
    <script type="text/javascript">
        ColumnCount = "<%=ColumnCount %>"
        TargetCount = "<%=TargetCount %>"

        $(document).ready(function () {
            setInterval("GetTrackInfo()", 1000);
        });

        function GetTrackInfo() {
            //当前时间
            var d = new Date();
            var formatdate = d.getYear() + "-" + (d.getMonth() + 1) + "-"
            + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();

            //获取当前Equivalent Age
            $.ajax({
                type: "GET",
                dataType: "text",
                async: false,
                url: "OperationHandler.aspx",
                data: "sType=GetEquivalentAge&pourid=" + $("#hfpid").val() + "&rand=" + new Date().toString(),
                success: function (msg) {
                    var tmp = msg.split(';');
                    for (i = 0; i < tmp.length - 1; i++) {
                        var tmp2 = tmp[i].split('|');
                        $('#LoggingStarted' + i).val(tmp2[0]);
                        $('#EquivalentAge' + i).val(tmp2[2]);
                        $('#Temperature' + i).val(tmp2[1]);
                        for (j = 0; j < TargetCount; j++) {
                            $('#Target' + j + 'Loc' + i + 'DateTime').val(tmp2[3 + 2 * j]);
                            $('#Target' + j + 'Loc' + i + 'Temperature').val(tmp2[4 + 2 * j]);
                            //当前时间和Logger开始时间差
                            $('#Target' + j + 'Loc' + i + 'ElapsedTime').val(TimeSpan($('#LoggingStarted' + i).val(), tmp2[3 + 2 * j]));
                        }
                    }
                }
            })

            for(i=0;i<ColumnCount-5;i++)
            {
                //当前时间
                $('#DateTime' + i).val(formatdate);
                //当前时间和Logger开始时间差
                $('#ElapsedTime' + i).val(TimeSpan($('#LoggingStarted' + i).val(), new Date().toString()));
                for (j = 0; j < TargetCount; j++) {
                    //当前Equivalent Age和Target Equivalent Age 百分比
                    var curAge = parseFloat($('#EquivalentAge' + i).val());
                    var targetAge = parseFloat($('#Target' + j + 'Loc' + i + 'EquivalentAge').val());
                    if (curAge < targetAge) {
                        $('#Target' + j + 'Per' + i).val((curAge / targetAge * 100).toFixed(0) + "%");
                    }
                    else {
                        $('#Target' + j + 'Loc' + i + 'EquivalentAge').css("background-color", "#00FF00");
                    }
                }
            }
        }

        function TimeSpan(Started, Finished) {
            if(Started == "" || Finished == "")
                return;
            //时间差的毫秒数
            var ms = new Date(Finished.replace(/-/g, "\/")).getTime() - new Date(Started.replace(/-/g, "\/")).getTime();

            //计算出小时数
            //var leave1 = ms % (24 * 3600 * 1000)    //计算天数后剩余的毫秒数
            var hours = Math.floor(ms / (3600 * 1000))
            //计算相差分钟数
            var leave2 = ms % (3600 * 1000)        //计算小时数后剩余的毫秒数
            var minutes = Math.floor(leave2 / (60 * 1000))

            return hours + ":" + minutes;
        }
    </script>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hfpid" runat="server"></asp:HiddenField>   
        <%=TableDetails%>
    </form>
</body>
</html>
