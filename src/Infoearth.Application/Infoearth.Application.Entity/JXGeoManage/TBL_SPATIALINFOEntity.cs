using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 14:23
    /// �� ������Χ���ݱ�
    /// </summary>
    public class TBL_SPATIALINFOEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// GUID
        /// </summary>
        /// <returns></returns>
        [Column("SPATIALID")]
        public string SPATIALID { get; set; }
        /// <summary>
        /// ͼ������
        /// </summary>
        /// <returns></returns>
        [Column("SPATIALNAME")]
        public string SPATIALNAME { get; set; }
        /// <summary>
        ///  �յ�����
        /// </summary>
        /// <returns></returns>
        [Column("BOUNDARY")]
        public string BOUNDARY { get; set; }
        /// <summary>
        /// ͼ��ID
        /// </summary>
        /// <returns></returns>
        [Column("LAYERID")]
        public string LAYERID { get; set; }
        /// <summary>
        ///  ��ʽID
        /// </summary>
        /// <returns></returns>
        [Column("STYLEID")]
        public string STYLEID { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("DESCRIBE")]
        public string DESCRIBE { get; set; }
        /// <summary>
        /// �ֺ���ID
        /// </summary>
        /// <returns></returns>
        [Column("SUBCODE")]
        public string SUBCODE { get; set; }
        /// <summary>
        /// ���ͣ�GeoDisaster��
        /// </summary>
        /// <returns></returns>
        [Column("SUBTYPE")]
        public string SUBTYPE { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.SPATIALID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.SPATIALID = keyValue;
        }
        #endregion
    }
}