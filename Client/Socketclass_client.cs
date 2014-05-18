using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public class Socetclass
    {
        private IPHostEntry ipHost;

        private IPEndPoint ipEndPoint;
        private Socket workSoket;
        private string localpoint = "localhost";
        private int port = 11000;
        private int typeConection = -1; // тип соединения 0-сервер /1-клиент

        public Socetclass(string ipAdress, int conectPort)
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
        /// <summary>
        /// Присваение сокету статуса клиент, может только подключаться к серверу отправлять данные и получать ответ
        /// </summary>
        public void AsClient()
        {
            if (typeConection != -1)
            {
                throw new InvalidProgramException("Нельзя присвоить сокету тип 'клиент', присвоен уже другой статус");
            }

           // workSoket.Connect(ipEndPoint);
            typeConection = 1;

        }



        void tt()
        {


            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                workSoket.Bind(ipEndPoint);
                workSoket.Listen(10);

                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = workSoket.Accept();
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // Показываем данные на консоли
                    Console.Write("Полученный текст: " + data + "\n\n");

                    // Отправляем ответ клиенту\
                    string reply = "Спасибо за запрос в " + data.Length.ToString()
                            + " символов";
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);

                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Сервер завершил соединение с клиентом.");
                        break;
                    }

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        public string ListenMessage()
        {
            while (true)
            {
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                // Программа приостанавливается, ожидая входящее соединение
                Socket handler = workSoket.Accept();
                string data = null;

                // Мы дождались клиента, пытающегося с нами соединиться

                byte[] bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);

                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                // Показываем данные на консоли
                Console.Write("Полученный текст: " + data + "\n\n");

                // Отправляем ответ клиенту\
                string reply = "Спасибо за запрос в " + data.Length.ToString()
                        + " символов";
                byte[] msg = Encoding.UTF8.GetBytes(reply);
                handler.Send(msg);

                if (data.IndexOf("<TheEnd>") > -1)
                {
                    Console.WriteLine("Сервер завершил соединение с клиентом.");
                    break;
                }

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            return " ";
        }

        public void SendMessage(string message)
        {
            if (typeConection != 1)
            {
                throw new InvalidProgramException("Данный сокет не является клиентом,отправка невозможна");
            }
            byte[] answerByte = new byte[4096];


            workSoket.Connect(ipEndPoint);
            byte[] msg = Encoding.UTF8.GetBytes(message);

            // Отправляем данные через сокет
            workSoket.Send(msg);

            // Получаем ответ от сервера
            int answerByteRec = workSoket.Receive(answerByte);

            string answer = Encoding.UTF8.GetString(answerByte, 0, answerByteRec);
            Console.WriteLine(answer);

            workSoket.Disconnect(true);
            //workSoket.Shutdown(SocketShutdown.Both);
            //workSoket.Close();

        }
    }
}
