using System;
using System.Collections.Generic;
using System.Text;
using IRCServer1.Entities.Commands;
using IRCServer1.Entities;
using IRCServer1.Utilities;
using IRCServer1.Backend;
using System.Threading;

namespace IRCServer1.CommandHandlers
{
    class USERCommandHandler : CommandHandlerBase
    {
        public string errormsg = "";
      public override string HandleCommand(IRCCommandBase command, Session session)
        {
            if (command is USERcommand)
            {
                if(ServerBackend.Instance.Users.Contains(session.User)
                {
                  //user is already registered
                    errormsg = "462: You Are Already Registered";
                    return errormsg;

              }

                else
                {

                USERcommand usercommand = (USERcommand)command;
                ServerBackend.Instance.Users.Add(session.User);
                session.ConnectionState = ConnectionState.Registered;
                ServerBackend.Instance.ClientSessions.Add(session);
                return String.Empty;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
