using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using IRCServer1.Backend;
using IRCServer1.Entities;
using IRCServer1.Entities.Commands;
using IRCServer1.Utilities;

namespace IRCServer1
{
    internal class IRCServer1 : IServer
    {
        Socket server;

        int port;

        #region IServer Members

        public IRCServer1(int port)
        {
            this.port = port;
        }

        /// <summary>
        /// Starting server bind and listen
        /// </summary>
        public void Start()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
            server.Listen(1000);
            WaitForConnections();
        }

        /// <summary>
        /// Wating For Any Connection From users (clients).
        /// </summary>
        public void WaitForConnections()
        {
            server.BeginAccept(new AsyncCallback(AcceptConnection), server);
        }

        /// <summary>
        /// When a client is connected and begins the receive function and writes "Connected To Client" .
        /// </summary>
        /// <param name="result">IAsyncResult</param>
        public void AcceptConnection(IAsyncResult result)
        {
            Socket tmpClient = null;

            try
            {
                tmpClient = server.EndAccept(result);
            }
            catch
            {
                WaitForConnections();
                return;
            }

            WaitForConnections();

            Session tmpSession = new Session();
            tmpSession.Socket = tmpClient;

            ServerBackend.Instance.ClientSessions.Add(tmpSession);

            tmpClient.BeginReceive(tmpSession.Buffer, 0, tmpSession.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCommand), tmpSession);
        }

        public void ReceiveCommand(IAsyncResult result)
        {
            Session tmpSession = (Session)result.AsyncState;

            string reply;

            int msgRcv = 0;

            try
            {
                msgRcv = tmpSession.Socket.EndReceive(result);
            }
            catch
            {
                // Set msgRcv to 0, to assure that it will close
                msgRcv = 0;
            }

            if (msgRcv == 0)
            {
                try
                {
                    tmpSession.Socket.Close();
                    tmpSession.ConnectionState = ConnectionState.Destroyed;
                }
                catch
                {
                }

                return;
            }

            // Loop Receive
            tmpSession.Socket.BeginReceive(tmpSession.Buffer, 0, tmpSession.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCommand), tmpSession);

            // Execute
            IRCCommandBase command = CommandFactory.GetCommandFromMessage(Encoding.ASCII.GetString(tmpSession.Buffer, 0, msgRcv), tmpSession);

            if (command == null)
            {
                // Err_UnkownCommand
                reply = Errors.GetErrorResponse(ErrorCode.ERR_UNKNOWNCOMMAND, null);
            }
            else
            {
                reply = command.ExecuteCommand(tmpSession);
            }

            // Send Server's Reply
            tmpSession.Socket.BeginSend(Encoding.ASCII.GetBytes(reply), 0, reply.Length, SocketFlags.None, new AsyncCallback(FinalizeSending), tmpSession);
        }

        public void FinalizeSending(IAsyncResult result)
        {
            Session tmpSession = (Session)result.AsyncState;

            try
            {
                tmpSession.Socket.EndSend(result);
            }
            catch
            {
            }
        }

        #endregion IServer Members
    }
}