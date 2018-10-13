using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Auth
{
    interface IAuth
    {
        /// <summary>
        /// 获取 客户端类型 
        /// </summary>
        /// <param name="clientauthid"></param>
        /// <returns>-1返回错误 1微信客户端 2消息接受客户端</returns>
        string GetClientTypeId(string clientauthid);
    }
}
