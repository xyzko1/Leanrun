(function ($) {
    tablist = {
        newTab: function (item) {
            var dataId = item.id;
            var dataUrl = item.url;
            var menuName = item.title;
            var flag = true;
            if (dataUrl == undefined || $.trim(dataUrl).length == 0) {
                return false;
            }
            if (dataUrl.indexOf("http://") < 0 && dataUrl.indexOf(contentPath) < 0) {
                dataUrl = contentPath + dataUrl;
            }
            $('.mainContent .LRADMS_iframe').each(function () {
                if ($(this).data('id') == dataUrl) {
                    $(this).show().siblings('.LRADMS_iframe').hide();
                    flag = false;
                    return false;
                }
            });

            if (flag) {
                var str = '<a href="javascript:;" class="active menuTab"  data-id="' + dataUrl + '">' + menuName + ' <i class="fa fa-remove"></i></a>';
                $('.menuTab').removeClass('active');
                var str1 = '<iframe class="LRADMS_iframe" id="iframe' + dataId + '" name="iframe' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless></iframe>';
                $('.mainContent').find('iframe.LRADMS_iframe').hide();
                $('.mainContent').append(str1);
                learun.loading({ isShow: true });
                $('.mainContent iframe:visible').load(function () {
                    learun.loading({ isShow: false });
                });
                $('.menuTabs .page-tabs-content').append(str);
                $.learuntab.scrollToTab($('.menuTab.active'));
            }
        }
    }

    $.learuntab = {
        requestFullScreen: function () {
            var de = document.documentElement;
            if (de.requestFullscreen) {
                de.requestFullscreen();
            } else if (de.mozRequestFullScreen) {
                de.mozRequestFullScreen();
            } else if (de.webkitRequestFullScreen) {
                de.webkitRequestFullScreen();
            }
        },
        exitFullscreen: function () {
            var de = document;
            if (de.exitFullscreen) {
                de.exitFullscreen();
            } else if (de.mozCancelFullScreen) {
                de.mozCancelFullScreen();
            } else if (de.webkitCancelFullScreen) {
                de.webkitCancelFullScreen();
            }
        },
        refreshTab: function () {
            var currentId = $('.page-tabs-content').find('.active').attr('data-id');
            var target = $('.LRADMS_iframe[data-id="' + currentId + '"]');
            var url = target.attr('src');
            learun.loading({ isShow: true });
            target.attr('src', url).load(function () {
                learun.loading({ isShow: false });
            });
        },
        activeTab: function () {
            var currentId = $(this).data('id');
            if (!$(this).hasClass('active')) {
                $('.mainContent .LRADMS_iframe').each(function () {
                    if ($(this).data('id') == currentId) {
                        $(this).show().siblings('.LRADMS_iframe').hide();
                        return false;
                    }
                });
                $(this).addClass('active').siblings('.menuTab').removeClass('active');
                $.learuntab.scrollToTab(this);
            }
            var dataId = $(this).attr('data-value');
            if (dataId != "") {
                top.$.cookie('currentmoduleId', dataId, { path: "/" });
            }
        },
        closeOtherTabs: function () {
            $('.page-tabs-content').children("[data-id]").find('.fa-remove').parents('a').not(".active").each(function () {
                $('.LRADMS_iframe[data-id="' + $(this).data('id') + '"]').remove();
                $(this).remove();
            });
            $('.page-tabs-content').css("margin-left", "0");
        },
        closeTab: function () {
            var closeTabId = $(this).parents('.menuTab').data('id');
            var currentWidth = $(this).parents('.menuTab').width();
            if ($(this).parents('.menuTab').hasClass('active')) {
                if ($(this).parents('.menuTab').next('.menuTab').size()) {

                    var activeId = $(this).parents('.menuTab').next('.menuTab:eq(0)').data('id');

                    $(this).parents('.menuTab').next('.menuTab:eq(0)').addClass('active');

                    $('.mainContent .LRADMS_iframe').each(function () {
                        if ($(this).data('id') == activeId) {
                            $(this).show().siblings('.LRADMS_iframe').hide();
                            return false;
                        }
                    });
                    var marginLeftVal = parseInt($('.page-tabs-content').css('margin-left'));
                    if (marginLeftVal < 0) {
                        $('.page-tabs-content').animate({
                            marginLeft: (marginLeftVal + currentWidth) + 'px'
                        }, "fast");
                    }
                    $(this).parents('.menuTab').remove();
                    $('.mainContent .LRADMS_iframe').each(function () {
                        if ($(this).data('id') == closeTabId) {
                            $(this).remove();
                            return false;
                        }
                    });
                }
                if ($(this).parents('.menuTab').prev('.menuTab').size()) {
                    var activeId = $(this).parents('.menuTab').prev('.menuTab:last').data('id');
                    $(this).parents('.menuTab').prev('.menuTab:last').addClass('active');
                    $('.mainContent .LRADMS_iframe').each(function () {
                        if ($(this).data('id') == activeId) {
                            $(this).show().siblings('.LRADMS_iframe').hide();
                            return false;
                        }
                    });
                    $(this).parents('.menuTab').remove();
                    $('.mainContent .LRADMS_iframe').each(function () {
                        if ($(this).data('id') == closeTabId) {
                            $(this).remove();
                            return false;
                        }
                    });
                }
            }
            else {
                $(this).parents('.menuTab').remove();
                $('.mainContent .LRADMS_iframe').each(function () {
                    if ($(this).data('id') == closeTabId) {
                        $(this).remove();
                        return false;
                    }
                });
                $.learuntab.scrollToTab($('.menuTab.active'));
            }
            var dataId = $('.menuTab.active').attr('data-value');
            if (dataId != "") {
                top.$.cookie('currentmoduleId', dataId, { path: "/" });
            }
            return false;
        },
        findParentText: function (parentId) {
            var topMeunIds = top.learun.data.get(["topMeunParentIds"]);
            if (parentId == undefined || $.inArray(parentId, topMeunIds) >= 0) {
                return "";
            };
            var data = top.learun.data.get(["authorizeMenu"]);

            var text = "";
            var isEnd = true;
            while (isEnd) {
                var parent = $.learunindex.jsonWhere(data, function (v) { return v.F_ModuleId == parentId });
                if (parent && parent.length > 0) {
                    text = ">>" + parent[0].F_FullName + text;
                    if ($.inArray(parent[0].F_ParentId, topMeunIds) >= 0) {
                        isEnd = false;
                    } else {
                        parentId = parent[0].F_ParentId;
                    }
                }
            }
            var textStr = text.substr(2);
            return textStr;
        },
        addTab: function (tag) {
            $(".navbar-custom-menu>ul>li.open").removeClass("open");
            var dataId = $(tag).attr('data-id');
            var dataParentId = $(tag).attr('data-parent-id');
            var parentText = $.learuntab.findParentText(dataParentId);
            var icon_classname = $(tag).children("i").attr("class");
            if (dataId != "") {
                top.$.cookie('currentmoduleId', dataId, { path: "/" });
            }
            var dataUrl = $(tag).attr('data-href');
            var menuName = $.trim($(tag).text());
            var flag = true;
            if (dataUrl == undefined || $.trim(dataUrl).length == 0) {
                return false;
            }
            if (dataUrl.indexOf("http://") < 0 && dataUrl.indexOf(contentPath) < 0) {
                dataUrl = contentPath + dataUrl;
            }

            //是否新窗口打开
            var dataTarget = $(tag).attr('data-target');
            if (dataTarget !== "iframe" && dataUrl !== "/Home/AdminWaterDesktop") {//新窗口打开
                window.open(dataUrl);
                return false;
            } else {//iframe打开
                $('.mainContent .LRADMS_iframe').each(function () {
                    if ($(this).data('id') == dataUrl) {
                        $(this).show().siblings('.LRADMS_iframe').hide();
                        flag = false;
                        return false;
                    };
                });
            };

            var str = "";
            if (parentText) {
                str = '<a href="javascript:;" style="height:39px;" class="active menuTab" data-value=' + dataId + ' data-id="' + dataUrl + '">' + '<span style="color:#3C3C3C">' + parentText + '>></span><span>' + menuName + '</span></a>';
            } else {
                str = '<a href="javascript:;" style="height:39px;" class="active menuTab" data-value=' + dataId + ' data-id="' + dataUrl + '"><span>' + menuName + '</span></a>';
            }
            $('.menuTabs .page-tabs-content').html(str);
            if (flag) {
                $('.menuTab').removeClass('active');
                //限制tab选项打开的个数
                var childNodes = $('.content-iframe .mainContent').children();
                if (childNodes.length < 1000) {
                    $.learuntab.scrollToTab($('.menuTab.active'));
                } else {
                    learun.dialogMsg({ msg: '您打开的tab页过多,请先关闭其它选项后再操作！', type: 0 });
                    return;
                }
                var str1 = '<iframe class="LRADMS_iframe" id="iframe' + dataId + '" name="iframe' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless></iframe>';
                $('.mainContent').find('iframe.LRADMS_iframe').hide();
                $('.mainContent').append(str1);
                //learun.loading({ isShow: true });
                //$('.mainContent iframe:visible').load(function () {
                //    learun.loading({ isShow: false });
                //});
                $.learuntab.addEvent({ id: dataId, title: menuName, closed: true, icon: icon_classname, url: dataUrl });
            }
            var test = $('.content-tabs').is('show');
            if (tag.dataset.parentId == "0") {
                if (test) {
                    $('.roll-left').show();
                    //if ($('.page-tabs a')[0] != undefined) {
                    //    $('.page-tabs a').css("padding-left", "50px");
                    //}
                } else {
                    $('.roll-left').hide();
                    //if ($('.page-tabs a')[0] != undefined) {
                    //    $('.page-tabs a').css("padding-left", "5px");
                    //}
                }
            }
            if (tag.className == "menuItem menuiframe") {
                $('.roll-left').hide();
                if ($('.page-tabs a')[0] != undefined) {
                    $('.page-tabs a').css("padding-left", "5px");
                }
            } else {
                if (tag.dataset.parentId == "0") {
                    if (test) {
                        $('.roll-left').show();
                        //if ($('.page-tabs a')[0] != undefined) {
                        //    $('.page-tabs a').css("padding-left", "50px");
                        //}
                    } else {
                        $('.roll-left').hide();
                        //if ($('.page-tabs a')[0] != undefined) {
                        //    $('.page-tabs a').css("padding-left", "5px");
                        //}
                    }
                } else {
                    $('.roll-left').show();
                    //if ($('.page-tabs a')[0] != undefined) {
                    //    $('.page-tabs a').css("padding-left", "50px");
                    //}
                }
            }
            return false;
        },
        scrollTabRight: function () {
            var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
            var tabOuterWidth = $.learuntab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;
            if ($(".page-tabs-content").width() < visibleWidth) {
                return false;
            } else {
                var tabElement = $(".menuTab:first");
                var offsetVal = 0;
                while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).next();
                }
                offsetVal = 0;
                while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).next();
                }
                scrollVal = $.learuntab.calSumWidth($(tabElement).prevAll());
                if (scrollVal > 0) {
                    $('.page-tabs-content').animate({
                        marginLeft: 0 - scrollVal + 'px'
                    }, "fast");
                }
            }
        },
        scrollTabLeft: function () {
            var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
            var tabOuterWidth = $.learuntab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;
            if ($(".page-tabs-content").width() < visibleWidth) {
                return false;
            } else {
                var tabElement = $(".menuTab:first");
                var offsetVal = 0;
                while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).next();
                }
                offsetVal = 0;
                if ($.learuntab.calSumWidth($(tabElement).prevAll()) > visibleWidth) {
                    while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                        offsetVal += $(tabElement).outerWidth(true);
                        tabElement = $(tabElement).prev();
                    }
                    scrollVal = $.learuntab.calSumWidth($(tabElement).prevAll());
                }
            }
            $('.page-tabs-content').animate({
                marginLeft: 0 - scrollVal + 'px'
            }, "fast");
        },
        scrollToTab: function (element) {
            var marginLeftVal = $.learuntab.calSumWidth($(element).prevAll()), marginRightVal = $.learuntab.calSumWidth($(element).nextAll());
            var tabOuterWidth = $.learuntab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;
            if ($(".page-tabs-content").outerWidth() < visibleWidth) {
                scrollVal = 0;
            } else if (marginRightVal <= (visibleWidth - $(element).outerWidth(true) - $(element).next().outerWidth(true))) {
                if ((visibleWidth - $(element).next().outerWidth(true)) > marginRightVal) {
                    scrollVal = marginLeftVal;
                    var tabElement = element;
                    while ((scrollVal - $(tabElement).outerWidth()) > ($(".page-tabs-content").outerWidth() - visibleWidth)) {
                        scrollVal -= $(tabElement).prev().outerWidth();
                        tabElement = $(tabElement).prev();
                    }
                }
            } else if (marginLeftVal > (visibleWidth - $(element).outerWidth(true) - $(element).prev().outerWidth(true))) {
                scrollVal = marginLeftVal - $(element).prev().outerWidth(true);
            }
            $('.page-tabs-content').animate({
                marginLeft: 0 - scrollVal + 'px'
            }, "fast");
        },
        calSumWidth: function (element) {
            var width = 0;
            $(element).each(function () {
                width += $(this).outerWidth(true);
            });
            return width;
        },
        calSumHeight: function (element) {
            var height = 0;
            $(element).each(function () {
                height += $(this).outerHeight(true);
            });
            return height;
        },
        init: function () {
            //$("#top-menu").find(".treeviewTop").eq(0).click();
            $('.content-tabs').hide();
            $('.menuTabs').on('click', '.menuTab i', $.learuntab.closeTab);
            $('.menuTabs').on('click', '.menuTab', $.learuntab.activeTab);
            $('.tabLeft').on('click', $.learuntab.scrollTabLeft);
            $('.tabRight').on('click', $.learuntab.scrollTabRight);
            $('.tabReload').on('click', $.learuntab.refreshTab);
            $('.tabCloseCurrent').on('click', function () {
                $('.page-tabs-content').find('.active i').trigger("click");
            });
            $('.tabCloseAll').on('click', function tabCloseAll() {
                $('.page-tabs-content').children("[data-id]").find('.fa-remove').each(function () {
                    $('.LRADMS_iframe[data-id="' + $(this).data('id') + '"]').remove();
                    $(this).parents('a').remove();
                });
                $('.page-tabs-content').children("[data-id]:first").each(function () {
                    $('.LRADMS_iframe[data-id="' + $(this).data('id') + '"]').show();
                    $(this).addClass("active");
                });
                $('.page-tabs-content').css("margin-left", "0");
            });
            $('.tabCloseOther').on('click', $.learuntab.closeOtherTabs);
            $('.fullscreen').on('click', function () {
                if (!$(this).attr('fullscreen')) {
                    $(this).attr('fullscreen', 'true');
                    $.learuntab.requestFullScreen();
                } else {
                    $(this).removeAttr('fullscreen')
                    $.learuntab.exitFullscreen();
                }
            });
        },
        addEvent: function (item) {
            if (item.closed && item.isNoLog != true) {
                $.ajax({
                    url: contentPath + "/Home/VisitModule",
                    data: { moduleId: item.id, moduleName: item.title, moduleUrl: item.url },
                    type: "post",
                    dataType: "text"
                });
            }
        }
    };
    $.learunindex = {
        load: function () {
            $("body").removeClass("hold-transition")
            $("#content-wrapper").find('.mainContent').height($(window).height() - 100);
            $("#sidebar-menu").height($(window).height() - 84);
            $(window).resize(function (e) {
                $("#content-wrapper").find('.mainContent').height($(window).height() - 100);
                $("#sidebar-menu").height($(window).height() - 84);
            });
            $(".roll-left").click(function () {
                var btnChileI = $(".roll-left").find("i");
                if (btnChileI[0].className == "fa fa-forward") {
                    $.learunindex.subMenuShow();
                    btnChileI[0].className = "fa fa-backward";
                } else {
                    //$.learunindex.subMenuHide();
                    $(".ui-layout-toggler-west").click();
                    btnChileI[0].className = "fa fa-forward";
                }
            });
        },
        jsonWhere: function (data, action) {
            if (action == null) return;
            var reval = new Array();
            $(data).each(function (i, v) {
                if (action(v)) {
                    reval.push(v);
                }
            })
            return reval;
        },
        loadMenu: function (isInit) {
            var flag = false;

            var topMenuWidth = $('.lea-Head').width() - $.learuntab.calSumWidth($(".lea-Head").children().not(".left-bar"));

            var data = getInfoTop().learun.data.get(["authorizeMenu"]);
            var topMeunIds = getInfoTop().learun.data.get(["topMeunParentIds"]);
            //console.log(data);
            var _html = "";
            var menuWidth = 0;
            var _html1 = "", _html2 = "";
            $.each(data, function (i) {
                var row = data[i];
                //一级菜单导航栏显示
                if ($.inArray(row.F_ParentId, topMeunIds) >= 0) {
                    var _itemHtml = "";
                    if (row.F_UrlAddress == null || row.F_UrlAddress == "") {
                        _itemHtml += '<li class="treeviewTop" data-moduleId="' + row.F_ModuleId + '">';
                        // _itemHtml += '<a>';
                        _itemHtml += '<span style="font-size: 16px; font-weight: 400; line-height: 66px; color: rgba(255, 255, 255, 0.9); cursor: pointer; padding: 0px 10px;">' + row.F_FullName + '</span>';
                        //_itemHtml += '</a>';
                        //二级菜单显示
                        var childNodes = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == row.F_ModuleId && v.F_ModuleLoc == row.F_ParentId });
                        //console.log(childNodes);

                        if (childNodes.length > 0) {
                            _itemHtml += '<div class="popover-menu"><div class="arrow"><em></em><span></span></div><ul class="treeview-menu">';
                            $.each(childNodes, function (i) {
                                var subrow = childNodes[i];
                                //三级菜单显示
                                var subchildNodes = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == subrow.F_ModuleId && v.F_ModuleLoc == "0" && v.F_ModuleLoc });
                                var subchildLeft = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == subrow.F_ModuleId && v.F_ModuleLoc != "0" && v.F_ModuleLoc });
                                //console.log(subchildNodes);
                                //console.log(subchildLeft);
                                if (subchildNodes.length > 0) {
                                    _itemHtml += '<li data-moduleId="' + subrow.F_ModuleId + '">';
                                    _itemHtml += '<a class="menuItem menuiframe" href="#"><i class="' + subrow.F_Icon + ' firstIcon"></i>' + subrow.F_FullName + '';
                                    _itemHtml += '<i class="fa fa-angle-right pull-right"></i></a>';

                                    _itemHtml += '<div class="popover-menu-sub"><ul class="treeview-menu">';
                                    $.each(subchildNodes, function (i) {
                                        var subchildNodesrow = subchildNodes[i];
                                        //四级菜单显示
                                        var subchildNodesrowNodes = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == subchildNodesrow.F_ModuleId && v.F_ModuleLoc == "0" && v.F_ModuleLoc });
                                        var subchildNodesrowLeft = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == subchildNodesrow.F_ModuleId && v.F_ModuleLoc != "0" && v.F_ModuleLoc });
                                        //console.log(subchildNodesrowNodes);
                                        //console.log(subchildNodesrowLeft);
                                        if (subchildNodesrowNodes.length > 0) {
                                            _itemHtml += '<li data-moduleId="' + subchildNodesrow.F_ModuleId + '">';
                                            _itemHtml += '<a class="menuItem menuiframe" href="#"><i class="' + subchildNodesrow.F_Icon + ' firstIcon"></i>' + subchildNodesrow.F_FullName + '';
                                            _itemHtml += '<i class="fa fa-angle-right pull-right"></i></a>';

                                            _itemHtml += '<div class="popover-menu-subchild"><ul class="treeview-menu">';
                                            $.each(subchildNodesrowNodes, function (i) {
                                                var subchildNodesEle = subchildNodesrowNodes[i];
                                                _itemHtml += '<li><a class="menuItem menuiframe" onclick="$.learuntab.addTab(this)" data-parent-id="' + subchildNodesEle.F_ParentId + '"  data-id="' + subchildNodesEle.F_ModuleId + '" data-href="' + subchildNodesEle.F_UrlAddress + '"><i class="' + subchildNodesEle.F_Icon + ' firstIcon"></i>' + subchildNodesEle.F_FullName + '</a>';
                                            })
                                            _itemHtml += '</li></ul></div>';
                                        } else if (subchildNodesrowLeft.length > 0) {
                                            _itemHtml += '<li class="menuTopTree" data-moduleId="' + subchildNodesrow.F_ModuleId + '">';
                                            _itemHtml += '<a class="menuTreeItem menuItem"><i class="' + subchildNodesrow.F_Icon + ' firstIcon"></i>' + subchildNodesrow.F_FullName + '';
                                            _itemHtml += '<i class="fa fa-angle-right pull-right"></i></a>';
                                            _itemHtml += '</li>';
                                        } else {
                                            _itemHtml += '<li>';
                                            _itemHtml += '<a class="menuItem menuiframe" onclick="$.learuntab.addTab(this)" data-parent-id="' + subchildNodesrow.F_ParentId + '" data-id="' + subchildNodesrow.F_ModuleId + '" data-href="' + subchildNodesrow.F_UrlAddress + '"><i class="' + subchildNodesrow.F_Icon + ' firstIcon"></i>' + subchildNodesrow.F_FullName + '</a></li>';
                                        }
                                        _itemHtml += '</li>';
                                    });
                                    _itemHtml += '</ul></div>';
                                } else if (subchildLeft.length > 0) {
                                    _itemHtml += '<li class="menuTopTree" data-moduleId="' + subrow.F_ModuleId + '">';
                                    _itemHtml += '<a class="menuTreeItem menuItem"><i class="' + subrow.F_Icon + ' firstIcon"></i>' + subrow.F_FullName + '';
                                    _itemHtml += '<i class="fa fa-angle-right pull-right"></i></a>';
                                    _itemHtml += '</li>';

                                } else {
                                    _itemHtml += '<li>';
                                    _itemHtml += '<a class="menuItem menuiframe" onclick="$.learuntab.addTab(this)" data-parent-id="' + subrow.F_ParentId + '"  data-id="' + subrow.F_ModuleId + '" data-href="' + subrow.F_UrlAddress + '"><i class="' + subrow.F_Icon + ' firstIcon"></i>' + subrow.F_FullName + '</a></li>';
                                }
                                _itemHtml += '</li>';
                            })
                            _itemHtml += '</ul></div>';
                        } else {
                            _itemHtml += '<div class="popover-menu"></div>'
                        }
                        _itemHtml += '</li>';
                    } else {
                        _itemHtml += '<li class="treeviewTop treeviewTopNone" data-moduleId="' + row.F_ModuleId + '">';
                        _itemHtml += '<a onclick="$.learuntab.addTab(this)" data-parent-id="' + row.F_ParentId + '" data-parent-id="' + row.F_ParentId + '" data-id="' + row.F_ModuleId + '" data-href="' + row.F_UrlAddress + '" data-target="' + row.F_Target + '">';
                        _itemHtml += '<span>' + row.F_FullName + '</span>';
                        _itemHtml += '</a>';
                        _itemHtml += '<div class="popover-menu"></div>'
                        _itemHtml += '</li>';
                    }

                    menuWidth += 88;
                    _html += _itemHtml;
                }
            });
            $("#top-menu").html(_html);

            $("#top-menu>.treeviewTop").unbind();
            $('.popover-menu>ul>li').unbind();

            //$("#top-menu>.treeviewTop").hover(
            //    function () {
            //        var $li = $(this);
            //        var $moreMenuPopover = $li.find('.popover-moreMenu');
            //        //$li.addClass('active');
            //        if ($moreMenuPopover.length > 0) {
            //            $moreMenuPopover.slideDown(150);
            //            $($moreMenuPopover.find('.treeviewTop>a')[0]).trigger('click');
            //        }
            //        else {
            //            var $popover = $li.find('.popover-menu');
            //            $popover.slideDown(150);
            //        }
            //    },
            //    function () {
            //        var $li = $(this);
            //        var $popover = $li.find('.popover-menu');
            //        var $moreMenuPopover = $li.find('.popover-moreMenu');
            //        if ($moreMenuPopover.length == 0) {
            //            $popover.slideUp(50);
            //        }
            //        else {
            //            $moreMenuPopover.hide();
            //        }
            //        //$li.removeClass('active');
            //    });
            $('.popover-menu>ul>li').hover(
                function () {
                    var $li = $(this);
                    if ($li.parents('.moresubmenu').length == 0) {
                        var windowWidth = $(window).width();
                        var windowHeight = $(window).height();
                        var $popover = $li.find('.popover-menu-sub');
                        var subHeight = $popover.height();
                        $popover.css('left', $li.width());
                        if ((windowWidth - $li.offset().left - 154) < 152) {
                            $popover.css("left", "-156px");
                        }
                        if ((subHeight - 10 + $li.offset().top) > windowHeight) {
                            var marginTop = subHeight - 10 + $li.offset().top - windowHeight + 46;
                            $popover.css('margin-top', '-' + marginTop + 'px');
                        }
                        $li.addClass('active');
                        $popover.slideDown(150);
                    }
                },
                function () {
                    var $li = $(this);
                    if ($li.parents('.moresubmenu').length == 0) {
                        var $popover = $li.find('.popover-menu-sub');
                        $li.removeClass('active');
                        $popover.css('margin-top', '-46px');
                        $popover.slideUp(50);
                    }
                }
            );
            $('.popover-menu-sub>ul>li').hover(
                function () {
                    var $li = $(this);
                    if ($li.parents('.moresubmenu').length == 0) {
                        var windowWidth = $(window).width();
                        var windowHeight = $(window).height();
                        var $popover = $li.find('.popover-menu-subchild');
                        var subHeight = $popover.height();
                        if ((windowWidth - $li.offset().left - 154) < 152) {
                            $popover.css("left", "-156px");
                        }
                        if ((subHeight - 10 + $li.offset().top) > windowHeight) {
                            var marginTop = subHeight - 10 + $li.offset().top - windowHeight + 46;
                            $popover.css('margin-top', '-' + marginTop + 'px');
                        }
                        $li.addClass('active');
                        $popover.slideDown(150);
                    }
                },
                function () {
                    var $li = $(this);
                    if ($li.parents('.moresubmenu').length == 0) {
                        var $popover = $li.find('.popover-menu-subchild');
                        $li.removeClass('active');
                        $popover.css('margin-top', '-46px');
                        $popover.slideUp(50);
                    }
                }
            );

            $("#top-menu>.treeviewTop").unbind();
            //var _sidePrehtml = '<li>'
            //                 + '<a href="javascript:;" onclick="$.learuntab.addTab(this)" id="mianFrame" class="menuTab active" data-href="/Home/AdminWaterDesktop"><i class="fa fa-home"></i><span>首页</span></a>'
            //                 + '</li>';
            var _sidePrehtml = '';
            var _sidehtml = "";

            //导航菜单点击事件
            $("#top-menu>.treeviewTop").click(function (e) {
                //$.learunindex.subMenuShow();
                e.stopPropagation();

                var $li = $(this);
                var _templi = $li.addClass('active').siblings();
                _templi.removeClass('active');

                var num = $("#top-menu>.treeviewTop").index(this);
                $('.popover-menu').eq(num).show().parent().siblings().children('.popover-menu').hide();
                if (_colorArr != null && _colorArr != undefined) {
                    for (var i = 0; i < _templi.length; i++) {
                        _templi[i].style.backgroundColor = '';
                    }
                    $('li.treeviewTop.active').css("background-color", _colorArr.TopMenuActiveBackgroundColor);
                }
                _sidehtml = "";
                var moduleId = $li.attr("data-moduleId");

                //F_ModuleLoc !="0" 显示在菜单左侧
                var childNodesNull = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == moduleId && v.F_ModuleLoc != "0" && v.F_ModuleLoc });
                //F_ModuleLoc =="0" 显示在菜单顶部
                var childNodes0 = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == moduleId && v.F_ModuleLoc == "0" && v.F_ModuleLoc });
                if (childNodes0.length == 0 && childNodesNull.length == 0) {
                    var layOut = $('#layout_parent').layout();
                    layOut.sizePane('west', 1);
                }

                if (childNodes0.length > 0) {
                    var layOut = $('#layout_parent').layout();
                    layOut.sizePane('west', 1);
                    $('.roll-left').show();
                    //var btnChileI = $(".roll-left").find("i");
                    //if (btnChileI[0].className == "fa fa-backward") {
                    //    $.learunindex.subMenuShow();
                    //    btnChileI[0].className = "fa fa-forward";
                    //}
                } else {
                    if (childNodesNull.length > 0) {
                        $('.content-tabs').show();
                        $('.roll-left').show();
                        //var btnChileI = $(".roll-left").find("i");
                        //if (btnChileI[0].className == "fa fa-forward") {
                        //    $.learunindex.subMenuShow();
                        //    btnChileI[0].className = "fa fa-backward";
                        //}
                        var layOut = $('#layout_parent').layout();
                        layOut.sizePane('west', 250);
                        recuron(childNodesNull);
                    }
                    else {
                        if ($li.hasClass("treeviewTopNone")) {
                            $('.content-tabs').show();
                            $('.roll-left').show();
                            return false;
                        } else {
                            $('.content-tabs').hide();
                        }
                    }
                }

                if (!$('.content-tabs').is(":hidden")) {
                    $("#content-wrapper").find('.mainContent').height($(window).height() - 105);
                };

                if (_colorArr != null && _colorArr != undefined) {
                    $('.menu .popover-menu>ul').css('background-color', _colorArr.TopMenuBoxBackgroundColor);
                    //$('.menu .popover-menu>ul').css('color', _colorArr.TopMenuBoxColor);
                    $('.menu .popover-menu .popover-menu-subchild>ul').css('background-color', _colorArr.TopMenuBoxBackgroundColor);
                    $('.menu .popover-menu .popover-menu-sub>ul').css('background-color', _colorArr.TopMenuBoxBackgroundColor);
                    //$('.menu .popover-menu .active>.menuItem,.menu .popover-menu .menuItem:hover').css('background-color', _colorArr.TopMenuBoxBackgroundColor)
                    //$('.menu .popover-menu .active>.menuItem').css('background-color', _colorArr.TopMenuBoxBackgroundColor);
                    $('.menu .popover-menu .menuItem').hover(function () {
                        $('.menu .popover-menu .menuItem:hover').css('background-color', '#FFFFF0');
                        $('.menu .popover-menu .menuItem:hover').css('color', '#000000');
                        $('.menu .popover-menu .active>.menuItem').css('background-color', '#FFFFF0');
                    }, function () {
                        $('.menu .popover-menu .menuItem').css('background-color', _colorArr.TopMenuBoxBackgroundColor);
                    });
                }
            });

            $('.treeview-menu>li>.menuiframe').click(function () {
                $('.content-tabs').show();

                $('.popover-menu').slideUp(50);
                $('.popover-menu-sub').slideUp(50);
            })

            $('.treeview-menu>li>.menuTreeItem').click(function () {
                //$('.content-tabs').show();
                $('.popover-menu').slideUp(50);
                $('.popover-menu-sub').slideUp(50);
            })
            $('.treeviewTopNone').click(function () {
                $('.content-tabs').show();
            })

            //二级菜单点击显示左侧
            $('.treeview-menu>.menuTopTree').click(function (e) {
                e.stopPropagation();
                var $li = $(this);
                _sidehtml = "";
                var moduleId = $li.attr("data-moduleId");
                var leftchildNodes = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == moduleId && v.F_ModuleLoc != "0" && v.F_ModuleLoc });
                if (leftchildNodes.length > 0) {
                    var layOut = $('#layout_parent').layout();
                    $('.content-tabs').show();
                    $('.roll-left').show();
                    $('.page-tabs a').css("padding-left", "15px");
                    //var btnChileI = $(".roll-left").find("i");
                    //if (btnChileI[0].className == "fa fa-forward") {
                    //    $.learunindex.subMenuShow();
                    //    btnChileI[0].className = "fa fa-backward";
                    //}
                    layOut.sizePane('west', 250);
                    recuron(leftchildNodes);
                }
            });
            // GetColor();
            //点空白处顶部二级导航隐藏
            $("body").click(function (e) {
                $('.popover-menu').slideUp(50);
            });
            $("body").find("iframe").contents().click(function (e) {
                $('.popover-menu').slideUp(50);
            });
            /*
            * 递归支持多级菜单  
            */
            function recuron(childNodes) {
                $.each(childNodes, function (i) {
                    var row = childNodes[i];
                    _sidehtml += '<li class="treeview">';

                    var subchildNodes = $.learunindex.jsonWhere(data, function (v) { return v.F_ParentId == row.F_ModuleId });
                    if (subchildNodes.length > 0) {

                        _sidehtml += '<a href="javascript:;">'
                        _sidehtml += '<i class="' + row.F_Icon + '"></i><span>' + row.F_FullName + '</span><i class="fa fa-angle-left pull-right"></i>'
                        _sidehtml += '</a>'
                        _sidehtml += '<ul class="treeview-menu">';

                        recuron(subchildNodes);

                        _sidehtml += '</ul>';

                    } else {
                        _sidehtml += '<a class="menuItem" onclick="$.learuntab.addTab(this)" href="javascript:;" data-parent-id="' + row.F_ParentId + '" data-id="' + row.F_ModuleId + '" data-href="' + row.F_UrlAddress + '" data-target="' + row.F_Target + '">'
                        _sidehtml += '<i class="' + row.F_Icon + '"></i><span>' + row.F_FullName + '</span>'
                        _sidehtml += '</a>'
                    }
                    _sidehtml += '</li>';
                });
                $("#sidebar-menu").html(_sidePrehtml + _sidehtml);
                $("#sidebar-menu li a").click(function () {
                    var d = $(this), e = d.next();
                    if (e.is(".treeview-menu") && e.is(":visible")) {
                        e.slideUp(500, function () {
                            e.removeClass("menu-open")
                        }),
                        e.parent("li").removeClass("active")
                    } else if (e.is(".treeview-menu") && !e.is(":visible")) {


                        var f = d.parents("ul").first(),
                        g = f.find("ul:visible").slideUp(500);
                        if (_colorArr != null && _colorArr != undefined) {
                            if (g.length > 0) {
                                g[0].style.backgroundColor = _colorArr.LeftMenuBackgroundColor;
                                g[0].style.color = _colorArr.LeftMenuColor;
                                //$('.skin-blue .sidebar-menu > li > a,').css("background-color", _colorArr.LeftMenuBackgroundColor);
                                //$('.skin-blue .sidebar-menu > li > a,').css("color", _colorArr.LeftMenuColor)
                            }
                            $('.skin-blue .sidebar-menu > li > .treeview-menu').css("background-color", _colorArr.LeftMenuBackgroundColor);
                            $('.skin-blue .sidebar-menu > li.active > a').css("background-color", _colorArr.LeftMenuActiveBackgroundColor);

                        }
                        g.removeClass("menu-open");
                        var h = d.parent("li");
                        var _h = $.learuntab.calSumHeight($("#sidebar-menu>li"));
                        e.slideDown(500, function () {
                            e.addClass("menu-open"),
                            f.find("li.active").removeClass("active"),
                            h.addClass("active");

                            try {
                                var _height1 = $(window).height() - $("#sidebar-menu >li.active").position().top - 41;
                            }
                            catch (e) {
                                console.log(e.message);
                            }
                            var _height2 = $("#sidebar-menu li > ul.menu-open").height() + 10
                            if (_height2 > _height1) {
                                if (_h < $("#sidebar-menu").height()) {
                                    if (_height1 > 70) {
                                        $("#sidebar-menu >li > ul.menu-open").css({
                                            //overflow: "auto",
                                            height: _height1
                                        });
                                    }
                                    else {
                                        console.log(_height1, '_height1');
                                        $("#sidebar-menu >li > ul.menu-open").css({
                                            overflow: "initial",
                                            height: "initial"
                                        });
                                    }
                                }
                                else {
                                    $("#sidebar-menu >li > ul.menu-open").css({
                                        overflow: "initial",
                                        height: "initial"
                                    });
                                }
                            }
                            else {
                                $("#sidebar-menu >li > ul.menu-open").css({
                                    overflow: "initial",
                                    height: "initial"
                                });
                            }
                        })
                    }
                    else if (!e.is("treeview-menu")) {
                        $('.popover-menu').slideUp(50);
                        $('.popover-menu-sub').slideUp(50);
                        d.parent("li").siblings().removeClass("active");
                        d.parent("li").addClass("active");
                        d.parent("li").siblings().children(".treeview-menu").slideUp(50, function () {
                            $(this).removeClass("menu-open");
                        })
                        //$('.skin-blue .treeview-menu > li.active > a, .skin-blue .treeview-menu > li > a:hover').css("color", "#000080");
                    }
                    e.is(".treeview-menu");
                });
                if (_colorArr != null && _colorArr != undefined) {
                    $('.sidebar-menu > li> a').hover(function () {
                        $('.skin-blue .sidebar-menu > li:hover > a').css("background-color", _colorArr.LeftMenuActiveBackgroundColor);
                        $('.skin-blue .sidebar-menu > li:hover > a').css("color", _colorArr.LeftMenuActiveColor);
                    }, function () {
                        $('.sidebar-menu > li> a').css("background-color", _colorArr.LeftMenuBackgroundColor);
                        $('.sidebar-menu > li> a').css("color", _colorArr.LeftMenuColor);
                        $('.skin-blue .sidebar-menu > li.active > a').css("background-color", _colorArr.LeftMenuActiveBackgroundColor);
                        $('.skin-blue .sidebar-menu > li.active > a').css("color", _colorArr.LeftMenuActiveColor);
                    });
                    $('.treeview-menu > li > a').hover(function () {
                        $('.skin-blue .treeview-menu > li:hover > a').css("color", _colorArr.LeftMenuActiveColor);
                        $('.skin-blue .treeview-menu > li:hover > a').css("background-color", _colorArr.LeftMenuActiveBackgroundColor);
                    }, function () {
                        $('.skin-blue .treeview-menu > li > a').css("color", _colorArr.LeftMenuColor);
                        $('.skin-blue .treeview-menu > li > a').css("background-color", _colorArr.LeftMenuBackgroundColor);
                        $('.skin-blue .treeview-menu > li.active > a').css("color", _colorArr.LeftMenuActiveColor);
                        $('.skin-blue .treeview-menu > li.active > a').css("background-color", _colorArr.LeftMenuActiveBackgroundColor);
                    });
                }
            }
            var _colorArr;
            function GetColor() {
                $.ajax({
                    url: "/Home/GetColor",
                    type: "Get",
                    success: function (data) {
                        if (data) {
                            var arr = JSON.parse(data);
                            _colorArr = null;
                            if (_colorArr != null && _colorArr != undefined) {
                                $('.menu>.treeviewTop>a').css("color", _colorArr.TopMenuFontColor);
                                $('.menu>.treeviewTop>span').css("color", _colorArr.TopMenuFontColor);
                                $('.menu>.treeviewTop>a>span').css("font-size", _colorArr.TopMenuFontSize + "px");
                                $('.menu>.treeviewTop>span').css("font-size", _colorArr.TopMenuFontSize + "px");
                                $('.navbar').css("background-color", _colorArr.TopMenuBackgroundColor);
                                $('.skin-blue .main-header .logo').css("background-color", _colorArr.LogoBackgrounfColor)
                                $('.skin-blue .main-header .logo').hover(function () {
                                    $('.skin-blue .main-header .logo').css("background-color", _colorArr.LogoHoverColor);
                                }, function () {
                                    $('.skin-blue .main-header .logo').css("background-color", _colorArr.LogoBackgrounfColor);
                                });
                                $('.skin-blue .wrapper,.skin-blue .main-sidebar,.skin-blue .left-side').css("background-color", _colorArr.LeftMenuBackgroundColor);
                            }
                        }
                    },
                    error: function (e) { },
                    cache: false
                });
            }
            //$('.skin-blue .sidebar-menu > li > .treeview-menu').css("background-color", arr.LogoBackgrounfColor);
            //$('.skin-blue .sidebar-menu > li:hover > a,.skin-blue .sidebar-menu > li.active > a').css("background-color", arr.LogoHoverColor);
        },
        indexOut: function () {
            dialogConfirm("注：您确定要安全退出本次登录吗？", function (r) {
                if (r) {
                    learun.loading({ isShow: true, text: "正在安全退出..." });
                    window.setTimeout(function () {
                        $.ajax({
                            url: contentPath + "/Login/OutLogin",
                            type: "post",
                            dataType: "json",
                            success: function (data) {
                                window.location.href = ssoPath + "/Login/SSOClear?BackURL=" + contentWebUrl + "/Home/AdminWater";
                            }
                        });
                    }, 500);
                }
            });
        },
        subMenuShow: function () {
            $('.ui-layout-resizer-west')[0].style.display = 'none';
            if ($(".sidebar").width() == 0) {
                $(".ui-layout-toggler-west").click();
            }
            $('.content-tabs').slideDown(50);
        }
    };


    $(function () {
        learun.init({
            "callBack": function () {
                $.learunindex.loadMenu();
                $.learuntab.init();
                $.learunindex.load();

            },
            "themeType": "2"
        });
        //个人中心
        $("#taskcenter123").click(function () {
            tablist.newTab({ id: "UserSetting", title: "个人中心", closed: true, icon: "fa fa fa-user", url: "/PersonCenter/Index" });
        });
    });
})(jQuery);