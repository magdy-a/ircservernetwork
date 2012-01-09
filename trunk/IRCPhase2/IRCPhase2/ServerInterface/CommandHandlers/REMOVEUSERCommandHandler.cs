namespace IRCPhase2.ServerInterface.CommandHandlers
{
    using Backend;
    using Commands;
    using Entities;

    /// <summary>
    /// Remove User Command Handler Class
    /// </summary>
    public class REMOVEUSERCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// It Checks for the user if it exists in the Server, if Yes, Remove it from the my users List
        /// </summary>
        /// <param name="command">The RemoveUser Command to Handle</param>
        /// <returns>The Response for the RemoveUser Command</returns>
        public override string HandleCommand(DaemonCommandBase command)
        {
            string nickName;
            User tmpUser;

            if (((Commands.REMOVEUSERCommand)command).Message.Length < 2)
            {
                return Utilities.Responses.GetResponse(Utilities.ResponseCodes.Error);
            }

            nickName = ((Commands.REMOVEUSERCommand)command).Message[1];

            if ((tmpUser = DaemonBackEnd.Instance.LocalNode.Users.Find(x => x.Nickname.CompareTo(nickName) == 0)) != null)
            {
                DaemonBackEnd.Instance.LocalNode.Users.Remove(tmpUser);

                return Utilities.Responses.GetResponse(Utilities.ResponseCodes.OK);
            }
            else
            {
                return Utilities.Responses.GetResponse(Utilities.ResponseCodes.Error);
            }
        }
    }
}