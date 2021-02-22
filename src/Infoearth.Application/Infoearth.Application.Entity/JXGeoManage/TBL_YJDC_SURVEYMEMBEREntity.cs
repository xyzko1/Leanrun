using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 13:27
    /// �� ����Ӧ�������Ա��
    /// </summary>
    public class TBL_YJDC_SURVEYMEMBEREntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// ��λ
        /// </summary>
        /// <returns></returns>
        [Column("UNIT")]
        public string UNIT { get; set; }
        /// <summary>
        /// ְ��
        /// </summary>
        /// <returns></returns>
        [Column("PROFESSIONALTITLE")]
        public string PROFESSIONALTITLE { get; set; }
        /// <summary>
        /// ǩ��
        /// </summary>
        /// <returns></returns>
        [Column("SIGNATURE")]
        public string SIGNATURE { get; set; }
        /// <summary>
        /// Ӧ��������
        /// </summary>
        /// <returns></returns>
        [Column("YJDCGUID")]
        public string YJDCGUID { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.GUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.GUID = keyValue;
        }
        #endregion
    }
}