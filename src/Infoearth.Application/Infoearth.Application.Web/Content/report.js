/*

扩展统计报表引用公共脚本 by wc 2018-5-2

使用方式

$(select).report({

});
*/


(function ($) {
    // alert(accesscode)
    $.fn.report = function (settings) {
        //默认选项
        var defaluts =
            {
                module:'',
                viewReport: null,
                deleteReport: null,
                sucess:null,
            };
        var opt = $.extend(defaluts, settings);
        var _r = $(this).empty();
        var authToken = getAuthorizationToken();
        GetReport();

        //获取报表信息
        function GetReport() {
            var queryJson = { module: opt.module };
            $.ajax({
                url: '../../api/TBL_REPORTApi/GetListJson',
                type: 'get',
                async: true,
                data: { queryJson: JSON.stringify(queryJson) },
                datatype: 'json',
                beforeSend: function (a) {
                    a.setRequestHeader("Authorization", authToken);
                },
                success: function (data) {
                    if (opt.success != null)
                        opt.success(data);

                    _r = _r.empty();
                    var html = "";
                    if (data != null && data.length > 0) {
                        for (var i = 0; i < data.length; i++) {
                            html += '<div class="col-sm-6 col-md-3 report-list"><a class="linkName" href="javascript:void(0)"><span style="display:none;">' + data[i].GUID + '</span>' + data[i].REPORTNAME + '(' + data[i].CREATETIME + ')</a><a class="link" href="javascript:void(0)" style="margin-left:5px;"><i class="fa fa-file-excel-o"></i>报表详情</a><span class="delIcon" name="' + data[i].GUID +'">×</span></div>';
                        }
                        _r.html(html);

                        //查看报表详情
                        $(".linkName").click(function () {
                            guid = $(this).find("span").html();
                            ViewReport(guid);
                        });

                        $(".link").click(function () {
                            guid = $(this).prev().find("span").html();
                            ViewModal(guid);
                        });

                        //删除报表
                        $(".delIcon").click(function () {
                            guid = $(this).attr('name');
                            DeleteReport(guid);
                        });
                    }
                },
                cache: false

            })
        }

        //存入报表
        function SaveReport(n, q, c) {
            var postData = {};
            postData.REPORTNAME = n;
            postData.QUERYSTRING = q;
            postData.MODULE = opt.module;
            postData.CONDITION = c;
            $.SaveForm({
                url: "../../api/TBL_REPORTApi/SaveForm?keyValue=",
                param: postData,
                authToken: authToken,
                loading: "正在保存报表...",
                success: function () {
                    //刷新报表列表
                    GetReport();
                }
            })
        }

        //删除报表
        function DeleteReport(guid) {
            if (guid) {
                $.RemoveForm({
                    url: '../../api/TBL_REPORTApi/RemoveForm',
                    authToken: authToken,
                    param: { keyValue: guid },
                    success: function (data) {
                        if (opt.deleteReport != null)
                            opt.deleteReport(data);

                        //刷新报表
                        GetReport();
                    }
                });
            }
        }

        //查看报表
        function ViewReport(guid) {
            $.SetForm({
                url: "../../api/TBL_REPORTApi/GetFormJson",
                authToken: authToken,
                param: { keyValue: guid },
                success: function (data) {
                    if (opt.viewReport != null) {
                        opt.viewReport(data);
                    }

                }
            });
        }

        //查看报表统计条件
        function ViewModal(guid) {
            $.SetForm({
                url: "../../api/TBL_REPORTApi/GetFormJson",
                authToken: authToken,
                param: { keyValue: guid },
                success: function (data) {
                    if (opt.ViewModal != null) {
                        opt.ViewModal(data);
                    }

                }
            });
        }
        _r[0].d = {
            SaveReport: function ( n, q, c) {
                SaveReport(n, q, c)
            },
            DeleteReport: function (guid) {
                DeleteReport(guid)
            },
            ViewReport: function (guid) {
                ViewReport(guid)
            },
            ViewModal: function (guid) {
                ViewModal(guid)
            }
        };
        return _r;
    };

    $.fn.SaveReport = function (n, q, c) {
        if (this[0].d) {
            this[0].d.SaveReport(n, q, c);
        }
    };

    $.fn.DeleteReport = function (guid) {
        if (this[0].d) {
            this[0].d.DeleteReport(guid);
        }
    };
    $.fn.ViewReport = function (guid) {
        if (this[0].d) {
            this[0].d.ViewReport(guid);
        }
    };
    $.fn.ViewModal = function (guid) {
        if (this[0].d) {
            this[0].d.ViewModal(guid);
        }
    };
})(jQuery);