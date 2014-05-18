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
        private int typeConection = -1;

        public Socketclass_server(string ipAdress,int conectPort)
        {
            // Устанавливаем для сокета локальную конечную точку
            localpoint = ipAdress;
            port = conectPort;

            ipHost = Dns.GetHostEntry(localpoint);
            IPAddress ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, port);

            // Создаем сокет Tcp/Ip
            workSoket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        }
        static void ClientThread(Object StateInfo)
        {
            new Client((Socket)StateInfo);
        }
        /// <summary>
        /// Установка Soket Статуса сервер. Слушает входящие подключения и отвечает на них
        /// </summary>
        /// <param name="limitсListeners">Количество </param>
        public void AsServer(int limitсListeners = 10)
        {
            if (typeConection != -1)
            {
                throw new InvalidProgramException("Нельзя присвоить сокету тип 'сервер', присвоен уже другой статус");
            }
            workSoket.Bind(ipEndPoint);
            workSoket.Listen(limitсListeners);
            typeConection = 0;

            ListenMessage();


        }
        public void ListenMessage()
        {
            while (true)
            {
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                // Программа приостанавливается, ожидая входящее соединение
                Socket handler = workSoket.Accept();
                // Принимаем нового клиента
                // Создаем поток
                Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                // И запускаем этот поток, передавая ему принятого клиента
                Thread.Start(handler);

            }
        }


    }
}
