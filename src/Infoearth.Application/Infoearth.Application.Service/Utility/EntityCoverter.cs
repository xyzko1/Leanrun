using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Service
{
    /// <summary>
    /// 实体转换类
    /// </summary>
    public class EntityCoverter
    {
        /// <summary>
        /// 将源实体转换到空的实体类中
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T2 Covert<T1, T2>(T1 source)
        {
            T2 result = default(T2);

            PropertyInfo[] pi = typeof(T2).GetProperties();

            PropertyInfo[] pi1 = typeof(T1).GetProperties();

            result = Activator.CreateInstance<T2>();

            for (int i = 0; i < pi.Length; i++)
            {
                PropertyInfo temp = pi1.Where(t => t.Name == pi[i].Name).FirstOrDefault();
                if (temp != null)
                {
                    try
                    {
                        pi[i].SetValue(result, temp.GetValue(source, null), null);
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 将源实体转换到非空的实体中
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static T2 Covert<T1, T2>(T1 source,T2 destination)
        {
            PropertyInfo[] pi = typeof(T2).GetProperties();

            PropertyInfo[] pi1 = typeof(T1).GetProperties();

            for (int i = 0; i < pi.Length; i++)
            {
                PropertyInfo temp = pi1.Where(t => t.Name == pi[i].Name).FirstOrDefault();
                if (temp != null)
                {
                    try
                    {
                        pi[i].SetValue(destination, temp.GetValue(source, null), null);
                    }
                    catch
                    {
                    }
                }
            }
            return destination;
        }
    }
}
