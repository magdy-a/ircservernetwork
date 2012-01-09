namespace IRCPhase2.ServerInterface.CommandHandlers
{
    /// <summary>
    /// Unkown Command Handler Class
    /// </summary>
    public class UNKNOWNCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handles Unknown Command
        /// </summary>
        /// <param name="command">The Unknown Command to Handle</param>
        /// <returns>The Response for the Unknown Command</returns>
        public override string HandleCommand(Commands.DaemonCommandBase command)
        {
            return "Unknown Command";
        }
    }
}