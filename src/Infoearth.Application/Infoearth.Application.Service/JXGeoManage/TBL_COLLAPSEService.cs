using Infoearth.Application.Entity;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-13 14:44
    /// 描 述：地面塌陷调查表
    /// </summary>
    public class TBL_COLLAPSEService : RepositoryFactory<TBL_COLLAPSEEntity>, TBL_COLLAPSEIService, IAudit
    {
        private TBL_AUDITORSIService audits = new TBL_AUDITORSService();
        private TBL_HAZARDBASICINFOIService hazard = new TBL_HAZARDBASICINFOService();
        private TBL_COLLAPSE_HISTORYIService history = new TBL_COLLAPSE_HISTORYService();
        private TBL_AUDITINFOIService audit = new TBL_AUDITINFOService();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private TBL_HAZARDBASICINFO_HISTORYIService hazardHistory = new TBL_HAZARDBASICINFO_HISTORYService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_COLLAPSEEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_COLLAPSEEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_COLLAPSEEntity GetEntity(string keyValue)
        {
            //if (keyValue.Length == 12)
            //{
            //    keyValue += " " + " " + " " + " ";
            //}
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
        public void SaveForm(string keyValue, TBL_COLLAPSEEntity entity, NEWTBL_COLLAPSEEntity newentity=null)
        {
            //拆分地理位置（用于基础表赋值）

            string disasterType = "地面塌陷";

            DateTime modifyTime = DateTime.Now;
            string[] location = new string[] { };
            string provice = string.Empty;
            string city = string.Empty;
            string county = string.Empty;
            string town = string.Empty;
            string VILLAGE = string.Empty;
            string TEAM = string.Empty;
            if (newentity != null)
            {
                provice = newentity.PROVINCENAME;
                city = newentity.CITYNAME;
                county = newentity.COUNTYNAME;
                town = newentity.TOWNNAME;
                VILLAGE = newentity.VILLAGE;
                TEAM = newentity.TEAM;
            }
            else
            {
                provice = entity.PROVINCENAME;
                city = entity.CITYNAME.Split(',').Length > 0 ? entity.CITYNAME.Split(',')[0] : "";
                county = entity.COUNTYNAME;
                town = entity.TOWNNAME;
                VILLAGE = entity.VILLAGE;
                TEAM = entity.TEAM;
                //location = entity.LOCATION.Split(',');
                //provice = location[0];
                //city = location[1];
                //county = location[2];
                //if (location.Count() > 3)
                //{
                //    town = location[3];
                //}
            }

            //获取当前用户名称
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;

            // string auditor = audits.GetAudits(entity.TOWN, "A");  //A表示地灾调查的审核
            string auditor = audits.GetAudits(entity.UNIFIEDCODE.Substring(0, 6), "A");  //A表示地灾调查的审核
            entity.COUNTYCODE = entity.UNIFIEDCODE.Substring(0, 6);
            #region 数据保存

            //未开启审核
            if (string.IsNullOrEmpty(auditor))
            {
                //编辑
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //if (keyValue.Length == 12)
                    //{
                    //    keyValue += " " + " " + " " + " ";
                    //}
                    TBL_HAZARDBASICINFOEntity hazardInfo = hazard.GetEntity(keyValue);
                    //编辑基本信息表
                    EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_HAZARDBASICINFOEntity>(entity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = entity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = entity.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.HIDDENDANGER = entity.HIDDENPOINT;
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;

                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    // hazardInfo.LOCATION = entity.LOCATION.Replace(",", "");
                    hazardInfo.LOCATION = entity.LOCATION;
                    hazardInfo.MODIFYTIME = modifyTime;
                    hazardInfo.MODIFYUSER = userName;

                    hazard.SaveForm(keyValue, hazardInfo);

                    //编辑详情表
                    entity.UPDATEUSER = userName;
                    entity.UPDATETIME = modifyTime;

                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);

                    //新增历史表
                    TBL_COLLAPSE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_COLLAPSE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "U";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    history.SaveForm(string.Empty, historyInfo);

                    #region 添加到历史索引表 2019-2-14 by wc

                    TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = "U";
                    basicHistoryInfo.MODIFYUSER = userName;
                    basicHistoryInfo.AUDITSTATUS = "5";
                    basicHistoryInfo.AUDITOR = auditor;
                    basicHistoryInfo.THREATENPEOPLE = entity.THREATENPEOPLE;//威胁人口
                    basicHistoryInfo.THREATENASSETS = entity.THREATENASSETS;//威胁财产
                    basicHistoryInfo.FILLTABLEDATE = historyInfo.FILLTABLEDATE;

                    hazardHistory.SaveEntity(historyInfo.GUID, basicHistoryInfo);

                    #endregion
                }
                //新增
                else
                {
                    //新增基本信息表
                    TBL_HAZARDBASICINFOEntity hazardInfo = EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_HAZARDBASICINFOEntity>(entity);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = entity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = entity.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.HIDDENDANGER = entity.HIDDENPOINT;
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    //hazardInfo.LOCATION = entity.LOCATION.Replace(",", "");
                    hazardInfo.LOCATION = entity.LOCATION;
                    hazardInfo.MODIFYTIME = modifyTime;
                    hazardInfo.MODIFYUSER = userName;
                    hazardInfo.CREATETIME = modifyTime;
                    hazardInfo.CREATEUSER = userName;
                    hazardInfo.ISXH = "0";
                    hazard.SaveForm(keyValue, hazardInfo);

                    //新增详情表

                    entity.UPDATEUSER = userName;
                    entity.UPDATETIME = modifyTime;
                    entity.CREATORTIME = modifyTime;
                    entity.CREATORUSERID = userName;

                    this.BaseRepository().Insert(entity);

                    //新增历史表
                    TBL_COLLAPSE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_COLLAPSE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;
                    historyInfo.CREATORTIME = modifyTime;
                    historyInfo.CREATORUSERID = userName;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "A";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    history.SaveForm(string.Empty, historyInfo);

                    #region 添加到历史索引表 2019-2-14 by wc

                    TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = "A";
                    basicHistoryInfo.MODIFYUSER = userName;
                    basicHistoryInfo.AUDITSTATUS = "5";
                    basicHistoryInfo.AUDITOR = auditor;
                    basicHistoryInfo.THREATENPEOPLE = entity.THREATENPEOPLE;//威胁人口
                    basicHistoryInfo.THREATENASSETS = entity.THREATENASSETS;//威胁财产
                    basicHistoryInfo.FILLTABLEDATE = historyInfo.FILLTABLEDATE;

                    hazardHistory.SaveEntity(historyInfo.GUID, basicHistoryInfo);

                    #endregion

                }
            }
            //开启审核
            else
            {
                //编辑
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //新增历史表
                    TBL_COLLAPSE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_COLLAPSE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "U";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "0";
                    historyInfo.AUDITOR = auditor;
                    historyInfo.GUID=history.SaveForm(string.Empty, historyInfo);

                    //新增审核表
                    TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                    auditEntity.UPDATETIME = modifyTime;
                    auditEntity.UPDATETYPE = "U";
                    auditEntity.UPDATEUSER = userName;
                    auditEntity.STATUS = "0";
                    auditEntity.BUSSNESSTYPE = "A";
                    auditEntity.BUSINESSID = historyInfo.GUID;
                    auditEntity.BASICINFO = "TBL_COLLAPSE_HISTORY," + historyInfo.DISASTERUNITNAME + "," + historyInfo.UNIFIEDCODE + "," + disasterType;
                    auditEntity.AUDITOR = auditor;
                    audit.SaveForm(string.Empty, auditEntity);
                }
                else
                {
                    //新增历史表
                    TBL_COLLAPSE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_COLLAPSE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;
                    historyInfo.CREATORTIME = modifyTime;
                    historyInfo.CREATORUSERID = userName;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "A";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "0";
                    historyInfo.AUDITOR = auditor;
                    historyInfo.GUID=history.SaveForm(string.Empty, historyInfo);

                    //新增审核表
                    TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                    auditEntity.UPDATETIME = modifyTime;
                    auditEntity.UPDATETYPE = "A";
                    auditEntity.UPDATEUSER = userName;
                    auditEntity.BUSSNESSTYPE = "A";
                    auditEntity.STATUS = "0";
                    auditEntity.BUSINESSID = historyInfo.GUID;
                    auditEntity.BASICINFO = "TBL_COLLAPSE_HISTORY," + historyInfo.DISASTERUNITNAME + "," + historyInfo.UNIFIEDCODE + "," + disasterType;
                    auditEntity.AUDITOR = auditor;
                    audit.SaveForm(string.Empty, auditEntity);
                }
            }

            #endregion
        }
        #endregion

        #region 审核相关

        public void AuditData(string bussnessId, string updateType)
        {
            //查询数据 
            TBL_COLLAPSE_HISTORYEntity historyEntity = history.GetEntity(bussnessId);

            TBL_HAZARDBASICINFOEntity hazardInfo = null;

            TBL_COLLAPSEEntity entity = null;

            string disasterType = "地面塌陷";

            DateTime modifyTime = DateTime.Now;

            //string[] location = historyEntity.LOCATION.Split(',');

            //string provice = location[0];
            //string city = location[1];
            //string county = location[2];
            //string town = string.Empty;
            //if (location.Count() > 3)
            //{
            //    town = location[3];
            //}
            string provice = historyEntity.PROVINCENAME;
            string city = historyEntity.CITYNAME.Split(',').Length > 0 ? historyEntity.CITYNAME.Split(',')[0] : "";
            string county = historyEntity.COUNTYNAME;
            string town = historyEntity.TOWNNAME;
            string VILLAGE = historyEntity.VILLAGE;
            string TEAM = historyEntity.TEAM;
            switch (updateType)
            {
                //新增
                case "A":
                    //新增基本信息表
                    hazardInfo = EntityCoverter.Covert<TBL_COLLAPSE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");
                    hazardInfo.HIDDENDANGER = historyEntity.HIDDENPOINT;
                    hazardInfo.CREATETIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.CREATEUSER = historyEntity.EDITOR;
                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;
                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    hazard.SaveForm(string.Empty, hazardInfo);

                    //新增详情表
                    entity = EntityCoverter.Covert<TBL_COLLAPSE_HISTORYEntity, TBL_COLLAPSEEntity>(historyEntity);
                    this.BaseRepository().Insert(entity);

                    #region 添加到历史索引表 2019-2-14 by wc

                    TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion

                    break;
                case "U":
                    hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);
                    //编辑基本信息表
                    EntityCoverter.Covert<TBL_COLLAPSE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");
                    hazardInfo.HIDDENDANGER = historyEntity.HIDDENPOINT;
                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;
                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    hazard.SaveForm(historyEntity.UNIFIEDCODE, hazardInfo);

                    //编辑详情表
                    entity = EntityCoverter.Covert<TBL_COLLAPSE_HISTORYEntity, TBL_COLLAPSEEntity>(historyEntity);
                    entity.Modify(historyEntity.UNIFIEDCODE);
                    this.BaseRepository().Update(entity);

                    #region 添加到历史索引表 2019-2-14 by wc

                    basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion
                    break;
                case "D":

                    #region 新增历史索引表 2019-2-14 by wc

                    hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);

                    EntityCoverter.Covert<TBL_COLLAPSE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");

                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                    basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.ISXH = "1";
                    basicHistoryInfo.VERIFICATION = historyEntity.VERIFICATION;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion

                    //删除基本信息表
                    hazard.RemoveForm(historyEntity.UNIFIEDCODE);

                    //删除详情表
                    this.BaseRepository().Delete(historyEntity.UNIFIEDCODE);

                    //将所有该条灾害点的历史数据核销状态修改
                    string sql = string.Format("update TBL_COLLAPSE_HISTORY set verification = '{0}' where GUID = '{1}'", historyEntity.VERIFICATION, bussnessId);
                    int result = this.BaseRepository().ExecuteBySql(sql);


                    break;
                case "R":

                    #region 新增历史索引表 2019-2-14 by wc

                    hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);

                    EntityCoverter.Covert<TBL_COLLAPSE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");

                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                    basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.ISXH = "1";
                    basicHistoryInfo.VERIFICATION = historyEntity.VERIFICATION;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion

                    //删除基本信息表
                    hazard.RemoveForm(historyEntity.UNIFIEDCODE);

                    //删除详情表
                    this.BaseRepository().Delete(historyEntity.UNIFIEDCODE);

                    break;
                default:
                    break;
            }
        }

        public void VerificationData(string bussnessKey, int verificationType, DateTime fillTableDate)
        {
            //详情表
            TBL_COLLAPSEEntity entity = this.BaseRepository().FindEntity(bussnessKey);
            string auditInfo = audits.GetAudits(entity.TOWN, "A");

            DateTime now = DateTime.Now;
            string disasterType = "地面塌陷";
            //获取当前用户名称
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;

            //开启审核
            if (!string.IsNullOrEmpty(auditInfo))
            {
                //新增历史表
                TBL_COLLAPSE_HISTORYEntity historyEntity = EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_COLLAPSE_HISTORYEntity>(entity);
                historyEntity.MODIFIEDDATE = now;
                historyEntity.MODIFYTYPE = "D";
                historyEntity.EDITOR = userName;
                historyEntity.AUDITSTATUS = "0";
                historyEntity.AUDITOR = auditInfo;
                historyEntity.VERIFICATION = verificationType.ToString();
                historyEntity.FILLTABLEDATE = fillTableDate;
                history.SaveForm(string.Empty, historyEntity);

                //新增审核表
                TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                auditEntity.Create();
                auditEntity.UPDATETIME = now;
                auditEntity.UPDATETYPE = "D";
                auditEntity.UPDATEUSER = userName;
                auditEntity.STATUS = "0";
                auditEntity.BUSINESSID = historyEntity.GUID;
                auditEntity.BUSSNESSTYPE = "A";
                auditEntity.BASICINFO = "TBL_COLLAPSE_HISTORY," + historyEntity.DISASTERUNITNAME + "," + historyEntity.UNIFIEDCODE + "," + disasterType;
                auditEntity.AUDITOR = auditInfo;
                audit.SaveForm(string.Empty, auditEntity);
            }
            //未开启审核
            else
            {
                //新增历史表
                TBL_COLLAPSE_HISTORYEntity historyEntity = EntityCoverter.Covert<TBL_COLLAPSEEntity, TBL_COLLAPSE_HISTORYEntity>(entity);
                historyEntity.MODIFIEDDATE = now;
                historyEntity.MODIFYTYPE = "D";
                historyEntity.EDITOR = userName;
                historyEntity.AUDITSTATUS = "5";  //跳过审核
                historyEntity.AUDITOR = auditInfo;
                historyEntity.VERIFICATION = verificationType.ToString();
                historyEntity.FILLTABLEDATE = fillTableDate;
                history.SaveForm(string.Empty, historyEntity);

                #region 新增历史索引表

                //string[] location = historyEntity.LOCATION.Split(',');

                //string provice = location[0];
                //string city = location[1];
                //string county = location[2];
                //string town = string.Empty;
                //if (location.Count() > 3)
                //{
                //    town = location[3];
                //}
                TBL_HAZARDBASICINFOEntity hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);
                string[] location = historyEntity.LOCATION.Split(',');
                string provice = string.Empty;
                string city = string.Empty;
                string county = string.Empty;
                string town = string.Empty;
                if (location.Count() > 2)
                {
                    provice = location[0];
                    city = location[1];
                    county = location[2];
                    if (location.Count() > 3)
                    {
                        town = location[3];
                    }
                }
                else
                {
                    provice = hazardInfo.PROVINCENAME;
                    city = hazardInfo.CITYNAME;
                    county = hazardInfo.COUNTYNAME;
                    town = hazardInfo.TOWNNAME;
                }
                //TBL_HAZARDBASICINFOEntity hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);

                EntityCoverter.Covert<TBL_COLLAPSE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                hazardInfo.DISASTERTYPE = disasterType;
                hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                hazardInfo.PROVINCENAME = provice;
                hazardInfo.CITYNAME = city;
                hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                hazardInfo.COUNTYNAME = county;
                hazardInfo.TOWNNAME = town;
                hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");

                hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                basicHistoryInfo.MODIFYTIME = now;
                basicHistoryInfo.MODIFYTYPE = "D";
                basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                basicHistoryInfo.AUDITSTATUS = "5";
                basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                basicHistoryInfo.ISXH = "1";
                basicHistoryInfo.VERIFICATION = historyEntity.VERIFICATION;
                basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                hazardHistory.SaveEntity(historyEntity.GUID, basicHistoryInfo);


                #endregion


                //删除详情表
                this.BaseRepository().Delete(bussnessKey);

                //删除基本信息表
                hazard.RemoveForm(bussnessKey);

            }
        }

        #endregion
    }
}
