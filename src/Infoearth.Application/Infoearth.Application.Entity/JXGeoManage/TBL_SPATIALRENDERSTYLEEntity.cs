using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2019-03-28 14:24
    /// �� ������Χͼ����ʽ��
    /// </summary>
    public class TBL_SPATIALRENDERSTYLEEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("STYLEID")]
        public string STYLEID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("LINEWIDTH")]
        public string LINEWIDTH { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("LINECOLOR")]
        public string LINECOLOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("LINETRANSPARENCY")]
        public string LINETRANSPARENCY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("FILLCOLOR")]
        public string FILLCOLOR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("ISFILL")]
        public string ISFILL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("FILLTRANSPARENCY")]
        public string FILLTRANSPARENCY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("ISLINEFRAME")]
        public string ISLINEFRAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Column("REMARKS")]
        public string REMARKS { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.STYLEID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.STYLEID = keyValue;
        }
        #endregion
    }
}