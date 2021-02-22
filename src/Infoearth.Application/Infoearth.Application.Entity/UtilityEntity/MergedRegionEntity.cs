using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Entity.SystemManage;
using iTelluro.SYS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Entity
{
    /// <summary>
    /// 合并列
    /// </summary>
    public class MergedRegionEntity
    {
        public string rowReplace { get; set; }
        public bool IsAddCol { get; set; }
        public string rowText { get; set; }
        public string rowName { get; set; }
        public string columnName { get; set; }
        public string columnNameReplace { get; set; }
        public int rowFrom { get; set; }
        public int colFrom { get; set; }
        public int rowTo { get; set; }
        public int colTo { get; set; }
        public bool isNoMerged { get; set; }
        public int GroupHeaderCount { get; set; }//多表头
    }
    public class EchartEntity 
    {
        public IList<string> columnList;
        public IList<dataEntity> dataList;
        public IList<AreaEntity> AreaList;
        //public IList<DistrictDict> AreaList;
    }
    public class EchartEntityNEW
    {
        public IList<string> areacodeList;
        public IList<string> areanameList;
        public IList<string> longitudeList;
        public IList<string> latitudeList;
        public IList<dataEntity> count;
        public DataTable data;
    }
    public class EchartEntityNEWS
    {
        public IList<string> proviceList;
        public IList<string> provicenameList;
        public IList<string> cityList;
        public IList<string> citynameList;
        public IList<string> countyList;
        public IList<string> countynameList;       
        public IList<string> provicelongitude;
        public IList<string> provicelatitude;
        public IList<string> citylongitude;
        public IList<string> citylatitude;
        public IList<string> countylongitude;
        public IList<string> countylatitude;
        public IList<dataEntity> provicecount;
        public IList<dataEntity> citycount;
        public IList<dataEntity> countycount;
        public DataTable data;
        //public IEnumerable<TBL_HAZARDBASICINFOEntity> data;
    }
    public class EchartEntityCJ : EchartEntityNEWS
    {       
        //public DataTable HPdata;
        //public DataTable BTdata;
        //public DataTable NSLdata;
        //public DataTable CJdata;
        //public DataTable TXdata;
        //public DataTable LFdata;
        //public DataTable XPdata;
        public List<TBL_HAZARDBASICINFOEntity> HPdata;
        public List<TBL_HAZARDBASICINFOEntity> BTdata;
        public List<TBL_HAZARDBASICINFOEntity> NSLdata;
        public List<TBL_HAZARDBASICINFOEntity> CJdata;
        public List<TBL_HAZARDBASICINFOEntity> TXdata;
        public List<TBL_HAZARDBASICINFOEntity> LFdata;
        public List<TBL_HAZARDBASICINFOEntity> XPdata;
    }

    //public class NEWEchartEntity
    //{
    //    public IList<string> columnList;
    //    public IList<dataEntity> dataList;
    //    public IList<DistrictDict> AreaList;
    //}
    public class dataEntity 
    {
        public string name;
        public object data;
    }
    public class HeartClass
    {
        public string filed { get; set; }
        public string title { get; set; }
        public int indexColumn { get; set; }
        public int columnNum { get; set; }
        public int rowNum { get; set; }
    }
    public class ExcelType
    {
        public string FiledValue { get; set; }
        public int RowIndex { get; set; }
        public int CellIndex { get; set; }
        public int MergeCount { get; set; }
        public string CellStyle { get; set; }
    }
}
