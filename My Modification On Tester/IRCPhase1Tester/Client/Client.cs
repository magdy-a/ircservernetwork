using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace IRCPhase1Tester.Client
{
    public class Client
    {
        Socket clientSocket;

        public Socket ClientSocket
        {
            get { return clientSocket; }
            set { clientSocket = value; }
        }

        public Client(int portNumber)
        {
            Console.WriteLine("Starting the IRC Client...");

            string IP = "127.0.0.1";

            clientSocket = new Socket(AddressFamily.InterNetwork,
              SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), portNumber);

            clientSocket.Connect(iep);
        }

        public string Receive()
        {
            byte[] buffer = new byte[1024];
            int numOfBytes = clientSocket.Receive(buffer);
            return System.Text.Encoding.ASCII.GetString(buffer.Take(numOfBytes).ToArray());
        }

        public void Send(string message)
        {
            clientSocket.Send(System.Text.Encoding.ASCII.GetBytes(message));
        }

        public void Close()
        {
            clientSocket.Close();
        }
    }
}
