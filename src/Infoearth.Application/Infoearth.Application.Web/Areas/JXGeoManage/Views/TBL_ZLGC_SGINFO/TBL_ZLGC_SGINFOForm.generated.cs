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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_ZLGC_SGINFO/TBL_ZLGC_SGINFOForm.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_ZLGC_SGINFO_TBL_ZLGC_SGINFOForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_ZLGC_SGINFO_TBL_ZLGC_SGINFOForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_SGINFO\TBL_ZLGC_SGINFOForm.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\JXGeoManage\Views\TBL_ZLGC_SGINFO\TBL_ZLGC_SGINFOForm.cshtml"
  
    ViewBag.Title = "表单页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    body {\r\n        height: auto;\r\n        margin: 0;\r\n    }\r\n\r\n    td" +
" {\r\n        border-top: none !important;\r\n    }\r\n</style>\r\n<div>\r\n    <div");

WriteLiteral(" style=\"margin-top: 10px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" style=\"width: 100%; height: 35px; background-color: rgb(199, 228, 249); line-hei" +
"ght: 35px; border-radius: 5px\"");

WriteLiteral(">\r\n            <span>&nbsp;&nbsp;&nbsp;&nbsp;工程施工</span>\r\n            <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" style=\"float: right; margin-right: 30px; margin-top: 1.5px\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_GCSG_save()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>保存</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" style=\"float: right; margin-right: 30px; margin-top: 1.5px\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_GCSG_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>删除</a>\r\n            ");

WriteLiteral("\r\n            <a");

WriteLiteral(" id=\"lr-delete1\"");

WriteLiteral(" style=\"float: right; margin-right: 30px; margin-top: 1.5px\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_GCSG_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>新增</a>\r\n        </div>\r\n        <table");

WriteLiteral(" class=\"table form\"");

WriteLiteral(" id=\"gridTables_ZLGC_SG\"");

WriteLiteral(">\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">guid</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"GUID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">治理工程编号</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"ZLGCID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control readonly\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">治理工程名称</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"ZLGCNAME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control readonly\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">施工单位<span");

WriteLiteral(" class=\"required\"");

WriteLiteral(" style=\"color: red\"");

WriteLiteral(">*</span></td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"SGDEPT\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n                    <input");

WriteLiteral(" id=\"MEDIAGUID\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">联系人</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"CONTACTPERSON\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">联系电话</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"CONTACTTEL\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">发包形式</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"FBTYPE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">发包金额(万元)</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"FBJE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">开工日期</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"STARTTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker cs\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">竣工日期</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"ENDTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker cs\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">施工标段</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"SGBD\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">合同签订日期</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"QDTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker cs\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">招标时间</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"ZBTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker cs\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">招标地点</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"ZBPLACE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">中标时间</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"GETTIME\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker cs\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">合同地点</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"5\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"QDPLACE\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">工程内容</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"5\"");

WriteLiteral(">\r\n                    <textarea");

WriteLiteral(" id=\"GCCONTENT\"");

WriteLiteral(" class=\"form-control cs\"");

WriteLiteral("></textarea>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n       " +
" <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(" style=\"margin-top: 15px\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" id=\"gridTable_ZLGC_GCSG\"");

WriteLiteral("></table>\r\n            <div");

WriteLiteral(" id=\"gridPager_ZLGC_GCSG\"");

WriteLiteral("></div>\r\n        </div>\r\n        <div");

WriteLiteral(" style=\"height: 300px; width: 100%;\"");

WriteLiteral(">\r\n            <iframe");

WriteLiteral(" class=\"LRADMS_iframe\"");

WriteLiteral(" id=\"QCQFLmedia4\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" src=\"\"");

WriteLiteral(" style=\"border: none; width: 100%; height: 100%;\"");

WriteLiteral("></iframe>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var authToken = getAutho" +
"rizationToken();\r\n    var readonly = request(\'readonly\');\r\n    var xq = request(" +
"\'xq\');\r\n    var details = request(\'details\');\r\n    var mid = \"dcd1d0aa-1d51-4142" +
"-ae82-db812158b0da\";\r\n    $(function () {\r\n        initControl();\r\n        GetGr" +
"id_GCSG();\r\n        if (keyValue == \"\") {\r\n            $(\"#lr-add\").attr(\"disabl" +
"ed\", \"true\");\r\n            $(\"#lr-delete1\").attr(\"disabled\", \"true\");\r\n         " +
"   $(\"#lr-delete\").attr(\"disabled\", \"true\");\r\n        }\r\n        if (readonly ==" +
" 01 || xq == 02) {\r\n            $(\"input\").attr(\"disabled\", \"disabled\");\r\n      " +
"      $(\"textarea\").attr(\"disabled\", \"disabled\");\r\n            $(\"#lr-add\").attr" +
"(\"disabled\", \"true\");\r\n            $(\"#lr-delete1\").attr(\"disabled\", \"true\");\r\n " +
"           $(\"#lr-delete\").attr(\"disabled\", \"true\");\r\n            $(\".titlePanel" +
"\").css(\"display\", \"none\");\r\n        }\r\n        $(window).resize(function (e) {\r\n" +
"            window.setTimeout(function () {\r\n                $(\'#gridTable_ZLGC_" +
"GCSG\').setGridWidth(($(window).width()));\r\n                $(\'#gridTable_ZLGC_GC" +
"SG\').setGridHeight($(window).height() - 407);\r\n            }, 200);\r\n           " +
" e.stopPropagation();\r\n        });\r\n    });\r\n    //初始化控件\r\n    function initContr" +
"ol() {\r\n        var queryJson = eval(\"({\'ZLGCID\':\'\" + keyValue + \"\'})\");\r\n      " +
"  //获取表单\r\n        if (!!keyValue) {\r\n            $.SetForm({\r\n                ur" +
"l: \"../../api/TBL_ZLGC/GetGCSGPageListJson\",\r\n                param: { queryJson" +
": JSON.stringify(queryJson) },\r\n                authToken: authToken,\r\n         " +
"       success: function (data) {\r\n                    var mediaguid = \"\";\r\n    " +
"                if (data.rows > 0) {\r\n                        $(\"#form1\").SetWeb" +
"Controls(data.rows[0]);\r\n                        mediaguid = data.rows[0].MEDIAG" +
"UID;\r\n                    }\r\n                    $(\'#QCQFLmedia4\').attr(\'src\', c" +
"ontentPath + \"/SystemManage/MultMedia/Index?moduleID=\" + mid + \"&details=\" + det" +
"ails + \"&belongObjectGuid=\" + mediaguid);\r\n                }\r\n            });\r\n " +
"       }\r\n    }\r\n\r\n    //治理工程-工程施工删除\r\n    function btn_GCSG_delete() {\r\n        " +
"var keyValue = $(\"#gridTable_ZLGC_GCSG\").jqGridRowValue(\'GUID\');\r\n        if (ke" +
"yValue) {\r\n            $.RemoveForm({\r\n                url: \'../../api/TBL_ZLGC/" +
"GCSG_RemoveForm\',\r\n                type: \"post\",\r\n                authToken: aut" +
"hToken,\r\n                param: { \"\": keyValue },\r\n                success: func" +
"tion (data) {\r\n                    $(\'#gridTable_ZLGC_GCSG\').trigger(\'reloadGrid" +
"\');\r\n                }\r\n            });\r\n        } else {\r\n            dialogMsg" +
"(\'请选择需要删除的治理工程-工程施工表！\', 0);\r\n        }\r\n    }\r\n    var addBS = false;\r\n    funct" +
"ion btn_GCSG_add() {\r\n        addBS = true;\r\n        $(\".cs\").val(\"\");\r\n        " +
"$(\"#GUID\").val(\"\");\r\n        $(\'#QCQFLmedia4\').attr(\'src\', contentPath + \"/Syste" +
"mManage/MultMedia/Index?moduleID=\" + mid + \"&details=\" + details + \"&belongObjec" +
"tGuid=\");\r\n\r\n    }\r\n    //治理工程-工程施工新增\r\n    function btn_GCSG_save() {\r\n        v" +
"ar entityGCSG = $(\"#gridTables_ZLGC_SG\").GetWebControls();\r\n\r\n        $.SaveForm" +
"({\r\n            url: \"../../api/TBL_ZLGC/GCSG_SaveForm\",\r\n            type: \"pos" +
"t\",\r\n            param: {\r\n                \"keyValue\": \"\",\r\n                \"ent" +
"ityGCSG\": entityGCSG\r\n            },\r\n            loading: \"正在保存数据...\",\r\n       " +
"     close: false,\r\n            authToken: authToken,\r\n            success: func" +
"tion (data) {\r\n                console.log(data);\r\n                if ($(\"#QCQFL" +
"media4\")[0].getAttribute(\"src\") != \"\") {\r\n                    $(\"#QCQFLmedia4\")[" +
"0].contentWindow.SaveFileInfo(data.resultdata.MEDIAGUID);\r\n                }\r\n  " +
"              $(\"#gridTable_ZLGC_GCSG\").jqGrid(\'GridUnload\');\r\n                G" +
"etGrid_GCSG();\r\n            }\r\n        })\r\n    }\r\n    //加载工程施工列表信息\r\n    function" +
" GetGrid_GCSG() {\r\n        var queryJson = eval(\"({\'ZLGCID\':\'\" + keyValue + \"\'})" +
"\");\r\n        var selectedRowIndex = 0;\r\n        var $gridTable = $(\'#gridTable_Z" +
"LGC_GCSG\');\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n        " +
"    loadBeforeSend: function (a) {\r\n                a.setRequestHeader(\"Authoriz" +
"ation\", authToken);\r\n            },\r\n            height: $(window).height() - 40" +
"7,\r\n            url: \"../../api/TBL_ZLGC/GetGCSGPageListJson\",\r\n            post" +
"Data: { queryJson: JSON.stringify(queryJson) },\r\n            datatype: \"json\",\r\n" +
"            colModel: [\r\n                { label: \'GUID\', name: \'GUID\', index: \'" +
"GUID\', hidden: true },\r\n                { label: \'施工单位\', name: \'SGDEPT\', index: " +
"\'SGDEPT\', width: 350, align: \'left\', sortable: true },\r\n                { label:" +
" \'联系人\', name: \'CONTACTPERSON\', index: \'CONTACTPERSON\', width: 300, align: \'left\'" +
", sortable: true },\r\n                { label: \'联系电话\', name: \'CONTACTTEL\', index:" +
" \'CONTACTTEL\', width: 300, align: \'left\', sortable: true },\r\n                { l" +
"abel: \'发包形式\', name: \'FBTYPE\', index: \'FBTYPE\', width: 250, align: \'left\', sortab" +
"le: true }\r\n            ],\r\n            viewrecords: true,\r\n            rowNum: " +
"10,\r\n            rowList: [10, 20, 30],\r\n            pager: \"#gridPager_ZLGC_GCS" +
"G\",\r\n            sortname: \'GUID\',\r\n            sortorder: \'desc\',\r\n            " +
"rownumbers: true,\r\n            shrinkToFit: true,\r\n            gridview: true,\r\n" +
"            onSelectRow: function () {\r\n                selectedRowIndex = $(\'#\'" +
" + this.id).getGridParam(\'selrow\');\r\n                var GUID_S = $(\'#\' + this.i" +
"d).getRowData(selectedRowIndex).GUID;\r\n                if (!!GUID_S) {\r\n        " +
"            $.SetForm({\r\n                        url: \"../../api/TBL_ZLGC/GetGCS" +
"G\",\r\n                        authToken: authToken,\r\n                        para" +
"m: { keyValue: GUID_S },\r\n                        success: function (data) {\r\n  " +
"                          $(\"#gridTables_ZLGC_SG\").SetWebControls(data);\r\n      " +
"                  }\r\n\r\n                    })\r\n                }\r\n              " +
"  var mediaguid = $(\"#MEDIAGUID\").val(); \r\n                $(\'#QCQFLmedia4\').att" +
"r(\'src\', contentPath + \"/SystemManage/MultMedia/Index?moduleID=\" + mid + \"&detai" +
"ls=\" + details + \"&belongObjectGuid=\" + mediaguid);\r\n            },\r\n           " +
" gridComplete: function () {\r\n                $(\'#\' + this.id).setSelection(sele" +
"ctedRowIndex, false);\r\n                //var ids = new Array();\n                " +
"////getDataIDs()返回当前grid里所有数据的id\n                //ids = $(\"#\" + this.id).getDat" +
"aIDs();\n                ////选择或反选指定行。如果onselectrow为ture则会触发事件onSelectRow，onselec" +
"trow默认为ture\n                //$(\"#\" + this.id).setSelection(ids[0], true);\r\n\r\n  " +
"          }\r\n        });\r\n    }\r\n\r\n\r\n    //保存表单;\r\n    function AcceptClick() {\r\n" +
"        if (!$(\'#form1\').Validform()) {\r\n            return false;\r\n        }\r\n " +
"       var postData = $(\"#form1\").GetWebControls(keyValue);\r\n        $.SaveForm(" +
"{\r\n            url: \"../../JXGeoManage/TBL_ZLGC_SGINFO/SaveForm?keyValue=\" + key" +
"Value,\r\n            param: postData,\r\n            loading: \"正在保存数据...\",\r\n       " +
"     success: function () {\r\n                try {\r\n                    getInfoT" +
"op().learun.currentIframe().$(\'#gridTable\').trigger(\'reloadGrid\');\r\n            " +
"    } catch (e) {\r\n                    window.parent.$(\'#gridTable\').trigger(\'re" +
"loadGrid\');\r\n                }\r\n            }\r\n        })\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
