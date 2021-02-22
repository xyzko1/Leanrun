using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-05-09 14:25
    /// �� ����TBL_DZHJSB_DZZHFZYEAR
    /// </summary>
    public class TBL_DZHJSB_DZZHFZYEAREntity : BaseEntity
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
      //  public short? DISASTERYEAR { get; set; }
        public short? DISASTERYEAR { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        [Column("BZ")]
        public string BZ { get; set; }
        /// <summary>
        /// 01_�ɹ����õ����ֺ�
        /// </summary>
        /// <returns></returns>
        [Column("AVOIDDISAATER")]
        public short? AVOIDDISAATER { get; set; }
        /// <summary>
        /// 02_����������Ա
        /// </summary>
        /// <returns></returns>
        [Column("AVOIDHURTHUMAN")]
        public short? AVOIDHURTHUMAN { get; set; }
        /// <summary>
        /// 03_����ֱ�Ӿ�����ʧ
        /// </summary>
        /// <returns></returns>
        [Column("DIRECTECONOMICLOSS")]
        public short? DIRECTECONOMICLOSS { get; set; }
        /// <summary>
        /// 04_����Ӧ������С��
        /// </summary>
        /// <returns></returns>
        [Column("CDYJCZXZ")]
        public short? CDYJCZXZ { get; set; }
        /// <summary>
        /// 05_����Ӧ�����õ����ֺ�
        /// </summary>
        /// <returns></returns>
        [Column("CYYJCLDZZH")]
        public short? CYYJCLDZZH { get; set; }
        /// <summary>
        /// 06_�����ֺ�������Ŀ
        /// </summary>
        /// <returns></returns>
        [Column("DZZHFZXM")]
        public short? DZZHFZXM { get; set; }
        /// <summary>
        /// 07_������Ŀ
        /// </summary>
        /// <returns></returns>
        [Column("GOVERNPROJECT")]
        public short? GOVERNPROJECT { get; set; }
        /// <summary>
        /// 08_���Ԥ����Ŀ
        /// </summary>
        /// <returns></returns>
        [Column("JCYJXM")]
        public short? JCYJXM { get; set; }
        /// <summary>
        /// 09_Ͷ������ʽ�
        /// </summary>
        /// <returns></returns>
        [Column("TRFZZJ")]
        public decimal? TRFZZJ { get; set; }
        /// <summary>
        /// 10_��Ǩ����
        /// </summary>
        /// <returns></returns>
        [Column("REMOVALAMOUNT")]
        public short? REMOVALAMOUNT { get; set; }
        /// <summary>
        /// 11_��ɵ����ֺ�Σ����������Ŀ
        /// </summary>
        /// <returns></returns>
        [Column("WCDZZHWXXPGXM")]
        public short? WCDZZHWXXPGXM { get; set; }
        /// <summary>
        /// 12_�����ֺ�����������
        /// </summary>
        /// <returns></returns>
        [Column("HIDDENAMOUNTITOTALLY")]
        public short? HIDDENAMOUNTITOTALLY { get; set; }
        /// <summary>
        /// 13_��������
        /// </summary>
        /// <returns></returns>
        [Column("ADDAMOUNT")]
        public short? ADDAMOUNT { get; set; }
        /// <summary>
        /// 14_�������
        /// </summary>
        /// <returns></returns>
        [Column("CLEARAMOUNT")]
        public short? CLEARAMOUNT { get; set; }
        /// <summary>
        /// 15_�ش���
        /// </summary>
        /// <returns></returns>
        [Column("BIGLARGE")]
        public short? BIGLARGE { get; set; }
        /// <summary>
        /// 16_����
        /// </summary>
        /// <returns></returns>
        [Column("LARGE")]
        public short? LARGE { get; set; }
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