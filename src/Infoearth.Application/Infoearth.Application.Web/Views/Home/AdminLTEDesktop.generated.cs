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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/AdminLTEDesktop.cshtml")]
    public partial class _Views_Home_AdminLTEDesktop_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_AdminLTEDesktop_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>我的桌面</title>\r\n    <meta");

WriteLiteral(" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\"" +
"");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(">\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 265), Tuple.Create("\"", 317)
, Tuple.Create(Tuple.Create("", 272), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap.min.css")
, 272), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 349), Tuple.Create("\"", 393)
, Tuple.Create(Tuple.Create("", 356), Tuple.Create<System.Object, System.Int32>(Href("~/Content/styles/font-awesome.min.css")
, 356), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 425), Tuple.Create("\"", 464)
, Tuple.Create(Tuple.Create("", 432), Tuple.Create<System.Object, System.Int32>(Href("~/Content/adminLTE/css/index.css")
, 432), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 498), Tuple.Create("\"", 549)
, Tuple.Create(Tuple.Create("", 504), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/jquery/jquery-1.10.2.min.js")
, 504), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 573), Tuple.Create("\"", 620)
, Tuple.Create(Tuple.Create("", 579), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/charts/Chart.js")
, 579), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 644), Tuple.Create("\"", 692)
, Tuple.Create(Tuple.Create("", 650), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/respond.min.js")
, 650), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 716), Tuple.Create("\"", 766)
, Tuple.Create(Tuple.Create("", 722), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/html5shiv.min.js")
, 722), false)
);

WriteLiteral("></script>\r\n\r\n    <script>\r\n        $(function () {\r\n            if ($(\'#areascon" +
"tent\').height() > $(window).height() - 20) {\r\n                $(\'#areascontent\')" +
".css(\"margin-right\", \"0px\");\r\n            }\r\n            $(\'#areascontent\').heig" +
"ht($(window).height() - 22);\r\n            $(window).resize(function (e) {\r\n     " +
"           window.setTimeout(function () {\r\n                    $(\'#areascontent" +
"\').height($(window).height() - 22);\r\n                }, 200);\r\n            });\r\n" +
"            Canvas1();\r\n            Canvas2();\r\n            Canvas3();\r\n        " +
"});\r\n        function Canvas1() {\r\n            var randomScalingFactor = functio" +
"n () { return Math.round(Math.random() * 100) };\r\n            var doughnutData =" +
" [\r\n                {\r\n                    value: randomScalingFactor(),\r\n      " +
"              color: \"#F7464A\",\r\n                    highlight: \"#FF5A5E\",\r\n    " +
"                label: \"事假\"\r\n                },\r\n                {\r\n            " +
"        value: randomScalingFactor(),\r\n                    color: \"#46BFBD\",\r\n  " +
"                  highlight: \"#5AD3D1\",\r\n                    label: \"病假\"\r\n      " +
"          },\r\n                {\r\n                    value: randomScalingFactor(" +
"),\r\n                    color: \"#FDB45C\",\r\n                    highlight: \"#FFC8" +
"70\",\r\n                    label: \"公休假\"\r\n                },\r\n                {\r\n " +
"                   value: randomScalingFactor(),\r\n                    color: \"#9" +
"49FB1\",\r\n                    highlight: \"#A8B3C5\",\r\n                    label: \"" +
"调休假\"\r\n                }\r\n            ];\r\n            var ctx = document.getEleme" +
"ntById(\"Canvas1\").getContext(\"2d\");\r\n            window.myDoughnut = new Chart(c" +
"tx).Doughnut(doughnutData, { responsive: false });\r\n        }\r\n        function " +
"Canvas2() {\r\n            var randomScalingFactor = function () { return Math.rou" +
"nd(Math.random() * 100) };\r\n            var lineChartData = {\r\n                l" +
"abels: [\"星期一\", \"星期二\", \"星期三\", \"星期四\", \"星期五\", \"星期六\", \"星期日\"],\r\n                datas" +
"ets: [\r\n                    {\r\n                        fillColor: \"rgba(220,220," +
"220,0.2)\",\r\n                        strokeColor: \"rgba(220,220,220,1)\",\r\n       " +
"                 pointColor: \"rgba(220,220,220,1)\",\r\n                        poi" +
"ntStrokeColor: \"#fff\",\r\n                        pointHighlightFill: \"#fff\",\r\n   " +
"                     pointHighlightStroke: \"rgba(220,220,220,1)\",\r\n             " +
"           data: [randomScalingFactor(), randomScalingFactor(), randomScalingFac" +
"tor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), rand" +
"omScalingFactor()]\r\n                    }\r\n                ]\r\n            }\r\n   " +
"         var ctx = document.getElementById(\"Canvas2\").getContext(\"2d\");\r\n       " +
"     window.myLine = new Chart(ctx).Line(lineChartData, {\r\n                bezie" +
"rCurve: false,\r\n            });\r\n        }\r\n        function Canvas3() {\r\n      " +
"      var randomScalingFactor = function () { return Math.round(Math.random() * " +
"100) };\r\n            var lineChartData = {\r\n                labels: [\"1月\", \"2月\"," +
" \"3月\", \"4月\", \"5月\", \"6月\", \"7月\", \"8月\", \"8月\", \"10月\", \"11月\", \"12月\"],\r\n              " +
"  datasets: [\r\n                    {\r\n                        fillColor: \"#578eb" +
"e\",\r\n                        data: [randomScalingFactor(), randomScalingFactor()" +
", randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomSca" +
"lingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(" +
"), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]\r\n       " +
"             }\r\n                ]\r\n            }\r\n            var ctx = document" +
".getElementById(\"Canvas3\").getContext(\"2d\");\r\n            window.myLine = new Ch" +
"art(ctx).Bar(lineChartData, {\r\n                bezierCurve: false,\r\n\r\n          " +
"  });\r\n        }\r\n    </script>\r\n</head>\r\n<body");

WriteLiteral(" style=\"overflow: hidden; margin: 0px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"areascontent\"");

WriteLiteral(" style=\"margin: 10px 10px 0 10px; margin-bottom: 0px; overflow: auto;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"rows\"");

WriteLiteral(" style=\"margin-bottom: 0.8%; overflow: hidden;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"float: left; width: 69.2%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"height: 100%; border: 1px solid #e6e6e6; overflow: hidden;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #578ebe;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral("></i>\r\n                            </div>\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">17<span>个</span></h2>\r\n                            <h5>待办未处理</h5>\r\n             " +
"           </div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #e35b5a;\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">12<span>条</span></h2>\r\n                            <h5>预警信息未读</h5>\r\n            " +
"                <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-bell\"");

WriteLiteral("></i>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #44b6ae;\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">20<span>封</span></h2>\r\n                            <h5>邮件未读</h5>\r\n              " +
"              <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-envelope-o\"");

WriteLiteral("></i>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #8775a7; margin-right: 0px;\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">6</h2>\r\n                            <h5>对公待签收任务</h5>\r\n                          " +
"  <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-gavel\"");

WriteLiteral("></i>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #4f5c65; margin-bottom: 0px;\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">324<span>件</span></h2>\r\n                            <h5>今日订单数</h5>\r\n            " +
"                <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-shopping-cart\"");

WriteLiteral("></i>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #14aae4; margin-bottom: 0px;\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">525<span>件</span></h2>\r\n                            <h5>昨日订单数</h5>\r\n            " +
"                <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-file-text-o\"");

WriteLiteral("></i>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #949FB1; margin-bottom: 0px;\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">355<span>件</span></h2>\r\n                            <h5>回退订单数</h5>\r\n            " +
"                <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-coffee\"");

WriteLiteral("></i>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n                    <div");

WriteLiteral(" class=\"dashboard-stats\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"dashboard-stats-item\"");

WriteLiteral(" style=\"background-color: #f29503; margin-right: 0px; margin-bottom: 0px;\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" class=\"m-top-none\"");

WriteLiteral(">3335<span>元</span></h2>\r\n                            <h5>昨日成交金额</h5>\r\n          " +
"                  <div");

WriteLiteral(" class=\"stat-icon\"");

WriteLiteral(">\r\n                                <i");

WriteLiteral(" class=\"fa fa-rmb\"");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral("></i>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n                </div>\r\n            </div>\r\n            <d" +
"iv");

WriteLiteral(" style=\"float: right; width: 30%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"height: 221px; border: 1px solid #e6e6e6; background-color: #fff;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-area-chart fa-lg\"");

WriteLiteral(" style=\"padding-right: 5px;\"");

WriteLiteral("></i>成交订单</div>\r\n                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                            <canvas");

WriteLiteral(" id=\"Canvas2\"");

WriteLiteral(" style=\"height: 165px; width: 100%;\"");

WriteLiteral("></canvas>\r\n                        </div>\r\n                    </div>\r\n         " +
"       </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"rows\"");

WriteLiteral(" style=\"margin-bottom: 0.8%; overflow: hidden;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"float: left; width: 69.2%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"height: 290px; border: 1px solid #e6e6e6; background-color: #fff;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-bar-chart fa-lg\"");

WriteLiteral(" style=\"padding-right: 5px;\"");

WriteLiteral("></i>柱状图</div>\r\n                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                            <canvas");

WriteLiteral(" id=\"Canvas3\"");

WriteLiteral(" style=\"height: 230px; width: 100%;\"");

WriteLiteral("></canvas>\r\n                        </div>\r\n                    </div>\r\n         " +
"       </div>\r\n            </div>\r\n            <div");

WriteLiteral(" style=\"float: right; width: 30%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"height: 290px; border: 1px solid #e6e6e6; background-color: #fff;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pie-chart fa-lg\"");

WriteLiteral(" style=\"padding-right: 5px;\"");

WriteLiteral("></i>请假统计</div>\r\n                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                            <canvas");

WriteLiteral(" id=\"Canvas1\"");

WriteLiteral(" style=\"height: 180px; width: 100%; margin-top: 10px;\"");

WriteLiteral("></canvas>\r\n                            <div");

WriteLiteral(" style=\"text-align: center; padding-top: 15px;\"");

WriteLiteral(">\r\n                                <span><i");

WriteLiteral(" class=\"fa fa-square\"");

WriteLiteral(" style=\"color: #F7464A; font-size: 20px; padding-right: 5px; vertical-align: midd" +
"le; margin-top: -3px;\"");

WriteLiteral("></i>事假</span>\r\n                                <span");

WriteLiteral(" style=\"margin-left: 10px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-square\"");

WriteLiteral(" style=\"color: #46BFBD; font-size: 20px; padding-right: 5px; vertical-align: midd" +
"le; margin-top: -3px;\"");

WriteLiteral("></i>病假</span>\r\n                                <span");

WriteLiteral(" style=\"margin-left: 10px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-square\"");

WriteLiteral(" style=\"color: #FDB45C; font-size: 20px; padding-right: 5px; vertical-align: midd" +
"le; margin-top: -3px;\"");

WriteLiteral("></i>公休假</span>\r\n                                <span");

WriteLiteral(" style=\"margin-left: 10px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-square\"");

WriteLiteral(" style=\"color: #949FB1; font-size: 20px; padding-right: 5px; vertical-align: midd" +
"le; margin-top: -3px;\"");

WriteLiteral("></i>调休假</span>\r\n                            </div>\r\n                        </di" +
"v>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n  " +
"      </div>\r\n        <div");

WriteLiteral(" class=\"rows\"");

WriteLiteral(" style=\"overflow: hidden;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"float: left; width: 33.8%; margin-right: 0.8%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"height: 240px; border: 1px solid #e6e6e6; background-color: #fff;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-send fa-lg\"");

WriteLiteral(" style=\"padding-right: 5px;\"");

WriteLiteral("></i>企业文化</div>\r\n                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                            <ul>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">尊重自己的员工，依靠员工来宣传企业品牌</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-02</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">尊重自己的顾客，把顾客当成自己的朋友</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-06-18</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">靠团队精神达到共同目标</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-06-26</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">只有勇于承担责任，才能承担更大的责任</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-04-20</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">只有不完美的产品，没有不挑剔的客户</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-03-08</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">需求万变，努力不变</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-02-22</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">人是真正的最大的财产</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-02-15</span></li>\r\n                            </ul>\r\n                     " +
"   </div>\r\n                    </div>\r\n                </div>\r\n            </div" +
">\r\n            <div");

WriteLiteral(" style=\"float: left; width: 34.6%; margin-right: 0.8%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"height: 240px; border: 1px solid #e6e6e6; background-color: #fff;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-rss fa-lg\"");

WriteLiteral(" style=\"padding-right: 5px;\"");

WriteLiteral("></i>通知公告</div>\r\n                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                            <ul>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">【通知】中秋放假通知</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">【公告】苏州分公司第二期委培名单</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">【通知】上海公司作息时间调整通知，下月执行</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">【公告】Q2季度之星名单公示</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">【通知】冷饮券发放通知，请各部门主管到行政部领取</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">【公告】苏州分公司总经理任命书</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">【公告】餐费补贴通知，本月生效</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                            </ul>\r\n                     " +
"   </div>\r\n                    </div>\r\n                </div>\r\n            </div" +
">\r\n            <div");

WriteLiteral(" style=\"float: right; width: 30%;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" style=\"height: 240px; border: 1px solid #e6e6e6; background-color: #fff;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-thumbs-o-up fa-lg\"");

WriteLiteral(" style=\"padding-right: 5px;\"");

WriteLiteral("></i>最新签约</div>\r\n                        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                            <ul>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">上海亚太计算机信息系统有限公司</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-21</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">南京中车浦镇工业物流有限公司</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-20</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">山西晋煤集团技术研究院有限责任公司</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-19</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">长春机场集团有限公司</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-17</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">合肥工业大学</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-17</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">广西师范大学</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-13</span></li>\r\n                                <li><a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">中国邮政速递物流股份有限公司</a><span");

WriteLiteral(" class=\"time\"");

WriteLiteral(">2016-07-12</span></li>\r\n                            </ul>\r\n                     " +
"   </div>\r\n                    </div>\r\n                </div>\r\n            </div" +
">\r\n        </div>\r\n    </div>\r\n    <style>\r\n        #copyrightcontent {\r\n       " +
"     height: 30px;\r\n            line-height: 29px;\r\n            overflow: hidden" +
";\r\n            position: absolute;\r\n            top: 100%;\r\n            margin-t" +
"op: -30px;\r\n            width: 100%;\r\n            background-color: #fff;\r\n     " +
"       border: 1px solid #e6e6e6;\r\n            padding-left: 10px;\r\n            " +
"padding-right: 10px;\r\n        }\r\n\r\n        .dashboard-stats {\r\n            float" +
": left;\r\n            width: 25%;\r\n        }\r\n\r\n        .dashboard-stats-item {\r\n" +
"            position: relative;\r\n            overflow: hidden;\r\n            colo" +
"r: #fff;\r\n            cursor: pointer;\r\n            height: 105px;\r\n            " +
"margin-right: 10px;\r\n            margin-bottom: 10px;\r\n            padding-left:" +
" 15px;\r\n            padding-top: 20px;\r\n        }\r\n\r\n            .dashboard-stat" +
"s-item .m-top-none {\r\n                margin-top: 5px;\r\n            }\r\n\r\n       " +
"     .dashboard-stats-item h2 {\r\n                font-size: 28px;\r\n             " +
"   font-family: inherit;\r\n                line-height: 1.1;\r\n                fon" +
"t-weight: 500;\r\n                padding-left: 70px;\r\n            }\r\n\r\n          " +
"      .dashboard-stats-item h2 span {\r\n                    font-size: 12px;\r\n   " +
"                 padding-left: 5px;\r\n                }\r\n\r\n            .dashboard" +
"-stats-item h5 {\r\n                font-size: 12px;\r\n                font-family:" +
" inherit;\r\n                margin-top: 1px;\r\n                line-height: 1.1;\r\n" +
"                padding-left: 70px;\r\n            }\r\n\r\n\r\n            .dashboard-s" +
"tats-item .stat-icon {\r\n                position: absolute;\r\n                top" +
": 18px;\r\n                font-size: 50px;\r\n                opacity: .3;\r\n       " +
"     }\r\n\r\n        .dashboard-stats i.fa.stats-icon {\r\n            width: 50px;\r\n" +
"            padding: 20px;\r\n            font-size: 50px;\r\n            text-align" +
": center;\r\n            color: #fff;\r\n            height: 50px;\r\n            bord" +
"er-radius: 10px;\r\n        }\r\n\r\n        .panel-default {\r\n            border: non" +
"e;\r\n            border-radius: 0px;\r\n            margin-bottom: 0px;\r\n          " +
"  box-shadow: none;\r\n            -webkit-box-shadow: none;\r\n        }\r\n\r\n       " +
"     .panel-default > .panel-heading {\r\n                color: #777;\r\n          " +
"      background-color: #fff;\r\n                border-color: #e6e6e6;\r\n         " +
"       padding: 10px 10px;\r\n            }\r\n\r\n            .panel-default > .panel" +
"-body {\r\n                padding: 10px;\r\n                padding-bottom: 0px;\r\n " +
"           }\r\n\r\n                .panel-default > .panel-body ul {\r\n             " +
"       overflow: hidden;\r\n                    padding: 0;\r\n                    m" +
"argin: 0px;\r\n                    margin-top: -5px;\r\n                }\r\n\r\n       " +
"             .panel-default > .panel-body ul li {\r\n                        line-" +
"height: 27px;\r\n                        list-style-type: none;\r\n                 " +
"       white-space: nowrap;\r\n                        text-overflow: ellipsis;\r\n " +
"                   }\r\n\r\n                        .panel-default > .panel-body ul " +
"li .time {\r\n                            color: #a1a1a1;\r\n                       " +
"     float: right;\r\n                            padding-right: 5px;\r\n           " +
"             }\r\n    </style>\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
