using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Careysoft.Dotnet.Server.MessageServer.Server.Sender
{
    public class Sender
    {
        public static bool SendMessageToClient(MessageSocketServer server, string messageBody)
        {
            Model.MessageBodyModel model = Careysoft.Basic.Public.ObjectSerializer.Xml16ToInstances<Model.MessageBodyModel>(messageBody);
            //MessageSocketSession session = null;
            //IEnumerable<MessageSocketSession> sessions = server.GetAllSessions().Where(m => m.Cookies["ClientCode"] == model.Header.TargetCode);
            //if (sessions.Count() > 0)
            //{
            //    session = sessions.First();
            //}
            MessageSocketSession session = server.GetAllSessions().SingleOrDefault(m => m.Cookies["ClientCode"] == model.Header.TargetCode);
            string clientType = model.Header.TagetType.ToString();
            clientType = String.Format("Careysoft.Dotnet.Server.MessageServer.Server.Sender.{0}.Sender", clientType);
            FactorySendercs af = new FactorySendercs(clientType);
            return af.SendMessageToClient(session, model); //发送给微信时，session为0
        }

        public static bool SendMessageToGroup(MessageSocketServer server, string messageBody) {
            Model.MessageBodyModel model = Careysoft.Basic.Public.ObjectSerializer.Xml16ToInstances<Model.MessageBodyModel>(messageBody);
            string groupCode = Access.Auth.GetClient(model.Header.SourceCode).GroupCode;
            IEnumerable<MessageSocketSession> sessions = server.GetAllSessions().Where(m => m.Cookies["GroupCode"] == groupCode);
            foreach (MessageSocketSession session in sessions) {
                if (session.Cookies["ClientCode"] != model.Header.SourceCode)
                {
                    string clientType = model.Header.TagetType.ToString();
                    clientType = String.Format("Careysoft.Dotnet.Server.MessageServer.Server.Sender.{0}.Sender", clientType);
                    FactorySendercs af = new FactorySendercs(clientType);
                    af.SendMessageToClient(session, model);
                }
            }
            return true;
        }

        public static bool SendMessageToGroup(MessageSocketServer server, Model.MessageBodyModel model)
        {
            String groupCode = Access.Auth.GetClient(model.Header.SourceCode).GroupCode;
            IEnumerable<MessageSocketSession> sessions = server.GetAllSessions().Where(m => m.Cookies["GroupCode"] == groupCode);
            foreach (MessageSocketSession session in sessions)
            {
                if (session.Cookies["ClientCode"] != model.Header.SourceCode)
                {
                    string clientType = model.Header.TagetType.ToString();
                    clientType = String.Format("Careysoft.Dotnet.Server.MessageServer.Server.Sender.{0}.Sender", clientType);
                    FactorySendercs af = new FactorySendercs(clientType);
                    af.SendMessageToClient(session, model);
                }
            }
            return true;
        }
    }
}
