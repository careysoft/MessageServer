using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Careysoft.Dotnet.Server.MessageServer.Server.Access;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Access.Cache
{
    public class Auth : IAuth
    {
        
        private List<Model.ClientModel> m_ListClientModel = new List<Model.ClientModel>() { 
            new Model.ClientModel { ClientCode = "OE7KwCfJXMUdqOaTIriHRh4i", ClientPass="aaa", GroupCode = "Office", ClientType = Model.EnumClientType.WeChat }, 
            new Model.ClientModel { ClientCode = "qmeea1pdoGe8hfC8fGqs6ES3", ClientPass="aaa", GroupCode = "SqlData", ClientType = Model.EnumClientType.Normal }, 
            new Model.ClientModel { ClientCode = "BLsgHj4FPaUXsyjArNpNO3no", ClientPass="aaa", GroupCode = "SqlData", ClientType = Model.EnumClientType.Normal }, 
            new Model.ClientModel { ClientCode = "wNtSg8vGZeQhKe1TpP466G1K", ClientPass="aaa", GroupCode = "SqlData", ClientType = Model.EnumClientType.Normal } 
        };

        public Model.ClientModel AuthClientType(string clientAuthIdAndPassword)
        {
            string[] userAndPassArray = clientAuthIdAndPassword.Split('$');
            if (userAndPassArray.Length != 2) {
                return null;
            }
            var retlist = m_ListClientModel.Where(m => m.ClientCode == userAndPassArray[0] && m.ClientPass == userAndPassArray[1]);
            if (retlist.Count() == 1)
            {
                return retlist.First<Model.ClientModel>();
            }
            return null;
        }

        public Model.ClientModel GetClient(string clientId) {
            var client = m_ListClientModel.SingleOrDefault(m => m.ClientCode == clientId);
            return client;
        }
    }
}
