using System;
using IRCServer1.Backend;
using IRCServer1.Entities;
using IRCServer1.Entities.Commands;

namespace IRCServer1.CommandHandlers
{
    internal class QUITCommandHandler : CommandHandlerBase
    {
        public override string HandleCommand(IRCCommandBase command, Session session)
        {
            if (command is QUITCommand)
            {
                QUITCommand quitCommand = (QUITCommand)command;
                ServerBackend.Instance.Users.Remove(session.User);
                session.ConnectionState = ConnectionState.Destroyed;
                ServerBackend.Instance.ClientSessions.Remove(session);
                return String.Empty;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}