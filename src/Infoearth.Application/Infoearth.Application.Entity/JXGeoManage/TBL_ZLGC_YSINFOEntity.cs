using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:31
    /// �� ����������-����
    /// </summary>
    public class TBL_ZLGC_YSINFOEntity : BaseEntity
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
        /// �������յ�λ
        /// </summary>
        /// <returns></returns>
        [Column("CYDEPT")]
        public string CYDEPT { get; set; }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CYTIME")]
        public DateTime? CYTIME { get; set; }
        /// <summary>
        /// �������յص�
        /// </summary>
        /// <returns></returns>
        [Column("CYPLACE")]
        public string CYPLACE { get; set; }
        /// <summary>
        /// ��������ר��
        /// </summary>
        /// <returns></returns>
        [Column("CYZJ")]
        public string CYZJ { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("CYPW")]
        public string CYPW { get; set; }
        /// <summary>
        /// �������յ�λ
        /// </summary>
        /// <returns></returns>
        [Column("ZYDEPT")]
        public string ZYDEPT { get; set; }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ZYTIME")]
        public DateTime? ZYTIME { get; set; }
        /// <summary>
        /// �������յص�
        /// </summary>
        /// <returns></returns>
        [Column("ZYPLACE")]
        public string ZYPLACE { get; set; }
        /// <summary>
        /// ��������ר��
        /// </summary>
        /// <returns></returns>
        [Column("ZYZJ")]
        public string ZYZJ { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("ZYPW")]
        public string ZYPW { get; set; }
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