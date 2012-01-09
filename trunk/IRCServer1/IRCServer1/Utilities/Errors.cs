namespace IRCServer1.Utilities
{
    using System;

    /// <summary>
    /// Enum That Contains The Types of errors that will occur when you use a command wrong 
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// When you call command without enough parameters.
        /// </summary>
        ERR_NEEDMOREPARAMS,

        /// <summary>
        /// When useing add user command with a person already added.
        /// </summary>
        ERR_ALREADYREGISTERED,

        /// <summary>
        /// When sending a command that isn't knowen for handle class
        /// </summary>
        ERR_UNKNOWNCOMMAND,

        /// <summary>
        /// when sending a command that needs nick name and no nick name is passed , IE:adduser,removeuser
        /// </summary>
        ERR_NONICKNAMEGIVEN,

        /// <summary>
        /// when the nick you chosse is already in use , someone else reservied it
        /// </summary>
        ERR_NICKNAMEINUSE,

        /// <summary>
        /// when sending a privmsg that has no nick to send to
        /// </summary>
        ERR_NORECIPIENT,

        /// <summary>
        /// when using privmsg commadn without a text to send 
        /// </summary>
        ERR_NOTEXTTOSEND,

        /// <summary>
        /// when searching for an nick and you don't find it
        /// </summary>
        ERR_NOSUCHNICK
    }

    /// <summary>
    /// Class Ereor that handles any error may occur in the commands usage
    /// </summary>
    public class Errors
    {
        /// <summary>
        /// need more params error
        /// </summary>
        private const string ERRNEEDMOREPARAMS = "461 {0} :Need more params";

        /// <summary>
        /// already registered error
        /// </summary>       
        private const string ERRALREADYREGISTERED = "462 :You are already registered";

        /// <summary>
        /// Unknowen Command error
        /// </summary>
        private const string ERRUNKNOWNCOMMAND = "404 :Unknown command";

        /// <summary>
        /// No nickname given error
        /// </summary>
        private const string ERRNONICKNAMEGIVEN = "431 :No nickname given";

        /// <summary>
        /// Nickname is already in use error
        /// </summary>
        private const string ERRNICKNAMEINUSE = "433 {0} :Nickname is already in use";

        /// <summary>
        /// No recipient error
        /// </summary>
        private const string ERRNORECIPIENT = "411 :No recipient given ({0})";

        /// <summary>
        /// No text to send error
        /// </summary>
        private const string ERRNOTEXTTOSEND = "412 :No text to send";

        /// <summary>
        /// No such nick error
        /// </summary>
        private const string ERRNOSUCHNICK = "401 {0} :No such nick/channel";

        /// <summary>
        /// Returns string that represent an error
        /// </summary>
        /// <param name="errorCode">the error code which i'll get the string according to</param>
        /// <param name="arguments">the arguments that will have the command will have</param>
        /// <returns>error responde that will be string</returns>
        public static string GetErrorResponse(ErrorCode errorCode, params string[] arguments)
        {
            switch (errorCode)
            {
                case ErrorCode.ERR_NEEDMOREPARAMS:
                    if (arguments.Length != 1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return string.Format(ERRNEEDMOREPARAMS, arguments[0]);
                case ErrorCode.ERR_ALREADYREGISTERED:
                    {
                        return ERRALREADYREGISTERED;
                    }

                case ErrorCode.ERR_UNKNOWNCOMMAND:
                    {
                        return ERRUNKNOWNCOMMAND;
                    }

                case ErrorCode.ERR_NONICKNAMEGIVEN:
                    {
                        return ERRNONICKNAMEGIVEN;
                    }

                case ErrorCode.ERR_NICKNAMEINUSE:
                    {
                        if (arguments.Length != 1)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }

                    return string.Format(ERRNICKNAMEINUSE, arguments[0]);
                case ErrorCode.ERR_NORECIPIENT:
                    {
                        if (arguments.Length != 1)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }

                    return string.Format(ERRNORECIPIENT, arguments[0]);
                case ErrorCode.ERR_NOTEXTTOSEND:
                    {
                        return ERRNOTEXTTOSEND;
                    }

                case ErrorCode.ERR_NOSUCHNICK:
                    {
                        if (arguments.Length != 1)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }

                    return string.Format(ERRNOSUCHNICK, arguments[0]);
                default:
                    {
                        return string.Empty;
                    }
            }
        }
    }
}