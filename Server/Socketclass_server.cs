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
        Socket handler;
        Thread th;
        Socket sListener;

        public void Start1()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 30000);
            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                    // Программа приостанавливается, ожидая входящее соединение
                    handler = sListener.Accept();

                    Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                    Thread.Start(handler);


                    /*
                    string data = null;
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    Console.Write("Полученный текст: " + data + "\n\n");
                    string reply = "Спасибо за запрос в " + data.Length.ToString()
                            + " символов";
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    //////////////////////////////////
                    handler.Send(msg);
                    /////////////////////////////////////
                    */

                    Console.WriteLine("zkzkzkzkzkzkzkkz");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                //Console.ReadLine();
            }
        }



        public void Start()
        {

            th = new Thread(new ThreadStart(Start1));
            th.IsBackground = true;
            th.Start();
        }

        public void Stop()
        {
            if (th != null)
            {
                //это очень важные коментарии
                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();
                //sListener.Shutdown(SocketShutdown.Both);
                sListener.Close();
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
