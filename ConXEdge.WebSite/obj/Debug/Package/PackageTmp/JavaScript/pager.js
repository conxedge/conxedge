(function ($) {
    // 分页控件应用
    /*三个初始化参数：调用时应用以下三个隐藏控件。
    当前页码：<input name="hf_CurrentPage" type="hidden" value="<%=iCurrentpage %>" />
    总共数量： <input name="hf_ItemsNumber" type="hidden" value="<%=iItemsNumber %>" />
    每页个数： <input name="hf_iPageSize" type="hidden" value="<%=iPageSize %>" />
    */


    $.fn.pagination = function (callfunction,pIndex,pSize,pCount,vID) {
        var c_page = pIndex;
        var pagesize = pSize;
        var pagecount = pCount;
        opts = new Object();
        opts = $.extend({
            pageDiv_id: vID,
            current_page: c_page ? Number(c_page) : 1,
            items_Count: pagecount ? Number(pagecount) : 0,
            link_to: "javascript:void(0);",
            first_text: "首页",
            prev_text: "上一页",
            next_text: "下一页",
            last_text: "最后一页",
            first_show_always: true,
            prev_show_always: true,
            next_show_always: true,
            last_show_always: true,
            callback: (callfunction ? callfunction : pageselectCallback)
        }, opts || {});
        maxentries = Math.ceil(pagecount / pagesize);
        maxentries = (!maxentries || maxentries < 0) ? 1 : maxentries;
        var containers = this, links;
        //获取控件页码显示
        function getDiv(current_page) {
            var RDiv = $("<div class='t1_r'></div>");
            RDiv.append("页码：");
            var lbCur = $('<span  >' + current_page + '</span>');
            RDiv.append(lbCur);
            RDiv.append("/");
            var lbpage = $('<span >' + maxentries + '</span>');
            RDiv.append(lbpage);
            RDiv.append("&nbsp;&nbsp;共");
            var lbItem = $('<span   style=\"color:red;\">' + opts.items_Count + '</span>');
            RDiv.append(lbItem);
            RDiv.append("条&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;");
            RDiv.append($('<input   type="text" id="' + opts.pageDiv_id + '"  style="width: 40px; height:18px;"/>'));
            RDiv.append("&nbsp;页&nbsp;&nbsp;&nbsp;&nbsp;");
            var pbtn = $('<a href=\"javascript:\" id="btn_pagination">跳转</a>');
            pbtn.bind("click", function () {
                new_current_page = $("#" + opts.pageDiv_id).val();
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
        function createLink(page_id, current_page, appendopts) {
            var lnk;
            page_id = page_id < 1 ? 1 : (page_id < maxentries ? page_id : maxentries); // Normalize page id to sane value
            if (page_id == current_page) {
                lnk = $("<span class='current'>" + appendopts.text + "</span>");
            }
            else {
                lnk = $("<a>" + appendopts.text + "</a>").attr('href', opts.link_to.replace(/__id__/, page_id));
            }
            if (appendopts.classes) { lnk.addClass(appendopts.classes); }
            lnk.data('page_id', page_id);
            return lnk;
        }
        //
        function getLinks(current_page, eventHandler) {
            fragment = $("<div class=\"t1_b\"></div>");
            Tmp = $("<div class=\"t1_l\"></div>");
            if (opts.first_text && opts.first_show_always) {
                Tmp.append(createLink(0, current_page, { text: opts.first_text }));
                Tmp.append("&nbsp;");
            }
            if (opts.prev_text && (current_page > 0 || opts.prev_show_always)) {
                Tmp.append(createLink(current_page - 1, current_page, { text: opts.prev_text }));
                Tmp.append("&nbsp;");
            }
            if (opts.next_text && (current_page > 0 || opts.next_show_always)) {

                Tmp.append(createLink(current_page + 1, current_page, { text: opts.next_text }));
                Tmp.append("&nbsp;");
            }
            if (opts.last_text && opts.last_show_always) {
                Tmp.append(createLink(maxentries, current_page, { text: opts.last_text }));
            }
            $('a', Tmp).click(eventHandler);

            fragment.append(Tmp);
            fragment.append(getDiv(current_page));
            return fragment;
        }

        function selectPage(new_current_page) {
            // update the link display of a all containers
            containers.data('current_page', new_current_page);
            links = getLinks(new_current_page, paginationClickHandler);
            containers.empty();
            links.appendTo(containers);
           
           // return continuePropagation;
        }
        function paginationClickHandler(evt) {

            var new_current_page = $(evt.target).data('page_id');
            // call the callback and propagate the event if it does not return false
            var continuePropagation = opts.callback(new_current_page);
           // continuePropagation = selectPage(new_current_page);
            if (!continuePropagation) {
                evt.stopPropagation();
            }
            return continuePropagation;
        }
        containers.empty();
        links = getLinks(opts.current_page, paginationClickHandler);
        links.appendTo(containers);
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
})(jQuery);


