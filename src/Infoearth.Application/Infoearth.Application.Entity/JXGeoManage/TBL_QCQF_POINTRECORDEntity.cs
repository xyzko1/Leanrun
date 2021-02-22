using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-13 16:23
    /// �� ����Ⱥ��Ⱥ�������ˮ���ݱ�
    /// </summary>
    public class TBL_QCQF_POINTRECORDEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// Ⱥ��Ⱥ������GUID
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTGUID")]
        public string MONITORPOINTGUID { get; set; }
        /// <summary>
        /// �ϱ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        public DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// ����ף�
        /// </summary>
        /// <returns></returns>
        [Column("SLITWIDTH")]
        public decimal? SLITWIDTH { get; set; }
        /// <summary>
        /// �عĸ߶ȣ��ף�
        /// </summary>
        /// <returns></returns>
        [Column("TODRUMHEIGH")]
        public decimal? TODRUMHEIGH { get; set; }
        /// <summary>
        /// Ȫˮˮ�����ף�
        /// </summary>
        /// <returns></returns>
        [Column("SPRINGAMOUNT")]
        public decimal? SPRINGAMOUNT { get; set; }
        /// <summary>
        /// Ȫˮ���Ƕȣ��ף�
        /// </summary>
        /// <returns></returns>
        [Column("SPRINGVOICING")]
        public string SPRINGVOICING { get; set; }
        /// <summary>
        /// ��ˮˮ�����ף�
        /// </summary>
        /// <returns></returns>
        [Column("WELLLEVEL")]
        public decimal? WELLLEVEL { get; set; }
        /// <summary>
        /// ��ˮ���Ƕȣ��ף�
        /// </summary>
        /// <returns></returns>
        [Column("WELLVOICING")]
        public string WELLVOICING { get; set; }
        /// <summary>
        /// �۲���ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// �ϴ�����
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADLONGITUDE")]
        public decimal? UPLOADLONGITUDE { get; set; }
        /// <summary>
        /// �ϴ�γ��
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADLATITUDE")]
        public decimal? UPLOADLATITUDE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("SOURCETYPE")]
        public string SOURCETYPE { get; set; }
        /// <summary>
        /// �ϴ���ID
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADID")]
        public string UPLOADID { get; set; }
        /// <summary>
        /// �ϴ�������
        /// </summary>
        /// <returns></returns>
        [Column("UPLOADNAME")]
        public string UPLOADNAME { get; set; }
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