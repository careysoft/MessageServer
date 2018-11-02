using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Sender
{
    public class FactorySendercs
    {
        private string clsname = "Careysoft.Dotnet.Server.MessageServer.Server.Sender.Normal.Sender";
        private ISender access;
        public FactorySendercs()
        {
            access = null;
            Type t = Type.GetType(clsname);
            access = (ISender)Activator.CreateInstance(t);
        }

        public FactorySendercs(string typestring)
        {
            access = null;
            Type t = Type.GetType(typestring);
            access = (ISender)Activator.CreateInstance(t);
        }
        /// <summary>
        ///
        /// </summary>
        public bool SendMessageToClient(MessageSocketSession session, Model.MessageBodyModel model)
        {
            return access.SendMessageToClient(session, model);
        }
    }
}
