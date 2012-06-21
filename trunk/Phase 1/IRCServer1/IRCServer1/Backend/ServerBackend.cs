namespace IRCServer1.Backend
{
    using System.Collections.Generic;
    using Entities;

    /// <summary>
    /// Where I Mange The Server Data Such as : Users,Sessions,etc
    /// </summary>    
    public class ServerBackend
    {       
        /// <summary>
        /// An Object Of ServerBackend To Use Within The Code 
        /// </summary>
        private static ServerBackend instance;

        /// <summary>
        /// Prevents a default instance of the ServerBackend class from being created
        /// </summary>
        private ServerBackend()
        {
        }

        /// <summary>
        /// Gets Server Data For Me To Use 
        /// </summary>
        public static ServerBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerBackend();
                    instance.Users = new List<Entities.User>();
                    instance.ClientSessions = new List<Entities.Session>();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the client sessions.
        /// </summary>
        /// <value>
        /// The client sessions.
        /// </value>
        public List<Session> ClientSessions { get; set; }

        /// <summary>
        /// Gets or sets The User Of The Server To Use
        /// </summary>
        public List<Entities.User> Users { get; set; }
                        
        /// <summary>
        /// Returns The Session Of A Certain User.
        /// </summary>
        /// <param name="target">The Nick Name Of The Usre That I Want To Return The Session Of</param>
        /// <returns>Session For A Certain User</returns>
        public Session GetUserSession(string target)
        {
            for (int i = 0; i < this.ClientSessions.Count; i++)
            {
                if (this.ClientSessions[i].User.Nickname == target && this.ClientSessions[i].ConnectionState == ConnectionState.Registered)
                {
                    return this.ClientSessions[i];
                }
            }

            return null;
        }
    }
}