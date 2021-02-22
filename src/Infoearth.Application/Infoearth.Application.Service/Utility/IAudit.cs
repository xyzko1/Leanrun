using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Service
{
    /// <summary>
    /// 审核数据接口
    /// </summary>
    public interface IAudit
    {
        /// <summary>
        /// 审核数据
        /// </summary>
        /// <param name="bussnessId">业务数据ID</param>
        /// <param name="updateType">更新类型</param>
        void AuditData(string bussnessId,string updateType);

        /// <summary>
        /// 核销（删除）数据
        /// </summary>
        /// <param name="bussnessKey">业务表主键</param>
        /// <param name="verificationType">核销类型</param>
        /// <param name="fillTableDate">填表时间</param>
        void VerificationData(string bussnessKey, int verificationType, DateTime fillTableDate);
    }
}
