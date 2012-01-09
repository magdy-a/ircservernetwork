namespace IRCServer1.Entities.Commands
{
    using CommandHandlers;

    /// <summary>
    /// Handles User Command
    /// </summary>
    internal class USERcommand : IRCCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the USERcommand class.
        /// </summary>
        /// <param name="parameters">User Message Command Parts</param>
        public USERcommand(string[] parameters)
            : base(parameters)
        {
            if (parameters.Length > 0)
            {
                this.Message = parameters;
            }
        }

        /// <summary>
        /// Gets or sets message of the command
        /// </summary>
        public string[] Message { get; set; }

        /// <summary>
        /// Hanles The execution of Usre command
        /// </summary>
        /// <param name="session">holds my data</param>
        /// <returns>the server responde to this command</returns>
        public override string ExecuteCommand(Session session)
        {
            USERCommandHandler handler = new USERCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}