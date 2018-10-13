using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Auth.Access
{
    public class Auth : IAuth
    {
        private List<Model.AuthModel> m_ListAuthModel = new List<Model.AuthModel>() { 
            new Model.AuthModel { ClientCode = "OE7KwCfJXMUdqOaTIriHRh4i", ClientType = "1" }, 
            new Model.AuthModel { ClientCode = "qmeea1pdoGe8hfC8fGqs6ES3", ClientType = "2" }, 
            new Model.AuthModel { ClientCode = "BLsgHj4FPaUXsyjArNpNO3no", ClientType = "2" }, 
            new Model.AuthModel { ClientCode = "wNtSg8vGZeQhKe1TpP466G1K", ClientType = "2" } 
        };

        public string GetClientTypeId(string clientauthid)
        {
            var retlist = m_ListAuthModel.Where(m => m.ClientCode == clientauthid);
            if (retlist.Count() == 1)
            {
                return retlist.First<Model.AuthModel>().ClientType;
            }
            return "-1";
        }
    }
}
