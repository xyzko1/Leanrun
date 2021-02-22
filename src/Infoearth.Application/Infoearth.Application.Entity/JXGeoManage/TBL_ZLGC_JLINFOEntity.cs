using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-16 23:29
    /// �� ����������-����
    /// </summary>
    public class TBL_ZLGC_JLINFOEntity : BaseEntity
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
        /// ����λ
        /// </summary>
        /// <returns></returns>
        [Column("JLDEPT")]
        public string JLDEPT { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("JLCOST")]
        public decimal? JLCOST { get; set; }
        /// <summary>
        /// ��ͬǩ������
        /// </summary>
        /// <returns></returns>
        [Column("QDTIME")]
        public DateTime? QDTIME { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("GCCONTENT")]
        public string GCCONTENT { get; set; }
        /// <summary>
        /// ������ʽ
        /// </summary>
        /// <returns></returns>
        [Column("FBTYPE")]
        public string FBTYPE { get; set; }
        /// <summary>
        /// ��ͬǩ���ص�
        /// </summary>
        /// <returns></returns>
        [Column("QDPLACE")]
        public string QDPLACE { get; set; }
        /// <summary>
        /// �б�����
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
        /// �����嵥json(�������ơ����ʵȼ�����ע)
        /// </summary>
        /// <returns></returns>
        [Column("ZZQD")]
        public string ZZQD { get; set; }
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