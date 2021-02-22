﻿using System.Web.Optimization;

namespace Infoearth.Application.Web
{
    /// <summary>
    /// 版 本 LearunADMS V6.1.1.7 (http://www.learun.cn)
    /// Copyright (c) 2013-2016 
    /// 创建人：LR215
    /// 日 期：2015.11.4 14:31
    /// 描 述：js文件css文件绑定
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// 绑定js，css
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 公共基础库

            var styleBundle = new StyleBundle("~/Content/styles/base.css");
            styleBundle.Include("~/Content/styles/font-awesome.min.css", new CssRewriteUrlTransform());
            styleBundle.Include("~/Content/scripts/plugins/jquery-ui/jquery-ui.min.css", new CssRewriteUrlTransform());
            styleBundle.Include("~/Content/scripts/bootstrap/bootstrap.min.css", new CssRewriteUrlTransform());
            bundles.Add(styleBundle);
            var scriptBundle = new ScriptBundle("~/Content/scripts/base.js");
            scriptBundle.Include(
                     "~/Content/scripts/jquery/jquery-1.10.2.min.js",
                     "~/Content/scripts/plugins/jquery-ui/jquery-ui.min.js",
                     "~/Content/scripts/bootstrap/bootstrap.min.js",
                     "~/Content/scripts/plugins/layout/jquery.layout.js",
                     "~/Content/scripts/plugins/jquery.md5.js",
                     "~/Content/scripts/plugins/cookie/jquery.cookie.js"
                     );
            scriptBundle.Transforms.Clear();
            bundles.Add(scriptBundle);
            #endregion

            #region 框架基础库
            bundles.Add(new StyleBundle("~/Content/styles/learun.css").Include(
                        "~/Content/styles/learun-ui.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/learun.js").Include(
                       "~/Content/scripts/utils/base/learun.base.js",
                       "~/Content/scripts/utils/base/learun.base.plugin.js",
                       "~/Content/scripts/utils/base/learun.old.js"
                       ));
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/learunEx.js").Include(
                       "~/Content/scripts/utils/base/learun.base.extensions.js"
                       ));
            #endregion

            #region 登陆页面

            bundles.Add(new ScriptBundle("~/Content/scripts/utils/login/js").Include(
           "~/Content/scripts/utils/learun-login.js"));
            #endregion

            #region 经典版
            bundles.Add(new ScriptBundle("~/Content/adminDefault/js").Include(
                    "~/Content/scripts/utils/base/learun.clientdata.js",
                    "~/Content/adminDefault/index.js"));
            #endregion

            #region 数据
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/clientdata").Include(
                   "~/Content/scripts/utils/base/learun.clientdata.js"));
            #endregion

            #region 风尚版
            bundles.Add(new ScriptBundle("~/Content/adminLTE/js").Include(
                   "~/Content/scripts/utils/base/learun.clientdata.js",
                   "~/Content/adminLTE/index.js"));
            #endregion

            #region 炫动版
            bundles.Add(new ScriptBundle("~/Content/adminWindos/js").Include(
                  "~/Content/scripts/utils/base/learun.clientdata.js",
                  "~/Content/adminWindos/index.js"));
            #endregion

            #region 飞扬版皮肤
            bundles.Add(new StyleBundle("~/Content/adminPretty/css/Desktop").Include(
                   "~/Content/adminPretty/css/IndexDesktop.css"));
            bundles.Add(new StyleBundle("~/Content/adminPretty/css/home").Include(
                    "~/Content/adminPretty/css/index.css"));
            bundles.Add(new ScriptBundle("~/Content/adminPretty/Desktopjs").Include(
                    "~/Content/adminPretty/indexDesktop.js"));
            bundles.Add(new ScriptBundle("~/Content/adminPretty/js").Include(
                    "~/Content/scripts/utils/base/learun.clientdata.js",
                    "~/Content/adminPretty/index.js"));
            #endregion

            #region 地下水皮肤
            bundles.Add(new ScriptBundle("~/Content/adminWater/js").Include(
                   "~/Content/scripts/utils/base/learun.clientdata.js",
                   "~/Content/adminWater/index.js"));
            bundles.Add(new StyleBundle("~/Content/adminWater/css/Desktop").Include(
                   "~/Content/adminWater/css/IndexDesktop.css"));
            bundles.Add(new StyleBundle("~/Content/adminWater/css/home").Include(
                    "~/Content/adminWater/css/index.css"));
            bundles.Add(new ScriptBundle("~/Content/adminWater/Desktopjs").Include(
                    "~/Content/adminWater/indexDesktop.js"));
            #endregion

            #region 专业监测皮肤
            bundles.Add(new ScriptBundle("~/Content/adminMonitor/js").Include(
                   "~/Content/scripts/utils/base/learun.clientdata.js",
                   "~/Content/adminMonitor/index.js"));
            bundles.Add(new StyleBundle("~/Content/adminMonitor/css/Desktop").Include(
                   "~/Content/adminMonitor/css/IndexDesktop.css"));
            bundles.Add(new StyleBundle("~/Content/adminMonitor/css/home").Include(
                    "~/Content/adminMonitor/css/index.css"));
            bundles.Add(new ScriptBundle("~/Content/adminMonitor/Desktopjs").Include(
                    "~/Content/adminMonitor/indexDesktop.js"));
            #endregion

            #region 应急皮肤
            bundles.Add(new ScriptBundle("~/Content/adminEmergency/js").Include(
                   "~/Content/scripts/utils/base/learun.clientdata.js",
                   "~/Content/adminEmergency/index.js"));
            bundles.Add(new StyleBundle("~/Content/adminEmergency/css/Desktop").Include(
                   "~/Content/adminEmergency/css/IndexDesktop.css"));
            bundles.Add(new StyleBundle("~/Content/adminEmergency/css/home").Include(
                    "~/Content/adminEmergency/css/index.css"));
            bundles.Add(new ScriptBundle("~/Content/adminEmergency/Desktopjs").Include(
                    "~/Content/adminEmergency/indexDesktop.js"));
            #endregion

            #region jqgrid表格组件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/jqgrid/css").Include(
                        "~/Content/scripts/plugins/jqgrid/jqgrid.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/jqgrid/js").Include(
                       "~/Content/scripts/plugins/jqgrid/grid.locale-cn.js",
                       "~/Content/scripts/plugins/jqgrid/jqgrid.js"));
            #endregion

            #region 树形组件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/tree/css").Include(
                        "~/Content/scripts/plugins/tree/tree.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/tree/js").Include(
                       "~/Content/scripts/plugins/tree/tree.js"));
            #endregion

            #region jquery.md5.js
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/md5").Include(
                     "~/Content/scripts/plugins/jquery.md5.js"));
            #endregion

            #region jquery.cookie.js
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/cookie/js").Include(
                     "~/Content/scripts/plugins/cookie/jquery.cookie.js"));
            #endregion

            #region 表单验证
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/validator/js").Include(
                      "~/Content/scripts/plugins/validator/validator.js"));
            #endregion

            #region dialog.js
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/dialog/js").Include(
                     "~/Content/scripts/plugins/dialog/dialog.js"));
            #endregion

            #region tipso.min.js
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/tipso").Include(
                     "~/Content/scripts/plugins/tipso.min.js"));
            #endregion

            #region 日期控件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/datetime/css").Include(
                        "~/Content/scripts/plugins/datetime/pikaday.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/datepicker/js").Include(
                       "~/Content/scripts/plugins/datetime/pikaday.js"));
            #endregion

            #region 导向组件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/wizard/css").Include(
                        "~/Content/scripts/plugins/wizard/wizard.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/wizard/js").Include(
                       "~/Content/scripts/plugins/wizard/wizard.js"));
            #endregion

            #region 页面打印插件js
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/printTable/js").Include(
                "~/Content/scripts/plugins/printTable/jquery.printTable.js"));
            #endregion

            #region 自定义表单设计管理（包括对系统表单构建）
            //css
            bundles.Add(new StyleBundle("~/Content/styles/custmerform.css").Include(
            "~/Content/styles/learun-formDesigner.css"));

            bundles.Add(new ScriptBundle("~/Content/scripts/utils/custmerform/formcompontsjs").Include(
          "~/Content/scripts/utils/custmerform/learun.custmerform.componts.js"));//表单设计组件

            bundles.Add(new ScriptBundle("~/Content/scripts/utils/custmerform/formdesignerjs").Include(
            "~/Content/scripts/utils/custmerform/learun.custmerform.designer.js"));//设计器

            bundles.Add(new ScriptBundle("~/Content/scripts/utils/custmerform/formrenderingjs").Include(
            "~/Content/scripts/utils/custmerform/learun.custmerform.rendering.js"));//渲染器

            bundles.Add(new ScriptBundle("~/Content/scripts/utils/custmerform/formbuilderjs").Include(
            "~/Content/scripts/utils/custmerform/learun.form.builder.js"));//构建器

            bundles.Add(new ScriptBundle("~/Content/scripts/utils/custmerform/formindexjs").Include(
           "~/Content/scripts/utils/custmerform/learun.custmerform.index.js"));//构建器


            #endregion

            #region 流程设计器
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/flow-ui/css").Include(
            "~/Content/scripts/plugins/flow-ui/flow.css",
            "~/Content/styles/learun-flow.css"));
            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/flow-ui/js").Include(
            "~/Content/scripts/plugins/flow-ui/flow.js",
            "~/Content/scripts/utils/learun-flowlayout.js"));
            #endregion

            #region JS插件演示
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/learun-demo/js").Include(
            "~/Content/scripts/utils/learun-demo.js"));
            #endregion

            #region 上传文件插件
            bundles.Add(new StyleBundle("~/Content/scripts/plugins/uploadify/css").Include(
            "~/Content/scripts/plugins/uploadify/uploadify.css",
            "~/Content/scripts/plugins/uploadify/uploadify.extension.css",
            "~/Content/scripts/plugins/uploadify/uploadifyEx.css"));

            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/uploadify/js").Include(
           "~/Content/scripts/plugins/uploadify/jquery.uploadify.min.js"));

            bundles.Add(new StyleBundle("~/Content/scripts/plugins/webuploader/css").Include(
          "~/Content/scripts/plugins/webuploader/webuploader.css"));

            bundles.Add(new ScriptBundle("~/Content/scripts/plugins/webuploader/js").Include(
           "~/Content/scripts/plugins/webuploader/webuploader.nolog.js"));
            #endregion

            #region 即时通信
            //bundles.Add(new ScriptBundle("~/Content/scripts/utils/imjs").Include(
            //       "~/Content/scripts/plugins/signalr/jquery.signalR-2.2.0.min.js",
            //       "~/Content/scripts/utils/learun-im.js"));
            #endregion

            #region 快速开发
            //单表开发
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/learun-st.js").Include(
                   "~/Content/scripts/utils/generator/learun.singletable.js"));
            //后台服务类开发
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/learun-sc.js").Include(
                   "~/Content/scripts/utils/generator/learun.servicecode.js"));
            #endregion

            #region Excel导入,导出配置
            //excel导入配置页
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/learun-elis.js").Include(
                   "~/Content/scripts/utils/excel/learun-excelImportSet.js"));
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/learun-elif.js").Include(
                  "~/Content/scripts/utils/excel/learun-excelImportForm.js"));
            #endregion

            #region 地图
            var mapStyleBundle = new StyleBundle("~/Content/styles/map.css");

            mapStyleBundle.Include(
            "~/Content/scripts/plugins/openLayer/css/ol.css",
            "~/Content/scripts/plugins/openLayer/css/map.css",
            "~/Content/scripts/plugins/map/map.css");
            mapStyleBundle.Include("~/Content/scripts/plugins/map/themify-icons.css", new CssRewriteUrlTransform());
            bundles.Add(mapStyleBundle);
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/mapjs").Include(
          "~/Content/scripts/plugins/map/jquery.fullscreen.js",
          "~/Content/scripts/plugins/webgis/jsts.min.js",
          "~/Content/scripts/plugins/openLayer/ol.js",
          "~/Content/scripts/plugins/openLayer/itelluro.ol.js",
          "~/Content/scripts/plugins/openLayer/itelluro.tianditu.js",
          "~/Content/scripts/plugins/openLayer/measuretool.js",
          "~/Content/scripts/plugins/map/map.js"));


            #endregion

            #region 地图编辑

            var mapEStyleBundle = new StyleBundle("~/Content/styles/mapEditor.css");

            mapEStyleBundle.Include(
                "~/Content/scripts/plugins/colorpick/colpick.css",
            "~/Content/scripts/plugins/openLayer/css/ol.css",
            "~/Content/scripts/plugins/openLayer/css/map.css",
            "~/Content/scripts/plugins/mapVectorEditor/mapVectorEditor.css",
            "~/Content/scripts/plugins/jquery-range/jquery.range.css");
            mapEStyleBundle.Include("~/Content/scripts/plugins/map/themify-icons.css", new CssRewriteUrlTransform());
            mapEStyleBundle.Include("~/Content/styles/map-editor-icon/style.css", new CssRewriteUrlTransform());
            bundles.Add(mapEStyleBundle);
            bundles.Add(new ScriptBundle("~/Content/scripts/utils/mapEditorjs").Include(
          "~/Content/scripts/plugins/webgis/jsts.min.js",
          "~/Content/scripts/plugins/openLayer/ol.js",
          "~/Content/scripts/plugins/openLayer/itelluro.ol.js",
          "~/Content/scripts/plugins/openLayer/itelluro.tianditu.js",
          "~/Content/scripts/plugins/openLayer/measuretool.js",
          "~/Content/scripts/plugins/mapVectorEditor/countyRange.js",
          "~/Content/scripts/plugins/geojson/geojson-vt-dev.js",
          "~/Content/scripts/plugins/geojson/fetch.umd.js",
          "~/Content/scripts/plugins/colorpick/colpick.js",
          "~/Content/scripts/plugins/mapVectorEditor/countyRange.js",
          "~/Content/scripts/plugins/mapVectorEditor/vectorCustomDrag.js",
          "~/Content/scripts/plugins/mapVectorEditor/curve_calc.min.js",
          "~/Content/scripts/plugins/mapVectorEditor/mapVectorEditor.js"));

            #endregion

            #region zTree

            bundles.Add(new StyleBundle("~/Content/styles/zTree.css").Include(
                  "~/Content/scripts/plugins/JQueryzTree/css/zTreeStyle/zTreeStyle.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/Content/scripts/utils/zTreejs").Include(
                    "~/Content/scripts/plugins/JQueryzTree/js/jquery.ztree.all-3.5.min.js",
                    "~/Content/scripts/plugins/JQueryzTree/js/jquery.ztree.exhide-3.5.min.js"));

            #endregion

            //BundleTable.EnableOptimizations = true;
        }
    }
}