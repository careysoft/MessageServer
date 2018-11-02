using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketEngine;

namespace Careysoft.Dotnet.Server.MessageServer.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press wait to start the server!");
            //Console.WriteLine(Model.EnumCommand.AuthUser.ToString());
            var websocketserver = BootstrapFactory.CreateBootstrap();
            if (!websocketserver.Initialize())
            {
                Console.WriteLine("Failed to initialize!");
                Console.ReadKey();
                return;
            }
            (websocketserver.AppServers.First() as MessageServer.Server.MessageSocketServer).EventMessageSocketServer += new Model.EventMessageServerHandler(EventReceiveMessageServer);
            Console.WriteLine();
            if (websocketserver.Start() == SuperSocket.SocketBase.StartResult.Failed)
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();

            Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();
            //Stop the appServer
            websocketserver.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
            Console.WriteLine("Bye");
        }

        static void EventReceiveMessageServer(Model.EventMessageServerModel model) {
            Console.WriteLine(model.ToString());
        }
    }
}
