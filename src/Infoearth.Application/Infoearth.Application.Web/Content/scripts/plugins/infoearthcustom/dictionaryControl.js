(function ($) {
    $.fn.dictionaryControl = function (settings) {
        //默认选项
        var defaluts =
            {
                dicCode: "",//字典Code
                type: "",//类型：checkbox、radio
                wrap: {
                    interlaced: false,//是否每行换行,默认不换行
                    indexBr: "",//指定数字换行
                },
                QTHtml: {
                    html: "",//其他html
                    index: ""//在第几个后面
                },//其他html
            };
        $.extend(defaluts, settings);
        var _dictionnaryControl = $(this).empty();
        var id = $(this).attr("id");

        var data = getInfoTop().learun.data.get(["dataItem", defaluts.dicCode]);
        var dataDMLX = [];
        for (var item in data) {
            //遍历非主键的key值
            if (item.length != 36) {
                dataDMLX.push({ text: data[item], value: item });
            }
        }
        for (var i = 0; i < dataDMLX.length; i++) {
            var dicHtml = "<label><input  type=\"" + defaluts.type + "\" class='control' name=\"" + id + "\" value=\"" + dataDMLX[i].value + "\" />" + dataDMLX[i].text + "</label>";
            //每行换行
            if (defaluts.wrap.interlaced) {
                if (dataDMLX.length - 1 != i) {
                    dicHtml += "<Br />";
                }
            }
            //指定行换行
            if (!defaluts.wrap.interlaced && defaluts.wrap.indexBr) {
                if (defaluts.wrap.indexBr == i) {
                    dicHtml += "<Br />";
                }
            }
            //其他
            if (defaluts.QTHtml.html) {
                if (defaluts.QTHtml.index && defaluts.QTHtml.index - 1 == i) {
                    dicHtml += defaluts.QTHtml.html;

                } else if (!defaluts.QTHtml.index && i == dataDMLX.length - 1) {
                    dicHtml += defaluts.QTHtml.html;
                }
                if (defaluts.indexBr && defaluts.indexBr == i && !defaluts.wrap.interlaced) {
                    dicHtml += "<Br />";
                }

            }
            _dictionnaryControl.append(dicHtml);

        }
        $("input:radio.control").click(function (e) {
            var domname = $(this).attr("name");
            if ($(this).attr("checked") == "checked") {
                $(this).attr("checked", false);
                $(this).prop("checked", "");
            } else {
                $("input:radio[name=" + domname + "]").attr("checked", false);
                $("input:radio[name=" + domname + "]").prop("checked", "");
                $(this).prop("checked", "checked");
                $(this).attr("checked", "checked");
            }
            //地面塌陷　土洞塌陷单层
            if (domname == "ISHOLECOSINGLE") {
                if ($("input[name='ISHOLECOSINGLE']").is(":checked")) {
                    $(".DC").prop("disabled", "")
                } else {
                    $(".DC").prop("disabled", "disabled")
                }
            }
            //地面塌陷　土洞塌陷双层
            else if (domname == "ISHOLECODOUBLE") {
                if ($("input[name='ISHOLECODOUBLE']").is(":checked")) {
                    $(".SC").prop("disabled", "")
                } else {
                    $(".SC").prop("disabled", "disabled")
                }
            }
            //地裂缝　地震有无断层活动
            else if (domname == "ISFRACTUREACTIVITY") {
                if ($("input[name='ISFRACTUREACTIVITY']").is(":checked")) {
                    $(".YWDCHD").prop("disabled", "");
                } else {
                    $(".YWDCHD").prop("disabled", "disabled");
                }
            }
            //地裂缝　土层有无断裂
            else if (domname == "SOILNEWFRAC") {
                if ($("input[name='SOILNEWFRAC']:checked").val() == "A") {
                    $("#SOILNEWFRACDIRE").prop("disabled", "")
                    $("#SOILNEWFRACANGLE").prop("disabled", "")
                }
                if ($(this).val() == "B" || !$(this).is(":checked")) {
                    $("#SOILNEWFRACDIRE").prop("disabled", "disabled")
                    $("#SOILNEWFRACANGLE").prop("disabled", "disabled")
                    $("#SOILNEWFRACDIRE").val("")
                    $("#SOILNEWFRACANGLE").val("")
                }
            }
            //地裂缝　有无新的构造断裂倾向
            else if (domname == "EXPCONTSOILNEWFRAC") {
                if ($("input[name='EXPCONTSOILNEWFRAC']:checked").val() == "A") {
                    $("#EXPCONTSOILNEWFRACDIRE").prop("disabled", "")
                    $("#EXPCONTSOILNEWFRACANGLE").prop("disabled", "")
                }
                if ($(this).val() == "B" || !$(this).is(":checked")) {
                    $("#EXPCONTSOILNEWFRACDIRE").prop("disabled", "disabled")
                    $("#EXPCONTSOILNEWFRACANGLE").prop("disabled", "disabled")
                    $("#EXPCONTSOILNEWFRACANGLE").val("")
                    $("#EXPCONTSOILNEWFRACDIRE").val("")

                }
            }
            //泥石流　防治措施现状
            else if (domname == "CONTROLMEASTATUSQ") {
                if ($(this).val() == "A") {
                    $("input[name='CONTROMEASURETYPE']").removeAttr("disabled")
                    $("#CONTROMEASURETYPE").css("color", "#000")
                }
                if ($(this).val() == "B" || !$(this).is(":checked")) {
                    $("input[name='CONTROMEASURETYPE']").attr("disabled", "disabled")
                    $("#CONTROMEASURETYPE").css("color", "#ccc")
                }
            }
            //泥石流　防治措施现状
            else if (domname == "MONITORMEASURE") {
                if ($(this).val() == "A") {
                    $("input[name='MONITORMEASURETYPE']").removeAttr("disabled")
                    $("#MONITORMEASURETYPE").css("color", "#000")
                }
                if ($(this).val() == "B" || !$(this).is(":checked")) {
                    $("input[name='MONITORMEASURETYPE']").attr("disabled", "disabled")
                    $("#MONITORMEASURETYPE").css("color", "#ccc")
                }
            }
            //泥石流　1-15评分
            else if (domname == "BADGEOLOGICALPHENOMENA") {
                if ($(this).val() == "A") {
                    $("#SCORE1").val("3.339")
                } else if ($(this).val() == "B") {
                    $("#SCORE1").val("2.544")
                } else if ($(this).val() == "C") {
                    $("#SCORE1").val("1.908")
                } else if ($(this).val() == "D") {
                    $("#SCORE1").val("0.159")
                }
                if (!$(this).is(":checked")) {
                    $("#SCORE1").val("");
                }
                total();
            } else if (domname == "MIZOGUCHIFAN") {
                if ($(this).val() == "A") {
                    $("#SCORE3").val("1.512")
                } else if ($(this).val() == "B") {
                    $("#SCORE3").val("1.188")
                } else if ($(this).val() == "C") {
                    $("#SCORE3").val("0.756")
                } else if ($(this).val() == "D") {
                    $("#SCORE3").val("0.108")
                }
                if (!$(this).is(":checked")) {
                    $("#SCORE3").val("");
                }
                total();
            } else if (domname == "NEWCONSTRUCTIONAFFECT") {
                if ($(this).val() == "A") {
                    $("#SCORE5").val("0.675")
                } else if ($(this).val() == "B") {
                    $("#SCORE5").val("0.525")
                } else if ($(this).val() == "C") {
                    $("#SCORE5").val("0.375")
                } else if ($(this).val() == "D") {
                    $("#SCORE5").val("0.075")
                }
                if (!$(this).is(":checked")) {
                    $("#SCORE5").val("");
                }
                total();
            } else if (domname == "ROCKFACTOR") {
                if ($(this).val() == "A") {
                    $("#SCORE9").val("0.324")
                } else if ($(this).val() == "B") {
                    $("#SCORE9").val("0.27")
                } else if ($(this).val() == "C") {
                    $("#SCORE9").val("0.216")
                } else if ($(this).val() == "D") {
                    $("#SCORE9").val("0.054")
                }
                if (!$(this).is(":checked")) {
                    $("#SCORE9").val("");
                }
                total();
            } else if (domname == "TRENCHCCROSSSECTIONAL") {
                if ($(this).val() == "A") {
                    $("#SCORE11").val("0.18")
                } else if ($(this).val() == "B") {
                    $("#SCORE11").val("0.144")
                } else if ($(this).val() == "C") {
                    $("#SCORE11").val("0.108")
                } else if ($(this).val() == "D") {
                    $("#SCORE11").val("0.036")
                }
                if (!$(this).is(":checked")) {
                    $("#SCORE11").val("");
                }
                total();
            } else if (domname == "BLOCKDEGREE") {
                if ($(this).val() == "A") {
                    $("#SCORE15").val("0.12")
                } else if ($(this).val() == "B") {
                    $("#SCORE15").val("0.09")
                } else if ($(this).val() == "C") {
                    $("#SCORE15").val("0.06")
                } else if ($(this).val() == "D") {
                    $("#SCORE15").val("0.03")
                }
                if (!$(this).is(":checked")) {
                    $("#SCORE15").val("");
                }
                total();
            }
            e.stopPropagation();
            e.stopImmediatePropagation();
        });
        //$.ajax({
        //    url: "../../SystemManage/DataItemDetail/GetDataItemTreeJson?EnCode=" + defaluts.dicCode,
        //    async: false,
        //    success: function (data) {
        //        var dataDMLX = eval(data);
        //        for (var i = 0; i < dataDMLX.length; i++) {
        //            var dicHtml = "<label><input  type=\"" + defaluts.type + "\" name=\"" + id + "\" value=\"" + dataDMLX[i].value + "\" />" + dataDMLX[i].text + "</label>";
        //            //每行换行
        //            if (defaluts.wrap.interlaced) {
        //                if (dataDMLX.length - 1 != i) {
        //                    dicHtml += "<Br />";
        //                }
        //            }
        //            //指定行换行
        //            if (!defaluts.wrap.interlaced && defaluts.wrap.indexBr) {
        //                if (defaluts.wrap.indexBr == i) {
        //                    dicHtml += "<Br />";
        //                }
        //            }
        //            //其他
        //            if (defaluts.QTHtml.html) {
        //                if (defaluts.QTHtml.index && defaluts.QTHtml.index - 1 == i) {
        //                    dicHtml += defaluts.QTHtml.html;

        //                } else if (!defaluts.QTHtml.index && i == dataDMLX.length - 1) {
        //                    dicHtml += defaluts.QTHtml.html;
        //                }
        //                if (defaluts.indexBr && defaluts.indexBr == i && !defaluts.wrap.interlaced) {
        //                    dicHtml += "<Br />";
        //                }
                       
        //            }
        //            _dictionnaryControl.append(dicHtml);

        //        }
        //    }, error: function (e) {
        //    },
        //    cache: false
        //});
        $(this)[0].dic = {
            setDictionaryControlValue: function (value) {
                var name = $(this).attr('id');
                $("input[name='" + name + "']").removeAttr("checked");//清空绑定
                if (value.indexOf(",") == -1) {
                    $("input[name='" + name + "'][value=" + value + "]").prop("checked", true);
                }
                else {
                    var checkValueData = value.split(',');
                    for (var i = 0; i < checkValueData.length; i++) {
                        $("input[name='" + name + "'][value=" + checkValueData[i] + "]").prop("checked", true);
                    }
                }

            },
            getDictionaryControlValue:function () {
                var chekcValue = "";
                $("[name='" + $(this).attr('id') + "']").each(function () {
                    if ($(this).is(":checked")) {
                        chekcValue += $(this).attr('value') + ",";
                    }
                });
                chekcValue = chekcValue.substring(0, chekcValue.length - 1);
                return chekcValue;
            }
        };
        return _dictionnaryControl;
    };
    $.fn.setDictionaryControlValue = function (value) {
        if (this[0].dic) {
            this[0].dic.setDictionaryControlValue(value);
        }
    };
    $.fn.getDictionaryControlValue = function () {
        if (this[0].dic) {
            this[0].dic.getDictionaryControlValue();
        }
    };
})(jQuery);