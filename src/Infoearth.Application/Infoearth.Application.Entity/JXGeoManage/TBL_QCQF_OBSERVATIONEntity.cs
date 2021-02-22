using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-07 17:19
    /// �� ����Ⱥ��Ⱥ���۲�����Ϣ��
    /// </summary>
    public class TBL_QCQF_OBSERVATIONEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �۲��˵绰
        /// </summary>
        /// <returns></returns>
        [Column("OBSERVATIONPHONE")]
        public string OBSERVATIONPHONE { get; set; }
        /// <summary>
        /// �۲�������
        /// </summary>
        /// <returns></returns>
        [Column("OBSERVATIONPEOPLE")]
        public string OBSERVATIONPEOPLE { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        /// <returns></returns>
        [Column("LOGINPASSWORD")]
        public string LOGINPASSWORD { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME { get; set; }
        /// <summary>
        /// �Ƿ����Ʒ�Χ
        /// </summary>
        /// <returns></returns>
        [Column("ISLIMITED")]
        public string ISLIMITED { get; set; }
        /// <summary>
        /// ��Χֵ
        /// </summary>
        /// <returns></returns>
        [Column("FWZ")]
        public string FWZ { get; set; }
        /// <summary>
        /// �Ƿ�۲���
        /// </summary>
        /// <returns></returns>
        [Column("ISGCR")]
        public string ISGCR { get; set; }
        /// <summary>
        /// ʡ����
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// ʡ����
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// �б���
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
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
        /// �ر���
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
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