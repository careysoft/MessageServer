using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Model
{
    public class ClientModel
    {
        public string ClientCode { get; set; }
        public string ClientPass { get; set; }
        public string GroupCode { get; set; }
        public EnumClientType ClientType { get; set; }
    }
}
