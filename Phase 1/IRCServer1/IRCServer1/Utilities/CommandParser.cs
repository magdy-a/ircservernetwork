namespace IRCServer1.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

/// <summary>
/// Contains Types of commands that can be recived
/// </summary>
    public enum IRCCommandType
    {
        /// <summary>
        /// The user command type
        /// </summary>
        USER,

        /// <summary>
        /// The nick command type
        /// </summary>
        NICK,

        /// <summary>
        /// The quit command type
        /// </summary>
        QUIT,

        /// <summary>
        /// The privmsg command type
        /// </summary>
        PRIVMSG
    }

    /// <summary>
    /// Handles Sprateing a command into parts to ease the use and classfy it.
    /// </summary>
    public static class CommandParser
    {
        /// <summary>
        /// Conatins user string format 
        /// </summary>
        public const string USERCommand = "USER";

        /// <summary>
        /// Conatins nick string format 
        /// </summary>
        public const string NICKCommand = "NICK";

        /// <summary>
        /// Conatins quit string format 
        /// </summary>
        public const string QUITCommand = "QUIT";

        /// <summary>
        /// Conatins privmsg string format 
        /// </summary>
        public const string PRIVMSGCommand = "PRIVMSG";

        /// <summary>
        /// Returns The Parameters from the message string
        /// </summary>
        /// <param name="message">The recived command message</param>
        /// <returns>array of strings that will be the parts of the command</returns>
        public static string[] GetParameters(string message)
        {
            string[] colonSplit = message.Split(new char[] { ':' });

            if (colonSplit.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            string[] spaceSplit = colonSplit[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (spaceSplit.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return spaceSplit.Concat(colonSplit.Except(new List<string>() { colonSplit[0] })).ToArray();
        }

         /// <summary>
         /// Returns the command type from the string command that I have sent can be null
         /// </summary>
         /// <param name="command">string that is the command I'm Sending To Classfy</param>
         /// <returns>Type of command</returns>
        public static IRCCommandType? GetIRCCommandFromString(string command)
        {
            string commandUpperCase = command.ToUpper();

            switch (commandUpperCase)
            {
                case USERCommand:
                    return IRCCommandType.USER;
                case NICKCommand:
                    return IRCCommandType.NICK;
                case QUITCommand:
                    return IRCCommandType.QUIT;
                case PRIVMSGCommand:
                    return IRCCommandType.PRIVMSG;
                default:
                    return null;
            }
        }
    }
}