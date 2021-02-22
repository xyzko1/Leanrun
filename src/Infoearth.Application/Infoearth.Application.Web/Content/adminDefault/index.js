﻿$.fn.Tab = function (options) {
    var cfg = {
        items: [],
        width: 500,
        height: 500,
        tabcontentWidth: 498,
        tabWidth: 100,
        tabHeight: 32,
        tabScroll: true,
        tabScrollWidth: 19,
        tabClass: 'tab',
        tabContentClass: 'tab-div-content',
        tabClassOn: 'on',
        tabClassOff: 'off',
        tabClassClose: 'tab_close',
        tabClassInner: 'inner',
        tabClassInnerLeft: 'innerLeft',
        tabClassInnerMiddle: 'innerMiddle',
        tabClassInnerRight: 'innerRight',
        tabClassText: 'text',
        tabClassScrollLeft: 'scroll-left',
        tabClassScrollRight: 'scroll-right',
        tabClassDiv: 'tab-div',
        addEvent: null,
        currentEvent: null
    };
    //默认显示第一个li
    var displayLINum = 0;
    $.extend(cfg, options);
    //判断是不是有隐藏的tab
    var tW = cfg.tabWidth * cfg.items.length;
    cfg.tabScroll ? tW -= cfg.tabScrollWidth * 2 : null;
    //tabDiv,该div是自动增加的
    var tab = $('<div />').attr('id', 'jquery_tab_div').height(cfg.tabHeight).addClass(cfg.tabClass).append('<ul />');
    //tab target content
    var tabContent = $('<div />').attr('id', 'jquery_tab_div_content').width(cfg.tabcontentWidth).height(cfg.height - cfg.tabHeight).addClass(cfg.tabContentClass);
    var ccW = (cfg.items.length * cfg.tabWidth) - cfg.width;
    var tabH = '';
    //增加一个tab下的li得模板
    var tabTemplate = '';
    tabTemplate = '<table class="' + cfg.tabClassInner + '"  id="{0}" data-value="{3}" border="0" cellpadding="0" cellspacing="0"><tr>' + '<td class="' + cfg.tabClassInnerLeft + '"></td>'
			+ '<td class="' + cfg.tabClassInnerMiddle + '"><span class="' + cfg.tabClassText + '"><i class="fa {2}"></i>&nbsp;{1}</span></td>' + '<td class="' + cfg.tabClassInnerMiddle + '"><div class="' + cfg.tabClassClose + ' ' + cfg.tabClassClose + '_noselected"></div></td>' + '<td class="' + cfg.tabClassInnerRight + '"></td>'
			+ '</tr></table>';
    var scrollTab = function (o, flag) {
        //当前的left
        var displayWidth = Number(tab.css('left').replace('px', ''));
        !displayWidth ? displayWidth = 0 : null;
        //显示第几个LI
        var displayNum = 0;
        var DW = 0;
        var left = 0;
        if (flag && displayWidth == 0) {
            return;
        }
        if (flag) {
            displayLINum--;
            left = displayWidth + tab.find('li').eq(displayLINum).width();
            left > 0 ? left = 0 : null;
        } else {
            var _rigth = $(".tab ul").width() - parseInt(tab.offset().left) * -1 - cfg.tabcontentWidth - 82;
            var _step = tab.find('li').eq(displayLINum).width();
            if (_rigth > 0) {
                if (_rigth < _step) {
                    _step = _rigth;
                }
            } else {
                return;
            }
            left = displayWidth - _step;
            displayLINum++;
        }
        if (left == 0) {
            tab.animate({ 'left': parseInt(-19) });
        } else {
            tab.animate({ 'left': parseInt(left) });
        }
    }
    function removeTab(item) {
        tab.find("#" + item.id).parents('li').remove();
        tabContent.find('#iframe' + item.id).remove();
    }
    function addTab(item) {
        if (item == null)
        {
            return false;
        }
        if (item.replace == true) {
            removeTab(item);
        }
        if (tab.find("#" + item.id).length == 0) {
            learun.loading({ isShow: true });
            var innerString = tabTemplate.replace("{0}", item.id).replace("{1}", item.title).replace("{2}", item.icon).replace("{3}", item.dataValue);
            var liObj = $('<li class="off"></li>');
            liObj.append(innerString).appendTo(tab.find('ul')).find('table td:eq(1)').click(function () {
                liObj.contextmenu();
                //判断当前是不是处于激活状态
                if (liObj.hasClass(cfg.tabClassOn)) return;

                var activeLi = liObj.parent().find('li.' + cfg.tabClassOn);
                activeLi.removeClass().addClass(cfg.tabClassOff);

                $(this).next().find('div').removeClass().addClass(cfg.tabClassClose);
                liObj.removeClass().addClass(cfg.tabClassOn);

                tabContent.find('iframe').hide().removeClass(cfg.tabClassOn);
                tabContent.find('#iframe' + liObj.find('table').attr('id')).show().addClass(cfg.tabClassOn);
                cfg.currentEvent(liObj.find('.inner').attr('data-value'));
            })
            if (item.url) {
                var $iframe = $("<iframe class=\"LRADMS_iframe\" id=\"iframe" + item.id + "\" height=\"100%\" width=\"100%\" src=\"" + item.url + "\" frameBorder=\"0\"></iframe>")
                tabContent.append($iframe);
                var $footerTest = $("<div id=\"foot\" style=\"position: fixed; bottom: 0px; color: #fff; background-color: #2c3849;width:100%; margin-right: 2px; \"><div class=\"footer\" style=\"width:100%;\"><div style=\"float: left; width: 30%;\">&nbsp;技术支持：<a href=\" \" target=\"_blank\" style=\"color: white;\">武汉地大信息工程股份有限公司</a></div><div style=\"float: left; width: 40%; text-align: center;\"> Copyright © 2017 By Infoearth</div><div style=\"float: left; width: 30%; text-align: right;\"><i id=\"btn_message\" class=\"fa fa-comments\" title=\"消息通知\" style=\"width: 30px; font-size: 22px; vertical-align: middle; cursor: pointer;margin-top:-1px;margin-right:5px;display:none;\"></i></div></div></div>");
                tabContent.append($footerTest);
                $iframe.load(function () {
                    window.setTimeout(function () {
                        learun.loading({ isShow: false });
                    }, 200);
                });
            }
            if (item.closed) {
                liObj.find('td:eq(2)').find('div').click(function () {
                    var li_index = tab.find('li').length;
                    removeTab(item);
                    tab.find('li:eq(' + (li_index - 2) + ')').find('table td:eq(1)').trigger("click");
                }).hover(function () {
                    if (liObj.hasClass(cfg.tabClassOn)) return;
                    $(this).removeClass().addClass(cfg.tabClassClose);
                }, function () {
                    if (liObj.hasClass(cfg.tabClassOn)) return;
                    $(this).addClass(cfg.tabClassClose + '_noselected');
                });
            }
            else {
                liObj.find('td:eq(2)').html('');
            }
            tab.find('li:eq(' + (tab.find('li').length - 1) + ')').find('table td:eq(1)').trigger("click");
            cfg.addEvent(item);
        } else {
            tab.find('li').removeClass('on').addClass('off');
            tab.find("#" + item.id).parent().removeClass('off').addClass('on');
            tabContent.find('iframe').hide().removeClass('on');
            tabContent.find('#iframe' + item.id).show().addClass('on');
        }
    }
    function newTab(item) {
        if ($(".tab ul>li").length >= 10) {
            dialogAlert("为保证系统效率,只允许同时运行10个功能窗口,请关闭一些窗口后重试！", 0);
            return false;
        }
        if (item.moduleIdCookie == true) {
            top.$.cookie('currentmoduleId', item.id, { path: "/" });
            item.dataValue = item.id;
        }
        else {
            item.dataValue = top.$.cookie('currentmoduleId');
        }
        addTab(item);
        var nW = $(".tab ul").width() - 4;
        if (nW > cfg.width) {
            if (!cfg.tabScroll) {
                cfg.tabScroll = true;
                scrollLeft = $('<div class="' + cfg.tabClassScrollLeft + '"><i></i></div>').click(function () {
                    scrollTab(scrollLeft, true);
                });
                srcollRight = $('<div class="' + cfg.tabClassScrollRight + '"><i></i></div>').click(function () {
                    scrollTab(srcollRight, false);
                });
                cW -= cfg.tabScrollWidth * 2;
                tabContenter.width(cW);
                scrollLeft.insertBefore(tabContenter);
                srcollRight.insertBefore(tabContenter);
            }
            var _left = cfg.width - nW;
            tab.animate({ 'left': _left - 43 });
            displaylicount = tab.find('li').length;
        }
    }
    $.each(cfg.items, function (i, item) {
        addTab(item);
    });
    var scrollLeft, srcollRight;
    if (cfg.tabScroll) {
        scrollLeft = $('<div class="' + cfg.tabClassScrollLeft + '"><i></i></div>').click(function () {
            scrollTab($(this), true);
        });
        srcollRight = $('<div class="' + cfg.tabClassScrollRight + '"><i></i></div>').click(function () {
            scrollTab($(this), false);
        });
        cfg.width -= cfg.tabScrollWidth * 2;
    }
    var container = $('<div />').css({
        'position': 'relative',
        'width': cfg.width,
        'height': cfg.tabHeight
    }).append(scrollLeft).append(srcollRight).addClass(cfg.tabClassDiv);
    var tabContenter = $('<div />').css({
        'width': cfg.width,
        'height': cfg.tabHeight,
        'float': 'left'
    }).append(tab);
    var obj = $(this).append(tabH).append(container.append(tabContenter)).append(tabContent);
    $(window).resize(function () {
        cfg.width = $(window).width() - 100;
        cfg.height = $(window).height() - 76;
        cfg.tabcontentWidth = $(window).width() - 80;
        container.width(cfg.width);
        tabContent.width(cfg.tabcontentWidth).height(cfg.height - cfg.tabHeight);
    });
    //点击第一
    tab.find('li:first td:eq(1)').click();
    return obj.extend({ 'addTab': addTab, 'newTab': newTab });
};
//初始化导航
var tablist;
loadnav = function () {
    var navJson = {};
    tablist = $("#tab_list_add").Tab({
        items: [
            { id: 'desktop', title: '欢迎首页', closed: false, icon: 'fa fa fa-desktop', url: contentPath + '/Home/AdminDefaultDesktop' },
        ],
        tabScroll: false,
        width: $(window).width() - 100,
        height: $(window).height() - 76,
        tabcontentWidth: $(window).width() - 80,
        addEvent: function (item) {
            if (item.closed && item.isNoLog != true) {
                $.ajax({
                    url: contentPath + "/Home/VisitModule",
                    data: { moduleId: item.id, moduleName: item.title, moduleUrl: item.url },
                    type: "post",
                    dataType: "text"
                });
            }
        },
        currentEvent: function (moduleId) {
            top.$.cookie('currentmoduleId', moduleId, { path: "/" });
        }
    });
    //个人中心
    $("#GoToHome").click(function () {
        tablist.newTab({ id: 'desktop', title: '欢迎首页', closed: false, icon: 'fa fa fa-desktop', url: contentPath + '/Home/AdminDefaultDesktop' });
    });
    //个人中心
    $("#UserSetting").click(function () {
        tablist.newTab({ id: "UserSetting", title: "个人中心", closed: true, icon: "fa fa fa-user", url: contentPath + "/PersonCenter/Index" });
    });
    //动态加载导航菜单
    var _html = "";
    var index = 0;
    var _authorizeMenuData = learun.data.get(["authorizeMenu"]);
    $.each(_authorizeMenuData, function (i, row) {
        if (row.F_ParentId == '0') {
            index++;
            _html += '<li class="item">';
            _html += '    <a id=' + row.F_ModuleId + '  href="javascript:void(0);" class="main-nav">';
            _html += '        <div class="main-nav-icon"><i class="fa ' + row.F_Icon + '"></i></div>';
            _html += '        <div class="main-nav-text">' + row.F_FullName + '</div>';
            _html += '        <span class="arrow"></span>';
            _html += '    </a>';
            _html += getsubnav(row.F_ModuleId);
            _html += '</li>';
            navJson[row.F_ModuleId] = row;
        }
    });
    $("#nav").append(_html);
    $('#nav li a').click(function () {
        var id = $(this).attr('id');
        var data = navJson[id];
        if (data.F_Target == "iframe") {
            tablist.newTab({ moduleIdCookie: true, id: id, title: data.F_FullName, closed: true, icon: data.F_Icon, url: contentPath + data.F_UrlAddress });
        }
    })
    $("#nav li.item").hover(function (e) {
        $('#navDiv').width(4000);
        var $sub = $(this).find('.sub-nav-wrap');
        var length = $sub.find('.sub-nav').find('li').length;
        if (length > 0) {
            $sub.css('bottom', 'initial');
            $(this).addClass('on');
            $sub.show();
            
            var sub_top = $sub.offset().top + $sub.height();
            var body_height = $(window).height();
            if (sub_top > body_height) {
                $sub.css('bottom', '0px');
            }
        }
    }, function (e) {
        $('#navDiv').width(80);
        $(this).removeClass('on');
        $(this).find('.sub-nav-wrap').hide();
    });
    $("#nav li.sub").hover(function (e) {
        var $ul = $(this).find('ul');
        $ul.show();
        var top = $(this).find('ul').offset().top;
        var height = $ul.height();
        var wheight = $(window).height();
        if (top + height > wheight) {
            $ul.css('top', parseInt('-' + (height - 11))).css('left', '130px')
        } else {
            $ul.css('top', '0px').css('left', '130px');
        }
    }, function (e) {
        $(this).find('ul').hide();
        $(this).find('ul').css('top', '0px');
    });
    //导航二菜单
    function getsubnav(moduleId) {
        var _html = '<div class="sub-nav-wrap">';
        _html += '<ul class="sub-nav">';
        var _authorizeMenuData = learun.data.get(["authorizeMenu"]);
        $.each(_authorizeMenuData, function (i,row) {
            if (row.F_ParentId == moduleId) {
                if (isbelowmenu(row.F_ModuleId) == 0) {
                    _html += '<li><a id=' + row.F_ModuleId + '><i class="fa ' + row.F_Icon + '"></i>' + row.F_FullName + '</a></li>';
                } else {
                    _html += '<li class="sub" title=' + (row.F_Description == null ? "" : row.F_Description) + '><a id=' + row.F_ModuleId + '><i class="fa ' + row.F_Icon + '"></i>' + row.F_FullName + '</a>';
                    _html += getchildnav(row.F_ModuleId);
                    _html += '</li>'; //sub
                }
                navJson[row.F_ModuleId] = row;
            }
        });
        _html += '</ul>';
        _html += '</div>';
        return _html;
    }
    //导航三菜单
    function getchildnav(moduleId) {
        var _html = '<div class="sub-child"><ul>';
        var _authorizeMenuData = learun.data.get(["authorizeMenu"]);
        $.each(_authorizeMenuData, function (i, row) {
            if (row.F_ParentId == moduleId) {
                _html += '<li title=' + (row.F_Description == null ? "" : row.F_Description) + '><a id=' + row.F_ModuleId + '><i class="fa ' + row.F_Icon + '"></i>' + row.F_FullName + '</a></li>';
                navJson[row.F_ModuleId] = row;
            }
        });
        _html += '</ul></div>';
        return _html;
    }
    //判断是否有子节点
    function isbelowmenu(moduleId) {
        var count = 0;
        var _authorizeMenuData = learun.data.get(["authorizeMenu"]);
        $.each(_authorizeMenuData, function (i,row) {
            if (row.F_ParentId == moduleId) {
                count++;
                return false;
            }
        });
        return count;
    }
    $(window).resize(function (e) {
        window.setTimeout(function () {
            $('#navDiv').height(($(window).height()));
        }, 200);
        e.stopPropagation();
    });
    $('#navDiv').height(($(window).height()));
}
//安全退出
function IndexOut() {
    learun.dialogConfirm({
        msg:"注：您确定要安全退出本次登录吗？",
        callBack: function (r) {
            if (r) {
                learun.loading({ isShow: true, text: "正在安全退出..." });
                window.setTimeout(function () {
                    $.ajax({
                        url: contentPath + "/Login/OutLogin",
                        type: "post",
                        dataType: "json",
                        success: function (data) {
                            window.location.href = ssoPath + "/Login/SSOClear?BackURL=" + contentWebUrl + "/Home/AdminDefault";
                        }
                    });
                }, 500);
            }
        }
    });
}
//移除Tab
$.removeTab = function (type) {
    var Id = tabiframeId();
    var $tab = $(".tab-div");
    var $tabContent = $(".tab-div-content");
    switch (type) {
        case "reloadCurrent":
            $.currentIframe().learun.reload();
            break;
        case "closeCurrent":
            remove(Id.replace('iframe', ''));
            break;
        case "closeAll":
            $tab.find("div.tab_close").each(function () {
                var id = $(this).parents('.inner').attr('id');
                remove(id);
            });
            break;
        case "closeOther":
            $tab.find("div.tab_close").each(function () {
                var id = $(this).parents('.inner').attr('id');
                if (Id != id) {
                    remove(id);
                }
            });
            break;
        default:
            break;
    }
    function remove(id) {
        var li_index = $tab.find('li').length;
        $tab.find("#" + id).parents('li').remove();
        $tabContent.find('#iframe' + id).remove();
        $tab.find('li:eq(' + (li_index - 2) + ')').find('table td:eq(1)').trigger("click");
    }
}

$(function () {
    learun.init({
        "callBack": function () {
            loadnav();
        },
        "themeType": "1"
    });
});
