using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infoearth.Application.Entity
{
    public sealed class DescAttribute : Attribute
    {
        public DescAttribute()
        {
            this.IsExport = true;
        }

        public DescAttribute(string name)
        {
            this.Name = name;
            this.IsExport = true;
        }

        public DescAttribute(string name, bool isExport)
        {
            this.Name = name;
            this.IsExport = isExport;
        }
        public DescAttribute(string name, string DicName)
        {
            this.Name = name;
            this.IsExport = true;
            this.DicName = DicName;
        }
        public string Name { get; set; }
        public string DicName { get; set; }
        /// <summary>
        /// 是否可导出
        /// </summary>
        public bool IsExport { get; set; }
    }
}