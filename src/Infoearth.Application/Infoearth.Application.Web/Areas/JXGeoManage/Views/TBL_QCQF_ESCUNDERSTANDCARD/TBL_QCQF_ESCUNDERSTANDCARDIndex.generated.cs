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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_QCQF_ESCUNDERSTANDCARD/TBL_QCQF_ESCUNDERSTANDCARDIn" +
        "dex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_QCQF_ESCUNDERSTANDCARD_TBL_QCQF_ESCUNDERSTANDCARDIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_QCQF_ESCUNDERSTANDCARD_TBL_QCQF_ESCUNDERSTANDCARDIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_ESCUNDERSTANDCARD\TBL_QCQF_ESCUNDERSTANDCARDIndex.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"input");

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

WriteLiteral("></i>查询</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </di" +
"v>\r\n    <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n            <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n            <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n        </div>\r\n    </div>\r\n                      <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        InitialPage();\r\n        GetGrid();\r\n    " +
"});\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //resize重设布局;\r\n        $" +
"(window).resize(function (e) {\r\n            window.setTimeout(function () {\r\n   " +
"             $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n         " +
"       $(\'#gridTable\').setGridHeight($(window).height() - 136.5);\r\n            }" +
", 200);\r\n            e.stopPropagation();\r\n        });\r\n    }\r\n    //加载表格\r\n    f" +
"unction GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTable =" +
" $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n  " +
"          height: $(window).height() - 136.5,\r\n            url: \"../../JXGeoMana" +
"ge/TBL_QCQF_ESCUNDERSTANDCARD/GetPageListJson\",\r\n            datatype: \"json\",\r\n" +
"            colModel: [\r\n                { label: \'GUID\', name: \'GUID\', index: \'" +
"GUID\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'C" +
"GH灾害点编号\', name: \'CGHUNIFIEDCODE\', index: \'CGHUNIFIEDCODE\', width: 100, align: \'l" +
"eft\',sortable: true  },\r\n                { label: \'灾害点编号\', name: \'UNIFIEDCODE\', " +
"index: \'UNIFIEDCODE\', width: 100, align: \'left\',sortable: true  },\r\n            " +
"    { label: \'规模\', name: \'SCALE\', index: \'SCALE\', width: 100, align: \'left\',sort" +
"able: true  },\r\n                { label: \'规模等级\', name: \'SCALELEVEL\', index: \'SCA" +
"LELEVEL\', width: 100, align: \'left\',sortable: true  },\r\n                { label:" +
" \'本住户注意事项\', name: \'HOUSEHOLDNOTES\', index: \'HOUSEHOLDNOTES\', width: 100, align: " +
"\'left\',sortable: true  },\r\n                //{ label: \'撤离路线\', name: \'LEAVEROUTES" +
"\', index: \'LEAVEROUTES\', width: 100, align: \'left\',sortable: true  },\r\n         " +
"       //{ label: \'本卡发放单位\', name: \'CARDRELEASUNIT\', index: \'CARDRELEASUNIT\', wid" +
"th: 100, align: \'left\',sortable: true  },\r\n                //{ label: \'发放单位负责人\'," +
" name: \'CARDRELEASUNITHEADER\', index: \'CARDRELEASUNITHEADER\', width: 100, align:" +
" \'left\',sortable: true  },\r\n                //{ label: \'联系电话\', name: \'CARDRELEAS" +
"UNITTEL\', index: \'CARDRELEASUNITTEL\', width: 100, align: \'left\',sortable: true  " +
"},\r\n                //{ label: \'更新时间\', name: \'UPDATETIME\', index: \'UPDATETIME\', " +
"width: 100, align: \'left\',sortable: true  },\r\n                //{ label: \'记录状态\'," +
" name: \'RECORDSTATUS\', index: \'RECORDSTATUS\', width: 100, align: \'left\',sortable" +
": true  },\r\n                //{ label: \'创建者ID\', name: \'CREATORUSERID\', index: \'C" +
"REATORUSERID\', width: 100, align: \'left\',sortable: true  },\r\n                //{" +
" label: \'导出状态\', name: \'EXPSTATUS\', index: \'EXPSTATUS\', width: 100, align: \'left\'" +
",sortable: true  },\r\n                //{ label: \'创建时间\', name: \'CREATORTIME\', ind" +
"ex: \'CREATORTIME\', width: 100, align: \'left\',sortable: true  },\r\n               " +
" //{ label: \'更新者ID\', name: \'UPDATEUSERID\', index: \'UPDATEUSERID\', width: 100, al" +
"ign: \'left\',sortable: true  },\r\n                //{ label: \'更新次数\', name: \'UPDATE" +
"TIMES\', index: \'UPDATETIMES\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            //{ label: \'户主姓名\', name: \'HOUSEHOLDERNAME\', index: \'HOUSEHOLDERNAME\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                //{ label: \'家庭人数" +
"\', name: \'HOUSEHOLDSIZE\', index: \'HOUSEHOLDSIZE\', width: 100, align: \'left\',sort" +
"able: true  },\r\n                //{ label: \'房屋类型\', name: \'HOUSINGTYPE\', index: \'" +
"HOUSINGTYPE\', width: 100, align: \'left\',sortable: true  },\r\n                //{ " +
"label: \'家庭住址\', name: \'ADDRESS\', index: \'ADDRESS\', width: 100, align: \'left\',sort" +
"able: true  },\r\n                //{ label: \'姓名1\', name: \'NAME1\', index: \'NAME1\'," +
" width: 100, align: \'left\',sortable: true  },\r\n                //{ label: \'姓名2\'," +
" name: \'NAME2\', index: \'NAME2\', width: 100, align: \'left\',sortable: true  },\r\n  " +
"              //{ label: \'姓名3\', name: \'NAME3\', index: \'NAME3\', width: 100, align" +
": \'left\',sortable: true  },\r\n                //{ label: \'姓名4\', name: \'NAME4\', in" +
"dex: \'NAME4\', width: 100, align: \'left\',sortable: true  },\r\n                //{ " +
"label: \'姓名5\', name: \'NAME5\', index: \'NAME5\', width: 100, align: \'left\',sortable:" +
" true  },\r\n                //{ label: \'姓名6\', name: \'NAME6\', index: \'NAME6\', widt" +
"h: 100, align: \'left\',sortable: true  },\r\n                //{ label: \'姓名7\', name" +
": \'NAME7\', index: \'NAME7\', width: 100, align: \'left\',sortable: true  },\r\n       " +
"         //{ label: \'姓名8\', name: \'NAME8\', index: \'NAME8\', width: 100, align: \'le" +
"ft\',sortable: true  },\r\n                //{ label: \'性别1\', name: \'SEX1\', index: \'" +
"SEX1\', width: 100, align: \'left\',sortable: true  },\r\n                //{ label: " +
"\'性别2\', name: \'SEX2\', index: \'SEX2\', width: 100, align: \'left\',sortable: true  }," +
"\r\n                //{ label: \'性别3\', name: \'SEX3\', index: \'SEX3\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                //{ label: \'性别4\', name: \'SEX4\', i" +
"ndex: \'SEX4\', width: 100, align: \'left\',sortable: true  },\r\n                //{ " +
"label: \'性别5\', name: \'SEX5\', index: \'SEX5\', width: 100, align: \'left\',sortable: t" +
"rue  },\r\n                //{ label: \'性别6\', name: \'SEX6\', index: \'SEX6\', width: 1" +
"00, align: \'left\',sortable: true  },\r\n                //{ label: \'性别7\', name: \'S" +
"EX7\', index: \'SEX7\', width: 100, align: \'left\',sortable: true  },\r\n             " +
"   //{ label: \'性别8\', name: \'SEX8\', index: \'SEX8\', width: 100, align: \'left\',sort" +
"able: true  },\r\n                //{ label: \'年龄1\', name: \'AGE1\', index: \'AGE1\', w" +
"idth: 100, align: \'left\',sortable: true  },\r\n                //{ label: \'年龄2\', n" +
"ame: \'AGE2\', index: \'AGE2\', width: 100, align: \'left\',sortable: true  },\r\n      " +
"          //{ label: \'年龄3\', name: \'AGE3\', index: \'AGE3\', width: 100, align: \'lef" +
"t\',sortable: true  },\r\n                //{ label: \'年龄4\', name: \'AGE4\', index: \'A" +
"GE4\', width: 100, align: \'left\',sortable: true  },\r\n                //{ label: \'" +
"年龄5\', name: \'AGE5\', index: \'AGE5\', width: 100, align: \'left\',sortable: true  },\r" +
"\n                //{ label: \'年龄6\', name: \'AGE6\', index: \'AGE6\', width: 100, alig" +
"n: \'left\',sortable: true  },\r\n                //{ label: \'年龄7\', name: \'AGE7\', in" +
"dex: \'AGE7\', width: 100, align: \'left\',sortable: true  },\r\n                //{ l" +
"abel: \'年龄8\', name: \'AGE8\', index: \'AGE8\', width: 100, align: \'left\',sortable: tr" +
"ue  },\r\n                //{ label: \'本卡发放单位ID\', name: \'CARDRELEASUNITID\', index: " +
"\'CARDRELEASUNITID\', width: 100, align: \'left\',sortable: true  },\r\n              " +
"  //{ label: \'发放单位负责人ID\', name: \'CARDRELEASUNITHEADERID\', index: \'CARDRELEASUNIT" +
"HEADERID\', width: 100, align: \'left\',sortable: true  },\r\n                //{ lab" +
"el: \'灾害体与本住户的位置关系\', name: \'POSITIONALRELATIONSHIP\', index: \'POSITIONALRELATIONSH" +
"IP\', width: 100, align: \'left\',sortable: true  },\r\n            ],\r\n            v" +
"iewrecords: true,\r\n            rowNum: 30,\r\n            rowList: [30, 50, 100],\r" +
"\n            pager: \"#gridPager\",\r\n            sortname: \'GUID\',\r\n            so" +
"rtorder: \'desc\',\r\n            rownumbers: true,\r\n            shrinkToFit: false," +
"\r\n            gridview: true,\r\n            onSelectRow: function () {\r\n         " +
"       selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n            " +
"},\r\n            gridComplete: function () {\r\n                $(\'#\' + this.id).se" +
"tSelection(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n    //新" +
"增\r\n    function btn_add() {\r\n        dialogOpen({\r\n            id: \'Form\',\r\n    " +
"        title: \'添加群测群防避灾明白卡\',\r\n            url: \'/JXGeoManage/TBL_QCQF_ESCUNDERS" +
"TANDCARD/TBL_QCQF_ESCUNDERSTANDCARDForm\',\r\n            width: \'px\',\r\n           " +
" height: \'px\',\r\n            callBack: function (iframeId) {\r\n                get" +
"InfoTop().frames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n    }\r\n  " +
"  //编辑\r\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\").jqGrid" +
"RowValue(\'GUID\');\r\n        if (checkedRow(keyValue)) {\r\n            dialogOpen({" +
"\r\n                id: \'Form\',\r\n                title: \'编辑群测群防避灾明白卡\',\r\n          " +
"      url: \'/JXGeoManage/TBL_QCQF_ESCUNDERSTANDCARD/TBL_QCQF_ESCUNDERSTANDCARDFo" +
"rm?keyValue=\' + keyValue,\r\n                width: \'px\',\r\n                height:" +
" \'px\',\r\n                callBack: function (iframeId) {\r\n                    get" +
"InfoTop().frames[iframeId].AcceptClick();\r\n                }\r\n            })\r\n  " +
"      }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n        var keyValue = $(" +
"\"#gridTable\").jqGridRowValue(\'GUID\');\r\n        if (keyValue) {\r\n            $.Re" +
"moveForm({\r\n                url: \'../../JXGeoManage/TBL_QCQF_ESCUNDERSTANDCARD/R" +
"emoveForm\',\r\n                param: { keyValue: keyValue },\r\n                suc" +
"cess: function (data) {\r\n                    $(\'#gridTable\').trigger(\'reloadGrid" +
"\');\r\n                }\r\n            })\r\n        } else {\r\n            dialogMsg(" +
"\'请选择需要删除的群测群防避灾明白卡！\', 0);\r\n        }\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
