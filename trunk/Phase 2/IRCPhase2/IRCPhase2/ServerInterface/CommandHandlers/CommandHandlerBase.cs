namespace IRCPhase2.ServerInterface.CommandHandlers
{
    using System.Collections.Generic;
    using Backend;
    using Commands;
    using Entities;

    /// <summary>
    /// The Base Class of all Commands
    /// </summary>
    public abstract class CommandHandlerBase
    {
        /// <summary>
        /// The local Node for this RoutingDaemon
        /// </summary>
        private static Node local = DaemonBackEnd.Instance.LocalNode;

        /// <summary>
        /// The Neighbour Daemons for this Node
        /// </summary>
        private static List<Node> neighbours = DaemonBackEnd.Instance.LocalNode.Neighbors;

        /// <summary>
        /// The abstract Function for the command to handle it
        /// </summary>
        /// <param name="command">The Command to Handle</param>
        /// <returns>The Response for this Response</returns>
        public abstract string HandleCommand(DaemonCommandBase command);
    }
}