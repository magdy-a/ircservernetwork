namespace IRCPhase2.ServerInterface.Commands
{
    using ServerInterface.CommandHandlers;

    /// <summary>
    /// Next Hop Command Class
    /// </summary>
    public class NEXTHOPCommand : DaemonCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the NEXTHOPCommand class.
        /// </summary>
        /// <param name="parameters">The Arguments for this Command</param>
        public NEXTHOPCommand(string[] parameters)
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
        /// Executes the Unknown Command, and return the Response
        /// </summary>
        /// <returns>The Response for this NEXTHOP Command</returns>
        public override string ExecuteCommand()
        {
            return new NEXTHOPCommandHandler().HandleCommand(this);
        }
    }
}