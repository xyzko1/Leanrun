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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO/TBL_HAZARDBASICINFOQueryHXBrowse.cs" +
        "html")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_TBL_HAZARDBASICINFOQueryHXBrowse_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_TBL_HAZARDBASICINFOQueryHXBrowse_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO\TBL_HAZARDBASICINFOQueryHXBrowse.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_IndexMap.cshtml";

            
            #line default
            #line hidden
WriteLiteral(@"
<style>
    .spansa {
        padding: 0 20px !important;
        width: 9%;
        text-align: center;
        height: 28px;
        line-height: 28px;
        min-width: 113px;
    }

    .spans {
        padding: 0 10px;
        width: 9%;
        text-align: center;
        height: 28px;
        line-height: 28px;
        min-width: 100px;
    }

    .ui-select-text, .form-control {
        border-radius: 4px;
    }

    .fa-folder-open {
        color: transparent !important;
        background: url(""../../Content/images/zTreeStandard.png"") no-repeat;
        background-position: -110px -16px;
        margin-right: 2px;
        width: 16px !important;
        height: 16px !important;
    }

    .fa-folder {
        color: transparent !important;
        background: url(""../../Content/images/zTreeStandard.png"") no-repeat;
        background-position: -110px 0;
        margin-right: 2px;
        width: 16px !important;
        height: 16px !important;
    }

    .fa-file-o {
        color: transparent !important;
        background: url(""../../Content/images/zTreeStandard.png"") no-repeat;
        background-position: -110px -32px;
        width: 16px !important;
        height: 16px !important;
    }
    /*.ui-layout-pane-west {
        overflow:initial!important;
    }*/
</style>
<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(" style=\"height:100%;overflow:auto;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(" style=\"margin:0px;height:100%\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(" style=\"height:40px;line-height:40px;background-color: rgba(236, 247, 255, 1);col" +
"or:#000\"");

WriteLiteral(">行政区划</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(" id=\"ui_center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(" style=\"height: 100%;width:100%;margin-top:0px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width:100%;height:38px;background:#fff\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"GJCXH\"");

WriteLiteral(" style=\"position:absolute;top:-120px;z-index:3;width:99%;transition:all 0.6s\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害点名称:</span><input");

WriteLiteral(" id=\"DISASTERNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害点编号:</span><input");

WriteLiteral(" id=\"UNIFIEDCODE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">灾害点类型:</span><div");

WriteLiteral(" id=\"DISASTERTYPE\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                        <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">地理位置:</span><div");

WriteLiteral(" id=\"LOCATION\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral(" />\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 100%; height: 40px;background-color: rgba(255, 255, 255, 0.8);colo" +
"r:#000; display: flex; align-items: center; position: relative;\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">是否已治理:</span><div");

WriteLiteral(" id=\"ISZLGCPNT\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                    <span");

WriteLiteral(" class=\"spans\"");

WriteLiteral(">是否搬迁:</span><div");

WriteLiteral(" id=\"RELOCATION\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" style=\"width: 16%\"");

WriteLiteral("></div>\r\n                    ");

WriteLiteral("\r\n                    <div");

WriteLiteral(" id=\"\"");

WriteLiteral(" style=\"width: 25%; height: 40px;background-color: rgba(255, 255, 255, 0.8);color" +
":#000; display: flex;justify-content: flex-end; align-items: center; position: r" +
"elative;\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"btn_Search_higher_history\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" style=\"cursor: pointer; color: white;padding:4px 4px;margin-left:30px\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>查询</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" id=\"btn_Reset_history\"");

WriteLiteral(" style=\"background:gray;border:1px solid gray;height:28px;padding:4px 12px;margin" +
":0 30px; color: white; display:inline-block; cursor: pointer;\"");

WriteLiteral(">重置</a>\r\n                        <a");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" id=\"btn_ResetTree\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">重新加载行政区划树</a>\r\n                    </div>\r\n                </div>\r\n            <" +
"/div>\r\n\r\n            ");

WriteLiteral("\r\n            <div");

WriteLiteral(" id=\"DZHJManage\"");

WriteLiteral(" class=\"\"");

WriteLiteral(" style=\"width:100%;height:40px;background: rgba(236, 247, 255, 1);display:flex;al" +
"ign-items: center;position:relative;z-index:23;justify-content: start;\"");

WriteLiteral(">\r\n                ");

WriteLiteral("\r\n                <div");

WriteLiteral(" style=\"float:left;\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n                        <table>\r\n                            <tr>\r\n           " +
"                     <td");

WriteLiteral(" style=\"font-size: 14px; color: #000; padding: 0px 6px 10px 0px; font-weight: bol" +
"d !important;\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" style=\"width: 10%; font-weight: 900; min-width: 80px; white-space: nowrap;\"");

WriteLiteral(">\r\n                                        <i");

WriteLiteral(" class=\"fa fa-bars\"");

WriteLiteral(" style=\"margin:0 5px;font-weight:700;\"");

WriteLiteral("></i><span>查询条件:</span>\r\n                                    </div>\r\n            " +
"                    </td>\r\n                                <td>\r\n               " +
"                     <input");

WriteLiteral(" id=\"txt_Key\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入灾害名称或编号\"");

WriteLiteral(" style=\"width: 200px; height:28px; outline:none; margin:-7px 10px 0px 20px;\"");

WriteLiteral(" />\r\n                                </td>\r\n                                <td");

WriteLiteral(" style=\"padding:0 0 8px 3px;\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" style=\"font-size:16px; cursor:pointer;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral(" style=\"margin: -9px 10px 0px 0px\"");

WriteLiteral("></i></a>\r\n                                </td>\r\n                            </t" +
"r>\r\n                        </table>\r\n                    </div>\r\n              " +
"  </div>\r\n                <div");

WriteLiteral(" style=\"width: 90%;align-items: center;flex-wrap: nowrap;\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" id=\"serch-btn\"");

WriteLiteral(" style=\"font-size:13px;float:right;maring-right:10px;position:absolute;top:10px; " +
"right:10px;cursor:pointer\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" id=\"fontfamily\"");

WriteLiteral(" class=\"fa fa-caret-right\"");

WriteLiteral("></i>\r\n                        高级查询\r\n                    </span>\r\n               " +
" </div>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" id=\"myTabContent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(" style=\"height: calc(100% - 38px); width: 100%;background:#fff\"");

WriteLiteral(">\r\n            ");

WriteLiteral("\r\n            <div");

WriteLiteral(" id=\"LSSJCX\"");

WriteLiteral(" class=\"tab-pane fade in active\"");

WriteLiteral(" style=\"height: 100%; width: 100%;background:#fff\"");

WriteLiteral(">\r\n                <iframe");

WriteLiteral(" id=\"LSSJCXA1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" onscroll=\"no\"");

WriteLiteral(" style=\"border:none;height:100%\"");

WriteLiteral("></iframe>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    $(function () {\r\n        var AreaCode = 0, AreaVale = \"\", flag = " +
"true, tabname = \"GJCXH\";\r\n        initControl();\r\n        InitialPage();\r\n      " +
"  $(\'.ui-layout-center\').css(\'overflow\', \'hidden\');\r\n        GetTree();\r\n       " +
" $(\"#serch-btn\").click(function () {\r\n            if (flag) {\r\n                i" +
"f (tabname == \"ZXSJCX\") {\r\n                    $(\"#GJCX\").css(\"top\", 40)\r\n      " +
"          } else {\r\n                    $(\"#GJCXH\").css(\"top\", 40)\r\n            " +
"    }\r\n\r\n                $(\"#fontfamily\").removeClass();\r\n                $(\"#fo" +
"ntfamily\").addClass(\"fa fa-caret-down\")\r\n                flag = false\r\n         " +
"   } else {\r\n                if (tabname == \"ZXSJCX\") {\r\n                    $(\"" +
"#GJCX\").css(\"top\", -120)\r\n                } else {\r\n                    $(\"#GJCX" +
"H\").css(\"top\", -120)\r\n                }\r\n                $(\"#fontfamily\").remove" +
"Class();\r\n                $(\"#fontfamily\").addClass(\"fa fa-caret-right\")\r\n      " +
"          flag = true\r\n            }\r\n        })\r\n        $(\'#LSSJCXA1\').attr(\'s" +
"rc\', \"/JXGeoManage/TBL_HAZARDBASICINFO/TBL_HAZARDBASICINFOHXQuery?AreaVale=\" + A" +
"reaVale);\r\n        //高级查询点击事件\r\n        $(\"#btn_Search_higher\").click(function ()" +
" {\r\n            if ($(\'#ZXSJCXA\').attr(\'src\') != \"\" && $(\'#ZXSJCXA\').attr(\'src\')" +
" != undefined) {\r\n                var queryJson = $.extend(queryJson, $(\"#GJCX\")" +
".getWebControls(), {});\r\n                queryJson[\"PROVINCE\"] = PROVINCE;\r\n    " +
"            queryJson[\"CITY\"] = CITY;\r\n                queryJson[\"COUNTY\"] = COU" +
"NTY;\r\n                $(\'#ZXSJCXA\')[0].contentWindow.SearchEvent(queryJson);\r\n  " +
"          }\r\n        })\r\n        //高级查询点击事件\r\n        $(\"#btn_Search_higher_histo" +
"ry\").click(function () {\r\n            if ($(\'#LSSJCXA1\').attr(\'src\') != \"\" && $(" +
"\'#LSSJCXA1\').attr(\'src\') != undefined) {\r\n                var queryJson = $.exte" +
"nd(queryJson, $(\"#GJCXH\").getWebControls(), {});\r\n                queryJson[\"txt" +
"_Key\"] = $(\"#txt_Key\").val();\r\n                queryJson[\"PROVINCE\"] = PROVINCE;" +
"\r\n                queryJson[\"CITY\"] = CITY;\r\n                queryJson[\"COUNTY\"]" +
" = COUNTY;\r\n                $(\'#LSSJCXA1\')[0].contentWindow.SearchEvent(queryJso" +
"n);\r\n            }\r\n        })\r\n        //高级查询点击事件\r\n        $(\"#btn_Search\").cli" +
"ck(function () {\r\n            if ($(\'#LSSJCXA1\').attr(\'src\') != \"\" && $(\'#LSSJCX" +
"A1\').attr(\'src\') != undefined) {\r\n                var queryJson = $.extend(query" +
"Json, $(\"#GJCXH\").getWebControls(), {});\r\n                queryJson[\"txt_Key\"] =" +
" $(\"#txt_Key\").val();\r\n                queryJson[\"PROVINCE\"] = PROVINCE;\r\n      " +
"          queryJson[\"CITY\"] = CITY;\r\n                queryJson[\"COUNTY\"] = COUNT" +
"Y;\r\n                $(\'#LSSJCXA1\')[0].contentWindow.SearchEvent(queryJson);\r\n   " +
"         }\r\n        })\r\n        //重置\r\n        $(\"#btn_Reset_history\").click(func" +
"tion () {\r\n            $(\"#DISASTERNAME\").val(\"\");\r\n            $(\"#UNIFIEDCODE\"" +
").val(\"\");\r\n            $(\"#DISASTERTYPE\").val(\"\");\r\n            $(\"#DISASTERTYP" +
"E\").attr(\"data-value\", \"\").attr(\"data-text\", \"\");\r\n            $(\"#DISASTERTYPE " +
".ui-select-text\").text(\" \");\r\n            $(\"#ISZLGCPNT\").val(\"\");\r\n            " +
"$(\"#ISZLGCPNT\").attr(\"data-value\", \"\").attr(\"data-text\", \"\");\r\n            $(\"#I" +
"SZLGCPNT .ui-select-text\").text(\" \");\r\n\r\n            $(\"#RELOCATION\").val(\"\");\r\n" +
"            $(\"#RELOCATION\").attr(\"data-value\", \"\").attr(\"data-text\", \"\");\r\n    " +
"        $(\"#RELOCATION .ui-select-text\").text(\" \");\r\n            //$(\"#ENDTIME\")" +
".val(\"\");\r\n\r\n        });\r\n        //重新加载行政区划树\r\n        $(\"#btn_ResetTree\").click" +
"(function () {\r\n            GetTree();\r\n        });\r\n        //初始化页面\r\n        fu" +
"nction InitialPage() {\r\n            var isResize = 0;\r\n            //layout布局\r\n " +
"           $(\'#layout\').layout({\r\n                west__size: 190,\r\n            " +
"    applyDemoStyles: true,\r\n                onresize: function () {\r\n           " +
"         if (isResize < 10) {\r\n                        isResize++;\r\n            " +
"        }\r\n                    resize();\r\n                }\r\n            });\r\n  " +
"          //layout.sizePane(\"\")\r\n            //resize重设布局;\r\n            $(window" +
").resize(function (e) {\r\n                if (isResize < 10) {\r\n                 " +
"   isResize++;\r\n                }\r\n                resize();\r\n                e." +
"stopPropagation();\r\n            });\r\n            function resize() {\r\n          " +
"      window.setTimeout(function () {\r\n                    $(\'#layout2 .ui-layou" +
"t-center\').css(\'overflow\', \'hidden\');\r\n\r\n                }, 200);\r\n             " +
"   $(\'#layout2 .ui-layout-center\').css(\'overflow\', \'hidden\');\r\n                $" +
"(\"#itemTree\").height($(\'.ui-layout-west\').height() - 45);\r\n            };\r\n     " +
"   }\r\n        //加载行政区划树\r\n        var AreaCode = 0, PROVINCE = \"\", CITY = \"\", COU" +
"NTY = \"\";\r\n        function GetTree() {\r\n            var item = {\r\n             " +
"   height: $(window).height() - 52,\r\n                isAllExpand: false,\r\n      " +
"          url: \"../../Map/GetTreeJsonForMap\",\r\n                onnodeclick: func" +
"tion (item) {\r\n                    AreaCode = item.id;\r\n                    Area" +
"Vale = item.value;\r\n                    var level = item.value.split(\',\')[1];\r\n " +
"                   if (level == 1) {\r\n                        PROVINCE = item.id" +
";\r\n                        CITY = \"\";\r\n                        COUNTY = \"\";\r\n   " +
"                 } else if (level == 2) {\r\n                        PROVINCE = it" +
"em.id.substring(0, 2) + \"0000\";\r\n                        CITY = item.id;\r\n      " +
"                  COUNTY = \"\";\r\n                    } else if (level == 3) {\r\n  " +
"                      PROVINCE = item.id.substring(0, 2) + \"0000\";\r\n            " +
"            CITY = item.id.substring(0, 4) + \"00\";\r\n                        COUN" +
"TY = item.id;\r\n                    } else if (level == -1) {\r\n                  " +
"      PROVINCE = \"\";\r\n                        CITY = \"\";\r\n                      " +
"  COUNTY = \"\";\r\n                    }\r\n\r\n                    if ($(\'#LSSJCXA1\')." +
"attr(\'src\') != \"\" && $(\'#LSSJCXA1\').attr(\'src\') != undefined) {\r\n               " +
"         var queryJson = $.extend(queryJson, $(\"#GJCXH\").getWebControls(), {});\r" +
"\n                        queryJson[\"AreaCode\"] = AreaCode;\r\n                    " +
"    queryJson[\"PROVINCE\"] = PROVINCE;\r\n                        queryJson[\"CITY\"]" +
" = CITY;\r\n                        queryJson[\"COUNTY\"] = COUNTY;\r\n               " +
"         $(\'#LSSJCXA1\')[0].contentWindow.SearchEvent(queryJson);\r\n              " +
"          var data = [{\r\n                            latitude: item.value.split(" +
"\',\')[3],\r\n                            longitude: item.value.split(\',\')[2],\r\n    " +
"                        popupHtml: \"\"\r\n                        }]\r\n             " +
"           $(\'#LSSJCXA1\')[0].contentWindow.mapCtlExt.addLocation(data, false, le" +
"vel);\r\n                    }\r\n                },\r\n            };\r\n            //" +
"初始化\r\n            $(\"#itemTree\").treeview(item);\r\n        };\r\n        //初始化控件\r\n  " +
"      function initControl() {\r\n            //是否治理\r\n            $(\"#ISZLGCPNT\")." +
"ComboBox({\r\n                data: [{ \'text\': \'是\', \'value\': 1 }, { \'text\': \'否\', \'" +
"value\': 0 }],\r\n                id: \"value\",\r\n                text: \"text\",\r\n    " +
"            height: \'200px\'\r\n            });\r\n\r\n            //是否搬迁\r\n            " +
"$(\"#RELOCATION\").ComboBox({\r\n                data: [{ \'text\': \'是\', \'value\': 1 }," +
" { \'text\': \'否\', \'value\': 0 }],\r\n                id: \"value\",\r\n                te" +
"xt: \"text\",\r\n                height: \'200px\'\r\n            });\r\n\r\n            //项" +
"目类型\r\n            //$(\"#PROJECTID\").ComboBox({\r\n            //    data: [{ \'text\'" +
": \'调查\', \'value\': \"\" }, { \'text\': \'排查\', \'value\': 0 }],\r\n            //    id: \"va" +
"lue\",\r\n            //    text: \"text\",\r\n            //    height: \'200px\'\r\n     " +
"       //});\r\n            //灾害类型\r\n            $(\"#DISASTERTYPE\").ComboBox({\r\n   " +
"             url: \"../../SystemManage/DataItemDetail/GetDataItemTreeJson\",\r\n    " +
"            param: { EnCode: \"HazardType\" },\r\n                id: \"text\",\r\n     " +
"           text: \"text\",\r\n                multiple: true,\r\n                heigh" +
"t: \'210px\',\r\n                description: \"==请选择==\"\r\n            });\r\n        }\r" +
"\n\r\n    });\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591