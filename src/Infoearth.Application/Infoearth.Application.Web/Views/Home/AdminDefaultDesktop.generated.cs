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
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/AdminDefaultDesktop.cshtml")]
    public partial class _Views_Home_AdminDefaultDesktop_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_AdminDefaultDesktop_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>我的桌面</title>\r\n    <!--框架必需start-->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 209), Tuple.Create("\"", 253)
, Tuple.Create(Tuple.Create("", 216), Tuple.Create<System.Object, System.Int32>(Href("~/Content/styles/font-awesome.min.css")
, 216), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

            
            #line 10 "..\..\Views\Home\AdminDefaultDesktop.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/styles/learun-ui.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 365), Tuple.Create("\"", 416)
, Tuple.Create(Tuple.Create("", 371), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Scripts/jquery/jquery-1.10.2.min.js")
, 371), false)
);

WriteLiteral("></script>\r\n    <!--框架必需end-->\r\n    <!--第三方统计图start-->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 484), Tuple.Create("\"", 540)
, Tuple.Create(Tuple.Create("", 490), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Scripts/plugins/highcharts/highcharts.js")
, 490), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 564), Tuple.Create("\"", 625)
, Tuple.Create(Tuple.Create("", 570), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Scripts/plugins/highcharts/highcharts-more.js")
, 570), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 649), Tuple.Create("\"", 712)
, Tuple.Create(Tuple.Create("", 655), Tuple.Create<System.Object, System.Int32>(Href("~/Content/Scripts/plugins/highcharts/modules/exporting.js")
, 655), false)
);

WriteLiteral("></script>\r\n    <!--第三方统计图end-->\r\n    <script>\r\n        $(function () {\r\n        " +
"    InitialPage();\r\n            LoadInterfaceVisit();\r\n            LoadDepartmen" +
"tApp();\r\n            //setInterval(GetData, 3000);\r\n        });\r\n        //funct" +
"ion GetData() {\r\n        //    $.ajax({\r\n        //        url: top.contentPath " +
"+ \"/Utility/GetLearunData\",\r\n        //        type: \'get\',\r\n        //        d" +
"ataType: \'json\',\r\n        //        success: function (data) {\r\n        //      " +
"      $(\"#businessNewNum\").text(data.total)\r\n        //        }\r\n        //    " +
"});\r\n        //}\r\n\r\n\r\n        //初始化\r\n        function InitialPage() {\r\n         " +
"   $(\'#desktop\').height($(window).height() - 22);\r\n            $(window).resize(" +
"function (e) {\r\n                window.setTimeout(function () {\r\n               " +
"     $(\'#desktop\').height($(window).height() - 22);\r\n                }, 200);\r\n " +
"               e.stopPropagation();\r\n            });\r\n        }\r\n        //访问流量图" +
"表\r\n        function LoadInterfaceVisit() {\r\n            var chart = new Highchar" +
"ts.Chart({\r\n                chart: {\r\n                    renderTo: \'piecontaine" +
"r\',\r\n                    plotBackgroundColor: null,\r\n                    plotBor" +
"derWidth: null,\r\n                    defaultSeriesType: \'pie\'\r\n                }" +
",\r\n                title: {\r\n                    text: \'\'\r\n                },\r\n " +
"               exporting: {\r\n                    enabled: false\r\n               " +
" },\r\n                credits: {\r\n                    enabled: false\r\n           " +
"     },\r\n                tooltip: {\r\n                    formatter: function () " +
"{\r\n                        return \'<b>\' + this.point.name + \'</b>: \' + this.perc" +
"entage + \' %\';\r\n                    }\r\n                },\r\n                plotO" +
"ptions: {\r\n                    pie: {\r\n                        allowPointSelect:" +
" true, //点击切换\r\n                        cursor: \'pointer\',\r\n                     " +
"   dataLabels: {\r\n                            enabled: true,\r\n                  " +
"          formatter: function () {\r\n                                return \'<b>\'" +
" + this.point.name + \'</b>: \' + this.percentage + \' %\';\r\n                       " +
"     }\r\n                        },\r\n                        showInLegend: true\r\n" +
"                    }\r\n                },\r\n                series: [{\r\n         " +
"           data: [\r\n                        [\'枢纽楼\', 10],\r\n                      " +
"  [\'IDC中心\', 10],\r\n                        [\'端局\', 10],\r\n                        [" +
"\'模块局\', 10],\r\n                        [\'营业厅\', 10],\r\n                        [\'办公大" +
"楼\', 10],\r\n                        [\'C网基站\', 40],\r\n                    ]\r\n        " +
"        }]\r\n            });\r\n        }\r\n        //部门应用图表\r\n        function LoadD" +
"epartmentApp() {\r\n            $(\'#container\').highcharts({\r\n                char" +
"t: {\r\n                    type: \'spline\'\r\n                },\r\n                ti" +
"tle: {\r\n                    text: \'\'\r\n                },\r\n                xAxis:" +
" {\r\n                    categories: [\'1月\', \'2月\', \'3月\', \'4月\', \'5月\', \'6月\', \'7月\', \'" +
"8月\', \'9月\', \'10月\', \'11月\', \'12月\']\r\n                },\r\n                yAxis: {\r\n " +
"                   title: {\r\n                        text: \'电量（度）\'\r\n            " +
"        },\r\n                    labels: {\r\n                        formatter: fu" +
"nction () {\r\n                            return this.value + \'度\'\r\n              " +
"          }\r\n                    }\r\n                },\r\n                exportin" +
"g: {\r\n                    enabled: false\r\n                },\r\n                cr" +
"edits: {\r\n                    enabled: false\r\n                },\r\n              " +
"  tooltip: {\r\n                    crosshairs: true,\r\n                    shared:" +
" true\r\n                },\r\n                plotOptions: {\r\n                    s" +
"pline: {\r\n                        marker: {\r\n                            radius:" +
" 4,\r\n                            lineColor: \'#666666\',\r\n                        " +
"    lineWidth: 1\r\n                        }\r\n                    }\r\n            " +
"    },\r\n                series: [{\r\n                    name: \'预算\',\r\n           " +
"         marker: {\r\n                        symbol: \'square\'\r\n                  " +
"  },\r\n                    data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 23.3, 18" +
".3, 13.9, 9.6, 1]\r\n\r\n                }, {\r\n                    name: \'实际\',\r\n    " +
"                marker: {\r\n                        symbol: \'diamond\'\r\n          " +
"          },\r\n                    data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 1" +
"6.6, 14.2, 10.3, 6.6, 4.8]\r\n                }]\r\n            });\r\n\r\n        }\r\n  " +
"      //跳转到指定模块菜单\r\n        function OpenNav(Navid) {\r\n            top.$(\"#nav\")." +
"find(\'a#\' + Navid).trigger(\"click\");\r\n        }\r\n    </script>\r\n</head>\r\n<body>\r" +
"\n    <div");

WriteLiteral(" class=\"border\"");

WriteLiteral(" id=\"desktop\"");

WriteLiteral(" style=\"margin: 10px 10px 0 10px; background: #fff; overflow: auto;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"portal-panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"portal-panel-title\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-balance-scale\"");

WriteLiteral("></i>&nbsp;&nbsp;统计指标\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"portal-panel-content\"");

WriteLiteral(" style=\"margin-top: 15px; overflow: hidden;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" style=\"width: 20%; position: relative; float: left;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"task-stat\"");

WriteLiteral(" style=\"background-color: #578ebe;\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"visual\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-pie-chart\"");

WriteLiteral("></i>\r\n                                </div>\r\n                                <d" +
"iv");

WriteLiteral(" class=\"details\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"number\"");

WriteLiteral(" id=\"businessNewNum\"");

WriteLiteral(">\r\n                                        128\r\n                                 " +
"   </div>\r\n                                    <div");

WriteLiteral(" class=\"desc\"");

WriteLiteral(">\r\n                                        最新商机量\r\n                               " +
"     </div>\r\n                                </div>\r\n                           " +
"     <a");

WriteLiteral(" class=\"more\"");

WriteLiteral(" style=\"background-color: #4884b8;\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(" onclick=\"OpenNav(\'66f6301c-1789-4525-a7d2-2b83272aafa6\')\"");

WriteLiteral(">查看更多 <i");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </div>\r\n" +
"                        </div>\r\n                        <div");

WriteLiteral(" style=\"width: 20%; position: relative; float: left;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"task-stat\"");

WriteLiteral(" style=\"background-color: #e35b5a;\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"visual\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-bar-chart-o\"");

WriteLiteral("></i>\r\n                                </div>\r\n                                <d" +
"iv");

WriteLiteral(" class=\"details\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"number\"");

WriteLiteral(">\r\n                                        266\r\n                                 " +
"   </div>\r\n                                    <div");

WriteLiteral(" class=\"desc\"");

WriteLiteral(">\r\n                                        最新客户量\r\n                               " +
"     </div>\r\n                                </div>\r\n                           " +
"     <a");

WriteLiteral(" class=\"more\"");

WriteLiteral(" style=\"background-color: #e04a49;\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(" onclick=\"OpenNav(\'1d3797f6-5cd2-41bc-b769-27f2513d61a9\')\"");

WriteLiteral(">查看更多 <i");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </div>\r\n" +
"                        </div>\r\n                        <div");

WriteLiteral(" style=\"width: 20%; position: relative; float: left;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"task-stat\"");

WriteLiteral(" style=\"background-color: #44b6ae;\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"visual\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-windows\"");

WriteLiteral("></i>\r\n                                </div>\r\n                                <d" +
"iv");

WriteLiteral(" class=\"details\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"number\"");

WriteLiteral(">\r\n                                        39\r\n                                  " +
"  </div>\r\n                                    <div");

WriteLiteral(" class=\"desc\"");

WriteLiteral(">\r\n                                        新签订单量\r\n                               " +
"     </div>\r\n                                </div>\r\n                           " +
"     <a");

WriteLiteral(" class=\"more\"");

WriteLiteral(" style=\"background-color: #3ea7a0;\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(" onclick=\"OpenNav(\'b352f049-4331-4b19-ac22-e379cb30bd55\')\"");

WriteLiteral(">查看更多 <i");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </div>\r\n" +
"                        </div>\r\n                        <div");

WriteLiteral(" style=\"width: 20%; position: relative; float: left;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"task-stat\"");

WriteLiteral(" style=\"background-color: #8775a7;\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"visual\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-globe\"");

WriteLiteral("></i>\r\n                                </div>\r\n                                <d" +
"iv");

WriteLiteral(" class=\"details\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"number\"");

WriteLiteral(">\r\n                                        29898.00\r\n                            " +
"        </div>\r\n                                    <div");

WriteLiteral(" class=\"desc\"");

WriteLiteral(">\r\n                                        本周付款额\r\n                               " +
"     </div>\r\n                                </div>\r\n                           " +
"     <a");

WriteLiteral(" class=\"more\"");

WriteLiteral(" style=\"background-color: #7c699f;\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(">查看更多 <i");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </div>\r\n" +
"                        </div>\r\n                        <div");

WriteLiteral(" style=\"width: 20%; position: relative; float: left;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"task-stat\"");

WriteLiteral(" style=\"background-color: #3598dc;\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"visual\"");

WriteLiteral(">\r\n                                    <i");

WriteLiteral(" class=\"fa fa-globe\"");

WriteLiteral("></i>\r\n                                </div>\r\n                                <d" +
"iv");

WriteLiteral(" class=\"details\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"number\"");

WriteLiteral(">\r\n                                        16897.00\r\n                            " +
"        </div>\r\n                                    <div");

WriteLiteral(" class=\"desc\"");

WriteLiteral(">\r\n                                        利润总额\r\n                                " +
"    </div>\r\n                                </div>\r\n                            " +
"    <a");

WriteLiteral(" class=\"more\"");

WriteLiteral(" style=\"background-color: #258fd7;\"");

WriteLiteral(" href=\"javascript:;\"");

WriteLiteral(">查看更多 <i");

WriteLiteral(" class=\"fa fa-arrow-circle-right\"");

WriteLiteral("></i>\r\n                                </a>\r\n                            </div>\r\n" +
"                        </div>\r\n                    </div>\r\n                </di" +
"v>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" style=\"overflow: hidden; margin-bottom: 10px;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"width: 50%; float: left;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"portal-panel-title\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-coffee\"");

WriteLiteral("></i>&nbsp;&nbsp;待办任务（Top 5）\r\n                    </div>\r\n                    <di" +
"v");

WriteLiteral(" class=\"portal-panel-content\"");

WriteLiteral(" style=\"overflow: hidden; padding-top: 20px; padding-left: 30px; padding-right: 5" +
"0px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[审批]&nbsp;&nbsp;&nbsp;老李的请假条</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2016-05-25</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[审批]&nbsp;&nbsp;&nbsp;陈日天的转岗申请单</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2016-04-01</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[工作]&nbsp;&nbsp;&nbsp;回访千事汇通项目负责人</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2015-09-11</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[工作]&nbsp;&nbsp;&nbsp;联系宋卡公司财务支付二期尾款</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2015-02-19</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[审批]&nbsp;&nbsp;&nbsp;刘昊的借支申请单</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2015-02-26</label>\r\n                        </div>\r\n                    </div>\r\n" +
"                </div>\r\n                <div");

WriteLiteral(" style=\"width: 50%; float: left;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"portal-panel-title\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-bullhorn\"");

WriteLiteral("></i>&nbsp;&nbsp;公告/通知（Top 5）\r\n                    </div>\r\n                    <d" +
"iv");

WriteLiteral(" class=\"portal-panel-content\"");

WriteLiteral(" style=\"overflow: hidden; padding-top: 20px; padding-left: 30px; padding-right: 5" +
"0px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[公告]&nbsp;&nbsp;&nbsp;端午节放假安排</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2016-06-01</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[通知]&nbsp;&nbsp;&nbsp;苏州分公司总经理任命书</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2016-05-28</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[通知]&nbsp;&nbsp;&nbsp;公司开票信息更新通知</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2016-05-23</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[公告]&nbsp;&nbsp;&nbsp;全体员工体检通知</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2016-04-06</label>\r\n                        </div>\r\n                        <div" +
"");

WriteLiteral(" style=\"line-height: 39px; border-bottom: 1px solid #ccc;\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"text-decoration: none;\"");

WriteLiteral(">[通知]&nbsp;&nbsp;&nbsp;华东区营销总监任命书</a>\r\n                            <label");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">2016-04-18</label>\r\n                        </div>\r\n                    </div>\r\n" +
"                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" style=\"overflow: hidden; height: 460px;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"width: 50%; float: left;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"portal-panel-title\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-bar-chart\"");

WriteLiteral("></i>&nbsp;&nbsp;局站分类型总用电占比\r\n                    </div>\r\n                    <div" +
"");

WriteLiteral(" class=\"portal-panel-content\"");

WriteLiteral(" style=\"margin-top: 10px; overflow: hidden;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"piecontainer\"");

WriteLiteral(">\r\n                        </div>\r\n                    </div>\r\n                </" +
"div>\r\n                <div");

WriteLiteral(" style=\"width: 50%; float: left;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"portal-panel-title\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"fa fa-bar-chart\"");

WriteLiteral("></i>&nbsp;&nbsp;预算与实际用电量对比\r\n                    </div>\r\n                    <div" +
"");

WriteLiteral(" class=\"portal-panel-content\"");

WriteLiteral(" style=\"margin-top: 10px; overflow: hidden;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"container\"");

WriteLiteral("></div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n" +
"        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591