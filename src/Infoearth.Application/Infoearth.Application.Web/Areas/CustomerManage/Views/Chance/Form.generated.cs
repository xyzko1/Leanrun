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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/CustomerManage/Views/Chance/Form.cshtml")]
    public partial class _Areas_CustomerManage_Views_Chance_Form_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_CustomerManage_Views_Chance_Form_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\CustomerManage\Views\Chance\Form.cshtml"
  ;
  ViewBag.Title = "表单页面";
  Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var keyValue = request(\'keyValue\');\r\n    $(function () {\r\n       " +
" initControl();\r\n    });\r\n    //初始化控件\r\n    function initControl() {\r\n        //商" +
"机类别\r\n        $(\"#F_ChanceTypeId\").ComboBox({\r\n            url: \"../../SystemMana" +
"ge/DataItemDetail/GetDataItemListJson\",\r\n            param: { EnCode: \"Client_Ch" +
"anceSort\" },\r\n            id: \"F_ItemValue\",\r\n            text: \"F_ItemName\",\r\n " +
"           description: \"==请选择==\",\r\n            height: \"200px\"\r\n        });\r\n  " +
"      //商机来源      \r\n        $(\"#F_SourceId\").ComboBox({\r\n            url: \"../.." +
"/SystemManage/DataItemDetail/GetDataItemListJson\",\r\n            param: { EnCode:" +
" \"Client_ChanceSource\" },\r\n            id: \"F_ItemValue\",\r\n            text: \"F_" +
"ItemName\",\r\n            description: \"==请选择==\",\r\n            height: \"200px\"\r\n  " +
"      });\r\n        //商机阶段\r\n        $(\"#F_StageId\").ComboBox({\r\n            url: " +
"\"../../SystemManage/DataItemDetail/GetDataItemListJson\",\r\n            param: { E" +
"nCode: \"Client_ChancePhase\" },\r\n            id: \"F_ItemValue\",\r\n            text" +
": \"F_ItemName\",\r\n            description: \"==请选择==\",\r\n            height: \"200px" +
"\"\r\n        });\r\n        //跟进人员\r\n        $(\"#F_TraceUserId\").ComboBoxTree({\r\n    " +
"        url: \"../../BaseManage/User/GetTreeJson\",\r\n            description: \"==请" +
"选择==\",\r\n            height: \"200px\",\r\n            allowSearch: true\r\n        });" +
"\r\n        //公司行业\r\n        $(\"#F_CompanyNatureId\").ComboBox({\r\n            url: \"" +
"../../SystemManage/DataItemDetail/GetDataItemListJson\",\r\n            param: { En" +
"Code: \"Client_Trade\" },\r\n            id: \"F_ItemValue\",\r\n            text: \"F_It" +
"emName\",\r\n            description: \"==请选择==\",\r\n            height: \"200px\"\r\n    " +
"    });\r\n        //所在省份\r\n        $(\"#F_Province\").ComboBox({\r\n            url: \"" +
"../../SystemManage/Area/GetAreaListJson\",\r\n            param: { parentId: \"0\" }," +
"\r\n            id: \"F_AreaCode\",\r\n            text: \"F_AreaName\",\r\n            de" +
"scription: \"==选择省==\",\r\n            height: \"170px\"\r\n        }).bind(\"change\", fu" +
"nction () {\r\n            var value = $(this).attr(\'data-value\');\r\n            $(" +
"\"#F_City\").ComboBox({\r\n                url: \"../../SystemManage/Area/GetAreaList" +
"Json\",\r\n                param: { parentId: value },\r\n                id: \"F_Area" +
"Code\",\r\n                text: \"F_AreaName\",\r\n                description: \"==选择市" +
"==\",\r\n                height: \"170px\"\r\n            });\r\n        });\r\n        //所" +
"在城市\r\n        $(\"#F_City\").ComboBox({\r\n            description: \"==选择市==\",\r\n     " +
"       height: \"170px\"\r\n        });\r\n        //获取表单\r\n        if (!!keyValue) {\r\n" +
"            $.SetForm({\r\n                url: \"../../CustomerManage/Chance/GetFo" +
"rmJson\",\r\n                param: { keyValue: keyValue },\r\n                succes" +
"s: function (data) {\r\n                    $(\"#form1\").SetWebControls(data);\r\n   " +
"                 $(\"#F_Province\").trigger(\"change\"); $(\"#F_City\").ComboBoxSetVal" +
"ue(data.F_City)\r\n                }\r\n            })\r\n        }\r\n    }\r\n    //保存表单" +
";\r\n    function AcceptClick() {\r\n        if (!$(\'#form1\').Validform()) {\r\n      " +
"      return false;\r\n        }\r\n        var postData = $(\"#form1\").GetWebControl" +
"s(keyValue);\r\n        postData[\"F_TraceUserName\"] = $(\"#F_TraceUserId\").attr(\'da" +
"ta-text\');\r\n        $.SaveForm({\r\n            url: \"../../CustomerManage/Chance/" +
"SaveForm?keyValue=\" + keyValue,\r\n            param: postData,\r\n            loadi" +
"ng: \"正在保存数据...\",\r\n            success: function () {\r\n                $.currentI" +
"frame().$(\"#gridTable\").trigger(\"reloadGrid\");\r\n            }\r\n        })\r\n    }" +
"\r\n</script>\r\n<div");

WriteLiteral(" style=\"margin-top: 20px; margin-right: 20px;\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(">\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">商机编号<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_EnCode\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3877), Tuple.Create("\"", 3900)
            
            #line 113 "..\..\Areas\CustomerManage\Views\Chance\Form.cshtml"
, Tuple.Create(Tuple.Create("", 3885), Tuple.Create<System.Object, System.Int32>(ViewBag.EnCode
            
            #line default
            #line hidden
, 3885), false)
);

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">商机名称<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_FullName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onblur=\"$.ExistField(this.id,\'../../CustomerManage/Chance/ExistFullName\')\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">预计金额<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Amount\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" value=\"0.00\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"Double\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">预计利润<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Profit\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" value=\"0.00\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"Double\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">预计成交</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_DealDate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker()\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">销售费用</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_SaleCost\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"DoubleOrNull\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">商机类别</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_ChanceTypeId\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">商机来源<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_SourceId\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">商机阶段<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_StageId\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">成功率%<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_SuccessRate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"Double\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">公司名称<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_CompanyName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">跟进人员<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_TraceUserId\"");

WriteLiteral(" type=\"selectTree\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">公司行业</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_CompanyNatureId\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n            </td>\r\n\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">公司网站</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_CompanySite\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">公司情况</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_CompanyDesc\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">公司地址</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_CompanyAddress\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">所在省份</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_Province\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">所在城市</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"F_City\"");

WriteLiteral(" type=\"select\"");

WriteLiteral(" class=\"ui-select\"");

WriteLiteral("></div>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">联系人<font");

WriteLiteral(" face=\"宋体\"");

WriteLiteral(">*</font></td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Contacts\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" isvalid=\"yes\"");

WriteLiteral(" checkexpession=\"NotNull\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">手机</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Mobile\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">电话</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Tel\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">传真</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Fax\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">QQ</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_QQ\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">Email</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Email\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">微信</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Wechat\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">爱好</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Hobby\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n\r\n            <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">备注</td>\r\n            <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(" colspan=\"3\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"F_Description\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n\r\n    </table>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591