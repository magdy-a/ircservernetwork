namespace IRCPhase2.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Daemon Command Type Enum
    /// </summary>
    public enum DaemonCommandType
    {
        /// <summary>
        /// Add User Command
        /// </summary>
        ADDUSER,

        /// <summary>
        /// Remove User Command
        /// </summary>
        REMOVEUSER,

        /// <summary>
        /// NextHop Command
        /// </summary>
        NEXTHOP,

        /// <summary>
        /// User Table Command
        /// </summary>
        USERTABLE,

        /// <summary>
        /// Known Command
        /// </summary>
        UNKNOWN
    }

    /// <summary>
    /// The Command Parser Class
    /// </summary>
    public static class CommandParser
    {
        /// <summary>
        /// Get Parameters Function, Extracts the Parameters from an incoming Command
        /// </summary>
        /// <param name="message">The command to extract parameters from</param>
        /// <returns>Parameters in string[]</returns>
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
        /// Creates an IRCCommand From a CommandString
        /// </summary>
        /// <param name="command">The CommandString to Extract Command From</param>
        /// <returns>The Command Created from the Command String</returns>
        public static DaemonCommandType GetIRCCommandFromString(string command)
        {
            try
            {
                return (DaemonCommandType)Enum.Parse(typeof(DaemonCommandType), command.ToUpper());
            }
            catch
            {
                return DaemonCommandType.UNKNOWN;
            }
        }
    }
}