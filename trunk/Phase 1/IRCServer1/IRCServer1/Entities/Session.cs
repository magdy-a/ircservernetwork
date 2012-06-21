namespace IRCServer1.Entities
{
    using System.Net.Sockets;

    /// <summary>
    /// handles the type of the user connection
    /// </summary>
    public enum ConnectionState
    {
        /// <summary>
        /// The State when a user sends a user command without nick or the oppsite
        /// </summary>
        NotRegistered,

        /// <summary>
        /// when a user compelete the registertion by having nick and user name 
        /// </summary>
        Registered,

        /// <summary>
        /// when a user quits 
        /// </summary>
        Destroyed
    }

    /// <summary>
    /// The class which holds current data 
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Initializes a new instance of the Session class,and sets the connection state to NotRegistered,Init my Buffer for the data
        /// </summary>
        public Session()
        {
            this.ConnectionState = Entities.ConnectionState.NotRegistered;
            this.Buffer = new byte[1024];
        }

        /// <summary>
        /// Gets or sets the clientID
        /// </summary>
        public int ClientID { get; set; }

        /// <summary>
        /// Gets or sets user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets Socket
        /// </summary>
        public Socket Socket { get; set; }

        /// <summary>
        /// Gets or sets ConnectionState
        /// </summary>
        public ConnectionState ConnectionState { get; set; }

        /// <summary>
        /// Gets or sets Buffer
        /// </summary>
        public byte[] Buffer { get; set; }
    }
}