using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.Extension;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
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
    /// 日 期：2019-05-15 15:38
    /// 描 述：巡查隐患点灾情表
    /// </summary>
    public class TBL_DZHJSB_DZZHQKMONTH_GDService : RepositoryFactory<TBL_DZHJSB_DZZHQKMONTH_GDEntity>, TBL_DZHJSB_DZZHQKMONTH_GDIService
    {
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TBL_DZHJSB_DZZHQKMONTH_GDEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<TBL_DZHJSB_DZZHQKMONTH_GDEntity>();
            return this.BaseRepository().FindList(expression);
        }
        public DataTable Getdata(string queryJson)
        {
            int Year = 0;
            int Month = 12;
            int StartMonth = 1;
            dynamic json = Newtonsoft.Json.Linq.JToken.Parse(queryJson) as dynamic;
            int.TryParse(json.Year.ToString(), out Year);
            int.TryParse(json.EndMonth.ToString(), out Month);
            int.TryParse(json.StartMonth.ToString(), out StartMonth);                 
            DataTable dt = new DataTable();
            #region 增加表头
            dt.Columns.Add("月");
            dt.Columns.Add("灾情总数（起）");
            dt.Columns.Add("自然");
            dt.Columns.Add("人为");
            dt.Columns.Add("特大型");
            dt.Columns.Add("大型");
            dt.Columns.Add("中型");
            dt.Columns.Add("达到统计标准");
            dt.Columns.Add("未达到统计标准");
            dt.Columns.Add("滑坡");
            dt.Columns.Add("崩塌");
            dt.Columns.Add("泥石流");
            dt.Columns.Add("地面塌陷");
            dt.Columns.Add("地裂缝");
            dt.Columns.Add("地面沉降");
            dt.Columns.Add("死亡");
            dt.Columns.Add("失踪");
            dt.Columns.Add("受伤");
            dt.Columns.Add("经济损失（万元）");
            dt.Columns.Add("备注");
            #endregion
            //遍历查询月份（月份从1月开始）
            for (int i = StartMonth; i <= Month; i++)
            {
                var dtoArr = GetListentity(Year, i, i);
                var dr = dt.NewRow();
                dr["月"] = i;
                dr["灾情总数（起）"] = dtoArr.Count();
                dr["自然"] = dtoArr.Count(t => t.COURSE.Contains("自然"));
                dr["人为"] = dtoArr.Count(t => t.COURSE.Contains("人为"));
                dr["特大型"] = dtoArr.Count(t => t.ZHDJ == "特大型");
                dr["大型"] = dtoArr.Count(t => t.ZHDJ == "大型");
                dr["中型"] = dtoArr.Count(t => t.ZHDJ == "中型");
                dr["达到统计标准"] = dtoArr.Count(t => t.ZHDJ == "小型");
                dr["未达到统计标准"] = 0;
                dr["滑坡"] = dtoArr.Count(t => t.ZHLX.Contains("滑坡"));
                dr["崩塌"] = dtoArr.Count(t => t.ZHLX.Contains("崩塌"));
                dr["泥石流"] = dtoArr.Count(t => t.ZHLX.Contains("泥石流"));
                dr["地面塌陷"] = dtoArr.Count(t => t.ZHLX.Contains("地面塌陷"));
                dr["地裂缝"] = dtoArr.Count(t => t.ZHLX.Contains("地裂缝"));
                dr["地面沉降"] = dtoArr.Count(t => t.ZHLX.Contains("地面沉降"));
                dr["死亡"] = dtoArr.Sum(t => t.SW);
                dr["失踪"] = dtoArr.Sum(t => t.SZ);
                dr["受伤"] = dtoArr.Sum(t => t.SS);
                dr["经济损失（万元）"] = dtoArr.Sum(t => t.ZJJJSS);
                dr["备注"] ="";
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public IEnumerable<TBL_DZHJSB_DZZHQKMONTH_GDEntity> GetListentity(int Year, int StartMonth, int EndMonth)
        {
            var expression = queryJsonExpression(Year,StartMonth,EndMonth);
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TBL_DZHJSB_DZZHQKMONTH_GDEntity GetEntity(string keyValue)
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
        public void SaveForm(string keyValue, TBL_DZHJSB_DZZHQKMONTH_GDEntity entity)
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
        #endregion

        #region 筛选条件
        System.Linq.Expressions.Expression<Func<TBL_DZHJSB_DZZHQKMONTH_GDEntity, bool>> queryJsonExpression(int Year, int StartMonth, int EndMonth)
        {
            var expression = LinqExtensions.True<TBL_DZHJSB_DZZHQKMONTH_GDEntity>();
            expression = expression.And(t => t.HAPPENDATE.Value.Year == Year && t.HAPPENDATE.Value.Month >= StartMonth && t.HAPPENDATE.Value.Month <= EndMonth);
            return expression;
        }
        #endregion
    }
}
