namespace IRCServer1.CommandHandlers
{
    using Entities;
    using Entities.Commands;

    /// <summary>
    /// Handles Commands
    /// </summary>
    internal abstract class CommandHandlerBase
    {
        /// <summary>
        /// Handlse The Command s
        /// </summary>
        /// <param name="command">The Command that I Will Handle</param>
        /// <param name="session">holds my data</param>
        /// <returns>Reponse to this command</returns>
        public abstract string HandleCommand(IRCCommandBase command, Session session);

        /// <summary>
        /// Update the user state when reciving user or nick command
        /// </summary>
        /// <param name="session">holds my data</param>
        protected void UpdateConnectionState(Session session)
        {
            if (session.User != null && session.User.Username != null && session.User.Nickname != null)
            {
                session.ConnectionState = ConnectionState.Registered;
            }
        }
    }
}