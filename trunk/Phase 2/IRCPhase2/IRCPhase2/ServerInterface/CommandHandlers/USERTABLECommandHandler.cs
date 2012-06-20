namespace IRCPhase2.ServerInterface.CommandHandlers
{
    using System;
    using System.Collections.Generic;
    using Backend;
    using Entities;
    using IRC.Utilities;
    using Utilities;

    /// <summary>
    /// User Table Command Handler Class
    /// </summary>
    public class USERTABLECommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handles the USERTABLE Command
        /// </summary>
        /// <param name="command">The command To Handle it</param>
        /// <returns>The Response for this Command</returns>
        public override string HandleCommand(Commands.DaemonCommandBase command)
        {
            List<Node> exculsiveAllNodes;
            RoutingTableEntry tmpEntry = null;

            string result;
            List<string> lines = new List<string>();

            int counter = 0;

            // Get all nodes except me
            exculsiveAllNodes = DaemonBackEnd.Instance.AllNodes.FindAll(node => node.NodeID != DaemonBackEnd.Instance.LocalNode.NodeID);

            foreach (Node node in exculsiveAllNodes)
            {
                tmpEntry = DaemonBackEnd.Instance.RoutingTable.Find(entry => entry.Node.NodeID == node.NodeID);

                if (tmpEntry == null)
                {
                    // Log TmpEntry = NULL
                    Logger.Instance.Error(string.Format("When getting RoutingEntry for Node: {0} it returned null", node.NodeID.ToString()));
                    IRCLogger.IRClog(string.Format("When getting RoutingEntry for Node: {0} it returned null", node.NodeID.ToString()));
                    continue;
                }

                foreach (User user in node.Users)
                {
                    lines.Add("\node" + Responses.GetResponse(ResponseCodes.UserEntry, user.Nickname, tmpEntry.NextHop != null ? tmpEntry.NextHop.NodeID.ToString() : tmpEntry.Node.NodeID.ToString(), tmpEntry.Distance.ToString()));

                    counter++;
                }
            }

            result = Responses.GetResponse(Utilities.ResponseCodes.UserTable_OK, counter.ToString());
            lines.ForEach(line => result += line);

            // Log the UserTable
            Logger.Instance.Warn(string.Format("User Table ::: {1}{0}", Environment.NewLine, result));
            IRCLogger.IRClog(string.Format("User Table ::: {1}{0}", Environment.NewLine, result));

            return result;
        }
    }
}