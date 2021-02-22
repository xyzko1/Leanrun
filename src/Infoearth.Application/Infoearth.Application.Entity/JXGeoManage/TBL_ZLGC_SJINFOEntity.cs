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
    /// �� ����������-���
    /// </summary>
    public class TBL_ZLGC_SJINFOEntity : BaseEntity
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
        /// ��Ƶ�λ
        /// </summary>
        /// <returns></returns>
        [Column("DESIGNDEPT")]
        public string DESIGNDEPT { get; set; }
        /// <summary>
        /// �ɹ���ʽ
        /// </summary>
        /// <returns></returns>
        [Column("PROCUREMENT")]
        public string PROCUREMENT { get; set; }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        /// <returns></returns>
        [Column("DESIGNCOST")]
        public decimal? DESIGNCOST { get; set; }
        /// <summary>
        /// ��ͬǩ��ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("QDTIME")]
        public DateTime? QDTIME { get; set; }
        /// <summary>
        /// ������ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SCTIME")]
        public DateTime? SCTIME { get; set; }
        /// <summary>
        /// ���ר��
        /// </summary>
        /// <returns></returns>
        [Column("SCZJ")]
        public string SCZJ { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTPERSON")]
        public string CONTACTPERSON { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTTEL")]
        public string CONTACTTEL { get; set; }
        /// <summary>
        /// ��ͬǩ���ص�
        /// </summary>
        /// <returns></returns>
        [Column("QDPLACE")]
        public string QDPLACE { get; set; }
        /// <summary>
        /// ������ص�
        /// </summary>
        /// <returns></returns>
        [Column("SCPLACE")]
        public string SCPLACE { get; set; }
        /// <summary>
        /// ��׼����
        /// </summary>
        /// <returns></returns>
        [Column("PZDEPT")]
        public string PZDEPT { get; set; }
        /// <summary>
        /// ��׼�ĺ�
        /// </summary>
        /// <returns></returns>
        [Column("PZWH")]
        public string PZWH { get; set; }
        /// <summary>
        /// �б�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ZBTIME")]
        public DateTime? ZBTIME { get; set; }
        /// <summary>
        /// �б�ص�
        /// </summary>
        /// <returns></returns>
        [Column("ZBPLACE")]
        public string ZBPLACE { get; set; }
        /// <summary>
        /// �б�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("GETTIME")]
        public DateTime? GETTIME { get; set; }
        /// <summary>
        /// �����嵥json(�������ơ����ʵȼ�����ע)
        /// </summary>
        /// <returns></returns>
        [Column("ZZQD")]
        public string ZZQD { get; set; }
        /// <summary>
        /// ��������json(�����������ơ����ȡ�γ�ȡ��������)
        /// </summary>
        /// <returns></returns>
        [Column("ZLQY")]
        public string ZLQY { get; set; }
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