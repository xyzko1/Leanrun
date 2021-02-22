using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:30
    /// �� ����������-Ұ�⿱��
    /// </summary>
    public class TBL_ZLGC_KCINFOEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �����̱��
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCID")]
        public string ZLGCID { get; set; }
        [Column("MEDIAGUID")]
        public string MEDIAGUID { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("ZLGCNAME")]
        public string ZLGCNAME { get; set; }
        /// <summary>
        /// ���쵥λ
        /// </summary>
        /// <returns></returns>
        [Column("KCDW")]
        public string KCDW { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        [Column("LXDH")]
        public string LXDH { get; set; }
        /// <summary>
        /// �������(��Ԫ)
        /// </summary>
        /// <returns></returns>
        [Column("KCFY")]
        public decimal? KCFY { get; set; }
        /// <summary>
        /// ���쿪ʼʱ��
        /// </summary>
        /// <returns></returns>
        [Column("KCKSSJ")]
        public DateTime? KCKSSJ { get; set; }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("KCJSSJ")]
        public DateTime? KCJSSJ { get; set; }
        /// <summary>
        /// ��ͬǩ��ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("HTQDSJ")]
        public DateTime? HTQDSJ { get; set; }
        /// <summary>
        /// �б�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ZHAOBIAOSJ")]
        public DateTime? ZHAOBIAOSJ { get; set; }
        /// <summary>
        /// �б�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ZHONGBIAOSJ")]
        public DateTime? ZHONGBIAOSJ { get; set; }
        /// <summary>
        /// �������ר��
        /// </summary>
        /// <returns></returns>
        [Column("KCSCZJ")]
        public string KCSCZJ { get; set; }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("KCSCSJ")]
        public DateTime? KCSCSJ { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ZLGCID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ZLGCID = keyValue;
        }
        #endregion
    }
}