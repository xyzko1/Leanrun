using Infoearth.Application.Entity.CustomerManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using System.Collections.Generic;

namespace Infoearth.Application.IService.CustomerManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创 建：佘赐雄
    /// 日 期：2016-04-28 16:48
    /// 描 述：现金余额
    /// </summary>
    public interface ICashBalanceService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<CashBalanceEntity> GetList(string queryJson);
        #endregion

        #region 提交数据
        /// <summary>
        /// 添加收支余额
        /// </summary>
        /// <param name="db"></param>
        /// <param name="cashBalanceEntity"></param>
        void AddBalance(IRepository db, CashBalanceEntity cashBalanceEntity);
        #endregion
    }
}
