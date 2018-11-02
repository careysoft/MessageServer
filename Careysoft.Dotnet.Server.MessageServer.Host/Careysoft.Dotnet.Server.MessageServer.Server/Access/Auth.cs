using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Access
{
    public class Auth
    {
        public static Model.ClientModel AuthClientType(string clientAuthIdAndPassword)
        {
            FactoryAuth af = new FactoryAuth();
            return af.AuthClientType(clientAuthIdAndPassword);
        }

        public static Model.ClientModel GetClient(string clientId) {
            FactoryAuth af = new FactoryAuth();
            return af.GetClient(clientId);
        }
    }
}
