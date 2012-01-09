namespace IRCPhase2.Entities
{
    using Backend;

    /// <summary>
    /// RoutingTableEntry Class
    /// </summary>
    public class RoutingTableEntry
    {
        /// <summary>
        /// Gets or sets the Node for this Routing Table
        /// </summary>
        public Node Node { get; set; }

        /// <summary>
        /// Gets or sets the NextHop for this Routing Table Entry
        /// </summary>
        public Node NextHop { get; set; }

        /// <summary>
        /// Gets or sets the Distance for this Routing Table Entry
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Gets the Next Hop for this Routing Table Entry
        /// </summary>
        public string[] NextHopResponse
        {
            get
            {
                return new string[] { (this.NextHop != null) ? this.NextHop.NodeID.ToString() : this.Node.NodeID.ToString(), this.Distance.ToString() };
            }
        }

        /// <summary>
        /// Create an Entry for a specific User
        /// </summary>
        /// <param name="nickName">The NickName for the User</param>
        /// <returns>Routing Table Entry Containing that NickName</returns>
        public static RoutingTableEntry GetEntry(string nickName)
        {
            // Get the Node that carries that nickName
            Node carrier = DaemonBackEnd.Instance.AllNodes.Find(node => node.Users.Find(user => user.Nickname.CompareTo(nickName) == 0) != null);

            // If there was no carrier, return null entry, else: get the entry from the routingTable
            return carrier == null ? null : DaemonBackEnd.Instance.RoutingTable.Find(table => table.Node == carrier);
        }
    }
}