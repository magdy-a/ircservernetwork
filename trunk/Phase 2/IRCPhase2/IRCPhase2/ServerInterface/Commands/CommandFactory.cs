namespace IRCPhase2.ServerInterface.Commands
{
    using Utilities;

    /// <summary>
    /// CommandFactory Class
    /// </summary>
    internal class CommandFactory
    {
        /// <summary>
        /// Creates a Command form a CommandString
        /// </summary>
        /// <param name="message">The CommandString</param>
        /// <returns>The Command generated from the String</returns>
        public static DaemonCommandBase GetCommandFromMessage(string message)
        {
            string[] parameters = Utilities.CommandParser.GetParameters(message);

            if (parameters.Length == 0)
            {
                return new UNKNOWNCommand();
            }

            switch (CommandParser.GetIRCCommandFromString(parameters[0]))
            {
                case DaemonCommandType.ADDUSER:
                    return new ADDUSERCommand(parameters);
                case DaemonCommandType.REMOVEUSER:
                    return new REMOVEUSERCommand(parameters);
                case DaemonCommandType.NEXTHOP:
                    return new NEXTHOPCommand(parameters);
                case DaemonCommandType.USERTABLE:
                    return new USERTABLECommand(parameters);
                default:
                    return new UNKNOWNCommand();
            }
        }
    }
}