using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-14 11:42
    /// �� �����ֺ��������
    /// </summary>
    public class TBL_HAZARDBASICINFOEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        [Column("OLDUNIFIEDCODE")]
        public string OLDUNIFIEDCODE { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("UNIFIEDCODE")]
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERNAME")]
        public string DISASTERNAME { get; set; }
        /// <summary>
        /// Ұ����
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORCODE")]
        public string OUTDOORCODE { get; set; }
        /// <summary>
        /// ���ڱ��
        /// </summary>
        /// <returns></returns>
        [Column("INDOORCODE")]
        public string INDOORCODE { get; set; }
        /// <summary>
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// ʡ����
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCENAME")]
        public string PROVINCENAME { get; set; }
        /// <summary>
        /// ��
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
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("TEAM")]
        public string TEAM { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("VILLAGE")]
        public string VILLAGE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
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
        public string LONGITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        public string LATITUDE { get; set; }
        /// <summary>
        /// X
        /// </summary>
        /// <returns></returns>
        [Column("X")]
        public decimal? X { get; set; }
        /// <summary>
        /// Y
        /// </summary>
        /// <returns></returns>
        [Column("Y")]
        public decimal? Y { get; set; }
        /// <summary>
        /// Z
        /// </summary>
        /// <returns></returns>
        [Column("Z")]
        public decimal? Z { get; set; }
        /// <summary>
        /// �¶�/�����
        /// </summary>
        /// <returns></returns>
        [Column("ALTTOP")]
        public decimal? ALTTOP { get; set; }
        /// <summary>
        /// �µ�/��С���
        /// </summary>
        /// <returns></returns>
        [Column("ALTBOTOM")]
        public decimal? ALTBOTOM { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("CONTROLSTATE")]
        public string CONTROLSTATE { get; set; }
        /// <summary>
        /// ����ˮ����
        /// </summary>
        /// <returns></returns>
        [Column("GROUNDWATERTYPE")]
        public string GROUNDWATERTYPE { get; set; }
        /// <summary>
        /// ���첿λ
        /// </summary>
        /// <returns></returns>
        [Column("TECTONICREGION")]
        public string TECTONICREGION { get; set; }
        /// <summary>
        /// �����Ҷ�
        /// </summary>
        /// <returns></returns>
        [Column("EARTHQUAKEINTENSITY")]
        public string EARTHQUAKEINTENSITY { get; set; }
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
        /// ��в�˿�
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPEOPLE")]
        public int? THREATENPEOPLE { get; set; }
        /// <summary>
        /// ��в�Ʋ�
        /// </summary>
        /// <returns></returns>
        [Column("THREATENASSETS")]
        public decimal? THREATENASSETS { get; set; }
        /// <summary>
        /// �ֺ��ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERLEVEL")]
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        /// <returns></returns>
        [Column("DANGERLEVEL")]
        public string DANGERLEVEL { get; set; }
        /// <summary>
        /// ���ν���
        /// </summary>
        /// <returns></returns>
        [Column("TREATMENTSUGGESTION")]
        public string TREATMENTSUGGESTION { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENDANGER")]
        public string HIDDENDANGER { get; set; }
        /// <summary>
        /// ��⽨��
        /// </summary>
        /// <returns></returns>
        [Column("MONITORSUGGESTION")]
        public string MONITORSUGGESTION { get; set; }
        /// <summary>
        /// �ٻ�����
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDHOME")]
        public int? DESTROYEDHOME { get; set; }
        /// <summary>
        /// ��·
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDROAD")]
        public decimal? DESTROYEDROAD { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DESTROYEDCANAL")]
        public decimal? DESTROYEDCANAL { get; set; }
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ���̱��
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTID")]
        public string PROJECTID { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("COUNTYNAME")]
        public string COUNTYNAME { get; set; }
        /// <summary>
        /// ��������(��顢Ѳ�顢�Ų�)
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYTYPE")]
        public string SURVEYTYPE { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("SURVEYTIME")]
        public DateTime? SURVEYTIME { get; set; }
        /// <summary>
        /// �Ƿ�Ϊ��Ҫ�ֺ���
        /// </summary>
        /// <returns></returns>
        [Column("ISIMPORTANT")]
        public string ISIMPORTANT { get; set; }
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
        [Column("CREATEUSER")]
        public string CREATEUSER { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYTIME")]
        public DateTime? MODIFYTIME { get; set; }
        /// <summary>
        /// �޸���
        /// </summary>
        /// <returns></returns>
        [Column("MODIFYUSER")]
        public string MODIFYUSER { get; set; }

        /// <summary>
        /// �����˿�
        /// </summary>
        /// <returns></returns>
        [Column("DEATHTOLL")]
        public decimal? DEATHTOLL { get; set; }
        /// <summary>
        /// �Ʋ���ʧ
        /// </summary>
        /// <returns></returns>
        [Column("ASSETSLOSE")]
        public decimal? ASSETSLOSE { get; set; }
        /// <summary>
        /// ʧ������
        /// </summary>
        /// <returns></returns>
        [Column("MISSINGPERSON")]
        public decimal? MISSINGPERSON { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("INJUREDPERSON")]
        public decimal? INJUREDPERSON { get; set; }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        /// <returns></returns>
        [Column("ISXH")]
        public string ISXH { get; set; }
        /// <summary>
        /// �Ƿ��ش�������
        /// </summary>
        /// <returns></returns>
        [Column("ISZDYHD")]
        public string ISZDYHD { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("DATASOURCE")]
        public string DATASOURCE { get; set; }
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

    /// <summary>
    /// �ֺ�����ʷ������
    /// </summary>
    public class PastHAZARDBASICINFO
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string GUID { get; set; }
        /// <summary>
        /// ͳһ�ֺ����
        /// </summary>
        public string UNIFIEDCODE { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        public string DISASTERUNITNAME { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string MODIFYTYPE { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string EDITOR { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        public string AUDITOR { get; set; }
        /// <summary>
        /// ����λ��
        /// </summary>
        public string LOCATION { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        public string DISASTERLEVEL { get; set; }
        /// <summary>
        /// ����ȼ�
        /// </summary>
        public string DANGERLEVEL { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? MODIFIEDDATE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string LONGITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        public string LATITUDE { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public string FILLDATE { get; set; }

    }
}