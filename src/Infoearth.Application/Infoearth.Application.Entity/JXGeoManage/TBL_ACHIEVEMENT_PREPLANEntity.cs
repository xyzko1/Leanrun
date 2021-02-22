using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-05-25 16:29
    /// �� �������ι滮�ɹ���
    /// </summary>
    public class TBL_ACHIEVEMENT_PREPLANEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �ɹ�����
        /// </summary>
        /// <returns></returns>
        [Column("ACHIEVEMENTNAME")]
        public string ACHIEVEMENTNAME { get; set; }
        /// <summary>
        /// �滮�������ͣ�A-���ҹ滮B-�����滮C-����滮��
        /// </summary>
        /// <returns></returns>
        [Column("AREATYPE")]
        public string AREATYPE { get; set; }
        /// <summary>
        /// �滮ʱ�����ͣ�A-�����ڹ滮B-���ڹ滮C-���ڹ滮D-���ڹ滮��
        /// </summary>
        /// <returns></returns>
        [Column("TIMETYPE")]
        public string TIMETYPE { get; set; }
        /// <summary>
        /// �����ֺ����ͣ�A-��������ֺ����ι滮B-�ۺϵ����ֺ����ι滮��
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("PREVENTION")]
        public string PREVENTION { get; set; }
        /// <summary>
        /// Ŀǰ�ȶ��̶�
        /// </summary>
        /// <returns></returns>
        [Column("CURSTABLESTATUS")]
        public string CURSTABLESTATUS { get; set; }
        /// <summary>
        /// ���仯����
        /// </summary>
        /// <returns></returns>
        [Column("STABLETREND")]
        public string STABLETREND { get; set; }
        /// <summary>
        /// ����ԭ���Ŀ��
        /// </summary>
        /// <returns></returns>
        [Column("PRINCIPLEGOAL")]
        public string PRINCIPLEGOAL { get; set; }
        /// <summary>
        /// ���岿�����Ҫ����
        /// </summary>
        /// <returns></returns>
        [Column("MAINTAST")]
        public string MAINTAST { get; set; }
        /// <summary>
        /// ����Ԥ��Ч��
        /// </summary>
        /// <returns></returns>
        [Column("DESIREDRESULT")]
        public string DESIREDRESULT { get; set; }
        /// <summary>
        /// �׷�����
        /// </summary>
        /// <returns></returns>
        [Column("PRONEAREA")]
        public string PRONEAREA { get; set; }
        /// <summary>
        /// �ص��������
        /// </summary>
        /// <returns></returns>
        [Column("MAINPREVENTAREA")]
        public string MAINPREVENTAREA { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// ������д��
        /// </summary>
        /// <returns></returns>
        [Column("WRITENAME")]
        public string WRITENAME { get; set; }
        /// <summary>
        /// ����¼����
        /// </summary>
        /// <returns></returns>
        [Column("CREATENAME")]
        public string CREATENAME { get; set; }
        /// <summary>
        /// ������д����
        /// </summary>
        /// <returns></returns>
        [Column("WRITETIME")]
        public DateTime? WRITETIME { get; set; }
        /// <summary>
        /// ����¼������
        /// </summary>
        /// <returns></returns>
        [Column("CREATETIME")]
        public DateTime? CREATETIME { get; set; }
        /// <summary>
        /// �����汾��
        /// </summary>
        /// <returns></returns>
        [Column("VESION")]
        public string VESION { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ����λ��
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
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
        /// ʡ����
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
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
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