namespace IRCPhase2.ServerInterface.Commands
{
    using ServerInterface.CommandHandlers;

    /// <summary>
    /// Add User Command Class
    /// </summary>
    public class ADDUSERCommand : DaemonCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the ADDUSERCommand class.
        /// </summary>
        /// <param name="parameters">The Arguments for this Command</param>
        public ADDUSERCommand(string[] parameters)
        {
            if (parameters.Length > 0)
            {
                this.Message = parameters;
            }
        }

        /// <summary>
        /// Gets or sets the Message for this Command
        /// </summary>
        public string[] Message { get; set; }

        /// <summary>
        /// Executes the ADDUSER Command, and return the Response
        /// </summary>
        /// <returns>The Response for this ADDUSER Command</returns>
        public override string ExecuteCommand()
        {
            return new ADDUSERCommandHandler().HandleCommand(this);
        }
    }
}