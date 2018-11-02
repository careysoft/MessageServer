using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;

namespace Careysoft.Dotnet.Server.MessageServer.Client
{
    public class MessageSocketClient
    {
        public event EventHandler EventClientOpened; 
        public event EventHandler EventClientClosed;

        private WebSocket4Net.WebSocket m_WebSocketClient = null;
        private string m_Ip = "";
        private string m_Port = "";
        private bool m_Logined = false;
        private string m_PrivateKey = "";
        private string m_ClientCode = "qmeea1pdoGe8hfC8fGqs6ES3";
        private string m_ClientPass = "aaa";

        public WebSocketState SocketState {
            get {
                return m_WebSocketClient.State;
            }
        }

        public MessageSocketClient(string ip, string port) {
            m_Ip = ip;
            m_Port = port;
        }

        public bool Connect() {
            if (m_WebSocketClient != null) {
                Close();        
            }
            m_WebSocketClient = new WebSocket4Net.WebSocket(string.Format("ws://{0}:{1}/websocket", m_Ip, m_Port), "basic", WebSocketVersion.Rfc6455);
            m_WebSocketClient.Opened += new EventHandler(m_WebSocketClient_Opened);
            m_WebSocketClient.Closed += new EventHandler(m_WebSocketClient_Closed);
            m_WebSocketClient.MessageReceived += new EventHandler<MessageReceivedEventArgs>(m_WebSocketClient_MessageReceived);
            m_WebSocketClient.Open();
            return true;
        }

        public bool Close() {
            m_WebSocketClient.Close();
            m_WebSocketClient = null;
            return true;
        }

        public void SendWeiXinMessage(string userId, string message) {
            Model.MessageBodyModel modelBody = new Model.MessageBodyModel();
            modelBody.Header.TargetCode = userId;
            modelBody.Header.TagetType = Model.EnumClientType.WeChat;
            modelBody.Header.SourceCode = m_ClientCode;
            modelBody.Header.MessageType = Model.EnumMessageType.Point;
            modelBody.MessageContentType = Model.EnumMessageContentType.Text;
            modelBody.MessageContent = message;
            string body = Careysoft.Basic.Public.ObjectSerializer.InstancesToXML<Model.MessageBodyModel>(modelBody);
            body = Careysoft.Basic.Public.DES.Encrypt(body, m_PrivateKey);
            Model.MessageModel model = new Model.MessageModel(Model.EnumCommand.MessagePoint, body);
            m_WebSocketClient.Send(model.ToString());
        }

        void m_WebSocketClient_Opened(object sender, EventArgs e)
        {
            if (EventClientOpened != null) {
                EventClientOpened(sender, e);
            }
        }

        void m_WebSocketClient_Closed(object sender, EventArgs e)
        {
            if (EventClientClosed != null)
            {
                EventClientClosed(sender, e);
            }
        }

        void m_WebSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Model.MessageModel model = new Model.MessageModel(e.Message);
            switch (model.Command)
            {
                case Model.EnumCommand.AuthQuestion:
                    m_WebSocketClient.Send(String.Format("{0} {1}${2}", Model.EnumCommand.AuthUser.ToString(), m_ClientCode, m_ClientPass));
                    break;
                case Model.EnumCommand.AuthAccept:
                    m_Logined = true;
                    m_PrivateKey = Careysoft.Basic.Public.DES.Decrypt(model.Body, DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
                    break;
                case Model.EnumCommand.MessagePoint:
                    string body = model.Body;
                    body = Careysoft.Basic.Public.DES.Decrypt(body, m_PrivateKey);
                    Model.MessageBodyModel msgModel = Careysoft.Basic.Public.ObjectSerializer.Xml16ToInstances<Model.MessageBodyModel>(body);
                    break;
            }
        }
    }
}
