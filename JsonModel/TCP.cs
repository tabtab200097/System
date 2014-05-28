using System;
using System.Collections.Generic;

using System.Text;
using System.Net;
using System.Net.Sockets;
using JsonModel;
using Newtonsoft.Json;

namespace JsonModel
{
    public class TCP
    {
        private string hostname = "localhost";
        private int port = 30000;

        private byte[] SendMessage(int idOperation, byte[] msg)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(hostname);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(ipEndPoint);

            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());

            byte[] data = BitConverter.GetBytes(idOperation);
            sender.Send(data);
            int dataRec = sender.Receive(data);
            Console.WriteLine("\nтут должен быть окай: {0}\n\n", Encoding.UTF8.GetString(data, 0, dataRec));

            byte[] answer = new byte[4096];
            int bytesSent = sender.Send(msg);
            int bytesRec = sender.Receive(answer);


            //Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(answer, 0, bytesRec));

            //sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            return answer;
        }

        public TCP(string server,int port)
        {
            this.hostname = server;
            this.port = port;
        }

        public int Authorization(string login, string password)
        {
            int result = 0;
            AuthRequest request = new AuthRequest();
            request.login = login;
            request.password = password;
            string json = JsonConvert.SerializeObject(request, Formatting.Indented);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(json/*.ToString()*/);
            byte[] response = SendMessage(1, data);
            result = BitConverter.ToInt32(response, 0);
            return result;
        }

        public string SendSimpleText(string message)
        {
            if (message.Length == 0)
                return "Ничего не прошло, выкинуло";
            byte [] data = System.Text.Encoding.UTF8.GetBytes(message);
            byte [] responsedata = SendMessage(0,data);
            string response = System.Text.Encoding.UTF8.GetString(responsedata, 0, responsedata.Length);
            return response;
        }

        public List<JsonTestList> GetTestList()
        {
            byte[] responsedata = SendMessage(102, System.Text.Encoding.UTF8.GetBytes("ок"));
            string json = Encoding.UTF8.GetString(responsedata, 0, responsedata.Length);
            List<JsonTestList> data = JsonConvert.DeserializeObject<List<JsonTestList>>(json);
            return data;
        }

        public JsonTest GetTestById(int id)
        {
            byte[] responsedata = SendMessage(103, BitConverter.GetBytes(id));
            string json = Encoding.UTF8.GetString(responsedata, 0, responsedata.Length);
            JsonTest data = JsonConvert.DeserializeObject<JsonTest>(json);
            return data;
        }

        public List<JsonUserResult> CheckMyAnswersPleeease(JsonUserTest answers)
        {
            string json = JsonConvert.SerializeObject(answers);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(json);
            byte[] responsedata = SendMessage(104, data);
            string json2 = Encoding.UTF8.GetString(responsedata, 0, responsedata.Length);
            List<JsonUserResult> result = JsonConvert.DeserializeObject<List<JsonUserResult>>(json2);
            return result;

        }

    }
}
