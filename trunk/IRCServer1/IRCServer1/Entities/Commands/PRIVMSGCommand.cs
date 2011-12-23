using IRCServer1.CommandHandlers;

namespace IRCServer1.Entities.Commands
{
    internal class PRIVMSGCommand : IRCCommandBase
    {
        public PRIVMSGCommand(string[] parameters)
            : base(parameters)
        {
            Params = parameters;

            if (parameters.Length > 0)
            {
                Nick = parameters[0];

                if (parameters.Length > 1)
                {
                    Message = parameters[1];
                }
            }
        }

        public string Nick { get; set; }

        public string Message { get; set; }

        public string[] Params { get; set; }

        public override string ExecuteCommand(Session session)
        {
            PRIVMSGCommandHandler handler = new PRIVMSGCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}