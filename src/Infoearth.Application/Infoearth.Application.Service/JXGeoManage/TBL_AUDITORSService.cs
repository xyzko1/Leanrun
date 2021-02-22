using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：超级管理员
    /// 日 期：2018-03-17 14:53
    /// 描 述：审计人表
    /// </summary>
    public class TBL_AUDITORSService : RepositoryFactory<TBL_AUDITORSEntity>, TBL_AUDITORSIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<TBL_AUDITORSEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AUDITORSEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            string areaCode = json.AreaCode;
            string keyword = json.txt_Keyword;
            if (!string.IsNullOrEmpty(areaCode))
            {
                if (areaCode.Length == 9)
                    expression = expression.And(t => t.DISTRICTCODE == areaCode);

                else if (areaCode.Length == 6)
                {
                    if (areaCode.EndsWith("0000"))
                    {
                        expression = expression.And(t => t.DISTRICTCODE.StartsWith(areaCode.Substring(0, 2)));
                    }
                    else if (areaCode.EndsWith("00"))
                    {
                        expression = expression.And(t => t.DISTRICTCODE.StartsWith(areaCode.Substring(0, 4)));
                    }
                    else
                    {
                        expression = expression.And(t => t.DISTRICTCODE.StartsWith(areaCode.Substring(0, 6)));
                    }
                }
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.NAME.Contains(keyword));
            }
            //数据范围权限过滤
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000") && !_codes.Equals("0"))
            {
                expression = expression.And(t => _codes.Contains(t.DISTRICTCODE));
            }
            return this.BaseRepository().FindList(expression, pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_AUDITORSEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_AUDITORSEntity>();
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            string areaCode = json.AreaCode;
            string keyword = json.txt_Keyword;
            if (!string.IsNullOrEmpty(areaCode))
            {
                if (areaCode.Length == 9)
                    expression = expression.And(t => t.DISTRICTCODE == areaCode);

                else if (areaCode.Length == 6)
                {
                    if (areaCode.EndsWith("0000"))
                    {
                        expression = expression.And(t => t.DISTRICTCODE.StartsWith(areaCode.Substring(0, 2)));
                    }
                    else if (areaCode.EndsWith("00"))
                    {
                        expression = expression.And(t => t.DISTRICTCODE.StartsWith(areaCode.Substring(0, 4)));
                    }
                    else
                    {
                        expression = expression.And(t => t.DISTRICTCODE.StartsWith(areaCode.Substring(0, 6)));
                    }
                }
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.NAME.Contains(keyword));
            }
            //数据范围权限过滤
            List<string> _codes = ssoWS.GetAllAuthDistricts();
            if (!_codes.Contains("000000") && !_codes.Equals("0"))
            {
                expression = expression.And(t => _codes.Contains(t.DISTRICTCODE));
            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_AUDITORSEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_AUDITORSEntity entity)
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
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="STATE">状态</param>
        /// <param name="GUIDS">guid</param>
        /// <returns></returns>
        public void SaveFormNew(string STATE, string GUIDS)
        {
            string sql = "";
            sql = "UPDATE TBL_AUDITORS set ISAUDIT='"+STATE+"'  WHERE GUID in ("+GUIDS+")";
            this.BaseRepository().ExecuteBySql(sql);
        }
        public void deleteNew(string GUIDS)
        {
            string sql = "";
            sql = "DELETE FROM TBL_AUDITORS  WHERE GUID in (" + GUIDS + ")";
            this.BaseRepository().ExecuteBySql(sql);
        }
        /// <summary>
        /// 根据行政区划和业务类型查找审核人
        /// </summary>
        /// <param name="distinct"></param>
        /// <param name="bussnessType"></param>
        /// <returns></returns>
        public string GetAudits(string distinct, string bussnessType)
        {
            var expression = LinqExtensions.True<TBL_AUDITORSEntity>();
            expression = expression.And(t => t.ISAUDIT == "0");
            if (!string.IsNullOrEmpty(bussnessType))
            {
                expression = expression.And(t => t.BUSSNESSTYPE == bussnessType);
            }
            string[] result = new string[] { };
            if (!string.IsNullOrEmpty(distinct))
            {
               var expression1 = LinqExtensions.False<TBL_AUDITORSEntity>();
               expression1 = expression1.Or(t => t.DISTRICTCODE == distinct);
               result = this.BaseRepository().FindList(expression1).Select(t => t.LOGINNAME).ToArray();
                if (result.Count() == 0)
                {
                    expression1 = expression1.Or(t => t.DISTRICTCODE == distinct.Substring(0, 4) + "00");
                    result = this.BaseRepository().FindList(expression1).Select(t => t.LOGINNAME).ToArray();
                }
                if (result.Count() == 0){
                     expression1 = expression1.Or(t => t.DISTRICTCODE == distinct.Substring(0, 2) + "0000");
                     result = this.BaseRepository().FindList(expression1).Select(t => t.LOGINNAME).ToArray();
                }
                if (distinct.Length == 9)
                    expression1 = expression1.Or(t => t.DISTRICTCODE == distinct.Substring(0, 6));
                expression = expression.And(expression1);
                result = this.BaseRepository().FindList(expression).Select(t => t.LOGINNAME).ToArray();
            }
            
            return string.Join(",", result);
        }
        #endregion
    }
}
