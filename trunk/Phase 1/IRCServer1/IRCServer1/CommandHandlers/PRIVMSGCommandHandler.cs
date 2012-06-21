namespace IRCServer1.CommandHandlers
{
    using System;
    using System.Text;
    using Backend;
    using Entities;
    using Entities.Commands;
    using Utilities;

    /// <summary>
    /// Handles privmsg command
    /// </summary>
    internal class PRIVMSGCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handlse The PRIVMSG Command 
        /// </summary>
        /// <param name="command">The Command that I Will Handle</param>
        /// <param name="session">holds my data</param>
        /// <returns>Reponse to this command</returns>
        public override string HandleCommand(IRCCommandBase command, Session session)
        {
            string[] nickNames;

            if (command is PRIVMSGCommand)
            {
                PRIVMSGCommand privMsgCommand = (PRIVMSGCommand)command;

                // No Receipient
                if (privMsgCommand.Params.Length == 0)
                {
                    return Errors.GetErrorResponse(ErrorCode.ERR_NORECIPIENT, IRCCommandType.PRIVMSG.ToString());
                }

                // NO Text To Send
                if (privMsgCommand.Params.Length == 1)
                {
                    return Errors.GetErrorResponse(ErrorCode.ERR_NOTEXTTOSEND, null);
                }

                nickNames = privMsgCommand.Nick.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < nickNames.Length; i++)
                {
                    Session tmpSession = ServerBackend.Instance.GetUserSession(nickNames[i]);

                    // NoSuchNick Error
                    if (tmpSession == null)
                    {
                        ////return Errors.GetErrorResponse(ErrorCode.ERR_NOSUCHNICK, IRCCommandType.PRIVMSG.ToString());
                        return Errors.GetErrorResponse(ErrorCode.ERR_NOSUCHNICK, new string[] { nickNames[i] });
                    }
                }

                // If Passed Successfully, send
                for (int i = 0; i < nickNames.Length; i++)
                {
                    Session tmpSession = ServerBackend.Instance.GetUserSession(nickNames[i]);

                    // Send with Sync, it doesn't matter
                    tmpSession.Socket.Send(Encoding.ASCII.GetBytes(":" + session.User.Nickname + " PRIVMSG :" + privMsgCommand.Message));
                }

                ////ServerBackend.Instance.SendMessage(tmpSession, privMsgCommand.Message);
                return "OK";
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}