using iTelluro.DataTools.Utility.GIS;
using iTelluro.Explorer.GisHelper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Common
{
    public class SpatialQueryHelper
    {
        /// <summary>
        /// 多边形是否相交(缓冲区)
        /// </summary>
        /// <param name="sourcewkt"></param>
        /// <param name="destwkt"></param>
        /// <returns></returns>    
        public static bool IsIntersects(string polyline, double radius, string longitude, string latitude)
        {
            try
            {
                //缓冲5000m
                //OSGeo.OGR.Geometry geo = GisAnalysisHelper.Buffer(polyline, radius);
                //string wkt = string.Empty;
                ////缓冲区WKT
                //geo.ExportToWkt(out wkt);
                //if (geo.ExportToWkt(out wkt)>0)
                //{
                //    result = true;
                //}
                //return result;

                bool bol = false;
                if (radius > 0)
                {
                    GEOSGeometry lineString = GEOSBuffer.FromWKT(polyline);
                    GEOSGeometry buffer = GEOSBuffer.CreateBuffer(lineString, GEOSBuffer.WGS84_Meter2Degree(radius));
                    string bufferWkt = GEOSBuffer.ToWKT(buffer);
                    if (!string.IsNullOrWhiteSpace(bufferWkt))
                    {

                        //bol = isContainPoint(bufferWkt, longitude, latitude);  
                        if (string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
                            return bol;
                        string pointWkt = "POINT(" + longitude + " " + latitude + ")";
                        iTelluroLib.GeoTools.IO.WKTReader wktreader = new iTelluroLib.GeoTools.IO.WKTReader();
                        iTelluroLib.GeoAPI.Geometries.IGeometry polygonGeometry = wktreader.Read(bufferWkt);
                        iTelluroLib.GeoAPI.Geometries.IGeometry pointGeometry = wktreader.Read(pointWkt);
                        if (polygonGeometry.Contains(pointGeometry))
                            bol = true;
                    }
                }
                return bol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 多边形是否相交
        /// </summary>
        /// <param name="sourcewkt"></param>
        /// <param name="destwkt"></param>
        /// <returns></returns>
        public static bool IsIntersect(string sourcewkt, string destwkt)
        {
            try
            {
                bool result = false;
                iTelluroLib.GeoTools.Geometries.Polygon sourcePolygon = null;
                iTelluroLib.GeoTools.Geometries.Polygon destPolygon = null;
                iTelluroLib.GeoTools.IO.WKTReader wktreader = new iTelluroLib.GeoTools.IO.WKTReader();

                iTelluroLib.GeoAPI.Geometries.IGeometry geometry = wktreader.Read(sourcewkt);
                Type t = geometry.GetType();
                if (t.Name == "Polygon")
                {
                    iTelluroLib.GeoTools.Geometries.Polygon pol = geometry as iTelluroLib.GeoTools.Geometries.Polygon;
                    sourcePolygon = pol;
                }
                geometry = wktreader.Read(destwkt);
                t = geometry.GetType();
                if (t.Name == "Polygon")
                {
                    iTelluroLib.GeoTools.Geometries.Polygon pol = geometry as iTelluroLib.GeoTools.Geometries.Polygon;
                    destPolygon = pol;
                }
                if (sourcePolygon.Intersects(destPolygon) || sourcePolygon.Contains(destPolygon))
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 多边形是否相交
        /// </summary>
        /// <param name="sourcewkt"></param>
        /// <param name="destwkt"></param>
        /// <returns></returns>
        public static bool IsIntersect(string sourcewkt, string destwkt, ref string intersectWkt)
        {
            try
            {
                bool result = false;

                iTelluroLib.GeoTools.IO.WKTReader wktreader = new iTelluroLib.GeoTools.IO.WKTReader();

                iTelluroLib.GeoAPI.Geometries.IGeometry sourceGeometry = wktreader.Read(sourcewkt);

                iTelluroLib.GeoAPI.Geometries.IGeometry destGeometry = wktreader.Read(destwkt);

                if (sourceGeometry.Intersects(destGeometry) || sourceGeometry.Contains(destGeometry))
                {
                    intersectWkt = sourceGeometry.Intersection(destGeometry).AsText();
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 多边形是否相交
        /// </summary>
        /// <param name="sourcewkt"></param>
        /// <param name="destwkt"></param>
        /// <returns></returns>
        public static bool IsIntersect(string sourcewkt, decimal east, decimal west, decimal north, decimal south)
        {
            try
            {
                bool result = false;
                iTelluroLib.GeoTools.Geometries.Polygon sourcePolygon = null;
                iTelluroLib.GeoTools.Geometries.Polygon destPolygon = null;
                iTelluroLib.GeoTools.IO.WKTReader wktreader = new iTelluroLib.GeoTools.IO.WKTReader();

                iTelluroLib.GeoAPI.Geometries.IGeometry geometry = wktreader.Read(sourcewkt);
                Type t = geometry.GetType();
                if (t.Name == "Polygon")
                {
                    iTelluroLib.GeoTools.Geometries.Polygon pol = geometry as iTelluroLib.GeoTools.Geometries.Polygon;
                    sourcePolygon = pol;
                }
                double maxLon = decimal.ToDouble(east);
                double minLon = decimal.ToDouble(west);
                double maxLat = decimal.ToDouble(north);
                double minLat = decimal.ToDouble(south);
                iTelluroLib.GeoTools.Geometries.Coordinate[] coords = new iTelluroLib.GeoTools.Geometries.Coordinate[5];
                coords[0] = new iTelluroLib.GeoTools.Geometries.Coordinate(minLon, maxLat);
                coords[1] = new iTelluroLib.GeoTools.Geometries.Coordinate(maxLon, maxLat);
                coords[2] = new iTelluroLib.GeoTools.Geometries.Coordinate(maxLon, minLat);
                coords[3] = new iTelluroLib.GeoTools.Geometries.Coordinate(minLon, minLat);
                coords[4] = new iTelluroLib.GeoTools.Geometries.Coordinate(minLon, maxLat);
                iTelluroLib.GeoTools.Geometries.LinearRing rectGeoTools = new iTelluroLib.GeoTools.Geometries.LinearRing(coords);
                destPolygon = new iTelluroLib.GeoTools.Geometries.Polygon(rectGeoTools);
                if (sourcePolygon.Intersects(destPolygon) || sourcePolygon.Contains(destPolygon))
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 多边形是否包含点
        /// </summary>
        /// <param name="polygonWkt"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public static bool isContainPoint(string polygonWkt, string longitude, string latitude)
        {
             try
            {
            bool bol = false;
            if (string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
                return bol;
            string pointWkt = "POINT(" + longitude + " " + latitude + ")";
            iTelluroLib.GeoTools.IO.WKTReader wktreader = new iTelluroLib.GeoTools.IO.WKTReader();
            iTelluroLib.GeoAPI.Geometries.IGeometry polygonGeometry = wktreader.Read(polygonWkt);
            iTelluroLib.GeoAPI.Geometries.IGeometry pointGeometry = wktreader.Read(pointWkt);
            if (polygonGeometry.Contains(pointGeometry))
                bol = true;
            return bol;
            }
             catch (Exception ex)
             {
                 return false;
             }
        }

        public static string GetWKTByJW(decimal east, decimal west, decimal north, decimal south)
        {
            double maxLon = decimal.ToDouble(east);
            double minLon = decimal.ToDouble(west);
            double maxLat = decimal.ToDouble(north);
            double minLat = decimal.ToDouble(south);
            iTelluroLib.GeoTools.Geometries.Coordinate[] coords = new iTelluroLib.GeoTools.Geometries.Coordinate[5];
            coords[0] = new iTelluroLib.GeoTools.Geometries.Coordinate(minLon, maxLat);
            coords[1] = new iTelluroLib.GeoTools.Geometries.Coordinate(maxLon, maxLat);
            coords[2] = new iTelluroLib.GeoTools.Geometries.Coordinate(maxLon, minLat);
            coords[3] = new iTelluroLib.GeoTools.Geometries.Coordinate(minLon, minLat);
            coords[4] = new iTelluroLib.GeoTools.Geometries.Coordinate(minLon, maxLat);
            iTelluroLib.GeoTools.Geometries.LinearRing rectGeoTools = new iTelluroLib.GeoTools.Geometries.LinearRing(coords);
            iTelluroLib.GeoTools.Geometries.Polygon destPolygon = new iTelluroLib.GeoTools.Geometries.Polygon(rectGeoTools);
            return destPolygon.AsText();
        }

        /// <summary>
        ///     判断点是否在圆内部
        /// </summary>
        public static bool PointInCircle(double lat1, double lon1, double lat2, double lon2, double radius)
        {
            double x = Math.Pow(lon1 - lon2, 2);
            double y = Math.Pow(lat1 - lat2, 2);
            double result = Math.Pow(radius, 2) - (x + y);
            if (result >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double HaverSin(double theta)
        {
            var v = Math.Sin(theta / 2);
            return v * v;
        }


        static double EARTH_RADIUS = 6371.0;//km 地球半径 平均值，千米

        /// <summary>
        /// 给定的经度1，纬度1；经度2，纬度2. 计算2个经纬度之间的距离。
        /// </summary>
        /// <param name="lat1">纬度1</param>
        /// <param name="lon1">经度1</param>
        /// <param name="lat2">纬度2</param>
        /// <param name="lon2">经度2</param>
        /// <returns>距离（公里、千米）</returns>
        public static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            //用haversine公式计算球面两点间的距离。
            //经纬度转换成弧度
            lat1 = ConvertDegreesToRadians(lat1);
            lon1 = ConvertDegreesToRadians(lon1);
            lat2 = ConvertDegreesToRadians(lat2);
            lon2 = ConvertDegreesToRadians(lon2);

            //差值
            var vLon = Math.Abs(lon1 - lon2);
            var vLat = Math.Abs(lat1 - lat2);

            //h is the great circle distance in radians, great circle就是一个球体上的切面，它的圆心即是球心的一个周长最大的圆。
            var h = HaverSin(vLat) + Math.Cos(lat1) * Math.Cos(lat2) * HaverSin(vLon);

            var distance = 2 * EARTH_RADIUS * Math.Asin(Math.Sqrt(h));

            return distance;
        }

        /// <summary>
        /// 将角度换算为弧度。
        /// </summary>
        /// <param name="degrees">角度</param>
        /// <returns>弧度</returns>
        public static double ConvertDegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        public static double ConvertRadiansToDegrees(double radian)
        {
            return radian * 180.0 / Math.PI;
        }

    }
}

