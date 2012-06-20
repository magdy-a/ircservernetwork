namespace IRCPhase2.Utilities
{
    using System;

    /// <summary>
    /// Responses Codes Enum
    /// </summary>
    public enum ResponseCodes
    {
        /// <summary>
        /// OK Response
        /// </summary>
        OK,

        /// <summary>
        /// NextHop Response
        /// </summary>
        NextHop_OK,

        /// <summary>
        /// User Table OK Response
        /// </summary>
        UserTable_OK,

        /// <summary>
        /// User Entry Response
        /// </summary>
        UserEntry,

        /// <summary>
        /// Error Response
        /// </summary>
        Error,

        /// <summary>
        /// None Response
        /// </summary>
        None
    }

    /// <summary>
    /// Responses Class
    /// </summary>
    public class Responses
    {
        /// <summary>
        /// Response OK Template
        /// </summary>
        private const string RESPONSEOK = "OK";

        /// <summary>
        /// Response NextHop OK Template
        /// </summary>
        private const string RESPONSENEXTHOPOK = "OK {0} {1}";

        /// <summary>
        /// Response UserTable OK Template
        /// </summary>
        private const string RESPONSEUSERTABLEOK = "OK {0}";

        /// <summary>
        /// Response UserEntry Template
        /// </summary>
        private const string RESPONSEUSERENTRY = "{0} {1} {2}";

        /// <summary>
        /// Response Error Template
        /// </summary>
        private const string RESPONSEERROR = "ERROR";

        /// <summary>
        /// Response NONE Template
        /// </summary>
        private const string RESPONSENONE = "NONE";

        /// <summary>
        /// Create a Response from a Response Template, and it's values
        /// </summary>
        /// <param name="response">Response Type</param>
        /// <param name="arguments">Arguments to use in the Template</param>
        /// <returns>The Result Response</returns>
        public static string GetResponse(ResponseCodes response, params string[] arguments)
        {
            switch (response)
            {
                case ResponseCodes.NextHop_OK:
                    if (arguments.Length != 2)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return string.Format(RESPONSENEXTHOPOK, arguments[0], arguments[1]);
                case ResponseCodes.UserTable_OK:
                    if (arguments.Length != 1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return string.Format(RESPONSEUSERTABLEOK, arguments[0]);
                case ResponseCodes.UserEntry:
                    if (arguments.Length != 3)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return string.Format(RESPONSEUSERENTRY, arguments[0], arguments[1], arguments[2]);
                case ResponseCodes.OK:
                    return RESPONSEOK;
                case ResponseCodes.Error:
                    return RESPONSEERROR;
                case ResponseCodes.None:
                    return RESPONSENONE;
                default:
                    return String.Empty;
            }
        }
    }
}