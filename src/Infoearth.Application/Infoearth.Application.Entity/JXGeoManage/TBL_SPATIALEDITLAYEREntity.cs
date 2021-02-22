using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 13:52
    /// �� ������Χͼ�����
    /// </summary>
    public class TBL_SPATIALEDITLAYEREntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ͼ��ID
        /// </summary>
        /// <returns></returns>
        [Column("LAYERID")]
        public string LAYERID { get; set; }
        /// <summary>
        /// ͼ������
        /// </summary>
        /// <returns></returns>
        [Column("LAYERNAME")]
        public string LAYERNAME { get; set; }
        /// <summary>
        /// ��Χ����
        /// </summary>
        /// <returns></returns>
        [Column("DESCRIBE")]
        public string DESCRIBE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("MOUDLEID")]
        public string MOUDLEID { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.LAYERID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.LAYERID = keyValue;
        }
        #endregion
    }
}