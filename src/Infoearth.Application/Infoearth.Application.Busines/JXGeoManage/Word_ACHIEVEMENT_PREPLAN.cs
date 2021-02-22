using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Infoearth.Application.IService.JXGeoManage;
using Infoearth.Application.Service.JXGeoManage;
using iTelluro.FileImage.BusinessInfoProxy.BusinessInfoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Busines.JXGeoManage
{
    public class Word_ACHIEVEMENT_PREPLAN : WordBase
    {
        private TBL_ACHIEVEMENT_PREPLANIService _iTBL_ACHIEVEMENT_PREPLAN = new TBL_ACHIEVEMENT_PREPLANService();
        public Word_ACHIEVEMENT_PREPLAN()
        {
            //ISSO sso = AjaxHelper.Container.Current.Resolve<ISSO>();
            //sso.Token = token;
            //ICache cache = AjaxHelper.Container.Current.Resolve<ICache>();
            //sso.Cache = cache;
            //_iSlope = AjaxHelper.Container.Current.Resolve<ISlopeAppService>();
            _Addpictures = 0;
        }

        /// <summary>
        /// 填充Word模板
        /// </summary>
        /// <param name="unifiecode">编号</param>
        /// <param name="w">word模板对象</param>
        /// <param name="lstPic">图片</param>
        protected override int FillBookmark(string unifiecode, WordprocessingDocument w, BusinessFileDetailinfoDTO[] lstPic)
        {
            object oo = _iTBL_ACHIEVEMENT_PREPLAN.GetEntity(unifiecode);
            string[][] pictureTypeCode = new string[][] { new string[] { "ImageA", "0BD245C7-1DC4-454E-8816-9892804F9FDB" }, new string[] { "ImageB", "48693C7B-2BFC-4322-AF39-2239B156FDD3" } };
            int timeStart = Environment.TickCount;
            DownloadImage(lstPic, pictureTypeCode);
            while (true)
            {
                int timeEnd = Environment.TickCount;
                double resultTime = Math.Ceiling((timeEnd - timeStart) / (1000.0 * 60.0));
                if (resultTime > 1)
                {
                    return 0;
                }
                if (_Addpictures == _gdownload.Keys.Count)
                {
                    var bookmarks = w.MainDocumentPart.Document.Body.Descendants<BookmarkStart>();

                    foreach (BookmarkStart bm in bookmarks)
                    {
                        if (bm != null)
                        {
                            PropertyInfo p = oo.GetType().GetProperty(bm.Name.ToString().ToUpper());//获取模板书签里的值
                            string item = bm.Name;
                            string strTreatment = OpenxmlUtility.GetTreatmentByProperty(oo);// 获取对象的防治建议名称

                            #region 书签中有，数据库里没有的属性
                            if (p == null)
                            {
                                #region 按图片类型进行导出
                                if (item == "ImageA")
                                {
                                    FillImage(this._gdownload, w, "0BD245C7-1DC4-454E-8816-9892804F9FDB", bm);
                                }
                                else if (item == "ImageB")
                                {
                                    FillImage(this._gdownload, w, "48693C7B-2BFC-4322-AF39-2239B156FDD3", bm);
                                }
                                #endregion

                                else if (item == "PositionToRiver1" || item == "PositionToRiver2")
                                {
                                    OpenxmlUtility.AddTextToBody(bm, OpenxmlUtility.GetPositionToRiverName(item, oo));
                                }
                                else if (item == "群测群防")
                                {
                                    if (strTreatment.Contains(item.ToString()))
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, true);
                                    }
                                    else
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, false);
                                    }
                                }
                                else if (item == "专业监测")
                                {
                                    if (strTreatment.Contains(item.ToString()))
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, true);
                                    }
                                    else
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, false);
                                    }
                                }
                                else if (item == "搬迁避让")
                                {
                                    if (strTreatment.Contains(item.ToString()))
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, true);
                                    }
                                    else
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, false);
                                    }
                                }
                                else if (item == "工程治理")
                                {
                                    if (strTreatment.Contains(item.ToString()))
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, true);
                                    }
                                    else
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, false);
                                    }
                                }
                                else if (item == "应急排危除险")
                                {
                                    if (strTreatment.Contains(item.ToString()))
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, true);
                                    }
                                    else
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, false);
                                    }
                                }
                                else if (item == "立警示牌")
                                {
                                    if (strTreatment.Contains(item.ToString()))
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, true);
                                    }
                                    else
                                    {
                                        OpenxmlUtility.AddCheckBoxToBody(bm, item, false);
                                    }
                                }
                            }
                            #endregion

                            #region 书签中有与数据库一一对应的属性
                            else
                            {
                                #region 所有表格都有的属性(经纬度转化成度分秒形式，调查单位显示名称)
                                if (item == "Longitude" || item == "Latitude" || item == "SettlementCenterLongitude" || item == "SettlementCenterLatitude")//把经纬度由double类型转换成度分秒的形式
                                {
                                    OpenxmlUtility.AddTextToBody(bm, OpenxmlUtility.GetLonLat(p, oo));
                                }
                                #endregion
                                else if (item == "PreventionPlan" || item == "IsMeasuringPNT" || item == "IsSurveyPNT" || item == "IsRSPNT" || item == "HiddenDanger")
                                {
                                    OpenxmlUtility.AddTextToBody(bm, OpenxmlUtility.GetCheckBoxValue(p, oo));
                                }
                                else
                                {
                                    OpenxmlUtility.AddTextToBody(bm, p.GetValue(oo, null) == null ? "" : p.GetValue(oo, null).ToString());
                                }
                            }
                            #endregion
                        }
                    }
                    w.MainDocumentPart.Document.Save();
                    return 1;
                }
            }
        }

        protected void FillImage(Dictionary<BusinessFileDetailinfoDTO, string> images, WordprocessingDocument w, string type, BookmarkStart bm)
        {
            foreach (BusinessFileDetailinfoDTO item in images.Keys)
            {
                if (item.TYPECODE == type)
                {
                    string filename = item.FILEINFOGUID + item.ExtName;
                    string filepath = _tempFile + filename;
                    string text = item.FILENAME;
                    OpenxmlUtility.InsertImageToDoC(filepath, item.FILENAME, w, bm);
                }
            }
        }
    }
}