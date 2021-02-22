using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:24
    /// �� ����Ⱥ��Ⱥ��������Ϣ��
    /// </summary>
    public class TBL_QCQF_LAYOUTPOINTINFOEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ������ͱ�ţ�DG:�ع�;DL:����;QL:ǽ��;JS:��ˮ;QS:Ȫˮ;+��λ˳��ţ�
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTCODE")]
        public string MONITORPOINTCODE { get; set; }
        /// <summary>
        /// ��ⲿλ
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTPOSITION")]
        public string MONITORPOINTPOSITION { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LON")]
        public decimal? LON { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LAT")]
        public decimal? LAT { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("ZRRNAME")]
        public string ZRRNAME { get; set; }
        /// <summary>
        /// �����˵绰
        /// </summary>
        /// <returns></returns>
        [Column("ZRRPHONE")]
        public string ZRRPHONE { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTIME")]
        public DateTime? MODIFYTIME { get; set; }
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