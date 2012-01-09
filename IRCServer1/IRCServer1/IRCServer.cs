namespace IRCServer1
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using Backend;
    using Entities;
    using Entities.Commands;
    using Utilities;
    
    /// <summary>
    /// This is the server class that is used with inhartance of IServer
    /// </summary> 
    internal class IRCServer1 : IServer
    {
        /// <summary>
        /// The Socket That The Server Will Connect To
        /// </summary>
        private Socket server;

        /// <summary>
        /// The Port That Is Used To Bind Function In The Server
        /// </summary>
        private int port;

        #region IServer Members
        /// <summary>
        /// Initializes a new instance of the IRCServer1 class with port number
        /// </summary>
        /// <param name="port">the port number that will be used in this class</param>
        public IRCServer1(int port)
        {
            this.port = port;
        }

        /// <summary>
        /// Starting server bind and listen
        /// </summary>
        public void Start()
        {
           this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
           this.server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.port));
           this.server.Listen(1000);
           this.WaitForConnections();
        }

        /// <summary>
        /// Wating For Any Connection From users (clients).
        /// </summary>
        public void WaitForConnections()
        {
            this.server.BeginAccept(new AsyncCallback(this.AcceptConnection), this.server);
        }

        /// <summary>
        /// When a client is connected and begins the receive function and writes "Connected To Client" .
        /// </summary>
        /// <param name="result">IAsyncResult That Will Be Used For The Call Back</param>
        public void AcceptConnection(IAsyncResult result)
        {
            Socket tmpClient = null;

            try
            {
                tmpClient = this.server.EndAccept(result);
            }
            catch
            {
                this.WaitForConnections();
                return;
            }

            this.WaitForConnections();

            Session tmpSession = new Session();
            tmpSession.Socket = tmpClient;

            ServerBackend.Instance.ClientSessions.Add(tmpSession);

            tmpClient.BeginReceive(tmpSession.Buffer, 0, tmpSession.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveCommand), tmpSession);
        }

        /// <summary>
        /// Recives Command From The Server And Sends Reply Executes It And Send Responde If Command Is Not Null And Still Recives 
        /// </summary>
        /// <param name="result">IAsyncResult Will Be Used For The Call Back</param>
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
            tmpSession.Socket.BeginReceive(tmpSession.Buffer, 0, tmpSession.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReceiveCommand), tmpSession);

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

            // Begins Send From Sockets Using The GetBytes And Calls Back With FinalizeSending
            tmpSession.Socket.BeginSend(Encoding.ASCII.GetBytes(reply), 0, reply.Length, SocketFlags.None, new AsyncCallback(this.FinalizeSending), tmpSession);
        }

        /// <summary>
        /// This Function Is A Call Back That Ends The Sending And Closes The Socket
        /// </summary>
        /// <param name="result">IAsyncResult result That Is Used For The Call Backs</param>
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