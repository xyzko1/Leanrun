using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.MONITORPOINT
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 16:55
    /// �� ������������������
    /// </summary>
    public class TBL_DMCJ_MONITORDATAEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTID")]
        public string MONITORPOINTID { get; set; }
        /// <summary>
        /// ���ֵ(��߳�)
        /// </summary>
        /// <returns></returns>
        [Column("VALUE")]
        public Decimal? VALUE { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        public System.DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTYPE")]
        public string MONITORTYPE { get; set; }
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
    public class TBL_DMCJ_MONITORDATAQuery
    {
        #region ʵ���Ա
        [Desc("��������")]
        public string MONITORPOINTNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTID")]
        [Desc("������")]
        public string MONITORPOINTID { get; set; }
        /// <summary>
        /// ���ֵ(��߳�)
        /// </summary>
        /// <returns></returns>
        [Column("VALUE")]
        [Desc("���ֵ")]
        public Decimal? VALUE { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        [Desc("���ʱ��")]
        public System.DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTYPE")]
        public string MONITORTYPE { get; set; }
        #endregion
    }
}