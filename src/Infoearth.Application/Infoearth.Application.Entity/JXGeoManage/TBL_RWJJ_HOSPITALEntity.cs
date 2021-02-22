using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-06-26 16:28
    /// �� �������ľ���ҽԺ��Ϣ��
    /// </summary>
    public class TBL_RWJJ_HOSPITALEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ҽԺ����
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// ���֤��
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
        /// �޽�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("AREASTRUCTURE")]
        public int? AREASTRUCTURE { get; set; }
        /// <summary>
        /// �ṹ����
        /// </summary>
        /// <returns></returns>
        [Column("STRUCTURETYPE")]
        public string STRUCTURETYPE { get; set; }
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
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LEGALPERSON")]
        public string LEGALPERSON { get; set; }
        /// <summary>
        /// ְ������
        /// </summary>
        /// <returns></returns>
        [Column("HOSPITALPEOPLE")]
        public long? HOSPITALPEOPLE { get; set; }
        /// <summary>
        /// ���ʲ�
        /// </summary>
        /// <returns></returns>
        [Column("TOTALASSETS")]
        public long? TOTALASSETS { get; set; }
        /// <summary>
        /// ռ�����
        /// </summary>
        /// <returns></returns>
        [Column("FLOORSPACE")]
        public long? FLOORSPACE { get; set; }
        /// <summary>
        /// �վ�����
        /// </summary>
        /// <returns></returns>
        [Column("AVERAGEDAILY")]
        public long? AVERAGEDAILY { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("SICKBEDNUMBER")]
        public long? SICKBEDNUMBER { get; set; }
        /// <summary>
        /// ҽ����Ա��
        /// </summary>
        /// <returns></returns>
        [Column("MEDICALWORKERS")]
        public long? MEDICALWORKERS { get; set; }
        /// <summary>
        /// �Ȼ�������
        /// </summary>
        /// <returns></returns>
        [Column("AMBULANCE")]
        public long? AMBULANCE { get; set; }
        /// <summary>
        /// ҽԺ�ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("HOSPITALRANK")]
        public string HOSPITALRANK { get; set; }
        /// <summary>
        /// ҽԺID
        /// </summary>
        /// <returns></returns>
        [Column("NAMEID")]
        public string NAMEID { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        /// <returns></returns>
        [Column("LEGALPERSONID")]
        public string LEGALPERSONID { get; set; }
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