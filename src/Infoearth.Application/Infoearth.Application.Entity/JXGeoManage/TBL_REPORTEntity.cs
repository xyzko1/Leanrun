using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-04-28 16:05
    /// �� ����ͳ�ƹ��ñ���
    /// </summary>
    public class TBL_REPORTEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("REPORTNAME")]
        public string REPORTNAME { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("CREATEPEOPLE")]
        public string CREATEPEOPLE { get; set; }
        /// <summary>
        /// ͳ����������̨��
        /// </summary>
        /// <returns></returns>
        [Column("QUERYSTRING")]
        public string QUERYSTRING { get; set; }
        /// <summary>
        /// ��ʾ������ǰ�ˣ�
        /// </summary>
        /// <returns></returns>
        [Column("CONDITION")]
        public string CONDITION { get; set; }
        /// <summary>
        /// ����ģ��
        /// </summary>
        /// <returns></returns>
        [Column("MODULE")]
        public string MODULE { get; set; }
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