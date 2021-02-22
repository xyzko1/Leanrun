using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;
using System.Collections.Generic;

namespace Infoearth.Application.Entity.DMCJManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ���̹ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-22 12:10
    /// �� ����������������
    /// </summary>
    public class TBL_DMCJ_BASEINFOEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJBH")]
        [Desc("����������")]
        public string DMCJBH { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("XMMC")]
        public string XMMC { get; set; }
        /// <summary>
        /// ���鵥λ
        /// </summary>
        /// <returns></returns>
        [Column("DCDW")]
        public string DCDW { get; set; }
        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJMC")]
        [Desc("�����������")]
        public string DMCJMC { get; set; }
        /// <summary>
        /// ���ڱ��
        /// </summary>
        /// <returns></returns>
        [Column("INDOORCODE")]
        public string INDOORCODE { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("OUTDOORCODE")]
        public string OUTDOORCODE { get; set; }
        /// <summary>
        /// ����λ��
        /// </summary>
        /// <returns></returns>
        [Column("LOCATION")]
        [Desc("����λ��")]
        public string LOCATION { get; set; }
        /// <summary>
        /// ����λ��-ʡ���ر��
        /// </summary>
        /// <returns></returns>
        [Column("AREACODE")]
        public string AREACODE { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("LONGITUDE")]
        [Desc("����")]
        public decimal? LONGITUDE { get; set; }
        /// <summary>
        /// γ��
        /// </summary>
        /// <returns></returns>
        [Column("LATITUDE")]
        [Desc("γ��")]
        public decimal? LATITUDE { get; set; }
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
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("ALTITUDE")]
        public decimal? ALTITUDE { get; set; }
        /// <summary>
        /// ���ʻ�������-������ʷ���仯����
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJCJLS")]
        public string DZHJTJCJLS { get; set; }
        /// <summary>
        /// ���ʻ�������-���ε�ò
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJDXDM")]
        public string DZHJTJDXDM { get; set; }
        /// <summary>
        /// ���ʻ�������-���ʹ��켰����
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJDZGZ")]
        public string DZHJTJDZGZ { get; set; }
        /// <summary>
        /// ���ʻ�������-���ļͳ��������ͳ����﹤�̵�������
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJCJHJ")]
        public string DZHJTJCJHJ { get; set; }
        /// <summary>
        /// ���ʻ�������-ˮ�ĵ�������
        /// </summary>
        /// <returns></returns>
        [Column("DZHJTJSWDZ")]
        public string DZHJTJSWDZ { get; set; }
        /// <summary>
        /// �����������1(�������ƻ������濪�ѡ�����̧��)
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXX1")]
        public string DMCJXX1 { get; set; }
        /// <summary>
        /// �����������2(�Ŷ����ռ��١�������ʩ�ƻ����ۿ���ͷ��̰�ʧЧ)
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXX2")]
        public string DMCJXX2 { get; set; }
        /// <summary>
        /// �����������3(��ˮ���ࡢ�����ֺ�������)
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXX3")]
        public string DMCJXX3 { get; set; }
        /// <summary>
        /// �����������-�ֺ���������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXXMS1")]
        public string DMCJXXMS1 { get; set; }
        /// <summary>
        /// �����������-�ֺ���������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXXMS2")]
        public string DMCJXXMS2 { get; set; }
        /// <summary>
        /// �����������-�ֺ���������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJXXMS3")]
        public string DMCJXXMS3 { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮ����-���ɲ�λ
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCCW")]
        public string CJQDXSKCCW { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮ����-����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCSJ")]
        public DateTime? CJQDXSKCSJ { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮ����-���ɾ�����(��)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCJSL")]
        public int? CJQDXSKCJSL { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮ����-���ɾ����(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCJSD")]
        public decimal? CJQDXSKCJSD { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮ����-������(m3/a)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCL1")]
        public decimal? CJQDXSKCL1 { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮ����-������(m3/d)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCL2")]
        public decimal? CJQDXSKCL2 { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ-����ǰˮλ(ͷ)�߳�(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCQSW")]
        public decimal? CJQDXSKCQSW { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ-©������ˮλ(ͷ)�߳�(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSLDZXSW")]
        public decimal? CJQDXSLDZXSW { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ�ع�-�ع��λ
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGCW")]
        public string CJQDXSHGCW { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ�ع�-�ع�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGSJ")]
        public DateTime? CJQDXSHGSJ { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ�ع�-�عྮ����(��)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSL")]
        public int? CJQDXSHGJSL { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ�ع�-�عྮ���(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSD")]
        public decimal? CJQDXSHGJSD { get; set; }
        /// <summary>
        /// ��������������
        /// </summary>
        /// <returns></returns>
        [Column("CJQRLHDTZ")]
        public string CJQRLHDTZ { get; set; }
        /// <summary>
        /// ����ԭ��
        /// </summary>
        /// <returns></returns>
        [Column("CJYY")]
        public string CJYY { get; set; }
        /// <summary>
        /// ��չ����
        /// </summary>
        /// <returns></returns>
        [Column("FZQS")]
        public string FZQS { get; set; }
        /// <summary>
        /// �ֺ���״��Ԥ��
        /// </summary>
        /// <returns></returns>
        [Column("ZAXZJYC")]
        public string ZAXZJYC { get; set; }
        /// <summary>
        /// ������״������-�Ѳ�ȡ�ķ��δ�ʩ��Ч��
        /// </summary>
        /// <returns></returns>
        [Column("YCQFZCS")]
        public string YCQFZCS { get; set; }
        /// <summary>
        /// ������״������-�����ν���
        /// </summary>
        /// <returns></returns>
        [Column("JHFZCS")]
        public string JHFZCS { get; set; }
        /// <summary>
        /// �ֳ�ͼ��-ƽ(��)��ͼ
        /// </summary>
        /// <returns></returns>
        [Column("PMT")]
        public string PMT { get; set; }
        /// <summary>
        /// �ֳ�ͼ��-ͼƬ�����
        /// </summary>
        /// <returns></returns>
        [Column("TPBH")]
        public string TPBH { get; set; }
        /// <summary>
        /// �ֳ�ͼ��-Ӱ�񼰱��
        /// </summary>
        /// <returns></returns>
        [Column("YXBH")]
        public string YXBH { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("DCR")]
        [Desc("������")]
        public string DCR { get; set; }
        /// <summary>
        /// ��¼��
        /// </summary>
        /// <returns></returns>
        [Column("JLR")]
        public string JLR { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        [Column("SHR")]
        public string SHR { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("TBSJ")]
        [Desc("�������")]
        public DateTime? TBSJ { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            //this.DMCJBH = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            //this.DMCJBH = keyValue;
        }
        #endregion
    }
    public class MasterDetailEntity
    {
        public TBL_DMCJ_BASEINFOEntity TBL_DMCJ_BASEINFOEntity { get; set; }

        public List<TBL_DMCJ_BASEINFO_SUBEntity> TBL_DMCJ_BASEINFO_SUBList { get; set; }
    }
}