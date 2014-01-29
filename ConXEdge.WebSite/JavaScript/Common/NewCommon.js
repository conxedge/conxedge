//新添加的通用方法
function NewCommon() {
    //显示日期时间星期
    //objID：显示用的控件ID
    this.ShowTime = function (objID) {
        var NewDate = new Date();
        var Year = NewDate.getYear();
        var Month = NewDate.getMonth() + 1;
        var DayS = NewDate.getDate();
        var Hour = NewDate.getHours();
        var Minute = NewDate.getMinutes();
        var Second = NewDate.getSeconds();
        var Xday;
        var ShowStr;

        if (navigator.userAgent.indexOf("MSIE") == -1)
            Year = 1900 + Year;

        switch (NewDate.getDay()) {
            case 0: Xday = "星期日";
                break;
            case 1: Xday = "星期一";
                break;
            case 2: Xday = "星期二";
                break;
            case 3: Xday = "星期三";
                break;
            case 4: Xday = "星期四";
                break;
            case 5: Xday = "星期五";
                break;
            case 6: Xday = "星期六";
                break;
        }

        if (Month < 10)
            Month = "0" + Month;

        if (DayS < 10)
            DayS = "0" + DayS;

        if (Hour < 10)
            Hour = "0" + Hour;

        if (Minute < 10)
            Minute = "0" + Minute;

        if (Second < 10)
            Second = "0" + Second;

        ShowStr = Year + "年" + Month + "月" + DayS + "日";
        ShowStr += "  " + Xday + "  ";
        ShowStr += Hour + ":" + Minute + ":" + Second;

        $("#" + objID).html(ShowStr);
    }
    //格式化小数
    //strStr：值
    //nAfterDot：小数位数
    this.FormatNumber = function (srcStr, nAfterDot) {
        var srcStr, nAfterDot;
        var resultStr, nTen;
        srcStr = "" + srcStr + "";
        strLen = srcStr.length;
        dotPos = srcStr.indexOf(".", 0);
        if (dotPos == -1) {
            resultStr = srcStr + ".";
            for (i = 0; i < nAfterDot; i++) {
                resultStr = resultStr + "0";
            }
            return resultStr;
        }
        else {
            if ((strLen - dotPos - 1) >= nAfterDot) {
                nAfter = dotPos + nAfterDot + 1;
                nTen = 1;
                for (j = 0; j < nAfterDot; j++) {
                    nTen = nTen * 10;
                }
                resultStr = Math.round(parseFloat(srcStr) * nTen) / nTen;
                return resultStr;
            }
            else {
                resultStr = srcStr;
                for (i = 0; i < (nAfterDot - strLen + dotPos + 1); i++) {
                    resultStr = resultStr + "0";
                }
                return resultStr;
            }
        }
    }

    //判断字符串长度是否在规定范围内
    //str：字符串
    //minlen：最小长度
    //maxlen：最大长度
    //返回值：true在范围内，false不在
    this.checkByteLength = function (str, minlen, maxlen) {
        if (str == null) return false;
        var l = str.length;
        var blen = 0;
        for (i = 0; i < l; i++) {
            if ((str.charCodeAt(i) & 0xff00) != 0) {
                blen++;
            }
            blen++;
        }
        if (blen > maxlen || blen < minlen) {
            return false;
        }
        return true;
    }

    //判断是否是整数
    this.checkInt = function (str) {
        var r = /^\+?[1-9][0-9]*$/; //正整数 
        if (r.test(str))
            return true;
        else
            return false;
    }

    /**  
    * 检查是否为电子邮件  
    *  
    * @param {}  
    *            str  
    * @return {boolean} true：电子邮件，false:<b>不是</b>电子邮件;  
    */
    this.checkEmail = function (str) {
        var re = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
        return re.test(str);
    }  

    //获取url参数值
    //param：参数名称
    this.getParameter = function (param) {
        var query = window.location.search;
        var iLen = param.length;
        var iStart = query.indexOf(param);
        if (iStart == -1)
            return "";
        iStart += iLen + 1;
        var iEnd = query.indexOf("&", iStart);
        if (iEnd == -1)
            return query.substring(iStart);

        return query.substring(iStart, iEnd);
    }

    ///////////////////////根据金额获取大写字符串////////////////////
    this.MoneyToChinese = function (dValue, maxDec) {
        // 验证输入金额数值或数值字符串：
        dValue = dValue.toString().replace(/,/g, ""); dValue = dValue.replace(/^0+/, "");      // 金额数值转字符、移除逗号、移除前导零
        if (dValue == "") { return "零元整"; }      // （错误：金额为空！）
        else if (isNaN(dValue)) { return "错误：金额不是合法的数值！"; }

        var minus = "";                             // 负数的符号“-”的大写：“负”字。可自定义字符，如“（负）”。
        var CN_SYMBOL = "";                         // 币种名称（如“人民币”，默认空）
        if (dValue.length > 1) {
            if (dValue.indexOf('-') == 0) { dValue = dValue.replace("-", ""); minus = "负"; }   // 处理负数符号“-”
            if (dValue.indexOf('+') == 0) { dValue = dValue.replace("+", ""); }                 // 处理前导正数符号“+”（无实际意义）
        }

        // 变量定义：
        var vInt = ""; var vDec = "";               // 字符串：金额的整数部分、小数部分
        var resAIW;                                 // 字符串：要输出的结果
        var parts;                                  // 数组（整数部分.小数部分），length=1时则仅为整数。
        var digits, radices, bigRadices, decimals;  // 数组：数字（0~9——零~玖）；基（十进制记数系统中每个数字位的基是10——拾,佰,仟）；大基（万,亿,兆,京,垓,杼,穰,沟,涧,正）；辅币（元以下，角/分/厘/毫/丝）。
        var zeroCount;                              // 零计数
        var i, p, d;                                // 循环因子；前一位数字；当前位数字。
        var quotient, modulus;                      // 整数部分计算用：商数、模数。

        // 金额数值转换为字符，分割整数部分和小数部分：整数、小数分开来搞（小数部分有可能四舍五入后对整数部分有进位）。
        var NoneDecLen = (typeof (maxDec) == "undefined" || maxDec == null || Number(maxDec) < 0 || Number(maxDec) > 5);     // 是否未指定有效小数位（true/false）
        parts = dValue.split('.');                      // 数组赋值：（整数部分.小数部分），Array的length=1则仅为整数。
        if (parts.length > 1) {
            vInt = parts[0]; vDec = parts[1];           // 变量赋值：金额的整数部分、小数部分

            if (NoneDecLen) { maxDec = vDec.length > 5 ? 5 : vDec.length; }                                  // 未指定有效小数位参数值时，自动取实际小数位长但不超5。
            var rDec = Number("0." + vDec);
            rDec *= Math.pow(10, maxDec); rDec = Math.round(Math.abs(rDec)); rDec /= Math.pow(10, maxDec);  // 小数四舍五入
            var aIntDec = rDec.toString().split('.');
            if (Number(aIntDec[0]) == 1) { vInt = (Number(vInt) + 1).toString(); }                           // 小数部分四舍五入后有可能向整数部分的个位进位（值1）
            if (aIntDec.length > 1) { vDec = aIntDec[1]; } else { vDec = ""; }
        }
        else { vInt = dValue; vDec = ""; if (NoneDecLen) { maxDec = 0; } }
        if (vInt.length > 44) { return "错误：金额值太大了！整数位长【" + vInt.length.toString() + "】超过了上限——44位/千正/10^43（注：1正=1万涧=1亿亿亿亿亿，10^40）！"; }

        // 准备各字符数组 Prepare the characters corresponding to the digits:
        digits = new Array("零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖");         // 零~玖
        radices = new Array("", "拾", "佰", "仟");                                              // 拾,佰,仟
        bigRadices = new Array("", "万", "亿", "兆", "京", "垓", "杼", "穰", "沟", "涧", "正"); // 万,亿,兆,京,垓,杼,穰,沟,涧,正
        decimals = new Array("角", "分", "厘", "毫", "丝");                                     // 角/分/厘/毫/丝

        resAIW = "";  // 开始处理

        // 处理整数部分（如果有）
        if (Number(vInt) > 0) {
            zeroCount = 0;
            for (i = 0; i < vInt.length; i++) {
                p = vInt.length - i - 1; d = vInt.substr(i, 1); quotient = p / 4; modulus = p % 4;
                if (d == "0") { zeroCount++; }
                else {
                    if (zeroCount > 0) { resAIW += digits[0]; }
                    zeroCount = 0; resAIW += digits[Number(d)] + radices[modulus];
                }
                if (modulus == 0 && zeroCount < 4) { resAIW += bigRadices[quotient]; }
            }
            resAIW += "元";
        }

        // 处理小数部分（如果有）
        for (i = 0; i < vDec.length; i++) { d = vDec.substr(i, 1); if (d != "0") { resAIW += digits[Number(d)] + decimals[i]; } }

        // 处理结果
        if (resAIW == "") { resAIW = "零" + "元"; }     // 零元
        if (vDec == "") { resAIW += "整"; }             // ...元整
        resAIW = CN_SYMBOL + minus + resAIW;            // 人民币/负......元角分/整
        return resAIW;
    }

    this.atrand = function () {
        return Math.floor(Math.random() * 100000000) + 1;
    }

    this.newGuid = function () {
        var guid = "";
        for (var i = 1; i <= 32; i++) {
            var n = Math.floor(Math.random() * 16.0).toString(16);
            guid += n;
            if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                guid += "-";
        }
        return guid;
    }

    //数组中移除一项
    this.Array_RemoveItem = function (ay, item) {
        var tmpArray = new Array();

        for (var i = 0; i < ay.length; i++) {
            if (ay[i] != item) tmpArray.push(ay[i]);
        }
        return tmpArray;
    }

    //将数组组合成字符串
    this.AyyayToString = function (ay, sp) {
        var result = "";
        for (var i = 0; i < ay.length; i++) {
            result += ay[i].replace(sp, "") + sp;
        }
        if (result != "")
            result = result.substring(0, result.length - 1);
        return result;
    }

    //列表鼠标事件
    this.listChangeItem=function(control, type) {
        $(control).find("td").each(function () {
            if (type == 1) {
                $(this).css("background-color", "#FFFCD0");
            }
            else {
                $(this).css("background-color", "#ffffff");
            }
        });
    }

    //列表鼠标事件
    this.listChangeSpItem = function (control, type) {
        $(control).find("td").each(function () {
            if (type == 1) {
                $(this).css("background-color", "#FFFCD0");
            }
            else {
                $(this).css("background-color", "#FAFDFF");
            }
        });
    }

    this.pfSelectAll = function (cboxAllID) {
        $("input[type='checkbox']").not("#" + cboxAllID).each(function () {
            $(this).attr("checked", $("#" + cboxAllID).attr("checked"));
        });
    }

    this.pfValidEdit = function (cboxAllID) {
        if ($("input[type='checkbox']:checked").not("#" + cboxAllID).size() == 1)
            return true;
        else
            return false;
    }

    this.pfValidDel = function (cboxAllID) {
        if ($("input[type='checkbox']:checked").not("#" + cboxAllID).size() > 0)
            return true;
        else
            return false;
    }
}

var newCommon=new NewCommon();