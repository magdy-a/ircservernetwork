namespace IRCServer1.Entities.Commands
{
    /// <summary>
    /// Handles Command Classfying used to be iharted from
    /// </summary>
    public abstract class IRCCommandBase
    {
        /// <summary>
        /// Initializes a new instance of the IRCCommandBase class.
        /// </summary>
        /// <param name="parameters">Message parts</param>
        public IRCCommandBase(string[] parameters)
        {
        }

        /// <summary>
        /// executes command will be inharted
        /// </summary>
        /// <param name="session">holds data for my server</param>
        /// <returns>the command respoance</returns>
        public abstract string ExecuteCommand(Session session);
    }
}