using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-05 14:36
    /// �� ����ң�н����
    /// </summary>
    public class TBL_SENSE_HISTORYEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ͳһ���
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// ͼ�����
        /// </summary>
        /// <returns></returns>
        [Column("SENSECODE")]
        public string SENSECODE { get; set; }
        /// <summary>
        /// ң��ͼ����
        /// </summary>
        /// <returns></returns>
        [Column("SENSEIMGCODE")]
        public string SENSEIMGCODE { get; set; }
        /// <summary>
        /// ͼ����
        /// </summary>
        /// <returns></returns>
        [Column("SENSENAME")]
        public string SENSENAME { get; set; }
        /// <summary>
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("CITYNAME")]
        public string CITYNAME { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("TEAM")]
        public string TEAM { get; set; }
        /// <summary>
        /// ��Ȼ����λ��
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        public string LOCATION { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("INDOORCODE")]
        public string INDOORCODE { get; set; }
        /// <summary>
        /// Ұ����
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORCODE")]
        public string OUTDOORCODE { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERUNITNAME")]
        public string DISASTERUNITNAME { get; set; }
        /// <summary>
        /// ��ģ
        /// </summary>
        /// <returns></returns>
        [Column("SCALE")]
        public string SCALE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public string LATITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        public string LONGITUDE { get; set; }
        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [Column("X")]
        public string X { get; set; }
        /// <summary>
        /// y
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public string Y { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// ң��Ӱ������
        /// </summary>
        /// <returns></returns>
        [Column("IMGFEATURES")]
        public string IMGFEATURES { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("EXPLAIN")]
        public string EXPLAIN { get; set; }
        /// <summary>
        /// Ұ����֤���
        /// </summary>
        /// <returns></returns>
        [Column("OUTRESULT")]
        public string OUTRESULT { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("EXPLAINPEOPLE")]
        public string EXPLAINPEOPLE { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("EXPLAINTIME")]
        public string EXPLAINTIME { get; set; }
        /// <summary>
        /// �Ƿ�˲�
        /// </summary>
        /// <returns></returns>
        [Column("ISAUDIT")]
        public string ISAUDIT { get; set; }
        /// <summary>
        /// �˲���
        /// </summary>
        /// <returns></returns>
        [Column("AUDITPEOPLE")]
        public string AUDITPEOPLE { get; set; }
        /// <summary>
        /// ң��ͼ��
        /// </summary>
        /// <returns></returns>
        [Column("SENSEIMAGE")]
        public string SENSEIMAGE { get; set; }
        /// <summary>
        /// ˳���
        /// </summary>
        /// <returns></returns>
        [Column("NUMBER")]
        public string NUMBER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("ISNEW")]
        public string ISNEW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("CREATTIME")]
        public System.DateTime? CREATTIME { get; set; }
        /// <summary>
        /// �޸����ͣ�I���������룻A��������¼��U���޸ļ�¼��D��ɾ����¼��
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTYPE")]
        public string MODIFYTYPE { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <returns></returns>
        [Column("MODIFIEDDATE")]
        public System.DateTime? MODIFIEDDATE { get; set; }
        /// <summary>
        /// �޸��ˣ���Ӧ�û����LOGINNAME����
        /// </summary>
        /// <returns></returns>
        [Column("EDITOR")]
        public string EDITOR { get; set; }
        /// <summary>
        /// ���״̬��1������ƣ�2�����ͨ����3����Ʋ�ͨ����4��������5��������֤��
        /// </summary>
        /// <returns></returns>
        [Column("AUDITSTATUS")]
        public string AUDITSTATUS { get; set; }
        /// <summary>
        /// �����ˣ���Ӧ�û����LOGINNAME����
        /// </summary>
        /// <returns></returns>
        [Column("AUDITOR")]
        public string AUDITOR { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("AUDITEDDATE")]
        public System.DateTime? AUDITEDDATE { get; set; }
        /// <summary>
        /// �������ͣ�1-�����̣�2-��Ǩ���ã�3-�˹��˶���
        /// </summary>
        /// <returns></returns>
        [Column("VERIFICATION")]
        public string VERIFICATION { get; set; }
        /// <summary>
        /// ���ر��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYCODE")]
        public string COUNTYCODE { get; set; }
        /// <summary>
        /// ������(���)
        /// </summary>
        /// <returns></returns>
        [Column("UPDATEUSER")]
        public string UPDATEUSER { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("UPDATETIME")]
        public DateTime? UPDATETIME { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("FILLTABLEDATE")]
        public DateTime? FILLTABLEDATE { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("CREATORUSERID")]
        public string CREATORUSERID { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CREATORTIME")]
        public DateTime? CREATORTIME { get; set; }
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