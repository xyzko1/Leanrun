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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_QCQF_DISASTERPREVENTION/TBL_QCQF_DISASTERPREVENTION" +
        "Index.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_QCQF_DISASTERPREVENTION_TBL_QCQF_DISASTERPREVENTIONIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_QCQF_DISASTERPREVENTION_TBL_QCQF_DISASTERPREVENTIONIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_QCQF_DISASTERPREVENTION\TBL_QCQF_DISASTERPREVENTIONIndex.cshtml"
  
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
"ge/TBL_QCQF_DISASTERPREVENTION/GetPageListJson\",\r\n            datatype: \"json\",\r" +
"\n            colModel: [\r\n                { label: \'灾害点编号\', name: \'UNIFIEDCODE\'," +
" index: \'UNIFIEDCODE\', width: 100, align: \'left\',sortable: true  },\r\n           " +
"     { label: \'曾经发生灾害时间\', name: \'DISASTERTIME\', index: \'DISASTERTIME\', width: 10" +
"0, align: \'left\',sortable: true  },\r\n                { label: \'地质环境条件\', name: \'G" +
"EOLOGICALENVIRONMENT\', index: \'GEOLOGICALENVIRONMENT\', width: 100, align: \'left\'" +
",sortable: true  },\r\n                { label: \'变形特征及历史活动情况\', name: \'DEFORMATIONH" +
"ISTORICALE\', index: \'DEFORMATIONHISTORICALE\', width: 100, align: \'left\',sortable" +
": true  },\r\n                { label: \'稳定性分析\', name: \'STABILITYANALYSIS\', index: " +
"\'STABILITYANALYSIS\', width: 100, align: \'left\',sortable: true  },\r\n             " +
"   { label: \'引发因素\', name: \'TRIGGERFACTORS\', index: \'TRIGGERFACTORS\', width: 100," +
" align: \'left\',sortable: true  },\r\n                { label: \'潜在危害\', name: \'POTEN" +
"TIALHAZARDS\', index: \'POTENTIALHAZARDS\', width: 100, align: \'left\',sortable: tru" +
"e  },\r\n                { label: \'临灾状态预测\', name: \'STATEPREDICTION\', index: \'STATE" +
"PREDICTION\', width: 100, align: \'left\',sortable: true  },\r\n                { lab" +
"el: \'监测方法\', name: \'MONITORMETHOD\', index: \'MONITORMETHOD\', width: 100, align: \'l" +
"eft\',sortable: true  },\r\n                { label: \'监测周期\', name: \'MONITORCYCLE\', " +
"index: \'MONITORCYCLE\', width: 100, align: \'left\',sortable: true  },\r\n           " +
"     { label: \'监测责任人\', name: \'MONITORRESPONSIBLE\', index: \'MONITORRESPONSIBLE\', " +
"width: 100, align: \'left\',sortable: true  },\r\n                { label: \'监测责任人电话\'" +
", name: \'MONITORRESPONSIBLETEL\', index: \'MONITORRESPONSIBLETEL\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'群测群防人员\', name: \'GROUPMO" +
"NITORINGSTAFF\', index: \'GROUPMONITORINGSTAFF\', width: 100, align: \'left\',sortabl" +
"e: true  },\r\n                { label: \'群测群防人员电话\', name: \'GROUPMONITORINGSTAFFTEL" +
"\', index: \'GROUPMONITORINGSTAFFTEL\', width: 100, align: \'left\',sortable: true  }" +
",\r\n                { label: \'报警方法\', name: \'ALARMMETHOD\', index: \'ALARMMETHOD\', w" +
"idth: 100, align: \'left\',sortable: true  },\r\n                { label: \'报警信号\', na" +
"me: \'ALARMSIGNAL\', index: \'ALARMSIGNAL\', width: 100, align: \'left\',sortable: tru" +
"e  },\r\n                { label: \'报警人\', name: \'ALARMPEOPLE\', index: \'ALARMPEOPLE\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'报警人电话\'" +
", name: \'ALARMTEL\', index: \'ALARMTEL\', width: 100, align: \'left\',sortable: true " +
" },\r\n                { label: \'预定避灾地点\', name: \'BOOKESCAPINGLOCATION\', index: \'BO" +
"OKESCAPINGLOCATION\', width: 100, align: \'left\',sortable: true  },\r\n             " +
"   { label: \'人员撤离路线\', name: \'EVACUATIONROUTES\', index: \'EVACUATIONROUTES\', width" +
": 100, align: \'left\',sortable: true  },\r\n                { label: \'防治建议\', name: " +
"\'TREATMENTSUGGESTION\', index: \'TREATMENTSUGGESTION\', width: 100, align: \'left\',s" +
"ortable: true  },\r\n                { label: \'更新时间\', name: \'UPDATETIME\', index: \'" +
"UPDATETIME\', width: 100, align: \'left\',sortable: true  },\r\n                { lab" +
"el: \'记录状态\', name: \'RECORDSTATUS\', index: \'RECORDSTATUS\', width: 100, align: \'lef" +
"t\',sortable: true  },\r\n                { label: \'导出状态\', name: \'EXPSTATUS\', index" +
": \'EXPSTATUS\', width: 100, align: \'left\',sortable: true  },\r\n                { l" +
"abel: \'创建者ID\', name: \'CREATORUSERID\', index: \'CREATORUSERID\', width: 100, align:" +
" \'left\',sortable: true  },\r\n                { label: \'创建时间\', name: \'CREATORTIME\'" +
", index: \'CREATORTIME\', width: 100, align: \'left\',sortable: true  },\r\n          " +
"      { label: \'更新者ID\', name: \'UPDATEUSERID\', index: \'UPDATEUSERID\', width: 100," +
" align: \'left\',sortable: true  },\r\n                { label: \'更新次数\', name: \'UPDAT" +
"ETIMES\', index: \'UPDATETIMES\', width: 100, align: \'left\',sortable: true  },\r\n   " +
"             { label: \'人员撤离路线示意图\', name: \'EVACUATIONROUTESPIC\', index: \'EVACUATI" +
"ONROUTESPIC\', width: 100, align: \'left\',sortable: true  },\r\n                { la" +
"bel: \'隐患点类型\', name: \'HIDDENPOINTTYPE\', index: \'HIDDENPOINTTYPE\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'监测责任人ID\', name: \'MONITO" +
"RRESPONSIBLEID\', index: \'MONITORRESPONSIBLEID\', width: 100, align: \'left\',sortab" +
"le: true  },\r\n                { label: \'群测群防人员ID\', name: \'GROUPMONITORINGSTAFFID" +
"\', index: \'GROUPMONITORINGSTAFFID\', width: 100, align: \'left\',sortable: true  }," +
"\r\n                { label: \'报警人ID\', name: \'ALARMPEOPLEID\', index: \'ALARMPEOPLEID" +
"\', width: 100, align: \'left\',sortable: true  },\r\n            ],\r\n            vie" +
"wrecords: true,\r\n            rowNum: 30,\r\n            rowList: [30, 50, 100],\r\n " +
"           pager: \"#gridPager\",\r\n            sortname: \'UNIFIEDCODE\',\r\n         " +
"   sortorder: \'desc\',\r\n            rownumbers: true,\r\n            shrinkToFit: f" +
"alse,\r\n            gridview: true,\r\n            onSelectRow: function () {\r\n    " +
"            selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n       " +
"     },\r\n            gridComplete: function () {\r\n                $(\'#\' + this.i" +
"d).setSelection(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n  " +
"  //新增\r\n    function btn_add() {\r\n        dialogOpen({\r\n            id: \'Form\',\r" +
"\n            title: \'添加群测群防防灾预案表\',\r\n            url: \'/JXGeoManage/TBL_QCQF_DISA" +
"STERPREVENTION/TBL_QCQF_DISASTERPREVENTIONForm\',\r\n            width: \'px\',\r\n    " +
"        height: \'px\',\r\n            callBack: function (iframeId) {\r\n            " +
"    getInfoTop().frames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n  " +
"  }\r\n    //编辑\r\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\")" +
".jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (checkedRow(keyValue)) {\r\n          " +
"  dialogOpen({\r\n                id: \'Form\',\r\n                title: \'编辑群测群防防灾预案表" +
"\',\r\n                url: \'/JXGeoManage/TBL_QCQF_DISASTERPREVENTION/TBL_QCQF_DISA" +
"STERPREVENTIONForm?keyValue=\' + keyValue,\r\n                width: \'px\',\r\n       " +
"         height: \'px\',\r\n                callBack: function (iframeId) {\r\n       " +
"             getInfoTop().frames[iframeId].AcceptClick();\r\n                }\r\n  " +
"          })\r\n        }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n        v" +
"ar keyValue = $(\"#gridTable\").jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (keyVal" +
"ue) {\r\n            $.RemoveForm({\r\n                url: \'../../JXGeoManage/TBL_Q" +
"CQF_DISASTERPREVENTION/RemoveForm\',\r\n                param: { keyValue: keyValue" +
" },\r\n                success: function (data) {\r\n                    $(\'#gridTab" +
"le\').trigger(\'reloadGrid\');\r\n                }\r\n            })\r\n        } else {" +
"\r\n            dialogMsg(\'请选择需要删除的群测群防防灾预案表！\', 0);\r\n        }\r\n    }\r\n</script>\r\n" +
"");

});

        }
    }
}
#pragma warning restore 1591
