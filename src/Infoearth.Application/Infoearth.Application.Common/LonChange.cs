using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Common
{
    public class LonChange
    {
        private string lonNew = "";
        private string latNew = "";
        private string xNew = "";
        private string yNew = "";
        /// </summary>
        /// <param name="csStr">北京54坐标系</param>
        /// <param name="numberNameStr">三度分带</param>
        /// <returns></returns>
        public object btnBLtoXY_Click(string _lat, string _lon, string csStr, string numberNameStr)
        {
            #region BLtoXY

            object fromCSType = null;
            object toCSType = null;

            if (_lon == string.Empty || _lat == string.Empty)
            {
                return null;
            }
            double b = double.Parse(_lon);
            double l = double.Parse(_lat);

            if (csStr != null && numberNameStr != null)
            {
                if (b == -1 || l == -1)
                {

                    // MessageBox.Show("BL坐标不符合规范,请重新填写！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);return;
                    // var result = "BL坐标不符合规范,请重新填写！";
                    return null;

                }

                if (csStr == "北京54坐标系")
                {
                    fromCSType = CSType.GCS_Beijing_1954;
                    if (numberNameStr == "3度分带")
                    {
                        if (double.Parse(_lon.Trim().Substring(0, 3)) < 73.5 ||
                            double.Parse(_lon.Trim().Substring(0, 3)) > 136.5)
                        {
                            //MessageBox.Show("请确保经度在73.5与136.5之间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return null;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 73.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 76.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_25;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 76.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 79.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_26;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 79.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 82.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_27;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 82.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 85.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_28;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 85.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 88.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_29;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 88.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 91.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_30;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 91.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 94.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_31;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 94.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 97.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_32;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 97.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 100.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_33;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >=
                                 100.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <
                                 103.5)
                        {
                            toCSType = CSType.Beijing_1954_3_Degree_GK_Zone_34;
                        }
                        else if (
                            double.Parse(_lon.Trim().Substring(0, 3)) >=
                            103.5 &&
                            double.Parse(_lon.Trim().Substring(0, 3)) <
                            106.5)
                        {
                            toCSType =
                                CSType.Beijing_1954_3_Degree_GK_Zone_35;
                        }
                        else if (
                            double.Parse(_lon.Trim()
                                             .Substring(0, 3)) >= 106.5 &&
                            double.Parse(_lon.Trim()
                                             .Substring(0, 3)) < 109.5)
                        {
                            toCSType =
                                CSType.Beijing_1954_3_Degree_GK_Zone_36;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) >=
                            109.5 &&
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) <
                            112.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_37;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) >=
                            112.5 &&
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) <
                            115.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_38;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) >=
                            115.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) <
                            118.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_39;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) >=
                            118.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) <
                            121.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_40;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) >=
                            121.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) <
                            124.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_41;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(
                                        0, 3)) >=
                            124.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(
                                        0, 3)) <
                            127.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_42;
                        }
                        else if (
                            double.Parse(
                                _lon
                                    .Trim()
                                    .Substring
                                    (0, 3)) >=
                            127.5 &&
                            double.Parse(
                                _lon
                                    .Trim()
                                    .Substring
                                    (0, 3)) <
                            130.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_43;
                        }
                        else if (
                            double.Parse
                                (_lon

                                     .Trim
                                     ()
                                     .Substring
                                     (0,
                                      3)) >=
                            130.5 &&
                            double.Parse
                                (_lon

                                     .Trim
                                     ()
                                     .Substring
                                     (0,
                                      3)) <
                            133.5)
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_44;
                        }
                        else
                        {
                            toCSType =
                                CSType
                                    .Beijing_1954_3_Degree_GK_Zone_45;
                        }
                    }
                    else if (numberNameStr == "6度分带")
                    {
                        if (double.Parse(_lon.Trim().Substring(0, 3)) < 72 ||
                            double.Parse(_lon.Trim().Substring(0, 3)) > 138)
                        {
                            //MessageBox.Show("请确保经度在72与138之间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return null;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 72 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 78)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_13;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 78 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 84)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_14;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 84 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 90)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_15;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 90 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 96)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_16;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 96 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 102)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_17;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 102 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 108)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_18;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 108 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 114)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_19;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 114 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 120)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_20;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 120 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <= 126)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_21;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >=
                                 126 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <=
                                 132)
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_22;
                        }
                        else
                        {
                            toCSType = CSType.Beijing_1954_GK_Zone_23;
                        }
                    }
                }
                else if (csStr == "西安80坐标系")
                {
                    fromCSType = CSType.GCS_Xian_1980;
                    if (numberNameStr == "3度分带")
                    {
                        if (double.Parse(_lon.Trim().Substring(0, 3)) < 73.5 ||
                            double.Parse(_lon.Trim().Substring(0, 3)) > 136.5)
                        {
                            // MessageBox.Show("请确保经度在73.5与136.5之间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return null;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 73.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 76.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_25;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 76.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 79.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_26;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 79.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 82.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_27;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 82.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 85.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_28;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 85.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 88.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_29;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 88.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 91.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_30;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 91.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 94.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_31;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 94.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 97.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_32;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 97.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 100.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_33;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >=
                                 100.5 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) <
                                 103.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_34;
                        }
                        else if (
                            double.Parse(_lon.Trim().Substring(0, 3)) >=
                            103.5 &&
                            double.Parse(_lon.Trim().Substring(0, 3)) <
                            106.5)
                        {
                            toCSType = CSType.Xian_1980_3_Degree_GK_Zone_35;
                        }
                        else if (
                            double.Parse(_lon.Trim()
                                             .Substring(0, 3)) >= 106.5 &&
                            double.Parse(_lon.Trim()
                                             .Substring(0, 3)) < 109.5)
                        {
                            toCSType =
                                CSType.Xian_1980_3_Degree_GK_Zone_36;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) >=
                            109.5 &&
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) <
                            112.5)
                        {
                            toCSType =
                                CSType.Xian_1980_3_Degree_GK_Zone_37;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) >=
                            112.5 &&
                            double.Parse(
                                _lon.Trim().Substring(0, 3)) <
                            115.5)
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_38;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) >=
                            115.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) <
                            118.5)
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_39;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) >=
                            118.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) <
                            121.5)
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_40;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) >=
                            121.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(0, 3)) <
                            124.5)
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_41;
                        }
                        else if (
                            double.Parse(
                                _lon.Trim()
                                    .Substring(
                                        0, 3)) >=
                            124.5 &&
                            double.Parse(
                                _lon.Trim()
                                    .Substring(
                                        0, 3)) <
                            127.5)
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_42;
                        }
                        else if (
                            double.Parse(
                                _lon
                                    .Trim()
                                    .Substring
                                    (0, 3)) >=
                            127.5 &&
                            double.Parse(
                                _lon
                                    .Trim()
                                    .Substring
                                    (0, 3)) <
                            130.5)
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_43;
                        }
                        else if (
                            double.Parse
                                (_lon

                                     .Trim
                                     ()
                                     .Substring
                                     (0,
                                      3)) >=
                            130.5 &&
                            double.Parse
                                (_lon

                                     .Trim
                                     ()
                                     .Substring
                                     (0,
                                      3)) <
                            133.5)
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_44;
                        }
                        else
                        {
                            toCSType =
                                CSType
                                    .Xian_1980_3_Degree_GK_Zone_45;
                        }
                    }
                    else if (numberNameStr == "6度分带")
                    {
                        if (double.Parse(_lon.Trim().Substring(0, 3)) < 72 ||
                            double.Parse(_lon.Trim().Substring(0, 3)) > 138)
                        {
                            //MessageBox.Show("请确保经度在72与138之间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            return null;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 72 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 78)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_13;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 78 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 84)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_14;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 84 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 90)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_15;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 90 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 96)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_16;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 96 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 102)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_17;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 102 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 108)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_18;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 108 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 114)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_19;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 114 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 120)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_20;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >= 120 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 126)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_21;
                        }
                        else if (double.Parse(_lon.Trim().Substring(0, 3)) >=
                                 126 &&
                                 double.Parse(_lon.Trim().Substring(0, 3)) < 132)
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_22;
                        }
                        else
                        {
                            toCSType = CSType.Xian_1980_GK_Zone_23;
                        }
                    }
                }

                var point = new double[2];

                if (fromCSType != null && toCSType != null)
                {
                    point = CSWKTUtility.TransForm(l, b, (CSType)fromCSType, (CSType)toCSType);
                    if (point != null)
                    {
                        xNew = point[1].ToString("#0.00");
                        yNew = point[0].ToString("#0.00");
                    }
                }
                var jsonData = new
                {
                    x = xNew,
                    y = yNew
                };
                return jsonData;
            }
            else
            {
                //MessageBox.Show("请填写坐标相关信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return null;
            }

            #endregion
        }

        public object btnXYtoBL_Click(string _x, string _y, string csStr, string numberNameStr)
        {


            #region  XYtoBL

            //string csStr = cmbCoordinateSystem;
            //string numberNameStr = "";
            object fromCSType = null;
            object toCSType = null;

            double x = CSWKTUtility.GetValue(_x);
            double y = CSWKTUtility.GetValue(_y);

            if (csStr != "" && numberNameStr != "")
            {
                if (x == -1 || y == -1)
                {
                    //MessageBox.Show("存在不是数字类型XY坐标，请重新填写！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return null;
                }
                else if (_y.Length < 2)
                {
                    //MessageBox.Show("y坐标输入格式不正确，请重新填写！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return null;
                }
                if (csStr == "北京54坐标系")
                {
                    toCSType = CSType.GCS_Beijing_1954;
                    if (numberNameStr == "3度分带")
                    {
                        if (_y.Substring(0, 2) != "25" && _y.Substring(0, 2) != "26" &&
                            _y.Substring(0, 2) != "27" && _y.Substring(0, 2) != "28" &&
                            _y.Substring(0, 2) != "29" && _y.Substring(0, 2) != "30" &&
                            _y.Substring(0, 2) != "31" && _y.Substring(0, 2) != "32" &&
                            _y.Substring(0, 2) != "33" && _y.Substring(0, 2) != "34" &&
                            _y.Substring(0, 2) != "35" && _y.Substring(0, 2) != "36" &&
                            _y.Substring(0, 2) != "37" && _y.Substring(0, 2) != "38" &&
                            _y.Substring(0, 2) != "39" && _y.Substring(0, 2) != "40" &&
                            _y.Substring(0, 2) != "41" && _y.Substring(0, 2) != "42" &&
                            _y.Substring(0, 2) != "43" && _y.Substring(0, 2) != "44" &&
                            _y.Substring(0, 2) != "45")
                        {
                            //MessageBox.Show("y坐标前两位数应为25—45之间，请重新填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else if (_y.Substring(0, 2) == "25")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_25;
                        }
                        else if (_y.Substring(0, 2) == "26")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_26;
                        }
                        else if (_y.Substring(0, 2) == "27")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_27;
                        }
                        else if (_y.Substring(0, 2) == "28")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_28;
                        }
                        else if (_y.Substring(0, 2) == "29")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_29;
                        }
                        else if (_y.Substring(0, 2) == "30")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_30;
                        }
                        else if (_y.Substring(0, 2) == "31")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_31;
                        }
                        else if (_y.Substring(0, 2) == "32")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_32;
                        }
                        else if (_y.Substring(0, 2) == "33")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_33;
                        }
                        else if (_y.Substring(0, 2) == "34")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_34;
                        }
                        else if (_y.Substring(0, 2) == "35")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_35;
                        }
                        else if (_y.Substring(0, 2) == "36")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_36;
                        }
                        else if (_y.Substring(0, 2) == "37")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_37;
                        }
                        else if (_y.Substring(0, 2) == "38")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_38;
                        }
                        else if (_y.Substring(0, 2) == "39")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_39;
                        }
                        else if (_y.Substring(0, 2) == "40")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_40;
                        }
                        else if (_y.Substring(0, 2) == "41")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_41;
                        }
                        else if (_y.Substring(0, 2) == "42")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_42;
                        }
                        else if (_y.Substring(0, 2) == "43")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_43;
                        }
                        else if (_y.Substring(0, 2) == "44")
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_44;
                        }
                        else
                        {
                            fromCSType = CSType.Beijing_1954_3_Degree_GK_Zone_45;
                        }
                    }
                    else if (numberNameStr == "6度分带")
                    {
                        if (_y.Substring(0, 2) != "13" && _y.Substring(0, 2) != "14" &&
                            _y.Substring(0, 2) != "15" && _y.Substring(0, 2) != "16" &&
                            _y.Substring(0, 2) != "17" && _y.Substring(0, 2) != "18" &&
                            _y.Substring(0, 2) != "19" && _y.Substring(0, 2) != "20" &&
                            _y.Substring(0, 2) != "21" && _y.Substring(0, 2) != "22" &&
                            _y.Substring(0, 2) != "23")
                        {
                            // MessageBox.Show("y坐标前两位数应为13—23之间，请重新填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else if (_y.Substring(0, 2) == "13")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_13;
                        }
                        else if (_y.Substring(0, 2) == "14")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_14;
                        }
                        else if (_y.Substring(0, 2) == "15")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_15;
                        }
                        else if (_y.Substring(0, 2) == "16")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_16;
                        }

                        else if (_y.Substring(0, 2) == "17")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_17;
                        }

                        else if (_y.Substring(0, 2) == "18")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_18;
                        }
                        else if (_y.Substring(0, 2) == "19")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_19;
                        }
                        else if (_y.Substring(0, 2) == "20")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_20;
                        }
                        else if (_y.Substring(0, 2) == "21")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_21;
                        }
                        else if (_y.Substring(0, 2) == "22")
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_22;
                        }

                        else
                        {
                            fromCSType = CSType.Beijing_1954_GK_Zone_23;
                        }
                    }
                }
                else if (csStr == "西安80坐标系")
                {
                    toCSType = CSType.GCS_Xian_1980;
                    if (numberNameStr == "3度分带")
                    {
                        if (_y.Substring(0, 2) != "25" && _y.Substring(0, 2) != "26" &&
                            _y.Substring(0, 2) != "27" && _y.Substring(0, 2) != "28" &&
                            _y.Substring(0, 2) != "29" && _y.Substring(0, 2) != "30" &&
                            _y.Substring(0, 2) != "31" && _y.Substring(0, 2) != "32" &&
                            _y.Substring(0, 2) != "33" && _y.Substring(0, 2) != "34" &&
                            _y.Substring(0, 2) != "35" && _y.Substring(0, 2) != "36" &&
                            _y.Substring(0, 2) != "37" && _y.Substring(0, 2) != "38" &&
                            _y.Substring(0, 2) != "39" && _y.Substring(0, 2) != "40" &&
                            _y.Substring(0, 2) != "41" && _y.Substring(0, 2) != "42" &&
                            _y.Substring(0, 2) != "43" && _y.Substring(0, 2) != "44" &&
                            _y.Substring(0, 2) != "45")
                        {
                            //MessageBox.Show("y坐标前两位数应为25—45之间，请重新填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else if (_y.Substring(0, 2) == "25")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_25;
                        }
                        else if (_y.Substring(0, 2) == "26")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_26;
                        }
                        else if (_y.Substring(0, 2) == "27")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_27;
                        }
                        else if (_y.Substring(0, 2) == "28")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_28;
                        }
                        else if (_y.Substring(0, 2) == "29")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_29;
                        }
                        else if (_y.Substring(0, 2) == "30")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_30;
                        }
                        else if (_y.Substring(0, 2) == "31")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_31;
                        }
                        else if (_y.Substring(0, 2) == "32")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_32;
                        }

                        else if (_y.Substring(0, 2) == "33")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_33;
                        }
                        else if (_y.Substring(0, 2) == "34")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_34;
                        }
                        else if (_y.Substring(0, 2) == "35")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_35;
                        }
                        else if (_y.Substring(0, 2) == "36")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_36;
                        }
                        else if (_y.Substring(0, 2) == "37")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_37;
                        }
                        else if (_y.Substring(0, 2) == "38")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_38;
                        }
                        else if (_y.Substring(0, 2) == "39")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_39;
                        }
                        else if (_y.Substring(0, 2) == "40")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_40;
                        }
                        else if (_y.Substring(0, 2) == "41")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_41;
                        }
                        else if (_y.Substring(0, 2) == "42")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_42;
                        }
                        else if (_y.Substring(0, 2) == "43")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_43;
                        }
                        else if (_y.Substring(0, 2) == "44")
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_44;
                        }
                        else
                        {
                            fromCSType = CSType.Xian_1980_3_Degree_GK_Zone_45;
                        }
                    }
                    else if (numberNameStr == "6度分带")
                    {
                        if (_y.Substring(0, 2) != "13" && _y.Substring(0, 2) != "14" &&
                            _y.Substring(0, 2) != "15" && _y.Substring(0, 2) != "16" &&
                            _y.Substring(0, 2) != "17" && _y.Substring(0, 2) != "18" &&
                            _y.Substring(0, 2) != "19" && _y.Substring(0, 2) != "20" &&
                            _y.Substring(0, 2) != "21" && _y.Substring(0, 2) != "22" &&
                            _y.Substring(0, 2) != "23")
                        {
                            //MessageBox.Show("y坐标前两位数应为13—23之间，请重新填写", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else if (_y.Substring(0, 2) == "13")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_13;
                        }
                        else if (_y.Substring(0, 2) == "14")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_14;
                        }
                        else if (_y.Substring(0, 2) == "15")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_15;
                        }
                        else if (_y.Substring(0, 2) == "16")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_16;
                        }

                        else if (_y.Substring(0, 2) == "17")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_17;
                        }
                        else if (_y.Substring(0, 2) == "18")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_18;
                        }
                        else if (_y.Substring(0, 2) == "19")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_19;
                        }
                        else if (_y.Substring(0, 2) == "20")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_20;
                        }
                        else if (_y.Substring(0, 2) == "21")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_21;
                        }
                        else if (_y.Substring(0, 2) == "22")
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_22;
                        }
                        else
                        {
                            fromCSType = CSType.Xian_1980_GK_Zone_23;
                        }
                    }
                }

                var point = new double[2];
                if (fromCSType != null && toCSType != null)
                {
                    point = CSWKTUtility.TransForm(x, y, (CSType)fromCSType, (CSType)toCSType);
                    if (point != null)
                    {
                        lonNew = point[0].ToString("#.00000000");
                        latNew = point[1].ToString("#.00000000");
                    }

                }
                var jsonData = new
                {
                    lon = lonNew,
                    lat = latNew
                };
                return jsonData;
            }
            else
            {
                //MessageBox.Show("请填写坐标相关信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return null;
            }

            #endregion
        }
    }
}
