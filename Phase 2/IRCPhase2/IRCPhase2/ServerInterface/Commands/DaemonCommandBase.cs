namespace IRCPhase2.ServerInterface.Commands
{
    /// <summary>
    /// DaemonCommandBase Class
    /// </summary>
    public abstract class DaemonCommandBase
    {
        /// <summary>
        /// Executes the Command, and Creates a Response for it
        /// </summary>
        /// <returns>The Response for this Command</returns>
        public abstract string ExecuteCommand();
    }
}