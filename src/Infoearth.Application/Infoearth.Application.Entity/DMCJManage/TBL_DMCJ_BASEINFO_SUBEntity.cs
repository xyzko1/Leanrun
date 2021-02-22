using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.DMCJManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-09-04 12:02
    /// �� ����������������SUB
    /// </summary>
    public class TBL_DMCJ_BASEINFO_SUBEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("GUID")]
        public string GUID { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        [Column("DMCJBH")]
        public string DMCJBH { get; set; }
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
        public System.DateTime? CJQDXSKCSJ { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮ����-���ɾ�����(��)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSKCJSL")]
        public decimal? CJQDXSKCJSL { get; set; }
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
        public System.DateTime? CJQDXSHGSJ { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ�ع�-�عྮ����(��)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSL")]
        public decimal? CJQDXSHGJSL { get; set; }
        /// <summary>
        /// ����������ˮ���ɸſ�-����ˮλ�ع�-�عྮ���(m)
        /// </summary>
        /// <returns></returns>
        [Column("CJQDXSHGJSD")]
        public decimal? CJQDXSHGJSD { get; set; }
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