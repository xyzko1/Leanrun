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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/PublicInfoManage/Views/Notice/Form.cshtml")]
    public partial class _Areas_PublicInfoManage_Views_Notice_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_PublicInfoManage_Views_Notice_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\PublicInfoManage\Views\Notice\Form.cshtml"
  
    ViewBag.Title = "公告管理";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 86), Tuple.Create("\"", 144)
, Tuple.Create(Tuple.Create("", 93), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/css/simditor.css")
, 93), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 174), Tuple.Create("\"", 231)
, Tuple.Create(Tuple.Create("", 180), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/module.min.js")
, 180), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 251), Tuple.Create("\"", 310)
, Tuple.Create(Tuple.Create("", 257), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/uploader.min.js")
, 257), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 330), Tuple.Create("\"", 388)
, Tuple.Create(Tuple.Create("", 336), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/hotkeys.min.js")
, 336), false)
);

WriteLiteral("></script>\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 408), Tuple.Create("\"", 467)
, Tuple.Create(Tuple.Create("", 414), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/simditor/js/simditor.min.js")
, 414), false)
);

WriteLiteral("></script>\r\n<link");

WriteAttribute("href", Tuple.Create(" href=\"", 485), Tuple.Create("\"", 548)
, Tuple.Create(Tuple.Create("", 492), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/cxColor/css/jquery.cxcolor.css")
, 492), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n<script");

WriteAttribute("src", Tuple.Create(" src=\"", 578), Tuple.Create("\"", 638)
, Tuple.Create(Tuple.Create("", 584), Tuple.Create<System.Object, System.Int32>(Href("~/Content/scripts/plugins/cxColor/js/jquery.cxcolor.js")
, 584), false)
);

WriteLiteral("></script>\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    var editor = n" +
"ull;\r\n    $(function () {\r\n        editor = new Simditor({\r\n            textarea" +
": $(\'#F_NewsContent\'),\r\n            placeholder: \'这里输入公告内容...\',\r\n            too" +
"lbar: [\'title\', \'bold\', \'italic\', \'underline\', \'strikethrough\', \'color\', \'|\', \'o" +
"l\', \'ul\', \'blockquote\', \'code\', \'table\', \'|\', \'link\', \'image\', \'hr\', \'|\', \'inden" +
"t\', \'outdent\']\r\n        });\r\n        initControl();\r\n    })\r\n    //初始化控件\r\n    fu" +
"nction initControl() {\r\n        //公告类别\r\n        $(\"#F_Category\").ComboBox({\r\n   " +
"         param: { EnCode: \"NoticeCategory\" },\r\n            url: \"../../SystemMan" +
"age/DataItemDetail/GetDataItemListJson\",\r\n            description: \"==请选择==\",\r\n " +
"           id: \"F_ItemValue\",\r\n            text: \"F_ItemName\",\r\n            heig" +
"ht: \"230px\"\r\n        });\r\n        //获取表单\r\n        if (!!keyValue) {\r\n           " +
" $.SetForm({\r\n                url: \"../../PublicInfoManage/Notice/GetFormJson\",\r" +
"\n                param: { keyValue: keyValue },\r\n                success: functi" +
"on (data) {\r\n                    $(\"#form1\").SetWebControls(data);\r\n            " +
"        editor.setValue(data.F_NewsContent);\r\n                    $(\"#F_FullHead" +
"\").attr(\"color\", data.F_FullHeadColor).css(\"color\", data.F_FullHeadColor);\r\n    " +
"            }\r\n            });\r\n        }\r\n    }\r\n    //选择颜色-设置标题色彩\r\n    functio" +
"n SelectColorEvent() {\r\n        var mycolor = $(\"#select_color\").cxColor();\r\n   " +
"     mycolor.show();\r\n        $(\"#select_color\").bind(\"change\", function () {\r\n " +
"           $(\"#F_FullHead\").css(\"color\", this.value).attr(\"color\", this.value);\r" +
"\n        });\r\n    }\r\n    //保存表单\r\n    function AcceptClick() {\r\n        if (!$(\'#" +
"form1\').Validform()) {\r\n            return false;\r\n        }\r\n        var postDa" +
"ta = {\r\n            F_FullHead: $(\"#F_FullHead\").val(),\r\n            F_FullHeadC" +
"olor: $(\'#F_FullHead\').attr(\'color\'),\r\n            F_Category: $(\"#F_Category\")." +
"attr(\'data-value\'),\r\n            F_ReleaseTime: $(\"#F_ReleaseTime\").val(),\r\n    " +
"        F_NewsContent: editor.getValue()\r\n        }\r\n        $.SaveForm({\r\n     " +
"       url: \"../../PublicInfoManage/Notice/SaveForm?keyValue=\" + keyValue,\r\n    " +
"        param: postData,\r\n            loading: \"正在保存数据...\",\r\n            success" +
": function () {\r\n                $.currentIframe().$(\"#gridTable\").trigger(\"relo" +
"adGrid\");\r\n            }\r\n        })\r\n    }\r\n</script>\r\n<div");

WriteLiteral(" style=\"margin-top: 20px; margin-right: 30px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" style=\"table-layout: auto;\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">公告标题<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_FullHead\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" style=\"color: #000000;\"");

WriteLiteral(" placeholder=\"请输入标题\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n                <span");

WriteLiteral(" id=\"select_color\"");

WriteLiteral(" class=\"input-button\"");

WriteLiteral(" style=\"width: 18px; margin-top: -9px; height: auto;\"");

WriteLiteral(" title=\"使用彩色标题\"");

WriteLiteral(" onclick=\"SelectColorEvent()\"");

WriteLiteral(">\r\n                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 3597), Tuple.Create("\"", 3635)
, Tuple.Create(Tuple.Create("", 3603), Tuple.Create<System.Object, System.Int32>(Href("~/Content/images/large_tiles.png")
, 3603), false)
);

WriteLiteral(" /></span>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">公告类别<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_Category\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">发布时间</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_ReleaseTime\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4100), Tuple.Create("\"", 4157)
            
            #line 94 "..\..\Areas\PublicInfoManage\Views\Notice\Form.cshtml"
           , Tuple.Create(Tuple.Create("", 4108), Tuple.Create<System.Object, System.Int32>(Infoearth.Util.Time.GetToday("yyyy/MM/dd HH:mm")
            
            #line default
            #line hidden
, 4108), false)
);

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">信息来源</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_SourceName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">来源地址</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_SourceAddress\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(" valign=\"top\"");

WriteLiteral(" style=\"padding-top: 4px;\"");

WriteLiteral(">公告内容</th>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <textarea");

WriteLiteral(" id=\"F_NewsContent\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" rows=\"5\"");

WriteLiteral("></textarea>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591