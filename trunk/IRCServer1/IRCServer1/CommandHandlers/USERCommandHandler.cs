using System;
using IRCServer1.Backend;
using IRCServer1.Entities;
using IRCServer1.Entities.Commands;
using IRCServer1.Utilities;

namespace IRCServer1.CommandHandlers
{
    internal class USERCommandHandler : CommandHandlerBase
    {
        public override string HandleCommand(IRCCommandBase command, Session session)
        {
            if (command is USERcommand)
            {
                USERcommand userCommand = (USERcommand)command;

                // Need more Params
                if (userCommand.Message.Length != 4)
                {
                    return Utilities.Errors.GetErrorResponse(Utilities.ErrorCode.ERR_NEEDMOREPARAMS, IRCCommandType.USER.ToString());
                }

                // Already Registered
                if (session.User != null && session.User.Realname != null)
                {
                    return Utilities.Errors.GetErrorResponse(Utilities.ErrorCode.ERR_ALREADYREGISTERED, null);
                }

                // If Object isn't created yet, create one
                if (session.User == null)
                {
                    session.User = new User();
                    ServerBackend.Instance.Users.Add(session.User);
                }

                session.User.Username = userCommand.Message[0];
                session.User.Hostname = userCommand.Message[1];
                session.User.Realname = userCommand.Message[3];

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