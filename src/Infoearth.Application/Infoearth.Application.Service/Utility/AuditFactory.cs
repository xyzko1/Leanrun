using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// 审计接口工厂类
    /// </summary>
    public class AuditFactory
    {
        /// <summary>
        /// 创建接口
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IAudit Create(string name)
        {
            switch (name)
            {
                case "TBL_AVALANCHE_HISTORY":
                    return new TBL_AVALANCHEService();
                case "TBL_COLLAPSE_HISTORY":
                    return new TBL_COLLAPSEService();
                case "TBL_DEBRISFLOW_HISTORY":
                    return new TBL_DEBRISFLOWService();
                case "TBL_LANDCRACK_HISTORY":
                    return new TBL_LANDCRACKService();
                case "TBL_LANDSETTLEMENT_HISTORY":
                    return new TBL_LANDSETTLEMENTService();
                case "TBL_LANDSLIP_HISTORY":
                    return new TBL_LANDSLIPService();
                case "TBL_SLOPE_HISTORY":
                    return new TBL_SLOPEService();
                default:
                    return new TBL_AVALANCHEService();
            }
        }

        public static IAudit Create2(string type)
        {
            switch (type)
            {
                case "崩塌":
                    return new TBL_AVALANCHEService();
                case "地面塌陷":
                    return new TBL_COLLAPSEService();
                case "泥石流":
                    return new TBL_DEBRISFLOWService();
                case "地裂缝":
                    return new TBL_LANDCRACKService();
                case "地面沉降":
                    return new TBL_LANDSETTLEMENTService();
                case "滑坡":
                    return new TBL_LANDSLIPService();
                case "斜坡":
                    return new TBL_SLOPEService();
                default:
                    return new TBL_AVALANCHEService();
            }
        }
    }
}
