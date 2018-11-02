using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Access
{
    public class FactoryAuth
    {
        private string clsname = "Careysoft.Dotnet.Server.MessageServer.Server.Access.Cache.Auth";
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
        public Model.ClientModel AuthClientType(string clientAuthIdAndPassword)
        {
            return access.AuthClientType(clientAuthIdAndPassword);
        }

        public Model.ClientModel GetClient(string clientId) {
            return access.GetClient(clientId);
        }
    }
}
