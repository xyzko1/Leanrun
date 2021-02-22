var nodeInfos = null;
var deleteFiles = [];
var addFiles = [];
var existFiles = [];
var mediaPath = "";
var moduleID = "00A31B8F-FC2D-404c-8BFE-2F5D846D372A";
var belongObjectGuid = "3703050000002000";
var isEdit = true;


Array.prototype.indexOf=function(val){
    for(var i=0;i<this.length;i++){
        if(this[i]==val)return i;
}
return -1;
}

Array.prototype.remove=function(val){
    var index=this.indexOf(val);
    if(index>-1){
    this.splice(index,1);
}
}

//zTree 属性变量
var setting = {
    data: {
        simpleData: {
            enable: true
        }
    },
    view: {
        selectedMulti: false
    },
    callback: {
        onClick: zTreeOnClick
    }
};

$(function () {
    //top.contentPath = '';
    moduleID = request('moduleID');
    belongObjectGuid = request('belongObjectGuid');
    if (moduleID == null || moduleID == "") {
        moduleID = "00A31B8F-FC2D-404c-8BFE-2F5D846D372A";
    }
    //if (belongObjectGuid == null || belongObjectGuid == "") {
    //    belongObjectGuid = "3703050000002000";
    //}
    var queryUrl = "../../SystemManage/MultMedia/GetMultMediaWebPath";
    $.ajax({
        url: queryUrl,
        async: false,
        type: "GET",
        success: function (data) {
            mediaPath = data;
        }, error: function (e) {
        },
        cache: false
    });
    $("#filedownload").attr("disabled", "disabled");
    $("#filedelete").attr("disabled", "disabled");
    $("#fileadd").attr("disabled", "disabled");
    $("#fileaddlocal").attr("disabled", "disabled");
    var iW = $(window).width();
    var iH = $(window).height();
    //设置左右容器高度
    //$("#layout").width(iW);
    $("#layout").height(iH);
    $("#docmentTree").height(iH - $(".west-Panel .panel-Title").height() - $(".west-Panel .btn-group").height() - 14);
    $("#docPanel").height(iH - $(".center-Panel .panel-Title").height() - $(".center-Panel .titlePanel").height() - 4);
    $("#mediaBrowserLook").height($("#docPanel").height() - 1);
    InitialPage();
    InitTree();
    uploadifyLocal();
});

//初始化页面
function InitialPage() {
    //layout布局
   var layout= $('#layout').layout({
        applyDemoStyles: true,
        onresize: function () {
            $(window).resize();
        }
   });

   layout.sizePane("west", 300);

    resize();

    //resize重设(表格、树形)宽高
    $(window).resize(function (e) {
        resize();
    });

    function resize() {
        var height = $(window).height();
        $("#docmentTree").height(height - $(".west-Panel .panel-Title").height() - $(".west-Panel .btn-group").height() - 14);
        $("#docPanel").height(height - $(".center-Panel .panel-Title").height() - $(".center-Panel .titlePanel").height() - 4);
        $("#mediaBrowserLook").height($("#docPanel").height() - 1);
    }
};

//添加文件
function btn_add() {
    learun.dialogOpen({
        id: "FileSelectFormMultMedia",
        title: '附件列表',
        url: '/SystemManage/MultMedia/FileSelectForm?folderId=' + nodeInfos.id,
        width: "800px",
        height: "600px",
        isClose:true,
        callBack: function (iframeId) {
            var rowData = getInfoTop().frames[iframeId].selectFileData;
            if (rowData.length) {
                for (var i = 0; i < rowData.length; i++) {
                    var fileGuid = rowData[i].GUID;
                    var fileName = rowData[i].FILENAME;
                    if (nodeInfos != null && fileGuid != null && fileGuid != "") {
                        var nid = nodeInfos.id + "#" + fileGuid;
                        var index = addFiles.indexOf(nid);
                        var index1 = existFiles.indexOf(nid);
                        if (index <= -1 && index1 <= -1) {
                            addFiles.push(nid);
                            $.fn.zTree.getZTreeObj("docmentTree").addNodes(nodeInfos, { id: fileGuid, pId: nodeInfos.id, name: fileName, nodetype: "FILE", icon: "../../Content/images/file.png" });
                        }
                    }
                }
            }

            return true;
        }
    });
};

//本地上传
function btn_addLocal() {
};

//删除
function btn_delete() {
    if (nodeInfos == null) {
        return;
    }
    learun.dialogConfirm({
        msg: '确认要删除该文件吗?',
        isClose:true,
        callBack: function (isOk) {
            if (isOk) {
                var treeObj = $.fn.zTree.getZTreeObj("docmentTree");
                //选中节点  
                var nodes = treeObj.getSelectedNodes();
                for (var i = 0, l = nodes.length; i < l; i++) {
                    //删除选中的节点  
                    if (nodes[i].businessID != null && nodes[i].businessID != "") {
                        deleteFiles.push(nodes[i].businessID);
                    }
                    addFiles.remove(nodes[i].pId + "#" + nodes[i].id);
                    existFiles.remove(nodes[i].pId + "#" + nodes[i].id);
                    treeObj.removeNode(nodes[i]);
                }
                nodeInfos = null;
            }
        }
    });
};

//下载
function btn_download() {
    if (nodeInfos == null) {
        return;
    }
    var downLoadUrl = mediaPath + "/page/download.ashx";
    var form = $("<form></form>").attr("action", downLoadUrl).attr("method", "get");
    form.append($("<input></input>").attr("type", "hidden").attr("name", "Guid").attr("value", nodeInfos.id));
    form.append($("<input></input>").attr("type", "hidden").attr("name", "Filename").attr("value", nodeInfos.name));
    form.appendTo('body').submit().remove();
    //window.location.href = downLoadUrl;
};

//初始化目录树
function InitTree() {
    var queryUrl = "../../SystemManage/MultMedia/FindMedInfoList";
    $.ajax({
        url: queryUrl,
        async: true,
        type: "POST",
        data: {
            moduleID: moduleID,
            belongObjectGuid: belongObjectGuid
        },
        success: function (data) {
            var treeNodes = JSON.parse(data);
            for (var i = 0; i < treeNodes.length; i++) {
                if (treeNodes[i].nodetype == "FILE") {
                    existFiles.push(treeNodes[i].pId + "#" + treeNodes[i].id);
                }
            }
            $.fn.zTree.init($("#docmentTree"), setting, treeNodes);
        }, error: function (e) {
        },
        cache: false
    });
}

//树节点点击事件
function zTreeOnClick(event, treeId, treeNode) {
    nodeInfos = treeNode;
    if (treeNode.nodetype != "FILE") {
        $("#filedownload").attr("disabled", "disabled");
        $("#filedelete").attr("disabled", "disabled");
        $("#fileadd").removeAttr("disabled");
        $("#fileaddlocal").removeAttr("disabled");
    }
    else {
        $("#fileaddlocal").attr("disabled", "disabled");
        $("#fileadd").attr("disabled", "disabled");
        $("#filedownload").removeAttr("disabled");
        $("#filedelete").removeAttr("disabled");

        $("#mediaBrowserLook")[0].src =mediaPath+ "/page/redirectToDetail.aspx?Guid=" + treeNode.id + "&webform=true";
    }
    if (!isEdit) {
        $("#filedownload").attr("disabled", "disabled");
        $("#filedelete").attr("disabled", "disabled");
        $("#fileadd").attr("disabled", "disabled");
        $("#fileaddlocal").attr("disabled", "disabled");
    }
}

function SaveFileInfo(belongGuid) {
    if (belongGuid != "" && belongGuid != undefined) {
        belongObjectGuid = belongGuid;
    }
    if (!belongObjectGuid) {
        return;
    }
    var addStr = "";
    var deleteStr = "";
    for (var i = 0; i < addFiles.length; i++) {
        addStr += addFiles[i] + ",";
    }

    for (var i = 0; i < deleteFiles.length; i++) {
        deleteStr += deleteFiles[i] + ",";
    }

    var queryUrl = "../../SystemManage/MultMedia/UpdateMediaInfo";
    $.ajax({
        url: queryUrl,
        async: true,
        type: "POST",
        data: {
            addData: addStr,
            deleteData:deleteStr,
            moduleID: moduleID,
            belongObjectGuid: belongObjectGuid
        },
        success: function (data) {
          
        }, error: function (e) {
        },
        cache: false
    });
};

function SetMultMediaEnable(isEnable) {
    isEdit = isEnable;
}

//上传文件
function uploadifyLocal() {
    var _extensions = 'jpg,jpeg,png,tif,tiff,gif,pcx,tga,exif,fpx,svg,psd,cdr,pcd,eps,ai,raw,wmf,cad,ico,bmp,doc,docx,ppt,pptx,pdf,txt,rtf,odt,xls,xlsx,flv,wmv,mkv,mp4,avi,rm,rmvb';
    var upLoader = WebUploader.create({
        auto: true,
        method: 'post',
        swf: '/Content/scripts/plugins/webuploader/Uploader.swf',
        server: '/SystemManage/MultMedia/UploadifyFile?folderId=' + " ",
        pick: { id: "#fileaddlocal" },
        accept: { extensions: _extensions },
        resize: false
    });
    upLoader.on('beforeFileQueued', function (file) {
        if (_extensions.indexOf(file.ext) < 0) {
            learun.dialogAlert({ msg: "上传格式不正确！", type: -1 });
            return false;
        }
    });
    upLoader.on('uploadStart', function (file) {
        if ($('.upload-history').is(":hidden")) {
            $(".upload-info").css('border-bottom-color', '#fff').addClass("active");
            $(".upload-history").slideDown(10);
        }
        var infoBox = '<div class="upload-info-box" id="' + file.id + '">' +
                         '<img src="/Content/images/filetype/' + file.ext + '.png" style="width:30px;height:30px;float:left;" />' +
                         '<span class="file-name" title="' + file.name + '">' + file.name + '</span><span class="file-size">(' + learun.countFileSize(file.size) + ')</span><span class="percentageInfo">0%</span><span class="up-info"></span>' +
                         '<span class="percentageInfoBg" style="position:absolute;top:0;left:0;height:30px;background:green;opacity:0.3;"></span>' +
                         '<a title="删除" class="tip-box f-delete"><i class="fa fa-trash-o"></i></a>' +
                         '<a title="成功" class="tip-box f-success"><i class="fa fa-check-circle"></i></a>' +
                      '</div>';
        $(".upload-history").prepend(infoBox);
    });
    //上传过程中
    upLoader.on('uploadProgress', function (file, percentage) {
        var _percentage = parseInt(percentage * 100) + '%';
        $("#" + file.id).find(".percentageInfo").text(_percentage);
        $("#" + file.id).find(".percentageInfoBg").css("width", _percentage);
        $(".upload-info-box").hover(function () {
            $(this).find(".f-delete").show();
        }, function () {
            $(this).find(".f-delete").hide();
        });
        uploadCancelLocal();
    });
    //上传成功后
    upLoader.on('uploadSuccess', function (file, response) {
        $("#" + file.id).find(".percentageInfoBg").hide();
        $("#" + file.id).find(".f-success").show();
        $("#" + file.id).find(".up-info").text("上传成功！");
        var fileInfo = response.resultdata;
        var fileGuid =fileInfo.GUID;
        var fileName = fileInfo.FILENAME;
        if (nodeInfos != null && fileGuid != null && fileGuid != "") {
            var nid = nodeInfos.id + "#" + fileGuid;
            var index = addFiles.indexOf(nid);
            var index1 = existFiles.indexOf(nid);
            if (index <= -1 && index1 <= -1) {
                addFiles.push(nid);
                $.fn.zTree.getZTreeObj("docmentTree").addNodes(nodeInfos, { id: fileGuid, pId: nodeInfos.id, name: fileName, nodetype: "FILE", icon: "../../Content/images/file.png" });
            }
        }
        $(".upload-info-box").hover(
            function () { $(this).find(".f-delete").show(); $(this).find(".f-success").hide(); },
            function () { $(this).find(".f-delete").hide(); $(this).find(".f-success").show(); }
        );
        learun.dialogMsg({ msg: "恭喜您，上传成功！", type: 1 });
    });
    //上传失败后
    upLoader.on('uploadError', function (file, code) {
        $("#" + file.id).find(".up-info").text("上传失败！");
        learun.dialogMsg({ msg: "很抱歉，上传失败！", type: 1 });
    });
    //上传完成后
    upLoader.on("uploadComplete", function (file, data) {
        $('#gridTable').trigger('reloadGrid');
        uploadCancelLocal();
    });

};

function uploadCancelLocal() {
    $(".f-delete").click(function () {
        var progress = parseInt($(this).parent().find(".percentageInfo").text().replace("%", ""));
        var fileId = $(this).parent().attr("id");
        if (progress < 100) {
            upLoader.cancelFile(fileId);
        }
        $(this).parent().remove();
    });
};

