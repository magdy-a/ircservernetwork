using IRCServer1.CommandHandlers;

namespace IRCServer1.Entities.Commands
{
    internal class USERcommand : IRCCommandBase
    {
        public USERcommand(string[] parameters)
            : base(parameters)
        {
            if (parameters.Length > 0)
            {
                Message = parameters;
            }
        }

        public string[] Message { get; set; }

        public override string ExecuteCommand(Session session)
        {
            USERCommandHandler handler = new USERCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}