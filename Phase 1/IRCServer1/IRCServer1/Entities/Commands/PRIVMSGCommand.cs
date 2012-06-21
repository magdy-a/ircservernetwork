namespace IRCServer1.Entities.Commands
{
    using CommandHandlers;

    /// <summary>
    /// Handles Privmsg Command
    /// </summary>
    internal class PRIVMSGCommand : IRCCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the PRIVMSGCommand class.
        /// </summary>
        /// <param name="parameters">PRIVMSG Message Command Parts</param>
        public PRIVMSGCommand(string[] parameters)
            : base(parameters)
        {
            this.Params = parameters;

            if (parameters.Length > 0)
            {
                this.Nick = parameters[0];

                if (parameters.Length > 1)
                {
                    this.Message = parameters[1];
                }
            }
        }

        /// <summary>
        /// Gets or sets user nick name
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// Gets or sets message of the command
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets parts of the commands (message parts)
        /// </summary>
        public string[] Params { get; set; }

        /// <summary>
        /// Hanles The execution of PRIVMSG command
        /// </summary>
        /// <param name="session">holds my data</param>
        /// <returns>the server responde to this command</returns>
        public override string ExecuteCommand(Session session)
        {
            PRIVMSGCommandHandler handler = new PRIVMSGCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}