using IRCServer1.Entities;
using IRCServer1.Entities.Commands;

namespace IRCServer1.CommandHandlers
{
    internal abstract class CommandHandlerBase
    {
        public abstract string HandleCommand(IRCCommandBase command, Session session);

        protected void UpdateConnectionState(Session session)
        {
            if (session.User != null && session.User.Username != null && session.User.Nickname != null)
            {
                session.ConnectionState = ConnectionState.Registered;
            }
        }
    }
}