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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FormManage/Views/FormModule/Index.cshtml")]
    public partial class _Areas_FormManage_Views_FormModule_Index_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FormManage_Views_FormModule_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FormManage\Views\FormModule\Index.cshtml"
  
    ViewBag.Title = "表单设计管理";
    Layout = "~/Views/Shared/_LayoutIndex.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"ui-layout\"");

WriteLiteral(" id=\"layout\"");

WriteLiteral(" style=\"height: 100%; width: 100%;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ui-layout-west\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"west-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">表单类别</div>\r\n            <div");

WriteLiteral(" id=\"itemTree\"");

WriteLiteral("></div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"ui-layout-center\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"center-Panel\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-Title\"");

WriteLiteral(">表单管理</div>\r\n            <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n                    <table>\r\n                        <tr>\r\n                   " +
"         <td>\r\n                                <input");

WriteLiteral(" id=\"txt_Keyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n                            </td>\r\n                            <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i>&nbsp;查询</a>\r\n                            </td>\r\n                        </t" +
"r>\r\n                    </table>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"learun.reload();\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n                        <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral("     class=\"btn btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n                        <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral("    class=\"btn btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n                        <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral("  class=\"btn btn-default\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n                        <a");

WriteLiteral(" id=\"lr-more\"");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" aria-expanded=\"false\"");

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-reorder\"");

WriteLiteral("></i>&nbsp;更多<span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span>\r\n                        </a>\r\n                        <ul");

WriteLiteral(" class=\"dropdown-menu pull-right\"");

WriteLiteral(" aria-labelledby=\"lr-more\"");

WriteLiteral(">\r\n                            <li");

WriteLiteral(" id=\"lr-preview\"");

WriteLiteral("><a><i></i>&nbsp;预览表单</a></li>\r\n                            <li");

WriteLiteral(" id=\"lr-enabled\"");

WriteLiteral("><a><i></i>&nbsp;启用表单</a></li>\r\n                            <li");

WriteLiteral(" id=\"lr-disabled\"");

WriteLiteral("><a><i></i>&nbsp;停用表单</a></li>\r\n                        </ul>\r\n                  " +
"  </div>\r\n                </div>\r\n                <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<script>\r\n    (f" +
"unction ($) {\r\n        var indexJs = {\r\n            initialPage: function () {\r\n" +
"                //layout布局\r\n                $(\'#layout\').layout({\r\n             " +
"       applyDemoStyles: true,\r\n                    onresize: function () {\r\n    " +
"                    $(window).resize();\r\n                    }\r\n                " +
"});\r\n                //resize重设(表格、树形)宽高\r\n                $(window).resize(funct" +
"ion (e) {\r\n                    window.setTimeout(function () {\r\n                " +
"        $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n              " +
"          $(\"#gridTable\").setGridHeight($(window).height() - 169.5);\r\n          " +
"              $(\"#itemTree\").setTreeHeight($(window).height() - 52);\r\n          " +
"          }, 200);\r\n                    e.stopPropagation();\r\n                })" +
";\r\n            },\r\n            initialTree: function () {\r\n                var i" +
"tem = {\r\n                    height: $(window).height() - 52,\r\n                 " +
"   param: { EnCode: \"FormSort\" },\r\n                    url: \"../../SystemManage/" +
"DataItemDetail/GetDataItemTreeJson\",\r\n                    onnodeclick: function " +
"(item) {\r\n                        var queryJson = { F_FrmCategory: item.id };\r\n " +
"                       indexJs.event.search(queryJson);\r\n                    }\r\n" +
"                };\r\n                //初始化\r\n                $(\"#itemTree\").treevi" +
"ew(item);\r\n            },\r\n            initialGrid: function () {\r\n             " +
"   var selectedRowIndex = 0;\r\n                $(\"#gridTable\").jqGrid({\r\n        " +
"            url: \"../../FormManage/FormModule/GetPageListJson\",\r\n               " +
"     datatype: \"json\",\r\n                    height: $(window).height() - 169.5,\r" +
"\n                    autowidth: true,\r\n                    colModel: [\r\n        " +
"                { label: \'主键\', name: \'F_FrmId\', hidden: true },\r\n               " +
"         { label: \'数据库Id\', name: \'F_FrmDbId\', hidden: true },\r\n                 " +
"       { label: \'表单编号\', name: \'F_FrmCode\', index: \'F_FrmCode\', width: 100, align" +
": \'left\' },\r\n                        { label: \'表单名称\', name: \'F_FrmName\', index: " +
"\'F_FrmName\', width: 120, align: \'left\' },\r\n                        {\r\n          " +
"                  label: \'分类\', name: \'F_FrmCategory\', index: \'F_FrmCategory\', wi" +
"dth: 100, align: \'center\',\r\n                            formatter: function (cel" +
"lvalue, options, rowObject) {\r\n                                return top.learun" +
".data.get([\"dataItem\", \"FormSort\", cellvalue]);\r\n                            }\r\n" +
"                        },\r\n                        {\r\n                         " +
"   label: \"表单类型\", name: \"F_FrmType\", index: \"F_FrmType\", width: 120, align: \"cen" +
"ter\",\r\n                            formatter: function (cellvalue, options, rowO" +
"bject) {\r\n                                if (cellvalue == 0) {\r\n               " +
"                     return \'<span  class=\\\"label label-primary\\\">自定义表单</span>\';" +
"\r\n                                } else if (cellvalue == 1) {\r\n                " +
"                    return \'<span  class=\\\"label label-warning\\\">自定义表单(建表)</span" +
">\';\r\n                                } else {\r\n                                 " +
"   return \'<span  class=\\\"label label-danger\\\">系统表单</span>\';\r\n                  " +
"              }\r\n                            }\r\n                        },\r\n    " +
"                    { label: \'版本号\', name: \'F_Version\', index: \'F_Version\', width" +
": 160, align: \"left\" },\r\n                        { label: \'状态Id\', name: \'F_Enabl" +
"edMark\', index: \'F_EnabledMark\', hidden: true },\r\n                        {\r\n   " +
"                         label: \"状态\", name: \"f_enabledmarklabl\", index: \"f_enabl" +
"edmarklabl\", width: 60, align: \"center\",\r\n                            formatter:" +
" function (cellvalue, options, rowObject) {\r\n                                if " +
"(rowObject.F_EnabledMark == 1) {\r\n                                    return \'<s" +
"pan  class=\\\"label label-success\\\">启用</span>\';\r\n                                " +
"} else if (rowObject.F_EnabledMark == 0) {\r\n                                    " +
"return \'<span  class=\\\"label label-danger\\\">停用</span>\';\r\n                       " +
"         } else if (rowObject.F_EnabledMark == 3) {\r\n                           " +
"         return \'<span  class=\\\"label label-info\\\">草稿</span>\';\r\n                " +
"                } else {\r\n                                    return \'\';\r\n      " +
"                          }\r\n                            }\r\n                    " +
"    },\r\n                        { label: \"创建用户\", name: \"F_CreateUserName\", index" +
": \"F_CreateUserName\", width: 100, align: \"left\" },\r\n                        {\r\n " +
"                           label: \"创建时间\", name: \"F_CreateDate\", index: \"F_Create" +
"Date\", width: 150, align: \"left\",\r\n                            formatter: functi" +
"on (cellvalue, options, rowObject) {\r\n                                return for" +
"matDate(cellvalue, \'yyyy-MM-dd hh:mm:ss\');\r\n                            }\r\n     " +
"                   },\r\n                        { label: \"备注\", name: \"F_Descripti" +
"on\", index: \"F_Description\", width: 200, align: \"left\" }\r\n                    ]," +
"\r\n                    viewrecords: true,\r\n                    rowNum: 30,\r\n     " +
"               rowList: [30, 50, 100],\r\n                    pager: \"#gridPager\"," +
"\r\n                    sortname: \'F_CreateDate desc\',\r\n                    rownum" +
"bers: true,\r\n                    shrinkToFit: false,\r\n                    gridvi" +
"ew: true,\r\n                    onSelectRow: function () {\r\n                     " +
"   selectedRowIndex = $(\"#\" + this.id).getGridParam(\'selrow\');\r\n                " +
"    },\r\n                    gridComplete: function () {\r\n                       " +
" $(\"#\" + this.id).setSelection(selectedRowIndex, false);\r\n                    }\r" +
"\n                });\r\n            },\r\n            bindEvent: function () {\r\n    " +
"            //查询事件\r\n                $(\"#btn_Search\").click(function () {\r\n      " +
"              var queryJson = { Keyword: $(\"#txt_Keyword\").val() };\r\n           " +
"         indexJs.event.search(queryJson);\r\n                });\r\n                " +
"//新增\r\n                $(\"#lr-add\").click(indexJs.event.btnAdd);\r\n               " +
" //编辑\r\n                $(\"#lr-edit\").click(indexJs.event.btnEdit);\r\n            " +
"    //编辑\r\n                $(\"#lr-delete\").click(indexJs.event.btnDelete);\r\n     " +
"           //预览\r\n                $(\"#lr-preview\").click(indexJs.event.btnPreview" +
");\r\n                //启用\r\n                $(\"#lr-enabled\").click(indexJs.event.b" +
"tnEnable);\r\n                //停用\r\n                $(\"#lr-disabled\").click(indexJ" +
"s.event.btnDisable);\r\n            },\r\n            event: {\r\n                sear" +
"ch: function (queryJson) {\r\n                    $(\"#gridTable\").jqGrid(\'setGridP" +
"aram\', {\r\n                        postData: { queryJson: JSON.stringify(queryJso" +
"n) },\r\n                    }).trigger(\'reloadGrid\');\r\n                },\r\n      " +
"          btnAdd: function () {\r\n                    dialogOpen({\r\n             " +
"           id: \"FormBuider\",\r\n                        title: \'新增表单\',\r\n          " +
"              url: \'/FormManage/FormModule/FormBuider\',\r\n                       " +
" width: \"1100px\",\r\n                        height: \"700px\",\r\n                   " +
"     btn: null,\r\n                        callBack: function (iframeId) {\r\n      " +
"                      getInfoTop().frames[iframeId].AcceptClick();\r\n            " +
"            }\r\n                    });\r\n                },\r\n                btnE" +
"dit: function () {\r\n                    var keyValue = $(\"#gridTable\").jqGridRow" +
"Value(\"F_FrmId\");\r\n                    if (checkedRow(keyValue)) {\r\n            " +
"            dialogOpen({\r\n                            id: \"FormBuider\",\r\n       " +
"                     title: \'修改表单\',\r\n                            url: \'/FormMana" +
"ge/FormModule/FormBuider?keyValue=\' + keyValue,\r\n                            wid" +
"th: \"1100px\",\r\n                            height: \"700px\",\r\n                   " +
"         btn: null,\r\n                            callBack: function (iframeId) {" +
"\r\n                                getInfoTop().frames[iframeId].AcceptClick();\r\n" +
"                            }\r\n                        });\r\n                    " +
"}\r\n                },\r\n                btnDelete: function () {\r\n               " +
"     var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_FrmId\");\r\n                " +
"    if (keyValue) {\r\n                        learun.removeForm({\r\n              " +
"              url: \"/FormManage/FormModule/VirtualRemove\",\r\n                    " +
"        param: { keyValue: keyValue },\r\n                            success: fun" +
"ction (data) {\r\n                                $(\"#gridTable\").trigger(\"reloadG" +
"rid\");\r\n                            }\r\n                        })\r\n             " +
"       } else {\r\n                        dialogMsg(\'请选择需要删除的表单模板！\', 0);\r\n       " +
"             }\r\n                },\r\n                btnPreview: function () {\r\n " +
"                   var keyValue = $(\"#gridTable\").jqGridRowValue(\"F_FrmId\");\r\n  " +
"                  var frmname = $(\"#gridTable\").jqGridRowValue(\"F_FrmName\");\r\n  " +
"                  if (keyValue) {\r\n                        dialogOpen({\r\n       " +
"                     id: \"FormPreview\",\r\n                            title: \'表单预" +
"览【\' + frmname + \"】\",\r\n                            url: \'/FormManage/FormModule/F" +
"ormPreview?keyValue=\' + keyValue,\r\n                            width: \"800px\",\r\n" +
"                            height: \"550px\",\r\n                            callBa" +
"ck: function () {\r\n                            }\r\n                        });\r\n " +
"                   }\r\n                    else {\r\n                        dialog" +
"Msg(\'请选择要设计的表单模板！\', 0);\r\n                    }\r\n                },\r\n            " +
"    btnEnable: function () {\r\n                    var keyValue = $(\"#gridTable\")" +
".jqGridRowValue(\"F_FrmId\");\r\n                    var enabledmark = $(\"#gridTable" +
"\").jqGridRowValue(\"F_EnabledMark\");\r\n                    if (keyValue) {\r\n      " +
"                  if (enabledmark == 3) {\r\n                            dialogMsg" +
"(\'草稿不能被启用！\', 0);\r\n                            return;\r\n                        }" +
"\r\n                        $.ConfirmAjax({\r\n                            msg: \"请确认" +
"是否要【启用】表单？\",\r\n                            url: \"../../FormManage/FormModule/Enab" +
"leOrDisableForm\",\r\n                            param: { keyValue: keyValue, flag" +
": 1 },\r\n                            success: function (data) {\r\n                " +
"                $(\"#gridTable\").trigger(\"reloadGrid\");\r\n                        " +
"    }\r\n                        })\r\n                    } else {\r\n               " +
"         dialogMsg(\'请选择要启用的表单模板！\', 0);\r\n                    }\r\n                }" +
",\r\n                btnDisable: function () {\r\n                    var keyValue =" +
" $(\"#gridTable\").jqGridRowValue(\"F_FrmId\");\r\n                    var enabledmark" +
" = $(\"#gridTable\").jqGridRowValue(\"F_EnabledMark\");\r\n                    if (key" +
"Value) {\r\n                        if (enabledmark == 3) {\r\n                     " +
"       dialogMsg(\'草稿不能被禁用！\', 0);\r\n                            return;\r\n         " +
"               }\r\n                        $.ConfirmAjax({\r\n                     " +
"       msg: \"请确认是否要【禁用】表单？\",\r\n                            url: \"../../FormManage" +
"/FormModule/EnableOrDisableForm\",\r\n                            param: { keyValue" +
": keyValue, flag: 0 },\r\n                            success: function (data) {\r\n" +
"                                $(\"#gridTable\").trigger(\"reloadGrid\");\r\n        " +
"                    }\r\n                        })\r\n                    } else {\r" +
"\n                        dialogMsg(\'请选择要禁用的表单模板！\', 0);\r\n                    }\r\n\r" +
"\n                }\r\n            }\r\n        };\r\n\r\n        $(function () {\r\n      " +
"      indexJs.initialPage();\r\n            indexJs.initialTree();\r\n            in" +
"dexJs.initialGrid();\r\n            indexJs.bindEvent();\r\n        });\r\n\r\n    })(wi" +
"ndow.jQuery, window.learun);\r\n</script>");

        }
    }
}
#pragma warning restore 1591
