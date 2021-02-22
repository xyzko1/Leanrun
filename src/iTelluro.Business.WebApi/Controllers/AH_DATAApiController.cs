using Infoearth.Application.Entity.JXGeoManage;
using Infoearth.Application.Busines.JXGeoManage;
using Infoearth.Util;
using Infoearth.Util.WebControl;
using iTelluro.Busness.WebApiProxy;
using System.Collections.Generic;
using Infoearth.Application.Entity.SystemManage;
using System.Linq;
using Infoearth.Application.Cache;
using Infoearth.Util.Offices;
using System;
using System.Data;
using System.Collections;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Infoearth.Application.Entity;
using System.Configuration;
using DAL;
using Infoearth.Application.Busines;
using System.Data.OleDb;

namespace iTelluro.Busness.WebApi.Controllers
{
    public class AH_DATAApiController : ApiControllerBase
    {
        private TBL_HAZARDBASICINFOBLL tbl_hazardbasicinfobll = new TBL_HAZARDBASICINFOBLL();
        private SSOWebApiWS ssoWS = new SSOWebApiWS("");
        private DBhelper tbl_sqlhelp = new DBhelper();
        private TBL_AVALANCHEBLL tbl_AVALANCHEbll = new TBL_AVALANCHEBLL();//崩塌
        private TBL_LANDSLIPBLL tbl_landslipbll = new TBL_LANDSLIPBLL();//滑坡
        private TBL_DEBRISFLOWBLL tbl_debrisflowbll = new TBL_DEBRISFLOWBLL();//泥石流
        private TBL_LANDSETTLEMENTBLL tbl_landsettlementbll = new TBL_LANDSETTLEMENTBLL();//地面沉降
        private TBL_COLLAPSEBLL tbl_collapsebll = new TBL_COLLAPSEBLL();//地面塌陷
        private TBL_LANDCRACKBLL tbl_landcrackbll = new TBL_LANDCRACKBLL();//地裂缝
        private TBL_SLOPEBLL tbl_slopebll = new TBL_SLOPEBLL();//斜坡
        public string BaseDb = ConfigurationManager.ConnectionStrings["AHBaseDb"].ConnectionString;
        private TBL_XIAOHAOBLL tbl_xiaohaobll = new TBL_XIAOHAOBLL();
        private TBL_QCQF_DISASTERPREVENTIONBLL tbl_QCQF = new TBL_QCQF_DISASTERPREVENTIONBLL();
        static string strConn = "";
        [HttpGet]
        //[HttpPost]
        public object GetData()
        {
            //获取选中文件的路径
            string path = "C:\\Users\\admin\\Desktop\\转换.xls";
            //获取文件后缀名 
            if (System.IO.Path.GetExtension(path).ToLower() == ".xls")
            {
                //如果是07以下（.xls）的版本的Excel文件就使用这条连接字符串
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=Excel 8.0;";
            }
            else
            {
                //如果是07以上(.xlsx)的版本的Excel文件就使用这条连接字符串
                strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + path + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=1'"; //此連接可以操作.xls與.xlsx文件
            }
            if (System.IO.Path.GetExtension(path).ToLower().Contains(".xls"))
            {
                //打开Excel的连接，设置连接对象
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable sheetNames = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //OleDbConnection conn = new OleDbConnection(strConn);
                //当前选中的工作表前几行数据，获取数据列
                OleDbDataAdapter oada = new OleDbDataAdapter("select  * from [Sheet1$]", strConn);
                DataTable dt = new DataTable();
                oada.Fill(dt);
                conn.Close();
                var tablelist = tbl_hazardbasicinfobll.GetValue().ToList();//获取库中灾害点所有数据
                List<string> list = new List<string>();
                DataTable data = dt.Clone();
                //存在 不存在
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow result_dr = data.NewRow();
                    var unicode = tablelist.Where(p => p.OLDUNIFIEDCODE.Equals((dt.Rows[i]["OLDUNIFIEDCODE"].ToString()))).Select(p => p.UNIFIEDCODE).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(unicode))
                    {
                        result_dr["OLDUNIFIEDCODE"] = dt.Rows[i]["OLDUNIFIEDCODE"].ToString();
                        result_dr["UNIFIEDCODE"] = unicode;
                        result_dr["DISASTERTYPE"] = dt.Rows[i]["DISASTERTYPE"].ToString();
                        result_dr["OUTDOORCODE"] = dt.Rows[i]["OUTDOORCODE"].ToString();
                        result_dr["DISASTERNAME"] = dt.Rows[i]["DISASTERNAME"].ToString();
                        result_dr["LONGITUDE"] = dt.Rows[i]["LONGITUDE"].ToString();
                        result_dr["LATITUDE"] = dt.Rows[i]["LATITUDE"].ToString();
                        result_dr["THREATENASSETS"] = dt.Rows[i]["THREATENASSETS"].ToString();
                        result_dr["THREATENPEOPLE"] = dt.Rows[i]["THREATENPEOPLE"].ToString();
                        result_dr["ASSDD"] = dt.Rows[i]["ASSDD"].ToString();
                        data.Rows.Add(result_dr);
                    }
                    else
                    {
                        result_dr["OLDUNIFIEDCODE"] = dt.Rows[i]["OLDUNIFIEDCODE"].ToString();
                        result_dr["UNIFIEDCODE"] = "";
                        result_dr["DISASTERTYPE"] = dt.Rows[i]["DISASTERTYPE"].ToString();
                        result_dr["OUTDOORCODE"] = dt.Rows[i]["OUTDOORCODE"].ToString();
                        result_dr["DISASTERNAME"] = dt.Rows[i]["DISASTERNAME"].ToString();
                        result_dr["LONGITUDE"] = dt.Rows[i]["LONGITUDE"].ToString();
                        result_dr["LATITUDE"] = dt.Rows[i]["LATITUDE"].ToString();
                        result_dr["THREATENASSETS"] = dt.Rows[i]["THREATENASSETS"].ToString();
                        result_dr["THREATENPEOPLE"] = dt.Rows[i]["THREATENPEOPLE"].ToString();
                        result_dr["ASSDD"] = dt.Rows[i]["ASSDD"].ToString();
                        data.Rows.Add(result_dr);
                    }
                }
                int count = data.Rows.Count;
                ExcelHelper.ExcelDownloadOnlyDT(data, "排查数据", string.Format("排查数据导出{0}.xls", DateTime.Now.ToLongDateString().ToString()));
            }

                //    //DataTable s6 = ds.Clone();
                //    //var irem1 = ds.Select(" 潜在灾害类型 ''");
                //    //foreach (var item in irem1)
                //    //{
                //    //    DataRow dr = s6.NewRow();
                //    //    dr = item;
                //    //    s6.Rows.Add(dr.ItemArray);
                //    //}
                //    List<TBL_LANDSLIPEntity> testList6 = ds.ConvertToModel<TBL_LANDSLIPEntity>();
                //    string ssoUrl = System.Configuration.ConfigurationManager.AppSettings["SSOUrl"];
                //    SSOWebApiWS ws = new SSOWebApiWS(ssoUrl);
                //    //  List<AreaEntity> result = ws.GetTreeJsonForMap(null, "0");
                //    List<string> selectXZQH = new List<string>();
                //    selectXZQH = ssoWS.GetAreaListJson("0").Select(p => p.F_AreaCode).ToList();
                //    List<AreaEntity> result = ssoWS.GetDistricts(new AdministrativeEntity() { PageIndex = 1, PageSize = 100000 }).ToList();
                //    Dictionary<string, TBL_QCQF_DISASTERPREVENTIONEntity> ss = new Dictionary<string, TBL_QCQF_DISASTERPREVENTIONEntity>();
                //    List<TBL_QCQF_DISASTERPREVENTIONEntity> testList7 = ds.ConvertToModel<TBL_QCQF_DISASTERPREVENTIONEntity>();
                //    string[] stirngarr = new string[testList7.Count];
                //    foreach (var item in testList6)
                //    {
                //        item.LOCATION = item.PROVINCE + "," + item.CITY + "," + item.COUNTYCODE + "," + item.TOWN + "," + item.VILLAGE;

                //        //item.PROVINCE = result.Where(s => s.F_AreaName == item.PROVINCE).ToList()[0].F_AreaCode;
                //        item.PROVINCE = "360000";
                //        item.CITY = result.Where(s => s.F_AreaName == item.CITY && s.F_AreaCode.StartsWith("36")).ToList().ToList().Count == 0 ? "" : result.Where(s => s.F_AreaName == item.CITY && s.F_AreaCode.StartsWith("36")).ToList()[0].F_AreaCode;
                //        item.COUNTYCODE = result.Where(s => s.F_AreaName == item.COUNTYCODE && s.F_AreaCode.StartsWith("36")).ToList().Count == 0 ? "" : result.Where(s => s.F_AreaName == item.COUNTYCODE && s.F_AreaCode.StartsWith("36")).ToList()[0].F_AreaCode;
                //        item.TOWN = result.Where(s => s.F_AreaName == item.TOWN && s.F_AreaCode.StartsWith("36")).ToList().ToList().Count == 0 ? "" : result.Where(s => s.F_AreaName == item.TOWN && s.F_AreaCode.StartsWith("36")).ToList()[0].F_AreaCode;
                //        if (string.IsNullOrEmpty(item.COUNTYCODE))
                //        {
                //            item.COUNTYCODE = "360102";
                //        }
                //        item.UNIFIEDCODE = item.COUNTYCODE + "01" + item.INDOORCODE;
                //        TBL_QCQF_DISASTERPREVENTIONEntity ssss = new TBL_QCQF_DISASTERPREVENTIONEntity();
                //        if (ss.TryGetValue(item.UNIFIEDCODE, out ssss))
                //        {
                //            item.UNIFIEDCODE = "360103" + "01" + item.INDOORCODE;

                //            if (ss.TryGetValue(item.UNIFIEDCODE, out ssss))
                //            {
                //                item.UNIFIEDCODE = "360105" + "01" + item.INDOORCODE;
                //                ss.Add(item.UNIFIEDCODE, ssss);
                //            }
                //            else
                //            {
                //                ss.Add(item.UNIFIEDCODE, ssss);
                //            }
                //        }
                //        else
                //        {
                //            ss.Add(item.UNIFIEDCODE, ssss);
                //        }

                //    }
                //    // foreach (var item in ss)
                //    for (int i = 0; i < ss.Count; i++)
                //    {
                //        var element = ss.ElementAt(i);
                //        TBL_QCQF_DISASTERPREVENTIONEntity qwe = testList7[i] as TBL_QCQF_DISASTERPREVENTIONEntity;
                //        qwe.UNIFIEDCODE = element.Key;
                //        testList7.Add(qwe);
                //    }
                //    foreach (var item in testList6)
                //    {
                //        tbl_landslipbll.SaveForm(string.Empty, item);
                //    }

                //    foreach (var item in testList7)
                //    {
                //        tbl_QCQF.SaveForm(string.Empty, item);
                //    }


                //    //int i = 0;
                //    ////遍历Excel文件获取Excel工作表，并将所有工作表名称加载到comboBox控件中
                //    //foreach (DataRow dr in sheetNames.Rows)
                //    //{
                //    //    if (i == 0)
                //    //    {
                //    //        this.comboBoxSheet.Text = dr[2].ToString();
                //    //    }
                //    //    //添加工作表名称
                //    //    comboBoxSheet.Items.Add(dr[2]);
                //    //    i++;
                //    //}
                //    //label4_Click(sender, e);
                //    //label3_Click(sender, e);
                //}
                //else
                //{
                //    //MessageBox.Show("excel 格式不正确！");
                //}
                //Oracle的导入方式
                //string sql1 = @"select * from TBL_AVALANCHE where PROVINCE='370000' and LOCATION like'%,%'";
                //DataTable s1 = tbl_sqlhelp.ExecuteDataSet(BaseDb, sql1).Tables[0];
                //List<TBL_AVALANCHEEntity> testList1 = s1.ConvertToModel<TBL_AVALANCHEEntity>();
                //foreach (var item in testList1)
                //{
                //    tbl_AVALANCHEbll.SaveForm(string.Empty, item);
                //}

                //string sql2 = "select * from TBL_COLLAPSE where PROVINCE='370000' and LOCATION like'%,%'";
                //DataTable s2 = tbl_sqlhelp.ExecuteDataSet(BaseDb, sql2).Tables[0];
                //List<TBL_COLLAPSEEntity> testList2 = s2.ConvertToModel<TBL_COLLAPSEEntity>();
                //foreach (var item in testList2)
                //{
                //    tbl_collapsebll.SaveForm(string.Empty, item);
                //}
                //string sql3 = "select * from TBL_LANDCRACK where PROVINCE='370000' and LOCATION like'%,%'";
                //DataTable s3 = tbl_sqlhelp.ExecuteDataSet(BaseDb, sql3).Tables[0];
                //List<TBL_LANDCRACKEntity> testList3 = s3.ConvertToModel<TBL_LANDCRACKEntity>();
                //foreach (var item in testList3)
                //{
                //    tbl_landcrackbll.SaveForm(string.Empty, item);
                //}
                //string sql4 = "select * from TBL_LANDSETTLEMENT where PROVINCE='370000' and LOCATION like'%,%'";
                //DataTable s4 = tbl_sqlhelp.ExecuteDataSet(BaseDb, sql4).Tables[0];
                //List<TBL_LANDSETTLEMENTEntity> testList4 = s4.ConvertToModel<TBL_LANDSETTLEMENTEntity>();
                //foreach (var item in testList4)
                //{
                //    tbl_landsettlementbll.SaveForm(string.Empty, item);
                //}
                //string sql5 = "select * from TBL_LANDSLIP where PROVINCE='370000' and LOCATION like'%,%'";
                //DataTable s5 = tbl_sqlhelp.ExecuteDataSet(BaseDb, sql5).Tables[0];
                //List<TBL_LANDSLIPEntity> testList5 = s5.ConvertToModel<TBL_LANDSLIPEntity>();
                //foreach (var item in testList5)
                //{
                //    tbl_landslipbll.SaveForm(string.Empty, item);
                //}
                //string sql6 = "select * from TBL_DEBRISFLOW where PROVINCE='370000' and LOCATION like'%,%'";
                //DataTable s6 = tbl_sqlhelp.ExecuteDataSet(BaseDb, sql6).Tables[0];
                //List<TBL_DEBRISFLOWEntity> testList6 = s6.ConvertToModel<TBL_DEBRISFLOWEntity>();
                //foreach (var item in testList6)
                //{
                //    tbl_debrisflowbll.SaveForm(string.Empty, item);
                //}
                //string sql7 = "select * from TBL_SLOPE where PROVINCE='370000' and LOCATION like'%,%'";
                //DataTable s7 = tbl_sqlhelp.ExecuteDataSet(BaseDb, sql7).Tables[0];
                //List<TBL_SLOPEEntity> testList7 = s7.ConvertToModel<TBL_SLOPEEntity>();
                //foreach (var item in testList7)
                //{
                //    tbl_slopebll.SaveForm(string.Empty, item);
                //}
                //以下是SqlServer的数据库导入方式
                //string sql1 = "select TA.*,TA.ISHEXIAO AS ISXH,TB.provincename,TB.cityname,TB.countyname,TB.townname from TBL_AVALANCHE TA INNER JOIN tbl_hazardbasicinfo TB ON TA.unifiedcode=TB.unifiedcode  AND TA.PROVINCE='340000' ";
                //DataTable s1 = DBhelper.ExecuteSelect(sql1);
                //List<NEWTBL_AVALANCHEEntity> testList1 = s1.ConvertToModel<NEWTBL_AVALANCHEEntity>();
                //List<TBL_AVALANCHEEntity> newa = s1.ConvertToModel<TBL_AVALANCHEEntity>();
                //for (int i = 0; i < testList1.Count; i++)
                //{
                //    testList1[i].UNIFIEDCODE = testList1[i].UNIFIEDCODE;
                //    testList1[i].UNIFIEDCODE = tbl_hazardbasicinfobll.GetMaxCode(testList1[i].COUNTYCODE);// testList1[i].UNIFIEDCODE;
                //newa[i].UNIFIEDCODE = newa[i].CGHUNIFIEDCODE;
                //testList1[i].UNIFIEDCODE = testList1[i].CGHUNIFIEDCODE;
                //tbl_AVALANCHEbll.SaveForm(string.Empty, newa[i], testList1[i]);
                //if (testList1[i].ISXH == "1")
                //{
                //    TBL_XIAOHAOEntity entity = new TBL_XIAOHAOEntity();
                //    entity.UNIFIEDCODE = testList1[i].UNIFIEDCODE;
                //    int statusCode = 0;
                //    tbl_xiaohaobll.SaveForm(testList1[i].UNIFIEDCODE, entity, ref statusCode);
                //}

                // }
                //string sql2 = "select TA.*,TA.ISHEXIAO AS ISXH,TB.provincename,TB.cityname,TB.countyname,TB.townname from TBL_COLLAPSE TA INNER JOIN tbl_hazardbasicinfo TB ON TA.unifiedcode=TB.unifiedcode  AND TA.PROVINCE='340000' ";
                //DataTable s2 = DBhelper.ExecuteSelect(sql2);
                //List<NEWTBL_COLLAPSEEntity> testList2 = s2.ConvertToModel<NEWTBL_COLLAPSEEntity>();
                //List<TBL_COLLAPSEEntity> newa2 = s2.ConvertToModel<TBL_COLLAPSEEntity>();
                //for (int i = 0; i < testList2.Count; i++)
                //{
                //    tbl_collapsebll.SaveForm(string.Empty, newa2[i], testList2[i]);
                //    if (testList2[i].ISXH == "1")
                //    {
                //        TBL_XIAOHAOEntity entity = new TBL_XIAOHAOEntity();
                //        entity.UNIFIEDCODE = testList2[i].UNIFIEDCODE;
                //        int statusCode = 0;
                //        tbl_xiaohaobll.SaveForm(testList2[i].UNIFIEDCODE, entity, ref statusCode);
                //    }

                //}
                ////foreach (var item in testList2)
                ////{
                ////    tbl_collapsebll.SaveForm(string.Empty, item);
                ////}
                //string sql3 = "select TA.*,TA.ISHEXIAO AS ISXH,TB.provincename,TB.cityname,TB.countyname,TB.townname from TBL_LANDCRACK TA INNER JOIN tbl_hazardbasicinfo TB ON TA.unifiedcode=TB.unifiedcode  AND TA.PROVINCE='340000' ";
                //DataTable s3 = DBhelper.ExecuteSelect(sql3);
                //List<NEWTBL_LANDCRACKEntity> testList3 = s3.ConvertToModel<NEWTBL_LANDCRACKEntity>();
                //List<TBL_LANDCRACKEntity> newa3 = s3.ConvertToModel<TBL_LANDCRACKEntity>();
                //for (int i = 0; i < testList3.Count; i++)
                //{
                //    tbl_landcrackbll.SaveForm(string.Empty, newa3[i], testList3[i]);
                //    if (testList3[i].ISXH == "1")
                //    {
                //        TBL_XIAOHAOEntity entity = new TBL_XIAOHAOEntity();
                //        entity.UNIFIEDCODE = testList3[i].UNIFIEDCODE;
                //        int statusCode = 0;
                //        tbl_xiaohaobll.SaveForm(testList3[i].UNIFIEDCODE, entity, ref statusCode);
                //    }
                //}
                ////foreach (var item in testList3)
                ////{
                ////    tbl_landcrackbll.SaveForm(string.Empty, item);
                ////}
                //string sql4 = "select TA.*,TA.ISHEXIAO AS ISXH,TB.provincename,TB.cityname,TB.countyname,TB.townname from TBL_LANDSETTLEMENT TA INNER JOIN tbl_hazardbasicinfo TB ON TA.unifiedcode=TB.unifiedcode  AND TA.PROVINCE='340000' ";
                //DataTable s4 = DBhelper.ExecuteSelect(sql4);
                //List<NEWTBL_LANDSETTLEMENTEntity> testList4 = s4.ConvertToModel<NEWTBL_LANDSETTLEMENTEntity>();
                //List<TBL_LANDSETTLEMENTEntity> newa4 = s4.ConvertToModel<TBL_LANDSETTLEMENTEntity>();

                //for (int i = 0; i < testList4.Count; i++)
                //{
                //    tbl_landsettlementbll.SaveForm(string.Empty, newa4[i], testList4[i]);
                //    if (testList4[i].ISXH == "1")
                //    {
                //        TBL_XIAOHAOEntity entity = new TBL_XIAOHAOEntity();
                //        entity.UNIFIEDCODE = testList4[i].UNIFIEDCODE;
                //        int statusCode = 0;
                //        tbl_xiaohaobll.SaveForm(testList4[i].UNIFIEDCODE, entity, ref statusCode);
                //    }
                //}
                ////foreach (var item in testList4)
                ////{
                ////    tbl_landsettlementbll.SaveForm(string.Empty, item);
                ////}
                //string sql5 = "select TA.*,TA.ISHEXIAO AS ISXH,TB.provincename,TB.cityname,TB.countyname,TB.townname from TBL_LANDSLIP TA INNER JOIN tbl_hazardbasicinfo TB ON TA.unifiedcode=TB.unifiedcode  AND TA.PROVINCE='340000' ";
                //DataTable s5 = DBhelper.ExecuteSelect(sql5);
                //List<TBL_LANDSLIPEntity> newa5 = s5.ConvertToModel<TBL_LANDSLIPEntity>();
                //List<NEWTBL_LANDSLIPEntity> testList5 = s5.ConvertToModel<NEWTBL_LANDSLIPEntity>();
                //for (int i = 0; i < testList5.Count; i++)
                //{
                //    tbl_landslipbll.SaveForm(string.Empty, newa5[i], testList5[i]);
                //    if (testList5[i].ISXH == "1")
                //    {
                //        TBL_XIAOHAOEntity entity = new TBL_XIAOHAOEntity();
                //        entity.UNIFIEDCODE = testList5[i].UNIFIEDCODE;
                //        int statusCode = 0;
                //        tbl_xiaohaobll.SaveForm(testList5[i].UNIFIEDCODE, entity, ref statusCode);
                //    }
                //}
                ////foreach (var item in testList5)
                ////{
                ////    tbl_landslipbll.SaveForm(string.Empty, item);
                ////}
                //string sql6 = "select TA.*,TA.ISHEXIAO AS ISXH,TB.provincename,TB.cityname,TB.countyname,TB.townname from TBL_DEBRISFLOW TA INNER JOIN tbl_hazardbasicinfo TB ON TA.unifiedcode=TB.unifiedcode  AND TA.PROVINCE='340000' ";
                //DataTable s6 = DBhelper.ExecuteSelect(sql6);
                //List<NEWTBL_DEBRISFLOWEntity> testList6 = s6.ConvertToModel<NEWTBL_DEBRISFLOWEntity>();
                //List<TBL_DEBRISFLOWEntity> newa6 = s6.ConvertToModel<TBL_DEBRISFLOWEntity>();
                //for (int i = 0; i < testList6.Count; i++)
                //{
                //    newa6[i].UNIFIEDCODE = newa6[i].CGHUNIFIEDCODE;
                //    testList6[i].UNIFIEDCODE = testList6[i].CGHUNIFIEDCODE;
                //    tbl_debrisflowbll.SaveForm(string.Empty, newa6[i], testList6[i]);
                //    if (testList6[i].ISXH == "1")
                //    {
                //        TBL_XIAOHAOEntity entity = new TBL_XIAOHAOEntity();
                //        entity.UNIFIEDCODE = testList6[i].UNIFIEDCODE;
                //        int statusCode = 0;
                //        tbl_xiaohaobll.SaveForm(testList6[i].UNIFIEDCODE, entity, ref statusCode);
                //    }
                //}
                //foreach (var item in testList6)
                //{
                //    tbl_debrisflowbll.SaveForm(string.Empty, item);
                //}
                //string sql7 = "select TA.*,TA.ISHEXIAO AS ISXH,TB.provincename,TB.cityname,TB.countyname,TB.townname from TBL_SLOPE TA INNER JOIN tbl_hazardbasicinfo TB ON TA.unifiedcode=TB.unifiedcode  AND TA.PROVINCE='340000' ";
                //DataTable s7 = DBhelper.ExecuteSelect(sql7);
                //List<NEWTBL_SLOPEEntity> testList7 = s7.ConvertToModel<NEWTBL_SLOPEEntity>();
                //List<TBL_SLOPEEntity> newa7 = s7.ConvertToModel<TBL_SLOPEEntity>();
                //for (int i = 0; i < testList7.Count; i++)
                //{
                //    tbl_slopebll.SaveForm(string.Empty, newa7[i], testList7[i]);
                //    if (testList7[i].ISXH == "1")
                //    {
                //        TBL_XIAOHAOEntity entity = new TBL_XIAOHAOEntity();
                //        entity.UNIFIEDCODE = testList7[i].UNIFIEDCODE;
                //        int statusCode = 0;
                //        tbl_xiaohaobll.SaveForm(testList7[i].UNIFIEDCODE, entity, ref statusCode);
                //    }
                //}
                //foreach (var item in testList7)
                //{
                //    tbl_slopebll.SaveForm(string.Empty, item);
                //}
                return "OK";
        }
    }


}
