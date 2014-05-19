﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Net.Sockets;
using JsonModel;
using Newtonsoft.Json;

namespace Client
{
    class TCP
    {
        string hostname;
        int port;
        TcpClient clientConnect;
        NetworkStream streamConnect;
        int sizeBuffer = 4096;

        public TCP(string server,int port)
        {
            this.hostname = server;
            this.port = port;
        }

        private void startConect()
        {
             this.clientConnect = new TcpClient(this.hostname, this.port);
             this.streamConnect = this.clientConnect.GetStream();
        }

        private void closeConnect()
        {
            this.streamConnect.Close();
            this.clientConnect.Close();  
        }
        
        public int Autorisation(string login, string password)
        {
            int result = 0;
            Comand1 zapros = new Comand1();
            zapros.login = login;
            zapros.password = password;
            string json = JsonConvert.SerializeObject(zapros, Formatting.Indented);
            this.startConect();


            Byte[] data;
            data = BitConverter.GetBytes(1);
            streamConnect.Write(data, 0, data.Length);
            streamConnect.Read(data, 0, data.Length); ;
            data = System.Text.Encoding.UTF8.GetBytes(json.ToString());

            streamConnect.Write(data, 0, data.Length);


            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            data = new Byte[sizeBuffer];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = streamConnect.Read(data, 0, data.Length);
            result = BitConverter.ToInt32(data, 0);


            return result;
        }
      
        public void SendMessage(string message) 
        {
            if (message.Length == 0)
                return;
            this.startConect();

            // Send the message to the connected TcpServer.

            Byte[] data;
            data = BitConverter.GetBytes(message.Length*10);
            
            streamConnect.Write(data, 0, data.Length);
            
            streamConnect.Read(data, 0, data.Length);;


            data = System.Text.Encoding.UTF8.GetBytes(message.ToString());
                
                
            streamConnect.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);

            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            data = new Byte[sizeBuffer];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = streamConnect.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            // Close everything.
            //stream.Close(); 
            this.closeConnect();
        }
    }
}
