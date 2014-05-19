using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using JsonModel;
using Newtonsoft.Json;
using System.Threading;

namespace Server
{
    class Socketclass_server
   {
        private IPHostEntry ipHost;

        private IPEndPoint ipEndPoint;
        private Socket workSoket;
        private string localpoint = "localhost";
        private int port = 11000;
        private Thread th;

        public void Start1()
        {
            ipHost = Dns.GetHostEntry(localpoint);
            IPAddress ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, port);
            workSoket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            workSoket.Bind(ipEndPoint);
            workSoket.Listen(10);

            th = new Thread(new ThreadStart(Start));
            th.IsBackground = true;
            th.Start();
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                Socket handler = workSoket.Accept();
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                Thread.Start(handler);
            }

        }

        public void Stop()
        {
            if (th != null)
            {
                Console.WriteLine("Stoped");
                th.Abort();

            }
        }

        static void ClientThread(Object StateInfo)
        {
            new Client((Socket)StateInfo);
        }


    }
}
