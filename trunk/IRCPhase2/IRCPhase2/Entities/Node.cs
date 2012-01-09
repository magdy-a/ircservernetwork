namespace IRCPhase2.Entities
{
    using System;
    using System.Collections.Generic;
    using IRC.Utilities.Entities;

    /// <summary>
    /// Node Class, Carries the data concerning the Node that carries the RoutingDaemon and IRCServer
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        public Node()
        {
            this.Neighbors = new List<Node>();
            this.Users = new List<User>();
            this.LastUpdateTime = DateTime.Now;
            this.LastSequenceNumber = 0;
        }

        /// <summary>
        /// Gets or sets The Node ID for this Node
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// Gets or sets The Last Seq Num received for this Node
        /// </summary>
        public int LastSequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Node is Ack or Not
        /// </summary>
        public bool IsAcknowledged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Node Is Down or Not
        /// </summary>
        public bool IsDown { get; set; }

        /// <summary>
        /// Gets or sets List of Neighbours in this Node's RoutingDaemon
        /// </summary>
        public List<Node> Neighbors { get; set; }

        /// <summary>
        /// Gets or sets List of Users I have in this Node's IRCServer
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Gets or sets The Configuration loaded in the startup for this Node
        /// </summary>
        public NodeConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets or sets The Last Update time for the Node
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// Check for Equality between two Nodes
        /// </summary>
        /// <param name="obj">The Object to Check Equality with</param>
        /// <returns>Return the result of Equality Condition</returns>
        public override bool Equals(object obj)
        {
            return ((Node)obj).NodeID == this.NodeID;
        }
    }
}