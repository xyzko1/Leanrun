using Infoearth.Application.Entity;
using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Entity.SystemManage;
using Infoearth.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace Infoearth.Application.IService.JXGeoManage
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 �人�ش���Ϣ�ɷ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-03-14 14:58
    /// �� �����ֺ��������
    /// </summary>
    public interface HarzardTrendAnalyseIService
    {
        DataTable QueryStatistics(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList);
        DataTable QueryStatistics_yhdgmqs(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList);
        DataTable GetList_NXHD(string queryJson);
        DataTable QueryStatistics_ZQXQGM(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList);
        DataTable QueryStatistics_zhlxjgmqs(string queryJson, Dictionary<DataItemDetailEntity, List<DataItemDetailEntity>> dicList, ref List<MergedRegionEntity> columnList);
    }
}
