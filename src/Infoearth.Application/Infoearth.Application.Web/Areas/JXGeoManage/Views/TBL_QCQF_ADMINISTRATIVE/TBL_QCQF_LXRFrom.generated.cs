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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_QCQF_ADMINISTRATIVE/TBL_QCQF_LXRFrom.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_QCQF_ADMINISTRATIVE_TBL_QCQF_LXRFrom_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_QCQF_ADMINISTRATIVE_TBL_QCQF_LXRFrom_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_ADMINISTRATIVE\TBL_QCQF_LXRFrom.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script>\r\n        var userinfo = request(\'userinfo\') == \"\" ? null : request" +
"(\'userinfo\');\r\n        var authToken = getAuthorizationToken();\r\n        $(funct" +
"ion () {\r\n            GetGrid();\r\n            initControl();\r\n        });\r\n     " +
"   //初始化控件\r\n        var queryJson = {}\r\n        function initControl() {\r\n      " +
"      if (userinfo && userinfo != \"null\") {\r\n                if (userinfo == \"qf" +
"\") {\r\n                    queryJson.AreaCode = request(\"typeorcode\");\r\n         " +
"           $.ajax({\r\n                        url: \'../../JXGeoManage/TBL_QCQF_DI" +
"SASTERPREVENTION/GetQCQFZRRInfo\',\r\n                        data: { queryJson: JS" +
"ON.stringify(queryJson) },\r\n                        type: \'GET\',\r\n              " +
"          async: false,\r\n                        success: function (data) {\r\n   " +
"                         data = JSON.parse(data);\r\n                            v" +
"ar obj = {};\r\n                            for (var a in data) {\r\n               " +
"                 data[a] = JSON.parse(data[a]);\r\n                            }\r\n" +
"                            $(\'#gridTable\').jqGrid(\'setGridParam\', { data: data " +
"}).trigger(\'reloadGrid\');\r\n                        }\r\n                    })\r\n  " +
"              } else {\r\n                    userinfo = unescape(userinfo);\r\n    " +
"                userinfo = JSON.parse(userinfo);\r\n                    $(\'#gridTa" +
"ble\').jqGrid(\'addRowData\', userinfo.ContactPeopleID, userinfo);\r\n               " +
"     $(\'#gridTable\').trigger(\'reloadGrid\');\r\n                }\r\n            }\r\n " +
"       }\r\n        //加载统计表\r\n        function GetGrid() {\r\n            $(\'#gridTab" +
"le\').jqGrid({\r\n                autowidth: true,\r\n                height: 300,\r\n " +
"               datatype: \"local\",\r\n                colModel: [\r\n                " +
"    { label: \'ContactPeopleID\', name: \'ContactPeopleID\', index: \'ContactPeopleID" +
"\', width: 150, align: \'center\', sortable: false, hidden: true },\r\n              " +
"      { label: \'姓名\', name: \'UserName\', index: \'UserName\', width: 150, align: \'ce" +
"nter\', sortable: false },\r\n                    { label: \'登录名\', name: \'LoginName\'" +
", index: \'LoginName\', width: 150, align: \'center\', sortable: false },\r\n         " +
"           { label: \'手机\', name: \'Mobile\', index: \'Mobile\', width: 150, align: \'c" +
"enter\', sortable: false },\r\n                    { label: \'邮箱\', name: \'Email\', in" +
"dex: \'Email\', width: 150, align: \'center\', sortable: false },\r\n                 " +
"   {\r\n                        label: \'操作\', name: \'CZ\', index: \'CZ\', width: 150, " +
"align: \'left\', sortable: false,\r\n                        formatter: function (ce" +
"llvalue, options, rowObject) {\r\n                            return \'<a style=\"co" +
"lor:#3185c7;cursor:pointer;\" onclick=\"delect(\' + options.rowId + \')\">删除</a>\';\r\n " +
"                       }\r\n                    },\r\n                ],\r\n          " +
"      pager: \'false\',\r\n                onSelectRow: function (rowId, status) {\r\n" +
"                },\r\n                gridComplete: function () {\r\n               " +
" }\r\n            });\r\n        }\r\n        function addlxr() {\r\n            dialogO" +
"pen({\r\n                id: \'ContactPersonForm\',\r\n                title: \'新增联系人\'," +
"\r\n                url: \'../../ContactPerson/ContactPersonForm\',\r\n               " +
" width: \'800px\',\r\n                height: \"500px\",\r\n                callBack: fu" +
"nction (iframeId) {\r\n                    var data = getInfoTop().frames[iframeId" +
"].AcceptClick();\r\n                    var ids = $(\'#gridTable\').jqGrid(\'getDataI" +
"Ds\');\r\n                    for (var a = 0; a < ids.length; a++) {\r\n             " +
"           var getData = $(\'#gridTable\').jqGrid(\'getRowData\', ids[a]);\r\n        " +
"                if (getData.ContactPeopleID == data.ContactPeopleID) {\r\n        " +
"                    dialogAlert(\'当前用户已存在！无需重复添加\');\r\n                            " +
"return\r\n                        }\r\n                    }\r\n                    $(" +
"\'#gridTable\').jqGrid(\'addRowData\', data.ContactPeopleID, data);\r\n               " +
"     $(\'#gridTable\').trigger(\'reloadGrid\');\r\n                }\r\n            });\r" +
"\n        }\r\n        function addlslxr() {\r\n            dialogOpen({\r\n           " +
"     id: \'addlslxr\',\r\n                title: \'新增临时联系人\',\r\n                url: \'." +
"./../JXGeoManage/TBL_QCQF_ADMINISTRATIVE/TBL_QCQF_INSERT_LSLXRFrom\',\r\n          " +
"      width: \'400px\',\r\n                height: \'300px\',\r\n                callBac" +
"k: function (iframeId) {\r\n                    var data = getInfoTop().frames[ifr" +
"ameId].AcceptClick();\r\n                    var ids = $(\'#gridTable\').jqGrid(\'get" +
"DataIDs\');\r\n                    $(\'#gridTable\').jqGrid(\'addRowData\', ids.length " +
"+ 1, data);\r\n                    $(\'#gridTable\').trigger(\'reloadGrid\');\r\n       " +
"         }\r\n            });\r\n        }\r\n        function delect(id) {\r\n         " +
"   $(\'#gridTable\').jqGrid(\'delRowData\', id);\r\n            $(\'#gridTable\').trigge" +
"r(\'reloadGrid\');\r\n        }\r\n    </script>\r\n");

});

WriteLiteral("<style>\r\n    textarea {\r\n        padding-left: 4px;\r\n        resize: none;\r\n     " +
"   height: 200px;\r\n        line-height: 25px;\r\n        border: 1px solid #ccc;\r\n" +
"    }\r\n</style>\r\n<div");

WriteLiteral(" id=\"form1\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" style=\"width: 100%;background: #fff; padding: 10px 0 0 0\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(" style=\"height:40px;line-height:40px;border:none;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"toolbar2\"");

WriteLiteral(" style=\"float:right;margin-right:30px;height:40px;line-height:40px;display:flex;a" +
"lign-items: center;\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"addlxr()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>新增联系人</a>\r\n                    <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"addlslxr()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>新增临时联系人</a>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" style=\"clear:both\"");

WriteLiteral("></div>\r\n        </div>\r\n        <div");

WriteLiteral(" style=\"width: 100%; height: 40px; display: flex; align-items: center; justify-co" +
"ntent: start; padding-left: 9px\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"width: 7%;font-weight: 900;min-width:80px;white-space:nowrap;\"");

WriteLiteral(">\r\n                <span>收件人列表</span>\r\n            </div>\r\n        </div>\r\n      " +
"  <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n        </div>\r\n        <div");

WriteLiteral(" style=\"width: 100%; height: 40px; display: flex; align-items: center; justify-co" +
"ntent: start; padding-left: 9px;margin-top:20px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"width: 7%;font-weight: 900;min-width:80px;white-space:nowrap;\"");

WriteLiteral(">\r\n                <span>发送内容</span>\r\n            </div>\r\n        </div>\r\n       " +
" <div");

WriteLiteral(" style=\"width:98%;margin:0 auto;\"");

WriteLiteral(">\r\n            <textarea");

WriteLiteral(" style=\"width:100%;\"");

WriteLiteral(" id=\"fsnr\"");

WriteLiteral("></textarea>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
