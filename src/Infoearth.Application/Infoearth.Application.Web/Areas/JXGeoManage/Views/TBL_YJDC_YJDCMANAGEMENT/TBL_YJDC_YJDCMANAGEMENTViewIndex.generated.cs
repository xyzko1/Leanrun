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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_YJDC_YJDCMANAGEMENT/TBL_YJDC_YJDCMANAGEMENTViewInde" +
        "x.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_YJDC_YJDCMANAGEMENT_TBL_YJDC_YJDCMANAGEMENTViewIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_YJDC_YJDCMANAGEMENT_TBL_YJDC_YJDCMANAGEMENTViewIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_YJDC_YJDCMANAGEMENT\TBL_YJDC_YJDCMANAGEMENTViewIndex.cshtml"
  
    ViewBag.Title = "TBL_YJDC_YJDCMANAGEMENTViewIndex";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<style>
    .ui-layout-center {
        overflow-x: hidden !important;
    }

    .ui-layout-resizer {
        background-color: #f0f3f4 !important;
    }

    .titlePanel {
        line-height:0px !important;
    }
    .spans {
        padding: 0 10px;
        width:9%;
        text-align:center;
        height:28px;
        line-height:28px;
        min-width:100px
    }
    .divselect {
        width:16%
    }
    #gridTable td {
        border-right: 1px solid #ccc !important;
    }
    .ui-jqgrid-btable tr:nth-child(odd) {
        /*background:#DCDCDC*/
    }
</style>

<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" style=\"font-size:14px; font-weight: bold; padding-left: 15px;background: #ECF7FF" +
";height: 40px;line-height: 40px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral(" style=\"margin-right:10px;\"");

WriteLiteral("></i>查询条件:</div>\r\n    <div");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(" style=\"overflow: hidden;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" style=\"width:100%;height:40px;display:flex;align-items: center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"XZQHCODE\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral("></div>\r\n        </div>\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: #fff;color:#000; display: fle" +
"x; align-items: center; position: relative;\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾险情名称:</span><input");

WriteLiteral(" id=\"NAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("/>\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害点名称:</span><input");

WriteLiteral(" id=\"DISASTERNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("/>\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害类型:</span><input");

WriteLiteral(" id=\"TYPE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("/>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: #fff;color:#000; display: fle" +
"x; align-items: center; position: relative;\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">开始时间:</span><input");

WriteLiteral(" id=\"StartTime\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" datefmt=\"yyyy\"");

WriteLiteral(" onfocus=\"WdatePicker({dateFmt:\'yyyy-MM-dd\',isShowToday:false,isShowClear:false,m" +
"axDate:\'#F{$dp.$D(\\\'EndTime\\\')}\'})\"");

WriteLiteral("  />\r\n        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">结束时间:</span><input");

WriteLiteral(" id=\"EndTime\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" datefmt=\"yyyy\"");

WriteLiteral(" onfocus=\"WdatePicker({dateFmt:\'yyyy-MM-dd\',isShowToday:false,isShowClear:false,m" +
"inDate:\'#F{$dp.$D(\\\'StartTime\\\')}\',maxDate:\'%y-%M-%d\'})\"");

WriteLiteral("  />\r\n        <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"margin:0 30px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\r\n        <a");

WriteLiteral(" id=\"btn_Clear\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"background:gray;border-color:gray\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>重置</a>\r\n    </div>\r\n\r\n    </div>\r\n    <div");

WriteLiteral(" style=\"padding-left: 15px; background: #ECF7FF;height: 40px; line-height: 40px; " +
"border-bottom: 1px solid #ccc\"");

WriteLiteral(">\r\n        <span");

WriteLiteral(" style=\"padding-right: 10px; font-weight: bold; font-size: 14px; display: inline-" +
"block;\"");

WriteLiteral(">数据列表</span>\r\n        <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(" style=\"padding-bottom: 13px;\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" id=\"btn_export\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_export()\"");

WriteLiteral(" href=\"/Grw_WaterLevel/ExcelExport\"");

WriteLiteral("><i");

WriteLiteral(" class=\" fa fa-sign-in\"");

WriteLiteral("></i>&nbsp;导出</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n<div" +
"");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 3362), Tuple.Create("\"", 3421)
, Tuple.Create(Tuple.Create("", 3368), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/districts/multiDistricts.js")
, 3368), false)
);

WriteLiteral("></script>\r\n<script>\r\n    var layout2NorthH = 1;\r\n    $(function () {\r\n        In" +
"itialPage();\r\n        initControl()\r\n        GetGrid();\r\n        //查询点击事件\r\n     " +
"   $(\"#btn_Search\").click(function () {\r\n            SearchEvent();\r\n        });" +
"\r\n        $(\"#btn_Clear\").click(function () {\r\n            ClearEvent();\r\n      " +
"  });\r\n    });\r\n    //初始化页面\r\n    function InitialPage() {\r\n         var isResize" +
" = 0;\r\n          //resize重设布局;\r\n         $(window).resize(function (e) {\r\n      " +
"        //if (isResize<10) {\r\n              //   isResize ++;\r\n              //}" +
"\r\n             //resize();\r\n             window.setTimeout(function () {\r\n      " +
"           $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n           " +
"      $(\'#gridTable\').setGridHeight($(window).height() - 274);\r\n             }, " +
"200);\r\n              e.stopPropagation();\r\n         });\r\n     }\r\n\r\n    //加载表格\r\n " +
"   function GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var queryJso" +
"n = $(\"#filter-form\").getWebControls();\r\n        var $gridTable = $(\'#gridTable\'" +
");\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n            postD" +
"ata: { queryJson: JSON.stringify(queryJson) },\r\n            height: $(window).he" +
"ight() - 274,\r\n            url: \"../../JXGeoManage/TBL_YJDC_YJDCMANAGEMENT/GetPa" +
"geListJson\",\r\n            datatype: \"json\",\r\n            colModel: [\r\n          " +
"      { label: \'guid\', name: \'GUID\', index: \'GUID\', width: 160, align: \'center\'," +
" sortable: true, hidden: true },\r\n                { label: \'灾险情名称\', name: \'NAME\'" +
", index: \'NAME\', width: 160, align: \'center\', sortable: true },\r\n               " +
" { label: \'灾害点名称\', name: \'DISASTERNAME\', index: \'DISASTERNAME\', width: 160, alig" +
"n: \'center\', sortable: true },\r\n                { label: \'灾害类型\', name: \'TYPE\', i" +
"ndex: \'TYPE\', width: 160, align: \'center\', sortable: true },\r\n                { " +
"label: \'发生时间\', name: \'OCCURRENCETIME\', index: \'OCCURRENCETIME\', width: 160, alig" +
"n: \'center\', sortable: true },\r\n                { label: \'灾害规模（m2）\', name: \'DISA" +
"STERSCALE\', index: \'DISASTERSCALE\', width: 160, align: \'center\', sortable: true " +
"},\r\n                { label: \'威胁户数（户）\', name: \'DANGERTHREATFAMILY\', index: \'DANG" +
"ERTHREATFAMILY\', width: 160, align: \'center\', sortable: true },\r\n               " +
" { label: \'威胁人口（人）\', name: \'DANGERTHREATPEOPLENUM\', index: \'DANGERTHREATPEOPLENU" +
"M\', width: 160, align: \'center\', sortable: true },\r\n                { label: \'威胁" +
"财产（万元）\', name: \'DANGERPOTENTIALECONOMICLOSSES\', index: \'DANGERPOTENTIALECONOMICL" +
"OSSES\', width: 160, align: \'center\', sortable: true },\r\n            ],\r\n        " +
"    viewrecords: true,\r\n            rowNum: 30,\r\n            rowList: [30, 50, 1" +
"00],\r\n            pager: \"#gridPager\",\r\n            sortname: \'GUID\',\r\n         " +
"   sortorder: \'desc\',\r\n            rownumbers: true,\r\n            shrinkToFit: f" +
"alse,\r\n            gridview: true,\r\n            onSelectRow: function () {\r\n    " +
"            selectedRowIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n       " +
"     },\r\n            gridComplete: function () {\r\n                $(\'#\' + this.i" +
"d).setSelection(selectedRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n  " +
"  //新增\r\n    function btn_add() {\r\n        dialogOpen({\r\n            id: \'Form\',\r" +
"\n            title: \'添加地质灾害应急调查数据\',\r\n            url: \'/JXGeoManage/TBL_YJDC_YJD" +
"CMANAGEMENT/TBL_YJDC_YJDCMANAGEMENTForm \',\r\n            width: \'1200px\',\r\n      " +
"      height: \'500px\',\r\n            callBack: function (iframeId) {\r\n           " +
"     getInfoTop().frames[iframeId].AcceptClick();\r\n            }\r\n        });\r\n " +
"   }\r\n    //编辑\r\n    function btn_edit() {\r\n        var keyValue = $(\"#gridTable\"" +
").jqGridRowValue(\'GUID\');\r\n        if (checkedRow(keyValue)) {\r\n            dial" +
"ogOpen({\r\n                id: \'Form\',\r\n                title: \'编辑地质灾害应急调查数据\',\r\n " +
"               url: \'/JXGeoManage/TBL_YJDC_YJDCMANAGEMENT/TBL_YJDC_YJDCMANAGEMEN" +
"TForm?keyValue=\' + keyValue + \'&FormType=Edit\',\r\n                width: \'1200px\'" +
",\r\n                height: \'500px\',\r\n                callBack: function (iframeI" +
"d) {\r\n                    getInfoTop().frames[iframeId].AcceptClick();\r\n        " +
"        }\r\n            })\r\n        }\r\n    }\r\n    //删除\r\n    function btn_delete()" +
" {\r\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\'GUID\');\r\n        if (" +
"keyValue) {\r\n            $.RemoveForm({\r\n                url: \'../../JXGeoManage" +
"/TBL_YJDC_YJDCMANAGEMENT/RemoveForm\',\r\n                param: { keyValue: keyVal" +
"ue },\r\n                success: function (data) {\r\n                    $(\'#gridT" +
"able\').trigger(\'reloadGrid\');\r\n                }\r\n            })\r\n        } else" +
" {\r\n            dialogMsg(\'请选择需要删除的地质灾害应急调查数据！\', 0);\r\n        }\r\n    }\r\n      //" +
"查询表格函数\r\n      function SearchEvent() {\r\n        var queryJson = $(\"#filter-form\"" +
").getWebControls();\r\n            $(\"#gridTable\").jqGrid(\'setGridParam\', {\r\n     " +
"            postData: { queryJson: JSON.stringify(queryJson) },\r\n               " +
"  url: \"../../JXGeoManage/TBL_YJDC_YJDCMANAGEMENT/GetPageListJson\",\r\n           " +
"      page: 1\r\n            }).trigger(\'reloadGrid\');\r\n        }\r\n    //重置控件赋值 \r\n" +
"      function ClearEvent() {\r\n          $(\"#filter-form\").find(\"input[type=\'tex" +
"t\']\").val(\"\");\r\n      }\r\n      //初始化控件\r\n      function initControl() {\r\n        " +
"  var usercode = usercodes();\r\n          var district = $(\"#XZQHCODE\").mulDistri" +
"ctsCtl({\r\n              provinceId: usercode.provinceId,\n              selectPro" +
"viceId: usercode.provinceId,\r\n              selectCityId: usercode.selectCityId," +
"\r\n              showTown: false,\r\n              type: \'B\',\r\n          });\r\n     " +
" }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591