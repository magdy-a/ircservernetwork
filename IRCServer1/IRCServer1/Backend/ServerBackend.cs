using System.Collections.Generic;
using IRCServer1.Entities;

namespace IRCServer1.Backend
{
    public class ServerBackend
    {
        private static ServerBackend instance;

        private ServerBackend() { }

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

        public Session GetUserSession(string target)
        {
            for (int i = 0; i < ClientSessions.Count; i++)
            {
                if (ClientSessions[i].User.Nickname == target && ClientSessions[i].ConnectionState == ConnectionState.Registered)
                {
                    return ClientSessions[i];
                }
            }

            return null;
        }

        public List<Entities.User> Users { get; set; }

        /// <summary>
        /// Gets or sets the client sessions.
        /// </summary>
        /// <value>
        /// The client sessions.
        /// </value>
        public List<Session> ClientSessions { get; set; }
    }
}