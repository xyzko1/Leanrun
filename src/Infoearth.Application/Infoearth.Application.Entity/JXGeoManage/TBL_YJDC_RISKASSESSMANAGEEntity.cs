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
    /// �� ���������ֺ�Σ����������Ŀ�����ǼǱ�
    /// </summary>
    public class TBL_YJDC_RISKASSESSMANAGEEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ��Ŀ�ص�
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTPLACE")]
        public string PROJECTPLACE { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("COUNTRYNAME")]
        public string COUNTRYNAME { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("REPORTNAME")]
        public string REPORTNAME { get; set; }
        /// <summary>
        /// ��λ
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSUNIT")]
        public string ASSESSUNIT { get; set; }
        /// <summary>
        /// ר��
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSEXPERT")]
        public string ASSESSEXPERT { get; set; }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("RECORDTIME")]
        public System.DateTime? RECORDTIME { get; set; }
        /// <summary>
        /// �ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSLEVEL")]
        public string ASSESSLEVEL { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("ASSESSDEPARTMENT")]
        public string ASSESSDEPARTMENT { get; set; }
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