using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System;
using Infoearth.Application.Entity.SystemManage;
using System.Data;
using System.Linq;
using Infoearth.Application.Entity;
using Infoearth.Util;
using Infoearth.Util.Extension;
using Infoearth.Application.Service.SystemManage;
using Infoearth.Application.Service;

namespace Infoearth.Application.Busines.JXGeoManage
{
    /// <summary>
    /// �� �� InfoearthADMS V6.1.2.0
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-16 15:53
    /// �� �������빤����Ŀ������Ϣ��
    /// </summary>
    public class HarzardTrendAnalyseBLL
    {
        private HarzardTrendAnalyseIService service = new HarzardTrendAnalyseService();
        private JYGC_PROJECTBASEINFOIService projectService = new JYGC_PROJECTBASEINFOService();
        private DataItemDetailService dataItemDetailService = new DataItemDetailService();


        public DataTable QueryStatistics(string queryJson, ref List<MergedRegionEntity> columnList)
        {
            var queryParam = queryJson.ToJObject();
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicDataList = null;
            if (!queryParam["Type"].IsEmpty())
            {
                string value = queryParam["Type"].ToString();
                switch (value.ToLower())
                {
                    case "zqs"://������
                        dicDataList = GetDicData_ZQS(queryJson);
                        break;
                    case "yhdgmqs"://�������ģ����
                        dicDataList = GetDicData_yhdgmqs(queryJson);
                        return service.QueryStatistics_yhdgmqs(queryJson, dicDataList, ref columnList);
                        break;
                    case "zhlxjgmqs"://�ֺ����ͼ���ģ����
                        dicDataList = GetDicData_zhlxjgmqs(queryJson);
                        return service.QueryStatistics_zhlxjgmqs(queryJson, dicDataList, ref columnList);
                        break;
                    //case "nxhqs"://����������
                    //    dicDataList = GetDicData_ZQS(queryJson);
                    //    break;
                    case "nxhd"://�����ŵ�
                        columnList = GetColumn_nxhd();
                        return service.GetList_NXHD(queryJson);
                        break;
                    case "gmdjdb"://���顢���顢��ģ�ȼ��Ա�
                        dicDataList = GetDicData_ZQXQGM(queryJson);
                        return service.QueryStatistics_ZQXQGM(queryJson, dicDataList, ref columnList);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                dicDataList = GetDicData_ZQS(queryJson);
            }
            return service.QueryStatistics(queryJson, dicDataList, ref columnList);
        }
        //������
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_ZQS(string queryJson)
        {
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            //List<DataItemDetailEntity> list = projectService.GetListByDateDiff(queryJson).Select(p => new DataItemDetailEntity { F_ItemValue = p.PROJECTGUID, F_ItemName = p.YEAR.ToString() + "��" }).ToList();
            List<DataItemDetailEntity> list = new List<DataItemDetailEntity>();
            DataItemDetailEntity itemList = new DataItemDetailEntity();
            var queryParam = queryJson.ToJObject();
            DataItemDetailEntity itemList2 = new DataItemDetailEntity();
            itemList2.F_ItemName = queryParam["endYear"].ToString() + "��";
            itemList2.F_ItemValue = queryParam["endYear"].ToString();
            list.Add(itemList2);
            itemList.F_ItemName = queryParam["startYear"].ToString() + "��";
            itemList.F_ItemValue = queryParam["startYear"].ToString();
            list.Add(itemList);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "�ֺ�����(��)", F_ItemDetailId = "1" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "��Ŀ", F_Description = "�������ֺ�����(��)", F_ItemDetailId = " decode(guid,null,0,1) " }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "��Ŀ", F_Description = "��ɰ�Ǩ����(��)", F_ItemDetailId = "decode(ISBQBR,null,0,0,0,1)" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "��Ŀ", F_Description = "����������(��)", F_ItemDetailId = "decode(ISZLGC,null,0,0,0,1)" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "PROJECTID", F_ItemName = "��Ŀ", F_Description = "����������ĵ���(��)", F_ItemDetailId = "decode(ISZRZT,null,0,0,0,1)" }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "�������ֺ�����(��)", F_ItemDetailId = " case when guid=null then 0 else 1 end " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "��ɰ�Ǩ����(��)", F_ItemDetailId = " case  when ISBQBR=null then 0 when ISBQBR=0 then 0 else 1 end" }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "����������(��)", F_ItemDetailId = " case  when ISZLGC=null then 0 when ISZLGC=0 then 0 else 1 end " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "����������ĵ���(��)", F_ItemDetailId = "case  when ISZRZT=null then 0 when ISZRZT=0 then 0 else 1 end " }, list);
            return dicData;
        }
        //�������ģ����
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_yhdgmqs(string queryJson)
        {
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            List<DataItemDetailEntity> list = dataItemDetailService.GetItemDetailList("DISAATERSIZE").ToList();
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "�ֺ���ģ", F_Description = "�ֺ���ģ", F_ItemDetailId = "1" }, list);
            return dicData;
        }
        //���顢���顢��ģ�ȼ��Ա�
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_ZQXQGM(string queryJson)
        {

            List<DataItemDetailEntity> listDic = dataItemDetailService.GetItemDetailList("DISAATERSIZE").ToList();
            string strValue = string.Empty;
            //foreach (var item in listDic)
            //{
            //    strValue += string.Format(",'{0}','{1}'", item.F_ItemValue, item.F_ItemName);
            //}
            //string strDic = " decode({0}" + strValue + ") ";
            foreach (var item in listDic)
            {
                strValue += string.Format(" when '{0}' then '{1}'", item.F_ItemValue, item.F_ItemName);
            }
            string strDic = " case {0}" + strValue + " end ";

            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            //List<DataItemDetailEntity> list = projectService.GetListByDateDiff(queryJson).Select(p => new DataItemDetailEntity { F_ItemValue = p.PROJECTGUID, F_ItemName = p.YEAR.ToString() + "��" }).ToList();
            List<DataItemDetailEntity> list = new List<DataItemDetailEntity>();
            DataItemDetailEntity itemList = new DataItemDetailEntity();
            var queryParam = queryJson.ToJObject();
            DataItemDetailEntity itemList2 = new DataItemDetailEntity();
            itemList2.F_ItemName = queryParam["endYear"].ToString() + "��";
            itemList2.F_ItemValue = queryParam["endYear"].ToString();
            list.Add(itemList2);
            itemList.F_ItemName = queryParam["startYear"].ToString() + "��";
            itemList.F_ItemValue = queryParam["startYear"].ToString();
            list.Add(itemList);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "��Ŀ", F_Description = "�ֺ�����", F_ItemDetailId = "a.DISASTERTYPE" }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "��Ŀ", F_Description = "��ģ�ȼ�", F_ItemDetailId = string.Format(strDic, "a.SCALELEVEL") }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "��Ŀ", F_Description = "����ȼ�", F_ItemDetailId = string.Format(strDic, "a.DISASTERLEVEL") }, list);
            //dicData.Add(new DataItemDetailEntity() { F_ItemValue = "a.PROJECTID", F_ItemName = "��Ŀ", F_Description = "����ȼ�", F_ItemDetailId = string.Format(strDic, "a.DANGERLEVEL") }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "�ֺ�����", F_ItemDetailId = "a.DISASTERTYPE" }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "��ģ�ȼ�", F_ItemDetailId = string.Format(strDic, "a.SCALELEVEL") }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "����ȼ�", F_ItemDetailId = string.Format(strDic, "a.DISASTERLEVEL") }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = DbSqlFunctionHelper.DateToChar("MODIFYTIME", "yyyy"), F_ItemName = "��Ŀ", F_Description = "����ȼ�", F_ItemDetailId = string.Format(strDic, "a.DANGERLEVEL") }, list);
            return dicData;
        }
        //�ֺ����ͼ���ģ����
        private Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> GetDicData_zhlxjgmqs(string queryJson)
        {
            Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicData = new Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>>();
            List<DataItemDetailEntity> list = dataItemDetailService.GetItemDetailList("DISAATERSIZE").ToList();
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "����", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='����' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "����", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='����' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "��ʯ��", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='��ʯ��' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "��������", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='��������' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "���ȶ�б��", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='б��' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "���ѷ�", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='���ѷ�' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "�������", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='�������' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "����������", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='����������' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "����������", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='����������' " }, list);
            dicData.Add(new DataItemDetailEntity() { F_ItemValue = "SCALELEVEL", F_ItemName = "��ģ", F_Description = "ң�н����", F_ItemDetailId = "1", F_ModifyUserName = " and a.DISASTERTYPE='ң�н����' " }, list);
            return dicData;
        }

        private List<MergedRegionEntity> GetColumn_nxhd()
        {
            List<MergedRegionEntity> returnValue = new List<MergedRegionEntity> {
                new MergedRegionEntity() { columnName = "disastername", columnNameReplace = "�ֺ�������", rowFrom = 1, rowTo = 1, colFrom = 0, colTo = 0, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "outdoorcode", columnNameReplace = "Ұ����", rowFrom = 1, rowTo = 1, colFrom = 1, colTo = 1, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "location", columnNameReplace = "λ��", rowFrom = 1, rowTo = 1, colFrom = 2, colTo = 2, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "disastertype", columnNameReplace = "�ֺ�����", rowFrom = 1, rowTo = 1, colFrom = 3, colTo = 3, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "zlgcly", columnNameReplace = "��������", rowFrom = 1, rowTo = 1, colFrom = 4, colTo = 4, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "zlgcsj", columnNameReplace = "������Ǩ���ã�ʱ��", rowFrom = 1, rowTo = 1, colFrom = 5, colTo = 5, GroupHeaderCount = 1 },
                new MergedRegionEntity() { columnName = "zlptzj", columnNameReplace = "���������ʽ���Ԫ��", rowFrom = 1, rowTo = 1, colFrom = 6, colTo = 6, GroupHeaderCount = 1 },
            };
            return returnValue;
        }
    }
}
