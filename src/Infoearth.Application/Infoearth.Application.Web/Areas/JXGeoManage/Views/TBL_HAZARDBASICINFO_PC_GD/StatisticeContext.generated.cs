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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_HAZARDBASICINFO_PC_GD/StatisticeContext.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_PC_GD_StatisticeContext_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_HAZARDBASICINFO_PC_GD_StatisticeContext_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO_PC_GD\StatisticeContext.cshtml"
  
    ViewBag.Title = "统计内容";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<style>\r\n    .zaihai-leixing1 td {\r\n        padding-left: 0px;\r\n    }\r\n</style>" +
"\r\n<div");

WriteLiteral(" class=\"tanchukuan\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"tanchukuan-left\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"tanchukuan-left1\"");

WriteLiteral(" id=\"tj1\"");

WriteLiteral(">\r\n            <h1>灾害类型</h1>\r\n            <table");

WriteLiteral(" class=\"zaihai-leixing1\"");

WriteLiteral(">\r\n                <tr>                  \r\n                    <td>\r\n            " +
"            <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"dangerousCount\"");

WriteLiteral(" value=\"隐患点\"");

WriteLiteral(" />隐患点\r\n                    </td>                   \r\n                    <td></t" +
"d>\r\n                    <td></td>\r\n                    <td></td>\r\n              " +
"  </tr>\r\n                <tr>\r\n                    <td");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"allzh\"");

WriteLiteral(" value=\"allzh\"");

WriteLiteral(" />全选\r\n                    </td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"huap\"");

WriteLiteral(" value=\"滑坡\"");

WriteLiteral(" />滑坡\r\n                    </td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zhlxbengt\"");

WriteLiteral(" value=\"崩塌\"");

WriteLiteral(" />崩塌\r\n                    </td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zhlxxiep\"");

WriteLiteral(" value=\"斜坡\"");

WriteLiteral(" />斜坡\r\n                    </td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zhlxnisl\"");

WriteLiteral(" value=\"泥石流\"");

WriteLiteral(" />泥石流\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n " +
"                   <td>\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zhlxdimcj\"");

WriteLiteral(" value=\"地面沉降\"");

WriteLiteral(" />地面沉降\r\n                    </td>\r\n                    <td>\r\n                   " +
"     <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zhlxdilf\"");

WriteLiteral(" value=\"地裂缝\"");

WriteLiteral(" />地裂缝\r\n                    </td>\r\n                    <td>\r\n                    " +
"    <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zhlxtax\"");

WriteLiteral(" value=\"地面塌陷\"");

WriteLiteral(" />地面塌陷\r\n                    </td>\r\n                    <td></td>\r\n              " +
"  </tr>\r\n\r\n            </table>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"tanchukuan-left1\"");

WriteLiteral(" id=\"tj2\"");

WriteLiteral(">\r\n            <h1>稳定性及隐患点状态</h1>\r\n            <table");

WriteLiteral(" class=\"zaihai-leixing2\"");

WriteLiteral(">\r\n                <tr>\r\n                    <td");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"allwendbxqk\"");

WriteLiteral(" value=\"allwendbxqk\"");

WriteLiteral(" />全选\r\n                    </td>\r\n                    <td>稳定性</td>\r\n             " +
"       <td>\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"wdwendxh\"");

WriteLiteral(" value=\"目前稳定性好\"");

WriteLiteral(" />稳定性好\r\n                    </td>\r\n                    <td>\r\n                   " +
"     <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"wdwendxjc\"");

WriteLiteral(" value=\"目前稳定性较差\"");

WriteLiteral(" />稳定性较差\r\n                    </td>\r\n                    <td>\r\n                  " +
"      <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"wdwendxc\"");

WriteLiteral(" value=\"目前稳定性差\"");

WriteLiteral(" />稳定性差\r\n                    </td>\r\n                </tr>             \r\n         " +
"   </table>\r\n\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"tanchukuan-left1\"");

WriteLiteral(" id=\"tj3\"");

WriteLiteral(">\r\n            <h1>灾害影响及潜在威胁</h1>\r\n            <table");

WriteLiteral(" class=\"zaihai-leixing3\"");

WriteLiteral(">\r\n                <tr>\r\n                    <td");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"allzhyxjqzwx\"");

WriteLiteral(" value=\"allzhyxjqzwx\"");

WriteLiteral(" />全选\r\n                    </td>                  \r\n                <tr>         " +
"         \r\n                    <td");

WriteLiteral(" class=\"auto-style1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"qianzwxweixrk\"");

WriteLiteral(" value=\"威胁人数\"");

WriteLiteral(" />威胁人数(人)\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"auto-style1\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"qianzwxweixcc\"");

WriteLiteral(" value=\"威胁财产\"");

WriteLiteral(" />威胁财产(万元)\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"auto-style1\"");

WriteLiteral("></td>\r\n                </tr>\r\n            </table>\r\n\r\n        </div>     \r\n     " +
"   <div");

WriteLiteral(" class=\"tanchukuan-left1\"");

WriteLiteral(" id=\"tj4\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral(">\r\n            <h1>灾害体规模及危害性</h1>\r\n            <table");

WriteLiteral(" class=\"zaihai-leixing4\"");

WriteLiteral(" style=\"margin-left: 18px;\"");

WriteLiteral(">\r\n                <tr>\r\n                    <td");

WriteLiteral(" rowspan=\"2\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"allzxq\"");

WriteLiteral(" value=\"allzxq\"");

WriteLiteral(" />全选\r\n                    </td>\r\n                    <td>灾害体规模</td>\r\n           " +
"         <td>\r\n                        <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zqxx\"");

WriteLiteral(" value=\"小型\"");

WriteLiteral(" />小型\r\n                    </td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zqzx\"");

WriteLiteral(" value=\"中型\"");

WriteLiteral(" />中型\r\n                    </td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zqdx\"");

WriteLiteral(" value=\"大型\"");

WriteLiteral(" />大型\r\n                    </td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"zqtdx\"");

WriteLiteral(" value=\"特大型\"");

WriteLiteral(" />特大型\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n " +
"                   <td>危害性</td>\r\n                    <td>\r\n                     " +
"   <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"xqxx\"");

WriteLiteral(" value=\"小\"");

WriteLiteral(" />小\r\n                    </td>\r\n                    <td>\r\n                      " +
"  <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"xqzx\"");

WriteLiteral(" value=\"中\"");

WriteLiteral(" />中\r\n                    </td>\r\n                    <td>\r\n                      " +
"  <input");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" class=\"huxian\"");

WriteLiteral(" id=\"xqdx\"");

WriteLiteral(" value=\"大\"");

WriteLiteral(" />大\r\n                    </td>                \r\n                </tr>\r\n\r\n       " +
"     </table>\r\n\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"tanchukuan-right\"");

WriteLiteral(">\r\n        <fieldset");

WriteLiteral(" class=\"tanchukuan-right1\"");

WriteLiteral(">\r\n            <legend>统计内容</legend>\r\n            <div");

WriteLiteral(" style=\"margin: 0 0 10px 0;\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"xuanding\"");

WriteLiteral(" id=\"allcheck\"");

WriteLiteral(">全部选定</a>\r\n                <a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"xuanding\"");

WriteLiteral(" id=\"canclecheck\"");

WriteLiteral(">取消全部</a>\r\n            </div>\r\n            <div");

WriteLiteral(" style=\"margin: 0 0 10px 0; display: none;\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"xuanding\"");

WriteLiteral(" id=\"selectup\"");

WriteLiteral(">上移</a>\r\n                <a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"xuanding\"");

WriteLiteral(" id=\"selectdown\"");

WriteLiteral(">下移</a>\r\n            </div>\r\n            <div");

WriteLiteral(" style=\"margin: 0 0 10px 0;\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"xuanding\"");

WriteLiteral(" id=\"checkall\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(">查看全部字段</a>\r\n                <a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"xuanding\"");

WriteLiteral(" id=\"delectselect\"");

WriteLiteral(">删除</a>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"wenzi\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"treeDiv\"");

WriteLiteral(" style=\"height: 288px; overflow: auto; background-color: #FFFFFF; margin: 0 auto;" +
"\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"treemenu\"");

WriteLiteral(">\r\n                        <ul");

WriteLiteral(" id=\"tree\"");

WriteLiteral(" style=\"list-style-type: none\"");

WriteLiteral(">\r\n\r\n                            <li");

WriteLiteral(" style=\"text-align: left; cursor: pointer; display: none;\"");

WriteLiteral(" id=\"yinhuandiancount\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'dangerousCount," +
"allzh\'\"");

WriteLiteral(">\r\n                                <p>隐患点<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|0|yinhuandiancount|dangerousCount</span></p>\r\n                            </li>" +
"\r\n                            <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"huaPo\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'huap,allzh\'\"");

WriteLiteral(">\r\n                                <p>滑坡<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|6|huaPo|huap,allzh</span></p>\r\n                            </li>\r\n             " +
"               <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"bengTa\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'zhlxbengt,allzh" +
"\'\"");

WriteLiteral(">\r\n                                <p>崩塌<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|1|bengTa|zhlxbengt,allzh</span></p>\r\n                            </li>\r\n\r\n     " +
"                       <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"xiePo\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'zhlxxiep,allzh\'" +
"\"");

WriteLiteral(">\r\n                                <p>斜坡<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|7|xiePo|zhlxxiep,allzh</span></p>\r\n                            </li>\r\n         " +
"                   <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"nishiLiu\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'zhlxnisl,allzh\'" +
"\"");

WriteLiteral(">\r\n                                <p>泥石流<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|3|nishiLiu|zhlxnisl,allzh</span></p>\r\n                            </li>\r\n      " +
"                      <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"dimcj\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'zhlxdimcj,allzh" +
"\'\"");

WriteLiteral(">\r\n                                <p>地面沉降<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|4|dimcj|zhlxdimcj,allzh</span></p>\r\n                            </li>\r\n        " +
"                    <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"dilieFeng\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'zhlxdilf,allzh\'" +
"\"");

WriteLiteral(">\r\n                                <p>地裂缝<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|5|dilieFeng|zhlxdilf,allzh</span></p>\r\n                            </li>\r\n     " +
"                       <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"taXian\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'zhlxtax,allzh\'\"" +
"");

WriteLiteral(">\r\n                                <p>地面塌陷<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|2|taXian|zhlxtax,allzh</span></p>\r\n                            </li>\r\n\r\n       " +
"                     <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"wendingcd\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'wdwendxh,wdwend" +
"xjc,wdwendxc,allwendbxqk\'\"");

WriteLiteral(">\r\n                                <p>目前稳定程度\t<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|8|wendingcd|wdwendxh,wdwendxjc,wdwendxc,allwendbxqk</span></p>\r\n               " +
"                 <ul");

WriteLiteral(" style=\"list-style-type: none\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" id=\"wendwendxh\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='wdwendxh,allwendbxqk|wendingcd';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>稳定好</div>\r\n                      " +
"                  <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|0|3|wendingcd</span>\r\n                                    </li>\r\n              " +
"                      <li");

WriteLiteral(" id=\"wendwendxjc\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='wdwendxjc,allwendbxqk|wendingcd';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>稳定性较差</div>\r\n                    " +
"                    <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|1|3|wendingcd</span>\r\n                                    </li>\r\n              " +
"                      <li");

WriteLiteral(" id=\"wendwenxc\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='wdwendxc,allwendbxqk|wendingcd';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>稳定性差</div>\r\n                     " +
"                   <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|2|3|wendingcd</span>\r\n                                    </li>\r\n              " +
"                  </ul>\r\n                            </li>\r\n                    " +
"        <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"qianzwx\"");

WriteLiteral(" style=\"cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'qianzwxweixrk,q" +
"ianzwxweixcc\'\"");

WriteLiteral(">\r\n                                <p>潜在威胁<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|11|qianzwx|qianzwxweixrk,qianzwxweixcc</span></p>\r\n                            " +
"    <ul");

WriteLiteral(" style=\"list-style-type: none\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" id=\"qzwxwxrk\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='qianzwxweixrk,allzhyxjqzwx|qianzwx';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>威胁人数</div>\r\n                     " +
"                   <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|0|3|qianzwx</span>\r\n                                    </li>\r\n                " +
"                    <li");

WriteLiteral(" id=\"qzwxwxcc\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='qianzwxweixcc,allzhyxjqzwx|qianzwx';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>威胁财产</div>\r\n                     " +
"                   <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|1|3|qianzwx</span>\r\n                                    </li>\r\n                " +
"                    <li");

WriteLiteral(" id=\"qzwxwxhs\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral("></li>\r\n                                </ul>\r\n                            </li>\r" +
"\n                            <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"zaiqing\"");

WriteLiteral(" style=\"display:none; cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'zqxx,zqzx,zqdx," +
"zqtdx,allzxq\'\"");

WriteLiteral(">\r\n                                <p>灾害体规模<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|12|zaiqing|zqxx,zqzx,zqdx,zqtdx,allzxq</span></p>\r\n                            " +
"    <ul");

WriteLiteral(" style=\"list-style-type: none\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" id=\"zaiqingxx\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='zqxx,allzxq|zaiqing';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>小型</div>\r\n                       " +
"                 <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|0|4|zaiqing</span>\r\n                                    </li>\r\n                " +
"                    <li");

WriteLiteral(" id=\"zaiqingzx\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='zqzx,allzxq|zaiqing';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>中型</div>\r\n                       " +
"                 <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|1|4|zaiqing</span>\r\n                                    </li>\r\n                " +
"                    <li");

WriteLiteral(" id=\"zaiqingdx\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='zqdx,allzxq|zaiqing';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>大型</div>\r\n                       " +
"                 <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|2|4|zaiqing</span>\r\n                                    </li>\r\n                " +
"                    <li");

WriteLiteral(" id=\"zaiqingtdx\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='zqtdx,allzxq|zaiqing';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>特大型</div>\r\n                      " +
"                  <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|3|4|zaiqing</span>\r\n                                    </li>\r\n                " +
"                </ul>\r\n                            </li>\r\n                      " +
"      <li");

WriteLiteral(" state=\"closed\"");

WriteLiteral(" class=\"caidan\"");

WriteLiteral(" id=\"xianqing\"");

WriteLiteral(" style=\"display:none;cursor: pointer\"");

WriteLiteral(" onclick=\"javascript:object_statistics_p=$(this)[0];object_check=\'xqxx,xqzx,xqdx," +
"allzxq\'\"");

WriteLiteral(">\r\n                                <p>危害性<span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|12|xianqing|xqxx,xqzx,xqdx,allzxq</span></p>\r\n                                <" +
"ul");

WriteLiteral(" style=\"list-style-type: none\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" id=\"xianqingxx\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='xqxx,allzxq|xianqing';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>小</div>\r\n                        " +
"                <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|0|4|xianqing</span>\r\n                                    </li>\r\n               " +
"                     <li");

WriteLiteral(" id=\"xianqingzx\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='xqzx,allzxq|xianqing';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>中</div>\r\n                        " +
"                <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">|1|4|xianqing</span>\r\n                                    </li>\r\n               " +
"                     <li");

WriteLiteral(" id=\"xianqingdx\"");

WriteLiteral(@" onclick=""javascript:$('.caidan p').each(function () {  $(this).css('color', '#000');});  $('.caidan li').each(function () {  $(this).css('color', '#000');  });$(this).css('color','green');parent_statistics=false;markname_statistics=true;object_statistics=$(this)[0];txmark_statistics='xqdx,allzxq|xianqing';mark_statistics=true""");

WriteLiteral(">\r\n                                        <div>大</div>\r\n                        " +
"                <span");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(@">|2|4|xianqing</span>
                                    </li>                                  
                                </ul>
                            </li>                         
                        </ul>
                    </div>
                </div>
            </div>
            <a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"queding\"");

WriteLiteral(" id=\"yes\"");

WriteLiteral(">确定</a><a");

WriteLiteral(" href=\"javascript:void(0);\"");

WriteLiteral(" class=\"quxiao\"");

WriteLiteral(" id=\"cancle\"");

WriteLiteral(">取消</a>\r\n        </fieldset>\r\n\r\n    </div>\r\n\r\n\r\n\r\n</div>\r\n");

            
            #line 262 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO_PC_GD\StatisticeContext.cshtml"
Write(System.Web.Optimization.Styles.Render(
    "~/Content/disaster/Base.css",
"~/Content/disaster/GeoMap2.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 265 "..\..\Areas\JXGeoManage\Views\TBL_HAZARDBASICINFO_PC_GD\StatisticeContext.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/disaster/StatisticsNew.js"
));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>\r\n    function AcceptClick() {\r\n        var queryJson = $(\"#Tj\").getWeb" +
"Controls();\r\n        learun.dialogClose();\r\n        return queryJson;\r\n    }\r\n  " +
"  //2013-6-14 cml\r\n\r\n\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
