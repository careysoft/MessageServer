using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperWebSocket.SubProtocol;
using Careysoft.Dotnet.Server.MessageServer.Model;

namespace Careysoft.Dotnet.Server.MessageServer.Server
{
    public class AuthUser : SubCommandBase<MessageSocketSession>
    {
        public override void ExecuteCommand(MessageSocketSession session, SuperWebSocket.SubProtocol.SubRequestInfo requestInfo)
        {
            Model.ClientModel clientModel = Access.Auth.AuthClientType(requestInfo.Body);
            if (clientModel == null)
            {
                //Console.WriteLine(String.Format("{0} code error, refuse", session.SessionID));
                session.Close();
            }
            else
            {
                string privatekey = Careysoft.Basic.Public.FString.GetRandomString(8);
                session.Cookies.Add("ClientCode", clientModel.ClientCode);
                session.Cookies.Add("ClientType", clientModel.ClientType.ToString());
                session.Cookies.Add("GroupCode", clientModel.GroupCode);
                session.Cookies.Add("PrivateKey", privatekey);
                session.Cookies.Add("ConnectTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                session.Send(String.Format("{0} {1}", Model.EnumCommand.AuthAccept, Careysoft.Basic.Public.DES.Encrypt(privatekey, DateTime.Now.AddDays(-1).ToString("yyyyMMdd"))));
            }
        }
    }

    public class Status : SubCommandBase<MessageSocketSession>
    {
        public override void ExecuteCommand(MessageSocketSession session, SubRequestInfo requestInfo)
        {
            session.EventMessageServerSessionExcute(new Model.EventMessageServerModel(EnumMessageInfo.Log, "Status", session.SessionID));
            session.Cookies["ConnectTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            session.Send(Model.EnumCommand.Status.ToString());
        }
    }

    /// <summary>
    /// 点对点
    /// </summary>
    public class MessagePoint : SuperWebSocket.SubProtocol.SubCommandBase<MessageSocketSession>
    {
        public override void ExecuteCommand(MessageSocketSession session, SuperWebSocket.SubProtocol.SubRequestInfo requestInfo)
        {
            session.Cookies["ConnectTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string body = Careysoft.Basic.Public.DES.Decrypt(requestInfo.Body, session.Cookies["PrivateKey"]);
            session.EventMessageServerSessionExcute(new Model.EventMessageServerModel(EnumMessageInfo.Log, "MessagePoint", session.SessionID + " " + body));
            Sender.Sender.SendMessageToClient(session.AppServer as MessageSocketServer, body);
        }
    }

    /// <summary>
    /// 广播
    /// </summary>
    public class MessageGroup : SuperWebSocket.SubProtocol.SubCommandBase<MessageSocketSession>
    {
        public override void ExecuteCommand(MessageSocketSession session, SuperWebSocket.SubProtocol.SubRequestInfo requestInfo)
        {
            session.Cookies["ConnectTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string body = Careysoft.Basic.Public.DES.Decrypt(requestInfo.Body, session.Cookies["PrivateKey"]);
            session.EventMessageServerSessionExcute(new Model.EventMessageServerModel(EnumMessageInfo.Log, "MessagePoint", session.SessionID + " " + body));
            Sender.Sender.SendMessageToGroup(session.AppServer as MessageSocketServer, body);
        }
    }
}
