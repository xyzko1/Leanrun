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
    /// �� ���������鱨��
    /// </summary>
    public class TBL_YJDC_DISASTERREPORTEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
        /// <summary>
        /// �ֺ���������
        /// </summary>
        /// <returns></returns>
        [Column("ISZAIQINGORXIANQING")]
        public string ISZAIQINGORXIANQING { get; set; }
        /// <summary>
        /// �ӱ�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSTIME")]
        public System.DateTime? ACCESSTIME { get; set; }
        /// <summary>
        /// �ֺ�������
        /// </summary>
        /// <returns></returns>
        [Column("DISASTRENAME")]
        public string DISASTRENAME { get; set; }
        /// <summary>
        /// �����ص�
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENPLACE")]
        public string HAPPENPLACE { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("HAPPENTIME")]
        public System.DateTime? HAPPENTIME { get; set; }
        /// <summary>
        /// ��������(��)
        /// </summary>
        /// <returns></returns>
        [Column("DAETH")]
        public string DAETH { get; set; }
        /// <summary>
        /// ʧ������(��)
        /// </summary>
        /// <returns></returns>
        [Column("LOSS")]
        public string LOSS { get; set; }
        /// <summary>
        /// ��������(��)
        /// </summary>
        /// <returns></returns>
        [Column("HURT")]
        public string HURT { get; set; }
        /// <summary>
        /// �Ʋ���ʧ(��Ԫ)
        /// </summary>
        /// <returns></returns>
        [Column("CAICHANLOSS")]
        public string CAICHANLOSS { get; set; }
        /// <summary>
        /// ֱ�Ӿ�����ʧ(��Ԫ)
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERECONOMICLOSS")]
        public string DISASTERECONOMICLOSS { get; set; }
        /// <summary>
        /// ��в����(��)
        /// </summary>
        /// <returns></returns>
        [Column("HOUSEHOLDS")]
        public string HOUSEHOLDS { get; set; }
        /// <summary>
        /// ��в����(��)
        /// </summary>
        /// <returns></returns>
        [Column("THREATENPERSON")]
        public string THREATENPERSON { get; set; }
        /// <summary>
        /// ��в����(��)
        /// </summary>
        /// <returns></returns>
        [Column("THREATENHOUSE")]
        public string THREATENHOUSE { get; set; }
        /// <summary>
        /// ��в����
        /// </summary>
        /// <returns></returns>
        [Column("THREATENOTHER")]
        public string THREATENOTHER { get; set; }
        /// <summary>
        /// ֱ�Ӿ�����ʧ(��Ԫ)
        /// </summary>
        /// <returns></returns>
        [Column("MONEYLOSS")]
        public string MONEYLOSS { get; set; }
        /// <summary>
        /// �ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERTYPE")]
        public string DISASTERTYPE { get; set; }
        /// <summary>
        /// �ֺ���ģ
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERSCALE")]
        public string DISASTERSCALE { get; set; }
        /// <summary>
        /// ���Ⱦ������
        /// </summary>
        /// <returns></returns>
        [Column("SAVEDISASTERSITUATION")]
        public string SAVEDISASTERSITUATION { get; set; }
        /// <summary>
        /// �շ�����
        /// </summary>
        /// <returns></returns>
        [Column("CAUSEFACTOR")]
        public string CAUSEFACTOR { get; set; }
        /// <summary>
        /// ��չ����
        /// </summary>
        /// <returns></returns>
        [Column("DEVELOPMENTTREND")]
        public string DEVELOPMENTTREND { get; set; }
        /// <summary>
        /// �Ѳ�ȡ��ʩ
        /// </summary>
        /// <returns></returns>
        [Column("MEASURE")]
        public string MEASURE { get; set; }
        /// <summary>
        /// ���ν���
        /// </summary>
        /// <returns></returns>
        [Column("SUGGEST")]
        public string SUGGEST { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("INFOMENT")]
        public string INFOMENT { get; set; }
        /// <summary>
        /// ���λ
        /// </summary>
        /// <returns></returns>
        [Column("FILLINUNIT")]
        public string FILLINUNIT { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSOR")]
        public string ACCESSOR { get; set; }
        /// <summary>
        /// ���յ�λ
        /// </summary>
        /// <returns></returns>
        [Column("ACCESSSUNIT")]
        public string ACCESSSUNIT { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("FILLINTIME")]
        public System.DateTime? FILLINTIME { get; set; }
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
        [Column("COUTRYNAME")]
        public string COUTRYNAME { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("TOWNNAME")]
        public string TOWNNAME { get; set; }
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