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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/PublicInfoManage/Views/Email/EmailWriteForm.cshtml")]
    public partial class _Areas_PublicInfoManage_Views_Email_EmailWriteForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_PublicInfoManage_Views_Email_EmailWriteForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\PublicInfoManage\Views\Email\EmailWriteForm.cshtml"
  
    ViewBag.Title = "写邮件表单";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 91), Tuple.Create("\"", 149)
, Tuple.Create(Tuple.Create("", 98), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/css/simditor.css")
, 98), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 179), Tuple.Create("\"", 236)
, Tuple.Create(Tuple.Create("", 185), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/module.min.js")
, 185), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 256), Tuple.Create("\"", 314)
, Tuple.Create(Tuple.Create("", 262), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/hotkeys.min.js")
, 262), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 334), Tuple.Create("\"", 393)
, Tuple.Create(Tuple.Create("", 340), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/simditor.min.js")
, 340), false)
);

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 411), Tuple.Create("\"", 474)
, Tuple.Create(Tuple.Create("", 418), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/cxColor/css/jquery.cxcolor.css")
, 418), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 504), Tuple.Create("\"", 564)
, Tuple.Create(Tuple.Create("", 510), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/cxColor/js/jquery.cxcolor.js")
, 510), false)
);

WriteLiteral("></script>\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var editor = n" +
"ull;\r\n    $(function () {\r\n        editor = new Simditor({\r\n            textarea" +
": $(\'#F_EmailContent\'),\r\n            toolbar: [\'title\', \'bold\', \'italic\', \'under" +
"line\', \'strikethrough\', \'color\', \'|\', \'ol\', \'ul\', \'blockquote\', \'code\', \'table\'," +
" \'|\', \'link\', \'image\', \'hr\', \'|\', \'indent\', \'outdent\']\r\n        });\r\n        $(\"" +
"#form-body\").height($(window).height() - 46);\r\n        $(\".simditor .simditor-bo" +
"dy\").height(300).css({ \"overflow\": \"auto\", \"min-height\": \"0\" });\r\n        initCo" +
"ntrol();\r\n        initUserList();\r\n    })\r\n    //初始化控件\r\n    function initControl" +
"() {\r\n        //抄送点击事件\r\n        $(\"#btn_copysend\").click(function () {\r\n        " +
"    if (!$(this).hasClass(\"active\")) {\r\n                $(this).addClass(\'active" +
"\').html(\'删除抄送\');\r\n                $(\"#copysendAreas\").show();\r\n                v" +
"ar _height = 38 + ($(\"#bccsendAreas\").is(\':hidden\') == true ? 0 : 38);\r\n        " +
"        $(\".simditor .simditor-body\").height(300 - _height)\r\n            } else " +
"{\r\n                $(this).removeClass(\'active\').html(\'抄送\');\r\n                $(" +
"\"#copysendAreas\").hide();\r\n                var _height = 0 + ($(\"#bccsendAreas\")" +
".is(\':hidden\') == true ? 0 : 38);\r\n                $(\".simditor .simditor-body\")" +
".height(300 - _height);\r\n                $(\"#txt_copysend\").find(\'div.mail-send-" +
"addresss\').html(\'\');\r\n            }\r\n        });\r\n        //密送点击事件\r\n        $(\"#" +
"btn_bccsend\").click(function () {\r\n            if (!$(this).hasClass(\"active\")) " +
"{\r\n                $(this).addClass(\'active\').html(\'删除密送\');\r\n                $(\"" +
"#bccsendAreas\").show();\r\n                var _height = 38 + ($(\"#copysendAreas\")" +
".is(\':hidden\') == true ? 0 : 38);\r\n                $(\".simditor .simditor-body\")" +
".height(300 - _height)\r\n            } else {\r\n                $(this).removeClas" +
"s(\'active\').html(\'密送\');\r\n                $(\"#bccsendAreas\").hide();\r\n           " +
"     var _height = 0 + ($(\"#copysendAreas\").is(\':hidden\') == true ? 0 : 38);\r\n  " +
"              $(\".simditor .simditor-body\").height(300 - _height);\r\n            " +
"    $(\"#txt_bccsend\").find(\'div.mail-send-addresss\').html(\'\');\r\n            }\r\n " +
"       });\r\n        //添加（收件人、抄送认、密送人）事件\r\n        $(\'#btn_add_addresss,#btn_add_c" +
"opysend,#btn_add_bccsend\').click(function () {\r\n            var $this = $(this)." +
"prev(\'div.form-control\');\r\n            $this.addClass(\'active\');\r\n            $(" +
"\"#selectUserList\").animate({ left: 870, speed: 2000 }).show().height($(window).h" +
"eight() - 45).attr(\'data-type\', $(this).attr(\'id\'));\r\n            $(\"#selectUser" +
"List_background\").show().click(function () {\r\n                $this.removeClass(" +
"\'active\');\r\n                $(this).hide();\r\n                $(\"#selectUserList\"" +
").animate({ left: 1100, speed: 2000 }).hide();\r\n            });\r\n        });\r\n  " +
"      //上传文件\r\n        $(\"#F_Files\").uploadifyEx({\r\n            url: \"/Utility/Up" +
"loadifyFile?DataItemEncode=SaveFilePath&DataItemName=EmailFilePath\",\r\n          " +
"  btnName: \"添加附件\"\r\n        });\r\n        //获取表单\r\n        if (!!keyValue) {\r\n     " +
"       $.SetForm({\r\n                url: \"../../PublicInfoManage/Email/GetEmailF" +
"ormJson\",\r\n                param: { keyValue: keyValue },\r\n                succe" +
"ss: function (data) {                    \r\n                    $(\"#form1\").SetWe" +
"bControls(data);\r\n                    editor.setValue(data.F_EmailContent);\r\n   " +
"                 $(\"#F_Theme\").attr(\"color\", data.F_ThemeColor).css(\"color\", dat" +
"a.F_ThemeColor);\r\n                    $(\"#txt_addresss\").html(data.F_AddresssHtm" +
"l);\r\n                    $(\"#txt_copysend\").html(data.F_CopysendHtml);\r\n        " +
"            $(\"#txt_bccsend\").html(data.F_BccsendHtml);\r\n                    if " +
"($(\"#txt_copysend\").find(\'div.mail-send-address\').length > 0) {\r\n               " +
"         $(\"#btn_copysend\").trigger(\"click\")\r\n                    }\r\n           " +
"         if ($(\"#txt_bccsend\").find(\'div.mail-send-address\').length > 0) {\r\n    " +
"                    $(\"#btn_bccsend\").trigger(\"click\")\r\n                    }\r\n " +
"               }\r\n            });\r\n        }\r\n    }\r\n    //初始化加载用户列表\r\n    functi" +
"on initUserList() {\r\n        var item = {\r\n            slimscroll: false,\r\n     " +
"       height: $(window).height() - 46,\r\n            url: \"../../BaseManage/User" +
"/GetTreeJson\",\r\n            onnodeclick: function (item) {\r\n                if (" +
"item.Sort == \"User\") {\r\n                    var userId = item.id;\r\n             " +
"       var userName = item.text;\r\n                    var userCode = item.value;" +
"\r\n                    var datatype = $(\"#selectUserList\").attr(\'data-type\');\r\n  " +
"                  var _length = $(\'.mail-send-addresss\').find(\'[data-value=\' + u" +
"serId + \']\').length;\r\n                    if (_length == 0) {\r\n                 " +
"       $(\"#\" + datatype).prev(\'div.form-control\').find(\'.mail-send-addresss\').ap" +
"pend(\'<div class=\"mail-send-address\" data-value=\' + userId + \' ><div class=\"mail" +
"-send-address-name\" title=\' + item.title + \' >\' + userName + \'</div><div title=\"" +
"删除\" class=\"mail-send-address-del\" onclick=\"$(this).parent().remove()\">×</div></d" +
"iv>\');\r\n                    }\r\n                }\r\n            }\r\n        };\r\n   " +
"     //初始化\r\n        $(\"#selectUserList\").treeview(item);\r\n    }\r\n   \r    //选择颜色-" +
"设置标题色彩\r\n    function SelectColorEvent() {\r\n        var mycolor = $(\"#select_colo" +
"r\").cxColor();\r\n        mycolor.show();\r\n        $(\"#select_color\").bind(\"change" +
"\", function () {\r\n            $(\"#F_Theme\").css(\"color\", this.value).attr(\"color" +
"\", this.value);\r\n        });\r\n    }\r\n    //保存表单\r\n    function AcceptClick(SendSt" +
"ate) {\r\n        var addresssData = [];\r\n        var copysendData = [];\r\n        " +
"var bccsendData = [];\r\n        $(\"#txt_addresss .mail-send-address\").each(functi" +
"on () {\r\n            addresssData.push($(this).attr(\'data-value\'));\r\n        })\r" +
"\n        $(\"#txt_copysend .mail-send-address\").each(function () {\r\n            c" +
"opysendData.push($(this).attr(\'data-value\'));\r\n        })\r\n        $(\"#txt_bccse" +
"nd .mail-send-address\").each(function () {\r\n            bccsendData.push($(this)" +
".attr(\'data-value\'));\r\n        })\r\n        if (addresssData.length == 0) {\r\n    " +
"        top.dialogTop(\'请填写收件人后再发送\', \'error\');\r\n            return false;\r\n      " +
"  }\r\n        if (!$(\"#copysendAreas\").is(\':hidden\') && copysendData.length == 0)" +
" {\r\n            top.dialogTop(\'请填写抄送人后再发送\', \'error\');\r\n            return false;" +
"\r\n        }\r\n        if (!$(\"#bccsendAreas\").is(\':hidden\') && bccsendData.length" +
" == 0) {\r\n            top.dialogTop(\'请填写密送人后再发送\', \'error\');\r\n            return " +
"false;\r\n        }\r\n        if ($(\"#F_Theme\").val() == \"\") {\r\n            top.dia" +
"logTop(\'请填写主题后再发送\', \'error\');\r\n            return false;\r\n        }\r\n        if " +
"($(\"#copysendAreas\").is(\':hidden\')) {\r\n            $(\"#txt_copysend .mail-send-a" +
"ddress\").each(function () {\r\n                copysendData.push($(this).attr(\'dat" +
"a-value\'));\r\n            })\r\n        }\r\n        if ($(\"#bccsendAreas\").is(\':hidd" +
"en\')) {\r\n            $(\"#txt_bccsend .mail-send-address\").each(function () {\r\n  " +
"              bccsendData.push($(this).attr(\'data-value\'));\r\n            })\r\n   " +
"     }\r\n        var postData = {\r\n            F_SendState: SendState,\r\n         " +
"   F_Theme: $(\"#F_Theme\").val(),\r\n            F_ThemeColor: $(\'#F_Theme\').attr(\'" +
"color\'),\r\n            F_EmailContent: editor.getValue(),\r\n            F_Files: $" +
"(\"#F_Files\").attr(\'data-value\'),\r\n            F_SendPriority: $(\"#F_SendPriority" +
"\").is(\":checked\") == true ? 1 : 0,\r\n            F_IsReceipt: $(\"#F_IsReceipt\").i" +
"s(\":checked\") == true ? 1 : 0,\r\n            F_IsSmsReminder: $(\"#F_IsSmsReminder" +
"\").is(\":checked\") == true ? 1 : 0,\r\n            F_AddresssHtml: $(\"#txt_addresss" +
"\").html(),\r\n            F_CopysendHtml: $(\"#txt_copysend\").html(),\r\n            " +
"F_BccsendHtml: $(\"#txt_bccsend\").html(),\r\n            addresssIds: String(addres" +
"ssData),\r\n            copysendIds: String(copysendData),\r\n            bccsendIds" +
": String(bccsendData)\r\n        }\r\n        $.SaveForm({\r\n            url: \"../../" +
"PublicInfoManage/Email/SaveEmailForm?keyValue=\" + keyValue,\r\n            param: " +
"postData,\r\n            loading: keyValue != \"\" ? \"正在存入草稿...\" : \"正在发送数据...\",\r\n   " +
"         success: function () {\r\n                $.currentIframe().InitialEmailN" +
"avCount();\r\n                $.currentIframe().$(\"#gridTable\").trigger(\"reloadGri" +
"d\");\r\n            }\r\n        })\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" id=\"form-body\"");

WriteLiteral(" style=\"overflow: auto;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" style=\"margin-top: 20px; margin-right: 30px;\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" style=\"table-layout: auto;\"");

WriteLiteral(">\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 11px;\"");

WriteLiteral(">收件人</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"txt_addresss\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"padding-left: 3px; height: auto; min-height: 28px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"mail-send-addresss\"");

WriteLiteral("></div>\r\n                    </div>\r\n                    <span");

WriteLiteral(" id=\"btn_add_addresss\"");

WriteLiteral(" class=\"input-button\"");

WriteLiteral(" title=\"添加收件人\"");

WriteLiteral(">...</span>\r\n                </td>\r\n            </tr>\r\n            <tr");

WriteLiteral(" id=\"copysendAreas\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 11px;\"");

WriteLiteral(">抄送人</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"txt_copysend\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"padding-left: 3px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"mail-send-addresss\"");

WriteLiteral("></div>\r\n                    </div>\r\n                    <span");

WriteLiteral(" id=\"btn_add_copysend\"");

WriteLiteral(" class=\"input-button\"");

WriteLiteral(" title=\"添加抄送人\"");

WriteLiteral(">...</span>\r\n                </td>\r\n            </tr>\r\n            <tr");

WriteLiteral(" id=\"bccsendAreas\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 11px;\"");

WriteLiteral(">密送人</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"txt_bccsend\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"padding-left: 3px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"mail-send-addresss\"");

WriteLiteral("></div>\r\n                    </div>\r\n                    <span");

WriteLiteral(" id=\"btn_add_bccsend\"");

WriteLiteral(" class=\"input-button\"");

WriteLiteral(" title=\"添加密送人\"");

WriteLiteral(">...</span>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n        " +
"        <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral("></td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" id=\"btn_copysend\"");

WriteLiteral(" title=\"什么是抄送：同时将这一封邮件发送给其他联系人。\"");

WriteLiteral("\r\n                        style=\"color: #95A0AA; cursor: pointer;\"");

WriteLiteral(">抄送</a>&nbsp;\r\n                <a");

WriteLiteral(" id=\"btn_bccsend\"");

WriteLiteral(" title=\"什么是密送：同时将这一封邮件发送给其他联系人，但收件人及抄送人不会看到密送人。\"");

WriteLiteral("\r\n                    style=\"color: #95A0AA; cursor: pointer;\"");

WriteLiteral(">密送</a>&nbsp;\r\n                <a");

WriteLiteral(" id=\"btn_groupsend\"");

WriteLiteral(" title=\"什么是单独：会对多个人一对一发送。每个人将收到单独发给他/她的邮件。\"");

WriteLiteral("\r\n                    style=\"color: #95A0AA; cursor: pointer;\"");

WriteLiteral(">单独发送</a>&nbsp;\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n    " +
"            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">主题</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" id=\"F_Theme\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"color: #000000;\"");

WriteLiteral(" />\r\n                    <span");

WriteLiteral(" id=\"select_color\"");

WriteLiteral(" class=\"input-button\"");

WriteLiteral(" style=\"width: 18px; margin-top: -9px; height: auto;\"");

WriteLiteral(" title=\"使用主题彩色\"");

WriteLiteral(" onclick=\"SelectColorEvent()\"");

WriteLiteral(">\r\n                        <img");

WriteAttribute("src", Tuple.Create(" src=\"", 11550), Tuple.Create("\"", 11588)
, Tuple.Create(Tuple.Create("", 11556), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/large_tiles.png")
, 11556), false)
);

WriteLiteral(" />\r\n                    </span>\r\n                </td>\r\n            </tr>\r\n     " +
"       <tr>\r\n                <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 12px; height: 37px;\"");

WriteLiteral(">附件</td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"F_Files\"");

WriteLiteral("></div>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n            " +
"    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">内容</th>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <textarea");

WriteLiteral(" id=\"F_EmailContent\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" rows=\"5\"");

WriteLiteral("></textarea>\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n       " +
"         <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral("></td>\r\n                <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"checkbox user-select\"");

WriteLiteral(" style=\"color: #95A0AA;\"");

WriteLiteral(">\r\n                        <label>\r\n                            <input");

WriteLiteral(" id=\"SendPriority\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" />\r\n                            紧急\r\n                        </label>\r\n          " +
"              <label>\r\n                            <input");

WriteLiteral(" id=\"IsReceipt\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" />\r\n                            已读回执\r\n                        </label>\r\n        " +
"                <label>\r\n                            <input");

WriteLiteral(" id=\"IsSmsReminder\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" />\r\n                            短信提醒\r\n                        </label>\r\n        " +
"            </div>\r\n                    <span");

WriteLiteral(" style=\"position: absolute; top: 5px; right: 5px;\"");

WriteLiteral(">发件人：超级管理员（System）</span>\r\n                </td>\r\n            </tr>\r\n        </ta" +
"ble>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"form-button\"");

WriteLiteral(" id=\"wizard-actions\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" class=\"btn btn-success\"");

WriteLiteral(" onclick=\"AcceptClick(1)\"");

WriteLiteral(">立即发送</a>\r\n    <a");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"AcceptClick(0)\"");

WriteLiteral(">存草稿箱</a>\r\n</div>\r\n<div");

WriteLiteral(" id=\"selectUserList_background\"");

WriteLiteral(" style=\"display: none; width: 100%; height: 100%; opacity: 0.0; filter: alpha(opa" +
"city=00); background: #fff; position: absolute; top: 0; left: 0; z-index: 100;\"");

WriteLiteral("></div>\r\n<div");

WriteLiteral(" id=\"selectUserList\"");

WriteLiteral(" style=\"box-shadow: 0 0px 12px rgba(0,0,0,.175); position: fixed; top: 0px; left:" +
" 1100px; z-index: 101; width: 230px; border-left: 1px solid #ccc; background: #f" +
"ff; overflow: hidden; overflow-y: auto; display: none;\"");

WriteLiteral(">\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
