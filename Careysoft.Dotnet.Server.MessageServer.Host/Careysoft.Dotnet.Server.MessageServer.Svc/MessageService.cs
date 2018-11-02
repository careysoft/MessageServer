using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using SuperSocket.SocketEngine;

namespace Careysoft.Dotnet.Server.MessageServer.Svc
{
    partial class MessageService : ServiceBase
    {
        private SuperSocket.SocketBase.IBootstrap m_Websocketserver = null;
        public MessageService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: 在此处添加代码以启动服务。
            m_Websocketserver = BootstrapFactory.CreateBootstrap();
            if (!m_Websocketserver.Initialize())
            {
                Careysoft.Basic.Public.Log.ErrorWrite("Failed to initialize!");
                return;
            }
            (m_Websocketserver.AppServers.First() as MessageServer.Server.MessageSocketServer).EventMessageSocketServer += new Model.EventMessageServerHandler(EventReceiveMessageServer);
            if (m_Websocketserver.Start() == SuperSocket.SocketBase.StartResult.Failed)
            {
                Careysoft.Basic.Public.Log.ErrorWrite("Failed to start!");
            }
        }

        protected override void OnStop()
        {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            m_Websocketserver.Stop();
        }

        private void EventReceiveMessageServer(Model.EventMessageServerModel model)
        {
            //Console.WriteLine(model.ToString());
            if (model.Code == Model.EnumMessageInfo.Error) {
                Careysoft.Basic.Public.Log.ErrorWrite(model.ToString());
            }
        }
    }
}
