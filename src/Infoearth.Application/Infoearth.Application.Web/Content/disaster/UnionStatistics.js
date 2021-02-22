var selectedRowIndex = 0;
var authToken = getAuthorizationToken();
var sqlWhere = request("sqlWhere").replace('$','=');

var dicJson=[
    {key:'灾害体名称',value:'DISASTERNAME'},
    {key:'灾害体编号',value:'UNIFIEDCODE'},
    {key:'灾害体类型', value: 'DISASTERTYPE' },
    {key:'省',value:'PROVINCENAME'},
    {key:'市',value:'CITYNAME'},
    {key:'县',value:'COUNTYNAME'},
    {key:'乡镇',value:'TOWNNAME'},
    {key:'地理位置',value:'LOCATION'},
    {key:'经度',value:'LONGITUDE'},
    {key:'纬度',value:'LATITUDE'},
    {key:'野外编号',value:'OUTDOORCODE'},
    {key:'室内编号',value:'INDOORCODE'},
    {key:'灾害等级',value:'DISASTERLEVEL'},
    {key:'险情等级',value:'DANGERLEVEL'},
    {key:'地下水类型',value:'GROUNDWATERTYPE'},
    {key:'防治建议', value: 'TREATMENTSUGGESTION' },
    {key:'构造部位',value:'TECTONICREGION'},
    {key:'监测建议',value:'MONITORSUGGESTION'},
    {key:'今后变化趋势',value:'STABLETREND'},
    {key:'目前稳定程度',value:'CURSTABLESTATUS'},
    {key:'威胁财产',value:'THREATENASSETS'},
    {key:'威胁人口',value:'THREATENPEOPLE'},
    {key:'隐患点', value: 'HIDDENDANGER' },
    {key:'毁坏房屋',value:'DESTROYEDHOME'},
    {key:'毁路',value:'DESTROYEDROAD'},
    {key:'毁渠',value:'DESTROYEDCANAL'},
    {key:'X',value:'X'},
    {key:'Y',value:'Y'},
    {key:'Z',value:'Z'}
];

$(function () {
    $(document).ready(function () {
        $("#yuJuArea").val(sqlWhere);

        //检查字段
        $(".tongji-tiaojian-left-top1 a").each(function (index, a) {
            if (a) {
                $(a).click(function () {
                    $('.ui-jqgrid').css('display', 'block');

                    $('.gridPanel').css('border', 'none');

                        var value = "";
                        if (a.innerHTML == "威胁财产(万元)") {
                            $("#yuJuArea").val($("#yuJuArea").val() + CreplaceE(" 威胁财产"));
                            value = "威胁财产";
                        }
                        else if (a.innerHTML == "威胁人口(人)") {
                            $("#yuJuArea").val($("#yuJuArea").val() + CreplaceE(" 威胁人口"));
                            value = "威胁人口";
                        }
                        else if (a.innerHTML == "毁坏房屋(间)") {
                            $("#yuJuArea").val($("#yuJuArea").val() + CreplaceE(" 毁坏房屋"));
                            value = "毁坏房屋";
                        }
                        else {
                            $("#yuJuArea").val($("#yuJuArea").val() + " " + CreplaceE(a.innerHTML));
                            value = a.innerHTML;
                        }

                        QueryMethod(value);
                });
            }
        });

        LoadGrid();
        HideValue();

        $('.ui-jqgrid').css('display', 'none');

        //检查
        $("#btnVertify").click(function () {
            var sqlStr = $("#yuJuArea").val();
            if (sqlStr == "") {
                dialogMsg("请填写组合条件",0);
            }
            else {
                $.ajax({
                    url: "../../api/TBL_HAZARDBASICINFOApi/CheckExpression",
                    data: { sqlWhere: CreplaceE(sqlStr) },
                    type:'get',
                    success: function (data) {
                        if (data.type == "3") {
                            learun.loading({ isShow: false });
                            learun.dialogMsg({ msg: data.message, type: -1 });
                        } else {
                            learun.loading({ isShow: false });
                            learun.dialogMsg({ msg: data.message, type: 1 });
                        }
                    },
                    beforeSend: function (c, b) {
                        if (authToken != null)
                            c.setRequestHeader("Authorization", authToken);
                        learun.loading({ isShow: true, text: "正在检查语句" });
                    },
                    complete: function () {
                        learun.loading({ isShow: false });
                    },
                    cache: false
                })
            }
        });

        //计算方法
        $(".tongji-tiaojian-left-top2 a").each(function (index, a) {
            if (a) {
                $(a).click(function () {
                    $("#yuJuArea").val($("#yuJuArea").val() + " " + HTMLDecoded(a.innerHTML)); //把选中的项添加到查询语句中
                })
            }
        });

        //清除
        $("#btnClear").click(function () {
            $("#yuJuArea").val("");
        });

        //查询
        function HideValue() {
            var colms = [];
            for (var i = 0; i < dicJson.length; i++) {
                colms.push(dicJson[i].value);
            }
            $('#gridTable1').jqGrid("hideCol", colms);
        }

        //查询数据
        function QueryMethod(ShowName) {
            var colmn = GetColumn(ShowName);
            $("#gridTable1").jqGrid("clearGridData");
            $("#gridTable1").jqGrid('setGridParam', {
                async: false,
                loadBeforeSend: function (a) {
                    if (authToken != null)
                        a.setRequestHeader("Authorization", authToken);
                },
                sortname: colmn,
                postData: { queryJson: JSON.stringify({ colmn: colmn }) },
                url: "../../api/TBL_HAZARDBASICINFOApi/GetSinglePageListJson",
                onSelectRow: function (rowId, status) {
                    selectedRowIndex = $('#' + this.id).getGridParam('selrow');
                },
                onCellSelect: function (rowid, index, contents, event) {
                    if (isNumber(contents))
                        $("#yuJuArea").val($("#yuJuArea").val() + " " + contents);
                    else
                        $("#yuJuArea").val($("#yuJuArea").val() + " \'" + contents + "\'");
                },
                gridComplete: function () {
                    $('#' + this.id).setSelection(selectedRowIndex, false);
                }
            }).trigger('reloadGrid');

            HideValue();

            $('#gridTable1').jqGrid("showCol", [colmn]);
        }
        //初次加载数据，并隐藏所有列
        function LoadGrid() {
            var $gridTable = $('#gridTable1');
            $gridTable.jqGrid({
                async: false,
                autowidth: false,
                width:255,
                height: 270,
                url: "../../api/TBL_HAZARDBASICINFOApi/GetSinglePageListJson",
                loadBeforeSend: function (a) {
                    if (authToken != null)
                        a.setRequestHeader("Authorization", authToken);
                },
                postData: { queryJson: JSON.stringify({ colmn: 'UNIFIEDCODE' }) },
                datatype: "json",
                colModel: [
                { label: '灾害体编号', name: 'UNIFIEDCODE', index: 'UNIFIEDCODE', width: 240, align: 'left', sortable: true },
                { label: '灾害体名称', name: 'DISASTERNAME', index: 'DISASTERNAME', width: 240, align: 'left', sortable: true },
                { label: '省', name: 'PROVINCENAME', index: 'PROVINCENAME', width: 240, align: 'left', sortable: true },
                { label: '市', name: 'CITYNAME', index: 'CITYNAME', width: 240, align: 'left', sortable: true },
                { label: '县', name: 'COUNTYNAME', index: 'COUNTYNAME', width: 240, align: 'left', sortable: true },
                { label: '乡镇', name: 'TOWNNAME', index: 'TOWNNAME', width: 240, align: 'left', sortable: true },
                { label: '地理位置', name: 'LOCATION', index: 'LOCATION', width: 240, align: 'left', sortable: true },
                { label: '经度', name: 'LONGITUDE', index: 'LONGITUDE', width: 240, align: 'left', sortable: true },
                { label: '纬度', name: 'LATITUDE', index: 'LATITUDE', width: 240, align: 'left', sortable: true },

                { label: '野外编号', name: 'OUTDOORCODE', index: 'OUTDOORCODE', width: 240, align: 'left', sortable: true },
                { label: '室内编号', name: 'INDOORCODE', index: 'INDOORCODE', width: 240, align: 'left', sortable: true },
                { label: '灾害等级', name: 'DISASTERLEVEL', index: 'DISASTERLEVEL', width: 240, align: 'left', sortable: true },
                { label: '险情等级', name: 'DANGERLEVEL', index: 'DANGERLEVEL', width: 240, align: 'left', sortable: true },
                { label: 'X', name: 'X', index: 'X', width: 240, align: 'left', sortable: true },
                { label: 'Y', name: 'Y', index: 'Y', width: 240, align: 'left', sortable: true },
                { label: 'Z', name: 'Z', index: 'Z', width: 240, align: 'left', sortable: true },
                { label: '地下水类型', name: 'GROUNDWATERTYPE', index: 'GROUNDWATERTYPE', width: 240, align: 'left', sortable: true },
                { label: '防治建议', name: 'TREATMENTSUGGESTION', index: 'TREATMENTSUGGESTION', width: 240, align: 'left', sortable: true },
                { label: '构造部位', name: 'TECTONICREGION', index: 'TECTONICREGION', width: 240, align: 'left', sortable: true },
                { label: '监测建议', name: 'MONITORSUGGESTION', index: 'MONITORSUGGESTION', width: 240, align: 'left', sortable: true },
                { label: '今后变化趋势', name: 'STABLETREND', index: 'STABLETREND', width: 240, align: 'left', sortable: true },
                { label: '目前稳定程度', name: 'CURSTABLESTATUS', index: 'CURSTABLESTATUS', width: 240, align: 'left', sortable: true },
                { label: '威胁财产', name: 'THREATENASSETS', index: 'THREATENASSETS', width: 240, align: 'left', sortable: true },
                { label: '威胁人口', name: 'THREATENPEOPLE', index: 'THREATENPEOPLE', width: 240, align: 'left', sortable: true },
                { label: '隐患点', name: 'HIDDENDANGER', index: 'HIDDENDANGER', width: 240, align: 'left', sortable: true },
                { label: '灾害体类型', name: 'DISASTERTYPE', index: 'DISASTERTYPE', width: 240, align: 'left', sortable: true },
                { label: '毁坏房屋', name: 'DESTROYEDHOME', index: 'DESTROYEDHOME', width: 240, align: 'left', sortable: true },
                { label: '毁路', name: 'DESTROYEDROAD', index: 'DESTROYEDROAD', width: 240, align: 'left', sortable: true },
                { label: '毁渠', name: 'DESTROYEDCANAL', index: 'DESTROYEDCANAL', width: 240, align: 'left', sortable: true },
                ],
                viewrecords: true,
                rowNum: 100,
                rowList: [100, 200, 300],
                pager: "#gridPager1",
                sortname: 'UNIFIEDCODE',
                sortorder: 'desc',
                rownumbers: false,
                shrinkToFit: false,
                gridview: true,
                onSelectRow: function (rowId, status) {
                    selectedRowIndex = $('#' + this.id).getGridParam('selrow');
                },
                gridComplete: function () {
                    $('#' + this.id).setSelection(selectedRowIndex, false);
                }
            });
        }

    })
});


//中文字段替换成数据库字段名
function CreplaceE(UnionStatisticsSql) {
    for (var i = 0; i < dicJson.length; i++) {
        var reg1 = new RegExp(dicJson[i].key, "g");
        UnionStatisticsSql = UnionStatisticsSql.replace(reg1, dicJson[i].value);
    }
    return UnionStatisticsSql
}

//获取列名
function GetColumn(name) {
    for (var i = 0; i < dicJson.length; i++) {
        if (dicJson[i].key == name)
            return dicJson[i].value;
    }
    return name;
}

//转码
function HTMLDecoded(text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}

//是否是数字
function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}