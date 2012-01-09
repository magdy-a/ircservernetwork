namespace IRCServer1.Entities.Commands
{
    using CommandHandlers;

    /// <summary>
    /// Nick Command Class
    /// </summary>
    public class NICKCommand : IRCCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the NICKCommand class.
        /// </summary>
        /// <param name="parameters">Nick Message Command Parts</param>
        public NICKCommand(string[] parameters) :
            base(parameters)
        {
            if (parameters.Length > 0)
            {
                // Get the Desired Nick Name
                this.Message = parameters[0];
            }
        }

        /// <summary>
        /// Gets or sets the command messgae
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Hanles The execution of nick command
        /// </summary>
        /// <param name="session">holds my data</param>
        /// <returns>the server responde to this command</returns>
        public override string ExecuteCommand(Session session)
        {
            NICKCommandHandler handler = new NICKCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}