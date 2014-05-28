using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using JsonModel;
using Newtonsoft.Json;
using Server.DB;
using System.Diagnostics;

namespace Server
{
    public partial class Client
    {
        //private Socket stream;
        //private byte[] bytes;
        ServerDB DB;
        public Client(Socket handler)
        {
            DB = new ServerDB();
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
                    msg = this.Authorization(bytes);    
                    //this.operationComand1();
                    break;
                case 102:
                    msg = this.SendTestList();
                    break;
                case 103:
                    msg = this.SendTestById(bytes);
                    break; 
                default:
                    msg = this.otherComand(bytes);
                    break;
            }
            stream.Send(msg);
            
            //stream.Shutdown(SocketShutdown.Both);
            stream.Close();
        }

        private int getIdOperation(byte[] bytes)
        {
            int res = BitConverter.ToInt32(bytes, 0);
            Console.WriteLine("\nЗапрош прошел:{1}\nКод операции{0}\n", res, DateTime.Now.ToString());
            return res;
        }

        private byte[] otherComand(byte[] bytes)
        {

            //int bytesRec = this.stream.Receive(bytes);
            string data = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            Console.Write("\nПолученный текст: " + data + "\n\n");

            string reply = data.Length.ToString() + "\n\n\0\0\n\n";
            byte[] msg = Encoding.UTF8.GetBytes(reply);
            return msg;
        }

        private byte[] Authorization(byte[] bytes)
        {

            //int bytesRec = this.stream.Receive(this.bytes);
            string json = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            AuthRequest data = new AuthRequest();
            data = JsonConvert.DeserializeObject<AuthRequest>(json);

            int response = 0;
            Console.WriteLine("Попытка авторизироваться \nlogin: {0}\nPass: {1}", data.login, data.password);
           
            /*
             * 
             * работа с бд
             * */
            Account user = DB.Account.Where(x => x.Login == data.login && x.Password == data.password).FirstOrDefault();

            if (user!=null)
            {
                
                response = user.Id;
            }


            Debug.WriteLine("\nвернули токен {0}\n", response);

            byte[] msg = BitConverter.GetBytes(response);
            return msg;
        }

    }
}
