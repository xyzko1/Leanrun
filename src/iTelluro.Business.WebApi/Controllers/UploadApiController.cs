using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace iTelluro.Busness.WebApi.Controllers
{
    /// <summary>
    /// 业务系统公共Api接口
    /// </summary>
    public class UploadApiController : ApiControllerBase
    {
        /// <summary>
        /// 上传导入工具文件的服务接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public bool UploadFile()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            if (files.Count == 0)
            {
                throw new ArgumentException("上传文件不存在");
            }
            HttpPostedFile file = files[0];
            string base64 = file.FileName.Remove(0, 10);
            base64 = base64.Substring(0, base64.Length - 2);
            string fileName = DecodeBase64("utf-8", base64);
            if (fileName.EndsWith(".zip") == false)
            {
                throw new ArgumentException("上传文件格式不正确");
            }
            //创建文件夹
            string localDir = System.Configuration.ConfigurationManager.AppSettings["ServerFolder"];
            if (Directory.Exists(localDir) == false)
                Directory.CreateDirectory(localDir);
            string local = Path.Combine(localDir, fileName);
            //保存上传文件到本地
            file.SaveAs(local);

            return true;
        }

        ///编码
        private string EncodeBase64(string code_type, string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
        ///解码
        private string DecodeBase64(string code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }
    }
}
