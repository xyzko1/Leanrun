using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using Infoearth.Util.Extension;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using Infoearth.Application.Common;

namespace Infoearth.Application.Service.JXGeoManage
{
    public class TBL_XIAOHAOService : RepositoryFactory<TBL_XIAOHAOEntity>, TBL_XIAOHAOIService
    {
        private TBL_BQBRIService bqbrService = new TBL_BQBRService();
        private TBL_ZLGC_BASEINFOIService zlgcService = new TBL_ZLGC_BASEINFOService();
        private TBL_HAZARDBASICINFOIService hazardService = new TBL_HAZARDBASICINFOService();
        private TBL_AVALANCHE_HISTORYIService avalanceService = new TBL_AVALANCHE_HISTORYService();
        private TBL_AVALANCHEIService avalance = new TBL_AVALANCHEService();
        private TBL_LANDSLIP_HISTORYIService landshipService = new TBL_LANDSLIP_HISTORYService();
        private TBL_LANDSLIPIService landship = new TBL_LANDSLIPService();
        private TBL_DEBRISFLOW_HISTORYIService debrisflowService = new TBL_DEBRISFLOW_HISTORYService();
        private TBL_DEBRISFLOWIService debrisflow = new TBL_DEBRISFLOWService();
        private TBL_LANDCRACK_HISTORYIService landcrackService = new TBL_LANDCRACK_HISTORYService();
        private TBL_LANDCRACKIService landcrack = new TBL_LANDCRACKService();
        private TBL_LANDSETTLEMENT_HISTORYIService landsettlementService = new TBL_LANDSETTLEMENT_HISTORYService();
        private TBL_LANDSETTLEMENTIService landsettlement = new TBL_LANDSETTLEMENTService();
        private TBL_SLOPE_HISTORYIService slopeService = new TBL_SLOPE_HISTORYService();
        private TBL_SLOPEIService slope = new TBL_SLOPEService();
        private TBL_COLLAPSE_HISTORYIService collapseService = new TBL_COLLAPSE_HISTORYService();
        private TBL_COLLAPSEIService collapse = new TBL_COLLAPSEService();
        private TBL_AUDITINFOIService auditService = new TBL_AUDITINFOService();
        private TBL_AUDITORSIService audits = new TBL_AUDITORSService();
        private TBL_HAZARDBASICINFO_HISTORYIService hazardHistory = new TBL_HAZARDBASICINFO_HISTORYService();
        private TBL_AUDITINFOIService audit = new TBL_AUDITINFOService();

        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_XIAOHAOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            //var expression = queryJsonExpression(queryJson);
            var expression = search(queryJson);
            return this.BaseRepository().FindList(expression, pagination);
        }
        public IEnumerable<TBL_XIAOHAOEntity> GetSinglePastPageListJson(Pagination pagination, string queryJson, string condition)
        {
            var list = GetPageList(pagination, queryJson).ToList();
            List<TBL_XIAOHAOEntity> results = new List<TBL_XIAOHAOEntity>();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            return list;

        }

        public IEnumerable<TBL_XIAOHAOEntity> GetHXMapList(string queryJson, string condition)
        {
            var list = GetList(queryJson).ToList();
            List<TBL_XIAOHAOEntity> results = new List<TBL_XIAOHAOEntity>();
            var queryParam = condition.ToJObject();
            if (!queryParam["WKTString"].IsEmpty())
            {
                string WKTString = queryParam["WKTString"].ToString();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.isContainPoint(WKTString, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["x"].IsEmpty() && !queryParam["y"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                double x = queryParam["x"].ToDouble();
                double y = queryParam["y"].ToDouble();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.PointInCircle(item.LATITUDE.ToDouble(), item.LONGITUDE.ToDouble(), y, x, radius);
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            if (!queryParam["polyline"].IsEmpty() && !queryParam["radius"].IsEmpty())
            {
                string polyline = queryParam["polyline"].ToString();
                double radius = queryParam["radius"].ToDouble();
                foreach (var item in list)
                {
                    if (item.LONGITUDE.IsEmpty() || item.LATITUDE.IsEmpty())
                    {
                        continue;
                    }

                    bool isInsert = SpatialQueryHelper.IsIntersects(polyline, radius, item.LONGITUDE.ToString(), item.LATITUDE.ToString());
                    if (isInsert)
                    {
                        results.Add(item);
                    }

                }
                return results;
            }
            return list;

        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_XIAOHAOEntity> GetList(string queryJson)
        {
            //var expression = queryJsonExpression(queryJson);
            var expression = search(queryJson);
            var a = this.BaseRepository().FindList(expression);
            return a;
        }
        public List<string> searchSH()
        {
            List<TBL_AUDITINFOEntity> list = audit.GetList("").ToList();
            var basicInfo = list.Where(p => p.STATUS == "2").Select(p => p.BASICINFO);
            List<string> basicinfos = new List<string>();
            foreach (var item in basicInfo)
            {
                string[] infos = item.Split(',');
                basicinfos.Add(infos[2]);
            }
            basicinfos = basicinfos.Distinct().ToList();
            return basicinfos;
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_XIAOHAOEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_XIAOHAOEntity entity, ref int statusCode)
        {
            TBL_BQBREntity bqbrInfo = bqbrService.GetEntityByUnifycode(entity.UNIFIEDCODE);
            TBL_ZLGC_BASEINFOEntity zlgcInfo = zlgcService.GetEntityByUnifycode(entity.UNIFIEDCODE, entity.PROJECTID);
            //TBL_LANDSLIP_HISTORYEntity landshipentity = new TBL_LANDSLIP_HISTORYEntity();
            //landshipentity.UNIFIEDCODE = entity.UNIFIEDCODE;
            //landshipentity.DISASTERUNITNAME = entity.DISASTERNAME;
            //landshipentity.OUTDOORCODE = entity.OUTDOORCODE;
            //landshipentity.LATITUDE = entity.LATITUDE.ToString();
            //landshipentity.LONGITUDE = entity.LONGITUDE.ToString();
            //landshipentity.LOCATION = entity.LOCATION;
            //landshipentity.UPDATETIME = entity.CREATETIME;
            //TBL_SLOPE_HISTORYEntity slopentity = new TBL_SLOPE_HISTORYEntity();
            //slopentity.UNIFIEDCODE = entity.UNIFIEDCODE;
            //slopentity.DISASTERUNITNAME = entity.DISASTERNAME;
            //slopentity.OUTDOORCODE = entity.OUTDOORCODE;
            //slopentity.LATITUDE = entity.LATITUDE.ToString();
            //slopentity.LONGITUDE = entity.LONGITUDE.ToString();
            //slopentity.LOCATION = entity.LOCATION;
            //slopentity.UPDATETIME = entity.CREATETIME;
            //TBL_COLLAPSE_HISTORYEntity collapseentity = new TBL_COLLAPSE_HISTORYEntity();
            //collapseentity.UNIFIEDCODE = entity.UNIFIEDCODE;
            //collapseentity.DISASTERUNITNAME = entity.DISASTERNAME;
            //collapseentity.OUTDOORCODE = entity.OUTDOORCODE;
            //collapseentity.LATITUDE = entity.LATITUDE.ToString();
            //collapseentity.LONGITUDE = entity.LONGITUDE.ToString();
            //collapseentity.LOCATION = entity.LOCATION;
            //collapseentity.UPDATETIME = entity.CREATETIME;
            //TBL_AVALANCHE_HISTORYEntity avalanceServiceentity = new TBL_AVALANCHE_HISTORYEntity();
            //avalanceServiceentity.UNIFIEDCODE = entity.UNIFIEDCODE;
            //avalanceServiceentity.DISASTERUNITNAME = entity.DISASTERNAME;
            //avalanceServiceentity.OUTDOORCODE = entity.OUTDOORCODE;
            //avalanceServiceentity.LATITUDE = entity.LATITUDE.ToString();
            //avalanceServiceentity.LONGITUDE = entity.LONGITUDE.ToString();
            //avalanceServiceentity.LOCATION = entity.LOCATION;
            //avalanceServiceentity.UPDATETIME = entity.CREATETIME;
            //TBL_DEBRISFLOW_HISTORYEntity debrisflowentity = new TBL_DEBRISFLOW_HISTORYEntity();
            //debrisflowentity.UNIFIEDCODE = entity.UNIFIEDCODE;
            //debrisflowentity.DISASTERUNITNAME = entity.DISASTERNAME;
            //debrisflowentity.OUTDOORCODE = entity.OUTDOORCODE;
            //debrisflowentity.LATITUDE = entity.LATITUDE.ToString();
            //debrisflowentity.LONGITUDE = entity.LONGITUDE.ToString();
            //debrisflowentity.LOCATION = entity.LOCATION;
            //debrisflowentity.UPDATETIME = entity.CREATETIME;
            //TBL_LANDCRACK_HISTORYEntity landcrackentity = new TBL_LANDCRACK_HISTORYEntity();
            //landcrackentity.UNIFIEDCODE = entity.UNIFIEDCODE;
            //landcrackentity.DISASTERUNITNAME = entity.DISASTERNAME;
            //landcrackentity.OUTDOORCODE = entity.OUTDOORCODE;
            //landcrackentity.LATITUDE = entity.LATITUDE.ToString();
            //landcrackentity.LONGITUDE = entity.LONGITUDE.ToString();
            //landcrackentity.LOCATION = entity.LOCATION;
            //landcrackentity.UPDATETIME = entity.CREATETIME;
            //TBL_LANDSETTLEMENT_HISTORYEntity andsettlemententity = new TBL_LANDSETTLEMENT_HISTORYEntity();
            //andsettlemententity.UNIFIEDCODE = entity.UNIFIEDCODE;
            //andsettlemententity.DISASTERUNITNAME = entity.DISASTERNAME;
            //andsettlemententity.OUTDOORCODE = entity.OUTDOORCODE;
            //andsettlemententity.LATITUDE = entity.LATITUDE.ToString();
            //andsettlemententity.LONGITUDE = entity.LONGITUDE.ToString();
            //andsettlemententity.LOCATION = entity.LOCATION;
            //andsettlemententity.UPDATETIME = entity.CREATETIME;
            //判断是否存在搬迁避让或治理工程信息，存在则进行销号操作
            //entity.GUID = Guid.NewGuid().ToString();
            int VERIFICATION = 0;
            if (entity.ISBQBR == "1" && bqbrInfo != null)
            {
                VERIFICATION = 2;
                //entity.Create();
                //this.BaseRepository().Insert(entity);
                ////删除灾害点表信息
                //hazardService.RemoveForm(entity.UNIFIEDCODE);
                ////往7类历史表加数据
                //if (entity.DISASTERTYPE == "01")
                //{
                //    landshipentity.VERIFICATION = "2";
                //    landshipService.SaveEntity("", landshipentity);
                //}
                //else if (entity.DISASTERTYPE == "00")
                //{
                //    slopentity.VERIFICATION = "2";
                //    slopeService.SaveForm("", slopentity);
                //}
                //else if (entity.DISASTERTYPE == "04")
                //{
                //    collapseentity.VERIFICATION = "2";
                //    collapseService.SaveForm("", collapseentity);
                //}
                //else if (entity.DISASTERTYPE == "02")
                //{
                //    avalanceServiceentity.VERIFICATION = "2";
                //    avalanceService.SaveForm("", avalanceServiceentity);
                //}
                //else if (entity.DISASTERTYPE == "03")
                //{

                //    debrisflowentity.VERIFICATION = "2"; 
                //    debrisflowService.SaveForm("", debrisflowentity);
                //}
                //else if (entity.DISASTERTYPE == "06")
                //{
                //    landcrackentity.VERIFICATION = "2"; 
                //    landcrackService.SaveForm("", landcrackentity);
                //}
                //else if (entity.DISASTERTYPE == "05")
                //{
                //    andsettlemententity.VERIFICATION = "2"; 
                //    landsettlementService.SaveForm("", andsettlemententity);
                //}
                statusCode = UpdateStatus(entity, "A");
            }
            else if (zlgcInfo != null && entity.ISZLGC == "1")//治理工程
            {
                VERIFICATION = 1;
                //entity.Create();
                //this.BaseRepository().Insert(entity);
                ////删除灾害点表信息
                //hazardService.RemoveForm(entity.UNIFIEDCODE);
                ////往7类历史表加数据
                //if (entity.DISASTERTYPE == "01")
                //{
                //    landshipentity.VERIFICATION = "1";
                //    landshipService.SaveEntity("", landshipentity);
                //}
                //else if (entity.DISASTERTYPE == "00")
                //{
                //    slopentity.VERIFICATION = "1";
                //    slopeService.SaveForm("", slopentity);
                //}
                //else if (entity.DISASTERTYPE == "04")
                //{
                //    collapseentity.VERIFICATION = "1";
                //    collapseService.SaveForm("", collapseentity);
                //}
                //else if (entity.DISASTERTYPE == "02")
                //{
                //    avalanceServiceentity.VERIFICATION = "1";
                //    avalanceService.SaveForm("", avalanceServiceentity);
                //}
                //else if (entity.DISASTERTYPE == "03")
                //{

                //    debrisflowentity.VERIFICATION = "1";
                //    debrisflowService.SaveForm("", debrisflowentity);
                //}
                //else if (entity.DISASTERTYPE == "06")
                //{
                //    landcrackentity.VERIFICATION = "1";
                //    landcrackService.SaveForm("", landcrackentity);
                //}
                //else if (entity.DISASTERTYPE == "05")
                //{
                //    andsettlemententity.VERIFICATION = "1";
                //    landsettlementService.SaveForm("", andsettlemententity);
                //}
                statusCode = UpdateStatus(entity, "A");
            }
            else if (entity.ISZRZT == "1")//责任主体
            {
                VERIFICATION = 3;
                //entity.Create();
                //this.BaseRepository().Insert(entity);
                ////删除灾害点表信息
                //hazardService.RemoveForm(entity.UNIFIEDCODE);
                ////往7类历史表加数据
                //if (entity.DISASTERTYPE == "01")
                //{
                //    landshipentity.VERIFICATION = "3";
                //    landshipService.SaveEntity("", landshipentity);
                //}
                //else if (entity.DISASTERTYPE == "00")
                //{
                //    slopentity.VERIFICATION = "3";
                //    slopeService.SaveForm("", slopentity);
                //}
                //else if (entity.DISASTERTYPE == "04")
                //{
                //    collapseentity.VERIFICATION = "3";
                //    collapseService.SaveForm("", collapseentity);
                //}
                //else if (entity.DISASTERTYPE == "02")
                //{
                //    avalanceServiceentity.VERIFICATION = "3";
                //    avalanceService.SaveForm("", avalanceServiceentity);
                //}
                //else if (entity.DISASTERTYPE == "03")
                //{

                //    debrisflowentity.VERIFICATION = "3";
                //    debrisflowService.SaveForm("", debrisflowentity);
                //}
                //else if (entity.DISASTERTYPE == "06")
                //{
                //    landcrackentity.VERIFICATION = "3";
                //    landcrackService.SaveForm("", landcrackentity);
                //}
                //else if (entity.DISASTERTYPE == "05")
                //{
                //    andsettlemententity.VERIFICATION = "3";
                //    landsettlementService.SaveForm("", andsettlemententity);
                //}
                statusCode = UpdateStatus(entity);
            }
            //其他
            else if (entity.ZHDXZ != null)
            {
                VERIFICATION = 3;
                //entity.Create();
                //this.BaseRepository().Insert(entity);
                ////删除灾害点表信息
                //hazardService.RemoveForm(entity.UNIFIEDCODE);
                ////往7类历史表加数据
                //if (entity.DISASTERTYPE == "01")
                //{
                //    landshipentity.VERIFICATION = "3";
                //    landshipService.SaveEntity("", landshipentity);
                //}
                //else if (entity.DISASTERTYPE == "00")
                //{
                //    slopentity.VERIFICATION = "3";
                //    slopeService.SaveForm("", slopentity);
                //}
                //else if (entity.DISASTERTYPE == "04")
                //{
                //    collapseentity.VERIFICATION = "3";
                //    collapseService.SaveForm("", collapseentity);
                //}
                //else if (entity.DISASTERTYPE == "02")
                //{
                //    avalanceServiceentity.VERIFICATION = "3";
                //    avalanceService.SaveForm("", avalanceServiceentity);
                //}
                //else if (entity.DISASTERTYPE == "03")
                //{

                //    debrisflowentity.VERIFICATION = "3";
                //    debrisflowService.SaveForm("", debrisflowentity);
                //}
                //else if (entity.DISASTERTYPE == "06")
                //{
                //    landcrackentity.VERIFICATION = "3";
                //    landcrackService.SaveForm("", landcrackentity);
                //}
                //else if (entity.DISASTERTYPE == "05")
                //{
                //    andsettlemententity.VERIFICATION = "3";
                //    landsettlementService.SaveForm("", andsettlemententity);
                //}
                statusCode = UpdateStatus(entity);
            }
            else
            {
                statusCode = 0;
            }
            entity.Create();
            this.BaseRepository().Insert(entity);
            DateTime d=entity.FILLTABLEDATE == null ? Convert.ToDateTime("1900-1-1") : entity.FILLTABLEDATE.Value;
            auditService.VerificationData(entity.UNIFIEDCODE, VERIFICATION, d);

        }
        //更新状态
        private int UpdateStatus(TBL_XIAOHAOEntity entity, string type = "")
        {
            //string sql = string.Format("update {0} set ISXH = '1' where PROJECTID = '{1}' and UNIFIEDCODE = '{2}'", "TBL_HAZARDBASICINFO", entity.PROJECTID, entity.UNIFIEDCODE);
            //int result = this.BaseRepository().ExecuteBySql(sql);
            int statusCode = 100;
            if (type == "A")
            {
                statusCode = 99;
            }
            else
            {
                statusCode = 100;
            }
            return statusCode;
        }

        //删除隐患点
        public void DeleteHidden(string keyValue)
        {
            TBL_HAZARDBASICINFOEntity hazardInfo = hazardService.GetEntity(keyValue);
            DateTime modifyTime = DateTime.Now;
            //获取当前用户名称
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;
            string auditor = audits.GetAudits(keyValue.Substring(0, 6), "A");  //A表示地灾调查的审核
            //未开启审核
            if (string.IsNullOrEmpty(auditor))
            {
                //if (keyValue.Length == 12)
                //{
                //    keyValue += " " + " " + " " + " ";
                //}
                //删除灾害点表信息
                hazardService.RemoveForm(keyValue);
                //往灾害点历史表加信息
                TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);
                basicHistoryInfo.MODIFYTIME = modifyTime;
                basicHistoryInfo.MODIFYTYPE = "R";
                basicHistoryInfo.MODIFYUSER = userName;
                basicHistoryInfo.AUDITSTATUS = "5";
                basicHistoryInfo.AUDITOR = auditor;
                basicHistoryInfo.FILLTABLEDATE = modifyTime;
                hazardHistory.SaveEntity("", basicHistoryInfo);
                //往7类历史表加数据,并删除最新数据
                if (keyValue.Substring(6,2) == "01")
                {
                    TBL_LANDSLIP_HISTORYEntity historyInfo = landshipService.GetEntityByUNIFIEDCODE(keyValue);
                    //新增历史表
                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "R";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    landshipService.SaveEntity(string.Empty, historyInfo);
                    //删除最新数据
                    landship.RemoveForm(keyValue);
                }
                else if (keyValue.Substring(6,2) == "00")
                {
                    TBL_SLOPE_HISTORYEntity historyInfo = slopeService.GetEntityByUNIFIEDCODE(keyValue);
                    //新增历史表
                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "R";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    slopeService.SaveForm("", historyInfo);
                    //删除最新数据
                    slope.RemoveForm(keyValue);

                }
                else if (keyValue.Substring(6,2) == "05")
                {
                    TBL_COLLAPSE_HISTORYEntity historyInfo = collapseService.GetEntityByUNIFIEDCODE(keyValue);
                    //新增历史表
                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "R";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    collapseService.SaveForm("", historyInfo);
                    //删除最新数据
                    collapse.RemoveForm(keyValue);
                }
                else if (keyValue.Substring(6,2) == "02")
                {
                    TBL_AVALANCHE_HISTORYEntity historyInfo = avalanceService.GetEntityByUNIFIEDCODE(keyValue);
                    //新增历史表
                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "R";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    avalanceService.SaveForm("", historyInfo);
                    //删除最新数据
                    avalance.RemoveForm(keyValue);
                }
                else if (keyValue.Substring(6,2) == "03")
                {
                    TBL_DEBRISFLOW_HISTORYEntity historyInfo = debrisflowService.GetEntityByUNIFIEDCODE(keyValue);
                    //新增历史表
                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "R";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    debrisflowService.SaveForm("", historyInfo);
                    //删除最新数据
                    debrisflow.RemoveForm(keyValue);
                }
                else if (keyValue.Substring(6,2) == "06")
                {
                    TBL_LANDCRACK_HISTORYEntity historyInfo = landcrackService.GetEntityByUNIFIEDCODE(keyValue);
                    //新增历史表
                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "R";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    landcrackService.SaveForm("", historyInfo);
                    //删除最新数据
                    landcrack.RemoveForm(keyValue);
                }
                else if (keyValue.Substring(6,2) == "04")
                {
                    TBL_LANDSETTLEMENT_HISTORYEntity historyInfo = landsettlementService.GetEntityByUNIFIEDCODE(keyValue);
                    //新增历史表
                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "R";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    landsettlementService.SaveForm("", historyInfo);
                    //删除最新数据
                    landsettlement.RemoveForm(keyValue);
                }
            }
            else {//开启审核
                    String guid = "";
                    //往7类历史表加数据
                    if (keyValue.Substring(6,2) == "01")
                    {
                        TBL_LANDSLIP_HISTORYEntity historyInfo = landshipService.GetEntityByUNIFIEDCODE(keyValue);
                        //新增历史表
                        historyInfo.UPDATEUSER = userName;
                        historyInfo.UPDATETIME = modifyTime;

                        historyInfo.MODIFIEDDATE = modifyTime;
                        historyInfo.MODIFYTYPE = "R";
                        historyInfo.EDITOR = userName;
                        historyInfo.AUDITSTATUS = "0";
                        historyInfo.AUDITOR = auditor;
                        guid =landshipService.SaveEntity(string.Empty, historyInfo);
                        //删除最新数据
                        //landship.RemoveForm(keyValue);
                        //新增审核表
                        TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                        auditEntity.UPDATETIME = modifyTime;
                        auditEntity.UPDATETYPE = "R";
                        auditEntity.UPDATEUSER = userName;
                        auditEntity.STATUS = "0";
                        auditEntity.BUSSNESSTYPE = "A";
                        auditEntity.BUSINESSID = guid;
                        auditEntity.BASICINFO = "TBL_LANDSLIP_HISTORY," + hazardInfo.DISASTERNAME + "," + hazardInfo.UNIFIEDCODE + "," + hazardInfo.DISASTERTYPE;
                        auditEntity.AUDITOR = auditor;
                        audit.SaveForm("", auditEntity);
                    }
                    else if (keyValue.Substring(6,2) == "00")
                    {
                        TBL_SLOPE_HISTORYEntity historyInfo = slopeService.GetEntityByUNIFIEDCODE(keyValue);
                        //新增历史表
                        historyInfo.UPDATEUSER = userName;
                        historyInfo.UPDATETIME = modifyTime;

                        historyInfo.MODIFIEDDATE = modifyTime;
                        historyInfo.MODIFYTYPE = "R";
                        historyInfo.EDITOR = userName;
                        historyInfo.AUDITSTATUS = "0";
                        historyInfo.AUDITOR = auditor;
                        guid = slopeService.SaveForm("", historyInfo);
                        //删除最新数据
                       // slope.RemoveForm(keyValue);
                        TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                        auditEntity.UPDATETIME = modifyTime;
                        auditEntity.UPDATETYPE = "R";
                        auditEntity.UPDATEUSER = userName;
                        auditEntity.STATUS = "0";
                        auditEntity.BUSSNESSTYPE = "A";
                        auditEntity.BUSINESSID = guid;
                        auditEntity.BASICINFO = "TBL_SLOPE_HISTORY," + hazardInfo.DISASTERNAME + "," + hazardInfo.UNIFIEDCODE + "," + hazardInfo.DISASTERTYPE;
                        auditEntity.AUDITOR = auditor;
                        audit.SaveForm("", auditEntity);

                    }
                    else if (keyValue.Substring(6,2) == "05")
                    {
                        TBL_COLLAPSE_HISTORYEntity historyInfo = collapseService.GetEntityByUNIFIEDCODE(keyValue);
                        //新增历史表
                        historyInfo.UPDATEUSER = userName;
                        historyInfo.UPDATETIME = modifyTime;

                        historyInfo.MODIFIEDDATE = modifyTime;
                        historyInfo.MODIFYTYPE = "R";
                        historyInfo.EDITOR = userName;
                        historyInfo.AUDITSTATUS = "0";
                        historyInfo.AUDITOR = auditor;
                        guid = collapseService.SaveForm("", historyInfo);
                        //删除最新数据
                        //collapse.RemoveForm(keyValue);
                        TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                        auditEntity.UPDATETIME = modifyTime;
                        auditEntity.UPDATETYPE = "R";
                        auditEntity.UPDATEUSER = userName;
                        auditEntity.STATUS = "0";
                        auditEntity.BUSSNESSTYPE = "A";
                        auditEntity.BUSINESSID = guid;
                        auditEntity.BASICINFO = "TBL_COLLAPSE_HISTORY," + hazardInfo.DISASTERNAME + "," + hazardInfo.UNIFIEDCODE + "," + hazardInfo.DISASTERTYPE;
                        auditEntity.AUDITOR = auditor;
                        audit.SaveForm("", auditEntity);
                    }
                    else if (keyValue.Substring(6,2) == "02")
                    {
                        TBL_AVALANCHE_HISTORYEntity historyInfo = avalanceService.GetEntityByUNIFIEDCODE(keyValue);
                        //新增历史表
                        historyInfo.UPDATEUSER = userName;
                        historyInfo.UPDATETIME = modifyTime;

                        historyInfo.MODIFIEDDATE = modifyTime;
                        historyInfo.MODIFYTYPE = "R";
                        historyInfo.EDITOR = userName;
                        historyInfo.AUDITSTATUS = "0";
                        historyInfo.AUDITOR = auditor;
                        guid = avalanceService.SaveForm("", historyInfo);
                        //删除最新数据
                        //avalance.RemoveForm(keyValue);
                        TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                        auditEntity.UPDATETIME = modifyTime;
                        auditEntity.UPDATETYPE = "R";
                        auditEntity.UPDATEUSER = userName;
                        auditEntity.STATUS = "0";
                        auditEntity.BUSSNESSTYPE = "A";
                        auditEntity.BUSINESSID = guid;
                        auditEntity.BASICINFO = "TBL_AVALANCHE_HISTORY," + hazardInfo.DISASTERNAME + "," + hazardInfo.UNIFIEDCODE + "," + hazardInfo.DISASTERTYPE;
                        auditEntity.AUDITOR = auditor;
                        audit.SaveForm("", auditEntity);
                    }
                    else if (keyValue.Substring(6,2) == "03")
                    {
                        TBL_DEBRISFLOW_HISTORYEntity historyInfo = debrisflowService.GetEntityByUNIFIEDCODE(keyValue);
                        //新增历史表
                        historyInfo.UPDATEUSER = userName;
                        historyInfo.UPDATETIME = modifyTime;

                        historyInfo.MODIFIEDDATE = modifyTime;
                        historyInfo.MODIFYTYPE = "R";
                        historyInfo.EDITOR = userName;
                        historyInfo.AUDITSTATUS = "0";
                        historyInfo.AUDITOR = auditor;
                        guid = debrisflowService.SaveForm("", historyInfo);
                        //删除最新数据
                        //debrisflow.RemoveForm(keyValue);
                        TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                        auditEntity.UPDATETIME = modifyTime;
                        auditEntity.UPDATETYPE = "R";
                        auditEntity.UPDATEUSER = userName;
                        auditEntity.STATUS = "0";
                        auditEntity.BUSSNESSTYPE = "A";
                        auditEntity.BUSINESSID = guid;
                        auditEntity.BASICINFO = "TBL_DEBRISFLOW_HISTORY," + hazardInfo.DISASTERNAME + "," + hazardInfo.UNIFIEDCODE + "," + hazardInfo.DISASTERTYPE;
                        auditEntity.AUDITOR = auditor;
                        audit.SaveForm("", auditEntity);
                    }
                    else if (keyValue.Substring(6,2) == "06")
                    {
                        TBL_LANDCRACK_HISTORYEntity historyInfo = landcrackService.GetEntityByUNIFIEDCODE(keyValue);
                        //新增历史表
                        historyInfo.UPDATEUSER = userName;
                        historyInfo.UPDATETIME = modifyTime;

                        historyInfo.MODIFIEDDATE = modifyTime;
                        historyInfo.MODIFYTYPE = "R";
                        historyInfo.EDITOR = userName;
                        historyInfo.AUDITSTATUS = "0";
                        historyInfo.AUDITOR = auditor;
                        guid = landcrackService.SaveForm("", historyInfo);
                        //删除最新数据
                        //landcrack.RemoveForm(keyValue);
                        TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                        auditEntity.UPDATETIME = modifyTime;
                        auditEntity.UPDATETYPE = "R";
                        auditEntity.UPDATEUSER = userName;
                        auditEntity.STATUS = "0";
                        auditEntity.BUSSNESSTYPE = "A";
                        auditEntity.BUSINESSID = guid;
                        auditEntity.BASICINFO = "TBL_LANDCRACK_HISTORY," + hazardInfo.DISASTERNAME + "," + hazardInfo.UNIFIEDCODE + "," + hazardInfo.DISASTERTYPE;
                        auditEntity.AUDITOR = auditor;
                        audit.SaveForm("", auditEntity);
                    }
                    else if (keyValue.Substring(6,2) == "04")
                    {
                        TBL_LANDSETTLEMENT_HISTORYEntity historyInfo = landsettlementService.GetEntityByUNIFIEDCODE(keyValue);
                        //新增历史表
                        historyInfo.UPDATEUSER = userName;
                        historyInfo.UPDATETIME = modifyTime;

                        historyInfo.MODIFIEDDATE = modifyTime;
                        historyInfo.MODIFYTYPE = "R";
                        historyInfo.EDITOR = userName;
                        historyInfo.AUDITSTATUS = "0";
                        historyInfo.AUDITOR = auditor;
                        guid = landsettlementService.SaveForm("", historyInfo);
                        //删除最新数据
                        //landsettlement.RemoveForm(keyValue);
                        TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                        auditEntity.UPDATETIME = modifyTime;
                        auditEntity.UPDATETYPE = "R";
                        auditEntity.UPDATEUSER = userName;
                        auditEntity.STATUS = "0";
                        auditEntity.BUSSNESSTYPE = "A";
                        auditEntity.BUSINESSID = guid;
                        auditEntity.BASICINFO = "TBL_LANDSETTLEMENT_HISTORY," + hazardInfo.DISASTERNAME + "," + hazardInfo.UNIFIEDCODE + "," + hazardInfo.DISASTERTYPE;
                        auditEntity.AUDITOR = auditor;
                        audit.SaveForm("", auditEntity);
                    }

                }
                
        }
        #endregion
        public string search(string queryJson)
        {
            string sql = @" SELECT  *  FROM  TBL_XIAOHAO  WHERE 1=1 ";
            var basicinfos = searchSH().ToList();
            sql += " AND  UNIFIEDCODE  in('" + string.Join("','", basicinfos.ToArray()) + "') ";
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                //关键字灾害点名称或者编号或地理位置
                string txt_Key = json.txt_Key;
                if (!string.IsNullOrEmpty(txt_Key))
                {
                    sql = string.Format(sql + " AND  DISASTERNAME  LIKE  '%{0}%'  OR  UNIFIEDCODE  LIKE  '%{0}%'  OR  LOCATION  LIKE  '%{0}%' ", txt_Key);
                }
                //灾害点名称
                string DISASTERNAME = json.DISASTERNAME;
                if (!string.IsNullOrEmpty(DISASTERNAME))
                {
                    sql = string.Format(sql+ " AND  DISASTERNAME  = '{0}' ", DISASTERNAME);
                }
                //灾害点类型
                string DISASTERTYPE = json.DISASTERTYPE;
                if (!string.IsNullOrEmpty(DISASTERTYPE))
                {
                    sql = string.Format(sql + " AND  DISASTERTYPE  = '{0}' ", DISASTERTYPE);
                }
                //灾害点编号
                string UNIFIEDCODE = json.UNIFIEDCODE;
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    sql = string.Format(sql + " AND  UNIFIEDCODE  = '{0}' ", UNIFIEDCODE);
                }
                //野外编号
                string OUTDOORCODE = json.OUTDOORCODE;
                if (!string.IsNullOrEmpty(OUTDOORCODE))
                {
                    sql = string.Format(sql + " AND  OUTDOORCODE  = '{0}' ", OUTDOORCODE);
                }
                //开始时间
                string STARTTIME = json.STARTTIME;
                if (!string.IsNullOrEmpty(STARTTIME))
                {
                    DateTime date1 = Convert.ToDateTime(STARTTIME);
                    sql = string.Format(sql + " AND  XHSJ  >=  to_date('{0}','yyyy/mm/dd')  ", date1);
                }
                //结束时间
                string ENDTIME = json.ENDTIME;
                if (!string.IsNullOrEmpty(ENDTIME))
                {
                    DateTime date2 = Convert.ToDateTime(ENDTIME);
                    sql = string.Format(sql + " AND  XHSJ  <=  to_date('{0}','yyyy/mm/dd')  ", date2);
                }
                //行政区划
                string AreaCode = json.AreaCode;
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    if (AreaCode.EndsWith("0000"))
                    {
                        sql = string.Format(sql + " AND  XZQHCODE  LIKE  '{0}%' ", AreaCode.Substring(0,2));
                    }
                    else if (AreaCode.EndsWith("00"))
                    {
                        sql = string.Format(sql + " AND  XZQHCODE   LIKE  '{0}%'  ", AreaCode.Substring(0,4));
                    }
                    else
                    {
                        sql = string.Format(sql + " AND  XZQHCODE   LIKE  '{0}%'  ", AreaCode.Substring(0,6));
                    }
                }
                //数据范围权限过滤
                List<string> _codes = ssoWS.GetAllAuthDistricts();
                if (!_codes.Contains("000000") && !_codes.Equals("0"))
                {
                    sql += " AND XZQHCODE in('" + string.Join("','", _codes.ToArray()) + "') ";
                }
                return sql;
            }
            return sql;
        }
        #region 筛选条件
        System.Linq.Expressions.Expression<Func<TBL_XIAOHAOEntity, bool>> queryJsonExpression(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_XIAOHAOEntity>();
            if (!string.IsNullOrEmpty(queryJson) && queryJson != "{}")
            {
                dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
                //关键字灾害点名称或者编号或地理位置
                string txt_Key = json.txt_Key;
                if (!string.IsNullOrEmpty(txt_Key))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(txt_Key) || t.UNIFIEDCODE == txt_Key || t.LOCATION.Contains(txt_Key));
                }
                //灾害点名称
                string DISASTERNAME = json.DISASTERNAME;
                if (!string.IsNullOrEmpty(DISASTERNAME))
                {
                    expression = expression.And(t => t.DISASTERNAME.Contains(DISASTERNAME));
                }
                //灾害点类型
                string DISASTERTYPE = json.DISASTERTYPE;
                if (!string.IsNullOrEmpty(DISASTERTYPE))
                {
                    expression = expression.And(t => t.DISASTERTYPE.Equals(DISASTERTYPE));
                }
                //灾害点编号
                string UNIFIEDCODE = json.UNIFIEDCODE;
                if (!string.IsNullOrEmpty(UNIFIEDCODE))
                {
                    expression = expression.And(t => t.UNIFIEDCODE.Contains(UNIFIEDCODE));
                }
                //野外编号
                string OUTDOORCODE = json.OUTDOORCODE;
                if (!string.IsNullOrEmpty(OUTDOORCODE))
                {
                    expression = expression.And(t => t.OUTDOORCODE.Contains(OUTDOORCODE));
                }
                //开始时间
                string STARTTIME = json.STARTTIME;
                if (!string.IsNullOrEmpty(STARTTIME))
                {
                    DateTime date1 = Convert.ToDateTime(STARTTIME);
                    expression = expression.And(t => t.XHSJ >= date1);
                }
                //结束时间
                string ENDTIME = json.ENDTIME;
                if (!string.IsNullOrEmpty(ENDTIME))
                {
                    DateTime date2 = Convert.ToDateTime(ENDTIME);
                    expression = expression.And(t => t.XHSJ <= date2);
                }
                //行政区划
                string AreaCode = json.AreaCode;
                if (!string.IsNullOrEmpty(AreaCode))
                {
                    if (AreaCode.EndsWith("0000"))
                    {
                        expression = expression.And(t => t.XZQHCODE.Contains(AreaCode.Substring(0, 2)));
                    }
                    else if (AreaCode.EndsWith("00"))
                    {
                        expression = expression.And(t => t.XZQHCODE.Contains(AreaCode.Substring(0, 4)));
                    }
                    else
                    {
                        expression = expression.And(t => t.XZQHCODE.Contains(AreaCode.Substring(0, 6)));
                    }
                }
                //数据范围权限过滤
                List<string> _codes = ssoWS.GetAllAuthDistricts();
                if (!_codes.Contains("000000") && !_codes.Equals("0"))
                {
                    expression = expression.And(t => _codes.Contains(t.XZQHCODE));
                }
                var basicinfos = searchSH().ToList();
                expression.And(p => basicinfos.Contains(p.UNIFIEDCODE));
                return expression;
            }
            return expression;
        }
        #endregion


        #region 省地市编码转换
        private Expression<Func<TBL_XIAOHAOEntity, bool>> GetRegionExpression(JObject queryParam)
        {
            Expression<Func<TBL_XIAOHAOEntity, bool>> exp = LinqExtensions.True<TBL_XIAOHAOEntity>();
            if (!queryParam["PROVINCE"].IsEmpty())
            {
                if (!queryParam["CITY"].IsEmpty())
                {
                    if (!queryParam["COUNTY"].IsEmpty())
                    {
                        string[] strArr = queryParam["COUNTY"].ToString().Split(',');
                        exp = exp.And(GetLamdaList(strArr));
                    }
                    else
                    {
                        string[] strArr = queryParam["CITY"].ToString().Split(',');
                        exp = exp.And(GetLamdaList(strArr));
                    }
                }
                else
                {
                    string[] strArr = queryParam["PROVINCE"].ToString().Split(',');
                    exp = exp.And(GetLamdaList(strArr));
                }
            }
            return exp;
        }


        private Expression<Func<TBL_XIAOHAOEntity, bool>> GetLamdaList(string[] codeArr)
        {
            Expression<Func<TBL_XIAOHAOEntity, bool>> exp = LinqExtensions.True<TBL_XIAOHAOEntity>();
            for (int i = 0; i < codeArr.Length; i++)
            {
                var lamda = GetLamda(codeArr[i]);
                if (i == 0)
                {
                    exp = exp.And(lamda);
                }
                else
                {
                    exp = exp.Or(lamda);
                }
            }
            return exp;
        }

        private System.Linq.Expressions.Expression<Func<TBL_XIAOHAOEntity, bool>> GetLamda(string code)
        {
            System.Linq.Expressions.Expression<Func<TBL_XIAOHAOEntity, bool>> exp = LinqExtensions.True<TBL_XIAOHAOEntity>();
            if (code.Length == 9)
            {
                exp = s => s.UNIFIEDCODE.StartsWith(code);
            }
            else
            {
                if (code.EndsWith("0000"))
                {
                    string value = code.Substring(0, 2);
                    exp = s => s.UNIFIEDCODE.Substring(0, 2) == value;
                }
                else
                {
                    if (code.EndsWith("00"))
                    {
                        exp = s => s.UNIFIEDCODE.Substring(0, 4) == code.Substring(0, 4);
                    }
                    else
                    {
                        exp = s => s.UNIFIEDCODE.Substring(0, 6) == code;
                    }
                }
            }
            return exp;
        }
        #endregion
    }
}
