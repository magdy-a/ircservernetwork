namespace IRCPhase2.Backend
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Entities;
    using IRC.Utilities;
    using IRC.Utilities.Entities;

    /// <summary>
    /// Routing Daemon Backend
    /// </summary>
    public class DaemonBackEnd
    {
        /// <summary>
        /// The Default Version number
        /// </summary>
        private const int DefaultVersion = 1;

        /// <summary>
        /// The Default Time To Live number
        /// </summary>
        private const int DefaultTTL = 32;

        /// <summary>
        /// Static instance (Singleton).
        /// </summary>
        private static DaemonBackEnd instance;

        /// <summary>
        /// The List that carries all nodes in the network
        /// </summary>
        private List<Node> allNodes;

        /// <summary>
        /// Prevents a default instance of the DaemonBackEnd class from being created.
        /// </summary>
        private DaemonBackEnd()
        {
            this.allNodes = new List<Node>();
            this.LocalNode = new Node();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static DaemonBackEnd Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DaemonBackEnd();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets The List that carries all nodes in the network
        /// </summary>
        public List<Node> AllNodes
        {
            get { return this.allNodes; }
        }

        /// <summary>
        /// Gets or sets the local node.
        /// </summary>
        /// <value>
        /// The local node.
        /// </value>
        public Node LocalNode { get; set; }

        /// <summary>
        /// Gets or sets the routing table.
        /// </summary>
        /// <value>
        /// The routing table.
        /// </value>
        public List<RoutingTableEntry> RoutingTable { get; set; }

        /// <summary>
        /// Gets or sets the configuration of the local node.
        /// </summary>
        /// <value>
        /// The configuration of the node.
        /// </value>
        public List<NodeConfiguration> Configuration { get; set; }

        /// <summary>
        /// Updates the routing table using Dijkstra.
        /// </summary>
        public void UpdateRoutingTable()
        {
            DijkstraMapper mapper = new DijkstraMapper(this.allNodes);
            mapper.Run();
            this.RoutingTable = mapper.GetRoutingTable();
        }

        /// <summary>
        /// Gets the node by ID. If the node doesn't exist it creates it.
        /// </summary>
        /// <param name="nodeID">The node ID.</param>
        /// <returns>The Node object.</returns>
        public Node GetNodeByID(int nodeID)
        {
            Node node = this.allNodes.Find(n => n.NodeID == nodeID);

            if (node == null)
            {
                node = new Node() { NodeID = nodeID };
                this.allNodes.Add(node);
            }

            return node;
        }

        /// <summary>
        /// Updates the network with a newly received LSA (Link State Announcement).
        /// </summary>
        /// <param name="lsa">The LSA to Update the BackEnd with</param>
        /// <returns>Null on successful update, and an LSA if the sequence number is older than the latest received from that sender.</returns>
        public LSA UpdateBackEndWithLSA(LSA lsa)
        {
            Node senderNode = this.GetNodeByID(lsa.SenderNodeID);

            LSA returnLSA = null;

            // Check if incoming LSA's SequenceNumber is older or newer
            if (lsa.SequenceNumber < senderNode.LastSequenceNumber)
            {
                // LSA is old, Send Back The New LSA
                returnLSA = this.GetNewLSA(lsa);
            }
            else if (lsa.SequenceNumber > senderNode.LastSequenceNumber)
            {
                string users = string.Empty;

                // New LSA with New Users
                if (lsa.Users.Count > 0)
                {
                    lsa.Users.ForEach(user => users += user.Nickname);
                    Logger.Instance.Warn(string.Format("Received LSA with Users Count > 0 from Node {0}, Users :: {1}", lsa.SenderNodeID, users));
                    IRCLogger.IRClog(string.Format("Received LSA with Users Count > 0 from Node {0}, Users :: {1}", lsa.SenderNodeID, users));
                }

                // Overwrite the Node's Data with the new LSA
                senderNode.Neighbors = lsa.Links;
                senderNode.Users = lsa.Users;
                senderNode.LastUpdateTime = DateTime.Now;
                senderNode.LastSequenceNumber = lsa.SequenceNumber;

                // Update the Routing Table
                this.UpdateRoutingTable();
            }

            return returnLSA;
        }

        /// <summary>
        /// Configures the local node using the info in the configuration file.
        /// </summary>
        /// <param name="configuration">The configuration loaded from the configuration file.</param>
        public void ConfigureLocalNode(List<NodeConfiguration> configuration)
        {
            Node tmpNeighbour;

            this.LocalNode.Configuration = configuration.Find(x => x.NodeID == this.LocalNode.NodeID);

            this.allNodes.Add(this.LocalNode);

            foreach (NodeConfiguration config in configuration)
            {
                if (config.NodeID != this.LocalNode.NodeID)
                {
                    tmpNeighbour = new Node()
                    {
                        NodeID = config.NodeID,
                        Configuration = config
                    };

                    this.LocalNode.Neighbors.Add(tmpNeighbour);

                    this.allNodes.Add(tmpNeighbour);
                }
            }

            this.UpdateRoutingTable();
        }

        /// <summary>
        /// Gets the local node LSA.
        /// </summary>
        /// <returns>The LSA of the local node.</returns>
        public LSA GetLocalNodeLSA()
        {
            return new LSA()
            {
                Version = DefaultVersion,
                TTL = DefaultTTL,
                Type = LSAType.Advertisement,
                SenderNodeID = this.LocalNode.NodeID,
                SequenceNumber = this.LocalNode.LastSequenceNumber,
                Users = this.LocalNode.Users,
                Links = this.LocalNode.Neighbors
            };
        }

        /// <summary>
        /// Create a new LSA from an old one
        /// </summary>
        /// <param name="oldLSA">The Old LSA</param>
        /// <returns>The New LSA</returns>
        public LSA GetNewLSA(LSA oldLSA)
        {
            // Get the Sender Node
            Node senderNode = this.GetNodeByID(oldLSA.SenderNodeID);

            return new LSA()
            {
                Version = DefaultVersion,
                TTL = DefaultTTL,
                Type = oldLSA.Type,
                Links = senderNode.Neighbors,
                Users = senderNode.Users,
                SenderNodeID = oldLSA.SenderNodeID,
                SequenceNumber = senderNode.LastSequenceNumber
            };
        }

        /// <summary>
        /// Adds a user to the local Node, and return the NextHopResponse OK
        /// </summary>
        /// <param name="nickName">The Nick name to add</param>
        /// <returns>The NextHopResponse OK</returns>
        public string AddUserToLocalNode(string nickName)
        {
            this.LocalNode.Users.Add(new User() { Nickname = nickName });
            return Utilities.Responses.GetResponse(Utilities.ResponseCodes.OK);
        }

        /// <summary>
        /// Searches the Configuration Files for the Node that contains the same Port
        /// </summary>
        /// <param name="endPoint">EndPoint that carries the Port for the desired Node</param>
        /// <returns>NodeID for this endPoint</returns>
        public NodeConfiguration GetConfigFromEndPoint(EndPoint endPoint)
        {
            return this.GetConfigFromEndPoint(((IPEndPoint)endPoint).Port);
        }

        /// <summary>
        /// Searches the Configuration Files for the Node that contains the same Port
        /// </summary>
        /// <param name="port">Port of the desired Node</param>
        /// <returns>NodeID for this Configuration port</returns>
        public NodeConfiguration GetConfigFromEndPoint(int port)
        {
            return this.Configuration.Find(config => config.RoutingPort == port);
        }

        /// <summary>
        /// Gets all nodes.
        /// </summary>
        /// <param name="rootNode">The root node.</param>
        /// <returns>List of all nodes mapped.</returns>
        private List<Node> GetAllNodes(Node rootNode)
        {
            return null;
        }

        /// <summary>
        /// Explores the node recursively updating the list of nodes.
        /// </summary>
        /// <param name="node">The node to explore.</param>
        /// <param name="nodes">The nodes list to update.</param>
        private void ExploreNode(Node node, List<Node> nodes)
        {
        }
    }
}