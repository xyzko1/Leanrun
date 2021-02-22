using Infoearth.Application.Entity.PublicInfoManage;
using System.Data.Entity.ModelConfiguration;

namespace Infoearth.Application.Mapping.PublicInfoManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 武汉地大信息股份有限公司
    /// 创建人：佘赐雄
    /// 日 期：2015.12.15 10:56
    /// 描 述：文件
    /// </summary>
    public class FileInfoMap : EntityTypeConfiguration<FileInfoEntity>
    {
        public FileInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("BASE_FILEINFO");//Base_FileInfo
            //主键
            this.HasKey(t => t.F_FileId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
