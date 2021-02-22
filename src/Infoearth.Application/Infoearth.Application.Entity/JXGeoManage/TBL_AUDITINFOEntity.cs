using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-17 14:51
    /// �� ���������Ϣ��
    /// </summary>
    public class TBL_AUDITINFOEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ҵ��ID
        /// </summary>
        /// <returns></returns>
        [Column("BUSINESSID")]
        public string BUSINESSID { get; set; }
        /// <summary>
        /// ��Ϣ��ID
        /// </summary>
        /// <returns></returns>
        [Column("MSGFLOWID")]
        public string MSGFLOWID { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSER")]
        public string UPDATEUSER { get; set; }
        /// <summary>
        /// �޸����ͣ�I���������룻A��������¼��U���޸ļ�¼��D��ɾ����¼��
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETYPE")]
        public string UPDATETYPE { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME { get; set; }
        /// <summary>
        /// ״̬��0-δ�ύ 1-����� 2-���ͨ�� 3-��˲�ͨ����
        /// </summary>
        /// <returns></returns>
        [Column("STATUS")]
        public string STATUS { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("AUDITOR")]
        public string AUDITOR { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("AUDITTIME")]
        public DateTime? AUDITTIME { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string REMARK { get; set; }
        /// <summary>
        /// ƥ���ֶΣ������ƣ�
        /// </summary>
        /// <returns></returns>
        [Column("BASICINFO")]
        public string BASICINFO { get; set; }

        /// <summary>
        /// ҵ������
        /// </summary>
        /// <returns></returns>
        [Column("BUSSNESSTYPE")]
        public string BUSSNESSTYPE { get; set; }

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