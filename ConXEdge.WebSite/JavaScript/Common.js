/*
    /// <summary>
    /// 功能：脚本操作的一样公用方法
    /// 作者：许永明
    /// 日期：2011-12-07
    /// 修改：
    /// </summary>
*/
//根据参数返回值
function fGetUrlParam(param) {
    var sSerach = window.location.search;
    var st = '\?';
    sSerach = sSerach.replace(st, "");
    var sTemps = sSerach.split("&");
    if (sTemps.length) {
        for (var i = 0; i < sTemps.length; i++) {
            if (sTemps[i].split('=')[0] == param) {
                return sTemps[i].split('=')[1];
            }
        }
    }
    return "";
}