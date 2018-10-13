using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperWebSocket.SubProtocol;

namespace Careysoft.Dotnet.Server.MessageServer.Server
{
    public class AUTHU : SubCommandBase<MessageSocketSession>
    {
        public override void ExecuteCommand(MessageSocketSession session, SuperWebSocket.SubProtocol.SubRequestInfo requestInfo)
        {
            Auth.FactoryAuth af = new Auth.FactoryAuth();
            string clienttype = af.GetClientTypeId(requestInfo.Body);
            Console.WriteLine("Client type is " + clienttype);
            if (clienttype == "-1")
            {
                Console.WriteLine(String.Format("{0} code error, refuse", session.SessionID));
                session.Close();
            }
            else
            {
                string privatekey = Careysoft.Basic.Public.FString.GetRandomString(8);
                session.Cookies.Add("ClientType", clienttype);
                session.Cookies.Add("PrivateKey", privatekey);
                session.Send("AUTHA " + Careysoft.Basic.Public.DES.Encrypt(privatekey, "1234%^&*"));
                if (clienttype == "2")
                {
                    //(session.AppServer as MessageSocketSession).SendNotSendMessageToManage(session);
                }
            }
        }
    }
}
