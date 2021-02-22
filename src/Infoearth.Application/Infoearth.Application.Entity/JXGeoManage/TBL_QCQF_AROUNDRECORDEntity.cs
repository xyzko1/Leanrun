using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-13 16:22
    /// �� ����Ѳ���¼��
    /// </summary>
    public class TBL_QCQF_AROUNDRECORDEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �ϱ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("MONITORTIME")]
        public DateTime? MONITORTIME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ���ѷ죨1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("NEWSLIT")]
        public string NEWSLIT { get; set; }
        /// <summary>
        /// �µعģ�1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("NEWTODRUM")]
        public string NEWTODRUM { get; set; }
        /// <summary>
        /// �������ݣ�1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("NEWSUBSIDE")]
        public string NEWSUBSIDE { get; set; }
        /// <summary>
        /// С�ͱ�����1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("SMALLCOLLAPSES")]
        public string SMALLCOLLAPSES { get; set; }
        /// <summary>
        /// ���ݱ��Σ�1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEDEFORMATION")]
        public string HOUSEDEFORMATION { get; set; }
        /// <summary>
        /// ��Ȫˮ��ʪ�أ�1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("NEWSPRING")]
        public string NEWSPRING { get; set; }
        /// <summary>
        /// ����©ˮ��1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("WELLLEAK")]
        public string WELLLEAK { get; set; }
        /// <summary>
        /// ������б��1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("TREESSKEW")]
        public string TREESSKEW { get; set; }
        /// <summary>
        /// ������1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("UNDEDERVOICE")]
        public string UNDEDERVOICE { get; set; }
        /// <summary>
        /// �����쳣��1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("ANIMALSABNORMAL")]
        public string ANIMALSABNORMAL { get; set; }
        /// <summary>
        /// ��ע��1:��ʾ��;0:��ʾ�ޣ�
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string REMARK { get; set; }
        /// <summary>
        /// �۲���ID��1:��ʾ��;0:��ʾ�ޣ�
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