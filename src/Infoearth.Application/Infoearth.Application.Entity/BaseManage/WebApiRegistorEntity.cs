using System;
using System.ComponentModel.DataAnnotations.Schema;
using Infoearth.Application.Code;
using Newtonsoft.Json;
using Infoearth.Util;

namespace Infoearth.Application.Entity.BaseManage
{
    /// <summary>
    /// �� �� LearunADMS V6.1.2.0
    /// Copyright (c) 2013-2016 
    /// �� ������������Ա
    /// �� �ڣ�2017-07-27 15:01
    /// �� ����WebApiע��
    /// </summary>
    public class WebApiRegistorEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// WebApi����
        /// </summary>
        /// <returns></returns>
        [Column("F_WEBAPIID")]
        public string F_WebApiId { get; set; }
        /// <summary>
        /// Api��ַ
        /// </summary>
        /// <returns></returns>
        [Column("F_WEBAPIURL")]
        public string F_WebApiUrl { get; set; }
        /// <summary>
        /// ����ʽ(GET,POST,PUT,DELETE)
        /// </summary>
        /// <returns></returns>
        [Column("F_METHEDTYPE")]
        public string F_MethedType { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("F_PARAMETERS")]
        public string F_Parameters { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        [Column("F_RETRUNTYPE")]
        public string F_RetrunType { get; set; }
        /// <summary>
        /// Api����
        /// </summary>
        /// <returns></returns>
        [Column("F_DESCRIPTION")]
        public string F_Description { get; set; }
        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        /// <returns></returns>
        [Column("F_DETAILURL")]
        public string F_DetailUrl { get; set; }
        /// <summary>
        /// F_CreateDate
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEDATE")]
        //[JsonConverter(typeof(DateTimeConverter))]
        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// F_CreateUserId
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERID")]
        public string F_CreateUserId { get; set; }
        /// <summary>
        /// F_CreateUserName
        /// </summary>
        /// <returns></returns>
        [Column("F_CREATEUSERNAME")]
        public string F_CreateUserName { get; set; }
        /// <summary>
        /// F_ModifyDate
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYDATE")]
        //[JsonConverter(typeof(DateTimeConverter))]
        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// F_ModifyUserId
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERID")]
        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// F_ModifyUserName
        /// </summary>
        /// <returns></returns>
        [Column("F_MODIFYUSERNAME")]
        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        [Column("F_BZ")]
        public string F_BZ { get; set; }

        /// <summary>
        /// F_QS
        /// </summary>
        /// <returns></returns>
        [Column("F_QS")]
        public string F_QS { get; set; }
        /// <summary>
        /// F_RS
        /// </summary>
        /// <returns></returns>
        [Column("F_RS")]
        public string F_RS { get; set; }

        /// <summary>
        /// F_SYSTEMNAME
        /// </summary>
        /// <returns></returns>
        [Column("F_SYSTEMNAME")]
        public string F_SYSTEMNAME { get; set; }

        /// <summary>
        /// F_CLASSNAME
        /// </summary>
        /// <returns></returns>
        [Column("F_CLASSNAME")]
        public string F_CLASSNAME { get; set; }

        /// <summary>
        /// F_ACTIONNAME
        /// </summary>
        /// <returns></returns>
        [Column("F_ACTIONNAME")]
        public string F_ACTIONNAME { get; set; }

        /// <summary>
        /// F_STAUE
        /// </summary>
        [Column("F_STAUE")]
        public string F_STAUE { get; set; }

        /// <summary>
        /// F_IP
        /// </summary>
        [Column("F_IP")]
        public string F_IP { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.F_WebApiId = Guid.NewGuid().ToString();
            this.F_CreateDate = DateTime.Now;
            //if (OperatorProvider.Provider != null && OperatorProvider.Provider.Current() != null)
            //{
            //    this.F_CreateUserId = OperatorProvider.Provider.Current().UserId;
            //    this.F_CreateUserName = OperatorProvider.Provider.Current().UserName;
            //}
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_WebApiId = keyValue;
            this.F_ModifyDate = DateTime.Now;
            //if (OperatorProvider.Provider != null && OperatorProvider.Provider.Current() != null)
            //{
            //    this.F_ModifyUserId = OperatorProvider.Provider.Current().UserId;
            //    this.F_ModifyUserName = OperatorProvider.Provider.Current().UserName;
            //}
        }
        #endregion
    }
}