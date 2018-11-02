using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Sender.Normal
{
    public class Sender : ISender
    {

        public bool SendMessageToClient(MessageSocketSession session, Model.MessageBodyModel model)
        {
            try
            {
                string xml = Careysoft.Basic.Public.ObjectSerializer.InstancesToXML<Model.MessageBodyModel>(model);
                xml = Careysoft.Basic.Public.DES.Encrypt(xml, session.Cookies["PrivateKey"]);
                Model.MessageModel msgModel = new Model.MessageModel(Model.EnumCommand.MessagePoint, xml);
                session.Send(msgModel.ToString());
                return true;
            }
            catch (Exception e) { 
            
            }
            return false;
        }
    }
}
