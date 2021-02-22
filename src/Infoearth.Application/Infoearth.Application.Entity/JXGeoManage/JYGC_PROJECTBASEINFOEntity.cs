using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;

namespace Infoearth.Application.Entity.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 15:53
    /// �� �������빤����Ŀ������Ϣ��
    /// </summary>
    public class JYGC_PROJECTBASEINFOEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ��ĿGUID
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTGUID")]
        public string PROJECTGUID { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTNAME")]
        public string PROJECTNAME { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTCODE")]
        public string PROJECTCODE { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        /// <returns></returns>
        [Column("PROJECTTYPE")]
        public string PROJECTTYPE { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        [Column("YEAR")]
        public int YEAR { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("TIMECREATED")]
        public System.DateTime? TIMECREATED { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        [Column("USERCREATED")]
        public string USERCREATED { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        /// <returns></returns>
        [Column("TIMEMODIFIED")]
        public System.DateTime? TIMEMODIFIED { get; set; }
        /// <summary>
        /// �޸���
        /// </summary>
        /// <returns></returns>
        [Column("USERMODIFIED")]
        public string USERMODIFIED { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.PROJECTGUID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.PROJECTGUID = keyValue;
        }
        #endregion
    }
}