using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-25 16:13
    /// �� �������ľ���������Ϣ��
    /// </summary>
    public class TBL_RWJJ_GOVERNMENTEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// ���֤
        /// </summary>
        /// <returns></returns>
        [Column("CARDID")]
        public string CARDID { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        [Column("PHONE")]
        public string PHONE { get; set; }
        /// <summary>
        /// �ֻ�
        /// </summary>
        /// <returns></returns>
        [Column("MOBILE")]
        public string MOBILE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public decimal? LONGITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public decimal? LATITUDE { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTPERSON")]
        public string CONTACTPERSON { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("ORGANIZATIONLEVEL")]
        public string ORGANIZATIONLEVEL { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [Column("NAMEID")]
        public string NAMEID { get; set; }
        /// <summary>
        /// ��ϵ�˱��
        /// </summary>
        /// <returns></returns>
        [Column("CONTACTPERSONID")]
        public string CONTACTPERSONID { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.UNIFIEDCODE = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.UNIFIEDCODE = keyValue;
        }
        #endregion
    }
}