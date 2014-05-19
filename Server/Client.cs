using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using JsonModel;
using Newtonsoft.Json;

namespace Server
{
    public class Client
    {
        private Socket stream;
        private byte[] bytes;

        public Client(Socket handler)
        {
            this.stream = handler;
            this.bytes = new byte[4096];
            int idOperation = this.getIdOperation();
            switch (idOperation)
            {
                case 1:
                    this.operationComand1();
                    break;
                default:
                    this.otherComand();
                    break;
            }
            this.stream.Shutdown(SocketShutdown.Both);
            this.stream.Close();
        }

        private int getIdOperation()
        {
            int res = 0;
            int bytesRec = this.stream.Receive(this.bytes);
            res = BitConverter.ToInt32(bytes, 0);
            byte[] ms = Encoding.UTF8.GetBytes("ok");
            this.stream.Send(ms);

            Console.WriteLine("\nЗапрош прошел:{1}\nКод операции{0}\n", res, DateTime.Now.ToString());

            return res;
        }
        private void otherComand()
        {

            int bytesRec = this.stream.Receive(bytes);
            string data = Encoding.UTF8.GetString(this.bytes, 0, bytesRec);
            // Показываем данные на консоли
            Console.Write("\nПолученный текст: " + data + "\n\n");

            // Отправляем ответ клиенту\
            string reply = "Спасибо за запрос в " + data.Length.ToString()
                    + " символов";
            byte[] msg = Encoding.UTF8.GetBytes(reply);
            this.stream.Send(msg);
        }
        
        private void operationComand1()
        {

            int bytesRec = this.stream.Receive(this.bytes);
            string json = Encoding.UTF8.GetString(this.bytes, 0, bytesRec);
            Comand1 data = new Comand1();
            data = JsonConvert.DeserializeObject<Comand1>(json);

            int response = 0;
            Console.WriteLine("Попытка авторизироваться \nlogin: {0}\nPass: {1}", data.login, data.password);
            if (data.login == "admin" && data.password == "admin")
            {
                response = 123456;
            }
            Console.WriteLine("\nвернули токен {0}\n", response);
            this.bytes = BitConverter.GetBytes(response);
            this.stream.Send(this.bytes);
        }
    }
}
