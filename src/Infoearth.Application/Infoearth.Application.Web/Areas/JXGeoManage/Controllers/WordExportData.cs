using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Application.Busines.SystemManage;
using Infoearth.Application.Cache;
using Infoearth.Application.Entity.JXGeoManage;
using iTelluro.FileImage.BusinessInfoProxy.BusinessInfoService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;

namespace Infoearth.Application.Web.Areas.JXGeoManage.Controllers
{
    public class WordExportData : WordHelper
    {
        private BusinessInfoServiceClient _pBusinessInfo = new BusinessInfoServiceClient();
        Dictionary<BusinessFileDetailinfoDTO, string> download = new Dictionary<BusinessFileDetailinfoDTO, string>();


        /// <summary>
        /// 填充word模板
        /// </summary>
        /// <param name="unifiecode">地质遗迹编码</param>
        /// <param name="w">导出word对象</param>
        /// <returns></returns>
        protected override int FillBookmark(string GUID, string moudleId, DisasterTypeEnum DisasterType, WordprocessingDocument w)
        {
            Common_SaveWord(DisasterType, GUID, moudleId, w);
            return 1;
        }

        //崩塌情况
        private void Common_SaveWord(DisasterTypeEnum DisasterType, string GUID, string mouduleId, WordprocessingDocument w)
        {
            object georecsinfo = null; string UNIFIEDCODE = string.Empty;
            //mouduleId = "86343CDB-BCA2-4083-87A6-6E6AD38CCC5E";//地灾调查
            //mouduleId = "863484DB-BCA2-1587-87A6-6E6AD38CCC5E";//地灾排查
            switch (DisasterType)
            {
                case DisasterTypeEnum.滑坡:
                    TBL_LANDSLIPEntity landslip = new TBL_LANDSLIPBLL().GetEntity(GUID);
                    if (landslip.PROJECTID != null && landslip.PROJECTID != "")
                    {
                        var a = new JYGC_PROJECTBASEINFOBLL().GetEntity(landslip.PROJECTID);
                        if (a != null)
                        {
                            landslip.PROJECTID = a.PROJECTNAME;
                        }
                        else
                        {
                            landslip.PROJECTID = "";
                        }
                    }
                    UNIFIEDCODE = landslip.UNIFIEDCODE;
                    georecsinfo = landslip;
                    break;
                case DisasterTypeEnum.滑坡隐患:
                    //TBL_LANDSLIP_YHDEntity landslipYHD = new TBL_LANDSLIP_YHDBLL().GetEntity(GUID);
                    //UNIFIEDCODE = landslipYHD.UNIFIEDCODE;
                    //georecsinfo = landslipYHD;
                    break;
                case DisasterTypeEnum.崩塌:
                    TBL_AVALANCHEEntity avalanche = new TBL_AVALANCHEBLL().GetEntity(GUID);
                    if (avalanche.PROJECTID != null && avalanche.PROJECTID != "")
                    {
                        var a = new JYGC_PROJECTBASEINFOBLL().GetEntity(avalanche.PROJECTID);
                        if (a != null)
                        {
                            avalanche.PROJECTID = a.PROJECTNAME;
                        }
                        else
                        {
                            avalanche.PROJECTID = "";
                        }
                    }
                    UNIFIEDCODE = avalanche.UNIFIEDCODE;
                    georecsinfo = avalanche;
                    break;
                case DisasterTypeEnum.崩塌隐患:
                    //TBL_AVALANCHE_YHDEntity avalancheYHD = new TBL_AVALANCHE_YHDBLL().GetEntity(GUID);
                    //UNIFIEDCODE = avalancheYHD.UNIFIEDCODE;
                    //georecsinfo = avalancheYHD;
                    break;
                case DisasterTypeEnum.泥石流:
                    TBL_DEBRISFLOWEntity debrisflow = new TBL_DEBRISFLOWBLL().GetEntity(GUID);
                    if (debrisflow.PROJECTID != null && debrisflow.PROJECTID != "")
                    {
                        var a = new JYGC_PROJECTBASEINFOBLL().GetEntity(debrisflow.PROJECTID);
                        if (a != null)
                        {
                            debrisflow.PROJECTID = a.PROJECTNAME;
                        }
                        else
                        {
                            debrisflow.PROJECTID = "";
                        }
                    }
                    UNIFIEDCODE = debrisflow.UNIFIEDCODE;
                    georecsinfo = debrisflow;
                    break;
                case DisasterTypeEnum.地面沉降:
                    TBL_LANDSETTLEMENTEntity landsettlement = new TBL_LANDSETTLEMENTBLL().GetEntity(GUID);
                    if (landsettlement.PROJECTID != null && landsettlement.PROJECTID != "")
                    {
                        var a = new JYGC_PROJECTBASEINFOBLL().GetEntity(landsettlement.PROJECTID);
                        if (a != null)
                        {
                            landsettlement.PROJECTID = a.PROJECTNAME;
                        }
                        else
                        {
                            landsettlement.PROJECTID = "";
                        }
                    }
                    UNIFIEDCODE = landsettlement.UNIFIEDCODE;
                    georecsinfo = landsettlement;
                    break;
                case DisasterTypeEnum.地面塌陷:
                    TBL_COLLAPSEEntity collapse = new TBL_COLLAPSEBLL().GetEntity(GUID);
                    if (collapse.PROJECTID != null && collapse.PROJECTID != "")
                    {
                        var a = new JYGC_PROJECTBASEINFOBLL().GetEntity(collapse.PROJECTID);
                        if (a != null)
                        {
                            collapse.PROJECTID = a.PROJECTNAME;
                        }
                        else
                        {
                            collapse.PROJECTID = "";
                        }
                    }
                    UNIFIEDCODE = collapse.UNIFIEDCODE;
                    georecsinfo = collapse;
                    break;
                case DisasterTypeEnum.地裂缝:
                    TBL_LANDCRACKEntity landcrack = new TBL_LANDCRACKBLL().GetEntity(GUID);
                    if (landcrack.PROJECTID != null && landcrack.PROJECTID != "")
                    {
                        var a = new JYGC_PROJECTBASEINFOBLL().GetEntity(landcrack.PROJECTID);
                        if (a != null)
                        {
                            landcrack.PROJECTID = a.PROJECTNAME;
                        }
                        else
                        {
                            landcrack.PROJECTID = "";
                        }
                    }
                    UNIFIEDCODE = landcrack.UNIFIEDCODE;
                    georecsinfo = landcrack;
                    break;
                case DisasterTypeEnum.斜坡:
                    TBL_SLOPEEntity slope = new TBL_SLOPEBLL().GetEntity(GUID);
                    if (slope.PROJECTID != null && slope.PROJECTID != "")
                    {
                        var a = new JYGC_PROJECTBASEINFOBLL().GetEntity(slope.PROJECTID);
                        if (a != null)
                        {
                            slope.PROJECTID = a.PROJECTNAME;
                        }
                        else
                        {
                            slope.PROJECTID = "";
                        }
                    }
                    UNIFIEDCODE = slope.UNIFIEDCODE;
                    georecsinfo = slope;
                    
                    break;
            }
            string[][] pictureTypeCode = GetImageList();
            int timeStart = Environment.TickCount;
            string[] extName = this._imageFormat;
            BusinessFileDetailinfoDTO[] lstPic = _pBusinessInfo.GetFileInfos(mouduleId, GUID, extName);
            DownloadImage(lstPic, pictureTypeCode, out download);

            List<DicMarkerClass> ckbList = GetChectBoxByType(DisasterType);//复选框
            List<DicClass> dicList = GetListByType(DisasterType);//字典列表

            if (georecsinfo != null)
            {
                var bookmarks = w.MainDocumentPart.Document.Body.Descendants<BookmarkStart>();
                foreach (BookmarkStart bm in bookmarks)
                {
                    try
                    {
                        string field = bm.Name.ToString().ToUpper();
                        //是否是图片并填充图片
                        if (IsFileImage(w, bm, pictureTypeCode))
                            continue;
                        ////字典项并保存
                        if (IsCheckBox(bm, ckbList, dicList, field, georecsinfo))
                            continue;
                        PropertyInfo p = georecsinfo.GetType().GetProperty(field);
                        if (p == null)
                            continue;
                        string strValue= p.GetValue(georecsinfo, null) == null ? "" : p.GetValue(georecsinfo, null).ToString();
                        if (!string.IsNullOrWhiteSpace( strValue))
                        {
                            OpenxmlUtility.AddTextToBody(bm, strValue);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                w.MainDocumentPart.Document.Save();
            }
        }

        #region 数据字典
        private List<DicClass> GetListByType(DisasterTypeEnum DisasterType)
        {
            List<DicClass> returnValue = null;
            List<DicMarkerClass> list = GetChectBoxByType(DisasterType);
            DataItemCache dataItemCache = new DataItemCache();
            returnValue = dataItemCache.GetDataItemList().Where(p => list.Select(c => c.DicName).Contains(p.F_EnCode))
                .Select(p => new DicClass
                    {
                        Name = p.F_ItemName,
                        Value = p.F_ItemValue,
                         Type = list.Where(c => c.DicName == p.F_EnCode).FirstOrDefault().Filed
                    }).ToList();
            return returnValue;
        }
        //字典项和字段不同
        private List<DicMarkerClass> GetChectBoxByType(DisasterTypeEnum DisasterType)
        {
            List<DicMarkerClass> returnValue = new List<DicMarkerClass>();
            string strFiled = "";
            if (DisasterType == DisasterTypeEnum.滑坡隐患)
                DisasterType = DisasterTypeEnum.滑坡;
            else if (DisasterType == DisasterTypeEnum.崩塌隐患)
                DisasterType = DisasterTypeEnum.崩塌;
            switch (DisasterType)
            {
                case DisasterTypeEnum.滑坡:
                    #region 滑坡
                    returnValue.Add(new DicMarkerClass() { Filed = "EARTHQUAKEINTENSITY", DicName = "DIZHENLIEDU", Type=ControlEnum.Text });//地震烈度
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPEARCHTYPE", DicName = "SLOPEARCHTYPEHP", Type=ControlEnum.Text });//原始斜坡-斜坡结构类型1
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPEASPECTARCHTYPE", DicName = "SLOPEASPECTARCHTYPE", Type=ControlEnum.Text });//原始斜坡-斜坡结构类型2
                    returnValue.Add(new DicMarkerClass() { Filed = "SURFACETYPE1", DicName = "SURFACETYPE", Type=ControlEnum.Text });//原始斜坡-控滑结构面类型1
                    returnValue.Add(new DicMarkerClass() { Filed = "SURFACETYPE2", DicName = "SURFACETYPE", Type=ControlEnum.Text });//原始斜坡-控滑结构面类型2
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPBLOCKDEGREE", DicName = "LANDSLIPBLOCKDEGREE", Type=ControlEnum.Text });//结构特征-块度
                    returnValue.Add(new DicMarkerClass() { Filed = "SLIPSURFACESHAPE", DicName = "SLIPSURFACESHAPE", Type=ControlEnum.Text });//结构特征-形态
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPSOILNAME", DicName = "LANDSLIPSOILNAME", Type=ControlEnum.Text });//结构特征-滑土带名称
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN1", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称1
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN2", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称2
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN3", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称3
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN4", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称4
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN5", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称5
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN6", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称6
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN7", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称7
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN8", DicName = "DISTORTIONSIGN1HP", Type=ControlEnum.Text });//现今变形迹象-名称8



                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPYEAR", DicName = "LANDSLIPYEARHP", Type=ControlEnum.CheckBox });//滑坡时间
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPTYPE", DicName = "LANDSLIPTYPEHP", Type=ControlEnum.CheckBox });//滑坡类型
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPKIND", DicName = "LANDSLIPKINDHP", Type=ControlEnum.CheckBox });//滑体性质
                    returnValue.Add(new DicMarkerClass() { Filed = "MICROTOPOGRAPHY", DicName = "MICROTOPOGRAPHYHP", Type=ControlEnum.CheckBox });//微地貌
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATERTYPE", DicName = "GROUNDWATERTYPEHP", Type=ControlEnum.CheckBox });//地下水类型
                    returnValue.Add(new DicMarkerClass() { Filed = "POSITIONTORIVER", DicName = "POSITIONTORIVERHP", Type=ControlEnum.CheckBox });//滑坡相对河流位置
                    returnValue.Add(new DicMarkerClass() { Filed = "ORIGINALSLOPESHAPE", DicName = "SLOPEARCHTYPEHP", Type=ControlEnum.CheckBox });//原始斜坡-坡形
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPFLATSHAPE", DicName = "LANDSLIPFLATSHAPEHP", Type=ControlEnum.CheckBox });//平面形态
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPSECTIONSHAPE", DicName = "LANDSLIPSECTIONSHAPEHP", Type=ControlEnum.CheckBox });//剖面形态
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPARCH", DicName = "LANDSLIPARCHHP", Type=ControlEnum.CheckBox });//结构特征-结构
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATEROUTCROP", DicName = "GROUNDWATEROUTCROPHP", Type=ControlEnum.CheckBox });//地下水-露头
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATERSUPPLYTYPE", DicName = "GROUNDWATERSUPPLYTYPEHP", Type=ControlEnum.CheckBox });//地下水-补给类型
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDUSAGE", DicName = "LANDUSAGEHP", Type=ControlEnum.CheckBox });//土地使用
                    returnValue.Add(new DicMarkerClass() { Filed = "GEOLOGICFACTOR", DicName = "GEOLOGICFACTORHP", Type=ControlEnum.CheckBox });//地质因素
                    returnValue.Add(new DicMarkerClass() { Filed = "GEOMORPHICFACTOR", DicName = "GEOMORPHICFACTORHP", Type=ControlEnum.CheckBox });//地貌因素
                    returnValue.Add(new DicMarkerClass() { Filed = "PHYSICALFACTORS", DicName = "PHYSICALFACTORSHP", Type=ControlEnum.CheckBox });//物理因素
                    returnValue.Add(new DicMarkerClass() { Filed = "HUMANFACTOR", DicName = "HUMANFACTORHP", Type=ControlEnum.CheckBox });//人为因素
                    returnValue.Add(new DicMarkerClass() { Filed = "MAINFACTOR", DicName = "MAINFACTORHP", Type=ControlEnum.CheckBox });//主导因素
                    returnValue.Add(new DicMarkerClass() { Filed = "REINDUCEDFACTOR", DicName = "REINDUCEDFACTORHP", Type=ControlEnum.CheckBox });//复活诱发因素
                    returnValue.Add(new DicMarkerClass() { Filed = "CURSTABLESTATUS", DicName = "CURSTABLESTATUSHP", Type=ControlEnum.CheckBox });//目前稳定状况
                    returnValue.Add(new DicMarkerClass() { Filed = "STABLETREND", DicName = "STABLETRENDHP", Type=ControlEnum.CheckBox });//发展趋势分析
                    returnValue.Add(new DicMarkerClass() { Filed = "DISASTERLEVEL", DicName = "DISASTERLEVEL", Type=ControlEnum.CheckBox });//灾情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERLEVEL", DicName = "DANGERLEVEL", Type=ControlEnum.CheckBox });//险情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "SCALELEVEL", DicName = "DISAATERSIZE", Type=ControlEnum.CheckBox });//灾害规模等级
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDSLIPMONITORSUGGESTION", DicName = "LANDSLIPMONITORSUGGESTIONHP", Type=ControlEnum.CheckBox });//监测建议
                    returnValue.Add(new DicMarkerClass() { Filed = "TREATMENTSUGGESTION", DicName = "TREATMENTSUGGESTIONHP", Type=ControlEnum.CheckBox });//防治建议
                    #endregion
                    break;
                case DisasterTypeEnum.崩塌:
                    #region 崩塌
                    returnValue.Add(new DicMarkerClass() { Filed = "EARTHQUAKEINTENSITY", DicName = "DIZHENLIEDU", Type=ControlEnum.Text });//地震烈度
                    returnValue.Add(new DicMarkerClass() { Filed = "ROCKARCHTYPE", DicName = "ROCKARCHTYPE", Type=ControlEnum.Text });//结构类型
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPEARCHTYPE", DicName = "SLOPEARCHTYPEHP", Type=ControlEnum.Text });//斜坡结构类型1
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPEASPECTARCHTYPE", DicName = "SLOPEASPECTARCHTYPE", Type=ControlEnum.Text });//斜坡结构类型2
                    returnValue.Add(new DicMarkerClass() { Filed = "CTRLSURFTYPE1", DicName = "SURFACETYPE", Type=ControlEnum.Text });//结构特征-岩质-类型
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN1", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称1
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN2", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称2
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN3", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称3
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN4", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称4
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN5", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称5
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN6", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称6
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN7", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称7
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN8", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称8


                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPETYPE", DicName = "SLOPETYPEBT", Type=ControlEnum.CheckBox });//斜坡类型
                    returnValue.Add(new DicMarkerClass() { Filed = "MICROTOPOGRAPHY", DicName = "MICROTOPOGRAPHYBT", Type=ControlEnum.CheckBox });//微地貌
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATERTYPE", DicName = "GROUNDWATERTYPEBT", Type = ControlEnum.CheckBox });//地下水
                    returnValue.Add(new DicMarkerClass() { Filed = "POSITIONTORIVER", DicName = "POSITIONTORIVERBT", Type = ControlEnum.CheckBox });//斜坡与河流相对位置
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDUSAGE", DicName = "LANDUSAGEBT", Type = ControlEnum.CheckBox });//土地利用
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPESHAPE", DicName = "SLOPEARCHTYPEHP", Type = ControlEnum.CheckBox });//坡面形态
                    returnValue.Add(new DicMarkerClass() { Filed = "SOILDENSITYDEGREE", DicName = "SOILDENSITYDEGREEBT", Type = ControlEnum.CheckBox });//密实度
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATEROUTCROP", DicName = "GROUNDWATEROUTCROPBT", Type = ControlEnum.CheckBox });//露头
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATERSUPPLYTYPE", DicName = "GROUNDWATERSUPPLYTYPEBT", Type = ControlEnum.CheckBox });//补给类型
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERROCKASTABLEFACTOR", DicName = "DANGERROCKASTABLEFACTORBT", Type = ControlEnum.CheckBox });//可能失稳因素
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERROCKSTABLESTATUS", DicName = "DANGERROCKSTABLESTATUSBT", Type = ControlEnum.CheckBox });//目前稳定程度
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERROCKSTABLETREND", DicName = "DANGERROCKSTABLETRENDBT", Type = ControlEnum.CheckBox });//今后变化趋势
                    returnValue.Add(new DicMarkerClass() { Filed = "MONITORSUGGESTION", DicName = "MONITORSUGGESTIONBT", Type = ControlEnum.CheckBox });//监测建议
                    returnValue.Add(new DicMarkerClass() { Filed = "TREATMENTSUGGESTION", DicName = "TREATMENTSUGGESTIONBT", Type = ControlEnum.CheckBox });//防治建议
                    //returnValue.Add(new DicMarkerClass() { Filed = "DISASTERLEVEL", DicName = "DISASTERLEVEL", Type = ControlEnum.CheckBox });//灾情等级
                    //returnValue.Add(new DicMarkerClass() { Filed = "DANGERLEVEL", DicName = "DANGERLEVEL", Type = ControlEnum.CheckBox });//险情等级
                    #endregion
                    break;
                case DisasterTypeEnum.泥石流:
                    #region 泥石流
                    returnValue.Add(new DicMarkerClass() { Filed = "EARTHQUAKEINTENSITY", DicName = "DIZHENLIEDU", Type=ControlEnum.Text });//地震烈度


                    returnValue.Add(new DicMarkerClass() { Filed = "MRIVERLOCATION", DicName = "MRIVERLOCATIONNS", Type=ControlEnum.CheckBox });//泥石流沟位于主河道
                    returnValue.Add(new DicMarkerClass() { Filed = "HYDRODYNAMICTYPE", DicName = "HYDRODYNAMICTYPENS", Type=ControlEnum.CheckBox });//水动力类型
                    returnValue.Add(new DicMarkerClass() { Filed = "SEDIMENTSUPPLYROUTE", DicName = "SEDIMENTSUPPLYROUTENS", Type=ControlEnum.CheckBox });//泥砂补给途径
                    returnValue.Add(new DicMarkerClass() { Filed = "RECHARGEZONE", DicName = "RECHARGEZONENS", Type=ControlEnum.CheckBox });//补给区位置
                    returnValue.Add(new DicMarkerClass() { Filed = "MIZSECTORLANDTRENDS", DicName = "MIZSECTORLANDTRENDSNS", Type=ControlEnum.CheckBox });//发展趋势
                    returnValue.Add(new DicMarkerClass() { Filed = "MIZSECTORLANDEXTRUSIONRIVER", DicName = "MIZSECTORLANDEXTRUSIONRIVERNS", Type=ControlEnum.CheckBox });//挤压大河
                    returnValue.Add(new DicMarkerClass() { Filed = "GEOLOGICALSTRUCTURE", DicName = "GEOLOGICALSTRUCTURENS", Type=ControlEnum.CheckBox });//地质构造
                    returnValue.Add(new DicMarkerClass() { Filed = "SCALEACTIVITYDEGREE", DicName = "SCALEACTIVITYDEGREENS", Type=ControlEnum.CheckBox });//滑坡-活动程度
                    returnValue.Add(new DicMarkerClass() { Filed = "SCALEIANDSLIDE", DicName = "SCALEIANDSLIDENS", Type=ControlEnum.CheckBox });//滑坡-滑坡规模
                    returnValue.Add(new DicMarkerClass() { Filed = "ARTIFICIALABDBODYACTDEGREE", DicName = "ARTIFICIALABDBODYACTDEGREENS", Type=ControlEnum.CheckBox });//人工弃体-活动程度
                    returnValue.Add(new DicMarkerClass() { Filed = "ARTIFICIALABDBODYSCALE", DicName = "ARTIFICIALABDBODYSCALENS", Type=ControlEnum.CheckBox });//人工弃体-弃体规模
                    returnValue.Add(new DicMarkerClass() { Filed = "NATURALACCACTDEGREE", DicName = "NATURALACCACTDEGREENS", Type=ControlEnum.CheckBox });//自然堆-活动程度
                    returnValue.Add(new DicMarkerClass() { Filed = "NATURALACCSCALE", DicName = "NATURALACCSCALENS", Type=ControlEnum.CheckBox });//自然堆-堆积规模
                    returnValue.Add(new DicMarkerClass() { Filed = "CONTROLMEASTATUSQ", DicName = "MONITORMEASURE", Type=ControlEnum.CheckBox });//防治措施现状-有无
                    returnValue.Add(new DicMarkerClass() { Filed = "CONTROMEASURETYPE", DicName = "CONTROLMEASTATUSQNS", Type=ControlEnum.CheckBox });//防治措施现状-类型
                    returnValue.Add(new DicMarkerClass() { Filed = "MONITORMEASURE", DicName = "MONITORMEASURE", Type=ControlEnum.CheckBox });//监测措施-有无
                    returnValue.Add(new DicMarkerClass() { Filed = "MONITORMEASURETYPE", DicName = "MONITORMEASURENS", Type=ControlEnum.CheckBox });//监测措施-类型
                    returnValue.Add(new DicMarkerClass() { Filed = "THREATENHARMOBJ", DicName = "THREATENHARMOBJNS", Type=ControlEnum.CheckBox });//威胁危害对象
                    returnValue.Add(new DicMarkerClass() { Filed = "BADGEOLOGICALPHENOMENA", DicName = "BADGEOLOGICALPHENOMENANS", Type=ControlEnum.CheckBox });//不良地质现象
                    returnValue.Add(new DicMarkerClass() { Filed = "MIZOGUCHIFAN", DicName = "MIZOGUCHIFANNS", Type=ControlEnum.CheckBox });//沟口扇形地
                    returnValue.Add(new DicMarkerClass() { Filed = "NEWCONSTRUCTIONAFFECT", DicName = "NEWCONSTRUCTIONAFFECTNS", Type=ControlEnum.CheckBox });//新沟造影响
                    returnValue.Add(new DicMarkerClass() { Filed = "ROCKFACTOR", DicName = "ROCKFACTORNS", Type=ControlEnum.CheckBox });//岩性因素
                    returnValue.Add(new DicMarkerClass() { Filed = "TRENCHCCROSSSECTIONAL", DicName = "TRENCHCCROSSSECTIONALNS", Type=ControlEnum.CheckBox });//沟槽横断面
                    returnValue.Add(new DicMarkerClass() { Filed = "BLOCKDEGREE", DicName = "BLOCKDEGREENS", Type=ControlEnum.CheckBox });//堵塞程度
                    returnValue.Add(new DicMarkerClass() { Filed = "PRONEDEGREE", DicName = "PRONEDEGREENS", Type=ControlEnum.CheckBox });//易发程度
                    returnValue.Add(new DicMarkerClass() { Filed = "DEBRISFLOWTYPE", DicName = "DEBRISFLOWTYPE", Type=ControlEnum.CheckBox });//泥石流类型
                    returnValue.Add(new DicMarkerClass() { Filed = "DISASTERLEVEL", DicName = "DISASTERLEVEL", Type=ControlEnum.CheckBox });//灾情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERLEVEL", DicName = "DANGERLEVEL", Type=ControlEnum.CheckBox });//险情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "HIDDENPOINT", DicName = "HIDDENDANGER", Type=ControlEnum.CheckBox });//隐患点
                    returnValue.Add(new DicMarkerClass() { Filed = "ISZYYH", DicName = "ISIMPORTANT", Type=ControlEnum.CheckBox });//重要隐患点
                    returnValue.Add(new DicMarkerClass() { Filed = "DEVELOPINGSTAGE", DicName = "DEVELOPINGSTAGENS", Type=ControlEnum.CheckBox });//发展阶段
                    returnValue.Add(new DicMarkerClass() { Filed = "TREATMENTSUGGESTION", DicName = "TREATMENTSUGGESTIONNS", Type=ControlEnum.CheckBox });//防治建议
                    #endregion
                    break;
                case DisasterTypeEnum.地面沉降:
                    break;
                case DisasterTypeEnum.地面塌陷:
                    returnValue.Add(new DicMarkerClass() { Filed = "DISASTERLEVEL", DicName = "DISASTERLEVEL", Type=ControlEnum.CheckBox });//灾情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERLEVEL", DicName = "DANGERLEVEL", Type=ControlEnum.CheckBox });//险情等级
                     returnValue.Add(new DicMarkerClass() { Filed = "DESTROYEDOBJ", DicName = "DESTROYEDOBJTX", Type=ControlEnum.CheckBox });//灾情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "THREATENOBJ", DicName = "DESTROYEDOBJTX", Type=ControlEnum.CheckBox });//险情等级
                    break;
                case DisasterTypeEnum.地裂缝:
                    returnValue.Add(new DicMarkerClass() { Filed = "DISASTERLEVEL", DicName = "DISASTERLEVEL", Type=ControlEnum.CheckBox });//灾情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERLEVEL", DicName = "DANGERLEVEL", Type=ControlEnum.CheckBox });//险情等级
                     returnValue.Add(new DicMarkerClass() { Filed = "DESTROYEDOBJECT", DicName = "DESTROYEDOBJTX", Type=ControlEnum.CheckBox });//灾情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "THREATENOBJECT", DicName = "DESTROYEDOBJTX", Type=ControlEnum.CheckBox });//险情等级
                    break;

                case DisasterTypeEnum.斜坡:
                    #region 斜坡
                    returnValue.Add(new DicMarkerClass() { Filed = "EARTHQUAKEINTENSITY", DicName = "DIZHENLIEDU", Type=ControlEnum.Text });//地震烈度
                    returnValue.Add(new DicMarkerClass() { Filed = "ROCKARCHTYPE", DicName = "ROCKARCHTYPE", Type=ControlEnum.Text });//结构类型
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPEARCHTYPE", DicName = "SLOPEARCHTYPE", Type=ControlEnum.Text });//斜坡结构类型1
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPEASPECTARCHTYPE", DicName = "SLOPEASPECTARCHTYPE", Type=ControlEnum.Text });//斜坡结构类型2
                    returnValue.Add(new DicMarkerClass() { Filed = "CTRLSURFTYPE1", DicName = "CONTROLSURFACETYPE", Type=ControlEnum.Text });//结构特征-岩质-类型1
                    returnValue.Add(new DicMarkerClass() { Filed = "CTRLSURFTYPE2", DicName = "CONTROLSURFACETYPE", Type=ControlEnum.Text });//结构特征-岩质-类型2
                    returnValue.Add(new DicMarkerClass() { Filed = "CTRLSURFTYPE3", DicName = "CONTROLSURFACETYPE", Type=ControlEnum.Text });//结构特征-岩质-类型3
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN1", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称1
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN2", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称2
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN3", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称3
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN4", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称4
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN5", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称5
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN6", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称6
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN7", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称7
                    returnValue.Add(new DicMarkerClass() { Filed = "DISTORTIONSIGN8", DicName = "DISTORTIONSIGN1BT", Type=ControlEnum.Text });//现今变形破坏迹象-名称8
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPETYPE", DicName = "SLOPETYPEBT", Type=ControlEnum.CheckBox });//斜坡类型
                    returnValue.Add(new DicMarkerClass() { Filed = "MICROTOPOGRAPHY", DicName = "MICROTOPOGRAPHYBT", Type=ControlEnum.CheckBox });//微地貌
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATERTYPE", DicName = "GROUNDWATERTYPEBT", Type=ControlEnum.CheckBox });//地下水类型
                    returnValue.Add(new DicMarkerClass() { Filed = "POSITIONTORIVER", DicName = "POSITIONTORIVERBT", Type=ControlEnum.CheckBox });//斜坡与河流相对位置
                    returnValue.Add(new DicMarkerClass() { Filed = "LANDUSAGE", DicName = "LANDUSAGEBT", Type=ControlEnum.CheckBox });//土地利用
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPESHAPE", DicName = "SLOPEARCHTYPEHP", Type=ControlEnum.CheckBox });//坡面形态
                    returnValue.Add(new DicMarkerClass() { Filed = "SOILDENSITYDEGREE", DicName = "SOILDENSITYDEGREEBT", Type=ControlEnum.CheckBox });//密实度
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATEROUTCROP", DicName = "GROUNDWATEROUTCROPBT", Type=ControlEnum.CheckBox });//露头
                    returnValue.Add(new DicMarkerClass() { Filed = "GROUNDWATERSUPPLYTYPE", DicName = "GROUNDWATERSUPPLYTYPEBT", Type=ControlEnum.CheckBox });//补给类型
                    returnValue.Add(new DicMarkerClass() { Filed = "ASTABLEFACTOR", DicName = "ACCUMULATIONBODYASTABLEFACTORBT", Type=ControlEnum.CheckBox });//可能失稳因素
                    returnValue.Add(new DicMarkerClass() { Filed = "CURRENTSTABLESTATUS", DicName = "ACCUMULATIONBODYSTABLESTATUSBT", Type=ControlEnum.CheckBox });//目前稳定程度
                    returnValue.Add(new DicMarkerClass() { Filed = "STABLETREND", DicName = "ACCUMULATIONBODYSTABLESTATUSBT", Type=ControlEnum.CheckBox });//今后变化趋势
                    returnValue.Add(new DicMarkerClass() { Filed = "DISASTERLEVEL", DicName = "DISASTERLEVEL", Type=ControlEnum.CheckBox });//灾情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "DANGERLEVEL", DicName = "DANGERLEVEL", Type=ControlEnum.CheckBox });//险情等级
                    returnValue.Add(new DicMarkerClass() { Filed = "HIDDENDANGER", DicName = "HIDDENDANGER", Type=ControlEnum.CheckBox });//隐患点
                    returnValue.Add(new DicMarkerClass() { Filed = "ISZYYH", DicName = "ISIMPORTANT", Type=ControlEnum.CheckBox });//重要隐患点
                    returnValue.Add(new DicMarkerClass() { Filed = "SLOPEMONITORSUGGESTION", DicName = "LANDSLIPMONITORSUGGESTIONHP", Type=ControlEnum.CheckBox });//监测建议
                    returnValue.Add(new DicMarkerClass() { Filed = "TREATMENTSUGGESTION", DicName = "TREATMENTSUGGESTIONBT", Type=ControlEnum.CheckBox });//防治建议
                     returnValue.Add(new DicMarkerClass() { Filed = "THREATENOBJECT", DicName = "DESTROYEDOBJTX", Type=ControlEnum.CheckBox });//防治建议
                    #endregion
                    break;
                default:
                    break;
            }
            string[] strArr = strFiled.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in strArr)
            {
                returnValue.Add(new DicMarkerClass() { Filed = item, DicName = item });
            }
            return returnValue;
        }
        private string[][] GetImageList(string type = null)
        {
            string[][] pictureTypeCode = new string[][] { 
                new string[] { "ImageA", "0BD245C7-1DC4-454E-8816-9892804F9FDB" }, //默认的平面图
                new string[] { "ImageB", "48693C7B-2BFC-4322-AF39-2239B156FDD3" }, //默认的剖面图
                new string[] { "ZPJL", "" }, //照片记录
                new string[] { "YGYXJL", "" }, //遥感影像记录
            };
            return pictureTypeCode;
        }
        #endregion
        private decimal ConvertToDecimal(string obj)
        {
            decimal returnValue = 0;
            try
            {
                returnValue = Convert.ToDecimal(obj);
            }
            catch (Exception)
            {

            }
            return returnValue;
        }

        /// <summary>
        /// 字典项
        /// </summary>
        /// <param name="bm"></param>
        /// <param name="ckbList"></param>
        /// <param name="dicList"></param>
        /// <param name="bookmarksFiled"></param>
        /// <param name="georecsinfo"></param>
        /// <returns></returns>
        protected bool IsCheckBox(BookmarkStart bm, List<DicMarkerClass> ckbList, List<DicClass> dicList, string bookmarksFiled, object georecsinfo)
        {
            bool returnValue = false;
            DicMarkerClass isDicEntity= ckbList.Where(p => p.Filed.ToUpper() == bookmarksFiled).FirstOrDefault();
            if (null != isDicEntity)
            {
                PropertyInfo p2 = georecsinfo.GetType().GetProperty(bookmarksFiled);
                string value2  = p2.GetValue(georecsinfo, null) == null ? "" : p2.GetValue(georecsinfo, null).ToString();
                string[] arrCheck = value2.TrimEnd(',').Trim().Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries);//值（去掉空格）
                if (bookmarksFiled == "CTRLSURFTYPE3" || bookmarksFiled == "CTRLSURFTYPE2")
                {
                    bookmarksFiled = "CTRLSURFTYPE1";
                }
                if (bookmarksFiled == "DISTORTIONSIGN2" || bookmarksFiled == "DISTORTIONSIGN3" || bookmarksFiled == "DISTORTIONSIGN4" || bookmarksFiled == "DISTORTIONSIGN5" || bookmarksFiled == "DISTORTIONSIGN6" || bookmarksFiled == "DISTORTIONSIGN7" || bookmarksFiled == "DISTORTIONSIGN8")
                {
                    bookmarksFiled = "DISTORTIONSIGN1";
                }
                if (bookmarksFiled == "THREATENOBJECT")
                {
                    bookmarksFiled = "DESTROYEDOBJECT";
                } if (bookmarksFiled == "THREATENOBJ")
                {
                    bookmarksFiled = "DESTROYEDOBJ";
                }
                var list = dicList.Where(a => a.Type.ToUpper() == bookmarksFiled);
                if (isDicEntity.Type==ControlEnum.Text)//文字
                {
                    string value=string.Join(",", list.Where(p => arrCheck.Contains(p.Value)).Select(p => p.Name));
                    OpenxmlUtility.AddTextToBody(bm, value);
                }
                else
                {
                    foreach (var item in list)
                    {
                        if (arrCheck.Contains(item.Value))
                            OpenxmlUtility.AddCheckBoxToBody(bm, item.Name, true);
                        else
                            OpenxmlUtility.AddCheckBoxToBody(bm, item.Name, false);
                    }
                }
                returnValue = true;
            }
            return returnValue;
        }

        /// <summary>
        /// 是否是图片并填充图片
        /// </summary>
        /// <param name="w"></param>
        /// <param name="bm"></param>
        /// <param name="pictureTypeCode"></param>
        /// <returns></returns>
        protected bool IsFileImage(WordprocessingDocument w, BookmarkStart bm, string[][] pictureTypeCode)
        {
            bool isPic = false;
            for (int i = 0; i < pictureTypeCode.Length; i++)
            {
                if (bm.Name.ToString().ToUpper() == pictureTypeCode[i][0].ToUpper())
                {
                    if (bm.Name.ToString().ToUpper().IndexOf("IMAGE") != -1)
                    {
                        FillImage(download, w, pictureTypeCode[i][1], bm);
                    }
                    else
                    {
                        FillImage(download, w, pictureTypeCode[i][1], bm, true);
                    }
                    isPic = true;
                    break;
                }
            }
            return isPic;
        }
        //添加多媒体
        protected void FillImage(Dictionary<BusinessFileDetailinfoDTO, string> images, WordprocessingDocument w, string type, BookmarkStart bm, bool isGetFileName = false)
        {
            foreach (BusinessFileDetailinfoDTO item in images.Keys)
            {
                if (item.TYPECODE == type)
                {
                    string filename = item.FILEINFOGUID + item.ExtName;
                    string filepath = _tempFile + filename;
                    string text = item.FILENAME;
                    if (isGetFileName)
                    {
                        text += "；";
                        OpenxmlUtility.AddTextToBody(bm, text);
                    }
                    else
                    {
                        OpenxmlUtility.InsertImageToDoC(filepath, item.FILENAME, w, bm);
                    }
                }
            }
        }

        /// <summary>
        /// 下载所需要的图片
        /// </summary>
        /// <param name="picturels">多媒体文件集合</param>
        /// <param name="pictureTypeCode">需要下载文件类型</param>
        public void DownloadImage(BusinessFileDetailinfoDTO[] picturels, string[][] pictureTypeCode, out Dictionary<BusinessFileDetailinfoDTO, string> download)
        {
            download = new Dictionary<BusinessFileDetailinfoDTO, string>();
            if (pictureTypeCode != null)
            {
                foreach (BusinessFileDetailinfoDTO item in picturels)
                {
                    for (int i = 0; i < pictureTypeCode.Length; i++)
                    {
                        if (item.TYPECODE == pictureTypeCode[i][1])
                        {
                            download.Add(item, pictureTypeCode[i][1]);
                        }
                    }
                }
            }
            else
            {
                foreach (BusinessFileDetailinfoDTO item in picturels)
                {
                    download.Add(item, item.TYPECODE);
                }
            }

            //_gdownload = download;

            foreach (BusinessFileDetailinfoDTO item in download.Keys)
            {
                //http://192.168.100.55/multimediawebsite/page/download.ashx?Guid=7a3f4e27-8e21-49bb-8447-3151cb476eda&Filename=桌面截图&Thumbnail=1024
                WebClient client = new WebClient();
                client.DownloadFileCompleted += client_DownloadFileCompleted;
                string url = System.Configuration.ConfigurationManager.AppSettings["MediaPath"] + "/page/download.ashx";
                string filename = item.FILEINFOGUID + item.ExtName;
                string filepath = _tempFile + filename;

                if (!Directory.Exists(_tempFile))
                {
                    Directory.CreateDirectory(_tempFile);
                }

                if (File.Exists(filepath))
                {
                    _Addpictures++;
                }
                else
                {
                    //client.DownloadFileAsync(new Uri(url + "?Guid=" + item.FILEINFOGUID + "&Filename=" + item.FILENAME + "&Thumbnail" + pixel), filepath, item);
                    client.DownloadFile(new Uri(url + "?Guid=" + item.FILEINFOGUID + "&Filename=" + item.FILENAME + "&Thumbnail" + pixel), filepath);//同步下载
                }
            }
        }
        /// <summary>
        /// 异步下载文件，计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _Addpictures++;
        }
        private string ConvertDate(string date, string type)
        {
            string returnValue = "";
            try
            {
                if (type == "3")
                {
                    DateTime dt = Convert.ToDateTime(date);
                    returnValue = dt.Year + "年" + dt.Month + "月" + dt.Day + "日";
                }
                else if (type == "2")
                {
                    DateTime dt = Convert.ToDateTime(date);
                    returnValue = dt.Year + "年" + dt.Month + "月";
                }
                else if (type == "1")
                {
                    if (date.Length == 4)
                    {
                        returnValue = date + "年";
                    }
                    else
                    {
                        DateTime dt = Convert.ToDateTime(date);
                        returnValue = dt.Year + "年";
                    }
                }
            }
            catch (Exception)
            {


            }
            return returnValue;
        }
    }
    public class DicClass
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
    public class DicMarkerClass
    {
        /// <summary>
        /// 字典code
        /// </summary>
        public string DicName { get; set; }
        /// <summary>
        /// 实体中字段
        /// </summary>
        public string Filed { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public ControlEnum Type { get; set; }
    }
}