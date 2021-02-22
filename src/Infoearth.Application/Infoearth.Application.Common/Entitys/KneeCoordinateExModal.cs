using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infoearth.Application.Common.Entitys
{
    public class KneeCoordinateExModal
    {
        /// <summary>
        /// 拐点坐标x或经度
        /// </summary>
        public double CoordinateX { get; set; }
        /// <summary>
        /// 拐点坐标y或纬度
        /// </summary>
        public double CoordinateY { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public string SerialNum { get; set; }
    }
}
