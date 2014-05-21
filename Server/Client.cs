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
        //private Socket stream;
        //private byte[] bytes;

        public Client(Socket handler)
        {
            Socket stream = handler;
            byte[] bytes = new byte[4096];
            byte[] msg;
            /*TODO
             * принять(кодзапроса,длиназапроса)
             * послать(кодзапроса,длиназапроса)
             * а потом принимать и отсылать данные
             * 
            */
            int codeLength = stream.Receive(bytes);
            int idOperation = this.getIdOperation(bytes);

            byte[] ms = Encoding.UTF8.GetBytes("ok");
            stream.Send(ms);

            int bytesLength = stream.Receive(bytes);

            switch (idOperation)
            {
                case 1:
                    msg = this.Authorization(bytes, bytesLength);    
                    //this.operationComand1();
                    break;
                default:
                    msg = this.otherComand(bytes, bytesLength);
                    break;
            }
            stream.Send(msg);
            
            //stream.Shutdown(SocketShutdown.Both);
            stream.Close();
        }

        private int getIdOperation(byte[] bytes)
        {
            int res = 0;
            //int bytesRec = this.stream.Receive(this.bytes);
            res = BitConverter.ToInt32(bytes, 0);
            //byte[] ms = Encoding.UTF8.GetBytes("ok");
            //this.stream.Send(ms);

            Console.WriteLine("\nЗапрош прошел:{1}\nКод операции{0}\n", res, DateTime.Now.ToString());

            return res;
        }

        private byte[] otherComand(byte[] bytes, int bytesRec)
        {

            //int bytesRec = this.stream.Receive(bytes);
            string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            Console.Write("\nПолученный текст: " + data + "\n\n");

            string reply = "Спасибо за запрос в " + data.Length.ToString()
                    + " символов";
            byte[] msg = Encoding.UTF8.GetBytes(reply);
            return msg;
        }

        private byte[] Authorization(byte[] bytes, int bytesRec)
        {

            //int bytesRec = this.stream.Receive(this.bytes);
            string json = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            Comand1 data = new Comand1();
            data = JsonConvert.DeserializeObject<Comand1>(json);

            int response = 0;
            Console.WriteLine("Попытка авторизироваться \nlogin: {0}\nPass: {1}", data.login, data.password);
            if (data.login == "admin" && data.password == "admin")
            {
                response = 123456;
            }
            Console.WriteLine("\nвернули токен {0}\n", response);

            byte[] msg = BitConverter.GetBytes(response);
            return msg;
        }
    }
}
