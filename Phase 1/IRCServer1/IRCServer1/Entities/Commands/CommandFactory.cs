namespace IRCServer1.Entities.Commands
{
    using System;
    using System.Linq;
    using Utilities;

    /// <summary>
    /// Handles The Command Parsing.
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// Returns The Command From A Message
        /// </summary>
        /// <param name="message">the recived message</param>
        /// <param name="session">holds data for my server</param>
        /// <returns>The command created from the Message</returns>
        public static IRCCommandBase GetCommandFromMessage(string message, Session session)
        {
            string[] parameters = Utilities.CommandParser.GetParameters(message);

            if (parameters.Length == 0)
            {
                throw new InvalidOperationException();
            }

            IRCCommandType? type = CommandParser.GetIRCCommandFromString(parameters[0]);

            // Return NULL to indicate UnkownCommand
            if (!type.HasValue)
            {
                return null;
            }

            string[] arguments = parameters.Skip(1).ToArray();

            switch (type.Value)
            {
                case IRCCommandType.NICK:
                    {
                        return new NICKCommand(arguments);
                    }

                case IRCCommandType.USER:
                    {
                        return new USERcommand(arguments);
                    }

                default:
                    break;
            }

            if (session.ConnectionState == ConnectionState.Registered)
            {
                switch (type.Value)
                {
                    case IRCCommandType.PRIVMSG:
                        return new PRIVMSGCommand(arguments);
                    case IRCCommandType.QUIT:
                        return new QUITCommand(arguments);
                    default:
                        // Return NULL to indicate UnkownCommand
                        return null;
                }
            }
            else
            {
                // Return NULL to indicate UnkownCommand
                return null;
            }
        }
    }
}