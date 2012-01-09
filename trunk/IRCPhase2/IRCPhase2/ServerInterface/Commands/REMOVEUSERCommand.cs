namespace IRCPhase2.ServerInterface.Commands
{
    using ServerInterface.CommandHandlers;

    /// <summary>
    /// Remove User Command Class
    /// </summary>
    public class REMOVEUSERCommand : DaemonCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the REMOVEUSERCommand class.
        /// </summary>
        /// <param name="parameters">The Arguments for this Command</param>
        public REMOVEUSERCommand(string[] parameters)
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
        /// Executes the REMOVEUSER Command, and return the Response
        /// </summary>
        /// <returns>The Response for this REMOVEUSER Command</returns>
        public override string ExecuteCommand()
        {
            return new REMOVEUSERCommandHandler().HandleCommand(this);
        }
    }
}