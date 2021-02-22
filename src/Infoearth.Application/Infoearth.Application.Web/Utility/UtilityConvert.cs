using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infoearth.Application.Web.Utility
{
    public static class UtilityConvert
    {
        public static decimal? ConvertDecimal(string value)
        {
            string text = value.Trim();
            if (text == null || text.Equals(""))
            {
                return new decimal?(0m);
            }
            decimal value2 = 0m;
            decimal.TryParse(text, out value2);
            return new decimal?(value2);
        }

        public static decimal? ConvertDecimal(object obj)
        {
            if (obj == null || obj.ToString().Trim() == "")
            {
                return null;
            }
            double value = Convert.ToDouble(obj.ToString().Trim());
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ConvertDecimalOrNull(object obj)
        {
            if (obj == null || obj.ToString().Trim() == "")
            {
                return null;
            }
            decimal value = 0m;
            if (!decimal.TryParse(obj.ToString(), out value))
            {
                return null;
            }
            return new decimal?(value);
        }

        public static string ConvertObjectToString(object currentText)
        {
            if (currentText == null)
            {
                return null;
            }
            return currentText.ToString().Trim();
        }

        public static string ConvertStringToString(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Trim();
            }
            return string.Empty;
        }

        public static bool isInt(string value)
        {
            bool result;
            try
            {
                string text = value.Trim();
                if (text != null && !text.Equals(""))
                {
                    int.Parse(text);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static int ConverString2Int(string str)
        {
            int result = 0;
            int.TryParse(str, out result);
            return result;
        }

        public static double ConvertString2Double(string str)
        {
            double result = 0.0;
            double.TryParse(str, out result);
            return result;
        }

        public static float ConvertString2Float(string str)
        {
            float result = 0f;
            float.TryParse(str, out result);
            return result;
        }

        public static decimal ConvertString2Decimal(string str)
        {
            decimal result = 0.0m;
            decimal.TryParse(str, out result);
            return result;
        }

        public static string GetLsh(List<int> iExist)
        {
            object obj = 0;
            string result = string.Empty;
            iExist.Sort();
            obj = iExist[iExist.Count - 1];
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
            if (obj != null)
            {
                int num;
                if (int.TryParse(obj.ToString(), out num))
                {
                    if (num == 99)
                    {
                        foreach (int current in list)
                        {
                            if (!iExist.Contains(current))
                            {
                                num = current;
                                break;
                            }
                        }
                        result = string.Format("{0:00}", num);
                    }
                    else
                    {
                        num++;
                        result = string.Format("{0:00}", num);
                    }
                }
                else
                {
                    result = "";
                }
            }
            else
            {
                result = "";
            }
            return result;
        }

        public static string ConvertDecimalToString(decimal? obj)
        {
            if (obj.HasValue)
            {
                return obj.Value.ToString();
            }
            return string.Empty;
        }

        public static bool NameIsRight(string name)
        {
            return !name.Contains("·") && !name.Contains("~") && !name.Contains("！") && !name.Contains("@") && !name.Contains("#") && !name.Contains("￥") && !name.Contains("%") && !name.Contains("……") && !name.Contains("&") && !name.Contains("*") && !name.Contains("（") && !name.Contains("）") && !name.Contains("—") && !name.Contains("-") && !name.Contains("+") && !name.Contains("=") && !name.Contains("【") && !name.Contains("】") && !name.Contains("｛") && !name.Contains("｝") && !name.Contains("；") && !name.Contains("‘") && !name.Contains("’") && !name.Contains("、") && !name.Contains("|") && !name.Contains("“") && !name.Contains("”") && !name.Contains("：") && !name.Contains("、") && !name.Contains("？") && !name.Contains("，") && !name.Contains("。") && !name.Contains("《") && !name.Contains("》") && !name.Contains("¥") && !name.Contains("/") && !name.Contains(".") && !name.Contains("?") && !name.Contains(">") && !name.Contains(".") && !name.Contains("<") && !name.Contains(",") && !name.Contains("\\") && !name.Contains("'") && !name.Contains("'") && !name.Contains("\"") && !name.Contains(";") && !name.Contains(":") && !name.Contains("|") && !name.Contains("]") && !name.Contains("[") && !name.Contains("}") && !name.Contains("{") && !name.Contains("(") && !name.Contains(")") && !name.Contains("~") && !name.Contains("`") && !name.Contains("!") && !name.Contains("@") && !name.Contains("#") && !name.Contains("$") && !name.Contains("%") && !name.Contains("^") && !name.Contains("&") && !name.Contains(" ") && !(name == "") && !name.Contains(";") && !name.Contains("；");
        }

        public static string GetCode(string UnifiedCode, int index)
        {
            string result = "";
            if ("" != UnifiedCode.Trim() && UnifiedCode.Length > 5)
            {
                switch (index)
                {
                    case 1:
                        result = UnifiedCode.Substring(0, 2) + "0000";
                        break;
                    case 2:
                        result = UnifiedCode.Substring(0, 6);
                        break;
                    case 3:
                        result = UnifiedCode.Substring(0, 9);
                        break;
                }
            }
            return result;
        }

        public static string CoordinateConvert(string oCoordinate)
        {
            string str = "";
            double num = double.Parse(oCoordinate);
            double num2 = Math.Truncate(num);
            str = str + Convert.ToInt32(num2).ToString() + "°";
            double num3 = num - num2;
            num3 *= 60.0;
            num2 = Math.Truncate(num3);
            num3 -= num2;
            str = str + Convert.ToInt32(num2).ToString() + "'";
            return str + Math.Round(num3 * 60.0, 3).ToString() + "\"";
        }

        public static decimal? StringToDecimal(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            decimal value;
            if (!decimal.TryParse(str, out value))
            {
                return null;
            }
            return new decimal?(value);
        }

        public static int? StringToInt(string str)
        {
            if (str.Contains("."))
            {
                str = str.Substring(0, str.IndexOf('.'));
            }
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            int value;
            if (!int.TryParse(str, out value))
            {
                return null;
            }
            return new int?(value);
        }

        public static double ConvertDecimalOrNullToDouble(object value)
        {
            double result = 0.0;
            if (value == null)
            {
                return result;
            }
            double.TryParse(value.ToString(), out result);
            return result;
        }
    }
}