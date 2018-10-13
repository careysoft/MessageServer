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
        protected override void OnSessionStarted()
        {
            this.Send("Welcome to SuperSocket Telnet Server "+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            this.Send("AUTHQ");
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
           base.OnSessionClosed(reason);
        }
    }
}
