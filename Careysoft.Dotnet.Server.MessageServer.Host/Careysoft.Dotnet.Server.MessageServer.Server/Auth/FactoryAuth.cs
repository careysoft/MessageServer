using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Auth
{
    public class FactoryAuth
    {
        private string clsname = "WeiXinWebSocketServer.Auth.Access.Auth";
        private IAuth access;
        public FactoryAuth()
        {
            access = null;
            Type t = Type.GetType(clsname);
            access = (IAuth)Activator.CreateInstance(t);
        }

        public FactoryAuth(string typestring)
        {
            access = null;
            Type t = Type.GetType(typestring);
            access = (IAuth)Activator.CreateInstance(t);
        }
        /// <summary>
        ///
        /// </summary>
        public string GetClientTypeId(string clientauthid)
        {
            return access.GetClientTypeId(clientauthid);
        }
    }
}
