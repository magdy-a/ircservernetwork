namespace IRCPhase2.ServerInterface.CommandHandlers
{
    using Backend;
    using Entities;

    /// <summary>
    /// Add User Command Handler
    /// </summary>
    public class ADDUSERCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// It checks if the NickName exists in the Users of the LocalNode, or Exists in any User in any Neighbour and returns NickNameInUse Error, else it returns OK
        /// </summary>
        /// <param name="command">The AddUser Command to Handle</param>
        /// <returns>The AddUser Response for this Command</returns>
        public override string HandleCommand(Commands.DaemonCommandBase command)
        {
            // The Mater Line :):)
            ////return (((Commands.ADDUSERCommand)command).Message.Length < 2) ? Utilities.Responses.GetResponse(Utilities.ResponseCodes.Error) : ((Backend.DaemonBackEnd.Instance.LocalNode.Users.Find(x => x.Nickname.CompareTo(((Commands.ADDUSERCommand)command).Message[1]) == 0) != null || Backend.DaemonBackEnd.Instance.LocalNode.Neighbors.Find(y => y.Users.Find(z => z.Nickname.CompareTo(((Commands.ADDUSERCommand)command).Message[1]) == 0) != null) != null) ? Utilities.Responses.GetResponse(Utilities.ResponseCodes.Error) : Backend.DaemonBackEnd.Instance.AddUserToLocalNode(((Commands.ADDUSERCommand)command).Message[1]));

            if (((Commands.ADDUSERCommand)command).Message.Length < 2)
            {
                // If no nick name was given
                return Utilities.Responses.GetResponse(Utilities.ResponseCodes.Error);
            }
            else
            {
                string nick = ((Commands.ADDUSERCommand)command).Message[1];

                // Search For The Name In AllNodes
                foreach (Node node in DaemonBackEnd.Instance.AllNodes)
                {
                    foreach (User user in node.Users)
                    {
                        if (user.Nickname.CompareTo(nick) == 0)
                        {
                            // Return Error If Th Name Exists
                            return Utilities.Responses.GetResponse(Utilities.ResponseCodes.Error);
                        }
                    }
                }

                // Call The Add Function If All Gose Right
                return Backend.DaemonBackEnd.Instance.AddUserToLocalNode(nick);
            }
        }
    }
}