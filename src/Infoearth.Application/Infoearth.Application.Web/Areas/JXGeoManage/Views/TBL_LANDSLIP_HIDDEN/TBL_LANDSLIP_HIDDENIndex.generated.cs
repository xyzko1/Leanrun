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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_LANDSLIP_HIDDEN/TBL_LANDSLIP_HIDDENIndex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_LANDSLIP_HIDDEN_TBL_LANDSLIP_HIDDENIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_LANDSLIP_HIDDEN_TBL_LANDSLIP_HIDDENIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_LANDSLIP_HIDDEN\TBL_LANDSLIP_HIDDENIndex.cshtml"
  
    ViewBag.Title = "列表页面";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(">\r\n        <table>\r\n            <tr>\r\n                <td>\r\n                    <" +
"input");

WriteLiteral(" id=\"txt_Keyword\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"请输入要查询关键字\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(" />\r\n                </td>\r\n                <td");

WriteLiteral(" style=\"padding-left: 5px;\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></i> 查询</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </d" +
"iv>\r\n    <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>★刷新</a>\r\n            <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>★新增</a>\r\n            <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>★编辑</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>★删除</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n    <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script>;\r\n    $(function () {\r\n        InitialPage();\r\n        GetGrid();\r\n   " +
" });\r\n    //初始化页面\r\n    function InitialPage() {\r\n        //resize重设布局;\r\n        " +
"$(window).resize(function (e) {\r\n            window.setTimeout(function () {\r\n  " +
"              $(\'#gridTable\').setGridWidth(($(\'.gridPanel\').width()));\r\n        " +
"        $(\'#gridTable\').setGridHeight($(window).height() - 136.5);\r\n            " +
"}, 200);\r\n            e.stopPropagation();\r\n        });\r\n    }\r\n    //加载表格\r\n    " +
"function GetGrid() {\r\n        var selectedRowIndex = 0;\r\n        var $gridTable " +
"= $(\'#gridTable\');\r\n        $gridTable.jqGrid({\r\n            autowidth: true,\r\n " +
"           height: $(window).height() - 136.5,\r\n            url: \"../../JXGeoMan" +
"age/TBL_LANDSLIP/GetPageListJson\",\r\n            datatype: \"json\",\r\n            c" +
"olModel: [\r\n                           { label: \'统一编号\', name: \'UNIFIEDCODE\', ind" +
"ex: \'UNIFIEDCODE\', width: 100, align: \'left\', sortable: true },\r\n               " +
"            { label: \'CGH系统灾害点编码\', name: \'CGHUNIFIEDCODE\', index: \'CGHUNIFIEDCOD" +
"E\', width: 100, align: \'left\', sortable: true },\r\n                           { l" +
"abel: \'灾害点名称\', name: \'DISASTERUNITNAME\', index: \'DISASTERUNITNAME\', width: 100, " +
"align: \'left\', sortable: true },\r\n                           { label: \'野外编号\', na" +
"me: \'OUTDOORCODE\', index: \'OUTDOORCODE\', width: 100, align: \'left\', sortable: tr" +
"ue },\r\n                           { label: \'室内编号\', name: \'INDOORCODE\', index: \'I" +
"NDOORCODE\', width: 100, align: \'left\', sortable: true },\r\n                      " +
"     { label: \'省\', name: \'PROVINCE\', index: \'PROVINCE\', width: 100, align: \'left" +
"\', sortable: true },\r\n                           { label: \'市（县）\', name: \'CITY\', " +
"index: \'CITY\', width: 100, align: \'left\', sortable: true },\r\n                   " +
"        { label: \'乡镇\', name: \'TOWN\', index: \'TOWN\', width: 100, align: \'left\', s" +
"ortable: true },\r\n                           { label: \'地理位置（村）\', name: \'LOCATION" +
"\', index: \'LOCATION\', width: 100, align: \'left\', sortable: true },\r\n            " +
"               { label: \'经度\', name: \'LATITUDE\', index: \'LATITUDE\', width: 100, a" +
"lign: \'left\', sortable: true },\r\n                           { label: \'纬度\', name:" +
" \'LONGITUDE\', index: \'LONGITUDE\', width: 100, align: \'left\', sortable: true },\r\n" +
"                           { label: \'X坐标\', name: \'X\', index: \'X\', width: 100, al" +
"ign: \'left\', sortable: true },\r\n                           { label: \'Y坐标\', name:" +
" \'Y\', index: \'Y\', width: 100, align: \'left\', sortable: true },\r\n                " +
"           { label: \'Z坐标\', name: \'Z\', index: \'Z\', width: 100, align: \'left\', sor" +
"table: true },\r\n                           { label: \'坡底\', name: \'ALTTOP\', index:" +
" \'ALTTOP\', width: 100, align: \'left\', sortable: true },\r\n                       " +
"    { label: \'坡顶\', name: \'ALTBOTOM\', index: \'ALTBOTOM\', width: 100, align: \'left" +
"\', sortable: true },\r\n                           { label: \'滑坡年代\', name: \'LANDSLI" +
"PYEAR\', index: \'LANDSLIPYEAR\', width: 100, align: \'left\', sortable: true },\r\n   " +
"                        { label: \'滑坡时间\', name: \'LANDSLIPTIME\', index: \'LANDSLIPT" +
"IME\', width: 100, align: \'left\', sortable: true },\r\n                           {" +
" label: \'滑坡类型\', name: \'LANDSLIPTYPE\', index: \'LANDSLIPTYPE\', width: 100, align: " +
"\'left\', sortable: true },\r\n                           { label: \'滑体性质\', name: \'LA" +
"NDSLIPKIND\', index: \'LANDSLIPKIND\', width: 100, align: \'left\', sortable: true }," +
"\r\n                           { label: \'地层时代\', name: \'STRATIGRAPHICTIME\', index: " +
"\'STRATIGRAPHICTIME\', width: 100, align: \'left\', sortable: true },\r\n             " +
"              { label: \'地层岩性\', name: \'LITHOLOGY\', index: \'LITHOLOGY\', width: 100" +
", align: \'left\', sortable: true },\r\n                           { label: \'构造部位\', " +
"name: \'TECTONICREGION\', index: \'TECTONICREGION\', width: 100, align: \'left\', sort" +
"able: true },\r\n                           { label: \'地震烈度\', name: \'EARTHQUAKEINTE" +
"NSITY\', index: \'EARTHQUAKEINTENSITY\', width: 100, align: \'left\', sortable: true " +
"},\r\n                           { label: \'地层倾向\', name: \'STRATUMDIRECTION\', index:" +
" \'STRATUMDIRECTION\', width: 100, align: \'left\', sortable: true },\r\n             " +
"              { label: \'地层倾角\', name: \'STRATUMANGLE\', index: \'STRATUMANGLE\', widt" +
"h: 100, align: \'left\', sortable: true },\r\n                           { label: \'微" +
"地貌\', name: \'MICROTOPOGRAPHY\', index: \'MICROTOPOGRAPHY\', width: 100, align: \'left" +
"\', sortable: true },\r\n                           { label: \'地下水类型\', name: \'GROUND" +
"WATERTYPE\', index: \'GROUNDWATERTYPE\', width: 100, align: \'left\', sortable: true " +
"},\r\n                           { label: \'年均降雨量\', name: \'AVERAGEYEARRAINFALL\', in" +
"dex: \'AVERAGEYEARRAINFALL\', width: 100, align: \'left\', sortable: true },\r\n      " +
"                     { label: \'日最大降雨量\', name: \'MAXDAYRAINFALL\', index: \'MAXDAYRA" +
"INFALL\', width: 100, align: \'left\', sortable: true },\r\n                         " +
"  { label: \'时最大降雨量\', name: \'MAXHOURRAINFALL\', index: \'MAXHOURRAINFALL\', width: 1" +
"00, align: \'left\', sortable: true },\r\n                           { label: \'洪水位\'," +
" name: \'MAXWATERLEVEL\', index: \'MAXWATERLEVEL\', width: 100, align: \'left\', sorta" +
"ble: true },\r\n                           { label: \'枯水位\', name: \'MINWATERLEVEL\', " +
"index: \'MINWATERLEVEL\', width: 100, align: \'left\', sortable: true },\r\n          " +
"                 { label: \'相对河流位置\', name: \'POSITIONTORIVER\', index: \'POSITIONTOR" +
"IVER\', width: 100, align: \'left\', sortable: true },\r\n                           " +
"{ label: \'原始坡高\', name: \'ORIGINALSLOPEHEIGHT\', index: \'ORIGINALSLOPEHEIGHT\', widt" +
"h: 100, align: \'left\', sortable: true },\r\n                           { label: \'原" +
"始坡度\', name: \'ORIGINALSLOPEANGLE\', index: \'ORIGINALSLOPEANGLE\', width: 100, align" +
": \'left\', sortable: true },\r\n                           { label: \'原始坡形\', name: \'" +
"ORIGINALSLOPESHAPE\', index: \'ORIGINALSLOPESHAPE\', width: 100, align: \'left\', sor" +
"table: true },\r\n                           { label: \'斜坡结构类型\', name: \'SLOPEARCHTY" +
"PE\', index: \'SLOPEARCHTYPE\', width: 100, align: \'left\', sortable: true },\r\n     " +
"                      { label: \'斜坡结构类型\', name: \'SLOPEASPECTARCHTYPE\', index: \'SL" +
"OPEASPECTARCHTYPE\', width: 100, align: \'left\', sortable: true },\r\n              " +
"             { label: \'控滑结构面类型1\', name: \'SURFACETYPE1\', index: \'SURFACETYPE1\', w" +
"idth: 100, align: \'left\', sortable: true },\r\n                           { label:" +
" \'控滑结构面倾向1\', name: \'SURFACEDIRECTION1\', index: \'SURFACEDIRECTION1\', width: 100, " +
"align: \'left\', sortable: true },\r\n                           { label: \'控滑结构面倾角1\'" +
", name: \'SURFACEANGLE1\', index: \'SURFACEANGLE1\', width: 100, align: \'left\', sort" +
"able: true },\r\n                           { label: \'控滑结构面类型2\', name: \'SURFACETYP" +
"E2\', index: \'SURFACETYPE2\', width: 100, align: \'left\', sortable: true },\r\n      " +
"                     { label: \'控滑结构面倾向2\', name: \'SURFACEDIRECTION2\', index: \'SUR" +
"FACEDIRECTION2\', width: 100, align: \'left\', sortable: true },\r\n                 " +
"          { label: \'控滑结构面倾角2\', name: \'SURFACEANGLE2\', index: \'SURFACEANGLE2\', wi" +
"dth: 100, align: \'left\', sortable: true },\r\n                           { label: " +
"\'控滑结构面类型3\', name: \'SURFACETYPE3\', index: \'SURFACETYPE3\', width: 100, align: \'lef" +
"t\', sortable: true },\r\n                           { label: \'控滑结构面倾向3\', name: \'SU" +
"RFACEDIRECTION3\', index: \'SURFACEDIRECTION3\', width: 100, align: \'left\', sortabl" +
"e: true },\r\n                           { label: \'控滑结构面倾角3\', name: \'SURFACEANGLE3" +
"\', index: \'SURFACEANGLE3\', width: 100, align: \'left\', sortable: true },\r\n       " +
"                    { label: \'滑坡长度\', name: \'LANDSLIPLENGTH\', index: \'LANDSLIPLEN" +
"GTH\', width: 100, align: \'left\', sortable: true },\r\n                           {" +
" label: \'滑坡宽度\', name: \'LANDSLIPWIDTH\', index: \'LANDSLIPWIDTH\', width: 100, align" +
": \'left\', sortable: true },\r\n                           { label: \'滑坡厚度\', name: \'" +
"LANDSLIPDEPTH\', index: \'LANDSLIPDEPTH\', width: 100, align: \'left\', sortable: tru" +
"e },\r\n                           { label: \'滑坡坡度\', name: \'LANDSLIPANGLE\', index: " +
"\'LANDSLIPANGLE\', width: 100, align: \'left\', sortable: true },\r\n                 " +
"          { label: \'滑坡坡向\', name: \'LANDSLIPDIRECTION\', index: \'LANDSLIPDIRECTION\'" +
", width: 100, align: \'left\', sortable: true },\r\n                           { lab" +
"el: \'滑坡面积\', name: \'LANDSLIPSIZE\', index: \'LANDSLIPSIZE\', width: 100, align: \'lef" +
"t\', sortable: true },\r\n                           { label: \'滑坡体积\', name: \'LANDSL" +
"IPVOLUME\', index: \'LANDSLIPVOLUME\', width: 100, align: \'left\', sortable: true }," +
"\r\n                           { label: \'滑坡平面形态\', name: \'LANDSLIPFLATSHAPE\', index" +
": \'LANDSLIPFLATSHAPE\', width: 100, align: \'left\', sortable: true },\r\n           " +
"                { label: \'滑坡剖面形态\', name: \'LANDSLIPSECTIONSHAPE\', index: \'LANDSLI" +
"PSECTIONSHAPE\', width: 100, align: \'left\', sortable: true },\r\n                  " +
"         { label: \'规模等级\', name: \'SCALELEVEL\', index: \'SCALELEVEL\', width: 100, a" +
"lign: \'left\', sortable: true },\r\n                           { label: \'滑体岩性\', nam" +
"e: \'LANDSLIPLITHOLOGY\', index: \'LANDSLIPLITHOLOGY\', width: 100, align: \'left\', s" +
"ortable: true },\r\n                           { label: \'滑体结构\', name: \'LANDSLIPARC" +
"H\', index: \'LANDSLIPARCH\', width: 100, align: \'left\', sortable: true },\r\n       " +
"                    { label: \'滑体碎石含量\', name: \'GRAVELCONTENT\', index: \'GRAVELCONT" +
"ENT\', width: 100, align: \'left\', sortable: true },\r\n                           {" +
" label: \'滑体块度\', name: \'LANDSLIPBLOCKDEGREE\', index: \'LANDSLIPBLOCKDEGREE\', width" +
": 100, align: \'left\', sortable: true },\r\n                           { label: \'滑床" +
"岩性\', name: \'SLIPBEDLITHOLOGY\', index: \'SLIPBEDLITHOLOGY\', width: 100, align: \'le" +
"ft\', sortable: true },\r\n                           { label: \'滑床时代\', name: \'SLIPB" +
"EDTIME\', index: \'SLIPBEDTIME\', width: 100, align: \'left\', sortable: true },\r\n   " +
"                        { label: \'滑床倾向\', name: \'SLIPBEDDIRECTION\', index: \'SLIPB" +
"EDDIRECTION\', width: 100, align: \'left\', sortable: true },\r\n                    " +
"       { label: \'滑床倾角\', name: \'SLIPBEDANGLE\', index: \'SLIPBEDANGLE\', width: 100," +
" align: \'left\', sortable: true },\r\n                           { label: \'滑面形态\', n" +
"ame: \'SLIPSURFACESHAPE\', index: \'SLIPSURFACESHAPE\', width: 100, align: \'left\', s" +
"ortable: true },\r\n                           { label: \'滑面埋深\', name: \'SLIPSURFACE" +
"DEPTH\', index: \'SLIPSURFACEDEPTH\', width: 100, align: \'left\', sortable: true },\r" +
"\n                           { label: \'滑面倾向\', name: \'SLIPSURFACEDIRECTION\', index" +
": \'SLIPSURFACEDIRECTION\', width: 100, align: \'left\', sortable: true },\r\n        " +
"                   { label: \'滑面倾角\', name: \'SLIPSURFACEANGLE\', index: \'SLIPSURFAC" +
"EANGLE\', width: 100, align: \'left\', sortable: true },\r\n                         " +
"  { label: \'滑带厚度\', name: \'SLIPZONEDEPTH\', index: \'SLIPZONEDEPTH\', width: 100, al" +
"ign: \'left\', sortable: true },\r\n                           { label: \'滑带土名称\', nam" +
"e: \'LANDSLIPSOILNAME\', index: \'LANDSLIPSOILNAME\', width: 100, align: \'left\', sor" +
"table: true },\r\n                           { label: \'滑带土性状\', name: \'LANDSLIPSOIL" +
"CHARACTERS\', index: \'LANDSLIPSOILCHARACTERS\', width: 100, align: \'left\', sortabl" +
"e: true },\r\n                           { label: \'地下水埋深\', name: \'GROUNDWATERDEPTH" +
"\', index: \'GROUNDWATERDEPTH\', width: 100, align: \'left\', sortable: true },\r\n    " +
"                       { label: \'地下水露头\', name: \'GROUNDWATEROUTCROP\', index: \'GRO" +
"UNDWATEROUTCROP\', width: 100, align: \'left\', sortable: true },\r\n                " +
"           { label: \'地下水补给类型\', name: \'GROUNDWATERSUPPLYTYPE\', index: \'GROUNDWATE" +
"RSUPPLYTYPE\', width: 100, align: \'left\', sortable: true },\r\n                    " +
"       { label: \'土地使用\', name: \'LANDUSAGE\', index: \'LANDUSAGE\', width: 100, align" +
": \'left\', sortable: true },\r\n                           { label: \'变形迹象名称1\', name" +
": \'DISTORTIONSIGN1\', index: \'DISTORTIONSIGN1\', width: 100, align: \'left\', sortab" +
"le: true },\r\n                           { label: \'变形迹象部位1\', name: \'DISTORTIONPLA" +
"CE1\', index: \'DISTORTIONPLACE1\', width: 100, align: \'left\', sortable: true },\r\n " +
"                          { label: \'变形迹象特征1\', name: \'DISTORTIONCHARACTER1\', inde" +
"x: \'DISTORTIONCHARACTER1\', width: 100, align: \'left\', sortable: true },\r\n       " +
"                    { label: \'变形迹象初现时间1\', name: \'DISTORTIONINITDATE1\', index: \'D" +
"ISTORTIONINITDATE1\', width: 100, align: \'left\', sortable: true },\r\n             " +
"              { label: \'变形迹象名称2\', name: \'DISTORTIONSIGN2\', index: \'DISTORTIONSIG" +
"N2\', width: 100, align: \'left\', sortable: true },\r\n                           { " +
"label: \'变形迹象部位2\', name: \'DISTORTIONPLACE2\', index: \'DISTORTIONPLACE2\', width: 10" +
"0, align: \'left\', sortable: true },\r\n                           { label: \'变形迹象特征" +
"2\', name: \'DISTORTIONCHARACTER2\', index: \'DISTORTIONCHARACTER2\', width: 100, ali" +
"gn: \'left\', sortable: true },\r\n                           { label: \'变形迹象初现时间2\', " +
"name: \'DISTORTIONINITDATE2\', index: \'DISTORTIONINITDATE2\', width: 100, align: \'l" +
"eft\', sortable: true },\r\n                           { label: \'变形迹象名称3\', name: \'D" +
"ISTORTIONSIGN3\', index: \'DISTORTIONSIGN3\', width: 100, align: \'left\', sortable: " +
"true },\r\n                           { label: \'变形迹象部位3\', name: \'DISTORTIONPLACE3\'" +
", index: \'DISTORTIONPLACE3\', width: 100, align: \'left\', sortable: true },\r\n     " +
"                      { label: \'变形迹象特征3\', name: \'DISTORTIONCHARACTER3\', index: \'" +
"DISTORTIONCHARACTER3\', width: 100, align: \'left\', sortable: true },\r\n           " +
"                { label: \'变形迹象初现时间3\', name: \'DISTORTIONINITDATE3\', index: \'DISTO" +
"RTIONINITDATE3\', width: 100, align: \'left\', sortable: true },\r\n                 " +
"          { label: \'变形迹象名称4\', name: \'DISTORTIONSIGN4\', index: \'DISTORTIONSIGN4\'," +
" width: 100, align: \'left\', sortable: true },\r\n                           { labe" +
"l: \'变形迹象部位4\', name: \'DISTORTIONPLACE4\', index: \'DISTORTIONPLACE4\', width: 100, a" +
"lign: \'left\', sortable: true },\r\n                           { label: \'变形迹象特征4\', " +
"name: \'DISTORTIONCHARACTER4\', index: \'DISTORTIONCHARACTER4\', width: 100, align: " +
"\'left\', sortable: true },\r\n                           { label: \'变形迹象初现时间4\', name" +
": \'DISTORTIONINITDATE4\', index: \'DISTORTIONINITDATE4\', width: 100, align: \'left\'" +
", sortable: true },\r\n                           { label: \'变形迹象名称5\', name: \'DISTO" +
"RTIONSIGN5\', index: \'DISTORTIONSIGN5\', width: 100, align: \'left\', sortable: true" +
" },\r\n                           { label: \'变形迹象部位5\', name: \'DISTORTIONPLACE5\', in" +
"dex: \'DISTORTIONPLACE5\', width: 100, align: \'left\', sortable: true },\r\n         " +
"                  { label: \'变形迹象特征5\', name: \'DISTORTIONCHARACTER5\', index: \'DIST" +
"ORTIONCHARACTER5\', width: 100, align: \'left\', sortable: true },\r\n               " +
"            { label: \'变形迹象初现时间5\', name: \'DISTORTIONINITDATE5\', index: \'DISTORTIO" +
"NINITDATE5\', width: 100, align: \'left\', sortable: true },\r\n                     " +
"      { label: \'变形迹象部位6\', name: \'DISTORTIONPLACE6\', index: \'DISTORTIONPLACE6\', w" +
"idth: 100, align: \'left\', sortable: true },\r\n                           { label:" +
" \'变形迹象名称6\', name: \'DISTORTIONSIGN6\', index: \'DISTORTIONSIGN6\', width: 100, align" +
": \'left\', sortable: true },\r\n                           { label: \'变形迹象特征6\', name" +
": \'DISTORTIONCHARACTER6\', index: \'DISTORTIONCHARACTER6\', width: 100, align: \'lef" +
"t\', sortable: true },\r\n                           { label: \'变形迹象名称7\', name: \'DIS" +
"TORTIONSIGN7\', index: \'DISTORTIONSIGN7\', width: 100, align: \'left\', sortable: tr" +
"ue },\r\n                           { label: \'变形迹象部位7\', name: \'DISTORTIONPLACE7\', " +
"index: \'DISTORTIONPLACE7\', width: 100, align: \'left\', sortable: true },\r\n       " +
"                    { label: \'变形迹象特征7\', name: \'DISTORTIONCHARACTER7\', index: \'DI" +
"STORTIONCHARACTER7\', width: 100, align: \'left\', sortable: true },\r\n             " +
"              { label: \'变形迹象初现时间7\', name: \'DISTORTIONINITDATE7\', index: \'DISTORT" +
"IONINITDATE7\', width: 100, align: \'left\', sortable: true },\r\n                   " +
"        { label: \'变形迹象名称8\', name: \'DISTORTIONSIGN8\', index: \'DISTORTIONSIGN8\', w" +
"idth: 100, align: \'left\', sortable: true },\r\n                           { label:" +
" \'变形迹象部位8\', name: \'DISTORTIONPLACE8\', index: \'DISTORTIONPLACE8\', width: 100, ali" +
"gn: \'left\', sortable: true },\r\n                           { label: \'变形迹象特征8\', na" +
"me: \'DISTORTIONCHARACTER8\', index: \'DISTORTIONCHARACTER8\', width: 100, align: \'l" +
"eft\', sortable: true },\r\n                           { label: \'变形迹象初现时间8\', name: " +
"\'DISTORTIONINITDATE8\', index: \'DISTORTIONINITDATE8\', width: 100, align: \'left\', " +
"sortable: true },\r\n                           { label: \'地质因素\', name: \'GEOLOGICFA" +
"CTOR\', index: \'GEOLOGICFACTOR\', width: 100, align: \'left\', sortable: true },\r\n  " +
"                         { label: \'地貌因素\', name: \'GEOMORPHICFACTOR\', index: \'GEOM" +
"ORPHICFACTOR\', width: 100, align: \'left\', sortable: true },\r\n                   " +
"        { label: \'物理因素\', name: \'PHYSICALFACTORS\', index: \'PHYSICALFACTORS\', widt" +
"h: 100, align: \'left\', sortable: true },\r\n                           { label: \'人" +
"为因素\', name: \'HUMANFACTOR\', index: \'HUMANFACTOR\', width: 100, align: \'left\', sort" +
"able: true },\r\n                           { label: \'主导因素\', name: \'MAINFACTOR\', i" +
"ndex: \'MAINFACTOR\', width: 100, align: \'left\', sortable: true },\r\n              " +
"             { label: \'复活诱发因素\', name: \'REINDUCEDFACTOR\', index: \'REINDUCEDFACTOR" +
"\', width: 100, align: \'left\', sortable: true },\r\n                           { la" +
"bel: \'目前稳定状态\', name: \'CURSTABLESTATUS\', index: \'CURSTABLESTATUS\', width: 100, al" +
"ign: \'left\', sortable: true },\r\n                           { label: \'今后变化趋势\', na" +
"me: \'STABLETREND\', index: \'STABLETREND\', width: 100, align: \'left\', sortable: tr" +
"ue },\r\n                           { label: \'隐患点\', name: \'HIDDENDANGER\', index: \'" +
"HIDDENDANGER\', width: 100, align: \'left\', sortable: true },\r\n                   " +
"        { label: \'毁坏房屋\', name: \'DESTROYEDHOME\', index: \'DESTROYEDHOME\', width: 1" +
"00, align: \'left\', sortable: true },\r\n                           { label: \'死亡人口\'" +
", name: \'DEATHSPEOPLE\', index: \'DEATHSPEOPLE\', width: 100, align: \'left\', sortab" +
"le: true },\r\n                           { label: \'灾情等级\', name: \'DISASTERLEVEL\', " +
"index: \'DISASTERLEVEL\', width: 100, align: \'left\', sortable: true },\r\n          " +
"                 { label: \'威胁住户\', name: \'THREATENHOUSEHOLD\', index: \'THREATENHOU" +
"SEHOLD\', width: 100, align: \'left\', sortable: true },\r\n                         " +
"  { label: \'威胁人口\', name: \'THREATENPEOPLE\', index: \'THREATENPEOPLE\', width: 100, " +
"align: \'left\', sortable: true },\r\n                           { label: \'威胁财产\', na" +
"me: \'THREATENASSETS\', index: \'THREATENASSETS\', width: 100, align: \'left\', sortab" +
"le: true },\r\n                           { label: \'险情等级\', name: \'DANGERLEVEL\', in" +
"dex: \'DANGERLEVEL\', width: 100, align: \'left\', sortable: true },\r\n              " +
"             { label: \'监测建议\', name: \'LANDSLIPMONITORSUGGESTION\', index: \'LANDSLI" +
"PMONITORSUGGESTION\', width: 100, align: \'left\', sortable: true },\r\n             " +
"              { label: \'防灾预案\', name: \'PREVENTIONPLAN\', index: \'PREVENTIONPLAN\', " +
"width: 100, align: \'left\', sortable: true },\r\n                           { label" +
": \'防治建议\', name: \'TREATMENTSUGGESTION\', index: \'TREATMENTSUGGESTION\', width: 100," +
" align: \'left\', sortable: true },\r\n                           { label: \'群测人员\', n" +
"ame: \'MONITORMASS\', index: \'MONITORMASS\', width: 100, align: \'left\', sortable: t" +
"rue },\r\n                           { label: \'村长\', name: \'VILLAGEHEADER\', index: " +
"\'VILLAGEHEADER\', width: 100, align: \'left\', sortable: true },\r\n                 " +
"          { label: \'电话\', name: \'PHONE\', index: \'PHONE\', width: 100, align: \'left" +
"\', sortable: true },\r\n                           { label: \'调查负责人\', name: \'SURVEY" +
"HEADER\', index: \'SURVEYHEADER\', width: 100, align: \'left\', sortable: true },\r\n  " +
"                         { label: \'填表人\', name: \'FILLTABLEPEOPLE\', index: \'FILLTA" +
"BLEPEOPLE\', width: 100, align: \'left\', sortable: true },\r\n                      " +
"     { label: \'审核人\', name: \'VERIFYPEOPLE\', index: \'VERIFYPEOPLE\', width: 100, al" +
"ign: \'left\', sortable: true },\r\n                           { label: \'调查单位\', name" +
": \'SURVEYDEPT\', index: \'SURVEYDEPT\', width: 100, align: \'left\', sortable: true }" +
",\r\n                           { label: \'填表日期\', name: \'FILLTABLEDATE\', index: \'FI" +
"LLTABLEDATE\', width: 100, align: \'left\', sortable: true },\r\n                    " +
"       { label: \'更新时间\', name: \'UPDATETIME\', index: \'UPDATETIME\', width: 100, ali" +
"gn: \'left\', sortable: true },\r\n                           { label: \'记录状态\', name:" +
" \'RECORDSTATUS\', index: \'RECORDSTATUS\', width: 100, align: \'left\', sortable: tru" +
"e },\r\n                           { label: \'导出状态\', name: \'EXPSTATUS\', index: \'EXP" +
"STATUS\', width: 100, align: \'left\', sortable: true },\r\n                         " +
"  { label: \'防灾情况\', name: \'CONTROLSTATE\', index: \'CONTROLSTATE\', width: 100, alig" +
"n: \'left\', sortable: true },\r\n                           { label: \'创建者ID\', name:" +
" \'CREATORUSERID\', index: \'CREATORUSERID\', width: 100, align: \'left\', sortable: t" +
"rue },\r\n                           { label: \'创建时间\', name: \'CREATORTIME\', index: " +
"\'CREATORTIME\', width: 100, align: \'left\', sortable: true },\r\n                   " +
"        { label: \'更新者ID\', name: \'UPDATEUSERID\', index: \'UPDATEUSERID\', width: 10" +
"0, align: \'left\', sortable: true },\r\n                           { label: \'更新次数\'," +
" name: \'UPDATETIMES\', index: \'UPDATETIMES\', width: 100, align: \'left\', sortable:" +
" true },\r\n                           { label: \'滑坡情况\', name: \'LANDSLIPDESC\', inde" +
"x: \'LANDSLIPDESC\', width: 100, align: \'left\', sortable: true },\r\n               " +
"            { label: \'项目编号\', name: \'PROJECTID\', index: \'PROJECTID\', width: 100, " +
"align: \'left\', sortable: true },\r\n                           { label: \'图幅编号\', na" +
"me: \'MAPID\', index: \'MAPID\', width: 100, align: \'left\', sortable: true },\r\n     " +
"                      { label: \'图幅名称\', name: \'MAPNAME\', index: \'MAPNAME\', width:" +
" 100, align: \'left\', sortable: true },\r\n                           { label: \'县市编" +
"号\', name: \'COUNTYCODE\', index: \'COUNTYCODE\', width: 100, align: \'left\', sortable" +
": true },\r\n                           { label: \'变形活动阶段\', name: \'DISTORTIONACTIVI" +
"TIESPROGRESS\', index: \'DISTORTIONACTIVITIESPROGRESS\', width: 100, align: \'left\'," +
" sortable: true },\r\n                           { label: \'自然诱因\', name: \'NATURALFA" +
"CTOR\', index: \'NATURALFACTOR\', width: 100, align: \'left\', sortable: true },\r\n   " +
"                        { label: \'损坏房屋（间）\', name: \'DESTROYEDHOUSE\', index: \'DEST" +
"ROYEDHOUSE\', width: 100, align: \'left\', sortable: true },\r\n                     " +
"      { label: \'毁路（米）\', name: \'DESTROYEDROAD\', index: \'DESTROYEDROAD\', width: 10" +
"0, align: \'left\', sortable: true },\r\n                           { label: \'毁渠（米）\'" +
", name: \'DESTROYEDCANAL\', index: \'DESTROYEDCANAL\', width: 100, align: \'left\', so" +
"rtable: true },\r\n                           { label: \'其他危害\', name: \'OTHERHARM\', " +
"index: \'OTHERHARM\', width: 100, align: \'left\', sortable: true },\r\n              " +
"             { label: \'间接损失（万元）\', name: \'INDIRECTLOSS\', index: \'INDIRECTLOSS\', w" +
"idth: 100, align: \'left\', sortable: true },\r\n                           { label:" +
" \'直接损失\', name: \'DIRECTLOSSES\', index: \'DIRECTLOSSES\', width: 100, align: \'left\'," +
" sortable: true },\r\n                           { label: \'危害对象\', name: \'DESTROYED" +
"OBJECT\', index: \'DESTROYEDOBJECT\', width: 100, align: \'left\', sortable: true },\r" +
"\n                           { label: \'诱发灾害类型\', name: \'INDUCEDDAMAGETYPE\', index:" +
" \'INDUCEDDAMAGETYPE\', width: 100, align: \'left\', sortable: true },\r\n            " +
"               { label: \'诱发灾害波及范围\', name: \'INDUCEDDAMAGERANGE\', index: \'INDUCEDD" +
"AMAGERANGE\', width: 100, align: \'left\', sortable: true },\r\n                     " +
"      { label: \'诱发灾害造成损失\', name: \'INDUCEDDAMAGELOSS\', index: \'INDUCEDDAMAGELOSS\'" +
", width: 100, align: \'left\', sortable: true },\r\n                           { lab" +
"el: \'潜在危害威胁对象\', name: \'THREATENOBJECT\', index: \'THREATENOBJECT\', width: 100, ali" +
"gn: \'left\', sortable: true },\r\n                           { label: \'遥感解译点（0：否；1：" +
"是）\', name: \'ISRSPNT\', index: \'ISRSPNT\', width: 100, align: \'left\', sortable: tru" +
"e },\r\n                           { label: \'勘查点（0：否；1：是）\', name: \'ISSURVEYPNT\', i" +
"ndex: \'ISSURVEYPNT\', width: 100, align: \'left\', sortable: true },\r\n             " +
"              { label: \'测绘点（0：否；1：是）\', name: \'ISMEASURINGPNT\', index: \'ISMEASURI" +
"NGPNT\', width: 100, align: \'left\', sortable: true },\r\n                          " +
" { label: \'野外记录信息\', name: \'OUTDOORRECORD\', index: \'OUTDOORRECORD\', width: 100, a" +
"lign: \'left\', sortable: true },\r\n                           { label: \'村\', name: " +
"\'VILLAGE\', index: \'VILLAGE\', width: 100, align: \'left\', sortable: true },\r\n     " +
"                      { label: \'组\', name: \'TEAM\', index: \'TEAM\', width: 100, ali" +
"gn: \'left\', sortable: true },\r\n                           { label: \'群测群防\', name:" +
" \'MASSMONITORING\', index: \'MASSMONITORING\', width: 100, align: \'left\', sortable:" +
" true },\r\n                           { label: \'搬迁避让\', name: \'RELOCATION\', index:" +
" \'RELOCATION\', width: 100, align: \'left\', sortable: true },\r\n                   " +
"        { label: \'专业监测\', name: \'PROFESSIONMONITORING\', index: \'PROFESSIONMONITOR" +
"ING\', width: 100, align: \'left\', sortable: true },\r\n                           {" +
" label: \'工程治理\', name: \'ENGINEERINGMANAGEMENT\', index: \'ENGINEERINGMANAGEMENT\', w" +
"idth: 100, align: \'left\', sortable: true },\r\n                           { label:" +
" \'控滑结构面倾向4\', name: \'SURFACEDIRECTION4\', index: \'SURFACEDIRECTION4\', width: 100, " +
"align: \'left\', sortable: true },\r\n                           { label: \'控滑结构面类型4\'" +
", name: \'SURFACETYPE4\', index: \'SURFACETYPE4\', width: 100, align: \'left\', sortab" +
"le: true },\r\n                           { label: \'控滑结构面倾角4\', name: \'SURFACEANGLE" +
"4\', index: \'SURFACEANGLE4\', width: 100, align: \'left\', sortable: true },\r\n      " +
"                     { label: \'流域\', name: \'RIVERBASIN\', index: \'RIVERBASIN\', wid" +
"th: 100, align: \'left\', sortable: true },\r\n                           { label: \'" +
"失踪人数\', name: \'MISSINGPERSON\', index: \'MISSINGPERSON\', width: 100, align: \'left\'," +
" sortable: true },\r\n                           { label: \'受伤人数\', name: \'INJUREDPE" +
"RSON\', index: \'INJUREDPERSON\', width: 100, align: \'left\', sortable: true },\r\n   " +
"                        { label: \'是否治理工程\', name: \'ISZLGCPNT\', index: \'ISZLGCPNT\'" +
", width: 100, align: \'left\', sortable: true },\r\n                           { lab" +
"el: \'是否有监测点\', name: \'ISMONITORPNT\', index: \'ISMONITORPNT\', width: 100, align: \'l" +
"eft\', sortable: true },\r\n                           { label: \'遥感解译\', name: \'DISA" +
"STERSID\', index: \'DISASTERSID\', width: 100, align: \'left\', sortable: true },\r\n  " +
"                         { label: \'更新人(最近)\', name: \'UPDATEUSER\', index: \'UPDATEU" +
"SER\', width: 100, align: \'left\', sortable: true },\r\n                           {" +
" label: \'群测人员ID\', name: \'MONITORMASSID\', index: \'MONITORMASSID\', width: 100, ali" +
"gn: \'left\', sortable: true },\r\n                           { label: \'村长ID\', name:" +
" \'VILLAGEHEADERID\', index: \'VILLAGEHEADERID\', width: 100, align: \'left\', sortabl" +
"e: true },\r\n                           { label: \'调查负责人ID\', name: \'SURVEYHEADERID" +
"\', index: \'SURVEYHEADERID\', width: 100, align: \'left\', sortable: true },\r\n      " +
"                     { label: \'填表人ID\', name: \'FILLTABLEPEOPLEID\', index: \'FILLTA" +
"BLEPEOPLEID\', width: 100, align: \'left\', sortable: true },\r\n                    " +
"       { label: \'审核人ID\', name: \'VERIFYPEOPLEID\', index: \'VERIFYPEOPLEID\', width:" +
" 100, align: \'left\', sortable: true },\r\n                           { label: \'调查单" +
"位ID\', name: \'SURVEYDEPTID\', index: \'SURVEYDEPTID\', width: 100, align: \'left\', so" +
"rtable: true },\r\n            ],\r\n            viewrecords: true,\r\n            row" +
"Num: 30,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#gridPager\",\r" +
"\n            sortname: \'UNIFIEDCODE\',\r\n            sortorder: \'desc\',\r\n         " +
"   rownumbers: true,\r\n            shrinkToFit: false,\r\n            gridview: tru" +
"e,\r\n            onSelectRow: function () {\r\n                selectedRowIndex = $" +
"(\'#\' + this.id).getGridParam(\'selrow\');\r\n            },\r\n            gridComplet" +
"e: function () {\r\n                $(\'#\' + this.id).setSelection(selectedRowIndex" +
", false);\r\n            }\r\n        });\r\n    }\r\n    //新增\r\n    function btn_add() {" +
"\r\n        dialogOpen({\r\n            id: \'Form\',\r\n            title: \'添加滑坡调查表\',\r\n" +
"            url: \'/JXGeoManage/TBL_LANDSLIP/TBL_LANDSLIPForm\',\r\n            widt" +
"h: \'px\',\r\n            height: \'px\',\r\n            callBack: function (iframeId) {" +
"\r\n                getInfoTop().frames[iframeId].AcceptClick();\r\n            }\r\n " +
"       });\r\n    }\r\n    //编辑\r\n    function btn_edit() {\r\n        var keyValue = $" +
"(\"#gridTable\").jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (checkedRow(keyValue))" +
" {\r\n            dialogOpen({\r\n                id: \'Form\',\r\n                title" +
": \'编辑滑坡调查表\',\r\n                url: \'/JXGeoManage/TBL_LANDSLIP/TBL_LANDSLIPForm?k" +
"eyValue=\' + keyValue,\r\n                width: \'px\',\r\n                height: \'px" +
"\',\r\n                callBack: function (iframeId) {\r\n                    getInfo" +
"Top().frames[iframeId].AcceptClick();\r\n                }\r\n            })\r\n      " +
"  }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n        var keyValue = $(\"#gr" +
"idTable\").jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (keyValue) {\r\n            $" +
".RemoveForm({\r\n                url: \'../../JXGeoManage/TBL_LANDSLIP/RemoveForm\'," +
"\r\n                param: { keyValue: keyValue },\r\n                success: funct" +
"ion (data) {\r\n                    $(\'#gridTable\').trigger(\'reloadGrid\');\r\n      " +
"          }\r\n            })\r\n        } else {\r\n            dialogMsg(\'请选择需要删除的滑坡" +
"调查表！\', 0);\r\n        }\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
