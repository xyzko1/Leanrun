var map, WKTString = {};
(function ($) {
    $.fn.mapCtl = function (settings) {
        //默认选项
        var defaluts = {
            //地图数据源集合
            dataset: null,
            //地图控件宽高
            mapheight: 400,
            mapwidth: 800,
            isShowTools: true, //是否显示测量工具
            isShowGisLayer: false, //是否显示Gis图层工具
            isFrame: false,
            center: [118.0415, 36.4482],
            zoom: 10,
            extent: null,
            //边界拐点坐标
            boundWKT: null,
            baseLayer: "LAN",   //WAN:外网   LAN:内网  OFFLINE:离线,
            distance: 35, //点标注聚合距离
            isCluster: true, //是否启用点聚合
            offsetX: 12, //聚合时文本X方向偏移距离
            offsetY: 8, //聚合时文本X方向偏移距离
            getMarkerData: null,//点击地图标注回调方法
            markerDataId: "Id", //markerData主键
            fullScreen: null,//全屏事件,
            zoomEvent: null,
            gdzbdbx: false//拐点坐标和多边形显示
        };
        $.extend(defaluts, settings);
        var me = $(this);
        var id = me.attr("id");
        if (!id) {
            id = "map" + new Date().getTime();
            me.attr("id", id);
        }
        me.height(defaluts.mapheight);
        //me.width(defaluts.mapwidth);
        me.css({
            width: '100%'
        });
        var animationHtml = '<div id="css_animation" style="display:none"></div>';
        var layerList = new Array();
        var treeHtml = '', gisBtnHtml = '', gdzbdbxHtml = '';
        var isShowMapTools = defaluts.isShowTools;
        //图层树
        if (defaluts.isShowGisLayer) {
            treeHtml = '<div class="gislayerpop hide" style="min-width:150px;border-radius:5px;overflow-y:hidden;background-color:#fff;position:absolute;right:10px;top:42px;z-index:999999;border:solid 1px rgba(0, 0, 0, 0.07);over">' +
                            '<div style="padding:15px;border-bottom:1px solid rgba(0, 0, 0, 0.07);"><h4 style="margin-bottom: 0px;" >图层设置</h4></div>' +
                            '<div style="padding:5px;border-bottom:1px solid rgba(0, 0, 0, 0.07);">' +
                                '<h5 style="margin-bottom: 5px;">图层透明度设置：(<span class="opacity-value"></span>)</h5>' +
                                '<div class="opacity-set-wrap">' +
                                    '<div class="button-wrap"><button class="opacity-sub" title="减小" type="button"><i class="ti-minus"></i></button></div>' +
                                    '<div class="range-wrap"><input type="range" min="0" max="10" step="1" /></div>' +
                                    '<div class="button-wrap"><button class="opacity-add" title="增加" type="button"><i class="ti-plus"></i></button></div>' +
                                '</div>' +
                            '</div>' +
                            '<div id="itemTreeMap"></div>' +
                       '</div>';
            gisBtnHtml = '<span class="map_gislayer" data-toggle="tooltip" data-placement="bottom" title="GIS图层" ><i class="ti-layers-alt"></i></span>';
        }
        if (defaluts.gdzbdbx) {
            gdzbdbxHtml =
			'              <span class="map_gdzb" data-toggle="tooltip" data-placement="bottom" title="拐点坐标"><i class="fa fa-columns"></i></span>' +
            '              <span class="map_buffer"  data-toggle="tooltip" data-placement="bottom" title="线缓冲区"><i class="fa fa-map-o"></i></span>' +
	        '              <span class="map_circle_select"  data-toggle="tooltip" data-placement="bottom" title="地图框选(圆形)"><i class="fa fa-circle-thin"></i></span>' +
            '              <span class="map_rect_select" data-toggle="tooltip" data-placement="bottom" title="地图框选(矩形)"><i class="ti-layout-width-full"></i></span>' +
            '              <span class="map_poly_select"  data-toggle="tooltip" data-placement="bottom" title="地图框选(多边形)"><i class="fa fa-connectdevelop"></i></span>';
        }
        //地图上的显示模块的Html
        var html = animationHtml + '<div class="map_container">' + treeHtml +
			'      <div class="mapDiv"></div> ' +
			'      <div class="mapDivBtn"> ' +
			'              <span>地图</span>' +
			'              <span>卫星</span>' +
			'       </div>' +
			'      <div class="mapControllerBtn"> ' +
			gisBtnHtml +
            gdzbdbxHtml +
			'              <span class="map_length" data-toggle="tooltip" data-placement="bottom" title="测量距离"><i class="ti-ruler"></i></span>' +
			'              <span class="map_area"   data-toggle="tooltip" data-placement="bottom" title="测量面积"><i class="ti-ruler-alt-2"></i></span>' +
			'              <span class="map_reset"  data-toggle="tooltip" data-placement="bottom" title="复位"><i class="ti-back-right"></i></span>' +
			'              <span class="map_clear"  data-toggle="tooltip" data-placement="bottom" title="清理图层"><i class="ti-trash"></i></span>' +
			'              <span class="map_fullScreen" data-toggle="tooltip" data-placement="bottom" title="全屏"><i class="ti-fullscreen"></i></span>' +
			'       </div>' +
             '       <div id="div_buffer" style="width:176px;position: absolute;top: 40px;right: 134px;border-radius: 5px;border: 1px solid #007AFF;background: #fff;padding: 3px 6px;display:none;"><span>缓冲区半径:</span><input id="hcqbj" type="text" value=50000 class="form-control" style="width:60px;height:24px;display:inline-block;margin:0 5px" />m</div>' +
			' <div class=" map_zoom ol-zoom ol-unselectable ol-control"><button data-toggle="tooltip" data-placement="top" title="放大" type="button" class="ol-zoom-in map-zoom-in" id="zoomIn"><i class="ti-plus"/></button><button data-toggle="tooltip" data-placement="right" title="缩小" type="button" class="ol-zoom-out map-zoom-out"><i class="ti-minus"/></button></div>' +
			'</div>'
        me.html('');
        me.append(html);
        var count = me.find("#popup").length;
        if (count == 0) {
            var html = '<div class="ol-popup none" id="popup" style="display:none;">' + '<a href="#" id="popup-closer" class="ol-popup-closer"></a>' + '<div id="popup-content"></div></div>';
            me.append(html);
        }
        html = null;
        if (!defaluts.dataset) {
            return;
        }

        //地图的全局变量
        var vector = new ol.layer.Vector(),
			topName, chkId, select, dragBox, selectedFeatures,
			MeasureTool, isAgain = false,
			Layer, lyr = {},
			typeSelect = {},
			vectorLayer, vectorSource, locationLayer, getExtent, markerLayer, markerLayerExt, xzqhVectorLayer;
        var baseMap_map = defaluts.dataset.baseMap.map;
        var baseMap_note = defaluts.dataset.baseMap.note;
        var statellite_map = defaluts.dataset.statelliteMap.map;
        var statellite_note = defaluts.dataset.statelliteMap.note;
        var proviceMap, layerTemp = null, bufferFeature, shapeFeature, markerLayerCluster, dbxdrawTool, gdzbVectorLayer;

        //缓冲区数据源
        var vectorBufferSource = new ol.source.Vector({
            wrapX: false
        });
        var vectorBufferLayer = new ol.layer.Vector({
            source: vectorBufferSource
        });
        //边界
        var vectorDrawSource = new ol.source.Vector({
            wrapX: false
        });
        var vectorDrawLayer = new ol.layer.Vector({
            source: vectorDrawSource
        });
        if (defaluts.dataset.proviceMap) {
            proviceMap = defaluts.dataset.proviceMap;
        }
        //获取地图控件自定义的高度值
        var mapheight = defaluts.mapheight;

        typeSelect.check = false;

        //用来解决用户地图框选按钮重复点击事件
        isAgain = false;

        //设置地图容器
        var mapDiv = me.find("div.mapDiv");

        //动态的设置地图的高度
        mapDiv.css({
            height: mapheight
        });

        var tree = me.find("div.gislayerpop");
        if (tree) {
            tree.css({
                maxHeight: mapheight - 50
            });
        }
        //地图上的控件绑定事件
        var span = me.find(".mapDivBtn").find("span");
        span.click(function () {
            var index = $(this).index();
            if (index == 0) {
                changeMap(true);
            } else {
                changeMap(false);
            }
        });
        if (defaluts.isShowGisLayer) {
            var gislayer = me.find(".map_gislayer");
            gislayer.click(function () {
                var elem = me.find('div.gislayerpop');
                var eleCls = elem.attr("class");
                if (eleCls.indexOf("hide") > -1) {
                    elem.removeClass('hide');
                    currentState('map_gislayer');
                    if (draw) {
                        map.removeInteraction(draw); //移除之前的绘制对象
                    }
                } else {
                    elem.addClass('hide');
                    me.find("div.mapControllerBtn").find(".map_gislayer").css("background", "#fff");
                    me.find("div.mapControllerBtn").find(".map_gislayer").find("i").css("color", "#007AFF");
                }
            });
        }
        if (defaluts.isShowTools) {
            var map_length = me.find(".map_length");
            map_length.click(function () {
                measuremap('line', 'map_length');
            });
            var map_area = me.find(".map_area");
            map_area.click(function () {
                measuremap('area', 'map_area');
            });
            var map_reset = me.find(".map_reset");
            map_reset.click(function () {
                var elem = me.find('div.gislayerpop');
                if (elem.length > 0) {
                    var eleCls = elem.attr("class");
                    if (eleCls.indexOf("hide") == -1) {
                        elem.addClass('hide');
                    }
                }
                reset('map_reset');
            });
            var map_clear = me.find(".map_clear");
            map_clear.click(function () {
                clearMap('map_clear');
                WKTString = {};
                if (draw) {
                    map.removeInteraction(draw); //移除之前的绘制对象
                    MeasureTool.getExtent = null;
                }
                if (dbxdrawTool) {
                    map.removeInteraction(dbxdrawTool);
                }
                if (gdzbVectorLayer) {
                    gdzbVectorLayer.getSource().clear(gdzbVectorLayer.getSource().getFeatures());
                    map.removeLayer(gdzbVectorLayer);
                }
                if (me.find("#popup").length == 0) {
                    var html = '<div class="ol-popup none" id="popup" style="display:none;">' + '<a href="#" id="popup-closer" class="ol-popup-closer"></a>' + '<div id="popup-content"></div></div>';
                    me.append(html);
                }
                if (me.find("#css_animation").length == 0) {
                    me.append(animationHtml);
                }
            });
            var map_fullScreen = me.find(".map_fullScreen");
            map_fullScreen.click(function () {
                var elem = me.find('div.gislayerpop');
                if (elem.length > 0) {
                    var eleCls = elem.attr("class");
                    if (eleCls.indexOf("hide") == -1) {
                        elem.addClass('hide');
                    }
                    me.find("div.mapControllerBtn").find(".map_gislayer").css("background", "#fff");
                    me.find("div.mapControllerBtn").find(".map_gislayer").find("i").css("color", "#007AFF");
                }

                if (me.fullScreen) {
                    me.fullScreen({
                        background: '#FFFFFF',
                        eleHeight: me.height(),
                        eleMap: map,
                        callback: function (fullState, eHeight) {
                            if (fullState) {
                                me.height($(window).height());
                                mapDiv.css({
                                    height: me.height()
                                });
                            } else {
                                if (eHeight) {
                                    me.height(eHeight);
                                    mapDiv.css({
                                        height: eHeight
                                    });
                                }
                            }
                            map.updateSize();
                        }
                    });
                }
            });
            var map_gdzb = me.find(".map_gdzb");
            map_gdzb.click(function () {
                if (dbxdrawTool) {
                    map.removeInteraction(dbxdrawTool);
                }
                currentState("map_gdzb");
                removeAllOverlay(map);
                removeMarker();
                clearMeasureVector();
                if (draw) {
                    map.removeInteraction(draw); //移除之前的绘制对象
                    MeasureTool.getExtent = null;
                }
                learun.dialogOpen({
                    id: "kneecoordinate2",
                    title: '拐点坐标',
                    url: '/Content/scripts/plugins/Kneecoordinate/gdzb',
                    width: "680px",
                    height: "510px",
                    callBack: function (iframeId) {
                        getInfoTop().frames[iframeId].AcceptClick(function (data, dbxgdzbs) {
                            WKTString = dbxgdzbs;
                            if (data) {
                                data[0]['fillColor'] = 'transparent';
                                data[0]['strokeColor'] = '#007AFF';
                                gdzbaAddTagging(data);
                                map.getView().setCenter(data[0].coordinates[0]);
                                map.getView().setZoom(5);//地图定位放大
                            }
                        });

                    }
                });
            });
            //拐点坐标框选独用
            function gdzbaAddTagging(GDZBArr) {
                if (gdzbVectorLayer) {
                    gdzbVectorLayer.getSource().clear(gdzbVectorLayer.getSource().getFeatures());
                    map.removeLayer(gdzbVectorLayer);
                }
                gdzbVectorLayer = new ol.layer.Vector({
                    source: new ol.source.Vector()
                });
                var fillColor = 'rgba(252, 216, 107, 0.35)';
                var strokeColor = '#ffcc33';
                for (var i = 0; i < GDZBArr.length; i++) {
                    var data = GDZBArr[i];
                    if (data.coordinates.length == 0) {
                        continue;
                    }
                    if (data.fillColor) {
                        fillColor = data.fillColor;
                    }
                    if (data.strokeColor) {
                        strokeColor = data.strokeColor;
                    }
                    var coordinates = [[data.coordinates]];
                    var iconFeature = new ol.Feature({
                        geometry: new ol.geom.MultiPolygon(coordinates),
                        name: '拐点坐标标注' + (i + 1),
                        population: 4000,
                        rainfall: 500,
                        id: (i + 1)
                    });
                    iconStyle = new ol.style.Style({
                        fill: new ol.style.Fill({
                            color: fillColor
                        }),
                        stroke: new ol.style.Stroke({
                            color: strokeColor,
                            width: 2
                        }),
                        image: new ol.style.Circle({
                            radius: 7,
                            fill: new ol.style.Fill({
                                color: '#ffcc33'
                            })
                        })
                    });
                    iconFeature.setStyle(iconStyle);
                    gdzbVectorLayer.getSource().addFeature(iconFeature);
                    gdzbVectorLayer.setZIndex(20);
                };
                map.addLayer(gdzbVectorLayer);
            };

            var map_buffer = me.find(".map_buffer");
            $("#hcqbj").change(function () {
                if (!bufferFeature) {
                    return;
                }
                createBuffer(bufferFeature);
            });
            map_buffer.click(function () {
                bufferFeature = null; dbxdrawTool = null;
                measuremap('line', 'map_buffer', function (feature, drawTool) {
                    //生成缓冲区
                    bufferFeature = feature;
                    dbxdrawTool = drawTool;
                    createBuffer(feature);
                    map.removeInteraction(drawTool);
                });
            });

            function createBuffer(feature) {
                vectorBufferSource.clear();
                var reader = new jsts.io.WKTReader();
                var parser = new jsts.io.OL3Parser();
                var wktOLReader = new ol.format.WKT();
                var featureWKT = wktOLReader.writeFeature(feature);
                var value = parseFloat($("#hcqbj").val());
                var hudu = value / 1000.0 / 111.3195;
                WKTString = { polyline: featureWKT, radius: value };
                var featuretmmp = reader.read(featureWKT).buffer(hudu, 30);
                var styleBuffer = new ol.style.Style({
                    fill: new ol.style.Fill({
                        color: 'rgba(211, 211, 211, 0.5)'
                    }),
                    stroke: new ol.style.Stroke({
                        color: 'transparent',
                        width: 2
                    }),
                    image: new ol.style.Circle({
                        radius: 7,
                        fill: new ol.style.Fill({
                            color: '#007AFF'
                        })
                    })
                });
                var feat = new ol.Feature({
                    geometry: parser.write(featuretmmp.getGeometryN(0))
                });
                feat.setStyle(styleBuffer);
                vectorBufferSource.addFeature(feat);
            };

            var map_circle_select = me.find(".map_circle_select");
            map_circle_select.click(function () {
                shapeFeature = null; dbxdrawTool = null;
                measuremap('circle', 'map_circle_select', function (feature, drawTool) {
                    shapeFeature = feature;
                    dbxdrawTool = drawTool;
                    featureData(feature)
                    map.removeInteraction(drawTool);
                });
            });

            var map_rect_select = me.find(".map_rect_select");
            map_rect_select.click(function () {
                shapeFeature = null; dbxdrawTool = null;
                measuremap('box', 'map_rect_select', function (feature, drawTool) {
                    shapeFeature = feature;
                    dbxdrawTool = drawTool;
                    featureData(feature);
                    map.removeInteraction(drawTool);
                });
            });

            var map_poly_select = me.find(".map_poly_select");
            map_poly_select.click(function () {
                shapeFeature = null; dbxdrawTool = null;
                measuremap('area', 'map_poly_select', function (feature, drawTool) {
                    shapeFeature = feature;
                    dbxdrawTool = drawTool;
                    featureData(feature);
                    map.removeInteraction(drawTool);
                });
            });


        } else {
            me.find(".mapControllerBtn").hide();
        }
        //提示生效
        me.find("[data-toggle='tooltip']").tooltip();
        //feature数据处理多边形矩形圆
        function featureData(feature) {
            var geom = feature.getGeometry();
            if (geom.getType() == 'Circle') {
                var condition = geom.getCenter();
                var radius = geom.getRadius();
                WKTString = { x: condition[0], y: condition[1], radius: radius }
            } else {
                var points = geom.getCoordinates();
                var str = '';
                for (var i = 0; i < points[0].length; i++) {
                    str += points[0][i][0] + ' ' + points[0][i][1]
                    if (i < points[0].length - 1) {
                        str += ',';
                    }
                }
                WKTString = { WKTString: 'POLYGON((' + str + '))' };
            }
        }
        //设置起始显示视图
        (function loadMap() {
            if (map != undefined) {
                var layers = map.getLayers.getArray();
                layers.forEach(function (e) {
                    map.removeLayer(e);
                });
            };
            var zjLayer = "";
            switch (defaluts.baseLayer) {
                case "LAN":  //内网
                    //起始底图
                    map = NewWebTilesMap(mapDiv[0], baseMap_map.zoomlevel, 180, -180, -90, 90, baseMap_map.dataserverkey, baseMap_map.url, baseMap_map.tilesize, baseMap_map.zerolevelsize, 'baseLayer', defaluts.extent);
                    //加注记
                    zjLayer = new iTelluro().newItelluroLayer(baseMap_note.dataserverkey, baseMap_note.url, baseMap_note.tilesize, baseMap_note.zerolevelsize, 'zjLayer', defaluts.extent);
                    break;
                case "WAN":  //外网
                    //起始底图
                    map = new TianDiTu().NewWebTilesMap(mapDiv[0], baseMap_map.zoomlevel, 180, -180, -90, 90, baseMap_map.sourcePackageKey, baseMap_map.url, baseMap_map.tilesize, baseMap_map.zerolevelsize, 'baseLayer');
                    //加注记
                    zjLayer = createLayerOnline(baseMap_note.sourcePackageKey, baseMap_note.url, 'zjLayer');
                    break;
                case "OFFLINE":  //离线
                    //起始底图
                    map = NewLocalTilesMap(mapDiv[0], baseMap_map.zoomlevel, 180, -180, -90, 90, baseMap_map.url, baseMap_map.tilesize, baseMap_map.zerolevelsize, 'baseLayer', baseMap_map.imageType);
                    //加注记
                    zjLayer = new iTelluro().newLocalTilesLayer(baseMap_note.url, baseMap_note.tilesize, baseMap_note.zerolevelsize, 'zjLayer', baseMap_note.imageType);
                    break;
                default:
                    //起始底图
                    map = NewWebTilesMap(mapDiv[0], baseMap_map.zoomlevel, 180, -180, -90, 90, baseMap_map.dataserverkey, baseMap_map.url, baseMap_map.tilesize, baseMap_map.zerolevelsize, 'baseLayer', defaluts.extent);
                    //加注记
                    zjLayer = new iTelluro().newItelluroLayer(baseMap_note.dataserverkey, baseMap_note.url, baseMap_note.tilesize, baseMap_note.zerolevelsize, 'zjLayer', defaluts.extent);
                    break;
            }
            zjLayer.setZIndex(18);
            map.addLayer(zjLayer);
            if (proviceMap) {
                if (proviceMap.url) {
                    var pLayer = new iTelluro().newItelluroLayer(proviceMap.dataserverkey, proviceMap.url, proviceMap.tilesize, proviceMap.zerolevelsize, 'pLayer', defaluts.extent);
                    pLayer.setZIndex(19);
                    pLayer.setOpacity(proviceMap.opacity);
                    map.addLayer(pLayer);
                }
            };

            vectorBufferLayer.setZIndex(20);
            map.addLayer(vectorBufferLayer);
            vectorDrawLayer.setZIndex(19);
            map.addLayer(vectorDrawLayer);
            changeColor(0, 1);
            initMapControl();
            if (defaluts.isShowGisLayer) {
                LoadLayerTree();
            }

            //设置中心点
            if (defaluts.center != null && defaluts.center != undefined) {
                map.getView().setCenter(defaluts.center);
            } else {
                map.getView().setCenter([94, 30]);
            }
            //监听放大缩小
            var mapView = map.getView();
            var oldZoom = -10;
            mapView.on("change:resolution", function (event) {
                if (!defaluts.dataset.mapRanges) {
                    return;
                }
                var zoom = mapView.getZoom();
                var extent = mapView.calculateExtent(map.getSize());
                var XZJB = "";
                var tmp1 = 0;
                var tmp = -10;
                for (var i = 0; i < defaluts.dataset.mapRanges.length; i++) {
                    var range = defaluts.dataset.mapRanges[i];
                    if (oldZoom >= range.RangeLow && oldZoom < range.RangeHigh) {
                        tmp = i;
                    }
                    if (zoom >= range.RangeLow && zoom < range.RangeHigh) {
                        tmp1 = i;
                        XZJB = range.RangeName;
                    }
                }

                if (defaluts.zoomEvent && (tmp1 != tmp)) {
                    defaluts.zoomEvent(zoom, XZJB, extent, addMarkerCluster);
                }
                oldZoom = zoom;
            });

            map.getView().setZoom(defaluts.zoom);
        }());

        function createLayerOnline(sourcePackageKey, url, layerName) {
            var layer;
            switch (sourcePackageKey) {
                case "vec_c":  //矢量地图
                    layer = new TianDiTu().newWebVectorLayer(url, layerName);
                    break;
                case "cva_c":  //矢量地图注记
                    layer = new TianDiTu().newWebVectorLabelLayer(url, layerName);
                    break;
                case "img_c":  //影像地图
                    layer = new TianDiTu().newWebImageLayer(url, layerName);
                    break;
                case "cia_c":  //影像地图注记
                    layer = new TianDiTu().newWebImageLabelLayer(url, layerName);
                    break;
                default:
                    break;
            }
            return layer;
        };

        /** 添加地图上的一些控件  **/
        function initMapControl() {
            //2.1显示坐标
            map.addControl(new ol.control.MousePosition({
                className: 'map_mouse-position',
                undefinedHTML: '',
                projection: 'EPSG:4326',
                coordinateFormat: function (coordinate) {
                    return ol.coordinate.format(coordinate, '{x}, {y}', 4);
                }
            }));
            //2.2添加全屏控件
            if (!defaluts.isFrame) {
                var fullScreen = me.find(".map_fullScreen");
                map.addControl(new ol.control.FullScreen({
                    element: fullScreen[0],
                    exitFullScreenBackFun: function () {
                        mapDiv.css({
                            height: defaluts.mapheight
                        });
                    }
                }));
            }
            //2.3添加地图缩放
            var zoomIn = me.find("#zoomIn");
            var zoomOut = me.find(".map-zoom-out");
            zoomOut.click(function () {
                var zoom = map.getView().getZoom();
                map.getView().setZoom(zoom - 1);
            });
            zoomIn.click(function () {
                var zoom = map.getView().getZoom();
                map.getView().setZoom(zoom + 1);
            });
            //map.addControl(new ol.control.Zoom({
            //	element: {
            //		zoomIn: zoomIn,
            //		zoomOut: zoomOut
            //	}
            //}));
            //2.4比例尺
            map.addControl(new ol.control.ScaleLine());
            //2.5调用工具（画圆|画方|画多边形)
            MeasureTool = new ol.control.MeasureTool();
            MeasureTool.vector.setZIndex(30);
            map.addLayer(MeasureTool.vector);
            map.addControl(MeasureTool);
        };

        //加载图层树
        function LoadLayerTree() {
            var treeNode = defaluts.dataset.gisLayer;
            if ((typeof defaluts.dataset.gisLayer == 'string') && defaluts.dataset.gisLayer.constructor == String) {
                treeNode = JSON.parse(defaluts.dataset.gisLayer);
            }
            forEachGisData(treeNode);
            var item = {
                height: defaluts.mapheight - 150,
                showcheck: true,
                //icons: ["checkbox_0.gif", "checkbox_1.gif", "checkbox_2.gif"],
                data: treeNode,
                oncheckboxclick: function (item, status) {
                    if (item.parentnodes == "0000") {
                        //recursions(node.children);
                    } else {
                        chkId = item.id;
                        var node = item.value;
                        if ((typeof item.value == 'string') && item.value.constructor == String) {
                            var json = item.value.replace(/'/g, '"');
                            node = JSON.parse(json);
                        }
                        layerList[chkId] = loadLayer(map, item.text, layerList[chkId], status, node.dataserverkey, node.url, node.tilesize, node.zerolevelsize, node.opacity);
                    }
                },
                onnodeclick: function (item) {
                    layerTemp = null;
                    if (item.parentnodes == "0000") {
                        layerTemp = null;
                    } else {
                        var layerName = item.text;
                        var node = item.value;
                        if ((typeof item.value == 'string') && item.value.constructor == String) {
                            var json = item.value.replace(/'/g, '"');
                            node = JSON.parse(json);
                        }
                        layerName = node.dataserverkey;
                        var maplayers = map.getLayers().getArray();
                        maplayers.forEach(function (layer) {
                            if (layer.get("name") == layerName) {
                                layerTemp = layer;
                                var opc = layer.getOpacity();
                                _range.val(opc * 10);
                                $(".opacity-value").text(parseFloat(opc).toFixed(1));
                            }
                        });
                    }
                }
            };
            me.find("#itemTreeMap").treeview(item);
        };

        //图层透明度设置
        var _range = $(".opacity-set-wrap").find("input[type='range']");
        var _value = _range.val();
        _range.css("background-size", parseInt(_value * 10) + "% 100%");
        function opacityVal(value) {
            var _opacity = parseFloat(value / 10).toFixed(1);
            $(".opacity-value").text(_opacity);
            if (layerTemp) {
                layerTemp.setOpacity(_opacity);
            }
        };
        opacityVal(_value);
        $(".opacity-set-wrap").find("button").click(function () {
            var _Value = parseInt($(".opacity-value").text() * 10);
            if ($(this).hasClass("opacity-sub")) {
                _Value--;
                _Value = _Value < 0 ? 0 : _Value;
            } else {
                _Value++;
                _Value = _Value > 10 ? 10 : _Value;
            }
            _range.val(_Value);
            _range.css("background-size", parseInt(_Value * 10) + "% 100%");
            opacityVal(_Value);
        });
        _range.change(function (a) {
            _value = a.target.value;
            opacityVal(_value);
            $(this).css("background-size", parseInt(_value * 10) + "% 100%");
        });

        //距离测量|面积测量|画圆|画方
        function measuremap(measure, className, callback) {
            WKTString = {};
            //确定当前操作目标
            typeSelect.value = measure;
            MeasureTool.mapmeasure(typeSelect, callback);
            //双向绑定赋值
            getExtent = MeasureTool.getExtent;
            currentState(className);
        };

        function clearMeasureVector() {
            var maplayers = map.getLayers().getArray();
            maplayers.forEach(function (obj) {
                if (obj.get("name") === "drawCLayerName") {
                    obj.getSource().clear();
                }
            });
        };

        //清空图层
        function clearDraw() {
            removeAllOverlay(map);
            removeMarker();
            removeCustomMarker();
            removeCustomMarkerExt();
            removeClusterMarker();
            clearMeasureVector();
        };

        function changeMap(flag) {
            if (flag) {
                changeColor(0, 1);
                setLayer(baseMap_map, baseMap_note);
            } else {
                changeColor(1, 0);
                setLayer(statellite_map, statellite_note);
            }
        };

        /**.图层切换具体实现------remove掉以前的layer设置新的layer **/
        function setLayer(mapdata, notedata) {
            var newBaseLayer, newZjLayer;
            removeAllLayer({
                base: "baseLayer",
                zj: "zjLayer"
            });
            //底图
            newBaseLayer = new iTelluro().newItelluroLayer(mapdata.dataserverkey, mapdata.url, mapdata.tilesize, mapdata.zerolevelsize, 'baseLayer', defaluts.extent);
            //加注记   
            newZjLayer = new iTelluro().newItelluroLayer(notedata.dataserverkey, notedata.url, notedata.tilesize, notedata.zerolevelsize, 'zjLayer', defaluts.extent);

            switch (defaluts.baseLayer) {
                case "LAN":  //内网
                    //底图
                    newBaseLayer = new iTelluro().newItelluroLayer(mapdata.dataserverkey, mapdata.url, mapdata.tilesize, mapdata.zerolevelsize, 'baseLayer', defaluts.extent);
                    //加注记   
                    newZjLayer = new iTelluro().newItelluroLayer(notedata.dataserverkey, notedata.url, notedata.tilesize, notedata.zerolevelsize, 'zjLayer', defaluts.extent);

                    break;
                case "WAN":  //外网
                    //底图
                    newBaseLayer = createLayerOnline(mapdata.sourcePackageKey, mapdata.url, 'baseLayer');
                    //加注记
                    newZjLayer = createLayerOnline(notedata.sourcePackageKey, notedata.url, 'zjLayer');
                    break;
                case "OFFLINE":  //离线
                    //底图
                    newBaseLayer = new iTelluro().newLocalTilesLayer(mapdata.url, mapdata.tilesize, mapdata.zerolevelsize, 'baseLayer', mapdata.imageType);
                    //加注记   
                    newZjLayer = new iTelluro().newLocalTilesLayer(notedata.url, notedata.tilesize, notedata.zerolevelsize, 'zjLayer', notedata.imageType);
                    break;
                default:
                    //底图
                    newBaseLayer = new iTelluro().newItelluroLayer(mapdata.dataserverkey, mapdata.url, mapdata.tilesize, mapdata.zerolevelsize, 'baseLayer', defaluts.extent);
                    //加注记   
                    newZjLayer = new iTelluro().newItelluroLayer(notedata.dataserverkey, notedata.url, notedata.tilesize, notedata.zerolevelsize, 'zjLayer', defaluts.extent);
                    break;
            }
            newBaseLayer.setZIndex(0);
            newBaseLayer.setOpacity(mapdata.opacity);
            map.addLayer(newBaseLayer);
            newZjLayer.setZIndex(18);
            newZjLayer.setOpacity(notedata.opacity);
            map.addLayer(newZjLayer);
        };

        /** 根据name值切换移除底图 **/
        function removeAllLayer(obj) {
            var arr = map.getLayers().getArray();
            var len = arr.length;
            for (var i = 0; i < len; i++) {
                if (!arr[i]) {
                    return;
                }
                if (arr[i].get("name") === obj.base || arr[i].get("name") === obj.zj)
                    map.removeLayer(arr[i]);
            }
        };

        //移除图层上所有覆盖物
        function removeAllOverlay(map) {
            map.getOverlays().getArray().slice(0).forEach(function (overlay) {
                map.removeOverlay(overlay);
            })
        };

        //清除定位的marker
        function removeMarker() {
            if (locationLayer) {
                var point_div = me.find("#css_animation")[0];
                if (point_div) {
                    point_div.style.display = 'none';
                }
                map.removeLayer(locationLayer);
            }
        };

        //清空自定义的marker
        function removeCustomMarker() {
            if (markerLayer) {
                markerLayer.getSource().clear(markerLayer.getSource().getFeatures());
                map.removeLayer(markerLayer);
            }
        };

        //清空自定义的marker
        function removeCustomMarkerExt() {
            if (markerLayerExt) {
                markerLayerExt.getSource().clear(markerLayerExt.getSource().getFeatures());
                map.removeLayer(markerLayerExt);
            }
        };

        //清空自定义的marker
        function removeClusterMarker() {
            if (markerLayerCluster) {
                markerLayerCluster.getSource().clear(markerLayerCluster.getSource().getFeatures());
                map.removeLayer(markerLayerCluster);
            }
        };

        //地图按钮样式切换实现
        function changeColor(index0, index1) {
            me.find(".mapDivBtn").find("span").eq(index0).addClass("map_active");
            me.find(".mapDivBtn").find("span").eq(index1).removeClass("map_active");
        }

        //地图上清理图层：
        function clearMap(className) {
            currentState(className);
            removeAllOverlay(map);
            removeMarker();
            clearMeasureVector();
        }
        //地图上清理矢量图层：
        function clearMapFeature() {
            removeAllOverlay(map);
            clearMeasureVector();
        }

        //复位
        function reset(cls) {
            map.getView().setCenter(defaluts.center);
            map.getView().setZoom(defaluts.zoom);
            //currentState(cls);
            me.find("div.mapControllerBtn").find("span").css("background", "#fff");
            me.find("div.mapControllerBtn").find("span").find("i").css("color", "#007AFF");
            if (draw) {
                map.removeInteraction(draw); //移除之前的绘制对象
            }
        };

        //标注当前界面状态
        function currentState(className) {
            if (!className) {
                return;
            }
            if (className != "map_gislayer") {
                var elem = me.find('div.gislayerpop');
                if (elem.length > 0) {
                    var eleCls = elem.attr("class");
                    if (eleCls.indexOf("hide") == -1) {
                        elem.addClass('hide');
                    }
                }
            }
            var spanobj = me.find("div.mapControllerBtn").find("span." + className);
            var bjThis = spanobj.css("background-color");
            me.find("div.mapControllerBtn").find("span").css("background", "#fff");
            me.find("div.mapControllerBtn").find("span").find("i").css("color", "#007AFF");
            vectorBufferSource.clear();
            bufferFeature = null;
            if (bjThis == "rgb(255, 255, 255)" || bjThis == "rgba(0, 0, 0, 0)") {
                spanobj.css("background", "#007AFF");
                spanobj.find("i").css("color", "#fff");
                if (className == "map_buffer") {
                    $("#div_buffer").show();
                } else {
                    $("#div_buffer").hide();
                }
            } else {
                if (draw && className) {
                    map.removeInteraction(draw); //移除之前的绘制对象
                    $("#div_buffer").hide();
                }
            }
        }

        /********树的显示与隐藏******************/
        var isAncestorOrSelf = function (element, target) {
            var parent = element;
            while (parent.length > 0) {
                if (parent[0] === target[0]) {
                    return true;
                }
                parent = parent.parent();
            }
            return false;
        };

        var closeOnOuterClicks = function (e) {
            var elem = me.find('div.gislayerpop');
            if (me.find(e.target).hasClass('map_gislayer') || me.find(e.target).parent().hasClass('map_gislayer')) {
                elem.removeClass('hide');
                currentState('map_gislayer');
                return;
            }
            if (!isAncestorOrSelf(me.find(e.target), elem)) {
                elem.addClass('hide');
                me.find("div.mapControllerBtn").find(".map_gislayer").css("background", "#fff");
                me.find("div.mapControllerBtn").find(".map_gislayer").find("i").css("color", "#007AFF");
            }
        };

        //加载图层
        function loadLayer(map, topName, layer, ck, dataServerKey, url, tileSize, zeroLevelSize, opacity) {
            if (!layer) {
                layer = new iTelluro().newItelluroLayer(dataServerKey, url, tileSize, zeroLevelSize, dataServerKey, defaluts.extent);
                layer.setZIndex(22);
                layer.setOpacity(opacity);
                map.getView().setZoom(0);
                map.addLayer(layer);
            }
            if (!ck) {
                map.removeLayer(layer);
                layer = null;
            }
            return layer;
        };
        //循环遍历gis数据
        function forEachGisData(data) {
            $.each(data, function (i, e) {
                if (e.checkstate) {
                    loadDefaultGisLauer(e);
                }
                if (e.ChildNodes.length > 0) {
                    forEachGisData(e.ChildNodes);
                }
            });
        };
        //初始化加载gis图层
        function loadDefaultGisLauer(data) {
            data.value = data.value.replace(/'/g, '"');
            data.value = JSON.parse(data.value);
            layerList[data.id] = loadLayer(map, data.text, layerList[data.id], data.checkstate, data.value.dataserverkey, data.value.url, data.value.tilesize, data.value.zerolevelsize, data.value.opacity);
        };

        /** 监听地图点击事件 **/
        map.on("click", function (evt) {
            if (defaluts.clickCallBack) {
                var lonlat = evt.coordinate;
                var px = lonlat.toString();
                var lon = new Number(px.split(',')[0]);
                lon = lon.toFixed(4);
                var lat = new Number(px.split(',')[1]);
                lat = lat.toFixed(4);
                defaluts.clickCallBack(lon, lat);
            }
            closeOnOuterClicks(evt);
            var pixel = map.getEventPixel(evt.originalEvent);
            var feature = map.forEachFeatureAtPixel(pixel, function (feature) {
                return feature;
            });
            if (!feature) {
                return;
            }
            var features = feature.get('features');
            if (defaluts.isCluster && features && features.length > 0) {
                if (features.length == 1) {
                    feature = features[0];
                } else {
                    var zoom = map.getView().getZoom();
                    if (features.length > 10) {
                        map.getView().setZoom(zoom + 2);
                    } else {
                        map.getView().setZoom(zoom + 1);
                    }
                    var coordinate = features[0].getGeometry().getCoordinates();
                    map.getView().setCenter(coordinate)
                    return;
                }
            }
            var coordinate;
            if (feature.obj) {
                //marker点击列表添加或选中行
                if (defaluts.getMarkerData && typeof (eval(defaluts.getMarkerData)) == "function") {
                    defaluts.getMarkerData($(feature.obj).find("#" + defaluts.markerDataId).val());
                }
                coordinate = feature.getGeometry().getCoordinates();
                //选择拐点坐标bug修改
                var count = me.find("#popup").length;
                if (count == 0) {
                    var html = '<div class="ol-popup none" id="popup" style="display:none;">' + '<a href="#" id="popup-closer" class="ol-popup-closer"></a>' + '<div id="popup-content"></div></div>';
                    me.append(html);
                }
                var popup_element = me.find("#popup")[0];
                var popup_content = me.find("#popup-content")[0];
                popup_element.style.display = 'block';
                popup_content.innerHTML = feature.obj;
                var info_popup = new ol.Overlay(({
                    element: popup_element,
                    autoPan: true,
                    autoPanAnimation: {
                        duration: 250
                    }
                }));
                map.addOverlay(info_popup);
                if (coordinate.length !== 2) {
                    coordinate = evt.coordinate;
                }
                info_popup.setPosition(coordinate);
                me.find("#popup").find("#popup-closer").click(function (evt) {
                    evt.preventDefault();
                    info_popup.setPosition(undefined);
                });
            } else {
                return;
            }
        });

        map.on('postcompose', function (event) {
            changeMapData(event.context);
        });

        var wktOLReaderALL = new ol.format.WKT();
        var boundPolygon = null;
        if (defaluts.boundWKT && defaluts.boundWKT[0].length > 0) {
            boundPolygon = wktOLReaderALL.readFeature(defaluts.boundWKT[0]).getGeometry();
        }
        //改变地图数据
        function changeMapData(context) {
            if (!boundPolygon) {
                return;
            }
            var geoType = boundPolygon.getType();
            var coors = boundPolygon.getCoordinates();
            var pointArr = [];
            if (geoType == "Polygon") {
                for (var i = 0; i < coors.length; i++) {
                    var coorTmp = coors[i];
                    var pointTmp = [];
                    for (var j = 0; j < coorTmp.length; j++) {
                        pointTmp.push(map.getPixelFromCoordinate(coorTmp[j]));
                    }
                    pointArr.push(pointTmp);
                }

            } else if (geoType == "MultiPolygon") {
                for (var i = 0; i < coors.length; i++) {
                    var coorTmp = coors[i][0];
                    var pointTmp = [];
                    for (var j = 0; j < coorTmp.length; j++) {
                        pointTmp.push(map.getPixelFromCoordinate(coorTmp[j]));
                    }
                    pointArr.push(pointTmp);
                }
            }
            context.save();
            context.globalCompositeOperation = "destination-in";
            context.beginPath();
            for (var i = 0; i < pointArr.length; i++) {
                var pointTmp = pointArr[i];
                for (var j = 0; j < pointTmp.length; j++) {
                    if (j == 0) {
                        context.moveTo(pointTmp[j][0], pointTmp[j][1]);
                    } else {
                        context.lineTo(pointTmp[j][0], pointTmp[j][1]);
                    }
                }
            }
            context.closePath();
            context.fillStyle = "#ff0000ff";
            context.fill();
            context.restore();
        }

        //添加矢量标注(点线面)
        function addTagging(type, coordinates, popHtml, vectorArr) {
            if (vectorLayer != null) {
                vectorLayer.getSource().clear(vectorLayer.getSource().getFeatures());
                map.removeLayer(vectorLayer);
            }
            var geometry;
            if (type === 'MultiPolygon') {
                coordinates = [
					[coordinates]
                ];
                geometry = new ol.geom.MultiPolygon(coordinates);
            } else if (type === 'Point') {
                geometry = new ol.geom.Point(coordinates);
            } else {
                return;
            }
            var name = "拐点坐标标注", color = 'rgba(252, 216, 107, 0.35)';
            if (vectorArr) {
                name = vectorArr.name;
                color = vectorArr.color;
            }
            var iconFeature = new ol.Feature({
                geometry: geometry,
                name: name,
                population: 4000,
                rainfall: 500
            });
            var iconStyle = new ol.style.Style({
                fill: new ol.style.Fill({
                    color: color
                }),
                stroke: new ol.style.Stroke({
                    color: '#ffcc33',
                    width: 2
                }),
                image: new ol.style.Circle({
                    radius: 7,
                    fill: new ol.style.Fill({
                        color: '#ffcc33'
                    })
                })
            });
            iconFeature.obj = popHtml;
            iconFeature.setStyle(iconStyle);

            vectorSource = new ol.source.Vector({});
            vectorSource.addFeature(iconFeature);
            vectorLayer = new ol.layer.Vector({
                source: vectorSource
            });
            map.addLayer(vectorLayer);
        };

        //追加矢量标注(点线面)
        function appendTagging(type, coordinates, popHtml, vectorArr) {
            if (!vectorLayer) {
                return;
            }
            var geometry;
            if (type === 'MultiPolygon') {
                coordinates = [
					[coordinates]
                ];
                geometry = new ol.geom.MultiPolygon(coordinates);
            } else if (type === 'Point') {
                geometry = new ol.geom.Point(coordinates);
            } else {
                return;
            }
            var name = "拐点坐标标注", color = 'rgba(252, 216, 107, 0.35)';
            if (vectorArr) {
                name = vectorArr.name;
                color = vectorArr.color;
            }
            var iconFeature = new ol.Feature({
                geometry: geometry,
                name: name,
                population: 4000,
                rainfall: 500
            });
            var iconStyle = new ol.style.Style({
                fill: new ol.style.Fill({
                    color: color
                }),
                stroke: new ol.style.Stroke({
                    color: '#ffcc33',
                    width: 2
                }),
                image: new ol.style.Circle({
                    radius: 7,
                    fill: new ol.style.Fill({
                        color: '#ffcc33'
                    })
                })
            });
            iconFeature.obj = popHtml;
            iconFeature.setStyle(iconStyle);
            vectorLayer.getSource().addFeatures(iconFeature);
            map.render();
        };

        function addTaggingArr(GDZBArr) {
            if (vectorLayer) {
                vectorLayer.getSource().clear(vectorLayer.getSource().getFeatures());
                map.removeLayer(vectorLayer);
            }
            vectorLayer = new ol.layer.Vector({
                source: new ol.source.Vector()
            });
            var fillColor = 'rgba(252, 216, 107, 0.35)';
            var strokeColor = '#ffcc33';
            for (var i = 0; i < GDZBArr.length; i++) {
                var data = GDZBArr[i];
                if (data.coordinates.length == 0) {
                    continue;
                }
                if (data.fillColor) {
                    fillColor = data.fillColor;
                }
                if (data.strokeColor) {
                    strokeColor = data.strokeColor;
                }
                var coordinates = [[data.coordinates]];
                var iconFeature = new ol.Feature({
                    geometry: new ol.geom.MultiPolygon(coordinates),
                    name: '拐点坐标标注' + (i + 1),
                    population: 4000,
                    rainfall: 500,
                    id: (i + 1)
                });
                iconStyle = new ol.style.Style({
                    fill: new ol.style.Fill({
                        color: fillColor
                    }),
                    stroke: new ol.style.Stroke({
                        color: strokeColor,
                        width: 2
                    }),
                    image: new ol.style.Circle({
                        radius: 7,
                        fill: new ol.style.Fill({
                            color: '#ffcc33'
                        })
                    })
                });
                iconFeature.obj = data.popHtml;
                iconFeature.setStyle(iconStyle);
                vectorLayer.getSource().addFeature(iconFeature);
                vectorLayer.setZIndex(20);
            };
            map.addLayer(vectorLayer);
        };

        /** 加marker图片标注根据一组坐标和marker的图片地址来显示 **/
        function addMarker(markerArr) {
            //清空定为
            removeMarker();
            //清空标注
            removeCustomMarker();
            //markerArr验证判断
            if (!markerArr) return;
            var features = [];
            //第一步设置style
            //第二部创建featuare并设置好在地图上的位置及样式
            markerArr.forEach(function (data, index) {
                var feature = new ol.Feature({
                    geometry: new ol.geom.Point(data.location),
                    id: index++
                });

                var style = new ol.style.Style({
                    image: new ol.style.Icon({
                        src: data.url
                    })
                });
                var html = '<div class="ol-popup none" id="popup">' + '<a href="#" id="popup-closer" class="ol-popup-closer"></a>' + '<div id="popup-content"></div></div>';
                feature.obj = data.popupHtml;
                //设置样式在样式中既可以设置图标
                feature.setStyle(style);
                //添加到之前创建的layer中
                features.push(feature);
            });
            //第三步source添加到layer
            var source = new ol.source.Vector({
                features: features
            });

            if (defaluts.isCluster) {
                var clusterSource = new ol.source.Cluster({
                    distance: parseInt(defaluts.distance, 10),
                    source: source
                });
                var styleCache = {};
                markerLayer = new ol.layer.Vector({
                    source: clusterSource,
                    style: function (feature) {
                        var features = feature.get('features');
                        var size = features.length;
                        var style = styleCache[size];
                        if (size > 1) {
                            if (!style) {
                                style = new ol.style.Style({
                                    image: new ol.style.Circle({
                                        radius: 15,
                                        stroke: new ol.style.Stroke({
                                            color: '#fff'
                                        }),
                                        fill: new ol.style.Fill({
                                            color: '#3399CC'
                                        })
                                    }),
                                    text: new ol.style.Text({
                                        text: size.toString(),
                                        fill: new ol.style.Fill({
                                            color: '#fff'
                                        })
                                    })
                                });
                                styleCache[size] = style;
                            }
                        }
                        else {
                            style = features[0].getStyle();
                        }
                        //var style_= new ol.style.Style({
                        //    image: style.image_,
                        //    text: new ol.style.Text({
                        //        text: text,
                        //        offsetX: defaluts.offsetX,
                        //        offsetY: defaluts.offsetY
                        //    })
                        //});
                        return style;
                    }
                });
            } else {
                markerLayer = new ol.layer.Vector({
                    source: source
                })
            }

            //第四步添加feature到对应layer的Source中
            //markerLayer.getSource().addFeature(feature);
            markerLayer.setZIndex(30);
            //第五步 layer添加到map
            map.addLayer(markerLayer);
        };

        /** 加marker图片标注根据一组坐标和marker的图片地址来显示,不聚合 **/
        function addMarkerExt(markerArr) {
            //清空定为
            removeMarker();
            //清空标注
            removeCustomMarkerExt();
            var features = [];
            //第一步设置style
            //第二部创建featuare并设置好在地图上的位置及样式
            markerArr.forEach(function (data, index) {
                var feature = new ol.Feature({
                    geometry: new ol.geom.Point(data.location),
                    id: index++
                });

                var style = new ol.style.Style({
                    image: new ol.style.Icon({
                        src: data.url
                    })
                });
                var html = '<div class="ol-popup none" id="popup">' + '<a href="#" id="popup-closer" class="ol-popup-closer"></a>' + '<div id="popup-content"></div></div>';
                feature.obj = data.popupHtml;
                //设置样式在样式中既可以设置图标
                feature.setStyle(style);
                //添加到之前创建的layer中
                features.push(feature);
            });
            //第三步source添加到layer
            var source = new ol.source.Vector({
                features: features
            });
            markerLayerExt = new ol.layer.Vector({
                source: source
            })

            //第四步添加feature到对应layer的Source中
            //markerLayer.getSource().addFeature(feature);
            markerLayerExt.setZIndex(30);
            //第五步 layer添加到map
            map.addLayer(markerLayerExt);
        };

        //追加标注方法
        function appendMarker(markerArr) {
            if (!markerLayer) {
                return;
            }
            var features = [];
            //第一步设置style

            //第二部创建featuare并设置好在地图上的位置及样式
            markerArr.forEach(function (data, index) {
                var feature = new ol.Feature({
                    geometry: new ol.geom.Point(data.location),
                    id: index++
                });

                var style = new ol.style.Style({
                    image: new ol.style.Icon({
                        src: data.url
                    })
                });
                feature.obj = data.popupHtml;
                //设置样式在样式中既可以设置图标
                feature.setStyle(style);
                //添加到之前创建的layer中
                features.push(feature);
            });

            markerLayer.getSource().addFeatures(features);
            map.render();

        };

        /** 行政区划聚合**/
        function addMarkerCluster(markerArr) {
            //清空定位
            removeMarker();
            //清空标注
            removeClusterMarker();
            var features = [];
            //第一步设置style
            //第二部创建featuare并设置好在地图上的位置及样式
            markerArr.forEach(function (data, index) {
                var feature = new ol.Feature({
                    geometry: new ol.geom.Point(data.location),
                    id: index++
                });
                var url = '../../../../Content/images/bubble-1.png';
                if (data.url) {
                    url = data.url;
                }
                var style = new ol.style.Style({
                    image: new ol.style.Icon({
                        anchor: [0, 1],
                        src: url
                    }),
                    text: new ol.style.Text({
                        text: data.dataCount,
                        offsetX: 27,
                        offsetY: -22,
                        fill: new ol.style.Fill({
                            color: '#fff'
                        })
                    })
                });
                var html = '<div class="ol-popup none" id="popup">' + '<a href="#" id="popup-closer" class="ol-popup-closer"></a>' + '<div id="popup-content"></div></div>';
                feature.obj = data.popupHtml;
                //设置样式在样式中既可以设置图标
                feature.setStyle(style);
                //添加到之前创建的layer中
                features.push(feature);
            });
            //第三步source添加到layer
            var source = new ol.source.Vector({
                features: features
            });
            markerLayerCluster = new ol.layer.Vector({
                source: source
            })

            //第四步添加feature到对应layer的Source中
            //markerLayer.getSource().addFeature(feature);
            markerLayerCluster.setZIndex(30);
            //第五步 layer添加到map
            map.addLayer(markerLayerCluster);
        };


        /** /地图定位---给设置了一个单独的矢量图层-locationLayer 清除的时候主要清除它 **/
        function addLocation(locationArr, isAmEnable, zoomLevel) {
            if (!locationArr[0].latitude || !locationArr[0].longitude) {
                return;
            }
            if (zoomLevel) {
                map.getView().setZoom(zoomLevel);
            } else {
                if (map.getView().getZoom() < 8) {
                    map.getView().setZoom(10);
                }
            }
            flyTo([locationArr[0].longitude, locationArr[0].latitude], zoomLevel);
            if (isAmEnable) {
                flashCss([locationArr[0].longitude, locationArr[0].latitude]);
            }
        };

        /**地图上加图表 **/
        function addChart(chartInfos) {
            removeChartLayer(map);
            if (!chartInfos) { return };
            setTimeout(function () {
                for (var i = 0; i < chartInfos.length; i++) {
                    var timesTamp = i + Date.parse(new Date());
                    var boxId = "box-" + timesTamp;
                    var contentId = "content-" + timesTamp;
                    var layerId = "ChartOverlay-" + timesTamp;
                    var chartHtmlTemplate = '<div class="chartPop" id="' + boxId + '"><div id="' + contentId + '" style="min-width:30px;min-height:40px;"></div></div>';
                    if ($('#' + id).find('#' + boxId).length == 0) {
                        me.append(chartHtmlTemplate);
                    };
                    var popup_element = $('#' + boxId);
                    var popupContent = $('#' + contentId);
                    var chartPopup = new ol.Overlay({
                        element: popup_element[0],
                        autoPan: true,
                        positioning: 'bottom-center',
                        autoPanAnimation: {
                            duration: 250
                        },
                        id: layerId
                    });
                    var position = chartInfos[i].position;
                    chartPopup.setPosition(position);
                    map.addOverlay(chartPopup);

                    var option = chartInfos[i].option;
                    var myChart = echarts.init(popupContent[0]);
                    myChart.setOption(option);
                };
                map.updateSize();
                map.render();
            }, 0);
        };

        /*移除图表及其图层*/
        function removeChartLayer() {
            map.getOverlays().getArray().slice(0).forEach(function (overlay) {
                var layerId = overlay.getId();
                if (layerId && layerId.indexOf("ChartOverlay") !== -1) {
                    map.removeOverlay(overlay);
                }
            })
        };

        function addAreaGeometry(geometry,color) {
            if (!geometry || geometry.length <= 0) {
                return;
            }
            if (xzqhVectorLayer) {
                xzqhVectorLayer.getSource().clear(xzqhVectorLayer.getSource().getFeatures());
                map.removeLayer(xzqhVectorLayer);
            }
            color = color ? color : '#32CD32';
            var style = new ol.style.Style({
                stroke: new ol.style.Stroke({
                    color: color,
                    width: 4
                })
            });
            for (var i = 0; i < geometry.length; i++) {
                geometry[i].setStyle(style);
            }
            var source = new ol.source.Vector({
                features: geometry
            });
            xzqhVectorLayer = new ol.layer.Vector({
                source: source
            });
            xzqhVectorLayer.setZIndex(25);
            map.addLayer(xzqhVectorLayer);
        }

        /** 添加自定义画的要素**/
        function addDrawDataFeatrues(featrues) {
            if (vectorDrawSource) {
                vectorDrawSource.clear();
            }
            var wktJSTSReader = new jsts.io.WKTReader();
            var parser = new jsts.io.OL3Parser();
            if (!featrues || featrues.length <= 0) {
                return;
            }
            for (var i = 0; i < featrues.length; i++) {
                var feature = new ol.Feature();
                var geometry = null;

                if (featrues[i].GeoType != "Circle") {
                    var tmp = wktJSTSReader.read(featrues[i].Coordinates);
                    geometry = parser.write(tmp.getGeometryN(0));
                } else {
                    var tmp = featrues[i].Coordinates.split(',')
                    var radius = parseFloat(tmp[0]);
                    var center = [parseFloat(tmp[1]), parseFloat(tmp[2])];
                    geometry = new ol.geom.Circle(center, radius);
                }
                feature.setGeometry(geometry);
                var style = new ol.style.Style({
                    fill: new ol.style.Fill({
                        color: featrues[i].FillColor
                    }),
                    stroke: new ol.style.Stroke({
                        color: featrues[i].LineColor,
                        width: featrues[i].LineWidth
                    }),
                    image: new ol.style.Circle({
                        radius: 3,
                        stroke: new ol.style.Stroke({
                            color: 'rgba(0, 0, 0, 0.8)'
                        }),
                        fill: new ol.style.Fill({
                            color: 'rgba(255, 255, 0, 0.8)'
                        })
                    })
                });
                feature.setStyle(style);
                var id = uuid();
                feature.setId(id);
                vectorDrawSource.addFeature(feature);
            }
        }

        function setHeight(mapHeight) {
            me.height(mapHeight);
            me.find(".mapDiv").height(mapHeight);
            me.find("div.gislayerpop").height(mapHeight - 50)
            $("#itemTreeMap").setTreeHeight(mapHeight - 150);
        };

        function flyTo(location, zoomLevel) {
            var duration = 2000;
            var view = map.getView();
            view.animate({
                center: location,
                zoom: zoomLevel,
                duration: duration
            });
        };

        function flashCss(location) {
            if (locationLayer) {
                map.removeLayer(locationLayer);
            }
            var point_div = me.find("#css_animation")[0];
            point_div.style.display = 'block';
            locationLayer = new ol.Overlay({
                element: point_div,
                positioning: 'center-center',
                stopEvent: false
            });

            map.addOverlay(locationLayer);
            locationLayer.setPosition(location);
        };
        function loadGeoJsonFile(geoJsonInfos) {
            remoceGeoJsonLayers();
            if (!geoJsonInfos || geoJsonInfos.length <= 0) {
                return;
            }
            for (var i = 0; i < geoJsonInfos.length; i++) {
                var geoJson = geoJsonInfos[i];
                var gjStyle = defualtJsonStyle;
                if (geoJson.geoJsonStyle) {
                    gjStyle = geoJson.geoJsonStyle;
                }
                //加载geojson数据
                var geoJsonLayer = new ol.layer.Vector({
                    source: new ol.source.Vector({
                        url: geoJson.geoJsonUrl,
                        format: new ol.format.GeoJSON()
                    }),
                    style: gjStyle,
                    name: "GeoJsonLayer_" + uuid()
                });
                geoJsonLayer.setZIndex(25);
                map.addLayer(geoJsonLayer);
            }

        }
        /**默认样式 **/
        var defualtJsonStyle = function (feature, resolution) {
            var text = feature.get('CLValue');
            if (!text) {
                text = "";
            }
            var style = new ol.style.Style({
                stroke: new ol.style.Stroke({
                    width: 1.5,
                    color: [0, 0, 255, 255]
                }
                    ),
                text: new ol.style.Text({
                    text: text,
                    fill: new ol.style.Fill({
                        color: '#000'
                    })
                })
            });

            return style;
        };

        //清空geojson图层
        function remoceGeoJsonLayers() {
            var maplayers = map.getLayers().getArray();
            maplayers.forEach(function (layer) {
                var ln = layer.get("name");
                if (ln) {
                    if (ln.indexOf("GeoJsonLayer_") >= 0) {
                        map.removeLayer(layer);
                    }
                }
            });
        }

        //加载图层
        function loadCustomLayer(layer, ck, dataServerKey, url, tileSize, zeroLevelSize, opacity) {
            if (!layer) {
                layer = new iTelluro().newItelluroLayer(dataServerKey, url, tileSize, zeroLevelSize, dataServerKey, defaluts.extent);
                layer.setZIndex(22);
                if (opacity) {
                    layer.setOpacity(opacity);
                }
                map.getView().setZoom(0);
                map.addLayer(layer);
            }
            if (!ck) {
                map.removeLayer(layer);
                layer = null;
            }
            return layer;
        };

        //加载iTelluroServer图层
        function loadCustomLayerByiTelluro(layer, dataServerKey, url, tileSize, zeroLevelSize, layerName, zIndex, opacity) {
            if (!layer) {
                layer = new iTelluro().newItelluroLayer(dataServerKey, url, tileSize, zeroLevelSize, layerName, defaluts.extent);
                var _zIndex = zIndex ? zIndex : 22;
                layer.setZIndex(_zIndex);
                if (opacity) {
                    layer.setOpacity(opacity);
                }
                map.getView().setZoom(0);
                map.addLayer(layer);
            } else {
                layer.setVisible(true);
            }
            return layer;
        };

        //加载WMTSServer图层
        function loadCustomLayerByWMTS(layer, dataServerKey, url, tileMatrixSet, tileMatrixid, format, zoomlevel, tileSize, layerName, extent, zIndex, opacity) {
            if (!layer) {
                layer = new iTelluro().newTileByWMTS(url, dataServerKey, tileMatrixSet, tileMatrixid, format, zoomlevel, tileSize, layerName, extent);
                var _zIndex = zIndex ? zIndex : 22;
                layer.setZIndex(_zIndex);
                if (opacity) {
                    layer.setOpacity(opacity);
                }
                map.addLayer(layer);
            } else {
                layer.setVisible(true);
            }
            return layer;
        };

        //加载WMSServer图层
        function loadCustomLayerByWMS(layer, url, sld, format, dataServerKey, layerName, zIndex, opacity) {
            if (!layer) {
                layer = new iTelluro().newTileByWMS(url, sld, format, dataServerKey, layerName);
                var _zIndex = zIndex ? zIndex : 22;
                layer.setZIndex(_zIndex);
                if (opacity) {
                    layer.setOpacity(opacity);
                }
                map.getView().setZoom(0);
                map.addLayer(layer);
            } else {
                layer.setVisible(true);
            }
            return layer;
        };

        /** 生成Guid **/
        function uuid() {
            var s = [];
            var hexDigits = "0123456789abcdef";
            for (var i = 0; i < 36; i++) {
                s[i] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1);
            }
            s[14] = "4";  // bits 12-15 of the time_hi_and_version field to 0010
            s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1);  // bits 6-7 of the clock_seq_hi_and_reserved to 01
            s[8] = s[13] = s[18] = s[23] = "-";

            var uuid = s.join("");
            return uuid + "-InfoEarth";
        }

        me[0].m = {
            getExtent: function () {
                return MeasureTool.getExtent;
            },
            addTagging: function (type, coordinates, popHtml, vectorArr) {
                addTagging(type, coordinates, popHtml, vectorArr);
            },
            addTaggingArr: function (GDZBArr) {
                addTaggingArr(GDZBArr)
            },
            appendTagging: function (type, coordinates, popHtml, vectorArr) {
                appendTagging(type, coordinates, popHtml, vectorArr);
            },
            addMarker: function (markerArr) {
                addMarker(markerArr);
            },
            addMarkerCluster: function (markerArr) {
                addMarkerCluster(markerArr);
            },
            addMarkerExt: function (markerArr) {
                addMarkerExt(markerArr);
            },
            appendMarker: function (markerArr) {
                appendMarker(markerArr);
            },
            addLocation: function (locationArr, isAmEnable, zoomLevel) {
                addLocation(locationArr, isAmEnable, zoomLevel);
            },
            addChart: function (chartInfos) {
                addChart(chartInfos);
            },
            removeChartLayer: function (map) {
                removeChartLayer(map);
            },
            clearMap: function () {
                clearMap('map_clear');
            },
            clearMapDraw: function () {
                clearMapFeature();
            },
            drawShape: function (shapeType, classname, callback) {
                measuremap(shapeType, classname, callback);
            },
            setHeight: function (mapHeight) {
                setHeight(mapHeight);
                map.updateSize();
            },
            updateSize: function () {
                map.updateSize();
                map.render();
            },
            loadGeoJsonFile: function (geoJsonInfos) {
                loadGeoJsonFile(geoJsonInfos);
            },
            loadCustomLayer: function (layer, ck, dataServerKey, url, tileSize, zeroLevelSize, opacity) {
                loadCustomLayer(layer, ck, dataServerKey, url, tileSize, zeroLevelSize, opacity);
            },
            loadCustomLayerByiTelluro: function (layer, dataServerKey, url, tileSize, zeroLevelSize, layerName, zIndex, opacity) {
                loadCustomLayerByiTelluro(layer, dataServerKey, url, tileSize, zeroLevelSize, layerName, zIndex, opacity);
            },
            loadCustomLayerByWMTS: function (layer, dataServerKey, url, tileMatrixSet, tileMatrixid, format, zoomlevel, tileSize, layerName, extent, zIndex, opacity) {
                loadCustomLayerByWMTS(layer, dataServerKey, url, tileMatrixSet, tileMatrixid, format, zoomlevel, tileSize, layerName, extent, zIndex, opacity);
            },
            loadCustomLayerByWMS: function (layer, url, sld, format, dataServerKey, layerName, zIndex, opacity) {
                loadCustomLayerByWMS(layer, url, sld, format, dataServerKey, layerName, zIndex, opacity);
            },
            addAreaGeometry: function (geometry, color) {
                addAreaGeometry(geometry, color);
            },
            getBufferWKT: function () {
                var features = vectorBufferSource.getFeatures();
                if (!features || features.length <= 0) {
                    return "";
                }

                var wktOLReader = new ol.format.WKT();
                var featureWKT = wktOLReader.writeFeature(features[0]);
                return featureWKT;
            },
            getGDZBWKT: function () {
                if (!vectorLayer) {
                    return null;
                }
                var features = vectorLayer.getSource().getFeatures();
                if (!features || features.length <= 0) {
                    return "";
                }

                var wktOLReader = new ol.format.WKT();
                var featureWKT = wktOLReader.writeFeature(features[0]);
                return featureWKT;
            },
            getShapeFeature: function () {
                return shapeFeature;
            },
            drawCustomPolygon: function (polyWkt) {
                MeasureTool.source.clear();
                var wktJSTSReader = new jsts.io.WKTReader();
                var parser = new jsts.io.OL3Parser();
                var feature = new ol.Feature();
                var tmp = wktJSTSReader.read(polyWkt);
                var geometry = parser.write(tmp.getGeometryN(0));
                feature.setGeometry(geometry);
                MeasureTool.source.addFeature(feature);
            },
            flashCss: function (location) {
                flashCss(location); 
            },
            removeClusterMarker: function () {
                clearDraw();
            },
            addDrawDataFeatrues: function (featrues) {
                addDrawDataFeatrues(featrues)
            }
        };
        return me;
    };
    //获取框选地图多边形点的坐标
    $.fn.getExtent = function () {
        if (this[0].m) {
            return this[0].m.getExtent();
        }
        return null;
    };
    //添加点 线 面
    $.fn.addTagging = function (type, coordinates, popHtml, vectorArr) {
        if (this[0].m) {
            this[0].m.addTagging(type, coordinates, popHtml, vectorArr);
        }
    };
    $.fn.appendTagging = function (type, coordinates, popHtml, vectorArr) {
        if (this[0].m) {
            this[0].m.appendTagging(type, coordinates, popHtml, vectorArr);
        }
    };
    //添加面
    $.fn.addTaggingArr = function (GDZBArr) {
        if (this[0].m) {
            this[0].m.addTaggingArr(GDZBArr);
        }
    };
    //添加marker
    $.fn.addMarker = function (markerArr) {
        if (this[0].m) {
            this[0].m.addMarker(markerArr);
        }
    };
    //行政区划聚合
    $.fn.addMarkerCluster = function (markerArr) {
        if (this[0].m) {
            this[0].m.addMarkerCluster(markerArr);
        }
    };
    //添加marker(不聚合)
    $.fn.addMarkerExt = function (markerArr) {
        if (this[0].m) {
            this[0].m.addMarkerExt(markerArr);
        }
    };

    //追加marker
    $.fn.appendMarker = function (markerArr) {
        if (this[0].m) {
            this[0].m.appendMarker(markerArr);
        }
    };
    //定位
    $.fn.addLocation = function (locationArr, isAmEnable, zoomLevel) {
        if (this[0].m) {
            this[0].m.addLocation(locationArr, isAmEnable, zoomLevel);
        }
    };
    //添加图表
    $.fn.addChart = function (chartInfos) {
        if (this[0].m) {
            this[0].m.addChart(chartInfos);
        }
    };
    //清除图表
    $.fn.removeChartLayer = function (map) {
        if (this[0].m) {
            this[0].m.removeChartLayer(map);
        }
    };
    //清理地图
    $.fn.clearMap = function () {
        if (this[0].m) {
            this[0].m.clearMap();
        }
    };
    //清除地图框选
    $.fn.clearMapDraw = function () {
        if (this[0].m) {
            this[0].m.clearMapDraw();
        }
    };
    //自定义绘图
    $.fn.drawShape = function (shapeType, classname, callback) {
        if (this[0].m) {
            this[0].m.drawShape(shapeType, classname, callback);
        }
    };
    //自定义地图高度以及gis图层树高度
    $.fn.setHeight = function (mapHeight) {
        if (this[0].m) {
            this[0].m.setHeight(mapHeight);
        }
    };
    //地图改变大小刷新
    $.fn.updateSize = function () {
        if (this[0].m) {
            this[0].m.updateSize();
        }
    };
    //加载GeoJson文件
    $.fn.loadGeoJsonFile = function (geoJsonInfos) {
        if (this[0].m) {
            this[0].m.loadGeoJsonFile(geoJsonInfos);
        }
    };
    //加载图层
    $.fn.loadCustomLayer = function (layer, ck, dataServerKey, url, tileSize, zeroLevelSize, opacity) {
        if (this[0].m) {
            this[0].m.loadCustomLayer(layer, ck, dataServerKey, url, 512, zeroLevelSize, opacity);
        }
    };
    //加载iTelluroServer图层
    $.fn.loadCustomLayerByiTelluro = function (layer, dataServerKey, url, tileSize, zeroLevelSize, layerName, zIndex, opacity) {
        if (this[0].m) {
            this[0].m.loadCustomLayerByiTelluro(layer, dataServerKey, url, tileSize, zeroLevelSize, layerName, zIndex, opacity);
        }
    };
    //加载WMTSServer图层
    $.fn.loadCustomLayerByWMTS = function (layer, dataServerKey, url, tileMatrixSet, tileMatrixid, format, zoomlevel, tileSize, layerName, extent, zIndex, opacity) {
        if (this[0].m) {
            this[0].m.loadCustomLayerByWMTS(layer, dataServerKey, url, tileMatrixSet, tileMatrixid, format, zoomlevel, tileSize, layerName, extent, zIndex, opacity);
        }
    };
    //加载WMSServer图层
    $.fn.loadCustomLayerByWMS = function (layer, url, sld, format, dataServerKey, layerName, zIndex, opacity) {
        if (this[0].m) {
            this[0].m.loadCustomLayerByWMS(layer, url, sld, format, dataServerKey, layerName, zIndex, opacity);
        }
    };
    //加载行政区划边界
    $.fn.addAreaGeometry = function (geometry, color) {
        if (this[0].m) {
            this[0].m.addAreaGeometry(geometry, color);
        }
    };

    //获取缓冲区WKT串
    $.fn.getBufferWKT = function () {
        if (this[0].m) {
            return this[0].m.getBufferWKT();
        }
    };

    //获取拐点坐标WKT串
    $.fn.getGDZBWKT = function () {
        if (this[0].m) {
            return this[0].m.getGDZBWKT();
        }
    };
    //获取ShapeFeature
    $.fn.getShapeFeature = function () {
        if (this[0].m) {
            return this[0].m.getShapeFeature();
        }
    };
    //根据WKt画多边形
    $.fn.drawCustomPolygon = function (polyWkt) {
        if (this[0].m) {
            return this[0].m.drawCustomPolygon(polyWkt);
        }
    };
    //强调选中
    $.fn.flashCss = function (location) {
        if (this[0].m) {
            this[0].m.flashCss(location);
        }
    };
    //清空省市县
    $.fn.removeClusterMarker = function () {
        if (this[0].m) {
            this[0].m.removeClusterMarker();
        }
    };
    //新增边界  
    $.fn.addDrawDataFeatrues = function (featrues) {
        if (this[0].m) {
            this[0].m.addDrawDataFeatrues(featrues);
        }
    };
})(jQuery);