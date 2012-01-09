namespace IRCPhase2.Entities
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using Backend;
    using IRC.Utilities;
    using ServerInterface.Commands;

    /// <summary>
    /// IRCServer Class
    /// </summary>
    public class IRCServer
    {
        /// <summary>
        /// Max Buffer Size for the Receiving Buffer
        /// </summary>
        private const int MAXCOMMANDSIZE = 1024;

        /// <summary>
        /// The IRCServer Socket to Connect to
        /// </summary>
        private Socket ircServerSocket;

        /// <summary>
        /// The Buffer to use in Receiving Commands
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// Initializes a new instance of the IRCServer class.
        /// </summary>
        /// <param name="daemonSocket">The Socket to connect to</param>
        public IRCServer(Socket daemonSocket)
        {
            this.ircServerSocket = daemonSocket.Accept();
            IRCLogger.IRClog(string.Format("Server Binded Localport : {0} ,With IP :{1}", ((IPEndPoint)this.ircServerSocket.LocalEndPoint).Port, this.ircServerSocket.RemoteEndPoint.ToString()));
        }

        /// <summary>
        /// Wait for Server's Connections
        /// </summary>
        public void StartServer()
        {
            try
            {
                DaemonCommandBase tmpCommand;

                while (true)
                {
                    tmpCommand = this.ReceiveCommand();

                    // Check if message is null, then the server is disconnected
                    if (tmpCommand == null)
                    {
                        break;
                    }

                    // Send the NextHopResponse back to the IRCServer
                    this.SendResponse(tmpCommand.ExecuteCommand());

                    DaemonBackEnd.Instance.UpdateRoutingTable();
                }
            }
            catch (Exception ex)
            {
                IRCLogger.IRClog(ex);
            }
        }

        /// <summary>
        /// Send the NextHopResponse to the IRCServer
        /// </summary>
        /// <param name="response">The Response to send to the Server</param>
        public void SendResponse(string response)
        {
            // Writing Respone in Log
            Logger.Instance.Warn(string.Format("Sending NextHopResponse to IRC server :: {0}", response));
            IRCLogger.IRClog(string.Format("Sending NextHopResponse to ircServer :: {0}", response));

            this.ircServerSocket.Send(Encoding.ASCII.GetBytes(response));
        }

        /// <summary>
        /// Receive a command from the IRC Server
        /// </summary>
        /// <returns>The Command Received from the Server</returns>
        public DaemonCommandBase ReceiveCommand()
        {
            // Initialize the buffer
            this.buffer = new byte[MAXCOMMANDSIZE];

            // Receive the Command
            int length = this.ircServerSocket.Receive(this.buffer);

            // IRC server terminated connection
            if (length == 0)
            {
                return null;
            }

            Logger.Instance.Warn(string.Format("Received command {0} from IRC server.", Encoding.ASCII.GetString(this.buffer, 0, length)));
            IRCLogger.IRClog(string.Format("Received command {0} from IRC server.", Encoding.ASCII.GetString(this.buffer, 0, length)));

            // Initialize with null
            return CommandFactory.GetCommandFromMessage(Encoding.ASCII.GetString(this.buffer, 0, length));
        }
    }
}