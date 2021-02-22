using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-26 14:28
    /// �� ����ͳ�Ʒ�����ѯ����
    /// </summary>
    public class TBL_WHAA07CEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ������ID
        /// </summary>
        /// <returns></returns>
        [Column("SUMTYPE")]
        public string SUMTYPE { get; set; }
        /// <summary>
        /// ��ѯ�ı�����
        /// </summary>
        /// <returns></returns>
        [Column("TABLENAME")]
        public string TABLENAME { get; set; }
        /// <summary>
        /// ͳ���ֶ�����
        /// </summary>
        /// <returns></returns>
        [Column("REPORTFIELD")]
        public string REPORTFIELD { get; set; }
        /// <summary>
        /// ͳ������
        /// </summary>
        /// <returns></returns>
        [Column("REPORTTYPE")]
        public string REPORTTYPE { get; set; }
        /// <summary>
        /// ������2
        /// </summary>
        /// <returns></returns>
        [Column("REPORTCLASS")]
        public string REPORTCLASS { get; set; }
        /// <summary>
        /// ͳ�����
        /// </summary>
        /// <returns></returns>
        [Column("REPORTVALUE")]
        public string REPORTVALUE { get; set; }
        /// <summary>
        /// �����ֺ����͵�������
        /// </summary>
        /// <returns></returns>
        [Column("RPCAPTION")]
        public string RPCAPTION { get; set; }
        /// <summary>
        /// ������1
        /// </summary>
        /// <returns></returns>
        [Column("MEASURE")]
        public string MEASURE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("WIDTH")]
        public int? WIDTH { get; set; }
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