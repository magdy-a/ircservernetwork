namespace IRCServer1.Entities.Commands
{
    using CommandHandlers;

    /// <summary>
    /// Handles Quit Command
    /// </summary>
    internal class QUITCommand : IRCCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the QUITCommand class.
        /// </summary>
        /// <param name="parameters">Quit Message Command Parts</param>
        public QUITCommand(string[] parameters) :
            base(parameters)
        {
            if (parameters.Length > 0)
            {
                this.Message = parameters[0];
            }
        }

        /// <summary>
        /// Gets or sets message of the command
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Hanles The execution of Quit command
        /// </summary>
        /// <param name="session">holds my data</param>
        /// <returns>the server responde to this command</returns>
        public override string ExecuteCommand(Session session)
        {
            QUITCommandHandler handler = new QUITCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}