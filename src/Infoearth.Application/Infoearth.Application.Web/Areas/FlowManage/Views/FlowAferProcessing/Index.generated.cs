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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FlowManage/Views/FlowAferProcessing/Index.cshtml")]
    public partial class _Areas_FlowManage_Views_FlowAferProcessing_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FlowManage_Views_FlowAferProcessing_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FlowManage\Views\FlowAferProcessing\Index.cshtml"
  
    ViewBag.Title = "已办流程";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 89), Tuple.Create("\"", 158)
, Tuple.Create(Tuple.Create("", 95), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/pagination/jquery.pagination-1.2.7.js")
, 95), false)
);

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 176), Tuple.Create("\"", 241)
, Tuple.Create(Tuple.Create("", 183), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/pagination/jquery.pagination.css")
, 183), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<script>\r\n    var params=\"\";\r\n    $(function () {\r\n        InitialPage();\r\n " +
"       GetSchemeType();\r\n        GetGrid();\r\n    });\r\n    //初始化页面\r\n    function " +
"InitialPage() {\r\n        //resize重设(表格、树形)宽高\r\n        $(window).resize(function " +
"(e) {\r\n            window.setTimeout(function () {\r\n                $(\"#taskbloc" +
"k\").height($(window).height() - 131);\r\n                $(\"#itemTree\").height($(w" +
"indow).height() - 52);\r\n            }, 200);\r\n            e.stopPropagation();\r\n" +
"        });\r\n    }\r\n    //加载树\r\n    function GetSchemeType() {\r\n        $.SetForm" +
"({\r\n            url: \"../../SystemManage/DataItemDetail/GetDataItemTreeJson\",\r\n " +
"           param: { EnCode: \"FlowSort\" },\r\n            success: function (data) " +
"{\r\n                $.each(data, function (id, item) {\r\n                    var r" +
"ow = \'<li><a data-value=\"\' + item.id + \'\">\' + item.text + \'</a></li>\';\r\n        " +
"            $(\'#SchemeType\').find(\'ul\').append(row);\r\n                });\r\n     " +
"           $(\'#SchemeType\').find(\'li>a\').click(function () {\r\n                  " +
"  var id = $(this).attr(\'data-value\');\r\n                    var text = $(this).h" +
"tml();\r\n                    var queryJson = { SchemeType: id };\r\n               " +
"     params = { queryJson: JSON.stringify(queryJson) };\r\n                    $(\"" +
"#girdPager\").page(\'remote\', 0, params);\r\n                    $(\'#SchemeType\').fi" +
"nd(\'.dropdown-text\').html(text);\r\n                });\r\n\r\n            }\r\n        " +
"})\r\n    }\r\n    //加载表格\r\n    function GetGrid() {\r\n        $(\"#taskblock\").height(" +
"$(window).height() - 131);\r\n\r\n        $(\"#girdPager\").panginationEx({\r\n         " +
"   url: \"../../FlowManage/FlowAferProcessing/GetPageListJson\",\r\n            succ" +
"ess: function (data) {\r\n                var $flowlist = $(\"#flowlist\");\r\n       " +
"         $flowlist.html(\"\");\r\n                if (data.length > 0) {\r\n          " +
"          $(\'.no-data\').hide();\r\n                }\r\n                else {\r\n    " +
"                $(\'.no-data\').show();\r\n                }\r\n                $.each" +
"(data, function (i, item) {\r\n\r\n\r\n                    var _listhtml = \'<li><div s" +
"tyle=\"width: 82px; line-height: 38px;margin-top:11px; float: right;\"><a class=\"b" +
"tn btn-success previewmodel\">查看状态</a></div>\';\r\n                    _listhtml += " +
"\'<div  style=\"float: left;\">\';\r\n                    _listhtml += \'<span class=\\\"" +
"label label-success-learun\\\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"流" +
"程分类\">\' + item.f_schemetypename + \'</span>\';\r\n                    _listhtml += \'<" +
"span style=\"margin-left:5px;\"  class=\"item-text\">\' + item.f_code + \'/\' + item.f_" +
"name + \'</span>\';\r\n                   \r\n                    _listhtml += \'<p>\' +" +
" item.f_content + \'</p>\'\r\n                    _listhtml += \'<p>By.\' + item.f_cre" +
"ateusername + \'-\' + item.f_createdate + \'</p>\';\r\n                    _listhtml +" +
"= \'</div></li>\';\r\n                    var $_listhtml = $(_listhtml);\r\n          " +
"          $_listhtml.find(\'.previewmodel\')[0].processInstanceId = item.f_id;\r\n  " +
"                  $_listhtml.find(\'.previewmodel\')[0].processname = item.f_name;" +
"\r\n\r\n                    $flowlist.append($_listhtml);\r\n                });\r\n    " +
"            $(\'[data-toggle=\"tooltip\"]\').tooltip();\r\n                //查看进程\r\n   " +
"             $(\'.previewmodel\').click(function () {\r\n                    var $_b" +
"tn = $(this).context;\r\n                    var _processInstanceId = $_btn.proces" +
"sInstanceId;\r\n                    var _processname = $_btn.processname;\r\n       " +
"             dialogOpen({\r\n                        id: \"ProcessLookForm\",\r\n     " +
"                   title: \'查看状态\',\r\n                        url: \'/FlowManage/Flo" +
"wAferProcessing/ProcessLookForm?processId=\' + _processInstanceId,\r\n             " +
"           width: \"1100px\",\r\n                        height: \"700px\",\r\n         " +
"               btn: null,\r\n                        callBack: function (iframeId)" +
" {\r\n                        }\r\n                    });\r\n                });\r\n   " +
"         },\r\n            sortname: \"F_CreateDate desc\"\r\n        });\r\n\r\n        /" +
"/查询事件\r\n        $(\"#btn_Search\").click(function () {\r\n            var queryJson =" +
" { Keyword: $(\"#txt_Keyword\").val() };\r\n            params = { queryJson: JSON.s" +
"tringify(queryJson) };\r\n            $(\"#girdPager\").page(\'remote\', 0, params);\r\n" +
"        });\r\n\r\n\r\n    }\r\n    //回调函数\r\n    function callBack() {\r\n        $(\"#girdP" +
"ager\").page(\'remote\', \'\', params);\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"div");

WriteLiteral(" id=\"SchemeType\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-text\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">选择流程分类</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral("><span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral("></ul>\r\n                    </div>\r\n                </td>\r\n                <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"txt_Keyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>&nbsp;查询</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n  " +
"  </div>\r\n    <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"learun.reload();\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"taskblockPanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"taskblock\"");

WriteLiteral(" class=\"taskblock\"");

WriteLiteral(" >\r\n        <ul");

WriteLiteral(" id=\"flowlist\"");

WriteLiteral("></ul>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"girdPager\"");

WriteLiteral(" class=\"m-pagination\"");

WriteLiteral("></div>\r\n    <div");

WriteLiteral(" class=\"no-data\"");

WriteLiteral("></div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
