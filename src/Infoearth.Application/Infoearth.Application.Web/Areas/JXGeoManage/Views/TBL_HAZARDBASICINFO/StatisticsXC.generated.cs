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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO/StatisticsXC.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_StatisticsXC_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_StatisticsXC_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\StatisticsXC.cshtml"
  
    ViewBag.Title = "常用统计图表";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\StatisticsXC.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/scripts/plugins/echarts/echarts.min.js"
));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(@">

    .container-fluid {
        padding-left:0;
        padding-right:0;
    } 
    .row {
        margin-bottom: 20px;
    }
    .echartH {
        height:400px;
        border-width:1px;
        border-style:solid;
        border-color:rgba(168,226,255,1);
        border-radius:10px;
        padding:10px;
    }
</style>
<div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%; width: 100%; display:none\"");

WriteLiteral(">\r\n    \r\n    <div");

WriteLiteral(" id=\"myTabContent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" style=\"height:100%\"");

WriteLiteral(">\r\n        \r\n            <div");

WriteLiteral(" style=\"width:100%;height:50px;line-height: 50px;margin-left:20px\"");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\r\n                <table>\r\n                    <tr>\r\n                        <td" +
"");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                           统计年度：\r\n                        </td>\r\n             " +
"           <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral("  type=\"text\"");

WriteLiteral(" id=\"Static_Year\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({dateFmt:\'yyyy\'})\"");

WriteLiteral(" />\r\n                        </td>\r\n                        <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>统计</a>\r\n                        </td>\r\n                    </tr>\r\n          " +
"      </table>\r\n            </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n    \r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart1\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart2\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart3\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart4\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart5\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart6\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart7\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n        <div");

WriteLiteral(" class=\"col-md-6\"");

WriteLiteral("><div");

WriteLiteral(" id=\"echart8\"");

WriteLiteral(" class=\"echartH\"");

WriteLiteral("></div></div>\r\n    </div>\r\n</div>\r\n");

DefineSection("Scripts", () => {

            
            #line 68 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\StatisticsXC.cshtml"
 
            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    function AcceptClick() {\r\n        learun.dialogClose();\r\n        " +
"return getSelectVal();\r\n    }\r\n    var myChart1 = null;\r\n    var myChart2 = null" +
";\r\n    var myChart3 = null;\r\n    var myChart4 = null;\r\n    var myChart5 = null;\r" +
"\n    var myChart6 = null;\r\n    var myChart7 = null;\r\n    var myChart8 = null;\r\n " +
"   var authToken = getAuthorizationToken();\r\n    var NowName = \'\';\r\n    $(functi" +
"on () {\r\n        //GetCurrentUserCode();\r\n        var nowYear = new Date();\r\n   " +
"     $(\"#Static_Year\").val(nowYear.getFullYear());\r\n        var year = $(\"#Stati" +
"c_Year\").val();\r\n        getChartData(year);\r\n        $(window).resize(function " +
"(e) {\r\n            resize();\r\n            e.stopPropagation();\r\n        });\r\n   " +
"     \r\n        //统计点击事件\r\n        $(\"#btn_Search\").click(function () {\r\n         " +
"   myChart1.clear();\r\n            myChart2.clear();\r\n            myChart3.clear(" +
");\r\n            myChart4.clear();\r\n            myChart5.clear();\r\n            my" +
"Chart6.clear();\r\n            myChart7.clear();\r\n            myChart8.clear();\r\n " +
"           getChartData($(\"#Static_Year\").val());\r\n        });\r\n    });\r\n    fun" +
"ction resize() {\r\n        if (!!myChart1) {\r\n            myChart1.resize();\r\n   " +
"         myChart2.resize();\r\n            myChart3.resize();\r\n            myChart" +
"4.resize();\r\n            myChart5.resize();\r\n            myChart6.resize();\r\n   " +
"         myChart7.resize();\r\n            myChart8.resize();\r\n        }\r\n    }\r\n " +
"   \r\n    //var colorArr = [\"#123456\", \"#7b74d2\", \"#008cee\", \"cc74d2\", \"#d274b6\"," +
" \"#d27485\", \"#d29574\", \"#d2bc74\", \"#ced274\", \"#b5d274\", \"#93d274\", \"#74d2b2\", \"#" +
"8cbab5\", \"#ee47f0\", \"#8d4bf1\", \"#f1c74b\", \"#a1e236\"];\r\n    var colorArr = [\"#123" +
"456\", \"#008cee\", \"#d274b6\", \"#d29574\"];\r\n    //加载图表\r\n    function getChartData(y" +
"ear) {\r\n        var queryJson = {};\r\n        //queryJson[\"PROJECTTYPE\"] = \"调查\";\r" +
"\n        //queryJson[\"YEAR\"] = year;\r\n\r\n        $.ajax({\r\n            url: \'../." +
"./api/TBL_HAZARDBASICINFOApi/GetStatisticsByZHD?queryJson=\' + JSON.stringify(que" +
"ryJson),\r\n            beforeSend: function (request) {\r\n                request." +
"setRequestHeader(\"Authorization\", authToken);\r\n            },\r\n            async" +
": true,\r\n            type: \"GET\",\r\n            success: function (data) {\r\n     " +
"           var chartBarData1 = {\r\n                    title: NowName + \"地质灾害点统计\"" +
",\r\n                    legend: {},\r\n                    xAxis: {\r\n              " +
"          type: \'category\',\r\n                        data: data.columnList,\r\n   " +
"                     axisLabel: {\r\n                            interval: 0,\r\n   " +
"                         rotate: 45,\r\n                            show: true,\r\n " +
"                           //splitNumber: 15,\r\n                            textS" +
"tyle: {\r\n\r\n                            }\r\n                        }\r\n           " +
"         },\r\n                    yAxis: [{ type: \'value\' }],\r\n                  " +
"  grid: {\r\n                        \"borderWidth\": 0,\r\n                        to" +
"p: 60, right: 80,\r\n                        containLabel: true\r\n                 " +
"   },\r\n                    toolbox: {\r\n                        show: true,\r\n    " +
"                    feature: {\r\n                            saveAsImage: {\r\n    " +
"                            show: true,\r\n                            }\r\n        " +
"                },\r\n                        right:\'20\'\r\n                    },\r\n" +
"                    series: [{\r\n                        name: \"\",\r\n             " +
"           type: \'bar\',\r\n                        data: data.dataList[0].data,\r\n " +
"                       itemStyle: { normal: { color: function (params) { return " +
"colorArr[0]; } } }\r\n                    }]\r\n                };\r\n                " +
"myChart1 = initMonitorChart(\"echart1\", chartBarData1);\r\n            }\r\n        }" +
");\r\n\r\n        $.ajax({\r\n            url: \"../../api/TBL_HAZARDBASICINFOApi/GetHa" +
"zardStatisticsJson2?queryJson=\" + JSON.stringify(queryJson),\r\n            before" +
"Send: function (request) {\r\n                request.setRequestHeader(\"Authorizat" +
"ion\", authToken);\r\n            },\r\n            //data: { queryJson: JSON.stringi" +
"fy({ \"PROVINCE\": DefalutCode, \"PROVINCENAME\": regionName, \"Static_Unit\": \"市\" }) " +
"},\r\n            async: true,\r\n            type: \"GET\",\r\n            success: fun" +
"ction (data) {\r\n                var datas = [];\r\n                var dataSeries " +
"= [];\r\n                var zhdSeries = [];\r\n                for (a in data.resul" +
"t[0]) {\r\n                    datas.push({ name: a, value: data.result[0][a] });\r" +
"\n                    dataSeries.push(a);\r\n                }\r\n                zhd" +
"Series.push({\r\n                    name: \"灾害点\",\r\n                    type: \"pie\"" +
",\r\n                    data: datas\r\n                })\r\n                myChart2" +
" = echarts.init(document.getElementById(\"echart2\"));\r\n                //指定图表配置数据" +
"              \r\n                option = {\r\n                    title: {\r\n      " +
"                  left: \'left\',\r\n                        text: NowName + \'地质灾害类型" +
"统计\',\r\n                        textStyle: {\r\n                            color: \'" +
"#333\',\r\n                            fontSize: 16\r\n                        }\r\n   " +
"                 },\r\n                    tooltip: {\r\n                        tri" +
"gger: \'item\',\r\n                        formatter: \"{a}<br/>{b}:{c}({d}%)\"\r\n     " +
"               },\r\n                    legend: {\r\n                        orient" +
": \'vertical\',\r\n                        x: \'left\',\r\n                        y: 30" +
",\r\n                        padding: [5, 15, 5, 5],\r\n                        data" +
": dataSeries\r\n                    },\r\n                    grid: {\r\n             " +
"           \"borderWidth\": 0,\r\n                        top: 60, right: 80,\r\n     " +
"                   containLabel: true\r\n                    },\r\n                 " +
"   toolbox: {\r\n                        show: true,\r\n                        feat" +
"ure: {\r\n                            saveAsImage: {\r\n                            " +
"    show: true,\r\n                                excludeComponents: [\'toolbox\']," +
"\r\n                                pixelRatio: 2\r\n                            }\r\n" +
"                        },\r\n                        right: \'20\'\r\n               " +
"     },\r\n                    series: zhdSeries\r\n                }\r\n             " +
"   myChart2.setOption(option, true);\r\n            }\r\n        })\r\n\r\n        $.aja" +
"x({\r\n            url: \'../../api/TBL_HAZARDBASICINFOApi/GetStatisticsByZQDJ?quer" +
"yJson=\' + JSON.stringify(queryJson),\r\n            beforeSend: function (request)" +
" {\r\n                request.setRequestHeader(\"Authorization\", authToken);\r\n     " +
"       },\r\n            async: true,\r\n            type: \"GET\",\r\n            succe" +
"ss: function (data) {\r\n                var list1 = data.dataList[0].data;\r\n     " +
"           for (var item1 in list1) {\r\n                    if (list1[item1] == n" +
"ull) {\r\n                        list1[item1] = 0;\r\n                    }\r\n      " +
"          }\r\n                var list2 = data.dataList[1].data;\r\n               " +
" for (var item2 in list2) {\r\n                    if (list2[item2] == null) {\r\n  " +
"                      list2[item2] = 0;\r\n                    }\r\n                " +
"}\r\n                var list3 = data.dataList[2].data;\r\n                for (var " +
"item3 in list3) {\r\n                    if (list3[item3] == null) {\r\n            " +
"            list3[item3] = 0;\r\n                    }\r\n                }\r\n       " +
"         var list4 = data.dataList[3].data;\r\n                for (var item4 in l" +
"ist4) {\r\n                    if (list4[item4] == null) {\r\n                      " +
"  list4[item4] = 0;\r\n                    }\r\n                }\r\n                v" +
"ar chartBarData3 = {\r\n                    title: NowName + \"灾情等级统计\",\r\n          " +
"          legend: {},\r\n                    toolbox: {\r\n                        s" +
"how: true,\r\n                        feature: {\r\n                            save" +
"AsImage: {}\r\n                        },\r\n                        right: \'20\'\r\n  " +
"                  },\r\n                    xAxis: {\r\n                        type" +
": \'category\',\r\n                        data: data.columnList,\r\n                 " +
"       axisLabel: {}\r\n                    },\r\n                    yAxis: [{ type" +
": \'value\' }],\r\n                    series: [\r\n{\r\n            name: data.dataList" +
"[0].name,\r\n            type: \'bar\',\r\n            stack: \'weatherStation\',\r\n     " +
"       data: list1,\r\n            itemStyle: { normal: { color: function (params)" +
" { return colorArr[0]; } } }\r\n},\r\n{\r\n    name: data.dataList[1].name,\r\n    type:" +
" \'bar\',\r\n    stack: \'weatherStation\',\r\n    data: list2,\r\n    itemStyle: { normal" +
": { color: function (params) { return colorArr[1]; } } }\r\n},\r\n{\r\n    name: data." +
"dataList[2].name,\r\n    type: \'bar\',\r\n    stack: \'weatherStation\',\r\n    data: lis" +
"t3,\r\n    itemStyle: { normal: { color: function (params) { return colorArr[2]; }" +
" } }\r\n},\r\n{\r\n    name: data.dataList[3].name,\r\n    type: \'bar\',\r\n    stack: \'wea" +
"therStation\',\r\n    data: list4,\r\n    itemStyle: { normal: { color: function (par" +
"ams) { return colorArr[3]; } } }\r\n}\r\n                    ]\r\n                };\r\n" +
"                //for (var i = 0; i < data.dataList.length; i++) {\r\n            " +
"    //    var obj = {\r\n                //        name: data.dataList[i].name,\r\n " +
"               //        type: \'bar\',\r\n                //        stack: \'weather" +
"Station\',\r\n                //        data: data.dataList[i].data,\r\n             " +
"   //        itemStyle: { normal: { color: function (params) { return colorArr[i" +
"]; } } }\r\n                //    }\r\n                //    chartBarData3.series.pu" +
"sh(obj);\r\n                //}\r\n                chartBarData3.legend = [\'特大型\', \'大" +
"型\',\'中型\',\'小型\'];\r\n                myChart3 = initMonitorChart(\"echart3\", chartBarD" +
"ata3);\r\n\r\n            }\r\n        });\r\n\r\n        $.ajax({\r\n            url: \'../." +
"./api/TBL_HAZARDBASICINFOApi/GetStatisticsByXQDJ?queryJson=\' + JSON.stringify(qu" +
"eryJson),\r\n            beforeSend: function (request) {\r\n                request" +
".setRequestHeader(\"Authorization\", authToken);\r\n            },\r\n            asyn" +
"c: true,\r\n            type: \"GET\",\r\n            success: function (data) {\r\n    " +
"            var list1 = data.dataList[0].data;\r\n                for (var item1 i" +
"n list1) {\r\n                    if (list1[item1] == null) {\r\n                   " +
"     list1[item1] = 0;\r\n                    }\r\n                }\r\n              " +
"  var list2 = data.dataList[1].data;\r\n                for (var item2 in list2) {" +
"\r\n                    if (list2[item2] == null) {\r\n                        list2" +
"[item2] = 0;\r\n                    }\r\n                }\r\n                var list" +
"3 = data.dataList[2].data;\r\n                for (var item3 in list3) {\r\n        " +
"            if (list3[item3] == null) {\r\n                        list3[item3] = " +
"0;\r\n                    }\r\n                }\r\n                var list4 = data.d" +
"ataList[3].data;\r\n                for (var item4 in list4) {\r\n                  " +
"  if (list4[item4] == null) {\r\n                        list4[item4] = 0;\r\n      " +
"              }\r\n                }\r\n                var chartBarData4 = {\r\n     " +
"               title: NowName + \"险情等级统计\",\r\n                    legend: {},\r\n    " +
"                toolbox: {\r\n                        show: true,\r\n               " +
"         feature: {\r\n                            saveAsImage: {}\r\n              " +
"          },\r\n                        right: \'20\'\r\n                    },\r\n     " +
"               xAxis: {\r\n                        type: \'category\',\r\n            " +
"            data: data.columnList,\r\n                        axisLabel: {}\r\n     " +
"               },\r\n                    yAxis: [{ type: \'value\' }],\r\n            " +
"        series: [\r\n                            {\r\n                              " +
"  name: data.dataList[0].name,\r\n                                type: \'bar\',\r\n  " +
"                              stack: \'weatherStation\',\r\n                        " +
"        data: list1,\r\n                                itemStyle: { normal: { col" +
"or: function (params) { return colorArr[0]; } } }\r\n                            }" +
",\r\n                            {\r\n                                name: data.dat" +
"aList[1].name,\r\n                                type: \'bar\',\r\n                  " +
"              stack: \'weatherStation\',\r\n                                data: li" +
"st2,\r\n                                itemStyle: { normal: { color: function (pa" +
"rams) { return colorArr[1]; } } }\r\n                            },\r\n             " +
"               {\r\n                                name: data.dataList[2].name,\r\n" +
"                                type: \'bar\',\r\n                                st" +
"ack: \'weatherStation\',\r\n                                data: list3,\r\n          " +
"                      itemStyle: { normal: { color: function (params) { return c" +
"olorArr[2]; } } }\r\n                            },\r\n                            {" +
"\r\n                                name: data.dataList[3].name,\r\n                " +
"                type: \'bar\',\r\n                                stack: \'weatherSta" +
"tion\',\r\n                                data: list4,\r\n                          " +
"      itemStyle: { normal: { color: function (params) { return colorArr[3]; } } " +
"}\r\n                            }\r\n                    ]\r\n                };\r\n\r\n " +
"               chartBarData4.legend = [\'特大型\', \'大型\', \'中型\', \'小型\'];\r\n              " +
"  myChart4 = initMonitorChart(\"echart4\", chartBarData4);\r\n\r\n            }\r\n     " +
"   });\r\n\r\n        $.ajax({\r\n            url: \'../../api/TBL_HAZARDBASICINFOApi/G" +
"etStatisticsByGMDJ?queryJson=\' + JSON.stringify(queryJson),\r\n            beforeS" +
"end: function (request) {\r\n                request.setRequestHeader(\"Authorizati" +
"on\", authToken);\r\n            },\r\n            async: true,\r\n            type: \"G" +
"ET\",\r\n            success: function (data) {\r\n                var list1 = data.d" +
"ataList[0].data;\r\n                for (var item1 in list1) {\r\n                  " +
"  if (list1[item1] == null) {\r\n                        list1[item1] = 0;\r\n      " +
"              }\r\n                }\r\n                var list2 = data.dataList[1]" +
".data;\r\n                for (var item2 in list2) {\r\n                    if (list" +
"2[item2] == null) {\r\n                        list2[item2] = 0;\r\n                " +
"    }\r\n                }\r\n                var list3 = data.dataList[2].data;\r\n  " +
"              for (var item3 in list3) {\r\n                    if (list3[item3] =" +
"= null) {\r\n                        list3[item3] = 0;\r\n                    }\r\n   " +
"             }\r\n                var list4 = data.dataList[3].data;\r\n            " +
"    for (var item4 in list4) {\r\n                    if (list4[item4] == null) {\r" +
"\n                        list4[item4] = 0;\r\n                    }\r\n             " +
"   }\r\n                var chartBarData5 = {\r\n                    title: NowName " +
"+ \"灾害规模等级统计\",\r\n                    legend: {},\r\n                    toolbox: {\r\n" +
"                        show: true,\r\n                        feature: {\r\n       " +
"                     saveAsImage: {}\r\n                        },\r\n              " +
"          right: \'40\'\r\n                    },\r\n                    xAxis: {\r\n   " +
"                     type: \'category\',\r\n                        data: data.colum" +
"nList,\r\n                        axisLabel: {}\r\n                    },\r\n         " +
"           yAxis: [{ type: \'value\' }],\r\n                    series: [\r\n         " +
"                   {\r\n                                name: data.dataList[0].nam" +
"e,\r\n                                type: \'bar\',\r\n                              " +
"  stack: \'weatherStation\',\r\n                                data: list1,\r\n      " +
"                          itemStyle: { normal: { color: function (params) { retu" +
"rn colorArr[0]; } } }\r\n                            },\r\n                         " +
"   {\r\n                                name: data.dataList[1].name,\r\n            " +
"                    type: \'bar\',\r\n                                stack: \'weathe" +
"rStation\',\r\n                                data: list2,\r\n                      " +
"          itemStyle: { normal: { color: function (params) { return colorArr[1]; " +
"} } }\r\n                            },\r\n                            {\r\n          " +
"                      name: data.dataList[2].name,\r\n                            " +
"    type: \'bar\',\r\n                                stack: \'weatherStation\',\r\n    " +
"                            data: list3,\r\n                                itemSt" +
"yle: { normal: { color: function (params) { return colorArr[2]; } } }\r\n         " +
"                   },\r\n                            {\r\n                          " +
"      name: data.dataList[3].name,\r\n                                type: \'bar\'," +
"\r\n                                stack: \'weatherStation\',\r\n                    " +
"            data: list4,\r\n                                itemStyle: { normal: {" +
" color: function (params) { return colorArr[3]; } } }\r\n                         " +
"   }\r\n                    ]\r\n                };\r\n\r\n                chartBarData5" +
".legend = [\'特大型\', \'大型\', \'中型\', \'小型\'];\r\n                myChart5 = initMonitorChar" +
"t(\"echart5\", chartBarData5);\r\n\r\n            }\r\n        });\r\n\r\n        $.ajax({\r\n" +
"            url: \'../../api/TBL_HAZARDBASICINFOApi/GetStatisticsByZLGC?queryJson" +
"=\' + JSON.stringify(queryJson),\r\n            beforeSend: function (request) {\r\n " +
"               request.setRequestHeader(\"Authorization\", authToken);\r\n          " +
"  },\r\n            //async: false,\r\n            type: \"GET\",\r\n            success" +
": function (data) {\r\n                var chartBarData6 = {\r\n                    " +
"title: NowName + \"治理工程统计\",\r\n                    legend: {},\r\n                   " +
" toolbox: {\r\n                        show: true,\r\n                        featur" +
"e: {\r\n                            saveAsImage: {}\r\n                        },\r\n " +
"                       right: \'20\'\r\n                    },\r\n                    " +
"xAxis: {\r\n                        type: \'category\',\r\n                        dat" +
"a: data.columnList,\r\n                        axisLabel: {\r\n                     " +
"       interval: 0,\r\n                            rotate: 45,\r\n                  " +
"          show: true,\r\n                            splitNumber: 15,\r\n           " +
"                 textStyle: {\r\n\r\n                            }\r\n                " +
"        }\r\n                    },\r\n                    yAxis: [{ type: \'value\' }" +
"],\r\n                    series: [{\r\n                        name: \"\",\r\n         " +
"               type: \'bar\',\r\n                        data: data.dataList[0].data" +
",\r\n                        itemStyle: { normal: { color: function (params) { ret" +
"urn colorArr[0]; } } }\r\n                    }]\r\n                };\r\n\r\n          " +
"      myChart6 = initMonitorChart(\"echart6\", chartBarData6);\r\n\r\n            }\r\n " +
"       });\r\n\r\n        $.ajax({\r\n            url: \'../../api/TBL_HAZARDBASICINFOA" +
"pi/GetStatisticsByBABR?queryJson=\' + JSON.stringify(queryJson),\r\n            bef" +
"oreSend: function (request) {\r\n                request.setRequestHeader(\"Authori" +
"zation\", authToken);\r\n            },\r\n            //async: false,\r\n            t" +
"ype: \"GET\",\r\n            success: function (data) {\r\n                var chartBa" +
"rData7 = {\r\n                    title: NowName + \"搬迁避让统计\",\r\n                    " +
"legend: {},\r\n                    toolbox: {\r\n                        right: \'30\'" +
"\r\n                    },\r\n                    xAxis: {\r\n                        " +
"type: \'category\',\r\n                        data: data.columnList,\r\n             " +
"           axisLabel: {\r\n                            interval: 0,\r\n             " +
"               rotate: 45,\r\n                            show: true,\r\n           " +
"                 splitNumber: 15,\r\n                            textStyle: {\r\n\r\n " +
"                           }\r\n                        }\r\n                    },\r" +
"\n                    yAxis: [{ type: \'value\' }],\r\n                    series: [{" +
"\r\n                        name: \"\",\r\n                        type: \'bar\',\r\n     " +
"                   data: data.dataList[0].data,\r\n                        itemSty" +
"le: { normal: { color: function (params) { return colorArr[0]; } } }\r\n          " +
"          }]\r\n                };\r\n\r\n                myChart7 = initMonitorChart(" +
"\"echart7\", chartBarData7);\r\n\r\n            }\r\n        });\r\n\r\n        $.ajax({\r\n  " +
"          url: \'../../api/TBL_HAZARDBASICINFOApi/GetStatisticsByXH?queryJson=\' +" +
" JSON.stringify(queryJson),\r\n            beforeSend: function (request) {\r\n     " +
"           request.setRequestHeader(\"Authorization\", authToken);\r\n            }," +
"\r\n            //async: false,\r\n            type: \"GET\",\r\n            success: fu" +
"nction (data) {\r\n                var chartBarData8 = {\r\n                    titl" +
"e: NowName + \"拟销号点统计\",\r\n                    legend: {},\r\n                    too" +
"lbox: {\r\n                        right: \'20\'\r\n                    },\r\n          " +
"          xAxis: {\r\n                        type: \'category\',\r\n                 " +
"       data: data.columnList,\r\n                        axisLabel: {\r\n           " +
"                 interval: 0,\r\n                            rotate: 45,\r\n        " +
"                    show: true,\r\n                            splitNumber: 15,\r\n " +
"                           textStyle: {\r\n\r\n                            }\r\n      " +
"                  }\r\n                    },\r\n                    yAxis: [{ type:" +
" \'value\' }],\r\n                    series: [{\r\n                        name: \"\",\r" +
"\n                        type: \'bar\',\r\n                        data: data.dataLi" +
"st[0].data,\r\n                        itemStyle: { normal: { color: function (par" +
"ams) { return colorArr[0]; } } }\r\n                    }]\r\n                };\r\n\r\n" +
"                myChart8 = initMonitorChart(\"echart8\", chartBarData8);\r\n\r\n      " +
"      }\r\n        });\r\n    }\r\n\r\n    //先获取当前用户\r\n    function GetCurrentUserCode() " +
"{\r\n        var userCode = \'000000\';\r\n        $.ajax({\r\n            url: SSOURL +" +
" \'api/AdministrativeApi/GetCurrentUserCode\',\r\n            beforeSend: function (" +
"a) {\r\n                a.setRequestHeader(\"Authorization\", authToken);\r\n         " +
"   },\r\n            type: \'GET\',\r\n            async: false,\r\n            dataType" +
": \"json\",\r\n            success: function (data) {\r\n                if (WebApiRes" +
"ultWrap) {\r\n                    data = data.Result;\r\n                }\r\n        " +
"        if (data.length == 1) {//县级用户\r\n                    if (data.join(\",\").in" +
"dexOf(\"000000\") > 0) {\r\n                        selectProviceId = data[0].substr" +
"ing(0, 2) + \"0000\";;\r\n                        selectCityId = data[0].substring(0" +
", 4) + \"00\";\r\n                        selectCounty = data[0].substring(0, 6);\r\n " +
"                       userCode = selectCounty;\r\n                    }\r\n        " +
"        } else if (data.join(\",\").indexOf(\"0000\") > 0) {//是省级用户\r\n               " +
"     for (var i = 0; i < data.length; i++) {\r\n                        if (data[i" +
"].substring(2, 6) == \"0000\" && data[i].length < 9) {\r\n                          " +
"  selectProviceId = data[i];\r\n                            userCode = selectProvi" +
"ceId;\r\n                        }\r\n                    }\r\n                } else " +
"if (data.join(\",\").indexOf(\"00\") > 0) {//是市级用户\r\n                    for (var i =" +
" 0; i < data.length; i++) {\r\n                        if (data[i].substring(4, 6)" +
" == \"00\" && data[i].length < 9) {\r\n                            selectProviceId =" +
" data[i].substring(0, 2) + \"0000\";\r\n                            selectCityId = d" +
"ata[i];\r\n                            userCode = selectCityId;\r\n                 " +
"       }\r\n                    }\r\n                }\r\n                $.ajax({\r\n  " +
"                  url: SSOURL + \'api/AdministrativeApi/GetDistrctByCodes/\' + use" +
"rCode,\r\n                    beforeSend: function (a) {\r\n                        " +
"a.setRequestHeader(\"Authorization\", authToken);\r\n                    },\r\n       " +
"             type: \'GET\',\r\n                    async: false,\r\n                  " +
"  dataType: \"json\",\r\n                    success: function (data) {\r\n           " +
"             if (data[0] != undefined) {\r\n                            NowName = " +
"data[0].DistrictName;\r\n                        } else {\r\n                       " +
"     NowName = \"全国\";\r\n                        }\r\n                    }\r\n        " +
"        });\r\n            }, error: function (e) {\r\n            },\r\n            c" +
"ache: false\r\n        });\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591