namespace IRCPhase2.ServerInterface.Commands
{
    /// <summary>
    /// Unknown Command Class
    /// </summary>
    public class UNKNOWNCommand : DaemonCommandBase
    {
        /// <summary>
        /// Executes the UNKOWNCommand Command, and return the Response
        /// </summary>
        /// <returns>The Response for this Unknown Command</returns>
        public override string ExecuteCommand()
        {
            return new ServerInterface.CommandHandlers.UNKNOWNCommandHandler().HandleCommand(this);
        }
    }
}