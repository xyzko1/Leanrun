using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using Infoearth.Application.Entity.SystemManage;
using System.Data;
using System.Linq;
using Infoearth.Application.Entity;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Application.Service.SystemManage;
using Infoearth.Application.Service;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// 版 本 InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-16 15:53
    /// 描 述：解译工程项目基本信息表
    /// </summary>
    public class HarzardTrendAnalyseBLL
    {
        private HarzardTrendAnalyseIService service = new HarzardTrendAnalyseService();
        private JYGC_PROJECTBASEINFOIService projectService = new JYGC_PROJECTBASEINFOService();
        private DataItemDetailService dataItemDetailService = new DataItemDetailService();


        public DataTable QueryStatistics(string queryJson, ref List<MergedRegionEntity> columnList)
        {
            var queryParam = queryJson.ToJObject();
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicDataList = null;
            if (!queryParam["Type"].IsEmpty())
            {
                string value = queryParam["Type"].ToString();
                switch (value.ToLower())
                {
                    case "zqs"://总趋势
                        dicDataList = GetDicData_ZQS(queryJson);
                        break;
                    case "yhdgmqs"://隐患点规模趋势
                        dicDataList = GetDicData_yhdgmqs(queryJson);
                        return service.QueryStatistics_yhdgmqs(queryJson, dicDataList, ref columnList);
                        break;
                    case "zhlxjgmqs"://灾害类型及规模趋势
                        dicDataList = GetDicData_zhlxjgmqs(queryJson);
                        return service.QueryStatistics_zhlxjgmqs(queryJson, dicDataList, ref columnList);
                        break;
                    //case "nxhqs"://拟销号趋势
                    //    dicDataList = GetDicData_ZQS(queryJson);
                    //    break;
                    case "nxhd"://拟销号点
                        columnList = GetColumn_nxhd();
                        return service.GetList_NXHD(queryJson);
                        break;
                    case "gmdjdb"://灾情、险情、规模等级对比
                        dicDataList = GetDicData_ZQXQGM(queryJson);
                        return service.QueryStatistics_ZQXQGM(queryJson, dicDataList, ref columnList);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                dicDataList = GetDicData_ZQS(queryJson);
            }
            return service.QueryStatistics(queryJson, dicDataList, ref columnList);
        }
        //总趋势
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_ZQS(string queryJson)
        {
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            //List<DataItemDetailEntity> list = projectService.GetListByDateDiff(queryJson).Select(p => new DataItemDetailEntity { F_ItemValue = p.PROJECTGUID, F_ItemName = p.YEAR.ToString() + "年" }).ToList();
            List<DataItemDetailEntity> list = new List<DataItemDetailEntity>();
            DataItemDetailEntity itemList = new DataItemDetailEntity();
            var queryParam = queryJson.ToJObject();
            DataItemDetailEntity itemList2 = new DataItemDetailEntity();
            itemList2.F_ItemName = queryParam["endYear"].ToString() + "年";
            itemList2.F_ItemValue = queryParam["endYear"].ToString();
            list.Add(itemList2);
            itemList.F_ItemName = queryParam["startYear"].ToString() + "年";
            itemList.F_ItemValue = queryParam["startYear"].ToString();
            list.Add(itemList);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "灾害点数(处)", F_ItemDetailId = "1" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "项目", F_Description = "拟销号灾害点数(处)", F_ItemDetailId = " decode(guid,null,0,1) " }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "项目", F_Description = "完成搬迁点数(处)", F_ItemDetailId = "decode(ISBQBR,null,0,0,0,1)" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "项目", F_Description = "完成治理点数(处)", F_ItemDetailId = "decode(ISZLGC,null,0,0,0,1)" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "项目", F_Description = "有责任主体的点数(处)", F_ItemDetailId = "decode(ISZRZT,null,0,0,0,1)" }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "拟销号灾害点数(处)", F_ItemDetailId = " case when guid=null then 0 else 1 end " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "完成搬迁点数(处)", F_ItemDetailId = " case  when ISBQBR=null then 0 when ISBQBR=0 then 0 else 1 end" }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "完成治理点数(处)", F_ItemDetailId = " case  when ISZLGC=null then 0 when ISZLGC=0 then 0 else 1 end " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "有责任主体的点数(处)", F_ItemDetailId = "case  when ISZRZT=null then 0 when ISZRZT=0 then 0 else 1 end " }, list);
            return dicData;
        }
        //隐患点规模趋势
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_yhdgmqs(string queryJson)
        {
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            List<DataItemDetailEntity> list = dataItemDetailService.GetItemDetailList("DISAATERSIZE").ToList();
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "灾害规模", F_Description = "灾害规模", F_ItemDetailId = "1" }, list);
            return dicData;
        }
        //灾情、险情、规模等级对比
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_ZQXQGM(string queryJson)
        {

            List<DataItemDetailEntity> listDic = dataItemDetailService.GetItemDetailList("DISAATERSIZE").ToList();
            string strValue = string.Empty;
            //foreach (var item in listDic)
            //{
            //    strValue += string.Format(",'{0}','{1}'", item.F_ItemValue, item.F_ItemName);
            //}
            //string strDic = " decode({0}" + strValue + ") ";
            foreach (var item in listDic)
            {
                strValue += string.Format(" when '{0}' then '{1}'", item.F_ItemValue, item.F_ItemName);
            }
            string strDic = " case {0}" + strValue + " end ";

            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            //List<DataItemDetailEntity> list = projectService.GetListByDateDiff(queryJson).Select(p => new DataItemDetailEntity { F_ItemValue = p.PROJECTGUID, F_ItemName = p.YEAR.ToString() + "年" }).ToList();
            List<DataItemDetailEntity> list = new List<DataItemDetailEntity>();
            DataItemDetailEntity itemList = new DataItemDetailEntity();
            var queryParam = queryJson.ToJObject();
            DataItemDetailEntity itemList2 = new DataItemDetailEntity();
            itemList2.F_ItemName = queryParam["endYear"].ToString() + "年";
            itemList2.F_ItemValue = queryParam["endYear"].ToString();
            list.Add(itemList2);
            itemList.F_ItemName = queryParam["startYear"].ToString() + "年";
            itemList.F_ItemValue = queryParam["startYear"].ToString();
            list.Add(itemList);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "项目", F_Description = "灾害类型", F_ItemDetailId = "a.DISASTERTYPE" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "项目", F_Description = "规模等级", F_ItemDetailId = string.Format(strDic, "a.SCALELEVEL") }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "项目", F_Description = "灾情等级", F_ItemDetailId = string.Format(strDic, "a.DISASTERLEVEL") }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "项目", F_Description = "险情等级", F_ItemDetailId = string.Format(strDic, "a.DANGERLEVEL") }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "灾害类型", F_ItemDetailId = "a.DISASTERTYPE" }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "规模等级", F_ItemDetailId = string.Format(strDic, "a.SCALELEVEL") }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "灾情等级", F_ItemDetailId = string.Format(strDic, "a.DISASTERLEVEL") }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "项目", F_Description = "险情等级", F_ItemDetailId = string.Format(strDic, "a.DANGERLEVEL") }, list);
            return dicData;
        }
        //灾害类型及规模趋势
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_zhlxjgmqs(string queryJson)
        {
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            List<DataItemDetailEntity> list = dataItemDetailService.GetItemDetailList("DISAATERSIZE").ToList();
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "崩塌", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='崩塌' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "滑坡", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='滑坡' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "泥石流", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='泥石流' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "地面塌陷", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='地面塌陷' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "不稳定斜坡", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='斜坡' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "地裂缝", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='地裂缝' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "地面沉降", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='地面沉降' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "滑坡隐患点", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='滑坡隐患点' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "崩塌隐患点", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='崩塌隐患点' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "规模", F_Description = "遥感解译点", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='遥感解译点' " }, list);
            return dicData;
        }

        private List<MergedRegionEntity> GetColumn_nxhd()
        {
            List<MergedRegionEntity> returnValue = new List<MergedRegionEntity> {
                new MergedRegionEntity() { columnName = "disastername", columnNameReplace = "灾害点名称", rowFrom = 1, rowTo = 1, colFrom = 0, colTo = 0, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "outdoorcode", columnNameReplace = "野外编号", rowFrom = 1, rowTo = 1, colFrom = 1, colTo = 1, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "location", columnNameReplace = "位置", rowFrom = 1, rowTo = 1, colFrom = 2, colTo = 2, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "disastertype", columnNameReplace = "灾害类型", rowFrom = 1, rowTo = 1, colFrom = 3, colTo = 3, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "zlgcly", columnNameReplace = "销号理由", rowFrom = 1, rowTo = 1, colFrom = 4, colTo = 4, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "zlgcsj", columnNameReplace = "治理（搬迁避让）时间", rowFrom = 1, rowTo = 1, colFrom = 5, colTo = 5, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "zlptzj", columnNameReplace = "治理配套资金（万元）", rowFrom = 1, rowTo = 1, colFrom = 6, colTo = 6, GroupHeaderCount = 1 },
            };
            return returnValue;
        }
    }
}
