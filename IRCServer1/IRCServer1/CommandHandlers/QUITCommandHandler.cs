namespace IRCServer1.CommandHandlers
{
    using System;
    using Backend;
    using Entities;
    using Entities.Commands;

    /// <summary>
    /// Handles quit commands
    /// </summary>
    internal class QUITCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handlse The Quit Command 
        /// </summary>
        /// <param name="command">The Command that I Will Handle</param>
        /// <param name="session">holds my data</param>
        /// <returns>Reponse to this command</returns>
        public override string HandleCommand(IRCCommandBase command, Session session)
        {
            if (command is QUITCommand)
            {
                QUITCommand quitCommand = (QUITCommand)command;
                ServerBackend.Instance.Users.Remove(session.User);
                session.ConnectionState = ConnectionState.Destroyed;
                ServerBackend.Instance.ClientSessions.Remove(session);
                return string.Empty;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}