using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperWebSocket;
using SuperSocket.SocketBase;

namespace Careysoft.Dotnet.Server.MessageServer.Server
{
    public class MessageSocketSession : WebSocketSession<MessageSocketSession>
    {
        public Model.EventMessageServerHandler EventMessageServerSession;

        public void EventMessageServerSessionExcute(Model.EventMessageServerModel model) {
            if (EventMessageServerSession != null) {
                EventMessageServerSession(model);
            }
        }

        protected override void OnSessionStarted()
        {
            //this.Send("Welcome to SuperSocket Telnet Server "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            EventMessageServerSessionExcute(new Model.EventMessageServerModel(Model.EnumMessageInfo.Log, "OnSessionStarted", SessionID));
            this.Send(Model.EnumCommand.AuthQuestion.ToString());
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
           EventMessageServerSessionExcute(new Model.EventMessageServerModel(Model.EnumMessageInfo.Log, "OnSessionClosed", SessionID));
           Model.MessageBodyModel model = new Model.MessageBodyModel();
           model.Header.TagetType = Model.EnumClientType.Normal;
           model.Header.SourceCode = Cookies["ClientCode"];
           model.MessageContentType = Model.EnumMessageContentType.Text;
           model.MessageContent = "StateShutdown";
           Sender.Sender.SendMessageToGroup((MessageSocketServer)AppServer, model);
           base.OnSessionClosed(reason);
        }
    }
}
