﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UIManage/Views/UIDesign/MQIndex.cshtml")]
    public partial class _Areas_UIManage_Views_UIDesign_MQIndex_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UIManage_Views_UIDesign_MQIndex_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\UIManage\Views\UIDesign\MQIndex.cshtml"
  
    ViewBag.Title = "消息队列MQ";
    Layout = "~/Views/Shared/_Index.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    .orm_title {\r\n        color: #666666;\r\n        font-size: 16px;\r\n        h" +
"eight: 36px;\r\n        line-height: 36px;\r\n        margin-left: 15px;\r\n        fo" +
"nt-weight: bold;\r\n        padding-top: 5px;\r\n    }\r\n\r\n    .orm_title_note {\r\n   " +
"     color: #999999;\r\n        height: 24px;\r\n        line-height: 24px;\r\n       " +
" margin: 0 15px;\r\n        border-bottom: 1px solid #ededed;\r\n    }\r\n\r\n    .actio" +
"n_title1 {\r\n        color: #666666;\r\n        font-size: 14px;\r\n        height: 4" +
"0px;\r\n        line-height: 40px;\r\n        padding-left: 25px;\r\n    }\r\n\r\n    .but" +
"ton_style a {\r\n        display: inline-block;\r\n        height: 40px;\r\n        li" +
"ne-height: 40px;\r\n        padding: 0 25px;\r\n        color: #fff;\r\n    }\r\n\r\n    ." +
"button_style {\r\n        border-bottom: 1px solid #ededed;\r\n        margin: 0 25p" +
"x;\r\n    }\r\n\r\n    .orm_table {\r\n        width: 100%;\r\n    }\r\n\r\n        .orm_table" +
" tr th {\r\n            color: #5b5b60;\r\n            height: 30px;\r\n            li" +
"ne-height: 30px;\r\n            font-size: 14px;\r\n        }\r\n\r\n        .orm_table " +
"tr td {\r\n            vertical-align: top;\r\n            text-align: center;\r\n    " +
"    }\r\n\r\n    .orm_item {\r\n        border: 1px solid #eeeeee;\r\n        margin: 10" +
"px;\r\n        text-align: center;\r\n        padding: 20px;\r\n    }\r\n\r\n    .orm_item" +
"_title {\r\n        background: #007aff;\r\n        padding: 10px 20px;\r\n        bor" +
"der-radius: 8px;\r\n        display: inline-block;\r\n        font-style: italic;\r\n " +
"       color: #fff;\r\n        font-size: 24px;\r\n        font-weight: bold;\r\n    }" +
"\r\n\r\n    .orm_item_title_note {\r\n        font-size: 18px;\r\n        height: 48px;\r" +
"\n        line-height: 48px;\r\n    }\r\n\r\n    .orm_item_title_note1 {\r\n        color" +
": #333;\r\n        line-height: 28px;\r\n    }\r\n\r\n    .orm_action1 {\r\n        margin" +
": 10px;\r\n    }\r\n\r\n    .orm_action {\r\n        width: 100%;\r\n    }\r\n\r\n        .orm" +
"_action tr td {\r\n            border: 1px solid #eeeeee;\r\n            width: 100%" +
";\r\n        }\r\n\r\n    .orm_action_title {\r\n        height: 36px;\r\n        line-hei" +
"ght: 36px;\r\n        font-weight: bold;\r\n        padding-left: 15px;\r\n        fon" +
"t-size: 14px;\r\n        color: #5b5b60;\r\n    }\r\n    .orm_item_title_note1 img{\r\n " +
"       border:1px solid #eee;\r\n        margin:20px;\r\n        border-radius:3px;\r" +
"\n    }\r\n</style>\r\n\r\n\r\n\r\n\r\n\r\n<div");

WriteLiteral(" style=\" margin:10px;\"");

WriteLiteral(" id=\"abc\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" style=\"background:#fff; \"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"orm_title\"");

WriteLiteral(">消息队列MQ</div>\r\n\r\n\r\n        <div");

WriteLiteral(" style=\"border-bottom:2px solid #ee8339; margin-top:15px;\"");

WriteLiteral("></div>\r\n\r\n\r\n    </div>\r\n\r\n\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" style=\"background: #fff; margin-bottom: 10px; \"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"orm_action1\"");

WriteLiteral(">\r\n\r\n\r\n            <table");

WriteLiteral(" class=\"orm_action\"");

WriteLiteral(">\r\n\r\n\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"orm_action_title\"");

WriteLiteral(">\r\n                        一、WebConfig配置\r\n                    </td>\r\n\r\n          " +
"      </tr>\r\n                <tr>\r\n                    <td>\r\n                   " +
"     <div");

WriteLiteral(" style=\"padding:15px;\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                在Awebconfig文件中找到BusinessName,修改需要设定的系统名称\r\n\r\n\r\n" +
"\r\n\r\n\r\n                            </p>\r\n\r\n\r\n\r\n                          \r\n      " +
"                      <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                <!--消息队列配置信息-->\r\n                            <" +
"/p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                < add");

WriteLiteral(" key=\"MQServiceIp\"");

WriteLiteral(" value=\"amqp://192.168.100.39:5672/\"");

WriteLiteral(" />\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                <!--用户名-->\r\n                            </p>\r\n" +
"                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                < add");

WriteLiteral(" key=\"MQUserName\"");

WriteLiteral(" value=\"guest\"");

WriteLiteral(" />\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                <!--密码-->\r\n                            </p>\r\n " +
"                           <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                < add");

WriteLiteral(" key=\"MQPassWord\"");

WriteLiteral(" value=\"guest\"");

WriteLiteral(" />\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                <!--虚拟主机名-->\r\n                            </p>" +
"\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                < add");

WriteLiteral(" key=\"MQVirtualHost\"");

WriteLiteral(" value=\"DXSTask\"");

WriteLiteral(" />\r\n\r\n                            </p>\r\n\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                < add");

WriteLiteral(" key=\"BusinessName\"");

WriteLiteral(" value=\"地下水\"");

WriteLiteral(" />\r\n                            </p>\r\n\r\n\r\n                        </div>\r\n      " +
"              </td>\r\n                    <td></td>\r\n                </tr>\r\n\r\n   " +
"         </table>\r\n\r\n\r\n        </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n\r\n\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" style=\"background: #fff; margin-bottom: 10px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"orm_action1\"");

WriteLiteral(">\r\n\r\n\r\n            <table");

WriteLiteral(" class=\"orm_action\"");

WriteLiteral(">\r\n\r\n\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"orm_action_title\"");

WriteLiteral(">\r\n                        二、操作类调用路径\r\n\r\n\r\n                    </td>\r\n\r\n          " +
"      </tr>\r\n                <tr>\r\n                    <td>\r\n                   " +
"     <div");

WriteLiteral(" style=\"padding:15px;\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                <img");

WriteAttribute("src", Tuple.Create(" src=\"", 5385), Tuple.Create("\"", 5425)
, Tuple.Create(Tuple.Create("", 5391), Tuple.Create<System.Object, System.Int32>(Href("~/Content/adminDefault/img/MQ1.png")
, 5391), false)
);

WriteLiteral(" /></p>\r\n\r\n\r\n                         \r\n\r\n\r\n\r\n\r\n                        </div>\r\n " +
"                   </td>\r\n\r\n                </tr>\r\n\r\n            </table>\r\n\r\n\r\n " +
"       </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n\r\n\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(" style=\"background: #fff; margin-bottom: 10px;\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"orm_action1\"");

WriteLiteral(">\r\n\r\n\r\n            <table");

WriteLiteral(" class=\"orm_action\"");

WriteLiteral(">\r\n\r\n\r\n                <tr>\r\n                    <td");

WriteLiteral(" class=\"orm_action_title\"");

WriteLiteral(">\r\n                        三、调用示例\r\n                    </td>\r\n\r\n                <" +
"/tr>\r\n                <tr>\r\n                    <td>\r\n                        <d" +
"iv");

WriteLiteral(" style=\"padding:15px; padding-left:40px;\"");

WriteLiteral(">\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                public void SaveTaskInfo(TaskDTO taskInfo)\r\n  " +
"                          </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp  {\r\n                            </p>\r\n  " +
"                          <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp var entity = taskInfo.MapTo< tasken" +
"tity>();\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp  if (!string.IsNullOrEmpty(entity.I" +
"d))\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp {\r\n                            </p>" +
"\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp  _taskRepository.Update(entity" +
");\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp     }\r\n                       " +
"     </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp  else\r\n                       " +
"     </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp  {\r\n                          " +
"  </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp    entity.Id = Guid.NewGu" +
"id().ToString();\r\n                            </p>\r\n                            " +
"<p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp   var query = _modelQueueRepos" +
"itory.GetAll();\r\n                            </p>\r\n                            <" +
"p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp   var queueInfo = query.Where(" +
"t => t.MODELID == entity.MODELID).FirstOrDefault();\r\n                           " +
" </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(" style=\"color:green;\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp    //消息队列发消息\r\n                " +
"            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp    if (queueInfo != null)\r\n   " +
"                         </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp   {\r\n                         " +
"   </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp    MqConfigInfo config = " +
"new MqConfigInfo();\r\n                            </p>\r\n                         " +
"   <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp  config.MQExChange = queu" +
"eInfo.EXCHANGENAME;\r\n                            </p>\r\n                         " +
"   <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp    config.MQQueueName = q" +
"ueueInfo.QUEUENAME;\r\n                            </p>\r\n                         " +
"   <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp    config.MQRoutingKey = " +
"queueInfo.ROUTINGKEY;\r\n                            </p>\r\n                       " +
"     <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp   entity.STARTTIME = Date" +
"Time.Now;\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp   entity.EXCHANGENAME = q" +
"ueueInfo.EXCHANGENAME;\r\n                            </p>\r\n                      " +
"      <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp    entity.QUEUENAME = que" +
"ueInfo.QUEUENAME;\r\n                            </p>\r\n                           " +
" <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp  entity.ROUTINGKEY = queu" +
"eInfo.ROUTINGKEY;\r\n                            </p>\r\n                           " +
" <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp  entity.TASKSTATUS = \"正在排" +
"队...\";\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp   taskInfo.Id = entity.Id" +
";\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp  try\r\n                   " +
"         </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp   {\r\n                    " +
"        </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp&nbsp  MqHelper heper = ne" +
"w MqHelper(config);\r\n                            </p>\r\n                         " +
"   <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp&nbsp    heper.SendMsg(tas" +
"kInfo);\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp    }\r\n                   " +
"         </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp    catch(Exception ex)\r\n " +
"                           </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp   {\r\n                    " +
"        </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp&nbsp throw ex;\r\n         " +
"                   </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp&nbsp  }\r\n                     " +
"       </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp   }\r\n                         " +
"   </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp&nbsp  _taskRepository.Insert(entity" +
");\r\n                            </p>\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(">\r\n                                &nbsp&nbsp  }\r\n                            </p" +
">\r\n                            <p");

WriteLiteral(" class=\"orm_item_title_note1\"");

WriteLiteral(@">
                                &nbsp  }






                            </p>

                        </div>
                    </td>

                </tr>

            </table>


        </div>






    </div>


    

</div>
");

        }
    }
}
#pragma warning restore 1591