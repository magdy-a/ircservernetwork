namespace IRCServer1
{
    using System;

    /// <summary>
    /// Interface Class That Will Have Abstract Methods For The Server To Inharet From
    /// </summary>
    public interface IServer
    {
        /// <summary>
        /// Starts the server.
        /// </summary>
        void Start();

        /// <summary>
        /// Waits asynchronously for any client connections.
        /// </summary>
        void WaitForConnections();

        /// <summary>
        /// Accepts a client connection, and waits asynchronously for commands from the accepted client.
        /// </summary>
        /// <param name="result">IAsyncResult That Is Used For The Callback</param>
        void AcceptConnection(IAsyncResult result);

        /// <summary>
        /// Receives a command from a client, executes it and sends response to the client.
        /// </summary>
        /// <param name="result">IAsyncResult That Is Used For The Callback</param>
        void ReceiveCommand(IAsyncResult result);

        /// <summary>
        /// Finalizes sending the response to the client.
        /// </summary>
        /// <param name="result">IAsyncResult That Is Used For The Callback</param>
        void FinalizeSending(IAsyncResult result);
    }
}