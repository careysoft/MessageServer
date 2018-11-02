using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Sender
{
    interface ISender
    {
        /// <summary>
        /// 点对点发送
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SendMessageToClient(MessageSocketSession session, Model.MessageBodyModel model);
    }
}
