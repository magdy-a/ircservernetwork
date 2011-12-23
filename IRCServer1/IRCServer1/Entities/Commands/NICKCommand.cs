using IRCServer1.CommandHandlers;

namespace IRCServer1.Entities.Commands
{
    /// <summary>
    /// Nick Command Class
    /// </summary>
    public class NICKCommand : IRCCommandBase
    {
        public NICKCommand(string[] parameters) :
            base(parameters)
        {
            if (parameters.Length > 0)
            {
                // Get the Desired Nick Name
                this.Message = parameters[0];
            }
        }

        public string Message { get; set; }

        public override string ExecuteCommand(Session session)
        {
            NICKCommandHandler handler = new NICKCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}