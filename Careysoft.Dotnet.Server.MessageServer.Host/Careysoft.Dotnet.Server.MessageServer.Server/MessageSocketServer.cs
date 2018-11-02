using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperWebSocket;
using SuperSocket.SocketBase;

namespace Careysoft.Dotnet.Server.MessageServer.Server
{
    public class MessageSocketServer : WebSocketServer<MessageSocketSession>
    {
        public Model.EventMessageServerHandler EventMessageSocketServer;

        public MessageSocketServer() { 
            
        }

        protected override void OnNewSessionConnected(MessageSocketSession session)
        {
            session.EventMessageServerSession += new Model.EventMessageServerHandler(EventReceiveThreadMessage);
            base.OnNewSessionConnected(session);
        }

        private void EventReceiveThreadMessage(Model.EventMessageServerModel model) {
            if (EventMessageSocketServer != null)
            {
                EventMessageSocketServer(model);
            }
        }
    }
}
