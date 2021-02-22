using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-08 15:58
    /// �� ����TBL_DZHJSB_DZZHZQYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHZQYEAREntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// Ψһ��ʶ
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        [Column("DISTRICTCODE")]
        public string DISTRICTCODE { get; set; }
        /// <summary>
        /// ʡ
        /// </summary>
        /// <returns></returns>
        [Column("PROVINCE")]
        public string PROVINCE { get; set; }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("CITY")]
        public string CITY { get; set; }
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
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERYEAR")]
        public short? DISASTERYEAR { get; set; }
     //   public string DISASTERYEAR { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string BZ { get; set; }
        /// <summary>
        /// 01 ��ַ�ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("DISASTERAMOUNT")]
        public short? DISASTERAMOUNT { get; set; }
        /// <summary>
        /// 02 ��Ȼ����
        /// </summary>
        /// <returns></returns>
        [Column("NATURALELENT")]
        public short? NATURALELENT { get; set; }
        /// <summary>
        /// 03 ��Ϊ����
        /// </summary>
        /// <returns></returns>
        [Column("HUMANFACTORS")]
        public short? HUMANFACTORS { get; set; }
        /// <summary>
        /// 04�����ֺ�����
        /// </summary>
        /// <returns></returns>
        [Column("QUANTITY")]
        public short? QUANTITY { get; set; }
        /// <summary>
        /// 05 ����
        /// </summary>
        /// <returns></returns>
        [Column("COLLAPSE")]
        public short? COLLAPSE { get; set; }
        /// <summary>
        /// 06 ����
        /// </summary>
        /// <returns></returns>
        [Column("COAST")]
        public short? COAST { get; set; }
        /// <summary>
        /// 07 ��ʯ��
        /// </summary>
        /// <returns></returns>
        [Column("DEBRISFLOW")]
        public short? DEBRISFLOW { get; set; }
        /// <summary>
        /// 08 ��������
        /// </summary>
        /// <returns></returns>
        [Column("SURFACECOLLAPSE")]
        public short? SURFACECOLLAPSE { get; set; }
        /// <summary>
        /// 09 ���ѷ�
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEFRACTURE")]
        public short? SURFACEFRACTURE { get; set; }
        /// <summary>
        /// 10 �������
        /// </summary>
        /// <returns></returns>
        [Column("SURFACEFALL")]
        public short? SURFACEFALL { get; set; }
        /// <summary>
        /// 17�����������
        /// </summary>
        /// <returns></returns>
        [Column("CAUSEDEATHTOLL")]
        public short? CAUSEDEATHTOLL { get; set; }
        /// <summary>
        /// 12 ��������
        /// </summary>
        /// <returns></returns>
        [Column("DEADAMOUNT")]
        public short? DEADAMOUNT { get; set; }
        /// <summary>
        /// 13 ʧ������
        /// </summary>
        /// <returns></returns>
        [Column("LOSTAMOUNT")]
        public short? LOSTAMOUNT { get; set; }
        /// <summary>
        /// 14 ��������
        /// </summary>
        /// <returns></returns>
        [Column("HURTAMOUNT")]
        public short? HURTAMOUNT { get; set; }
        /// <summary>
        /// 15 ֱ�Ӿ�����ʧ
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTECONOMICLOSS")]
        public decimal? DIRECTECONOMICLOSS { get; set; }
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