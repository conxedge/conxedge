<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConXEdge.WebSite.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ConXEdge</title>
    <meta content="IE=7" http-equiv="X-UA-Compatible" />
    <script src="JavaScript/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="JavaScript/Common/NewCommon.js" type="text/javascript"></script>
    <script src="JavaScript/jquery-easyui-1.2.2/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="JavaScript/jquery-easyui-1.2.2/locale/easyui-lang-en.js" type="text/javascript"></script>
    <link href="JavaScript/jquery-easyui-1.2.2/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="Style/Global.css" rel="stylesheet" type="text/css" />
    <link href="Style/PageDefault.css" rel="stylesheet" type="text/css" />
    <link href="Style/icon.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function alertMsg(msg, fn) {
            $.messager.alert("System Infomation", msg, "", fn);
        }

        function alertErrorMsg(msg) {
            $.messager.alert("System Infomation", msg, "error");
        }

        function confirmMsg(msg, fn) {
            $.messager.confirm('System Infomation', msg, fn);
        }

        function defaultPage() {
            this.quitSystem = function () {
                $.messager.confirm("System Infomation", "Do you want to exit system？", function (r) {
                    if (r) {
                        window.parent.location.href = "\login.aspx";
                    }
                });
            }
        }

        var dp = new defaultPage();
        function onChangeMenuItem(control, type) {
            if (type == 1) {
                $(control).addClass("pageitemselect");

            }
            else if (type == 3) {
                $(control).addClass("pageitemselect2");
            }
            else {
                $(control).removeClass("pageitemselect");
                $(control).removeClass("pageitemselect2");
            }
        }

        //点击左边菜单
        function fclickLevelMenu(itemMenu, itemLevelId) {
            var iCount = $(".div_level_item").length;
            var tempId = itemLevelId.substring(0, itemLevelId.length - 1);
            for (var i = 1; i <= iCount; i++) {
                $("#" + tempId + i.toString()).css("display", "none");
            }
            if ($("#" + itemLevelId).height() > $("#tdleft").height() - 45 - $("#divLeftMenu").height()) {
                $("#" + itemLevelId).height($("#tdleft").height() - 45 - $("#divLeftMenu").height());
                $("#" + itemLevelId).css("overflow-y", "auto");
            }

            $("#" + itemLevelId).css("display", "block");
        }

        //子页刷新高度中调用
        function fSetHeight(heightvalue) {
            try {
                var t1 = $("#divlefttop").height();
                var t2 = $("#divlefttree").height();
                if (heightvalue > (t1 + t2)) {
                    $("#divtree").height(heightvalue - t1 - 30);

                }
            } catch (e) { }
        }

        //div展开
        function ExtendDiv(id) {
            var divObj = $("#" + id);
            if ($(divObj).attr("isExtend") == "1") {
                $(divObj).hide();
                $(divObj).attr("isExtend", "0");
            }
            else {
                $(divObj).show();
                $(divObj).attr("isExtend", "1");
            }
        }

        function OpenPwdUpdate() {
            alert('the function is uncomplete yet');
//                var url = "Module/System/PasswordUpdate.aspx?rTime" + (new Date().toString());
//                showModalDialog(url, '类型添加', 'dialogWidth:600px;dialogHeight:400px;center:yes;help:no;resizable:no;status:no;scroll:yes');
        }

        $(document).ready(function () {
            var itype = $("#hfInitType").val();
            var url = "";
            switch (parseInt(itype)) {
                case 1: url = ""; break;
                case 2: url = ""; break;
                default: url = "Module/Projects/ProjectList.aspx"; break;
            }
            document.getElementById("mainFrame").src = url;
            $("#mainFrame").height(document.documentElement.clientHeight - 187);
        });
    </script>
    <style type="text/css">
        html
        {
            overflow: hidden;
        }
    </style>
</head>
<body style="background-color: #A6E1FF;">
    <input type="hidden" id="hfInitType" runat="server" />
    <input type="hidden" id="hiduserinfo" runat="server" />
    <div>
        <div>
            <table cellpadding="0" cellspacing="0" style="width: 100%; height: 90px; background: url('Style/Images/Default/top_pp.jpg');">
                <tr>
                    <td align="left" valign="top" style="height: 92px; background: url('Style/Images/Default/top_back_0_SFJ.jpg');
                        background-repeat: no-repeat;">
                        <div style="float: right; height: 28px;">
                            <div style="width: 220px; height: 28px; background: url('Style/Images/Default/top_back_1.jpg');
                                background-repeat: no-repeat;">
                                <div style="width: 50px; float: left; margin-left: 6px; font-size: 12px; height: 28px;
                                    line-height: 26px;">
                                    <a class="linkmenulevel1" style="color: Black;" href="javascript:alert('the function is uncomplete yet');"
                                        target="mainFrame">
                                        <img src="/Style/Images/Default/help.jpg" style="position: relative; top: -4px;" />help</a>
                                </div>
                                <div style="width: 70px; float: left; margin-left: 2px; font-size: 12px; height: 28px;
                                    line-height: 26px;">
                                    <a class="linkmenulevel1" style="color: Black;" href="javascript:OpenPwdUpdate();">
                                        <img src="/Style/Images/Default/Top_Lock.jpg" style="position: relative; top: -4px;" />password</a></div>
                                <div style="width: 70px; float: left; margin-left: 2px; height: 28px; line-height: 26px;">
                                    <a class="linkmenulevel1" style="color: Black;" href="javascript:void(0);" onclick="dp.quitSystem();">
                                        <img src="/Style/Images/Default/Top_Close.jpg" style="position: relative; top: -4px;" />exit</a></div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr style="background: url('Style/Images/Default/TopLine.jpg');">
                    <td align="left" style="height: 33px; margin: 0px;">
                        <div style="height: 33px; width: 50px; background-repeat: no-repeat; float: left;">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="homepagecenter">
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td colspan="2" align="left" valign="middle" style="height: 30px; line-height: 30px;">
                    <div style="margin-left: 10px; float: left; width: 200px; height: 30px; line-height: 30px;
                        color: White;">
                        <img src="Style/Images/Default/Notice.jpg" alt="" style="vertical-align: middle;" /><%= CurrentUserInfo == null ? "" : "Hello " + CurrentUserInfo.UserName%>&nbsp;&nbsp;
                    </div>
                    <div style="padding-left: 40px; float: left; width: 700px; margin-top: 2px; line-height: 28px;
                        height: 28px; line-height: 28px; color: White; background: url('Style/Images/Default/top_message_bk.jpg');
                        background-repeat: no-repeat;">
                    </div>
                    <div style="clear: both;">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table class="homepagecenter" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 5px;">
                <div>
                </div>
            </td>
            <td id="tdleft" class="tdleft">
                <div id="divMenuTitle" class="dl_title" style="height: 30px;">
                    System Menu
                </div>
                <div id="divHomePage" class="leftcontent">
                    <div class="home_left_div">
                        <div class="home_left_div_title" onclick="ExtendDiv('divProject');">
                            <img class="img_title" src="Style/Images/Default/pixel.gif" />
                            <font class="font_title">Projects</font>
                        </div>
                        <div id="divProject" isextend="1">
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/ProjectList.aspx"
                                        target="mainFrame">Setup Projects</a></div>
                            </div>    
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/PourList.aspx"
                                        target="mainFrame">Setup Pours</a></div>
                            </div>    
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/LoggerList.aspx"
                                        target="mainFrame">Setup Loggers</a></div>
                            </div>           
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/ProductList.aspx"
                                        target="mainFrame">Setup Products</a></div>
                            </div>         
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/ContactList.aspx"
                                        target="mainFrame">Setup Contacts</a></div>
                            </div>   
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/DefaultTargetList.aspx"
                                        target="mainFrame">Default Target</a></div>
                            </div>       
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/LevelList.aspx"
                                        target="mainFrame">Set Levels</a></div>
                            </div> 
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/HardwareControl/DashBoardList.aspx"
                                        target="mainFrame">Dash Board</a></div>
                            </div>     
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/LoggerTempList.aspx"
                                        target="mainFrame">Logger Temp</a></div>
                            </div>                                           
                        </div>
                        <div class="home_left_div_title" onclick="ExtendDiv('divBaseInfo');">
                            <img class="img_title" src="Style/Images/Default/pixel.gif" />
                            <font class="font_title">BaseInfo</font>
                        </div>
                        <div id="divBaseInfo" isextend="1">
                            <div class="home_left_div_content">
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href="Module/Projects/CompanyList.aspx"
                                        target="mainFrame">Company</a>
                                </div>
                                <div class="home_left_div_content_item" onmouseover="onChangeMenuItem(this,1)" onmouseout="onChangeMenuItem(this,2)">
                                    <img class="img_content" src="Style/Images/Default/pixel.gif" />
                                    &nbsp;<a style='display: inline-block;' href=""
                                        target="mainFrame">User</a>
                                </div>
                            </div>    
                                              
                        </div>

                    </div>
                    <script type="text/javascript">
                        function fClickTreeIco(obj) {
                            var objChildren = $(obj).next("ul");
                            objChildren.toggleClass("treehid");
                            if ($(obj).has("span.tree-expanded").length) {
                                $(obj).find("span.tree-expanded").attr("class", "tree-collapsed");
                            }
                            else if ($(obj).has("span.tree-collapsed").length) {
                                $(obj).find("span.tree-collapsed").attr("class", "tree-expanded");
                            }
                        }
                        var focusTreeNodeID;
                        function onChangeTreeNode(obj, type) {
                            $(obj).css("background-color", "");
                            var list = $('#divtree').find(".treenodeselected");
                            var obj2;
                            for (var i = 0; i < list.length; i++) {
                                obj2 = list[i];
                            }
                            var IsTrue = true;
                            if (obj2 != undefined) {
                                if ($(obj2).attr("id") == $(obj).attr("id")) {
                                    IsTrue = false;
                                }
                            }
                            if (IsTrue) {
                                if (type == 1) {
                                    $(obj).css("background-color", "#fafafa");
                                }
                            }
                        }
                        function fTreeNodeClick(obj, txtid, txttext, txttype) {
                            focusTreeNodeID = txtid;
                            $(obj).css("background-color", "");
                            var list = $('#divtree').find(".treenodeselected");
                            for (var i = 0; i < list.length; i++) {
                                $(list[i]).removeClass("treenodeselected");
                            }
                            $(obj).addClass("treenodeselected");
                            $('#movetableid').hide();
                            $('#movedivid').hide();
                        }
                        function fClickContextMenu(obj, usercode, username) {
                            fTreeNodeClick(obj, usercode, username)
                            $('#movetableid').show();
                            $('#movedivid').show();
                            mouseMove(event);
                            var user = username + '(' + usercode + ')';
                            $("#hiduserinfo").val(user);
                        }
                        function mousePosition(ev) {
                            if (ev.pageX || ev.pageY) {
                                return { x: ev.pageX, y: ev.pageY };
                            }
                            return {
                                x: ev.clientX + document.body.scrollLeft - document.body.clientLeft,
                                y: ev.clientY + document.body.scrollTop - document.body.clientTop
                            };
                        }
                        function mouseMove(ev) {
                            ev = ev || window.event;
                            var mousePos = mousePosition(ev);
                            $('#movedivid').css('left', mousePos.x);
                            $('#movedivid').css('top', mousePos.y);
                        }
                        function Mouseout() {
                            $('#movetableid').hide();
                            $('#movedivid').hide();
                        } 
                    </script>
                </div>
                <div id="divMenu" class="leftcontent contenthid">
                    <div id="divLeftMenu">
                    </div>
                </div>
                <div class="dl_bottom">
                </div>
            </td>
            <td style="width: 5px;">
                <div>
                </div>
            </td>
            <td id="tdcontent" class="tdcontent">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr style="height: 4px">
                        <td style="width: 6px; background-image: url('Style/Images/Default/home_top_left.jpg')">
                        </td>
                        <td style="background-image: url('Style/Images/Default/home_top_center.jpg')">
                        </td>
                        <td style="width: 6px; background-image: url('Style/Images/Default/home_top_right.jpg')">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 6px; background-image: url('Style/Images/Default/home_middle_left.jpg')">
                        </td>
                        <td id="tdContent">
                            <!-- 处理内容/star -->
                            <iframe id="mainFrame" name="mainFrame" src="" frameborder="0" scrolling="auto" style="width: 100%;
                                height: 550px;"></iframe>
                            <!-- 处理内容/end -->
                        </td>
                        <td style="width: 6px; background-image: url('Style/Images/Default/home_middle_right.jpg')">
                        </td>
                    </tr>
                    <tr style="height: 4px">
                        <td style="width: 6px; background-image: url('Style/Images/Default/home_bottom_left.jpg')">
                        </td>
                        <td style="background-image: url('Style/Images/Default/home_bottom_center.jpg')">
                        </td>
                        <td style="width: 6px; background-image: url('Style/Images/Default/home_bottom_right.jpg')">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 4px;">
                <div>
                </div>
            </td>
        </tr>
    </table>
    <div class="homepagebottom">
        CopyRight &copy; HMI Technology
    </div>
</body>
</html>
