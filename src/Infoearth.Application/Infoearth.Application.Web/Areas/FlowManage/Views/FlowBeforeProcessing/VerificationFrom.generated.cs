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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/FlowManage/Views/FlowBeforeProcessing/VerificationFrom.cshtml")]
    public partial class _Areas_FlowManage_Views_FlowBeforeProcessing_VerificationFrom_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_FlowManage_Views_FlowBeforeProcessing_VerificationFrom_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\FlowManage\Views\FlowBeforeProcessing\VerificationFrom.cshtml"
  
    ViewBag.Title = "审核流程";
    Layout = "~/Views/Shared/_FlowForm.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var processId = request(\'processId\');\r\n    var createusername = d" +
"ecodeURI(request(\'createusername\'));\r\n    var description = decodeURI(request(\'d" +
"escription\'));\r\n    var nodeId = decodeURI(request(\'nodeId\'));\r\n    var nodeMain" +
"Id = decodeURI(request(\'nodeMainId\'));\r\n    $(function () {\r\n        var schemeC" +
"ontent, formContent = {};\r\n        $(\'#Createusername\').val(createusername);\r\n  " +
"      $(\'#Description\').val(description);\r\n        $(\'#VerificationOpinion\').hei" +
"ght($.windowHeight() - 360);\r\n        $(\'.FlowInfoPanel\').height($.windowHeight(" +
"));\r\n        $.SetForm({\r\n            url: \"../../FlowManage/FlowBeforeProcessin" +
"g/GetProcessJson\",\r\n            param: { keyValue: processId, nodeId: nodeId },\r" +
"\n            success: function (data) {\r\n                console.log(data, \"data" +
"\");\r\n\r\n\r\n                var thtml = \"\",chtml=\"\";\r\n                $.each(data.f" +
"ormEntityList, function (id, item) {\r\n                    if (id == 0) {\r\n      " +
"                  thtml += \'<li class=\"active\"><a href=\"#frm_\' + item.F_FrmId + " +
"\'\" data-toggle=\"tab\">\' + item.F_FrmName + \'</a></li>\';\r\n                    }\r\n " +
"                   else {\r\n                        thtml += \'<li><a href=\"#frm_\'" +
" + item.F_FrmId + \'\" data-toggle=\"tab\">\' + item.F_FrmName + \'</a></li>\';\r\n      " +
"              }\r\n                    chtml += \'<div id=\"frm_\' + item.F_FrmId + \'" +
"\" class=\"tab-pane active\" style=\"overflow-y:auto;\"><div id=\"formContent_\' + item" +
".F_FrmId + \'\" class=\"app_layout app_preview\"></div></div>\';\r\n                   " +
" formContent[item.F_FrmId] = JSON.parse(item.F_FrmContent);\r\n                });" +
"\r\n                $(\'#flowcontent\').prepend(chtml);\r\n                $(\'#flowtit" +
"le\').prepend(thtml);\r\n                $.each(formContent, function (i, item) {\r\n" +
"                    $(\'#frm_\' + i).height($.windowHeight() - 40);\r\n             " +
"       if (item.type == 2) {\r\n                        $(\'#formContent_\' + i).htm" +
"l(\'<iframe id=\"formIframe_\' + i + \'\" frameborder=\"no\" border=\"0\" marginwidth=\"0\"" +
" marginheight=\"0\" scrolling=\"no\" style=\"height:100%;width:100%;\"></iframe>\');\r\n " +
"                       learun.loadSystemForm(\'formIframe_\' + i, item.data.url + " +
"\"?processId=\" + processId);\r\n                        $(\'#formContent_\' + i).heig" +
"ht($.windowHeight() - 50);\r\n                    }\r\n                    else {\r\n " +
"                       $(\'#formContent_\' + i).formRendering(\'init\', { formData: " +
"item.data });\r\n                        $(\'#formContent_\' + i).formRendering(\'set" +
"\', { data: JSON.parse(data.dFormData[i].F_FrmInstanceJson) });\r\n                " +
"        $(\'#formContent_\' + i).find(\'input,select,textarea,.ui-select\').attr(\'di" +
"sabled\', \'disabled\');\r\n                    }\r\n                });\r\n             " +
"   schemeContent = JSON.parse(data.processSchemeEntity.F_SchemeContent);\r\n      " +
"          $(\'#FlowPanel\').flowDesigner({\r\n                    width: $(window).w" +
"idth() - 298,\r\n                    height: $(window).height() - 42,\r\n           " +
"         schemeContent: schemeContent,\r\n                    haveTool: false,\r\n  " +
"                  isprocessing: true,\r\n                    nodeData: data.nodeLi" +
"st\r\n                });\r\n                $.each(data.currentNode.setInfo.nodeAut" +
"horizeInfo, function (i, item) {\r\n                    if (!!formContent[item.for" +
"mId])\r\n                    {\r\n                        var formtype = formContent" +
"[item.formId].type;\r\n                        if (formtype != 2) {\r\n             " +
"               var $field = $(\'#formContent_\' + item.formId).find(\'[data-value=\"" +
"\' + item.fieldid + \'\"]\');\r\n                            if (item.edit) {\r\n       " +
"                         $field.find(\'input,select,textarea,.ui-select\').removeA" +
"ttr(\'disabled\');\r\n                            }\r\n                            if " +
"(!item.look) {\r\n                                $field.hide();\r\n                " +
"            }\r\n                        }\r\n                        else {\r\n      " +
"                      learun.setSystemFormFieldsAuthrize(\"formIframe_\" + item.fo" +
"rmId, item);\r\n                        }\r\n                    }\r\n                " +
"});\r\n            }\r\n        });\r\n\r\n        $(\'#btn_Submission\').click(function (" +
") {\r\n            if (!$(\'#VerificationInfo\').Validform()) {\r\n                ret" +
"urn false;\r\n            }\r\n            var _verificationFinally = $(\'input[name " +
"= VerificationFinally]:checked\').val();\r\n            if (_verificationFinally ==" +
" undefined) {\r\n                dialogTop(\"请选择审核结果\", \"error\");\r\n                r" +
"eturn false;\r\n            }\r\n            var _postdata = $(\"#VerificationInfo\")." +
"GetWebControls();\r\n\r\n            var data = {\r\n                processId: proces" +
"sId,\r\n                nodeId: nodeMainId,\r\n                isOk: (_verificationF" +
"inally == 1 ? true : false),\r\n                description: _postdata.Verificatio" +
"nOpinion\r\n            };\r\n            var formData = [];\r\n            $.each(for" +
"mContent, function (i, item) {\r\n                if (item.type != 2) {\r\n         " +
"           var _data = $(\"#formContent_\" + i).formRendering(\'get\');\r\n           " +
"         if (!!_data) {\r\n                        formData.push({ formId: i, form" +
"Data: JSON.stringify(_data) });\r\n                    }\r\n                }\r\n     " +
"           else {//系统表单\r\n                    var _data = learun.getSystemFormDat" +
"a(\'formIframe_\' + i);\r\n                    console.log(data);\r\n                 " +
"   formData.push({ formId: i, formData: JSON.stringify(_data) });\r\n             " +
"   }\r\n            });\r\n            data.formDataList = formData;\r\n            $." +
"ConfirmAjax({\r\n                msg: \"请确认是否要【提交审核】流程？\",\r\n                url: \".." +
"/../FlowManage/FlowBeforeProcessing/VerificationProcess\",\r\n                param" +
": data,\r\n                success: function (data) {\r\n                    learun." +
"currentIframe().callBack();\r\n                    dialogClose();\r\n               " +
" }\r\n            });\r\n        });\r\n    });\r\n</script>\r\n    <div");

WriteLiteral(" class=\"FlowPanelall\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" id=\"flowtitle\"");

WriteLiteral(" class=\"nav nav-tabs\"");

WriteLiteral(">\r\n           \r\n            <li><a");

WriteLiteral(" href=\"#FlowPanel\"");

WriteLiteral(" data-toggle=\"tab\"");

WriteLiteral(">流程信息</a></li>\r\n        </ul>\r\n        <div");

WriteLiteral(" id=\"flowcontent\"");

WriteLiteral(" class=\"tab-content\"");

WriteLiteral(">\r\n            \r\n            <div");

WriteLiteral(" id=\"FlowPanel\"");

WriteLiteral(" class=\"tab-pane\"");

WriteLiteral("> \r\n            </div>\r\n        </div>\r\n    </div>\r\n   <div");

WriteLiteral(" class=\"FlowInfoPanel\"");

WriteLiteral(" id=\"VerificationInfo\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" style=\"color:#9f9f9f;padding-bottom:15px;padding-left:5px;\"");

WriteLiteral("><i");

WriteLiteral(" style=\"padding-right:5px;\"");

WriteLiteral(" class=\"fa fa-info-circle\"");

WriteLiteral("></i><span>在此填写内容,提交审核</span></div>\r\n        <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">申请人员</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"Createusername\"");

WriteLiteral(" disabled");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">申请备注</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <textarea");

WriteLiteral(" id=\"Description\"");

WriteLiteral(" disabled");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"height:50px;\"");

WriteLiteral("></textarea>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n       " +
"         <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审核人员<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"VerificationUser\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7404), Tuple.Create("\"", 7484)
            
            #line 159 "..\..\Areas\FlowManage\Views\FlowBeforeProcessing\VerificationFrom.cshtml"
, Tuple.Create(Tuple.Create("", 7412), Tuple.Create<System.Object, System.Int32>(Infoearth.Application.Code.OperatorProvider.Provider.Current().UserName
            
            #line default
            #line hidden
, 7412), false)
);

WriteLiteral(" disabled");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审核结果<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"rdio rdio-color_a\"");

WriteLiteral("><input");

WriteLiteral(" name=\"VerificationFinally\"");

WriteLiteral("  id=\"VerificationFinally1\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" /><label");

WriteLiteral(" for=\"VerificationFinally1\"");

WriteLiteral(">同意</label></div>\r\n                    <div");

WriteLiteral(" class=\"rdio rdio-color_f\"");

WriteLiteral("><input");

WriteLiteral(" name=\"VerificationFinally\"");

WriteLiteral("  id=\"VerificationFinally2\"");

WriteLiteral(" value=\"2\"");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" /><label");

WriteLiteral(" for=\"VerificationFinally2\"");

WriteLiteral(">不同意</label></div>\r\n                </td>\r\n            </tr>\r\n            <tr");

WriteLiteral(" class=\"NodeRejectStep\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">驳回步骤<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            </tr>\r\n            <tr");

WriteLiteral(" class=\"NodeRejectStep\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"NodeRejectStep\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n            " +
"    <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">审核意见</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <textarea");

WriteLiteral(" id=\"VerificationOpinion\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral("></textarea>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n       " +
" <div");

WriteLiteral(" style=\"padding:5px;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"btn_Submission\"");

WriteLiteral(" class=\"btn btn-success btn-block\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-check-circle\"");

WriteLiteral(@"></i>&nbsp;提交审核</a>
        </div>
    </div>
<style>
body{overflow:hidden}
.FlowPanelall{width:799px;float:left;overflow-y:auto;}
.FlowInfoPanel{position: absolute;right: 0px;width: 300px;height: 619px;z-index:1000;background:rgba(0,0,0,.01);padding:10px;border-left:1px solid #ccc}
.FlowInfoPanel .form .formTitle{text-align:left;padding-left:5px}
.FlowInfoPanel .formTitle font{right:auto!important;margin-left:5px}
.FlowInfoPanel .formValue input,.FlowInfoPanel .formValue textarea{border-radius:5px}
input,textarea{background:#fff!important}
</style>
");

        }
    }
}
#pragma warning restore 1591
