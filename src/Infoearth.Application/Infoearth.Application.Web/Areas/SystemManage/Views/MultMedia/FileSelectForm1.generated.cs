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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/SystemManage/Views/MultMedia/FileSelectForm.cshtml")]
    public partial class _Areas_SystemManage_Views_MultMedia_FileSelectForm_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_SystemManage_Views_MultMedia_FileSelectForm_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
  
    ViewBag.Title = "文件管理";
    Layout = "~/Views/Shared/_Form.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 5 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
Write(System.Web.Optimization.Styles.Render("~/Content/scripts/plugins/webuploader/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
Write(System.Web.Optimization.Styles.Render(
    "~/Content/scripts/plugins/jqgrid/css"
   ));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

            
            #line 10 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
Write(System.Web.Optimization.Scripts.Render(
    "~/Content/scripts/plugins/jqgrid/js"
    ));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 13 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/Content/scripts/plugins/webuploader/js"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<script>\r\n    var selectFileData = [];\r\n    $(function () {\r\n        // Initial" +
"Page(); \r\n\r\n        //查询条件 \r\n        $(\"#FileType .dropdown-menu li\").click(func" +
"tion () {\r\n            var text = $(this).find(\'a\').html();\r\n            var val" +
"ue = $(this).find(\'a\').attr(\'data-value\');\r\n            $(\"#FileType .dropdown-t" +
"ext\").html(text).attr(\'data-value\', value)\r\n        });\r\n        GetGrid();\r\n   " +
"     uploadify();\r\n \r\n         \r\n        //$(\'#gridTable\').setGridWidth(($(\'.gri" +
"dPanel\').width()));\r\n        //$(\"#gridTable\").setGridHeight($(window).height() " +
"- 137);\r\n        //$(\'.profile-nav\').height($(window).height() - 20);\r\n        /" +
"/$(\'.profile-content\').height($(window).height() - 20); \r\n        \r\n       $(\".u" +
"pload-info\").click(function () { \r\n           if ($(this).next(\'.upload-history\'" +
").is(\":hidden\")) {\r\n               $(this).css(\'border-bottom-color\', \'#fff\'); \r" +
"\n               $(this).next(\".upload-history\").slideDown(10);\r\n               $" +
"(this).addClass(\"active\")\r\n           } else {\r\n               $(this).css(\'bord" +
"er-bottom-color\', \'#ccc\');\r\n               $(this).next(\".upload-history\").slide" +
"Up(10);\r\n               $(this).removeClass(\"active\")\r\n           }\r\n       });\r" +
"\n    });\r\n   \r\n    //加载表格\r\n    function GetGrid() {\r\n        var queryJson = $(\"" +
"#filter-form\").getWebControls();\r\n        queryJson[\"FileType\"] = \"\";\r\n        v" +
"ar $gridTable = $(\"#gridTable\");\r\n        $gridTable.jqGrid({\r\n            url: " +
"\"../../SystemManage/MultMedia/FindFileInfos\",\r\n            postData: { queryJson" +
": JSON.stringify(queryJson) },\r\n            datatype: \"json\",\r\n            heigh" +
"t: $(window).height() - 120,\r\n            autowidth: true,\r\n            colModel" +
": [\r\n                { label: \"主键\", name: \"GUID\", hidden: true },\r\n             " +
"  \r\n                { label: \"文件名\", name: \"FILENAME\", index: \"FILENAME\", width: " +
"150, align: \"left\",sortable:true },\r\n                { label: \"文件描述\", name: \"FIL" +
"EDESC\", index: \"FILEDESC\", width: 150, align: \"left\", sortable: false },\r\n      " +
"          { label: \"创建人\", name: \"CREATOR\", index: \"CREATOR\", width: 150, align: " +
"\"left\", sortable: false },\r\n               \r\n                {\r\n                " +
"    label: \"创建日期\", name: \"CREATEDDATE\", index: \"CREATEDDATE\", width: 150, align:" +
" \"left\",sortable:true,\r\n                    formatter: function (cellvalue, opti" +
"ons, rowObject) {\r\n                        return learun.formatDate(cellvalue, \'" +
"yyyy-MM-dd hh:mm:ss\');\r\n                    }\r\n                },\r\n             " +
"   {\r\n                    label: \"操作\", name: \"OPERATE\", index: \"OPERATE\", width:" +
" 100, align: \"center\", sortable: false,\r\n                    formatter: function" +
" (cellvalue, options, rowObject) {\r\n                        var guid = rowObject" +
".GUID;\r\n                        return \'<a class=\"btn btn-danger\" id=\"\' + guid +" +
" \'\" onclick=\"removeFile(this)\">删除</a>\';\r\n                    }\r\n                " +
"}\r\n            ],\r\n            viewrecords: true,\r\n            rowNum: 30,\r\n    " +
"        rowList: [30, 50, 100, 500, 1000],\r\n            pager: \"#gridPager\",\r\n  " +
"          sortname: \'CREATEDDATE desc\',\r\n            rownumbers: true,\r\n        " +
"    shrinkToFit: false,\r\n            multiselect: true,\r\n            gridview: t" +
"rue,\r\n            onSelectRow: function (rowid, status) {\r\n                var d" +
"t = $gridTable.jqGrid(\'getRowData\', rowid);\r\n                if (status) {\r\n    " +
"                addSelectFileData({ GUID: dt.GUID, FILENAME: dt.FILENAME });\r\n  " +
"              }\r\n                else {\r\n                    deleteSelectFileDat" +
"a(dt);\r\n                }\r\n            }, onSelectAll: function (aRowids, status" +
") {\r\n                $.each(aRowids, function (i, e) {\r\n                    var " +
"dt = $gridTable.jqGrid(\'getRowData\', e);\r\n                    if (status) {\r\n   " +
"                     addSelectFileData({ GUID: dt.GUID, FILENAME: dt.FILENAME })" +
";\r\n                    }\r\n                    else {\r\n                        de" +
"leteSelectFileData(dt);\r\n                    }\r\n                });\r\n\r\n         " +
"   },\r\n            gridComplete: function () {\r\n                var rowIds = $gr" +
"idTable.jqGrid(\'getDataIDs\');\r\n                for (var i = 0; i < selectFileDat" +
"a.length; i++) {\r\n                    for (var j = 0; j < rowIds.length; j++) {\r" +
"\n                        var guid = $gridTable.jqGrid(\'getRowData\', j).GUID;\r\n  " +
"                      if (selectFileData[i].GUID == guid) {\r\n                   " +
"         $gridTable.setSelection(j);\r\n                        }\r\n               " +
"     }\r\n                }\r\n            },\r\n        });\r\n \r\n        //查询点击事件\r\n   " +
"     $(\"#btn_Search\").click(function () {\r\n            SearchEvent();\r\n         " +
"   $(\".ui-filter-text\").trigger(\"click\");\r\n            $(\"#SelectedStartTime\").h" +
"tml($(\"#StartTime\").val());\r\n            $(\"#SelectedEndTime\").html($(\"#EndTime\"" +
").val());\r\n        });\r\n        //重置\r\n        $(\"#btn_Reset\").click(function () " +
"{\r\n            $(\"#filter-form\").find(\"input[type=\'text\']\").val(\"\");\r\n          " +
"  $(\"#FileType .dropdown-text\").html(\"\").attr(\'data-value\', \"\");\r\n        });\r\n\r" +
"\n        //$(\"#fileUpload\").click(function () {\r\n        //    learun.dialogOpen" +
"({\r\n        //        id: \"UploadifyForm\",\r\n        //        title: \'上传文件\',\r\n  " +
"      //        url: \'/SystemManage/MultMedia/UploadifyForm\',\r\n        //       " +
" width: \"600px\",\r\n        //        height: \"450px\",\r\n        //        isClose:" +
" true,\r\n        //        callBack: function (iframeId) {\r\n        //           " +
" var queryJson = $(\"#filter-form\").getWebControls();\r\n        //            var " +
"fileType=  $(\"#FileType\").find(\'.dropdown-text\').attr(\'data-value\');\r\n        //" +
"            if(!fileType){\r\n        //                fileType=\"\";\r\n        //  " +
"          }\r\n        //            queryJson[\"FileType\"] = fileType;\r\n        //" +
"            $(\"#gridTable\").jqGrid(\'setGridParam\', {\r\n        //                " +
"url: \"../../SystemManage/MultMedia/FindFileInfos\",\r\n        //                po" +
"stData: { queryJson: JSON.stringify(queryJson) },\r\n        //                pag" +
"e: 1\r\n        //            }).trigger(\'reloadGrid\');\r\n        //        }\r\n    " +
"    //    });\r\n        //});\r\n     \r\n    }\r\n\r\n    //上传文件\r\n    function uploadify" +
"() {\r\n        //var _extensions = \'avi,mp3,mp4,bmp,ico,gif,jpeg,jpg,png,tif,psd," +
"rar,zip,swf,log,pdf,doc,docx,ppt,pptx,txt,xls,xlsx\';\r\n        var _extensions = " +
"\'jpg,jpeg,png,tif,tiff,gif,pcx,tga,exif,fpx,svg,psd,cdr,pcd,eps,ai,raw,wmf,cad,i" +
"co,bmp,doc,docx,ppt,pptx,pdf,txt,rtf,odt,xls,xlsx,flv,wmv,mkv,mp4,avi,rm,rmvb\';\r" +
"\n        var upLoader = WebUploader.create({\r\n            auto: true,\r\n         " +
"   method: \'post\',\r\n            swf: \'/Content/scripts/plugins/webuploader/Uploa" +
"der.swf\',\r\n            server: \'/SystemManage/MultMedia/UploadifyFile?folderId=\'" +
" + \" \",\r\n            pick: { id: \"#fileUpload\", innerHTML: \"<i class=\'fa fa-uplo" +
"ad\'></i>&nbsp;上传文件\" },\r\n            accept: { extensions: _extensions },\r\n      " +
"      resize: false\r\n        });\r\n        upLoader.on(\'beforeFileQueued\', functi" +
"on (file) {\r\n            if (_extensions.indexOf(file.ext) < 0) {\r\n             " +
"   learun.dialogAlert({ msg: \"上传格式不正确！\", type: -1 });\r\n                return fa" +
"lse;\r\n            }\r\n        });\r\n        upLoader.on(\'uploadStart\', function (f" +
"ile) {\r\n            if ($(\'.upload-history\').is(\":hidden\")) {\r\n                $" +
"(\".upload-info\").css(\'border-bottom-color\', \'#fff\').addClass(\"active\");\r\n       " +
"         $(\".upload-history\").slideDown(10);\r\n            }\r\n            var inf" +
"oBox = \'<div class=\"upload-info-box\" id=\"\'+ file.id +\'\">\' +\r\n                   " +
"          \'<img src=\"/Content/images/filetype/\' + file.ext + \'.png\" style=\"width" +
":30px;height:30px;float:left;\" />\' +\r\n                             \'<span class=" +
"\"file-name\" title=\"\' + file.name + \'\">\' + file.name + \'</span><span class=\"file-" +
"size\">(\' + learun.countFileSize(file.size) + \')</span><span class=\"percentageInf" +
"o\">0%</span><span class=\"up-info\"></span>\' +\r\n                             \'<spa" +
"n class=\"percentageInfoBg\" style=\"position:absolute;top:0;left:0;height:30px;bac" +
"kground:green;opacity:0.3;\"></span>\' +\r\n                             \'<a title=\"" +
"删除\" class=\"tip-box f-delete\"><i class=\"fa fa-trash-o\"></i></a>\' +\r\n             " +
"                \'<a title=\"成功\" class=\"tip-box f-success\"><i class=\"fa fa-check-c" +
"ircle\"></i></a>\' +\r\n                          \'</div>\';\r\n            $(\".upload-" +
"history\").prepend(infoBox);\r\n        });\r\n        //上传过程中\r\n        upLoader.on(\'" +
"uploadProgress\', function (file, percentage) {\r\n            var _percentage = pa" +
"rseInt(percentage * 100) + \'%\';\r\n            $(\"#\" + file.id).find(\".percentageI" +
"nfo\").text(_percentage);\r\n            $(\"#\" + file.id).find(\".percentageInfoBg\")" +
".css(\"width\", _percentage);\r\n            $(\".upload-info-box\").hover(function ()" +
" {\r\n                    $(this).find(\".f-delete\").show();\r\n                },fun" +
"ction () {\r\n                    $(this).find(\".f-delete\").hide();\r\n             " +
"   });\r\n            uploadCancel();\r\n        });\r\n        //上传成功后\r\n        upLoa" +
"der.on(\'uploadSuccess\', function (file, response) {\r\n            $(\"#\" + file.id" +
").find(\".percentageInfoBg\").hide();\r\n            $(\"#\" + file.id).find(\".f-succe" +
"ss\").show();\r\n            $(\"#\" + file.id).find(\".up-info\").text(\"上传成功！\");\r\n    " +
"        var fileInfo = response.resultdata;\r\n            addSelectFileData({ GUI" +
"D: fileInfo.GUID, FILENAME: fileInfo.FILENAME });\r\n            $(\".upload-info-b" +
"ox\").hover(\r\n                function () { $(this).find(\".f-delete\").show(); $(t" +
"his).find(\".f-success\").hide(); },\r\n                function () { $(this).find(\"" +
".f-delete\").hide(); $(this).find(\".f-success\").show(); }\r\n            );\r\n      " +
"      learun.dialogMsg({ msg: \"恭喜您，上传成功！\", type: 1 });\r\n        });\r\n        //上" +
"传失败后\r\n        upLoader.on(\'uploadError\', function (file, code) {\r\n            $(" +
"\"#\" + file.id).find(\".up-info\").text(\"上传失败！\");\r\n            learun.dialogMsg({ m" +
"sg: \"很抱歉，上传失败！\", type: 1 });\r\n        });\r\n        //上传完成后\r\n        upLoader.on(" +
"\"uploadComplete\", function (file, data) {\r\n            $(\'#gridTable\').trigger(\'" +
"reloadGrid\');\r\n            uploadCancel();\r\n        });\r\n        \r\n    };\r\n\r\n   " +
" function uploadCancel() {\r\n        $(\".f-delete\").click(function () {\r\n        " +
"    var progress = parseInt($(this).parent().find(\".percentageInfo\").text().repl" +
"ace(\"%\", \"\"));\r\n            var fileId = $(this).parent().attr(\"id\");\r\n         " +
"   if (progress < 100) {\r\n                upLoader.cancelFile(fileId);\r\n        " +
"    }\r\n            $(this).parent().remove();\r\n        });\r\n    };\r\n\r\n    //查询表格" +
"函数\r\n    function SearchEvent() {\r\n        var queryJson = $(\"#filter-form\").getW" +
"ebControls();\r\n        var fileType = $(\"#FileType\").find(\'.dropdown-text\').attr" +
"(\'data-value\');\r\n        if (!fileType) {\r\n            fileType = \"\";\r\n        }" +
"\r\n        queryJson[\"FileType\"] = fileType;\r\n        $(\"#gridTable\").jqGrid(\'set" +
"GridParam\', {\r\n            url: \"../../SystemManage/MultMedia/FindFileInfos\",\r\n " +
"           postData: { queryJson: JSON.stringify(queryJson) },\r\n            page" +
": 1\r\n        }).trigger(\'reloadGrid\');\r\n    }\r\n\r\n    function addSelectFileData(" +
"dt) {\r\n        var flag = false;\r\n        for (var i = 0; i < selectFileData.len" +
"gth; i++) {\r\n            if (selectFileData[i].GUID == dt.GUID) {\r\n             " +
"   flag = true;\r\n            }\r\n        }\r\n        if (!flag) {\r\n            sel" +
"ectFileData.push({ GUID: dt.GUID, FILENAME: dt.FILENAME });\r\n        }\r\n    }\r\n " +
"   function deleteSelectFileData(dt) {\r\n        for (var i = 0; i < selectFileDa" +
"ta.length; i++) {\r\n            if (selectFileData[i].GUID == dt.GUID) {\r\n       " +
"         selectFileData.splice(i, 1);\r\n            }\r\n        }\r\n    }\r\n\r\n    //" +
"删除\r\n    function removeFile(tag) {\r\n        var Id = $(tag).attr(\'id\');\r\n       " +
" var keyValue;\r\n        for (var i = 0; i < selectFileData.length; i++) {\r\n     " +
"       if (selectFileData[i].GUID == Id) {\r\n                keyValue = Id;\r\n    " +
"        }\r\n        }\r\n        if (keyValue) {\r\n            $.RemoveForm({\r\n     " +
"           url: \'../../SystemManage/MultMedia/RemoveFiles\',\r\n                par" +
"am: { id: keyValue },\r\n                success: function (data) {\r\n             " +
"       learun.dialogMsg({ msg: \"删除成功\", type: 1 });\r\n                    deleteSe" +
"lectFileData({ GUID: keyValue });\r\n                    $(\'#gridTable\').trigger(\'" +
"reloadGrid\');\r\n                }\r\n            })\r\n        } else {\r\n            " +
"dialogMsg(\'请选择需要删除的任务！\', 0);\r\n        }\r\n    }\r\n</script>\r\n    ");

});

WriteLiteral("<div");

WriteLiteral(" class=\"widget-body\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"titlePanel\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"title-search\"");

WriteLiteral(" >\r\n            <table>\r\n                <tr>\r\n                    <td>查询条件</td>\r" +
"\n                    <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"ui-filter\"");

WriteLiteral(" style=\"width: 200px;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"ui-filter-text\"");

WriteLiteral(">\r\n                                <strong");

WriteLiteral(" id=\"SelectedStartTime\"");

WriteLiteral(">");

            
            #line 310 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
                                                          Write(DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</strong> 至 <strong");

WriteLiteral(" id=\"SelectedEndTime\"");

WriteLiteral(">");

            
            #line 310 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
                                                                                                                                                    Write(DateTime.Now.ToString("yyyy-MM-dd"));

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"ui-filter-list\"");

WriteLiteral(" style=\"width: 350px;height:280px;\"");

WriteLiteral(">\r\n                                <table");

WriteLiteral(" class=\"form\"");

WriteLiteral(" id=\"filter-form\"");

WriteLiteral(">\r\n                                    <tr>\r\n                                    " +
"    <th");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">查询时间：</th>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" style=\"float: left; width: 45%;\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" id=\"StartTime\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 13947), Tuple.Create("\"", 14004)
            
            #line 318 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
                 , Tuple.Create(Tuple.Create("", 13955), Tuple.Create<System.Object, System.Int32>(DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd")
            
            #line default
            #line hidden
, 13955), false)
);

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({maxDate:\'%y-%M-%d\'})\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"                  <div");

WriteLiteral(" style=\"float: left; width: 10%; text-align: center;\"");

WriteLiteral(">至</div>\r\n                                            <div");

WriteLiteral(" style=\"float: left; width: 45%;\"");

WriteLiteral(">\r\n                                                <input");

WriteLiteral(" id=\"EndTime\"");

WriteLiteral(" readonly");

WriteLiteral(" type=\"text\"");

WriteAttribute("value", Tuple.Create(" value=\"", 14426), Tuple.Create("\"", 14465)
            
            #line 322 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
               , Tuple.Create(Tuple.Create("", 14434), Tuple.Create<System.Object, System.Int32>(Infoearth.Util.Time.GetToday()
            
            #line default
            #line hidden
, 14434), false)
);

WriteLiteral(" class=\"form-control input-wdatepicker\"");

WriteLiteral(" onfocus=\"WdatePicker({maxDate:\'%y-%M-%d\'})\"");

WriteLiteral(">\r\n                                            </div>\r\n                          " +
"              </td>\r\n                                    </tr>\r\n                " +
"                    <tr>\r\n                                        <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">文件名称：</td>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"FileName\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                                        </td>\r\n                               " +
"     </tr>\r\n                                    <tr>\r\n                          " +
"              <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral("> 创建人：</td>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <input");

WriteLiteral(" id=\"FileUser\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteAttribute("value", Tuple.Create(" value=\"", 15341), Tuple.Create("\"", 15420)
            
            #line 335 "..\..\Areas\SystemManage\Views\MultMedia\FileSelectForm.cshtml"
                        , Tuple.Create(Tuple.Create("", 15349), Tuple.Create<System.Object, System.Int32>(Infoearth.Application.Code.OperatorProvider.Provider.Current().Account
            
            #line default
            #line hidden
, 15349), false)
);

WriteLiteral(">\r\n                                        </td>\r\n                               " +
"     </tr>\r\n                                    <tr>\r\n                          " +
"              <td");

WriteLiteral(" class=\"formTitle\"");

WriteLiteral(">文件类型：</td>\r\n                                        <td");

WriteLiteral(" class=\"formValue\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" id=\"FileType\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                                                <a");

WriteLiteral(" class=\"btn btn-default dropdown-text\"");

WriteLiteral(" style=\"width:205px;\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">选择条件</a>\r\n                                                <a");

WriteLiteral(" class=\"btn btn-default dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral("><span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                                                <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(" style=\"width:205px;\"");

WriteLiteral(">\r\n                                                    <li><a");

WriteLiteral(" data-value=\"imageType\"");

WriteLiteral(">图片</a></li>\r\n                                                    <li><a");

WriteLiteral(" data-value=\"documentType\"");

WriteLiteral(">文档</a></li>\r\n                                                    <li><a");

WriteLiteral(" data-value=\"vedioType\"");

WriteLiteral(@">视频</a></li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div");

WriteLiteral(" class=\"ui-filter-list-bottom\"");

WriteLiteral(" style=\"margin-top:50px;\"");

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" id=\"btn_Reset\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(">&nbsp;重&nbsp;&nbsp;置</a>\r\n                                    <a");

WriteLiteral(" id=\"btn_Search\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">&nbsp;查&nbsp;&nbsp;询</a>\r\n                                </div>\r\n              " +
"              </div>\r\n                        </div>\r\n                    </td>\r" +
"\n                    <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" id=\"time_horizon\"");

WriteLiteral(" class=\"btn-group\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" id=\"fileUpload\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" style=\"height: 29px;margin-bottom: 4px;\"");

WriteLiteral("></a>\r\n                        </div>\r\n                    </td>\r\n               " +
"     <td");

WriteLiteral(" style=\"padding-left: 10px;\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"upload-wrap\"");

WriteLiteral(" id=\"upload-list\"");

WriteLiteral(" style=\"width: 100px;\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"upload-info\"");

WriteLiteral(" style=\"padding: 0px 20px;\"");

WriteLiteral(">\r\n                                上传列表\r\n                            </div>\r\n    " +
"                        <div");

WriteLiteral(" class=\"upload-history\"");

WriteLiteral(" style=\"width: 380px;height:280px;padding:10px;\"");

WriteLiteral(">\r\n                                \r\n                            </div>\r\n        " +
"                </div>\r\n                    </td>\r\n                </tr>\r\n      " +
"      </table>\r\n        </div>\r\n        <div");

WriteLiteral(" style=\"clear:both;\"");

WriteLiteral("></div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"gridPanel\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" id=\"gridTable\"");

WriteLiteral("></table>\r\n        <div");

WriteLiteral(" id=\"gridPager\"");

WriteLiteral("></div>\r\n    </div>\r\n</div>\r\n\r\n<style>\r\n    .upload-wrap {\r\n        cursor: point" +
"er;\r\n        outline: 0;\r\n        width: auto;\r\n        height: 29px;\r\n        l" +
"ine-height: 28px;\r\n        position: relative;\r\n    }\r\n    .upload-wrap .upload-" +
"info {\r\n        border-radius: 4px;\r\n        -moz-user-select: none;\r\n        -w" +
"ebkit-user-select: none;\r\n        -ms-user-select: none;\r\n        -khtml-user-se" +
"lect: none;\r\n        user-select: none;\r\n        border: 1px solid #ccc;\r\n      " +
"  padding-left: 5px;\r\n        height: 29px;\r\n        line-height: 27px;\r\n       " +
" position: relative;\r\n        z-index: 100;\r\n        /*background: #fff url(../." +
"./../Comtent/images/a2.png) no-repeat right center;*/\r\n        background: #fff " +
"url(../../../../Content/images/a2.png) no-repeat right center;\r\n    }\r\n    .uplo" +
"ad-wrap .upload-info.active {\r\n        border-bottom-left-radius: 0;\r\n        bo" +
"rder-bottom-right-radius: 0;\r\n    }\r\n    .upload-wrap .upload-history {\r\n       " +
" border-bottom-left-radius: 4px;\r\n        border-bottom-right-radius: 4px;\r\n    " +
"    overflow: hidden;\r\n        padding: 20px;\r\n        padding-top: 15px;\r\n     " +
"   padding-bottom: 10px;\r\n        width: 100%;\r\n        display: none;\r\n        " +
"left: 0;\r\n        top: 28px;\r\n        background-color: #fff;\r\n        overflow-" +
"y: auto;\r\n        border: 1px solid #ccc;\r\n        position: absolute;\r\n        " +
"z-index: 99;\r\n        box-shadow: 0 6px 12px rgba(0,0,0,.175);\r\n    }\r\n    .webu" +
"ploader-pick{background:transparent;border:none;}\r\n    #fileUpload>div{\r\n       " +
" height:100% !important;\r\n        top:0 !important;\r\n    }\r\n    #fileUpload>div>" +
"input{height:100%;}\r\n    .upload-info-box{\r\n        width:100%;\r\n        height:" +
"30px;\r\n        line-height:30px;\r\n        padding-left:10px;\r\n        position:r" +
"elative;\r\n        overflow: hidden;\r\n        margin-bottom: 2px;\r\n    }\r\n    .up" +
"load-info-box span {\r\n        margin-left:5px;\r\n        float:left;\r\n    }\r\n    " +
".upload-info-box .file-name {\r\n        width: 130px;\r\n        overflow: hidden;\r" +
"\n        white-space: nowrap;\r\n        text-overflow: ellipsis;\r\n    }\r\n    .upl" +
"oad-info-box .file-size {\r\n        width: 76px;\r\n    }\r\n    .upload-info-box .ti" +
"p-box{\r\n        display:none;\r\n        position:absolute;\r\n        top:0;\r\n     " +
"   left:0;\r\n    }\r\n</style>");

        }
    }
}
#pragma warning restore 1591
