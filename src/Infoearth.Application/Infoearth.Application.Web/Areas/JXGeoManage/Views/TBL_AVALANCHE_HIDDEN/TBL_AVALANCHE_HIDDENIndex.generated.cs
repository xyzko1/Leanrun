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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/JXGeoManage/Views/TBL_AVALANCHE_HIDDEN/TBL_AVALANCHE_HIDDENIndex.cshtml")]
    public partial class _Areas_JXGeoManage_Views_TBL_AVALANCHE_HIDDEN_TBL_AVALANCHE_HIDDENIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_JXGeoManage_Views_TBL_AVALANCHE_HIDDEN_TBL_AVALANCHE_HIDDENIndex_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\JXGeoManage\Views\TBL_AVALANCHE_HIDDEN\TBL_AVALANCHE_HIDDENIndex.cshtml"
  
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

WriteLiteral("></i>查询</a>\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </di" +
"v>\r\n    <div");

WriteLiteral(" class=\"toolbar\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"lr-replace\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"reload()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-refresh\"");

WriteLiteral("></i>&nbsp;刷新</a>\r\n            <a");

WriteLiteral(" id=\"lr-add\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_add()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-plus\"");

WriteLiteral("></i>&nbsp;新增</a>\r\n            <a");

WriteLiteral(" id=\"lr-edit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_edit()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-pencil-square-o\"");

WriteLiteral("></i>&nbsp;编辑</a>\r\n            <a");

WriteLiteral(" id=\"lr-delete\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" onclick=\"btn_delete()\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-trash-o\"");

WriteLiteral("></i>&nbsp;删除</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

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
"age/TBL_AVALANCHE/GetPageListJson\",\r\n            datatype: \"json\",\r\n            " +
"colModel: [\r\n                { label: \'统一编号\', name: \'UNIFIEDCODE\', index: \'UNIFI" +
"EDCODE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: " +
"\'CGH系统灾害点编码\', name: \'CGHUNIFIEDCODE\', index: \'CGHUNIFIEDCODE\', width: 100, align" +
": \'left\',sortable: true  },\r\n                { label: \'名称\', name: \'DISASTERUNITN" +
"AME\', index: \'DISASTERUNITNAME\', width: 100, align: \'left\',sortable: true  },\r\n " +
"               { label: \'野外编号\', name: \'OUTDOORCODE\', index: \'OUTDOORCODE\', width" +
": 100, align: \'left\',sortable: true  },\r\n                { label: \'室内编号\', name: " +
"\'INDOORCODE\', index: \'INDOORCODE\', width: 100, align: \'left\',sortable: true  },\r" +
"\n                { label: \'省\', name: \'PROVINCE\', index: \'PROVINCE\', width: 100, " +
"align: \'left\',sortable: true  },\r\n                { label: \'市（县）\', name: \'CITY\'," +
" index: \'CITY\', width: 100, align: \'left\',sortable: true  },\r\n                { " +
"label: \'乡镇\', name: \'TOWN\', index: \'TOWN\', width: 100, align: \'left\',sortable: tr" +
"ue  },\r\n                { label: \'地理位置\', name: \'LOCATION\', index: \'LOCATION\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'经度\', name:" +
" \'LATITUDE\', index: \'LATITUDE\', width: 100, align: \'left\',sortable: true  },\r\n  " +
"              { label: \'纬度\', name: \'LONGITUDE\', index: \'LONGITUDE\', width: 100, " +
"align: \'left\',sortable: true  },\r\n                { label: \'X坐标\', name: \'X\', ind" +
"ex: \'X\', width: 100, align: \'left\',sortable: true  },\r\n                { label: " +
"\'Y坐标\', name: \'Y\', index: \'Y\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            { label: \'Z坐标\', name: \'Z\', index: \'Z\', width: 100, align: \'left\',sor" +
"table: true  },\r\n                { label: \'坡顶标高\', name: \'ALTTOP\', index: \'ALTTOP" +
"\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'坡脚标高\'" +
", name: \'ALTBOTOM\', index: \'ALTBOTOM\', width: 100, align: \'left\',sortable: true " +
" },\r\n                { label: \'崩塌类型\', name: \'AVALANCHETYPE\', index: \'AVALANCHETY" +
"PE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'地层时" +
"代\', name: \'STRATIGRAPHICTIME\', index: \'STRATIGRAPHICTIME\', width: 100, align: \'l" +
"eft\',sortable: true  },\r\n                { label: \'地层岩性\', name: \'LITHOLOGY\', ind" +
"ex: \'LITHOLOGY\', width: 100, align: \'left\',sortable: true  },\r\n                {" +
" label: \'构造部位\', name: \'TECTONICREGION\', index: \'TECTONICREGION\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'地震烈度\', name: \'EARTHQUAK" +
"EINTENSITY\', index: \'EARTHQUAKEINTENSITY\', width: 100, align: \'left\',sortable: t" +
"rue  },\r\n                { label: \'地层倾向\', name: \'STRATUMDIRECTION\', index: \'STRA" +
"TUMDIRECTION\', width: 100, align: \'left\',sortable: true  },\r\n                { l" +
"abel: \'地层倾角\', name: \'STRATUMANGLE\', index: \'STRATUMANGLE\', width: 100, align: \'l" +
"eft\',sortable: true  },\r\n                { label: \'微地貌\', name: \'MICROTOPOGRAPHY\'" +
", index: \'MICROTOPOGRAPHY\', width: 100, align: \'left\',sortable: true  },\r\n      " +
"          { label: \'地下水类型\', name: \'GROUNDWATERTYPE\', index: \'GROUNDWATERTYPE\', w" +
"idth: 100, align: \'left\',sortable: true  },\r\n                { label: \'年均降雨量\', n" +
"ame: \'AVERAGEYEARRAINFALL\', index: \'AVERAGEYEARRAINFALL\', width: 100, align: \'le" +
"ft\',sortable: true  },\r\n                { label: \'日最大降雨\', name: \'MAXDAYRAINFALL\'" +
", index: \'MAXDAYRAINFALL\', width: 100, align: \'left\',sortable: true  },\r\n       " +
"         { label: \'时最大降雨\', name: \'MAXHOURRAINFALL\', index: \'MAXHOURRAINFALL\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'洪水位\', name" +
": \'MAXWATERLEVEL\', index: \'MAXWATERLEVEL\', width: 100, align: \'left\',sortable: t" +
"rue  },\r\n                { label: \'枯水位\', name: \'MINWATERLEVEL\', index: \'MINWATER" +
"LEVEL\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"相对河流位置\', name: \'POSITIONTORIVER\', index: \'POSITIONTORIVER\', width: 100, align: \'" +
"left\',sortable: true  },\r\n                { label: \'土地利用\', name: \'LANDUSAGE\', in" +
"dex: \'LANDUSAGE\', width: 100, align: \'left\',sortable: true  },\r\n                " +
"{ label: \'坡高\', name: \'SLOPEHEIGHT\', index: \'SLOPEHEIGHT\', width: 100, align: \'le" +
"ft\',sortable: true  },\r\n                { label: \'坡长\', name: \'SLOPELENGTH\', inde" +
"x: \'SLOPELENGTH\', width: 100, align: \'left\',sortable: true  },\r\n                " +
"{ label: \'坡宽\', name: \'SLOPEWIDTH\', index: \'SLOPEWIDTH\', width: 100, align: \'left" +
"\',sortable: true  },\r\n                { label: \'体积（立方米）\', name: \'SCALE\', index: " +
"\'SCALE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: " +
"\'规模等级\', name: \'SCALELEVEL\', index: \'SCALELEVEL\', width: 100, align: \'left\',sorta" +
"ble: true  },\r\n                { label: \'坡度\', name: \'SLOPEANGLE\', index: \'SLOPEA" +
"NGLE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'坡" +
"向\', name: \'SLOPEDIRECTION\', index: \'SLOPEDIRECTION\', width: 100, align: \'left\',s" +
"ortable: true  },\r\n                { label: \'岩体结构类型\', name: \'ROCKARCHTYPE\', inde" +
"x: \'ROCKARCHTYPE\', width: 100, align: \'left\',sortable: true  },\r\n               " +
" { label: \'岩体厚度\', name: \'ROCKDEPTH\', index: \'ROCKDEPTH\', width: 100, align: \'lef" +
"t\',sortable: true  },\r\n                { label: \'岩体裂隙组数\', name: \'FRACTUREGROUPNU" +
"M\', index: \'FRACTUREGROUPNUM\', width: 100, align: \'left\',sortable: true  },\r\n   " +
"             { label: \'岩体块长\', name: \'ROCKLENGTH\', index: \'ROCKLENGTH\', width: 10" +
"0, align: \'left\',sortable: true  },\r\n                { label: \'岩体块宽\', name: \'ROC" +
"KWIDTH\', index: \'ROCKWIDTH\', width: 100, align: \'left\',sortable: true  },\r\n     " +
"           { label: \'岩体块高\', name: \'ROCKHEIGHT\', index: \'ROCKHEIGHT\', width: 100," +
" align: \'left\',sortable: true  },\r\n                { label: \'斜坡结构类型\', name: \'SLO" +
"PEARCHTYPE\', index: \'SLOPEARCHTYPE\', width: 100, align: \'left\',sortable: true  }" +
",\r\n                { label: \'斜坡结构类型-\', name: \'SLOPEASPECTARCHTYPE\', index: \'SLOP" +
"EASPECTARCHTYPE\', width: 100, align: \'left\',sortable: true  },\r\n                " +
"{ label: \'控制结构面类型1\', name: \'CTRLSURFTYPE1\', index: \'CTRLSURFTYPE1\', width: 100, " +
"align: \'left\',sortable: true  },\r\n                { label: \'控制结构面倾向1\', name: \'CT" +
"RLSURFDIRECTION1\', index: \'CTRLSURFDIRECTION1\', width: 100, align: \'left\',sortab" +
"le: true  },\r\n                { label: \'控制结构面倾角1\', name: \'CTRLSURFANGLE1\', index" +
": \'CTRLSURFANGLE1\', width: 100, align: \'left\',sortable: true  },\r\n              " +
"  { label: \'控制结构面长度1\', name: \'CTRLSURFLENGTH1\', index: \'CTRLSURFLENGTH1\', width:" +
" 100, align: \'left\',sortable: true  },\r\n                { label: \'控制结构面间距1\', nam" +
"e: \'CTRLSURFSPACE1\', index: \'CTRLSURFSPACE1\', width: 100, align: \'left\',sortable" +
": true  },\r\n                { label: \'控制结构面类型2\', name: \'CTRLSURFTYPE2\', index: \'" +
"CTRLSURFTYPE2\', width: 100, align: \'left\',sortable: true  },\r\n                { " +
"label: \'控制结构面倾向2\', name: \'CTRLSURFDIRECTION2\', index: \'CTRLSURFDIRECTION2\', widt" +
"h: 100, align: \'left\',sortable: true  },\r\n                { label: \'控制结构面倾角2\', n" +
"ame: \'CTRLSURFANGLE2\', index: \'CTRLSURFANGLE2\', width: 100, align: \'left\',sortab" +
"le: true  },\r\n                { label: \'控制结构面长度2\', name: \'COCTRLSURFLENGTH2\', in" +
"dex: \'COCTRLSURFLENGTH2\', width: 100, align: \'left\',sortable: true  },\r\n        " +
"        { label: \'控制结构面间距2\', name: \'CTRLSURFSPACE2\', index: \'CTRLSURFSPACE2\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'控制结构面类型3\'," +
" name: \'CTRLSURFTYPE3\', index: \'CTRLSURFTYPE3\', width: 100, align: \'left\',sortab" +
"le: true  },\r\n                { label: \'控制结构面倾向3\', name: \'CTRLSURFDIRECTION3\', i" +
"ndex: \'CTRLSURFDIRECTION3\', width: 100, align: \'left\',sortable: true  },\r\n      " +
"          { label: \'控制结构面倾角3\', name: \'CTRLSURFANGLE3\', index: \'CTRLSURFANGLE3\', " +
"width: 100, align: \'left\',sortable: true  },\r\n                { label: \'控制结构面长度3" +
"\', name: \'CTRLSURFLENGTH3\', index: \'CTRLSURFLENGTH3\', width: 100, align: \'left\'," +
"sortable: true  },\r\n                { label: \'控制结构面间距3\', name: \'CTRLSURFSPACE3\'," +
" index: \'CTRLSURFSPACE3\', width: 100, align: \'left\',sortable: true  },\r\n        " +
"        { label: \'全风化带深度(M)\', name: \'WEATHEREDZONEDEPTH\', index: \'WEATHEREDZONED" +
"EPTH\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'卸" +
"荷裂缝深度(M)\', name: \'UNLOADCRACKDEPTH\', index: \'UNLOADCRACKDEPTH\', width: 100, alig" +
"n: \'left\',sortable: true  },\r\n                { label: \'土体名称\', name: \'SOILTEXTUR" +
"ENAME\', index: \'SOILTEXTURENAME\', width: 100, align: \'left\',sortable: true  },\r\n" +
"                { label: \'土地密实度\', name: \'SOILDENSITYDEGREE\', index: \'SOILDENSITY" +
"DEGREE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: " +
"\'土地稠度\', name: \'SOILCONSISTENCY\', index: \'SOILCONSISTENCY\', width: 100, align: \'l" +
"eft\',sortable: true  },\r\n                { label: \'下伏基岩时代\', name: \'BEDROCKTIME\'," +
" index: \'BEDROCKTIME\', width: 100, align: \'left\',sortable: true  },\r\n           " +
"     { label: \'下伏基岩岩性\', name: \'BEDROCKLITHOLOGY\', index: \'BEDROCKLITHOLOGY\', wid" +
"th: 100, align: \'left\',sortable: true  },\r\n                { label: \'下伏基岩倾角\', na" +
"me: \'BEDROCKANGLE\', index: \'BEDROCKANGLE\', width: 100, align: \'left\',sortable: t" +
"rue  },\r\n                { label: \'下伏基岩倾向\', name: \'BEDROCKDIRECTION\', index: \'BE" +
"DROCKDIRECTION\', width: 100, align: \'left\',sortable: true  },\r\n                {" +
" label: \'下伏基岩埋深(M)\', name: \'BEDROCKDEPTH\', index: \'BEDROCKDEPTH\', width: 100, al" +
"ign: \'left\',sortable: true  },\r\n                { label: \'变形迹象名称1\', name: \'DISTO" +
"RTIONSIGN1\', index: \'DISTORTIONSIGN1\', width: 100, align: \'left\',sortable: true " +
" },\r\n                { label: \'变形迹象部位1\', name: \'DISTORTIONPLACE1\', index: \'DISTO" +
"RTIONPLACE1\', width: 100, align: \'left\',sortable: true  },\r\n                { la" +
"bel: \'变形迹象特征1\', name: \'DISTORTIONCHARACTER1\', index: \'DISTORTIONCHARACTER1\', wid" +
"th: 100, align: \'left\',sortable: true  },\r\n                { label: \'变形迹象初现时间1\'," +
" name: \'DISTORTIONINITDATE1\', index: \'DISTORTIONINITDATE1\', width: 100, align: \'" +
"left\',sortable: true  },\r\n                { label: \'变形迹象名称2\', name: \'DISTORTIONS" +
"IGN2\', index: \'DISTORTIONSIGN2\', width: 100, align: \'left\',sortable: true  },\r\n " +
"               { label: \'变形迹象部位2\', name: \'DISTORTIONPLACE2\', index: \'DISTORTIONP" +
"LACE2\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"变形迹象特征2\', name: \'DISTORTIONCHARACTER2\', index: \'DISTORTIONCHARACTER2\', width: 10" +
"0, align: \'left\',sortable: true  },\r\n                { label: \'变形迹象初现时间2\', name:" +
" \'DISTORTIONINITDATE2\', index: \'DISTORTIONINITDATE2\', width: 100, align: \'left\'," +
"sortable: true  },\r\n                { label: \'变形迹象名称3\', name: \'DISTORTIONSIGN3\'," +
" index: \'DISTORTIONSIGN3\', width: 100, align: \'left\',sortable: true  },\r\n       " +
"         { label: \'变形迹象部位3\', name: \'DISTORTIONPLACE3\', index: \'DISTORTIONPLACE3\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'变形迹象特征" +
"3\', name: \'DISTORTIONCHARACTER3\', index: \'DISTORTIONCHARACTER3\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'变形迹象初现时间3\', name: \'DIST" +
"ORTIONINITDATE3\', index: \'DISTORTIONINITDATE3\', width: 100, align: \'left\',sortab" +
"le: true  },\r\n                { label: \'变形迹象名称4\', name: \'DISTORTIONSIGN4\', index" +
": \'DISTORTIONSIGN4\', width: 100, align: \'left\',sortable: true  },\r\n             " +
"   { label: \'变形迹象部位4\', name: \'DISTORTIONPLACE4\', index: \'DISTORTIONPLACE4\', widt" +
"h: 100, align: \'left\',sortable: true  },\r\n                { label: \'变形迹象特征4\', na" +
"me: \'DISTORTIONCHARACTER4\', index: \'DISTORTIONCHARACTER4\', width: 100, align: \'l" +
"eft\',sortable: true  },\r\n                { label: \'变形迹象初现时间4\', name: \'DISTORTION" +
"INITDATE4\', index: \'DISTORTIONINITDATE4\', width: 100, align: \'left\',sortable: tr" +
"ue  },\r\n                { label: \'变形迹象名称5\', name: \'DISTORTIONSIGN5\', index: \'DIS" +
"TORTIONSIGN5\', width: 100, align: \'left\',sortable: true  },\r\n                { l" +
"abel: \'变形迹象部位5\', name: \'DISTORTIONPLACE5\', index: \'DISTORTIONPLACE5\', width: 100" +
", align: \'left\',sortable: true  },\r\n                { label: \'变形迹象特征5\', name: \'D" +
"ISTORTIONCHARACTER5\', index: \'DISTORTIONCHARACTER5\', width: 100, align: \'left\',s" +
"ortable: true  },\r\n                { label: \'变形迹象初现时间5\', name: \'DISTORTIONINITDA" +
"TE5\', index: \'DISTORTIONINITDATE5\', width: 100, align: \'left\',sortable: true  }," +
"\r\n                { label: \'变形迹象名称6\', name: \'DISTORTIONSIGN6\', index: \'DISTORTIO" +
"NSIGN6\', width: 100, align: \'left\',sortable: true  },\r\n                { label: " +
"\'变形迹象部位6\', name: \'DISTORTIONPLACE6\', index: \'DISTORTIONPLACE6\', width: 100, alig" +
"n: \'left\',sortable: true  },\r\n                { label: \'变形迹象特征6\', name: \'DISTORT" +
"IONCHARACTER6\', index: \'DISTORTIONCHARACTER6\', width: 100, align: \'left\',sortabl" +
"e: true  },\r\n                { label: \'变形迹象初现时间6\', name: \'DISTORTIONINITDATE6\', " +
"index: \'DISTORTIONINITDATE6\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            { label: \'变形迹象名称7\', name: \'DISTORTIONSIGN7\', index: \'DISTORTIONSIGN7" +
"\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'变形迹象部" +
"位7\', name: \'DISTORTIONPLACE7\', index: \'DISTORTIONPLACE7\', width: 100, align: \'le" +
"ft\',sortable: true  },\r\n                { label: \'变形迹象特征7\', name: \'DISTORTIONCHA" +
"RACTER7\', index: \'DISTORTIONCHARACTER7\', width: 100, align: \'left\',sortable: tru" +
"e  },\r\n                { label: \'变形迹象初现时间7\', name: \'DISTORTIONINITDATE7\', index:" +
" \'DISTORTIONINITDATE7\', width: 100, align: \'left\',sortable: true  },\r\n          " +
"      { label: \'变形迹象名称8\', name: \'DISTORTIONSIGN8\', index: \'DISTORTIONSIGN8\', wid" +
"th: 100, align: \'left\',sortable: true  },\r\n                { label: \'变形迹象部位8\', n" +
"ame: \'DISTORTIONPLACE8\', index: \'DISTORTIONPLACE8\', width: 100, align: \'left\',so" +
"rtable: true  },\r\n                { label: \'变形迹象特征8\', name: \'DISTORTIONCHARACTER" +
"8\', index: \'DISTORTIONCHARACTER8\', width: 100, align: \'left\',sortable: true  },\r" +
"\n                { label: \'变形迹象初现时间8\', name: \'DISTORTIONINITDATE8\', index: \'DIST" +
"ORTIONINITDATE8\', width: 100, align: \'left\',sortable: true  },\r\n                " +
"{ label: \'危岩体可能失稳因素\', name: \'DANGERROCKASTABLEFACTOR\', index: \'DANGERROCKASTABLE" +
"FACTOR\', width: 100, align: \'left\',sortable: true  },\r\n                { label: " +
"\'危岩体目前稳定程度\', name: \'DANGERROCKSTABLESTATUS\', index: \'DANGERROCKSTABLESTATUS\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'危岩体今后变化趋势\'" +
", name: \'DANGERROCKSTABLETREND\', index: \'DANGERROCKSTABLETREND\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'地下水埋深(M)\', name: \'GROUN" +
"DWATERDEPTH\', index: \'GROUNDWATERDEPTH\', width: 100, align: \'left\',sortable: tru" +
"e  },\r\n                { label: \'地下水露头\', name: \'GROUNDWATEROUTCROP\', index: \'GRO" +
"UNDWATEROUTCROP\', width: 100, align: \'left\',sortable: true  },\r\n                " +
"{ label: \'地下水补给类型\', name: \'GROUNDWATERSUPPLYTYPE\', index: \'GROUNDWATERSUPPLYTYPE" +
"\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'堆积体长度" +
"\', name: \'ACCUMULATIONBODYLENGTH\', index: \'ACCUMULATIONBODYLENGTH\', width: 100, " +
"align: \'left\',sortable: true  },\r\n                { label: \'堆积体宽度\', name: \'ACCUM" +
"ULATIONBODYWIDTH\', index: \'ACCUMULATIONBODYWIDTH\', width: 100, align: \'left\',sor" +
"table: true  },\r\n                { label: \'堆积体厚度\', name: \'ACCUMULATIONBODYDEPTH\'" +
", index: \'ACCUMULATIONBODYDEPTH\', width: 100, align: \'left\',sortable: true  },\r\n" +
"                { label: \'堆积体体积\', name: \'ACCUMULATIONBODYVOLUME\', index: \'ACCUMU" +
"LATIONBODYVOLUME\', width: 100, align: \'left\',sortable: true  },\r\n               " +
" { label: \'堆积体坡度\', name: \'ACCUMULATIONBODYANGLE\', index: \'ACCUMULATIONBODYANGLE\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'堆积体坡向\'" +
", name: \'ACCUMULATIONBODYDIRECTION\', index: \'ACCUMULATIONBODYDIRECTION\', width: " +
"100, align: \'left\',sortable: true  },\r\n                { label: \'堆积体坡面形态\', name:" +
" \'ACCUMULATIONBODYFLATSHAPE\', index: \'ACCUMULATIONBODYFLATSHAPE\', width: 100, al" +
"ign: \'left\',sortable: true  },\r\n                { label: \'堆积体稳定性\', name: \'ACCUMU" +
"LATIONBODYSTABILITY\', index: \'ACCUMULATIONBODYSTABILITY\', width: 100, align: \'le" +
"ft\',sortable: true  },\r\n                { label: \'堆积体可能失稳因素\', name: \'ACCUMULATIO" +
"NBODYASTABLEFACTOR\', index: \'ACCUMULATIONBODYASTABLEFACTOR\', width: 100, align: " +
"\'left\',sortable: true  },\r\n                { label: \'堆积体目前稳定状态\', name: \'ACCUMULA" +
"TIONBODYSTABLESTATUS\', index: \'ACCUMULATIONBODYSTABLESTATUS\', width: 100, align:" +
" \'left\',sortable: true  },\r\n                { label: \'堆积体今后变化趋势\', name: \'ACCUMUL" +
"ATIONBODYSTABLETREND\', index: \'ACCUMULATIONBODYSTABLETREND\', width: 100, align: " +
"\'left\',sortable: true  },\r\n                { label: \'隐患点\', name: \'HIDDENDANGER\'," +
" index: \'HIDDENDANGER\', width: 100, align: \'left\',sortable: true  },\r\n          " +
"      { label: \'防灾预案\', name: \'PREVENTIONPLAN\', index: \'PREVENTIONPLAN\', width: 1" +
"00, align: \'left\',sortable: true  },\r\n                { label: \'死亡人口\', name: \'DE" +
"ATHSPEOPLE\', index: \'DEATHSPEOPLE\', width: 100, align: \'left\',sortable: true  }," +
"\r\n                { label: \'毁坏房屋\', name: \'DESTROYEDHOME\', index: \'DESTROYEDHOME\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'毁路\', n" +
"ame: \'DESTROYEDROAD\', index: \'DESTROYEDROAD\', width: 100, align: \'left\',sortable" +
": true  },\r\n                { label: \'毁渠\', name: \'DESTROYEDCHANNEL\', index: \'DES" +
"TROYEDCHANNEL\', width: 100, align: \'left\',sortable: true  },\r\n                { " +
"label: \'其它危害\', name: \'DESTROYEDOTHERS\', index: \'DESTROYEDOTHERS\', width: 100, al" +
"ign: \'left\',sortable: true  },\r\n                { label: \'直接损失\', name: \'DIRECTLO" +
"SS\', index: \'DIRECTLOSS\', width: 100, align: \'left\',sortable: true  },\r\n        " +
"        { label: \'灾情等级\', name: \'DISASTERLEVEL\', index: \'DISASTERLEVEL\', width: 1" +
"00, align: \'left\',sortable: true  },\r\n                { label: \'威胁人口\', name: \'TH" +
"REATENPEOPLE\', index: \'THREATENPEOPLE\', width: 100, align: \'left\',sortable: true" +
"  },\r\n                { label: \'威胁财产\', name: \'THREATENASSETS\', index: \'THREATENA" +
"SSETS\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"险情等级\', name: \'DANGERLEVEL\', index: \'DANGERLEVEL\', width: 100, align: \'left\',sort" +
"able: true  },\r\n                { label: \'监测建议\', name: \'MONITORSUGGESTION\', inde" +
"x: \'MONITORSUGGESTION\', width: 100, align: \'left\',sortable: true  },\r\n          " +
"      { label: \'防治建议\', name: \'TREATMENTSUGGESTION\', index: \'TREATMENTSUGGESTION\'" +
", width: 100, align: \'left\',sortable: true  },\r\n                { label: \'群测人员\'," +
" name: \'MONITORMASS\', index: \'MONITORMASS\', width: 100, align: \'left\',sortable: " +
"true  },\r\n                { label: \'村长\', name: \'VILLAGEHEADER\', index: \'VILLAGEH" +
"EADER\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"电话\', name: \'PHONE\', index: \'PHONE\', width: 100, align: \'left\',sortable: true  }," +
"\r\n                { label: \'调查负责人\', name: \'SURVEYHEADER\', index: \'SURVEYHEADER\'," +
" width: 100, align: \'left\',sortable: true  },\r\n                { label: \'填表人\', n" +
"ame: \'FILLTABLEPEOPLE\', index: \'FILLTABLEPEOPLE\', width: 100, align: \'left\',sort" +
"able: true  },\r\n                { label: \'审核人\', name: \'VERIFYPEOPLE\', index: \'VE" +
"RIFYPEOPLE\', width: 100, align: \'left\',sortable: true  },\r\n                { lab" +
"el: \'调查单位\', name: \'SURVEYDEPT\', index: \'SURVEYDEPT\', width: 100, align: \'left\',s" +
"ortable: true  },\r\n                { label: \'填表日期\', name: \'FILLTABLEDATE\', index" +
": \'FILLTABLEDATE\', width: 100, align: \'left\',sortable: true  },\r\n               " +
" { label: \'发生时间\', name: \'HAPPENSTIME\', index: \'HAPPENSTIME\', width: 100, align: " +
"\'left\',sortable: true  },\r\n                { label: \'更新时间\', name: \'UPDATETIME\', " +
"index: \'UPDATETIME\', width: 100, align: \'left\',sortable: true  },\r\n             " +
"   { label: \'记录状态\', name: \'RECORDSTATUS\', index: \'RECORDSTATUS\', width: 100, ali" +
"gn: \'left\',sortable: true  },\r\n                { label: \'导出状态\', name: \'EXPSTATUS" +
"\', index: \'EXPSTATUS\', width: 100, align: \'left\',sortable: true  },\r\n           " +
"     { label: \'防灾情况\', name: \'CONTROLSTATE\', index: \'CONTROLSTATE\', width: 100, a" +
"lign: \'left\',sortable: true  },\r\n                { label: \'创建者ID\', name: \'CREATO" +
"RUSERID\', index: \'CREATORUSERID\', width: 100, align: \'left\',sortable: true  },\r\n" +
"                { label: \'创建时间\', name: \'CREATORTIME\', index: \'CREATORTIME\', widt" +
"h: 100, align: \'left\',sortable: true  },\r\n                { label: \'更新者ID\', name" +
": \'UPDATEUSERID\', index: \'UPDATEUSERID\', width: 100, align: \'left\',sortable: tru" +
"e  },\r\n                { label: \'更新次数\', name: \'UPDATETIMES\', index: \'UPDATETIMES" +
"\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'崩塌情况\'" +
", name: \'AVALANCHEDESC\', index: \'AVALANCHEDESC\', width: 100, align: \'left\',sorta" +
"ble: true  },\r\n                { label: \'项目编号\', name: \'PROJECTID\', index: \'PROJE" +
"CTID\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'图" +
"幅编号\', name: \'MAPID\', index: \'MAPID\', width: 100, align: \'left\',sortable: true  }" +
",\r\n                { label: \'图幅名称\', name: \'MAPNAME\', index: \'MAPNAME\', width: 10" +
"0, align: \'left\',sortable: true  },\r\n                { label: \'县市编号\', name: \'COU" +
"NTYCODE\', index: \'COUNTYCODE\', width: 100, align: \'left\',sortable: true  },\r\n   " +
"             { label: \'分布高程（米）\', name: \'DISTRIBUTEALTITUDE\', index: \'DISTRIBUTEA" +
"LTITUDE\', width: 100, align: \'left\',sortable: true  },\r\n                { label:" +
" \'厚度(米)\', name: \'DEPTH\', index: \'DEPTH\', width: 100, align: \'left\',sortable: tru" +
"e  },\r\n                { label: \'变形发育史形成时间\', name: \'DISTORTIONFORMDATE\', index: " +
"\'DISTORTIONFORMDATE\', width: 100, align: \'left\',sortable: true  },\r\n            " +
"    { label: \'发生崩塌次数\', name: \'AVALANCHETIMES\', index: \'AVALANCHETIMES\', width: 1" +
"00, align: \'left\',sortable: true  },\r\n                { label: \'变形发育史序号1\', name:" +
" \'AVALANCHENO1\', index: \'AVALANCHENO1\', width: 100, align: \'left\',sortable: true" +
"  },\r\n                { label: \'发生时间1\', name: \'OCCURREDTIME1\', index: \'OCCURREDT" +
"IME1\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'崩" +
"塌规模1（立方米）\', name: \'OCCURREDVOLUME1\', index: \'OCCURREDVOLUME1\', width: 100, align" +
": \'left\',sortable: true  },\r\n                { label: \'崩塌诱发因素1\', name: \'INDUCEDF" +
"ACTOR1\', index: \'INDUCEDFACTOR1\', width: 100, align: \'left\',sortable: true  },\r\n" +
"                { label: \'死亡人数1\', name: \'DEATHPEOPLE1\', index: \'DEATHPEOPLE1\', w" +
"idth: 100, align: \'left\',sortable: true  },\r\n                { label: \'崩塌直接经济损失1" +
"\', name: \'DIRECTLOSS1\', index: \'DIRECTLOSS1\', width: 100, align: \'left\',sortable" +
": true  },\r\n                { label: \'变形发育史序号2\', name: \'AVALANCHENO2\', index: \'A" +
"VALANCHENO2\', width: 100, align: \'left\',sortable: true  },\r\n                { la" +
"bel: \'发生时间2\', name: \'OCCURREDTIME2\', index: \'OCCURREDTIME2\', width: 100, align: " +
"\'left\',sortable: true  },\r\n                { label: \'崩塌规模2（立方米）\', name: \'OCCURRE" +
"DVOLUME2\', index: \'OCCURREDVOLUME2\', width: 100, align: \'left\',sortable: true  }" +
",\r\n                { label: \'崩塌诱发因素2\', name: \'INDUCEDFACTOR2\', index: \'INDUCEDFA" +
"CTOR2\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"死亡人数2\', name: \'DEATHPEOPLE2\', index: \'DEATHPEOPLE2\', width: 100, align: \'left\',s" +
"ortable: true  },\r\n                { label: \'崩塌直接经济损失2\', name: \'DIRECTLOSS2\', in" +
"dex: \'DIRECTLOSS2\', width: 100, align: \'left\',sortable: true  },\r\n              " +
"  { label: \'变形发育史序号3\', name: \'AVALANCHENO3\', index: \'AVALANCHENO3\', width: 100, " +
"align: \'left\',sortable: true  },\r\n                { label: \'发生时间3\', name: \'OCCUR" +
"REDTIME3\', index: \'OCCURREDTIME3\', width: 100, align: \'left\',sortable: true  },\r" +
"\n                { label: \'崩塌规模3（立方米）\', name: \'OCCURREDVOLUME3\', index: \'OCCURRE" +
"DVOLUME3\', width: 100, align: \'left\',sortable: true  },\r\n                { label" +
": \'崩塌诱发因素3\', name: \'INDUCEDFACTOR3\', index: \'INDUCEDFACTOR3\', width: 100, align:" +
" \'left\',sortable: true  },\r\n                { label: \'死亡人数3\', name: \'DEATHPEOPLE" +
"3\', index: \'DEATHPEOPLE3\', width: 100, align: \'left\',sortable: true  },\r\n       " +
"         { label: \'崩塌直接经济损失3\', name: \'DIRECTLOSS3\', index: \'DIRECTLOSS3\', width:" +
" 100, align: \'left\',sortable: true  },\r\n                { label: \'损坏房屋（间）\', name" +
": \'DESTROYEDHOUSE\', index: \'DESTROYEDHOUSE\', width: 100, align: \'left\',sortable:" +
" true  },\r\n                { label: \'威胁房屋（户）\', name: \'THREATENHOME\', index: \'THR" +
"EATENHOME\', width: 100, align: \'left\',sortable: true  },\r\n                { labe" +
"l: \'间接损失（万元）\', name: \'INDIRECTLOSS\', index: \'INDIRECTLOSS\', width: 100, align: \'" +
"left\',sortable: true  },\r\n                { label: \'危害对象\', name: \'DESTROYEDOBJEC" +
"T\', index: \'DESTROYEDOBJECT\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            { label: \'诱发灾害类型\', name: \'INDUCEDDAMAGETYPE\', index: \'INDUCEDDAMAGET" +
"YPE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'诱发" +
"灾害波及范围\', name: \'INDUCEDDAMAGERANGE\', index: \'INDUCEDDAMAGERANGE\', width: 100, al" +
"ign: \'left\',sortable: true  },\r\n                { label: \'诱发灾害造成损失\', name: \'INDU" +
"CEDDAMAGELOSS\', index: \'INDUCEDDAMAGELOSS\', width: 100, align: \'left\',sortable: " +
"true  },\r\n                { label: \'潜在危害威胁对象\', name: \'THREATENOBJECT\', index: \'T" +
"HREATENOBJECT\', width: 100, align: \'left\',sortable: true  },\r\n                { " +
"label: \'遥感解译点（0：否；1：是）\', name: \'ISRSPNT\', index: \'ISRSPNT\', width: 100, align: \'" +
"left\',sortable: true  },\r\n                { label: \'勘查点（0：否；1：是）\', name: \'ISSURV" +
"EYPNT\', index: \'ISSURVEYPNT\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            { label: \'测绘点（0：否；1：是）\', name: \'ISMEASURINGPNT\', index: \'ISMEASURING" +
"PNT\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'野外" +
"记录信息\', name: \'OUTDOORRECORD\', index: \'OUTDOORRECORD\', width: 100, align: \'left\'," +
"sortable: true  },\r\n                { label: \'村\', name: \'VILLAGE\', index: \'VILLA" +
"GE\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'组\'," +
" name: \'TEAM\', index: \'TEAM\', width: 100, align: \'left\',sortable: true  },\r\n    " +
"            { label: \'群测群防\', name: \'MASSMONITORING\', index: \'MASSMONITORING\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'搬迁避让\', nam" +
"e: \'RELOCATION\', index: \'RELOCATION\', width: 100, align: \'left\',sortable: true  " +
"},\r\n                { label: \'专业监测\', name: \'PROFESSIONMONITORING\', index: \'PROFE" +
"SSIONMONITORING\', width: 100, align: \'left\',sortable: true  },\r\n                " +
"{ label: \'工程治理\', name: \'ENGINEERINGMANAGEMENT\', index: \'ENGINEERINGMANAGEMENT\', " +
"width: 100, align: \'left\',sortable: true  },\r\n                { label: \'斜坡类型\', n" +
"ame: \'SLOPETYPE\', index: \'SLOPETYPE\', width: 100, align: \'left\',sortable: true  " +
"},\r\n                { label: \'流域\', name: \'RIVERBASIN\', index: \'RIVERBASIN\', widt" +
"h: 100, align: \'left\',sortable: true  },\r\n                { label: \'失踪人数\', name:" +
" \'MISSINGPERSON\', index: \'MISSINGPERSON\', width: 100, align: \'left\',sortable: tr" +
"ue  },\r\n                { label: \'受伤人数\', name: \'INJUREDPERSON\', index: \'INJUREDP" +
"ERSON\', width: 100, align: \'left\',sortable: true  },\r\n                { label: \'" +
"是否治理工程\', name: \'ISZLGCPNT\', index: \'ISZLGCPNT\', width: 100, align: \'left\',sortab" +
"le: true  },\r\n                { label: \'是否有监测点\', name: \'ISMONITORPNT\', index: \'I" +
"SMONITORPNT\', width: 100, align: \'left\',sortable: true  },\r\n                { la" +
"bel: \'遥感解译\', name: \'DISASTERSID\', index: \'DISASTERSID\', width: 100, align: \'left" +
"\',sortable: true  },\r\n                { label: \'更新人(最近)\', name: \'UPDATEUSER\', in" +
"dex: \'UPDATEUSER\', width: 100, align: \'left\',sortable: true  },\r\n               " +
" { label: \'调查负责人ID\', name: \'SURVEYHEADERID\', index: \'SURVEYHEADERID\', width: 100" +
", align: \'left\',sortable: true  },\r\n                { label: \'填表人ID\', name: \'FIL" +
"LTABLEPEOPLEID\', index: \'FILLTABLEPEOPLEID\', width: 100, align: \'left\',sortable:" +
" true  },\r\n                { label: \'审核人ID\', name: \'VERIFYPEOPLEID\', index: \'VER" +
"IFYPEOPLEID\', width: 100, align: \'left\',sortable: true  },\r\n                { la" +
"bel: \'群测人员ID\', name: \'MONITORMASSID\', index: \'MONITORMASSID\', width: 100, align:" +
" \'left\',sortable: true  },\r\n                { label: \'村长ID\', name: \'VILLAGEHEADE" +
"RID\', index: \'VILLAGEHEADERID\', width: 100, align: \'left\',sortable: true  },\r\n  " +
"              { label: \'调查单位ID\', name: \'SURVEYDEPTID\', index: \'SURVEYDEPTID\', wi" +
"dth: 100, align: \'left\',sortable: true  },\r\n                { label: \'CTRLSURFLE" +
"NGTH2\', name: \'CTRLSURFLENGTH2\', index: \'CTRLSURFLENGTH2\', width: 100, align: \'c" +
"enter\',sortable: true  },\r\n            ],\r\n            viewrecords: true,\r\n     " +
"       rowNum: 30,\r\n            rowList: [30, 50, 100],\r\n            pager: \"#gr" +
"idPager\",\r\n            sortname: \'UNIFIEDCODE\',\r\n            sortorder: \'desc\',\r" +
"\n            rownumbers: true,\r\n            shrinkToFit: false,\r\n            gri" +
"dview: true,\r\n            onSelectRow: function () {\r\n                selectedRo" +
"wIndex = $(\'#\' + this.id).getGridParam(\'selrow\');\r\n            },\r\n            g" +
"ridComplete: function () {\r\n                $(\'#\' + this.id).setSelection(select" +
"edRowIndex, false);\r\n            }\r\n        });\r\n    }\r\n    //新增\r\n    function b" +
"tn_add() {\r\n        dialogOpen({\r\n            id: \'Form\',\r\n            title: \'添" +
"加崩塌调查表\',\r\n            url: \'/JXGeoManage/TBL_AVALANCHE/TBL_AVALANCHEForm\',\r\n    " +
"        width: \'px\',\r\n            height: \'px\',\r\n            callBack: function " +
"(iframeId) {\r\n                getInfoTop().frames[iframeId].AcceptClick();\r\n    " +
"        }\r\n        });\r\n    }\r\n    //编辑\r\n    function btn_edit() {\r\n        var " +
"keyValue = $(\"#gridTable\").jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (checkedRo" +
"w(keyValue)) {\r\n            dialogOpen({\r\n                id: \'Form\',\r\n         " +
"       title: \'编辑崩塌调查表\',\r\n                url: \'/JXGeoManage/TBL_AVALANCHE/TBL_A" +
"VALANCHEForm?keyValue=\' + keyValue,\r\n                width: \'px\',\r\n             " +
"   height: \'px\',\r\n                callBack: function (iframeId) {\r\n             " +
"       getInfoTop().frames[iframeId].AcceptClick();\r\n                }\r\n        " +
"    })\r\n        }\r\n    }\r\n    //删除\r\n    function btn_delete() {\r\n        var key" +
"Value = $(\"#gridTable\").jqGridRowValue(\'UNIFIEDCODE\');\r\n        if (keyValue) {\r" +
"\n            $.RemoveForm({\r\n                url: \'../../JXGeoManage/TBL_AVALANC" +
"HE/RemoveForm\',\r\n                param: { keyValue: keyValue },\r\n               " +
" success: function (data) {\r\n                    $(\'#gridTable\').trigger(\'reload" +
"Grid\');\r\n                }\r\n            })\r\n        } else {\r\n            dialog" +
"Msg(\'请选择需要删除的崩塌调查表！\', 0);\r\n        }\r\n    }\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
