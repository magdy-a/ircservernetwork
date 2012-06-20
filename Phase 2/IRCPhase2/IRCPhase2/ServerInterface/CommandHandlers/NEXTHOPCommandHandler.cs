namespace IRCPhase2.ServerInterface.CommandHandlers
{
    using Backend;
    using Commands;
    using Entities;

    /// <summary>
    /// Next Hop Command Handler Class
    /// </summary>
    public class NEXTHOPCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handle the Command of the NextHop Command
        /// </summary>
        /// <param name="command">Command to Handle</param>
        /// <returns>The Respone for this command</returns>
        public override string HandleCommand(DaemonCommandBase command)
        {
            string nickName;

            // Check for noNick Error
            if (((NEXTHOPCommand)command).Message.Length < 2)
            {
                return Utilities.Responses.GetResponse(Utilities.ResponseCodes.Error);
            }

            // Get the NickName
            nickName = ((NEXTHOPCommand)command).Message[1];

            // Get the Node that carries that nickName
            Node carrier = DaemonBackEnd.Instance.AllNodes.Find(node => node.Users.Find(user => user.Nickname.CompareTo(nickName) == 0) != null);

            // If there was no carrier, return null entry, else: get the entry from the routingTable
            RoutingTableEntry entry = carrier == null ? null : DaemonBackEnd.Instance.RoutingTable.Find(table => table.Node == carrier);

            // If the entry was null, return None, else: return the NextHopResponse for this nickName
            return (entry == null) ? Utilities.Responses.GetResponse(Utilities.ResponseCodes.None) : Utilities.Responses.GetResponse(Utilities.ResponseCodes.NextHop_OK, entry.NextHopResponse);
        }
    }
}