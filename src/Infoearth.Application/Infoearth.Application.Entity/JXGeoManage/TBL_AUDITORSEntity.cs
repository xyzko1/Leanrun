using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-17 14:53
    /// �� ��������˱�
    /// </summary>
    public class TBL_AUDITORSEntity : BaseEntity
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
        /// �������
        /// </summary>
        /// <returns></returns>
        [Column("NAME")]
        public string NAME { get; set; }
        /// <summary>
        /// ��¼��
        /// </summary>
        /// <returns></returns>
        [Column("LOGINNAME")]
        public string LOGINNAME { get; set; }

        /// <summary>
        /// ҵ������
        /// </summary>
        /// <returns></returns>
        [Column("BUSSNESSTYPE")]
        public string BUSSNESSTYPE { get; set; }

         /// <summary>
        /// 0-�������,1-�ر����
        /// </summary>
        /// <returns></returns>
        [Column("ISAUDIT")]
        public string ISAUDIT { get; set; }

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
        /// ��
        /// </summary>
        /// <returns></returns>
        [Column("COUNTY")]
        public string COUNTY { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("TOWN")]
        public string TOWN { get; set; }

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