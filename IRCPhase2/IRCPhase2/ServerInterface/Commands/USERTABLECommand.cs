namespace IRCPhase2.ServerInterface.Commands
{
    /// <summary>
    /// User Table Command Class
    /// </summary>
    public class USERTABLECommand : DaemonCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the USERTABLECommand class.
        /// </summary>
        /// <param name="parameters">The Arguments for this Command</param>
        public USERTABLECommand(string[] parameters)
        {
            if (parameters.Length > 0)
            {
                this.Message = parameters;
            }
        }

        /// <summary>
        /// Gets or sets the Message args for this Command
        /// </summary>
        public string[] Message { get; set; }

        /// <summary>
        /// Executes the USERTABLE Command, and return the Response
        /// </summary>
        /// <returns>The Response for this USERTABLE Command</returns>
        public override string ExecuteCommand()
        {
            return new CommandHandlers.USERTABLECommandHandler().HandleCommand(this);
        }
    }
}