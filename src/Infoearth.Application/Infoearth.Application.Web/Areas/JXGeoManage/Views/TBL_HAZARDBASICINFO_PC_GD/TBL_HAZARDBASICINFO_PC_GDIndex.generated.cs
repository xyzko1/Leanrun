﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Infoearth.Application.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO_PC_GD/TBL_HAZARDBASICINFO_PC_GDInde" +
        "x.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_PC_GD_TBL_HAZARDBASICINFO_PC_GDIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_PC_GD_TBL_HAZARDBASICINFO_PC_GDIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO_PC_GD\TBL_HAZARDBASICINFO_PC_GDIndex.cshtml"
  
    ViewBag.Title = "历史数据查询";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" id=\"GJCX\"");

WriteLiteral(" style=\"position:absolute;top:-120px;z-index:3;width:100%;transition:all 0.6s\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">项目类型:</span><div");

WriteLiteral(" id=\"PROJECTID\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">操作类型:</span><div");

WriteLiteral(" id=\"MODIFYTYPE\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">是否已核销:</span><div");

WriteLiteral(" id=\"shifouhexiao\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">是否已治理:</span><div");

WriteLiteral(" id=\"ISZLGCPNT\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">是否搬迁:</span><div");

WriteLiteral(" id=\"RELOCATION\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">开始时间:</span><input");

WriteLiteral(" id=\"BeginTime\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" style=\"width: 16%; display: none;\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy-MM-dd 00:00:00\' })\"");

WriteLiteral(" />\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">年度:</span><input");

WriteLiteral(" id=\"EndTime\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" onfocus=\"WdatePicker({ dateFmt: \'yyyy\' })\"");

WriteLiteral(" />\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"btn_Search_higher\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"cursor: pointer; color: white;padding:4px 4px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\r\n        </span>\r\n        <div");

WriteLiteral(" style=\"width:16%\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" id=\"btn_Reset\"");

WriteLiteral(" style=\"background:gray;border-color:gray;height:28px;padding:4px 12px; color: wh" +
"ite; cursor: pointer;\"");

WriteLiteral(">重置</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout2\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-north\"");

WriteLiteral(" id=\"ui_map\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"mapControls\"");

WriteLiteral(" style=\"height: 350px;\"");

WriteLiteral("></div>   \r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%;width:100%;margin-top:0px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(" style=\"height:40px;line-height:40px\"");

WriteLiteral(">\r\n                ");

WriteLiteral("\r\n                <div");

WriteLiteral(" style=\"float:right;height:40px;line-height:40px;display:flex;align-items: center" +
";\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;导出</a>\r\n                        <a");

WriteLiteral(" id=\"lr_detail\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ViewDetail()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>详情</a>\r\n                        <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"SearchEvent()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n                        <a");

WriteLiteral(" id=\"lr-colgrid\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColDataGrid()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-down\"");

WriteLiteral("></i>列表</a>\r\n                        <a");

WriteLiteral(" id=\"lr-colmap\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColMapDiv()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-up\"");

WriteLiteral("></i>地图</a>\r\n                    </div>\r\n                </div>\r\n                " +
"<div");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral(@"></div>
            </div>
        </div>
    </div>
</div>
<style>
    .ui-th-column, .ui-jqgrid .ui-jqgrid-htable th.ui-th-column {
        border-top: 1px solid #ccc
    }

    .spansa {
        padding: 0 20px !important;
        width: 9%;
        text-align: center;
        height: 28px;
        line-height: 28px;
        min-width: 113px
    }

    .divselect {
        width: 21%;
    }

    .spans {
        padding: 0 10px;
        width: 9%;
        text-align: center;
        height: 28px;
        line-height: 28px;
        min-width: 100px
    }

    .ui-select-text, .form-control {
        border-radius: 4px;
    }

    .ui-layout-resizer {
        background: #f5f5f5 !important;
    }

    #gridTable td {
        border-right: 1px solid #ccc !important;
    }

    #gridTable tr:nth-child(odd) {
        /*background:#DCDCDC*/
    }
</style>
");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var layout2NorthH = 1;\r\n    var authToken = getAuthorizationToken" +
"();\r\n    var flag = true;\r\n    var AreaVale = request(\'AreaVale\'), PROVINCE = \"\"" +
", CITY = \"\", COUNTY = \"\";\r\n    var queryJson = \'\';\r\n    $(function () {\r\n       " +
"// test();\r\n        mapshow = true;\r\n        //initControl();\r\n        InitialPa" +
"ge();\r\n        GetMapData();\r\n        GetGrid();\r\n        BindMapMarker();\r\n    " +
"    //高级查询点击事件\r\n        $(\"#btn_Search_higher\").click(function () {\r\n           " +
" SearchEvent();\r\n        })\r\n        //查询\r\n        $(\"#btn_Search\").click(functi" +
"on () {\r\n            SearchEvent();\r\n        })\r\n        $(\"#serch-btn\").click(f" +
"unction () {\r\n            if (flag) {\r\n                $(\"#GJCXH\").css(\"top\", 40" +
")\r\n                $(\"#fontfamily\").removeClass();\r\n                $(\"#fontfami" +
"ly\").addClass(\"fa fa-caret-down\")\r\n                flag = false\r\n            } e" +
"lse {\r\n                $(\"#GJCXH\").css(\"top\", -120)\r\n                $(\"#fontfam" +
"ily\").removeClass();\r\n                $(\"#fontfamily\").addClass(\"fa fa-caret-rig" +
"ht\")\r\n                flag = true\r\n            }\r\n        })\r\n        //重置\r\n    " +
"    $(\"#btn_Reset\").click(function () {\r\n            $(\"#PROJECTID .ui-select-te" +
"xt\").text(\" \");\r\n            $(\"#MODIFYTYPE .ui-select-text\").text(\" \");\r\n      " +
"      $(\"#shifouhexiao .ui-select-text\").text(\"\");\r\n            $(\"#ISZLGCPNT .u" +
"i-select-text\").text(\"\");\r\n            $(\"#RELOCATION.ui-select-text\").text(\"\");" +
"\r\n            $(\"#BeginTime\").val(\"\");\r\n            $(\"#EndTime\").val(\"\");\r\n\r\n  " +
"      });\r\n\r\n    });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        var isR" +
"esize = 0;\r\n        var count = 0;\r\n        var resized = 0;\r\n        $(\'#layout" +
"2\').layout({\r\n            applyDemoStyles: true,\r\n            onresize: function" +
" () {\r\n                resize();\r\n                if (isResize > 1) {\r\n         " +
"           resized = 1;\r\n                } else {\r\n                    if (count" +
" == 1 || resized == 0) {\r\n                        $(\'#layout2 .ui-layout-center\'" +
").height($(\'#layout2 .ui-layout-center\').height() - 18);\r\n                    }\r" +
"\n                }\r\n                count++;\r\n            }\r\n        });\r\n      " +
"  //resize重设布局;\r\n        $(window).resize(function (e) {\r\n            if (isResi" +
"ze < 10) {\r\n                isResize++;\r\n            }\r\n            resize();\r\n " +
"           e.stopPropagation();\r\n        });\r\n        function resize() {\r\n     " +
"       window.setTimeout(function () {\r\n                if (mapCtlExt != null) {" +
"\r\n                    mapCtlExt.setHeight($(\'#mapControls\').parent().height() - " +
"4);\r\n                }              \r\n                $(\'#layout2 .ui-layout-cen" +
"ter\').width($(\'#layout2 .ui-layout-center\').parent().width());\r\n                " +
"$(\'#layout2 .ui-layout-resizer\').width($(\'#layout2 .ui-layout-center\').parent()." +
"width());\r\n                $(\'#layout2 .ui-layout-center\').height($(\'#layout2\')." +
"height() - $(\'#layout2 .ui-layout-north\').height() - 8);\r\n                $(\'#gr" +
"idTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n                $(\'#gridTabl" +
"e\').setGridHeight($(\'#layout2 .ui-layout-center\').height() - 128 + 29 -6);\r\n    " +
"            $(\'#layout2 .ui-layout-center\').css(\'overflow\', \'hidden\');\r\n        " +
"    }, 0);\r\n        };\r\n        $(window).resize();\r\n        $(\'#layout2 .ui-lay" +
"out-center\').height($(\'#layout2 .ui-layout-center\').height() - 18);\r\n        lay" +
"out2NorthH = $(\"#layout2 .ui-layout-north\").height();\r\n        $(window).resize(" +
");\r\n\r\n    }\r\n\r\n    //加载地图marker\r\n    function BindMapMarker(queryJson) {\r\n      " +
" // var queryJson = $(\"#GJCXH\").getWebControls();\r\n        if (queryJson == unde" +
"fined) {\r\n            queryJson = {};\r\n        }\r\n        $.ajax({\r\n           u" +
"rl: \"../../api/TBL_HAZARDBASICINFO_PC_GDApi/GetHXMapList\",\r\n            data: { " +
"condition: JSON.stringify(WKTString), queryJson: JSON.stringify(queryJson) },\r\n " +
"           type: \"GET\",\r\n            beforeSend: function (a) {\r\n               " +
" if (authToken)\r\n                    a.setRequestHeader(\"Authorization\", authTok" +
"en);\r\n            },\r\n            success: function (dataList) {\r\n              " +
"  var data = eval(dataList);\r\n                var code=[];\r\n                var " +
"returnValue = [];\r\n                for (var i = 0; i < data.length; i++) {\r\n    " +
"                if (array_contain(code, data[i].PCUNIFIEDCODE) == false) {      " +
"               \r\n                        //详情页面\r\n                        var div" +
"html = \'<div style=\"font-weight: bold;\"></div>\';\r\n                        divhtm" +
"l += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10px;\">灾害类型：</spa" +
"n><span>\' + data[i].DISASTERTYPE + \'</span></div>\';\r\n                        div" +
"html += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10px;\">排查编号：</" +
"span><span>\' + data[i].PCUNIFIEDCODE + \'</span></div>\';\r\n                       " +
" divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10px;\">灾害点" +
"编号：</span><span>\' + data[i].UNIFIEDCODE + \'</span></div>\';\r\n                    " +
"    divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10px;\">" +
"隐患点状态：</span><span>\' + data[i].YHSTATE + \'</span></div>\';\r\n                     " +
"   divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:10px;\">威" +
"胁人口(人)：</span><span>\' + data[i].THREATENPEOPLE + \'</span></div>\';\r\n             " +
"           divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"margin-left:" +
"10px;\">威胁财产(万元)：</span><span>\' + data[i].INDIRECTLOSS + \'</span></div>\';\r\n      " +
"                  divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"margi" +
"n-left:10px;\">监测责任人：</span><span>\' + data[i].MONITORINGPEOPLE + \'</span></div>\';" +
"\r\n                        divhtml += \'<div style=\"margin-bottom:5px;\"><span styl" +
"e=\"margin-left:10px;\">监测责任人手机：</span><span>\' + data[i].PHONE + \'</span></div>\';\r" +
"\n                        divhtml += \'<div style=\"margin-bottom:5px;\"><span style" +
"=\"margin-left:10px;\">监测人：</span><span>\' + data[i].JCPEOPLE + \'</span></div>\';\r\n " +
"                       divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"" +
"margin-left:10px;\">监测人手机：</span><span>\' + data[i].PHONE1 + \'</span></div>\';\r\n   " +
"                     divhtml += \'<div style=\"margin-bottom:5px;\"><span style=\"ma" +
"rgin-left:10px;\">地理位置：</span><span>\' + data[i].LOCATION + \'</span></div>\';\r\n    " +
"                    divhtml += \'<span style=\"margin-right:20px; float:right; cur" +
"sor: pointer;\"><a onclick=\"MapViewDetail(\\\'\' + data[i].PCUNIFIEDCODE + \'\\\')\" hre" +
"f=\"#\" class=\"link-detail\">详细信息</a></span>\';\r\n                        var longitu" +
"de = 0, latitude = 0;\r\n                        if (data[i].LONGITUDE) {\r\n       " +
"                     longitude = parseFloat(data[i].LONGITUDE);\r\n               " +
"         }\r\n                        if (data[i].LATITUDE) {\r\n                   " +
"         latitude = parseFloat(data[i].LATITUDE);\r\n                        }\r\n  " +
"                      returnValue.push({ id: \"all\", url: \"../../Content/images/\"" +
" + data[i].DISASTERTYPE + \"-16.png\", location: [longitude, latitude], popupHtml:" +
" divhtml });\r\n\r\n                    }\r\n                }\r\n                mapCtl" +
"Ext.addMarker(returnValue);\r\n            }, error: function (e) {\r\n            }" +
",\r\n            cache: false\r\n        });\r\n\r\n    };\r\n\r\n    //获取点击Marker时对应的数据\r\n  " +
"  var isMarkerClick = false;\r\n    function getMarkerData(UNIFIEDCODE) {\r\n       " +
" isMarkerClick = true;\r\n        var datas = $(\'#gridTable\').jqGrid(\"getRowData\")" +
";\r\n        var count = 0;\r\n        $.each(datas, function (i, e) {\r\n            " +
"if (e.UNIFIEDCODE.trim().indexOf(UNIFIEDCODE) > -1) {\r\n                count = 1" +
";\r\n                $(\'#gridTable\').setSelection(i + 1);\r\n                $(\'#gri" +
"dTable tr\').eq(i + 1).focus();\r\n            }\r\n        });    \r\n    };\r\n\r\n    fu" +
"nction array_contain(arry, obj) {\r\n        if (arry == null || arry == undefined" +
" || arry.length == 0)\r\n            return false;\r\n        for (var i = 0; i < ar" +
"ry.length; i++) {\r\n            if (arry[i] == obj)\r\n                return true;" +
"\r\n        }\r\n        return false;\r\n    }\r\n    //加载地图\r\n    var mapCtlExt = null;" +
"\r\n    function GetMapData() {\r\n        mapCtlExt = $(\"#mapControls\").mapCtl(\r\n  " +
"            cfGetMapData({gdzbdbx:true})\r\n          );\r\n     };\r\n    //加载表格\r\n   " +
" function GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var queryJson " +
"= $(\"#GJCXH\").getWebControls();\r\n        if (AreaVale != \"\") {\r\n            var " +
"level = AreaVale.split(\',\')[1];\r\n            var code = AreaVale.split(\',\')[0];\r" +
"\n            if (level == 1) {\r\n                PROVINCE = code;\r\n              " +
"  CITY = \"\";\r\n                COUNTY = \"\";\r\n            } else if (level == 2) {" +
"\r\n                PROVINCE = code.substring(0, 2) + \"0000\";\r\n                CIT" +
"Y = code;\r\n                COUNTY = \"\";\r\n            } else if (level == 3) {\r\n " +
"               PROVINCE = code.substring(0, 2) + \"0000\";\r\n                CITY =" +
" code.substring(0, 4) + \"00\";\r\n                COUNTY = code;\r\n            }\r\n  " +
"      }\r\n        queryJson[\"PROVINCE\"] = PROVINCE;\r\n        queryJson[\"CITY\"] = " +
"CITY;\r\n        queryJson[\"COUNTY\"] = COUNTY;    \r\n        var $gridTable = $(\'#g" +
"ridTable\');\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n        " +
"    postData: { queryJson: JSON.stringify(queryJson), condition: JSON.stringify(" +
"WKTString) },\r\n            height: $(window).height() - 524,\r\n            url: \"" +
"../../api/TBL_HAZARDBASICINFO_PC_GDApi/GetSinglePastPageListJson\",\r\n            " +
"datatype: \"json\",\r\n            loadBeforeSend: function (a) {\r\n                i" +
"f (authToken != null)\r\n                    a.setRequestHeader(\"Authorization\", a" +
"uthToken);\r\n            },\r\n            colModel: [\r\n                { label: \'灾" +
"害体类型\', name: \'DISASTERTYPE\', index: \'DISASTERTYPE\', width: 200, align: \'left\', s" +
"ortable: true },\r\n                { label: \'排查编号\', name: \'PCUNIFIEDCODE\', index:" +
" \'PCUNIFIEDCODE\', width: 200, align: \'left\', sortable: true },\r\n                " +
"{ label: \'统一编号\', name: \'UNIFIEDCODE\', index: \'UNIFIEDCODE\', width: 350, align: \'" +
"left\', sortable: true, hidden: true},\r\n                { label: \'省名称\', name: \'PR" +
"OVINCENAME\', index: \'PROVINCENAME\', width: 150, align: \'left\', sortable: true }," +
"\r\n                { label: \'省编码\', name: \'PROVINCE\', index: \'PROVINCE\', width: 15" +
"0, align: \'left\', sortable: true, hidden: true },\r\n                { label: \'市名称" +
"\', name: \'CITYNAME\', index: \'CITYNAME\', width: 150, align: \'left\', sortable: tru" +
"e },\r\n                { label: \'市编码\', name: \'CITY\', index: \'CITY\', width: 150, a" +
"lign: \'left\', sortable: true, hidden: true },\r\n                { label: \'县名称\', n" +
"ame: \'COUNTYNAME\', index: \'COUNTYNAME\', width: 150, align: \'left\', sortable: tru" +
"e }, \r\n                { label: \'县编码\', name: \'COUNTY\', index: \'COUNTY\', width: 1" +
"50, align: \'left\', sortable: true, hidden: true },     \r\n                { label" +
": \'地理位置\', name: \'LOCATION\', index: \'LOCATION\', width: 150, align: \'left\', sortab" +
"le: true },\r\n                { label: \'隐患点状态\', name: \'YHSTATE\', index: \'YHSTATE\'" +
", width: 150, align: \'left\', sortable: true },           \r\n                { lab" +
"el: \'经度\', name: \'LONGITUDE\', index: \'LONGITUDE\', width: 100, align: \'left\', sort" +
"able: true, hidden: true },\r\n                { label: \'纬度\', name: \'LATITUDE\', in" +
"dex: \'LATITUDE\', width: 100, align: \'left\', sortable: true, hidden: true },\r\n   " +
"             { label: \'填表时间\', name: \'FILETIME\', index: \'FILETIME\', width: 150, a" +
"lign: \'left\', sortable: true, hidden: true },\r\n            ],\r\n            viewr" +
"ecords: true,\r\n            rowNum: 30,\r\n            rowList: [30, 50, 100],\r\n   " +
"         pager: \"#gridPager\",\r\n            sortname: \'FILETIME\',\r\n            so" +
"rtorder: \'desc\',\r\n            rownumbers: true,\r\n            shrinkToFit: false," +
"\r\n            gridview: true,\r\n            onSelectRow: function (rowId, status)" +
" {\r\n                selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r" +
"\n                var dt = $gridTable.jqGrid(\"getRowData\", rowId);\r\n             " +
"   var data = [];\r\n                var longitude=0, latitude=0;\r\n               " +
" if (dt.LONGITUDE) {\r\n                    longitude = parseFloat(dt.LONGITUDE);\r" +
"\n                }\r\n                if (dt.LATITUDE) {\r\n                    lati" +
"tude = parseFloat(dt.LATITUDE);\r\n                }\r\n                data.push({ " +
"longitude: longitude, latitude: latitude });\r\n                mapCtlExt.addLocat" +
"ion(data,true);\r\n            },\r\n            gridComplete: function () {\r\n      " +
"          $(\'#\' + this.id).setSelection(selectedRowIndex, false);\r\n            }" +
"\r\n        });\r\n    }\r\n\r\n    //详情\r\n    function ViewDetail() {\r\n        var PCUNI" +
"FIEDCODE = $(\"#gridTable\").jqGridRowValue(\'PCUNIFIEDCODE\');\r\n        if (checked" +
"Row(PCUNIFIEDCODE)) {\r\n            newTab({\r\n                id: \"DZLSSJCX\",\r\n  " +
"              url: \'/JXGeoManage/TBL_HAZARDBASICINFO_PC_GD/TBL_HAZARDBASICINFO_P" +
"C_GDForm?keyValue=\' + PCUNIFIEDCODE,\r\n            });\r\n        }\r\n    }\r\n    //地" +
"图详情\r\n    function MapViewDetail(PCUNIFIEDCODE) {\r\n        if (checkedRow(PCUNIFI" +
"EDCODE)) {\r\n            newTab({\r\n                id: \"DZLSSJCX\",\r\n             " +
"   url: \'/JXGeoManage/TBL_HAZARDBASICINFO_PC_GD/TBL_HAZARDBASICINFO_PC_GDForm?ke" +
"yValue=\' + PCUNIFIEDCODE,\r\n            });            \r\n        }\r\n    }\r\n    //" +
"查询表格函数\r\n    function SearchEvent(data) {\r\n        if (data) {\r\n            query" +
"Json = data;\r\n        }      \r\n        BindMapMarker(queryJson);\r\n        $(\"#gr" +
"idTable\").jqGrid(\'setGridParam\', {\r\n            postData: { condition: JSON.stri" +
"ngify(WKTString), queryJson: JSON.stringify(queryJson) },\r\n            loadBefor" +
"eSend: function (a) {\r\n                a.setRequestHeader(\"Authorization\", authT" +
"oken);\r\n            },\r\n            url: \"../../api/TBL_HAZARDBASICINFO_PC_GDApi" +
"/GetSinglePastPageListJson\",\r\n            page: 1,\r\n            //stype:\'Post\',\r" +
"\n        }).trigger(\'reloadGrid\');\r\n    }\r\n    function ColDataGrid() {\r\n       " +
" var centerHeight = $(\"#layout2\").height();\r\n        var layout2 = $(\'#layout2\')" +
".layout();\r\n        if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-down\")) {\r\n     " +
"       var northH = centerHeight - 45;\r\n            layout2.sizePane(\"north\", no" +
"rthH);\r\n            $(\"#lr-colgrid i\").removeClass(\"fa-chevron-down\");\r\n        " +
"    $(\"#lr-colgrid i\").addClass(\"fa-chevron-up\");\r\n            if ($(\"#lr-colmap" +
" i\").hasClass(\"fa-chevron-down\")) {\r\n                $(\"#lr-colmap i\").removeCla" +
"ss(\"fa-chevron-down\");\r\n                $(\"#lr-colmap i\").addClass(\"fa-chevron-u" +
"p\");\r\n            }\r\n        }\r\n        else {\r\n            layout2.sizePane(\"no" +
"rth\", layout2NorthH);\r\n            $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up" +
"\");\r\n            $(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\r\n        }\r\n   " +
"     mapCtlExt.updateSize();\r\n    }\r\n    function ColMapDiv() {\r\n        var lay" +
"out2 = $(\'#layout2\').layout();\r\n        if ($(\"#lr-colmap i\").hasClass(\"fa-chevr" +
"on-up\")) {\r\n            layout2.sizePane(\"north\", 1);\r\n            $(\"#lr-colmap" +
" i\").removeClass(\"fa-chevron-up\");\r\n            $(\"#lr-colmap i\").addClass(\"fa-c" +
"hevron-down\");\r\n            if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-up\")) {\r" +
"\n                $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\");\r\n             " +
"   $(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\r\n            }\r\n        }\r\n  " +
"      else {\r\n            layout2.sizePane(\"north\", layout2NorthH);\r\n           " +
" $(\"#lr-colmap i\").removeClass(\"fa-chevron-down\");\r\n            $(\"#lr-colmap i\"" +
").addClass(\"fa-chevron-up\");\r\n            if (mapCtlExt != null) {\r\n            " +
"    mapCtlExt.setHeight($(\"#mapControl\").parent().height() - 32 - 4);\r\n         " +
"   }\r\n        }\r\n        mapCtlExt.updateSize();\r\n    }\r\n\r\n      //初始化控件\r\n      " +
"function initControl() {\r\n         \r\n      }\r\n    \r\n      //excel导出\r\n      funct" +
"ion reload() {\r\n          var queryJson = $(\"#GJCXH\").getWebControls();  \r\n     " +
"     location.href = \"../../TBL_HAZARDBASICINFO_PC_GD/Exportexcel?queryJson=\" + " +
"JSON.stringify(queryJson);\r\n          //$.ajax({\r\n          //    url: \"../../ap" +
"i/TBL_HAZARDBASICINFO_PC_GDApi/Exportexcel\",\r\n          //    data: {queryJson: " +
"JSON.stringify(queryJson) },\r\n          //    type: \"GET\",\r\n          //    befo" +
"reSend: function (a) {\r\n          //        if (authToken)\r\n          //        " +
"    a.setRequestHeader(\"Authorization\", authToken);\r\n          //    },\r\n       " +
"   //    success: function (data) {\r\n                 \r\n          //    }, error" +
": function (e) {\r\n          //    },\r\n          //    cache: false\r\n          //" +
"});\r\n      }\r\n     \r\n      function test() {\r\n          var queryJsons = {};\r\n  " +
"        queryJsons[\"Year\"] = \'2016\';\r\n          queryJsons[\"EndMonth\"] = \'5\';\r\n " +
"         queryJsons[\"StartMonth\"] = \'2\';\r\n          $.ajax({\r\n              url:" +
" \"../../api/TBL_DZHJSB_DZZHQKMONTH_GDApi/Getdata\",\r\n              data: { queryJ" +
"son: JSON.stringify(queryJsons) },\r\n              type: \"GET\",\r\n              be" +
"foreSend: function (a) {\r\n                  if (authToken)\r\n                    " +
"  a.setRequestHeader(\"Authorization\", authToken);\r\n              },\r\n           " +
"   success: function () {\r\n\r\n              }\r\n          })\r\n      }\r\n</script>\r\n" +
"");

});

        }
    }
}
#pragma warning restore 1591