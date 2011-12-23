using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCServer1.CommandHandlers;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;



namespace IRCServer1.Entities.Commands
{
    class USERcommand : IRCCommandBase
    {
        public string cumulativeREALNAME;
        public string ErrorMsg = "";
        public USERcommand(string[] parameters)
            : base(parameters)
        {
            if (parameters.Length > 4)
            {
                for (int i = 3; i < parameters.Length; i++)
                    if (parameters[i].Contains(" : "))
                    {
                        for (int j = i; j < parameters.Length; j++)
                        {
                            cumulativeREALNAME += parameters[j];

                        }
                        parameters[i] = cumulativeREALNAME;
                        break;
                    }
            }
            else
            { 
            
              //display the number of parameters error
                ErrorMsg = "461 USER:Need More Params";
                
            }
        }
        public override string ExecuteCommand(Session session)
        {
            USERCommandHandler handler = new USERCommandHandler();
            return handler.HandleCommand(this, session);
        }
    }
}
