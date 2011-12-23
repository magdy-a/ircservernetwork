using System;
using System.Text;
using IRCServer1.Backend;
using IRCServer1.Entities;
using IRCServer1.Entities.Commands;
using IRCServer1.Utilities;

namespace IRCServer1.CommandHandlers
{
    internal class PRIVMSGCommandHandler : CommandHandlerBase
    {
        public override string HandleCommand(IRCCommandBase command, Session session)
        {
            string[] NickNames;

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

                NickNames = privMsgCommand.Nick.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < NickNames.Length; i++)
                {
                    Session tmpSession = ServerBackend.Instance.GetUserSession(NickNames[i]);

                    // NoSuchNick Error
                    if (tmpSession == null)
                    {
                        //return Errors.GetErrorResponse(ErrorCode.ERR_NOSUCHNICK, IRCCommandType.PRIVMSG.ToString());
                        return Errors.GetErrorResponse(ErrorCode.ERR_NOSUCHNICK, new string[] { NickNames[i] });
                    }
                }

                // If Passed Successfully, send
                for (int i = 0; i < NickNames.Length; i++)
                {
                    Session tmpSession = ServerBackend.Instance.GetUserSession(NickNames[i]);

                    // Send with Sync, it doesn't matter
                    tmpSession.Socket.Send(Encoding.ASCII.GetBytes(":" + session.User.Nickname + " PRIVMSG :" + privMsgCommand.Message));
                }

                //ServerBackend.Instance.SendMessage(tmpSession, privMsgCommand.Message);
                return "OK";
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}