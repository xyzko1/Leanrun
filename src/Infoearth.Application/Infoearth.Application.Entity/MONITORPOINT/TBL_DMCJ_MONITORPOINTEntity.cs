using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.MONITORPOINT
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 18:23
    /// �� �����������������Ϣ��
    /// </summary>
    public class TBL_DMCJ_MONITORPOINTEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTID")]
        [Desc("������")]
        public string MONITORPOINTID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTNAME")]
        [Desc("��������")]
        public string MONITORPOINTNAME { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJNAME")]
        [Desc("�����������")]
        public string DMCJNAME { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJBH")]
        [Desc("����������")]
        public string DMCJBH { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTTYPE")]
        [Desc("�������")]
        public string MONITORPOINTTYPE { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("MONITORPOINTLEVEL")]
        [Desc("����ȼ�", "MONITORPOINTLEVEL")]
        public string MONITORPOINTLEVEL { get; set; }
        /// <summary>
        /// ���赥λ
        /// </summary>
        /// <returns></returns>
        [Column("BUILDDEPT")]
        public string BUILDDEPT { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("BUILDTIME")]
        public DateTime? BUILDTIME { get; set; }
        /// <summary>
        /// ����λ��
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        [Column("AREACODE")]
        public string AREACODE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public decimal? LATITUDE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public decimal? LONGITUDE { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            //this.MONITORPOINTID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            //this.MONITORPOINTID = keyValue;
        }
        #endregion
    }
}