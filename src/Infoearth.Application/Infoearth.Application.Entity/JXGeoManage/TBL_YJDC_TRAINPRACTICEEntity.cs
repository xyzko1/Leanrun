using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 13:27
    /// �� ����Ӧ��������
    /// </summary>
    public class TBL_YJDC_TRAINPRACTICEEntity : BaseEntity
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
        /// �����ص�
        /// </summary>
        /// <returns></returns>
        [Column("TRAINPLACE")]
        public string TRAINPLACE { get; set; }
        /// <summary>
        /// �ֺ�ģ��
        /// </summary>
        /// <returns></returns>
        [Column("SIMULATEDISASTER")]
        public string SIMULATEDISASTER { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("TRAINTIME")]
        public System.DateTime? TRAINTIME { get; set; }
        /// <summary>
        /// �μ�����
        /// </summary>
        /// <returns></returns>
        [Column("ATTENDPEOPLE")]
        public string ATTENDPEOPLE { get; set; }
        /// <summary>
        /// ��֯��
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSOR")]
        public string ACCESSOR { get; set; }
        /// <summary>
        /// ��֯��λ
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSUNIT")]
        public string ACCESSUNIT { get; set; }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("REPORTTIME")]
        public System.DateTime? REPORTTIME { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ORGANIZATION")]
        public string ORGANIZATION { get; set; }
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