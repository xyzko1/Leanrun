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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/DemoManage/Views/Base_Area/Base_AreaIndex.cshtml")]
    public partial class _Areas_DemoManage_Views_Base_Area_Base_AreaIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_DemoManage_Views_Base_Area_Base_AreaIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\DemoManage\Views\Base_Area\Base_AreaIndex.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 86), Tuple.Create("\"", 142)
, Tuple.Create(Tuple.Create("", 93), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/uploadify/uploadify.css")
, 93), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 169), Tuple.Create("\"", 235)
, Tuple.Create(Tuple.Create("", 176), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/uploadify/uploadify.extension.css")
, 176), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 264), Tuple.Create("\"", 329)
, Tuple.Create(Tuple.Create("", 270), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/uploadify/jquery.uploadify.min.js")
, 270), false)
);

WriteLiteral("></script>\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 346), Tuple.Create("\"", 403)
, Tuple.Create(Tuple.Create("", 353), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap-editable.css")
, 353), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 432), Tuple.Create("\"", 491)
, Tuple.Create(Tuple.Create("", 438), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/bootstrap/bootstrap-editable.min.js")
, 438), false)
);

WriteLiteral("></script>\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 508), Tuple.Create("\"", 568)
, Tuple.Create(Tuple.Create("", 515), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/webuploader/webuploader.css")
, 515), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 597), Tuple.Create("\"", 661)
, Tuple.Create(Tuple.Create("", 603), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/webuploader/webuploader.nolog.js")
, 603), false)
);

WriteLiteral("></script>\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 680), Tuple.Create("\"", 730)
, Tuple.Create(Tuple.Create("", 686), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/pdf/html2canvas.js")
, 686), false)
);

WriteLiteral("></script>\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 749), Tuple.Create("\"", 797)
, Tuple.Create(Tuple.Create("", 755), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/pdf/jspdf.min.js")
, 755), false)
);

WriteLiteral("></script>\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 816), Tuple.Create("\"", 864)
, Tuple.Create(Tuple.Create("", 822), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/pdf/pdfHelper.js")
, 822), false)
);

WriteLiteral("></script>\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 883), Tuple.Create("\"", 935)
, Tuple.Create(Tuple.Create("", 889), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/utils/MultMedia/multMedia.js")
, 889), false)
);

WriteLiteral("></script>\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 954), Tuple.Create("\"", 1021)
, Tuple.Create(Tuple.Create("", 960), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/infoearthcustom/MultMediaControl.js")
, 960), false)
);

WriteLiteral("></script>\n<script>\n    ;\n    var layout2NorthH = 1;\n    $(function () {\n        " +
"InitialPage();\n        GetTree();\n        GetMapData();\n        GetGrid();\n     " +
"   //$(\".ui-layout-west\").css(\"overflow\", \"hidden !important\");\n        //查询点击事件" +
"\n        $(\"#btn_Search\").click(function () {\n            SearchEvent();\n       " +
" });\n\n        $(\"#itemTree\").setNodeChecked(\'370100\');\n    });\n    //初始化页面\n    f" +
"unction InitialPage() {\n        //layout布局\n        $(\'#layout\').layout({\n       " +
"     applyDemoStyles: true,\n            onresize: function () {\n                " +
"if (isResize < 10) {\n                    isResize++;\n                }\n         " +
"       resize();\n            }\n        });\n        var isResize = 0;\n        var" +
" count = 0;\n        var resized = 0;\n        $(\'#layout2\').layout({\n            " +
"applyDemoStyles: true,\n            onresize: function () {\n                resiz" +
"e();\n                if (isResize > 1) {\n                    resized = 1;\n      " +
"              //$(\"#layout2 .ui-layout-center\").height($(\"#layout2 .ui-layout-ce" +
"nter\").height() + 18);\n                } else {\n                    if (count ==" +
" 1 || resized == 0) {\n                        $(\"#layout2 .ui-layout-center\").he" +
"ight($(\"#layout2 .ui-layout-center\").height() - 18);\n                    }\n     " +
"           }\n                count++;\n            }\n        });\n        //resize" +
"重设布局;\n        $(window).resize(function (e) {\n            if (isResize < 10) {\n " +
"               isResize++;\n            }\n            resize();\n            e.sto" +
"pPropagation();\n        });\n        function resize() {\n            window.setTi" +
"meout(function () {\n                if (mapCtlExt != null) {\n                   " +
" mapCtlExt.setHeight($(\"#mapControl\").parent().height() - 32 - 4);\n             " +
"   }\n                $(\".center-Panel\").height($(\"#layout\").parent().height() - " +
"20);\n                $(\"#pdfTest\").height($(\"#layout\").parent().height() - 20);\n" +
"                $(\"#layout2\").width($(\"#pdfTest\").width() - 9);\n                " +
"//$(\"#layout2 .ui-layout-center\").height($(\"#layout2 .ui-layout-center\").height(" +
")  - 18);\n                $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width())" +
");\n\n                $(\"#layout2 .ui-layout-center\").width($(\"#layout2 .ui-layout" +
"-center\").parent().width() - 10);\n                $(\"#layout2 .ui-layout-resizer" +
"\").width($(\"#layout2 .ui-layout-center\").parent().width() - 10);\n\n              " +
"  $(\'#gridTable\').setGridHeight($(window).height() - $(\"#mapControl\").height() -" +
" $(\".panel-Title\").height());\n                $(\'#gridTable\').setGridHeight($(\"#" +
"layout2 .ui-layout-center\").height() - 60 - 60);\n                $(\'.ui-jqgrid-b" +
"div\').height($(\"#layout2 .ui-layout-center\").height() - 60 - 60);\n              " +
"  $(\"#layout2 .ui-layout-center\").height($(\"#layout2\").height() - $(\"#layout2 .u" +
"i-layout-north\").height() - 15);\n                $(\'#gridTable\').setGridHeight($" +
"(\"#layout2 .ui-layout-center\").height() - 115);\n                $(\"#layout2 .ui-" +
"layout-center\").css(\"overflow\", \"hidden\");\n            }, 200);\n        };\n     " +
"   $(window).resize();\n        //$(\"#layout2 .ui-layout-center\").height($(\"#layo" +
"ut2 .ui-layout-center\").height() - 18);\n        layout2NorthH = $(\"#layout2 .ui-" +
"layout-north\").height();\n        var mult = $(\"#multMediaControl\").MultMediaCont" +
"rol();\n        $(\"#testMult\").click(function () {\n            mult.g\n        });" +
"\n    }\n    //加载行政区划树\n    var AreaCode = 0;\n    function GetTree() {\n        var " +
"item = {\n            height: $(window).height() - 52,\n            isAllExpand: f" +
"alse,\n            isSearch:true,\n            url: \"../../Map/GetTreeJsonForMap\"," +
"\n            searchUrl: \"../../Map/GetTreeJsonForMap\",\n            onnodeclick: " +
"function (item) {\n                AreaCode = item.id;\n                if (item.v" +
"alue.split(\',\')[1] < 3) {\n                    //展开下级\n                    $(\".bbi" +
"t-tree-selected\").children(\'.bbit-tree-ec-icon\').trigger(\"click\");\n             " +
"   }\n                $(\'#btn_Search\').trigger(\"click\");\n            },\n        }" +
";\n        //初始化\n        $(\"#itemTree\").treeview(item);\n    };\n    //加载地图\n    var" +
" mapCtlExt = null;\n    function GetMapData() {\r\n        mapCtlExt = $(\"#mapContr" +
"ol\").mapCtl(\r\n            cfGetMapData({}));\n    };\n    //加载表格\n    function GetG" +
"rid() {\n        var selectedRowIndex = 0;\n        var queryJson = $(\"#filter-for" +
"m\").getWebControls();\n        queryJson[\"AreaCode\"] = AreaCode;\n        var $gri" +
"dTable = $(\'#gridTable\');\n        $gridTable.jqGrid({\n            autowidth: tru" +
"e,\n            postData: { queryJson: JSON.stringify(queryJson) },\n            h" +
"eight: $(window).height() - 570,\n            url: \"../../DemoManage/Base_Area/Ge" +
"tPageListJson\",\n            datatype: \"json\",\n            colModel: [\n          " +
"      { label: \'区域主键\', name: \'F_AreaId\', index: \'F_AreaId\', width: 100, align: \'" +
"left\', sortable: true },\n                { label: \'父级主键\', name: \'F_ParentId\', in" +
"dex: \'F_ParentId\', width: 100, align: \'left\', sortable: true },\n                " +
"{ label: \'区域编码\', name: \'F_AreaCode\', index: \'F_AreaCode\', width: 100, align: \'le" +
"ft\', sortable: true },\n                { label: \'区域名称\', name: \'F_AreaName\', inde" +
"x: \'F_AreaName\', width: 100, align: \'left\', sortable: true },\n                { " +
"label: \'快速查询\', name: \'F_QuickQuery\', index: \'F_QuickQuery\', width: 100, align: \'" +
"left\', sortable: true },\n                { label: \'简拼\', name: \'F_SimpleSpelling\'" +
", index: \'F_SimpleSpelling\', width: 100, align: \'left\', sortable: true },\n      " +
"          { label: \'层次\', name: \'F_Layer\', index: \'F_Layer\', width: 100, align: \'" +
"left\', sortable: true },\n            ],\n            viewrecords: true,\n         " +
"   rowNum: 30,\n            rowList: [30, 50, 100],\n            pager: \"#gridPage" +
"r\",\n            sortname: \'F_AreaId\',\n            sortorder: \'desc\',\n           " +
" rownumbers: true,\n            shrinkToFit: false,\n            gridview: true,\n " +
"           onSelectRow: function () {\n                selectedRowIndex = $(\'#\' +" +
" this.id).getGridParam(\'selrow\');\n            },\n            gridComplete: funct" +
"ion () {\n                $(\'#\' + this.id).setSelection(selectedRowIndex, false);" +
"\n            }\n        });\n    }\n    //新增\n    function btn_add() {\n        dialo" +
"gOpen({\n            id: \'Form\',\n            title: \'添加行政区域表\',\n            url: \'" +
"/DemoManage/Base_Area/Base_AreaForm\',\n            width: \'500px\',\n            he" +
"ight: \'400px\',\n            callBack: function (iframeId) {\n                getIn" +
"foTop().frames[iframeId].AcceptClick();\n            }\n        });\n    }\n    //编辑" +
"\n    function btn_edit() {\n        var keyValue = $(\"#gridTable\").jqGridRowValue" +
"(\'F_AreaId\');\n        if (checkedRow(keyValue)) {\n            dialogOpen({\n     " +
"           id: \'Form\',\n                title: \'编辑行政区域表\',\n                url: \'/" +
"DemoManage/Base_Area/Base_AreaForm?keyValue=\' + keyValue,\n                width:" +
" \'500px\',\n                height: \'400px\',\n                callBack: function (i" +
"frameId) {\n                    getInfoTop().frames[iframeId].AcceptClick();\n    " +
"            }\n            })\n        }\n    }\n    //删除\n    function btn_delete() " +
"{\n        var keyValue = $(\"#gridTable\").jqGridRowValue(\'F_AreaId\');\n        if " +
"(keyValue) {\n            $.RemoveForm({\n                url: \'../../DemoManage/B" +
"ase_Area/RemoveForm\',\n                param: { keyValue: keyValue },\n           " +
"     success: function (data) {\n                    $(\'#gridTable\').trigger(\'rel" +
"oadGrid\');\n                }\n            })\n        } else {\n            dialogM" +
"sg(\'请选择需要删除的行政区域表！\', 0);\n        }\n    }\n    //查询表格函数\n    function SearchEvent()" +
" {\n        var queryJson = $(\"#filter-form\").getWebControls();\n        queryJson" +
"[\"AreaCode\"] = AreaCode\n        $(\"#gridTable\").jqGrid(\'setGridParam\', {\n       " +
"     postData: { queryJson: JSON.stringify(queryJson) },\n            url: \"../.." +
"/DemoManage/Base_Area/GetPageListJson\",\n            page: 1\n        }).trigger(\'" +
"reloadGrid\');\n    }\n\n    function reload() {\n\n        exportPDF($(\"#pdfTest\"), $" +
"(\"#pdfTest\").height(), false, true)\n    }\n\n\n    function ColDataGrid() {\n       " +
" var centerHeight = $(\"#ui_center .ui-layout\").height();\n        var layout2 = $" +
"(\'#layout2\').layout();\n\n        if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-down" +
"\")) {\n            var northH = centerHeight - 65;\n            layout2.sizePane(\"" +
"north\", northH);\n            $(\"#lr-colgrid i\").removeClass(\"fa-chevron-down\");\n" +
"            $(\"#lr-colgrid i\").addClass(\"fa-chevron-up\");\n            if ($(\"#lr" +
"-colmap i\").hasClass(\"fa-chevron-down\")) {\n                $(\"#lr-colmap i\").rem" +
"oveClass(\"fa-chevron-down\");\n                $(\"#lr-colmap i\").addClass(\"fa-chev" +
"ron-up\");\n            }\n        }\n        else {\n            layout2.sizePane(\"n" +
"orth\", layout2NorthH);\n            $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up" +
"\");\n            $(\"#lr-colgrid i\").addClass(\"fa-chevron-down\");\n\n        }\n     " +
"   mapCtlExt.updateSize();\n    }\n\n    function ColMapDiv() {\n        var layout2" +
" = $(\'#layout2\').layout();\n        if ($(\"#lr-colmap i\").hasClass(\"fa-chevron-up" +
"\")) {\n            layout2.sizePane(\"north\", 1);\n            $(\"#lr-colmap i\").re" +
"moveClass(\"fa-chevron-up\");\n            $(\"#lr-colmap i\").addClass(\"fa-chevron-d" +
"own\");\n            if ($(\"#lr-colgrid i\").hasClass(\"fa-chevron-up\")) {\n         " +
"       $(\"#lr-colgrid i\").removeClass(\"fa-chevron-up\");\n                $(\"#lr-c" +
"olgrid i\").addClass(\"fa-chevron-down\");\n            }\n        }\n        else {\n " +
"           layout2.sizePane(\"north\", layout2NorthH);\n            $(\"#lr-colmap i" +
"\").removeClass(\"fa-chevron-down\");\n            $(\"#lr-colmap i\").addClass(\"fa-ch" +
"evron-up\");\n            if (mapCtlExt != null) {\n                mapCtlExt.setHe" +
"ight($(\"#mapControl\").parent().height() - 32 - 4);\n            }\n        }\n     " +
"   mapCtlExt.updateSize();\n    }\n\n</script>\n<style>\n    .ui-layout-center {\n    " +
"    overflow-x: hidden !important;\n    }\n\n    .ui-layout-resizer {\n        backg" +
"round-color: #f0f3f4 !important;\n    }\n    .div_close {\n        float: right;\n  " +
"      width: 12px;\n        height: 13px;\n        margin-right: -5px;\n        mar" +
"gin-left: 5px;\n        margin-top: 0px;\n        display: block;\n        backgrou" +
"nd: url(../../../../Content/adminDefault/img/tab_close.png) no-repeat;\n    }\n\n  " +
"      .div_close:hover {\n            background-position: 0 -12px;\n        }\n</s" +
"tyle>\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(">\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">行政区划信息</div>\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\n        </div>\n    </div>\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_center\"");

WriteLiteral(">\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%;\"");

WriteLiteral(" id=\"pdfTest\"");

WriteLiteral(">\n            ");

WriteLiteral("\n            <div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout2\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\n\n                <div");

WriteLiteral(" class=\"ui-layout-north\"");

WriteLiteral(" style=\"height: 432px;\"");

WriteLiteral(" id=\"ui_map\"");

WriteLiteral(">\n                    <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">地图</div>\n                    <div");

WriteLiteral(" id=\"mapControl\"");

WriteLiteral(" style=\"height: 400px;\"");

WriteLiteral("></div>\n                </div>\n                <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_grid\"");

WriteLiteral(">\n                    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\n                        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\n                            <table>\n                                <tr>\n      " +
"                              <td>\n                                        <inpu" +
"t");

WriteLiteral(" id=\"F_AreaId\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\n                                    </td>\n                                   " +
" <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\n                                        <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\n                                    </td>\n                           " +
"     </tr>\n                            </table>\n                        </div>\n " +
"                       <div");

WriteLiteral(" style=\"float: right; margin-right: 10px;\"");

WriteLiteral(">\n                            <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\n                                <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>刷新</a>\n                                <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>新增</a>\n                                <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>编辑</a>\n                                <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>删除</a>\n                                <a");

WriteLiteral(" id=\"lr-detail\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>Excel测试</a>\n                            </div>\n                            <" +
"div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\n                                <a");

WriteLiteral(" id=\"lr-colgrid\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColDataGrid()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-down\"");

WriteLiteral("></i>列表</a>\n                                <a");

WriteLiteral(" id=\"lr-colmap\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"ColMapDiv()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-chevron-up\"");

WriteLiteral("></i>地图</a>\n                            </div>\n                        </div>\n   " +
"                     <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\n                    </div>\n                    <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\n                        <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\n                        <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\n                    </div>\n                    <div");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\n                        <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">行政区划控件</div>\n                        <div");

WriteLiteral(" id=\"districtControl\"");

WriteLiteral(" style=\"width: 100%;\"");

WriteLiteral("></div>\n                        <div>\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"获取值\"");

WriteLiteral(" id=\"getDistrict\"");

WriteLiteral(" />\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"设置值\"");

WriteLiteral(" id=\"setDistrict\"");

WriteLiteral(" />\n                        </div>\n                        <div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\n\n                        <div");

WriteLiteral(" class=\"pane\"");

WriteLiteral(" id=\"kneecoordinate\"");

WriteLiteral("></div>\n                        <div");

WriteLiteral(" class=\"pane\"");

WriteLiteral(">\n\n                            <a");

WriteLiteral(" id=\"displayKneecoor\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">显示拐点区域</a>\n\n                        </div>\n                    </div>\n          " +
"              <div");

WriteLiteral(" id=\"multMediaControl\"");

WriteLiteral(" style=\"width: 100%; padding: 20px; clear: both; margin-top: 0px; border-left: 1p" +
"x solid blue; border-bottom: 1px solid blue; border-right: 1px solid blue; borde" +
"r-top: 1px solid blue; \"");

WriteLiteral("></div>\n                    <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"testMult\"");

WriteLiteral(" value=\"测试多媒体获取数据\"");

WriteLiteral(" />\n\n                </div>\n            </div>\n            ");

WriteLiteral("\n        </div>\n    </div>\n</div>\n");

        }
    }
}
#pragma warning restore 1591
