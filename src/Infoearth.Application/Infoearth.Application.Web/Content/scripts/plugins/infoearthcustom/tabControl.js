(function ($) {
    //选项卡
    $.fn.tabCtlInit = function (settings) {
        //默认选项
        var defaluts =
            {
                toolWidth: "170",
                tabContentID: "tab_Content",//显示内容ID
                btnHtml: '<div class="roll-nav " style="width:70px;"><a id="lr-export" class="btn btn-default" onclick="btn_export()" style="line-height: 14px; margin-bottom: 3px;"><i class="fa fa-file-excel-o"></i>&nbsp;导出</a></div>'//按钮html
            };
        $.extend(defaluts, settings);
        var _tabControl = $(this).empty();
        var dropdownStyle = "";
        if (defaluts.hasReport) {
            defaluts.btnHtml = defaluts.btnHtml + '<div class="roll-nav " style="width:70px;"><a id="lr-report" class="btn btn-default" onclick="setReportName()" style="line-height: 14px; margin-bottom: 3px;"><i class="fa fa-book"></i>&nbsp;存入报表库</a></div>';
            dropdownStyle = "right: 75px;";
        }
        var defaultHtml = '<div class="lea-tabs" style="overflow:hidden;">' +
                '<div class="menuTabs">' +
                    '<div class="page-tabs-content" style="margin-left: 0px;"></div>' +
                '</div>' +
                '<div class="tabs-right-tool" style="width:' + defaluts.toolWidth + 'px">' +
                    '<button class="roll-nav tabLeft"><i class="fa fa fa-chevron-left"></i></button>' +
                    '<button class="roll-nav tabRight"><i class="fa fa fa-chevron-right" style="margin-left: 3px;"></i></button>' +
                    '<div class="dropdown">' +
                       ' <button class="roll-nav dropdown-toggle" data-toggle="dropdown"><i class="fa fa-gear "></i></button>' +
                       ' <ul class="dropdown-menu dropdown-menu-right" style="margin-top:40px;' + dropdownStyle + '">' +
                           ' <li><a class="tabCloseCurrent" href="javascript:;">关闭当前</a></li>' +
                           ' <li><a class="tabCloseOther" href="javascript:;">除此之外全部关闭</a></li>' +
                       ' </ul>' +
                    '</div>' + defaluts.btnHtml +
                '</div>' +
           ' </div>' +
            '<div id="' + defaluts.tabContentID + '" class="lea-content">' +
            '</div>';
        _tabControl.append(defaultHtml);
        iniEvent();
        //初始化事件
        function iniEvent() {
            $('.menuTabs').on('click', '.page-tabs-content .tab_close', closeTab);
            $('.menuTabs').on('click', '.menuTab', activeTab);

            $('.tabLeft').on('click', scrollTabLeft);
            $('.tabRight').on('click', scrollTabRight);
            //$('.tabReload').on('click', refreshTab);
            $('.tabCloseCurrent').on('click', function () {
                $('.page-tabs-content').find('.active').siblings(".tab_close").trigger("click");
            });
            $('.tabCloseAll').on('click', function () {
                $('.page-tabs-content').children("[data-id]").find('.tab_close').each(function () {
                    $(this).parent().remove();
                });
                $('.page-tabs-content').children("[data-id]:first").each(function () {
                    $('.LRADMS_iframe[data-id="' + $(this).data('id') + '"]').show();
                    $(this).children('a').addClass("active");
                });
                $('.page-tabs-content').css("margin-left", "0");
            });
            $('.tabCloseOther').on('click', closeOtherTabs);
            //$('.fullscreen').on('click', function () {
            //    if (!$(this).attr('fullscreen')) {
            //        $(this).attr('fullscreen', 'true');
            //        requestFullScreen();
            //    } else {
            //        $(this).removeAttr('fullscreen');
            //        exitFullscreen();
            //    }
            //});
        }
        //添加tab
        function newTab(item) {
            var dataId = item.id;
            var dataUrl = item.url;
            var activeStr = item.newUnActive ? "" : "active ";
            var aClick = item.aClick ? "onclick=" + item.aClick : "";
            var menuName = '<i class="' + item.icon + '"></i>' + item.title;
            var flag = true;
            if (dataUrl == undefined || $.trim(dataUrl).length == 0) {
                return false;
            }
            //dataUrl = contentPath + dataUrl;
            $('.menuTab').each(function () {
                if ($(this).data('id') == dataUrl) {
                    if (!$(this).hasClass('active')) {
                        $(this).addClass('active').parent().siblings().children(".menuTab").removeClass('active');
                        scrollToTab(this);
                        $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
                            if ($(this).data('id') == dataUrl) {
                                $(this).show().siblings('.LRADMS_iframe').hide();
                                return false;
                            }
                        });
                    }
                    flag = false;
                    return false;
                }
            });

            if (flag) {
                $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
                    $(this).hide();
                });
                var str = '<div data-id="' + dataUrl + '" style="position: relative; display: inline-block;"><a href="javascript:;" data-id="' + dataUrl + '" class="' + activeStr + 'menuTab" ' + aClick + '>' + menuName + '</a><div class="tab_close"></div><div style="clear:both;"></div></div>';
                $('.menuTab').removeClass('active');
                var str1 = '<iframe class="LRADMS_iframe" id="iframe' + dataId + '" name="iframe' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless></iframe>';
                $('#' + defaluts.tabContentID).find('iframe.LRADMS_iframe').hide();
                //$('#tab_Content').append(str1);
                if (item.noNextTab) {
                    $('#' + defaluts.tabContentID).append(getTabHtml_noNextTab(item));
                }
                else if (item.isTab) {
                    $('#' + defaluts.tabContentID).append(getTabHtml(item));
                }
                else {
                    $('#' + defaluts.tabContentID).append('<div class="LRADMS_iframe" data-id="' + dataId + '"> <table id="gridTable_' + dataId + '"></table></div>');
                }
                learun.loading({ isShow: true });
                $('#' + defaluts.tabContentID + ' iframe:visible').load(function () {
                    learun.loading({ isShow: false });
                });
                $('.menuTabs .page-tabs-content').append(str);
                scrollToTab($('.menuTab.active'));
            }
            return flag;
        }
        function getTabHtml(item) {
            var html = '<div class="LRADMS_iframe" id="div_' + item.id + '" data-id="' + item.id + '"><ul class="nav nav-tabs"> ' +
                            '<li class="active" id="li_' + item.id + '_sj" ><a href="#' + item.id + '_sj" data-toggle="tab">数据列表</a></li>' +
                           '<li id="li_' + item.id + '_tj"><a href="#' + item.id + '_tj" data-toggle="tab">统计图表</a></li>' +
                            '</ul>' +
                           '<div  class="tab-content">' +
                               '<div class="tab-pane fade in active" id="' + item.id + '_sj">' +
                                    '<table id="gridTable_' + item.id + '"></table>' +
                               '</div>' +
                               '<div class="tab-pane fade in active" id="' + item.id + '_tj">' +
                               ' <div id="echart_' + item.id + '" class="content"></div>' +
                             '</div>' +
                      '</div>';
            return html;
        }

        function getTabHtml_noNextTab(item) {
            var html = '<div class="LRADMS_iframe" id="div_' + item.id + '" data-id="' + item.id + '"></div>';
            return html;
        }

        function refreshTab() {
            var currentId = $('.page-tabs-content').find('.active').attr('data-id');
            var target = $('.LRADMS_iframe[data-id="' + currentId + '"]');
            var url = target.attr('src');
            learun.loading({ isShow: true });
            target.attr('src', url).load(function () {
                learun.loading({ isShow: false });
            });
        };
        function activeTab() {
            var currentId = $(this).data('id');
            if (!$(this).hasClass('active')) {
                $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
                    if ($(this).data('id') == currentId) {
                        $(this).show().siblings('.LRADMS_iframe').hide();
                        return false;
                    }
                });
                $(this).addClass('active').parent().siblings().children('.menuTab').removeClass('active');
                scrollToTab(this);
            }
            var dataId = $(this).attr('data-value');
            if (dataId != "") {
                getInfoTop().$.cookie('currentmoduleId', dataId, { path: "/" });
            }
        };
        function closeOtherTabs() {
            $('.page-tabs-content').children("[data-id]").find('.tab_close').siblings('a').not(".active").each(function () {
                if (excelArr) {
                    for (var i = 0; i < excelArr.length; i++) {
                        if (excelArr[i].id == $(this).data('id')) {
                            excelArr.splice(i, 1);
                        }
                    }
                }

                $('.LRADMS_iframe[data-id="' + $(this).data('id') + '"]').remove();
                $(this).remove();

            });
            $('.page-tabs-content').css("margin-left", "0");
        };
        function closeTab() {
            var closeTabId = $(this).siblings('.menuTab').data('id');
            var currentWidth = $(this).siblings('.menuTab').width();
            var closeFlag = false;//选项卡是否关闭

            if ($(this).siblings('.menuTab').hasClass('active')) {
                //当前关闭选项卡下一个选项卡
                if ($(this).parent().next().size()) {
                    var activeId = $(this).parent().next(':eq(0)').children('a').data('id');
                    //$(this).parent().next(':eq(0)').children('a').addClass('active');
                    $(this).parent().next(':eq(0)').children('a').trigger('click');
                    $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
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
                    $(this).parent().remove();
                    closeFlag = true;
                    $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
                        if ($(this).data('id') == closeTabId) {
                            $(this).remove();
                            return false;
                        }
                    });
                }
                if ($(this).parent().prev().size()) {
                    var activeId = $(this).parent().prev(':last').children('a').data('id');
                    //$(this).parent().prev(':last').children('a').addClass('active');
                    $(this).parent().prev(':eq(0)').children('a').trigger('click');
                    $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
                        if ($(this).data('id') == activeId) {
                            $(this).show().siblings('.LRADMS_iframe').hide();
                            return false;
                        }
                    });
                    $(this).parent().remove();
                    closeFlag = true;
                    $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
                        if ($(this).data('id') == closeTabId) {
                            $(this).remove();
                            return false;
                        }
                    });
                }
                if (excelArr && closeFlag) {
                    for (var i = 0; i < excelArr.length; i++) {
                        if (excelArr[i].id == closeTabId) {
                            excelArr.splice(i, 1);
                        }
                    }
                }
            }
            else {
                $(this).parent().remove();
                $('#' + defaluts.tabContentID + ' .LRADMS_iframe').each(function () {
                    if ($(this).data('id') == closeTabId) {
                        $(this).remove();
                        return false;
                    }
                });
                scrollToTab($('.menuTab.active'));
            }
            var dataId = $('.menuTab.active').attr('data-value');
            if (dataId != "") {
                getInfoTop().$.cookie('currentmoduleId', dataId, { path: "/" });
            }
            return false;
        };
        function scrollTabRight() {
            var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
            var tabOuterWidth = calSumWidth($(".lea-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".lea-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;
            if ($(".page-tabs-content").width() < visibleWidth) {
                return false;
            } else {
                var tabElement = $(".menuTab:first").parent();
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
                scrollVal = calSumWidth($(tabElement).prevAll());
                if (scrollVal > 0) {
                    $('.page-tabs-content').animate({
                        marginLeft: 0 - scrollVal + 'px'
                    }, "fast");
                }
            }
        };
        function scrollTabLeft() {
            var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
            var tabOuterWidth = calSumWidth($(".lea-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".lea-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;
            if ($(".page-tabs-content").width() < visibleWidth) {
                return false;
            } else {
                var tabElement = $(".menuTab:first").parent();
                var offsetVal = 0;
                while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).next();
                }
                offsetVal = 0;
                if (calSumWidth($(tabElement).prevAll()) > visibleWidth) {
                    while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                        offsetVal += $(tabElement).outerWidth(true);
                        tabElement = $(tabElement).prev();
                    }
                    scrollVal = calSumWidth($(tabElement).prevAll());
                }
            }
            $('.page-tabs-content').animate({
                marginLeft: 0 - scrollVal + 'px'
            }, "fast");
        };
        function scrollToTab(element) {
            if (element && element.tagName == 'A') {
                element = $(element).parent();
            }
            var marginLeftVal = calSumWidth($(element).prevAll()), marginRightVal = calSumWidth($(element).nextAll());
            var tabOuterWidth = calSumWidth($(".lea-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".lea-tabs").outerWidth(true) - tabOuterWidth;
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
        };
        function calSumWidth(element) {
            var width = 0;
            $(element).each(function () {
                width += $(this).outerWidth(true);
            });
            return width;
        };
        $(this)[0].tab = {
            newTab: function (item) {
                return newTab(item);
            },

        };
        return _tabControl;
    };
    $.fn.newTab = function (item) {
        if (this[0].tab) {
            this[0].tab.newTab(item);
        }
    };
})(jQuery);