using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using DocumentFormat.OpenXml;
using System.Reflection;
using iTelluroLib.Ini.Config;
using iTelluro.Explorer.InfoUtility;

namespace Infoearth.Application.Busines.JXGeoManage
{
    public static class OpenxmlUtility
    {
        //添加图片       
        public static void InsertImageToDoC(string filepath, string picname, WordprocessingDocument wordDoc, BookmarkStart imagebm)
        {
            string text = picname;
            BookmarkStart bm = imagebm;
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
            using (var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read, 8, true))
            {
                imagePart.FeedData(stream);
            }
            var picture = new PIC.Picture(
               new PIC.NonVisualPictureProperties(
                   new PIC.NonVisualDrawingProperties { Id = (UInt32Value)0U, Name = "Picture 1" },
                   new PIC.NonVisualPictureDrawingProperties(
                       new A.PictureLocks { NoChangeAspect = true, NoChangeArrowheads = true })),
               new PIC.BlipFill(
                   new A.Blip { Embed = mainPart.GetIdOfPart(imagePart) },
                   new A.SourceRectangle(),
                   new A.Stretch(new A.FillRectangle())),
               new PIC.ShapeProperties(
                   new A.Transform2D(
                       new A.Offset { X = 0, Y = 0 },
                       new A.Extents { Cx = 990000L, Cy = 792000L }),
                       new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle },
                       new A.NoFill(),
                       new A.Outline(
                           new A.NoFill(),
                           new A.Miter { Limit = 800000 },
                           new A.HeadEnd(),
                           new A.TailEnd()
                        )) { BlackWhiteMode = A.BlackWhiteModeValues.Auto });
            picture.AddNamespaceDeclaration("pic", "http://schemas.openxmlformats.org/drawingml/2006/picture");

            Drawing drawing = new Drawing(
                 new DW.Inline(
                     new DW.Extent { Cx = 990000L, Cy = 792000L },//{Cx = 990000L, Cy = 792000L}(小图) { Cx = 2976245L, Cy = 2233930L }(大图)，这里是设置图片真正的大小
                     new DW.EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                     new DW.DocProperties { Id = (UInt32Value)1U, Name = "Picture 1" },
                     new DW.NonVisualGraphicFrameDrawingProperties(
                         new A.GraphicFrameLocks { NoChangeAspect = true }),
                     new A.Graphic(
                         new A.GraphicData(picture) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                    )
                 {
                     DistanceFromTop = (UInt32Value)0U,
                     DistanceFromBottom = (UInt32Value)0U,
                     DistanceFromLeft = (UInt32Value)0U,
                     DistanceFromRight = (UInt32Value)0U
                 });

            if (bm != null)
            {
                Run bookmarkText = bm.NextSibling<Run>();
                Text t = new Text(text);
                Paragraph pImage = new Paragraph();
                Paragraph pText = new Paragraph();
                if (bookmarkText == null)
                {
                    bookmarkText = new Run();
                    bm.InsertAfterSelf(bookmarkText);
                }
                pImage.AppendChild(drawing);
                pText.AppendChild(t);
                bookmarkText.AppendChild(pImage);
                bookmarkText.AppendChild(pText);
            }

        }

        //添加文本
        public static void AddTextToBody(BookmarkStart bm, string txt)
        {
            Run bookmarkRun = bm.NextSibling<Run>();

            if (bookmarkRun == null)
            {
                bookmarkRun = new Run(
                   new RunProperties(
                       new RunFonts() { Hint = FontTypeHintValues.EastAsia, Ascii = "宋体", HighAnsi = "宋体" },
                       new FontSize() { Val = "18" },
                       new FontSizeComplexScript() { Val = "18" }));
                bm.InsertAfterSelf(bookmarkRun);
            }

            var textVal = new Text(txt);
            bookmarkRun.Append(textVal);
        }

        //添加CheckBox
        public static void AddCheckBoxToBody(BookmarkStart bm, string text, bool isTrueOrFalse)
        {
            SimpleField sf = new SimpleField(
                new FormFieldData(
                    new CheckBox(
                        new Checked { Val = isTrueOrFalse },
                        new FrameSize { Val = "18" }
                        )
                    )
                ) { Instruction = "FORMCHECKBOX" };

            Run bookmarkRun = bm.NextSibling<Run>();
            Text t = new Text(text);

            if (bookmarkRun == null)
            {
                bookmarkRun = new Run(
                     new RunProperties(
                       new RunFonts() { Hint = FontTypeHintValues.EastAsia },
                       new FontSize() { Val = "18" },
                       new FontSizeComplexScript() { Val = "18" }));
                bm.InsertAfterSelf(bookmarkRun);
            }

            bookmarkRun.AppendChild(sf);
            bookmarkRun.AppendChild(t);
        }

        public static string GetUrl()
        {
            string url = string.Empty;
            IConfigSource pConfigSource = Utility.GetConfigFile();
            if (pConfigSource != null)
            {
                IConfig icApplication = pConfigSource.Configs["MultiMediaUrl"];
                if (icApplication != null)
                {
                    url = icApplication.GetString("url") + "page/download.ashx";
                }
            }
            return url;
        }

        /// <summary>
        /// 获取对象的某个属性值
        /// </summary>
        /// <param name="oo"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetTextByProperty(object oo, string item)
        {
            string text = string.Empty;
            PropertyInfo pContactDept = oo.GetType().GetProperty(item);
            if (pContactDept != null)
            {
                text = pContactDept.GetValue(oo, null) == null ? "" : pContactDept.GetValue(oo, null).ToString();
            }
            return text;
        }

        /// <summary>
        /// 获取对象的防治建议名称
        /// </summary>
        /// <param name="oo"></param>
        /// <returns></returns>
        public static string GetTreatmentByProperty(object oo)
        {
            string text = string.Empty;
            PropertyInfo pInfo = oo.GetType().GetProperty("TREATMENTSUGGESTIONCNAME");
            if (pInfo != null)
            {
                text = pInfo.GetValue(oo, null) == null ? "" : pInfo.GetValue(oo, null).ToString();
            }
            return text;
        }

        /// <summary>
        /// 获取checkBox的值
        /// </summary>
        /// <param name="p"></param>
        /// <param name="oo"></param>
        /// <returns></returns>
        public static string GetCheckBoxValue(PropertyInfo p, object oo)
        {
            string strResult = string.Empty;
            object hiddenDanger = p.GetValue(oo, null) == null ? "" : p.GetValue(oo, null);
            if (hiddenDanger.ToString() == "1")
            {
                strResult = "是";
            }
            else if (hiddenDanger.ToString() == "0")
            {
                strResult = "否";
            }
            return strResult;
        }

        /// <summary>
        /// 获取相对河流位置的中文名称
        /// </summary>
        /// <param name="item"></param>
        /// <param name="oo"></param>
        /// <returns></returns>
        public static string GetPositionToRiverName(string item, object oo)
        {
            string strResult = string.Empty;
            string name = string.Empty;
            PropertyInfo positionToRiver = oo.GetType().GetProperty("POSITIONTORIVERCNAME");
            if (positionToRiver != null)
            {
                name = GetTextByProperty(oo, "POSITIONTORIVERCNAME");
            }
            if (item.ToUpper() == "POSITIONTORIVER1")
            {
                if (name.Contains("左岸"))
                {
                    strResult = "左岸";
                }
                if (name.Contains("右岸"))
                {
                    strResult = "右岸";
                }
                if (name.Contains("凹岸"))
                {
                    strResult = "凹岸";
                }
                if (name.Contains("凸岸"))
                {
                    strResult = "凸岸";
                }
            }
            else if (item.ToUpper() == "POSITIONTORIVER2")
            {
                if (name.Contains("凹岸"))
                {
                    strResult = "凹岸";
                }
                if (name.Contains("凸岸"))
                {
                    strResult = "凸岸";
                }
                if (name.Contains("左岸"))
                {
                    strResult = "左岸";
                }
                if (name.Contains("右岸"))
                {
                    strResult = "右岸";
                }

            }
            return strResult;
        }

        /// <summary>
        /// 获取泥石流类型
        /// </summary>
        /// <param name="item"></param>
        /// <param name="oo"></param>
        /// <returns></returns>
        public static string GetDebrisFlowType(string item, object oo)
        {
            string strResult = string.Empty;
            string name = string.Empty;
            PropertyInfo debrisFlowType = oo.GetType().GetProperty("DebrisFlowType".ToUpper());
            if (debrisFlowType != null)
            {
                name = GetTextByProperty(oo, "DebrisFlowType".ToUpper());
            }
            if (item.ToUpper() == "DebrisFlowType1".ToUpper())
            {
                if (name.Contains("泥石流"))
                {
                    strResult = "泥石流";
                }
                if (name.Contains("水泥流"))
                {
                    strResult = "水泥流";
                }
                if (name.Contains("水石流"))
                {
                    strResult = "水石流";
                }
                if (name.Contains("泥流"))
                {
                    strResult = "泥流";
                }
                if (name.Contains("山坡流"))
                {
                    strResult = "山坡流";
                }
                if (name.Contains("沟谷流"))
                {
                    strResult = "沟谷流";
                }
            }
            else if (item.ToUpper() == "DebrisFlowType2".ToUpper())
            {
                if (name.Contains("泥石流"))
                {
                    strResult = "泥石流";
                }
                if (name.Contains("水泥流"))
                {
                    strResult = "水泥流";
                }
                if (name.Contains("水石流"))
                {
                    strResult = "水石流";
                }
                if (name.Contains("泥流"))
                {
                    strResult = "泥流";
                }
                if (name.Contains("山坡流"))
                {
                    strResult = "山坡流";
                }
                if (name.Contains("沟谷流"))
                {
                    strResult = "沟谷流";
                }
            }
            return strResult;
        }

        /// <summary>
        /// 获得经纬度属性，并把它转换成度分秒的形式
        /// </summary>
        /// <param name="p"></param>
        /// <param name="oo"></param>
        /// <returns></returns>
        public static string GetLonLat(PropertyInfo p, object oo)
        {
            object lonorlat = p.GetValue(oo, null) == null ? "" : p.GetValue(oo, null);
            if (lonorlat != null && lonorlat.ToString().Trim() != "")
            {
                return UtilityConvert.CoordinateConvert(lonorlat.ToString());
            }
            return string.Empty;
        }
    }
}
