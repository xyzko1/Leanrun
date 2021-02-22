using Infoearth.Application.Entity;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Data.Repository;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoearth.Application.Service.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-13 11:25
    /// �� �������������
    /// </summary>
    public class TBL_AVALANCHEService : RepositoryFactory<TBL_AVALANCHEEntity>, TBL_AVALANCHEIService, IAudit
    {
        private TBL_AUDITORSIService audits = new TBL_AUDITORSService();
        private TBL_HAZARDBASICINFOIService hazard = new TBL_HAZARDBASICINFOService();
        private TBL_AVALANCHE_HISTORYIService history = new TBL_AVALANCHE_HISTORYService();
        private TBL_AUDITINFOIService audit = new TBL_AUDITINFOService();
        private TBL_HAZARDBASICINFO_HISTORYIService hazardHistory = new TBL_HAZARDBASICINFO_HISTORYService();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<TBL_AVALANCHEEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return this.BaseRepository().FindList(pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<TBL_AVALANCHEEntity> GetList(string queryJson)
        {
            return this.BaseRepository().IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public TBL_AVALANCHEEntity GetEntity(string keyValue)
        {
            //if (keyValue.Length == 12)
            //{
            //    keyValue += " " + " " + " " + " ";
            //}
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }

        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TBL_AVALANCHEEntity entity, NEWTBL_AVALANCHEEntity newentity = null)
        {
            //��ֵ���λ�ã����ڻ�����ֵ��

            string disasterType = "����";

            DateTime modifyTime = DateTime.Now;

            //string[] location = entity.LOCATION.Split(',');

            //string provice = location[0];
            //string city = location[1];
            //string county = location[2];
            //string town = string.Empty;
            //if (location.Count() > 3)
            //{
            //    town = location[3];
            //}
            string[] location = new string[] { };

            string provice = string.Empty;
            string city = string.Empty;
            string county = string.Empty;
            string town = string.Empty;
            string VILLAGE = string.Empty;
            string TEAM = string.Empty;
            if (newentity != null)
            {
                provice = newentity.PROVINCENAME;
                city = newentity.CITYNAME;
                county = newentity.COUNTYNAME;
                town = newentity.TOWNNAME;
                VILLAGE = newentity.VILLAGE;
                TEAM = newentity.TEAM;
            }
            else
            {
                provice = entity.PROVINCENAME;
                city = entity.CITYNAME.Split(',').Length > 0 ? entity.CITYNAME.Split(',')[0] : "";
                county = entity.COUNTYNAME;
                town = entity.TOWNNAME;
                VILLAGE = entity.VILLAGE;
                TEAM = entity.TEAM;
                //location = entity.LOCATION.Split(',');
                //provice = location[0];
                //city = location[1];
                //county = location[2];
                //if (location.Count() > 3)
                //{
                //    town = location[3];
                //}

            }
            //��ȡ��ǰ�û�����
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;

            //  string auditor = audits.GetAudits(entity.TOWN, "A");  //A��ʾ���ֵ�������
            string auditor = audits.GetAudits(entity.UNIFIEDCODE.Substring(0, 6), "A");  //A��ʾ���ֵ�������
            entity.COUNTYCODE = entity.UNIFIEDCODE.Substring(0, 6);
            #region ���ݱ���

            //δ�������
            if (string.IsNullOrEmpty(auditor))
            {
                //�༭
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //if (keyValue.Length == 12)
                    //{
                    //    keyValue += " " + " " + " " + " ";
                    //}
                    TBL_HAZARDBASICINFOEntity hazardInfo = hazard.GetEntity(keyValue);
                    //�༭������Ϣ��
                    EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_HAZARDBASICINFOEntity>(entity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = entity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = entity.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    //hazardInfo.LOCATION = entity.LOCATION.Replace(",", "");
                    hazardInfo.LOCATION = entity.LOCATION;
                    hazardInfo.MODIFYTIME = modifyTime;
                    hazardInfo.MODIFYUSER = userName;

                    hazard.SaveForm(keyValue, hazardInfo);

                    //�༭�����
                    entity.UPDATEUSER = userName;
                    entity.UPDATETIME = modifyTime;

                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);

                    //������ʷ��
                    TBL_AVALANCHE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_AVALANCHE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "U";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    history.SaveForm(string.Empty, historyInfo);

                    #region ��ӵ���ʷ������ 2019-2-14 by wc

                    TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = "U";
                    basicHistoryInfo.MODIFYUSER = userName;
                    basicHistoryInfo.AUDITSTATUS = "5";
                    basicHistoryInfo.AUDITOR = auditor;
                    basicHistoryInfo.THREATENPEOPLE = entity.THREATENPEOPLE;//��в�˿�
                    basicHistoryInfo.THREATENASSETS = entity.THREATENASSETS;//��в�Ʋ�
                    basicHistoryInfo.FILLTABLEDATE = historyInfo.FILLTABLEDATE;

                    hazardHistory.SaveEntity(historyInfo.GUID, basicHistoryInfo);

                    #endregion
                }
                //����
                else
                {
                    //����������Ϣ��
                    TBL_HAZARDBASICINFOEntity hazardInfo = EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_HAZARDBASICINFOEntity>(entity);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = entity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = entity.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    //hazardInfo.LOCATION = entity.LOCATION.Replace(",", "");
                    hazardInfo.LOCATION = entity.LOCATION;
                    hazardInfo.MODIFYTIME = modifyTime;
                    hazardInfo.MODIFYUSER = userName;
                    hazardInfo.CREATETIME = modifyTime;
                    hazardInfo.CREATEUSER = userName;
                    hazardInfo.ISXH = "0";
                    hazard.SaveForm(keyValue, hazardInfo);

                    //���������

                    entity.UPDATEUSER = userName;
                    entity.UPDATETIME = modifyTime;
                    entity.CREATORTIME = modifyTime;
                    entity.CREATORUSERID = userName;

                    this.BaseRepository().Insert(entity);

                    //������ʷ��
                    TBL_AVALANCHE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_AVALANCHE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;
                    historyInfo.CREATORTIME = modifyTime;
                    historyInfo.CREATORUSERID = userName;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "A";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "5";
                    historyInfo.AUDITOR = auditor;
                    history.SaveForm(string.Empty, historyInfo);

                    #region ��ӵ���ʷ������ 2019-2-14 by wc

                    TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = "A";
                    basicHistoryInfo.MODIFYUSER = userName;
                    basicHistoryInfo.AUDITSTATUS = "5";
                    basicHistoryInfo.AUDITOR = auditor;
                    basicHistoryInfo.FILLTABLEDATE = historyInfo.FILLTABLEDATE;
                    basicHistoryInfo.THREATENPEOPLE = entity.THREATENPEOPLE;//��в�˿�
                    basicHistoryInfo.THREATENASSETS = entity.THREATENASSETS;//��в�Ʋ�

                    hazardHistory.SaveEntity(historyInfo.GUID, basicHistoryInfo);

                    #endregion
                }
            }
            //�������
            else
            {
                //�༭
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //������ʷ��
                    TBL_AVALANCHE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_AVALANCHE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "U";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "0";
                    historyInfo.AUDITOR = auditor;
                    historyInfo.GUID=history.SaveForm(string.Empty, historyInfo);

                    //������˱�
                    TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                    auditEntity.UPDATETIME = modifyTime;
                    auditEntity.UPDATETYPE = "U";
                    auditEntity.UPDATEUSER = userName;
                    auditEntity.STATUS = "0";
                    auditEntity.BUSSNESSTYPE = "A";
                    auditEntity.BUSINESSID = historyInfo.GUID;
                    auditEntity.BASICINFO = "TBL_AVALANCHE_HISTORY," + historyInfo.DISASTERUNITNAME + "," + historyInfo.UNIFIEDCODE + "," + disasterType;
                    auditEntity.AUDITOR = auditor;
                    audit.SaveForm(string.Empty, auditEntity);
                }
                else
                {
                    //������ʷ��
                    TBL_AVALANCHE_HISTORYEntity historyInfo = EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_AVALANCHE_HISTORYEntity>(entity);

                    historyInfo.UPDATEUSER = userName;
                    historyInfo.UPDATETIME = modifyTime;
                    historyInfo.CREATORTIME = modifyTime;
                    historyInfo.CREATORUSERID = userName;

                    historyInfo.MODIFIEDDATE = modifyTime;
                    historyInfo.MODIFYTYPE = "A";
                    historyInfo.EDITOR = userName;
                    historyInfo.AUDITSTATUS = "0";
                    historyInfo.AUDITOR = auditor;
                    historyInfo.GUID=history.SaveForm(string.Empty, historyInfo);

                    //������˱�
                    TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                    auditEntity.UPDATETIME = modifyTime;
                    auditEntity.UPDATETYPE = "A";
                    auditEntity.UPDATEUSER = userName;
                    auditEntity.BUSSNESSTYPE = "A";
                    auditEntity.STATUS = "0";
                    auditEntity.BUSINESSID = historyInfo.GUID;
                    auditEntity.BASICINFO = "TBL_AVALANCHE_HISTORY," + historyInfo.DISASTERUNITNAME + "," + historyInfo.UNIFIEDCODE + "," + disasterType;
                    auditEntity.AUDITOR = auditor;
                    audit.SaveForm(string.Empty, auditEntity);
                }
            }

            #endregion
        }
        #endregion

        #region ������

        /// <summary>
        /// ��˼�¼
        /// </summary>
        /// <param name="bussnessId"></param>
        /// <param name="updateType"></param>
        public void AuditData(string bussnessId, string updateType)
        {
            //��ѯ���� 
            TBL_AVALANCHE_HISTORYEntity historyEntity = history.GetEntity(bussnessId);

            TBL_HAZARDBASICINFOEntity hazardInfo = null;

            TBL_AVALANCHEEntity entity = null;

            string disasterType = "����";

            DateTime modifyTime = DateTime.Now;

            //string[] location = historyEntity.LOCATION.Split(',');

            //string provice = location[0];
            //string city = location[1];
            //string county = location[2];
            //string town = string.Empty;
            //if (location.Count() > 3)
            //{
            //    town = location[3];
            //}
            string provice = historyEntity.PROVINCENAME;
            string city = historyEntity.CITYNAME.Split(',').Length > 0 ? historyEntity.CITYNAME.Split(',')[0] : "";
            string county = historyEntity.COUNTYNAME;
            string town = historyEntity.TOWNNAME;
            string VILLAGE = historyEntity.VILLAGE;
            string TEAM = historyEntity.TEAM;
            switch (updateType)
            {
                //����
                case "A":
                    //����������Ϣ��
                    hazardInfo = EntityCoverter.Covert<TBL_AVALANCHE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");
                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    hazardInfo.CREATETIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.CREATEUSER = historyEntity.EDITOR;
                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                    hazard.SaveForm(string.Empty, hazardInfo);

                    //���������
                    entity = EntityCoverter.Covert<TBL_AVALANCHE_HISTORYEntity, TBL_AVALANCHEEntity>(historyEntity);
                    this.BaseRepository().Insert(entity);

                    #region ��ӵ���ʷ������ 2019-2-14 by wc

                    TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion

                    break;
                case "U":
                    hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);
                    //�༭������Ϣ��
                    EntityCoverter.Covert<TBL_AVALANCHE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");
                    hazardInfo.VILLAGE = VILLAGE;
                    hazardInfo.TEAM = TEAM;
                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                    hazard.SaveForm(historyEntity.UNIFIEDCODE, hazardInfo);

                    //�༭�����
                    entity = EntityCoverter.Covert<TBL_AVALANCHE_HISTORYEntity, TBL_AVALANCHEEntity>(historyEntity);
                    entity.Modify(historyEntity.UNIFIEDCODE);
                    this.BaseRepository().Update(entity);

                    #region ��ӵ���ʷ������ 2019-2-14 by wc

                    basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion
                    break;
                case "D":

                    #region ������ʷ������ 2019-2-14 by wc

                    hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);

                    EntityCoverter.Covert<TBL_AVALANCHE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");

                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                    basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.ISXH = "1";
                    basicHistoryInfo.VERIFICATION = historyEntity.VERIFICATION;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion

                    //ɾ��������Ϣ��
                    hazard.RemoveForm(historyEntity.UNIFIEDCODE);

                    //ɾ�������
                    this.BaseRepository().Delete(historyEntity.UNIFIEDCODE);

                    //�����и����ֺ������ʷ���ݺ���״̬�޸�
                    string sql = string.Format("update TBL_AVALANCHE_HISTORY set verification = '{0}' where GUID = '{1}'", historyEntity.VERIFICATION, bussnessId);
                    int result = this.BaseRepository().ExecuteBySql(sql);


                    break;
                case "R":

                    #region ������ʷ������ 2019-2-14 by wc

                    hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);

                    EntityCoverter.Covert<TBL_AVALANCHE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                    hazardInfo.DISASTERTYPE = disasterType;
                    hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                    hazardInfo.PROVINCENAME = provice;
                    hazardInfo.CITYNAME = city;
                    hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                    hazardInfo.COUNTYNAME = county;
                    hazardInfo.TOWNNAME = town;
                    hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");

                    hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                    hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                    basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                    basicHistoryInfo.MODIFYTIME = modifyTime;
                    basicHistoryInfo.MODIFYTYPE = updateType;
                    basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                    basicHistoryInfo.AUDITSTATUS = "2";
                    basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                    basicHistoryInfo.ISXH = "1";
                    basicHistoryInfo.VERIFICATION = historyEntity.VERIFICATION;
                    basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                    hazardHistory.SaveEntity(bussnessId, basicHistoryInfo);

                    #endregion

                    //ɾ��������Ϣ��
                    hazard.RemoveForm(historyEntity.UNIFIEDCODE);

                    //ɾ�������
                    this.BaseRepository().Delete(historyEntity.UNIFIEDCODE);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="bussnessKey">ҵ�������</param>
        /// <param name="verificationType">��������</param>
        public void VerificationData(string bussnessKey, int verificationType, DateTime fillTableDate)
        {
            //�����
            TBL_AVALANCHEEntity entity = this.BaseRepository().FindEntity(bussnessKey);
            string auditInfo = audits.GetAudits(entity.TOWN, "A");

            DateTime now = DateTime.Now;
            string disasterType = "����";
            //��ȡ��ǰ�û�����
            UserInfo userInfo = ssoWS.GetUserInfo();
            string userName = userInfo.F_Account;

            //�������
            if (!string.IsNullOrEmpty(auditInfo))
            {
                //������ʷ��
                TBL_AVALANCHE_HISTORYEntity historyEntity = EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_AVALANCHE_HISTORYEntity>(entity);
                historyEntity.MODIFIEDDATE = now;
                historyEntity.MODIFYTYPE = "D";
                historyEntity.EDITOR = userName;
                historyEntity.AUDITSTATUS = "0";
                historyEntity.AUDITOR = auditInfo;
                historyEntity.FILLTABLEDATE = fillTableDate;
                historyEntity.VERIFICATION = verificationType.ToString();

                history.SaveForm(string.Empty, historyEntity);

                //������˱�
                TBL_AUDITINFOEntity auditEntity = new TBL_AUDITINFOEntity();
                auditEntity.Create();
                auditEntity.UPDATETIME = now;
                auditEntity.UPDATETYPE = "D";
                auditEntity.UPDATEUSER = userName;
                auditEntity.STATUS = "0";
                auditEntity.BUSINESSID = historyEntity.GUID;
                auditEntity.BUSSNESSTYPE = "A";
                auditEntity.BASICINFO = "TBL_AVALANCHE_HISTORY," + historyEntity.DISASTERUNITNAME + "," + historyEntity.UNIFIEDCODE + "," + disasterType;
                auditEntity.AUDITOR = auditInfo;
                audit.SaveForm(string.Empty, auditEntity);
            }
            //δ�������
            else
            {
                //������ʷ��
                TBL_AVALANCHE_HISTORYEntity historyEntity = EntityCoverter.Covert<TBL_AVALANCHEEntity, TBL_AVALANCHE_HISTORYEntity>(entity);
                historyEntity.MODIFIEDDATE = now;
                historyEntity.MODIFYTYPE = "D";
                historyEntity.EDITOR = userName;
                historyEntity.AUDITSTATUS = "5";  //�������
                historyEntity.AUDITOR = auditInfo;
                historyEntity.VERIFICATION = verificationType.ToString();
                historyEntity.FILLTABLEDATE = fillTableDate;
                history.SaveForm(string.Empty, historyEntity);

                #region ������ʷ������

                TBL_HAZARDBASICINFOEntity hazardInfo = hazard.GetEntity(historyEntity.UNIFIEDCODE);
                string[] location = historyEntity.LOCATION.Split(',');
                string provice = string.Empty;
                string city = string.Empty;
                string county = string.Empty;
                string town = string.Empty;
                if (location.Count() > 2)
                {
                    provice = location[0];
                    city = location[1];
                    county = location[2];
                    if (location.Count() > 3)
                    {
                        town = location[3];
                    }
                }
                else
                {
                    provice = hazardInfo.PROVINCENAME;
                    city = hazardInfo.CITYNAME;
                    county = hazardInfo.COUNTYNAME;
                    town = hazardInfo.TOWNNAME;
                }
                EntityCoverter.Covert<TBL_AVALANCHE_HISTORYEntity, TBL_HAZARDBASICINFOEntity>(historyEntity, hazardInfo);
                hazardInfo.DISASTERTYPE = disasterType;
                hazardInfo.DISASTERNAME = historyEntity.DISASTERUNITNAME;
                hazardInfo.PROVINCENAME = provice;
                hazardInfo.CITYNAME = city;
                hazardInfo.COUNTY = hazardInfo.UNIFIEDCODE.Substring(0, 6);
                hazardInfo.COUNTYNAME = county;
                hazardInfo.TOWNNAME = town;
                hazardInfo.LOCATION = historyEntity.LOCATION.Replace(",", "");

                hazardInfo.MODIFYTIME = historyEntity.MODIFIEDDATE;
                hazardInfo.MODIFYUSER = historyEntity.EDITOR;

                TBL_HAZARDBASICINFO_HISTORYEntity basicHistoryInfo = EntityCoverter.Covert<TBL_HAZARDBASICINFOEntity, TBL_HAZARDBASICINFO_HISTORYEntity>(hazardInfo);

                basicHistoryInfo.MODIFYTIME = now;
                basicHistoryInfo.MODIFYTYPE = "D";
                basicHistoryInfo.MODIFYUSER = historyEntity.EDITOR;
                basicHistoryInfo.AUDITSTATUS = "5";
                basicHistoryInfo.AUDITOR = historyEntity.AUDITOR;
                basicHistoryInfo.ISXH = "1";
                basicHistoryInfo.VERIFICATION = historyEntity.VERIFICATION;
                basicHistoryInfo.FILLTABLEDATE = historyEntity.FILLTABLEDATE;

                hazardHistory.SaveEntity(historyEntity.GUID, basicHistoryInfo);


                #endregion


                //ɾ�������
                this.BaseRepository().Delete(bussnessKey);

                //ɾ��������Ϣ��
                hazard.RemoveForm(bussnessKey);

            }
        }

        #endregion
    }
}
