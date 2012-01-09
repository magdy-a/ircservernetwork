namespace IRCServer1.CommandHandlers
{
    using System;
    using Backend;
    using Entities;
    using Entities.Commands;

    /// <summary>
    /// The Handler of the Nick Command
    /// </summary>
    internal class NICKCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handlse The nick Command 
        /// </summary>
        /// <param name="command">The Command that I Will Handle</param>
        /// <param name="session">holds my data</param>
        /// <returns>Reponse to this command</returns>
        public override string HandleCommand(IRCCommandBase command, Session session)
        {
            if (command is NICKCommand)
            {
                // Convert to Nick Command Object
                NICKCommand nickCommand = (NICKCommand)command;

                // Check if ERR_NONICKNAMEGIVEN, if no nick name given
                if (nickCommand.Message == null)
                {
                    return Utilities.Errors.GetErrorResponse(Utilities.ErrorCode.ERR_NONICKNAMEGIVEN, null);
                }

                // Check if ERR_NICKNAMEINUSE, if the Nick Name is already in the Server
                foreach (User u in ServerBackend.Instance.Users)
                {
                    //// If the user (which is not me), has the same Nick Name, Ignore
                   ////if (nickCommand.Message.CompareTo(u.Nickname) == 0)
                    if (nickCommand.Message == u.Nickname)
                    {
                        return Utilities.Errors.GetErrorResponse(Utilities.ErrorCode.ERR_NICKNAMEINUSE, u.Nickname);
                    }
                }

                // If Object isn't created yet, create one
                if (session.User == null)
                {
                    session.User = new User();
                    ServerBackend.Instance.Users.Add(session.User);
                }

                // If no errors throwed, accept the command
                session.User.Nickname = nickCommand.Message;

                // IF Client isn't registered, update it's connection state, then add it to the clientSessions
                if (session.ConnectionState != ConnectionState.Registered)
                {
                    UpdateConnectionState(session);
                }

                return "OK";
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}