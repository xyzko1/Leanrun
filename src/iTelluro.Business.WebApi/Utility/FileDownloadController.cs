using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace iTelluro.Busness.WebApi.Utility
{
    public class FileDownloadController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/Utility/FileDownload/ExcelDownloadByFileName")]
        public void ExcelDownloadByFileName(string fileName, string DownFileName)
        {
            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(DownFileName, Encoding.UTF8));
            //调用导出具体方法Export()
            //调用导出具体方法Export()
            string strPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ExcelFileDown\\" + fileName);
            using (System.IO.FileStream fs = new System.IO.FileStream(strPath, System.IO.FileMode.Open))
            {
                byte[] myByte = new byte[fs.Length];
                fs.Read(myByte, 0, myByte.Length);
                fs.Close();
                curContext.Response.BinaryWrite(myByte);
            }
            if (System.IO.File.Exists(strPath))
            {
                System.IO.File.Delete(strPath);
            }
            curContext.Response.Flush();
            curContext.Response.End();
        }
    }
}
