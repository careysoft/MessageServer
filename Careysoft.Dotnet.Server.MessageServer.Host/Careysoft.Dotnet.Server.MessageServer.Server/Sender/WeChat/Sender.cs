using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Sender.WeChat
{
    public class Sender : ISender
    {
        public bool SendMessageToClient(MessageSocketSession session, Model.MessageBodyModel model)
        {
            try
            {
                string errorInfo = "";
                return Careysoft.Basic.WeiXin.Qy.Client.ClientFuntion.SendTextMessageToUser(model.Header.TargetCode, model.MessageContent, ref errorInfo);
            }
            catch (Exception e)
            {

            }
            return false;
        }
    }
}
