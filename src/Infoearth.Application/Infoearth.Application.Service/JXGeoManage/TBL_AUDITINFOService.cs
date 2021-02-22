using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-17 14:51
    /// 描 述：审核信息表
    /// </summary>
    public class TBL_AUDITINFOService : RepositoryFactory<TBL_AUDITINFOEntity>, TBL_AUDITINFOIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private TBL_AUDITORSIService audits = new TBL_AUDITORSService();
        private TBL_HAZARDBASICINFOIService hazard = new TBL_HAZARDBASICINFOService();
        private TBL_AVALANCHE_HISTORYIService avalancehistory = new TBL_AVALANCHE_HISTORYService();
        private TBL_LANDSLIP_HISTORYIService sliphistory = new TBL_LANDSLIP_HISTORYService();
        private TBL_COLLAPSE_HISTORYIService collapsehistory = new TBL_COLLAPSE_HISTORYService();
        private TBL_DEBRISFLOW_HISTORYIService debrisflowhistory = new TBL_DEBRISFLOW_HISTORYService();
        private TBL_LANDSETTLEMENT_HISTORYIService settlementhistory = new TBL_LANDSETTLEMENT_HISTORYService();
        private TBL_LANDCRACK_HISTORYIService crackhistory = new TBL_LANDCRACK_HISTORYService();
        private TBL_SLOPE_HISTORYIService slopehistory = new TBL_SLOPE_HISTORYService();
        private TBL_AVALANCHE_HIDDEN_HISTORYService avalanchehidden = new TBL_AVALANCHE_HIDDEN_HISTORYService();
        private TBL_LANDSLIP_HIDDEN_HISTORYService landsliphidden = new TBL_LANDSLIP_HIDDEN_HISTORYService();
        private TBL_SENSE_HISTORYService sensehistory = new TBL_SENSE_HISTORYService();

        #region 获取数据
        /// <summary>
        /// 分页获取提交审核列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AUDITINFOEntity>();

            //获取当前用户名称
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;
            //筛选用户
            expression = expression.And(t => t.UPDATEUSER == userName);
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            //筛选时间
            string StartTime = json.StartTime;
            if (!string.IsNullOrEmpty(StartTime))
            {
                DateTime start = DateTime.Parse(StartTime);
                expression = expression.And(t => t.UPDATETIME >= start);
            }
            string EndTime = json.EndTime;
            if (!string.IsNullOrEmpty(EndTime))
            {
                DateTime end = DateTime.Parse(EndTime);
                expression = expression.And(t => t.UPDATETIME <= end);
            }
            //筛选数据名称
            string txt_keyword = json.txt_Keyword;
            if (!string.IsNullOrEmpty(txt_keyword))
            {
                expression = expression.And(t => t.BASICINFO != null && t.BASICINFO.Contains(txt_keyword));
            }
            //筛选更新类型
            string updateType = json.updateType;
            if (!string.IsNullOrEmpty(updateType))
                expression = expression.And(t => t.UPDATETYPE == updateType);

            //筛选审核类型
            string bussnessType = json.bussnessType;
            if (!string.IsNullOrEmpty(bussnessType))
                expression = expression.And(t => t.BUSSNESSTYPE == bussnessType);

            //筛选审核状态
            string status = json.status;
            if (!string.IsNullOrEmpty(status))
                expression = expression.And(t => t.STATUS == status);

            return this.BaseRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 分页获取待审核列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList2(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AUDITINFOEntity>();

            //获取当前用户名称
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;
            //筛选用户
            expression = expression.And(t => t.AUDITOR.Contains(userName));
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            //筛选关键字
            string txt_keyword = json.txt_Keyword;
            if (!string.IsNullOrEmpty(txt_keyword))
            {
                expression = expression.And(t => t.BASICINFO.Contains(txt_keyword));
            }
            //筛选时间
            string StartTime = json.StartTime;
            if (!string.IsNullOrEmpty(StartTime))
            {
                DateTime start = DateTime.Parse(StartTime);
                expression = expression.And(t => t.UPDATETIME >= start);
            }
            string EndTime = json.EndTime;
            if (!string.IsNullOrEmpty(EndTime))
            {
                DateTime end = DateTime.Parse(EndTime);
                expression = expression.And(t => t.UPDATETIME <= end);
            }
            //筛选更新类型
            string updateType = json.updateType;
            if (!string.IsNullOrEmpty(updateType))
                expression = expression.And(t => t.UPDATETYPE == updateType);

            //筛选审核类型
            string bussnessType = json.bussnessType;
            if (!string.IsNullOrEmpty(bussnessType))
                expression = expression.And(t => t.BUSSNESSTYPE == bussnessType);

            //筛选审核状态
            string status = json.status;
            if (!string.IsNullOrEmpty(status))
                expression = expression.And(t => t.STATUS == status);
            //去掉撤销的审核类型
            expression = expression.And(t => t.STATUS != "4" && t.STATUS != "0");
            return this.BaseRepository().FindList(expression, pagination); ;
        }
        /// <summary>
        /// 获取未审核的数据列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetPageList3(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AUDITINFOEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            string UNIFIEDCODE = json.unifycode;
            string type = json.type;
            var guids = "";
            if (type == "00")
            {
                var histotyDtos = slopehistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            } if (type == "01")
            {
                var histotyDtos = sliphistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "02")
            {
                var histotyDtos = avalancehistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "03")
            {
                var histotyDtos = debrisflowhistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "04")
            {
                var histotyDtos = settlementhistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "05")
            {
                var histotyDtos = collapsehistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "06")
            {
                var histotyDtos = crackhistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "07")
            {
                var histotyDtos = landsliphidden.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "08")
            {
                var histotyDtos = avalanchehidden.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            else if (type == "09")
            {
                var histotyDtos = sensehistory.GetList(queryJson);
                foreach (var histotyDto in histotyDtos)
                {
                    guids += histotyDto.GUID + ",";
                }
            }
            if (guids != "")
            {
                guids = guids.Substring(0, guids.Length - 1);
            }
            if (!string.IsNullOrEmpty(UNIFIEDCODE))
            {
                expression = expression.And(t => guids.Contains(t.BUSINESSID));
            }
            //待审核及未提交的数据
            expression = expression.And(t => t.STATUS == "1" || t.STATUS == "0");
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_AUDITINFOEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AUDITINFOEntity>();
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_AUDITINFOEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_AUDITINFOEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="keyValue">主键ID</param>
        public void SubmitAudit(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                //修改审计表
                TBL_AUDITINFOEntity entity = this.BaseRepository().FindEntity(keyValue);
                if (entity == null)
                    return;
                entity.STATUS = "1";
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);

                //修改业务表
                string basicInfo = entity.BASICINFO;  //历史表表名称,历史表数据名称,历史表字段A,历史表字段B...

                if (!string.IsNullOrEmpty(basicInfo))
                {
                    string[] infos = basicInfo.Split(',');

                    string sql = string.Format("update {0} set AUDITSTATUS = '1' where GUID = '{1}'", infos[0], entity.BUSINESSID);
                    int result = this.BaseRepository().ExecuteBySql(sql);
                }
            }
        }

        /// <summary>
        /// 撤销审核
        /// </summary>
        /// <param name="keyValue">业务ID</param>
        public void CancelSubmit(string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                //修改审计表
                TBL_AUDITINFOEntity entity = this.BaseRepository().FindEntity(keyValue);
                if (entity == null)
                    return;
                entity.STATUS = "4";
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);

                //修改业务表
                string basicInfo = entity.BASICINFO;  //历史表表名称,历史表数据名称,历史表字段A,历史表字段B...

                if (!string.IsNullOrEmpty(basicInfo))
                {
                    string[] infos = basicInfo.Split(',');

                    string sql = string.Format("update {0} set AUDITSTATUS = '4' where GUID = '{1}'", infos[0], entity.BUSINESSID);
                    int result = this.BaseRepository().ExecuteBySql(sql);
                }
            }
        }

        /// <summary>
        /// 审核数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="state">状态</param>
        /// <param name="comment">备注</param>
        public void AuditData(string keyValue, int state, string comment)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                //修改审计表
                TBL_AUDITINFOEntity entity = this.BaseRepository().FindEntity(keyValue);
                if (entity == null)
                    return;
                entity.STATUS = state.ToString();
                entity.REMARK = comment;
                entity.AUDITTIME = DateTime.Now;
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);

                //修改历史库
                string basicInfo = entity.BASICINFO;  //历史表表名称,历史表数据名称,历史表字段A,历史表字段B...

                if (!string.IsNullOrEmpty(basicInfo))
                {
                    string[] infos = basicInfo.Split(',');

                    var user = ssoWS.GetUserInfo();
                    //string sql = string.Format("update {0} set AUDITSTATUS = '{1}',AUDITOR='{2}',AUDITEDDATE=to_date('{3}','yyyy-MM-dd HH24:mi:SS') where GUID = '{4}'", infos[0], state, user.F_Account, DateTime.Now, entity.BUSINESSID);
                    string sql = string.Format("update {0} set AUDITSTATUS = '{1}',AUDITOR='{2}',AUDITEDDATE=" + DbSqlFunctionHelper.DateFormat(DateTime.Parse(string.Format("{0}", DateTime.Now)), "yyyy-MM-dd HH24:mi:SS") + " where GUID = '{4}'", infos[0], state, user.F_Account, DateTime.Now, entity.BUSINESSID);
                    int result = this.BaseRepository().ExecuteBySql(sql);

                    //审核通过
                    if (state == 2)
                    {
                        //操作业务库
                        IAudit audit = AuditFactory.Create(infos[0]);
                        audit.AuditData(entity.BUSINESSID, entity.UPDATETYPE);
                    }
                }
            }
        }

        /// <summary>
        /// 核销数据
        /// </summary>
        /// <param name="unifycode">灾害点编号</param>
        /// <param name="verification">核销类型</param>
        /// <param name="fillTableDate">填表日期</param>
        public void VerificationData(string unifycode, int verification, DateTime fillTableDate)
        {
            var hazardInfo = hazard.GetEntity(unifycode);
            if (hazardInfo != null)
            {
                IAudit audit = AuditFactory.Create2(hazardInfo.DISASTERTYPE);
                audit.VerificationData(unifycode, verification, fillTableDate);
            }
        }

        #endregion
    }
}
