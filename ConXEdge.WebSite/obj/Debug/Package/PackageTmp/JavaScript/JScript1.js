

// 分页控件应用
function paginationDiv(pDivID,callfunction, pIndex, pSize, pCount, vID) {
    this.paginationDiv_id = pDivID;
    this.current_page = pIndex ? Number(pIndex) : 1;
    this.pagesize = pSize ? Number(pSize) : 1;
    this.pagecount = pCount ? Number(pCount) : 0;
    this.pageDiv_id = vID;
    this.link_to = "javascript:void(0);";
    this.first_text = "首页";
    this.prev_text = "上一页";
    this.next_text = "下一页";
    this.last_text = "最后一页";
    this.first_show_always = true;
    this.prev_show_always = true;
    this.next_show_always = true;
    this.last_show_always = true;
    this.callback = (callfunction ? callfunction : pageselectCallback);


    this.maxentries = 1;
    var that = this;
    //获取控件页码显示
    this.getDiv=function(current_page) {
        var RDiv = $("<div class='t1_r'></div>");
        RDiv.append("页码：");
        var lbCur = $('<span  >' + that.current_page + '</span>');
        RDiv.append(lbCur);
        RDiv.append("/");
        var lbpage = $('<span >' + that.maxentries + '</span>');
        RDiv.append(lbpage);
        RDiv.append("&nbsp;&nbsp;共");
        var lbItem = $('<span   style=\"color:red;\">' + that.pagecount + '</span>');
        RDiv.append(lbItem);
        RDiv.append("条&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;");
        RDiv.append($('<input   type="text" id="' + that.pageDiv_id + '"  style="width: 40px; height:18px;"/>'));
        RDiv.append("&nbsp;页&nbsp;&nbsp;&nbsp;&nbsp;");
        var pbtn = $('<a href=\"javascript:\" id="btn_pagination">跳转</a>');
        pbtn.bind("click", function () {
            var new_current_page = $("#" + that.pageDiv_id).val();
            var patten = '^[1-9][0-9]*$';
            //验证跳转页面是否合格；
            if (new_current_page.match(patten) == null) {
                alert("页码不能为空，且为非零正整数，请重新输入！");
                return;
            }
            if (new_current_page > maxentries) {
                alert("您输入的页码大于总页数，请重新输入！");
                return;
            }
            selectPage(new_current_page);
        })
        RDiv.append(pbtn);
        return RDiv;
    }
    //创建分页控件
   this.createLink= function(page_id, current_page, appendopts) {
        var lnk;
        page_id = page_id < 1 ? 1 : (page_id < that.maxentries ? page_id : that.maxentries); // Normalize page id to sane value
        if (page_id == current_page) {
            lnk = $("<span class='current'>" + appendopts.text + "</span>");
        }
        else {
            lnk = $("<a href='" + that.link_to + "'>" + appendopts.text + "</a>").click(that.paginationClickHandler);
        }
        if (appendopts.classes) { lnk.addClass(appendopts.classes); }
        lnk.data('page_id', page_id);
        
        return lnk;
    }
    //
    this.getLinks=function(current_page) {
        fragment = $("<div class=\"t1_b\"></div>");
        Tmp = $("<div class=\"t1_l\"></div>");
        if (that.first_text && that.first_show_always) {
            Tmp.append(that.createLink(0, current_page, { text: that.first_text }));
            Tmp.append("&nbsp;");
        }
        if (that.prev_text && (current_page > 0 || that.prev_show_always)) {
            Tmp.append(that.createLink(current_page - 1, current_page, { text: that.prev_text }));
            Tmp.append("&nbsp;");
        }
        if (that.next_text && (current_page > 0 || that.next_show_always)) {

            Tmp.append(that.createLink(current_page + 1, current_page, { text: that.next_text }));
            Tmp.append("&nbsp;");
        }
        if (that.last_text && that.last_show_always) {
            Tmp.append(that.createLink(that.maxentries, current_page, { text: that.last_text }));
        }
        

        fragment.append(Tmp);
        fragment.append(that.getDiv(current_page));
        return fragment;
    }

    this.selectPage=function (new_current_page) {
        // update the link display of a all containers
        $("#" + that.paginationDiv_id).data('current_page', new_current_page);
        var links = that.getLinks(new_current_page);
        $("#" + that.paginationDiv_id).html(links);

        // call the callback and propagate the event if it does not return false
        var continuePropagation = that.callback(new_current_page);
        return continuePropagation;
    }
    this.paginationClickHandler=function (evt) {
        alert(1);
        var new_current_page = $(evt.target).data('page_id');
        continuePropagation = that.selectPage(new_current_page);
        if (!continuePropagation) {
            evt.stopPropagation();
        }
        return continuePropagation;
    }
    this.InitPagination = function (pIndex, pSize, pCount) {
        that.current_page = pIndex ? Number(pIndex) : 1;
        that.pagesize = pSize ? Number(pSize) : 1;
        that.pagecount = pCount ? Number(pCount) : 0;
        var mmm = Math.ceil(pCount / pSize);
        that.maxentries = (!mmm || mmm < 0) ? 1 : mmm;
        that.selectPage(that.current_page);
    }
    
    /*根据字段属性更新新的网址，如网址为http：//.../default.aspx?a=1&b=2&pIndex=1,
    pName="pIndex",
    pValue="2",
    返回值:default.aspx?a=1&b=2&pIndex=2*/
    function getnewurl(pName, pValue) {
        url = location.href;
        //alert(location.href);
        url = (url.indexOf("/") > 0) ? url.substring(url.lastIndexOf("/") + 1, url.length) : url;
        var new_url;
        if (url.indexOf("?") > 0) {
            new_url = url.substring(0, url.indexOf("?") + 1);
            var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
            for (i = 0; j = paraString[i]; i++) {

                if (j.substring(0, j.indexOf("=")).toLowerCase() == pName.toLowerCase()) {
                    paraString.splice(i, 1);
                    continue;
                }
            }

            for (i = 0; j = paraString[i]; i++) {
                new_url += j + "&";
            }
            new_url += pName + "=" + pValue;
        }
        else {
            new_url = url + "?" + pName + "=" + pValue;
        }
        return new_url;
    }

    /**
    回调函数 page_index为当前页面
    */
    function pageselectCallback(page_index) {

        var url = getnewurl("page", page_index);
        //alert(url);
        //window.navigate(url);
        window.location = url;
        return false;
    }
}
