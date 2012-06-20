namespace IRCPhase2
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Backend;
    using Entities;
    using IRC.Utilities;
    using IRC.Utilities.Entities;
    using Utilities;

    /// <summary>
    /// IRCPhase2 Class
    /// </summary>
    public class IRCPhase2
    {
        #region ConstData

        /// <summary>
        /// Size of the ByteArr
        /// </summary>
        private const int MAXMESSAGESIZE = 1024;

        /// <summary>
        /// Number of mili-seconds in each second, used in Thread.Sleep()
        /// </summary>
        private const int Second = 1000;

        /// <summary>
        /// The Advertisement Cycle Time, Which is used in Broadcasting the LSA, Thread.Sleep()
        /// </summary>
        private const int AdvertisementCycleTime = 30 * Second;

        /// <summary>
        /// Time for the Neighbor to retransmit the LSA, otherwise it should be marked as Down
        /// </summary>
        private const int NeighborTimeout = 120 * Second;

        /// <summary>
        /// Resending the LSA every RetransmissionTimeout for non responding neighbor
        /// </summary>
        private const int RetransmissionTimeout = 3 * Second;

        #endregion ConstData

        /// <summary>
        /// Socket that talks with the IRC Server, on local port
        /// </summary>
        private Socket daemonTCPSocket;

        /// <summary>
        /// Socket that talks with other Daemons, on routing port
        /// </summary>
        private Socket daemonUDPSocket;

        /// <summary>
        /// Just the IRC Server
        /// </summary>
        private IRCServer ircServer;

        /// <summary>
        /// Initializes a new instance of the <see cref="IRCPhase2"/> class.
        /// </summary>
        /// <param name="routingPort">The UDP port on the routing daemon used to exchange routing information with other routing daemons.</param>
        /// <param name="localPort">The TCP port on the routing daemon that is used to exchange information between it and the local IRC server.</param>
        public IRCPhase2(int routingPort, int localPort)
        {
            try
            {
                Logger.Instance.Debug("Initializing Routing Daemon Sockets");
                IRCLogger.IRClog("Initializing Routing Daemon Sockets");

                // Initialize the socket that will wait for commands from the local IRC server.
                this.daemonTCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.daemonTCPSocket.Bind(new IPEndPoint(IPAddress.Any, localPort));

                // Initialize the socket that will communicate with other routing daemon nodes.
                this.daemonUDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                this.daemonUDPSocket.Bind(new IPEndPoint(IPAddress.Any, routingPort));
            }
            catch (Exception ex)
            {
                IRCLogger.IRClog(ex);
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            this.daemonTCPSocket.Listen(10);

            // I don't want to start with thread here, to block the program until it accepts an ircServer connection, then continues the rest
            new Thread(new ThreadStart(this.WaitForIRCServerConnection)).Start();

            // Start a thread waiting to receive LSAs
            new Thread(new ThreadStart(this.WaitForLSAs)).Start();

            // Start a thread that sends LSAs every 30 seconds
            new Thread(new ThreadStart(this.BroadcastLSA)).Start();

            // Start a thread that checks for down neighbor
            new Thread(new ThreadStart(this.MarkNeighborAsDown)).Start();
        }

        /// <summary>
        /// Waits for IRC server connections.
        /// </summary>
        private void WaitForIRCServerConnection()
        {
            try
            {
                while (true)
                {
                    // The Constructor in IRCServer wait for the connection
                    this.ircServer = new IRCServer(this.daemonTCPSocket);

                    // Start a Thread of the Server
                    this.ircServer.StartServer();
                }
            }
            catch (Exception ex)
            {
                IRCLogger.IRClog(ex);
            }
        }

        /// <summary>
        /// Waits for routing daemon connections.
        /// </summary>
        private void WaitForLSAs()
        {
            try
            {
                EndPoint neighbourEndPoint;
                LSA neighbourPackage;
                int neighbourID;
                Node senderNode;
                NodeConfiguration tmpConfig;

                // Initialize the data Array just once, every time I read the length I need only
                byte[] data = new byte[MAXMESSAGESIZE];
                byte[] flood;
                int msgRcv;

                while (true)
                {
                    msgRcv = 0;

                    neighbourEndPoint = new IPEndPoint(IPAddress.Any, 0);

                    try
                    {
                        // Recieve from any Neighbour
                        msgRcv = this.daemonUDPSocket.ReceiveFrom(data, ref neighbourEndPoint);
                    }
                    catch
                    {
                        msgRcv = 0;
                    }

                    // If nothing recieved, continue
                    if (msgRcv == 0)
                    {
                        continue;
                    }

                    // Get the LSA
                    neighbourPackage = LSAUtility.CreateLSAFromByteArray(data);

                    // Neighbour Node
                    senderNode = DaemonBackEnd.Instance.GetNodeByID(neighbourPackage.SenderNodeID);

                    // Condition of New Neighbour, cause the routingPort doesn't exist in my configuration
                    // Neighbour NodeID
                    tmpConfig = DaemonBackEnd.Instance.GetConfigFromEndPoint(neighbourEndPoint);
                    if (tmpConfig == null)
                    {
                        Logger.Instance.Warn(string.Format("[WaitForLSAs] New Connection from Node {0}", senderNode.NodeID));
                        IRCLogger.IRClog(string.Format("[WaitForLSAs] New Connection from Node {0}", senderNode.NodeID));

                        tmpConfig = new NodeConfiguration() { RoutingPort = ((IPEndPoint)neighbourEndPoint).Port, NodeID = neighbourPackage.SenderNodeID };
                        DaemonBackEnd.Instance.GetNodeByID(neighbourPackage.SenderNodeID).Configuration = tmpConfig;
                        DaemonBackEnd.Instance.LocalNode.Neighbors.Add(DaemonBackEnd.Instance.GetNodeByID(neighbourPackage.SenderNodeID));
                        DaemonBackEnd.Instance.UpdateRoutingTable();
                    }

                    neighbourID = tmpConfig.NodeID;

                    if (neighbourPackage.SequenceNumber == senderNode.LastSequenceNumber)
                    {
                        // INFO : [WaitForLSAs] LSA of Node 2 is duplicate. Ignoring it.
                        Logger.Instance.Info(string.Format("[WaitForLSAs] LSA of Node {0} is duplicate. Ignoring it.", neighbourPackage.SenderNodeID));
                        IRCLogger.IRClog(string.Format("[WaitForLSAs] LSA of Node {0} is duplicate. Ignoring it.", neighbourPackage.SenderNodeID));
                        continue;
                    }

                    // INFO : [WaitForLSAs] Received LSA from Node: 3 via Node: 3
                    Logger.Instance.Info(string.Format("[WaitForLSAs] Received LSA from Node: {0} via Node: {1}", neighbourPackage.SenderNodeID, neighbourID));
                    IRCLogger.IRClog(string.Format("[WaitForLSAs] Received LSA from Node: {0} via Node: {1}", neighbourPackage.SenderNodeID, neighbourID));

                    // Is Down Check
                    if (senderNode.IsDown)
                    {
                        // Mark as Up
                        senderNode.IsDown = false;

                        // TODO check this update if true or false
                        DaemonBackEnd.Instance.UpdateRoutingTable();

                        // TODO : Check if this stat is true
                        // senderNode.LastUpdateTime = DateTime.Now;

                        // WARN : [WaitForLSAs] Node 2 is back up!
                        Logger.Instance.Warn(string.Format("[WaitForLSAs] Node {0} is back up!", senderNode.NodeID));
                        IRCLogger.IRClog(string.Format("[WaitForLSAs] Node {0} is back up!", senderNode.NodeID));
                    }

                    // Check LSA Type
                    switch (neighbourPackage.Type)
                    {
                        case LSAType.Acknowledgement:

                            // Mark as Ack
                            senderNode.IsAcknowledged = true;

                            senderNode.LastUpdateTime = DateTime.Now;

                            // INFO : [WaitForLSAs] Received Acknowledgment from Node: 3
                            Logger.Instance.Info(string.Format("[WaitForLSAs] Received Acknowledgment from Node: {0}", senderNode.NodeID));
                            IRCLogger.IRClog(string.Format("[WaitForLSAs] Received Acknowledgment from Node: {0}", senderNode.NodeID));

                            break;
                        case LSAType.Advertisement:

                            // Update Backend, and reutrn an LSA, if this one was older than mine
                            LSA newLSA = DaemonBackEnd.Instance.UpdateBackEndWithLSA(neighbourPackage);

                            // If the LSA was old, return the new one
                            if (newLSA != null)
                            {
                                // INFO : [WaitForLSAs] Received Out Of Sequence LSA from Node: 2
                                Logger.Instance.Info(string.Format("[WaitForLSAs] Received Out Of Sequence LSA from Node: {0}", senderNode.NodeID));
                                IRCLogger.IRClog(string.Format("[WaitForLSAs] Received Out Of Sequence LSA from Node: {0}", senderNode.NodeID));

                                // LSA was old, send back the new one
                                this.daemonUDPSocket.SendTo(LSAUtility.GetByteArrayFromLSA(newLSA), neighbourEndPoint);
                            }
                            else
                            {
                                // LSA is new, Send Back the Ack
                                daemonUDPSocket.SendTo(LSAUtility.CreateAckLSAFromLSA(neighbourPackage), neighbourEndPoint);

                                // INFO : [WaitForLSAs] Sent ACK LSA to Node: 3
                                Logger.Instance.Info(string.Format("[WaitForLSAs] Sent ACK LSA to Node: {0}", neighbourID));
                                IRCLogger.IRClog(string.Format("[WaitForLSAs] Sent ACK :{0} EndPoint: {1}, #LSA: {2}", neighbourPackage.ToString(), neighbourEndPoint.ToString(), neighbourPackage.SequenceNumber));

                                // Flood the LSA
                                flood = LSAUtility.GetByteArrayFromLSA(neighbourPackage);

                                DaemonBackEnd.Instance.LocalNode.Neighbors.FindAll(neighbour => neighbour.NodeID != neighbourID && neighbour.NodeID != neighbourPackage.SenderNodeID && neighbour.IsDown == false).ForEach(upNeighbour => daemonUDPSocket.SendTo(flood, (EndPoint)upNeighbour.Configuration.GetNodeEndPoint()));

                                // INFO : [WaitForLSAs] Flooding LSA from Node 2 to Node: 3
                                Logger.Instance.Info(string.Format("[WaitForLSAs] Flooding LSA from Node {0} to Node: {1}", neighbourPackage.SenderNodeID, neighbourID));
                                IRCLogger.IRClog(string.Format("[WaitForLSAs] Flood LSA :{0} EndPoint: {1}, #LSA: {2}", neighbourPackage.SenderNodeID.ToString(), neighbourEndPoint.ToString(), neighbourPackage.SequenceNumber));
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                IRCLogger.IRClog(ex);
            }
        }

        /// <summary>
        /// Broadcasts the local LSA to all neighbors.
        /// </summary>
        private void BroadcastLSA()
        {
            try
            {
                while (true)
                {
                    DaemonBackEnd.Instance.LocalNode.LastSequenceNumber++;
                    DaemonBackEnd.Instance.LocalNode.LastUpdateTime = DateTime.Now;

                    // DEBUG: [BroadcastLSA] Initializing...
                    Logger.Instance.Debug(string.Format("[BroadcastLSA] Initializing..."));
                    IRCLogger.IRClog(string.Format("[BroadcastLSA] Initializing..."));

                    DaemonBackEnd.Instance.LocalNode.Neighbors.FindAll(neighbour => neighbour.IsDown == false).
                        ForEach(notDownNeighbour => this.SendAdvertisment(notDownNeighbour));

                    // DEBUG: [BroadcastLSA] Finished.
                    Logger.Instance.Debug(string.Format("[BroadcastLSA] Finished."));
                    IRCLogger.IRClog(string.Format("[BroadcastLSA] Finished."));

                    // DaemonBackEnd.Instance.AllNodes.ForEach(node => node.IsAcknowledged = false);
                    DaemonBackEnd.Instance.LocalNode.Neighbors.ForEach(node => node.IsAcknowledged = false);

                    // Start the Wait for Ack from all of your neighbours
                    new Thread(new ThreadStart(this.WaitForAck)).Start();

                    // Wait the time of the Adv Cycle time
                    Thread.Sleep(AdvertisementCycleTime);
                }
            }
            catch (Exception ex)
            {
                IRCLogger.IRClog(ex);
            }
        }

        /// <summary>
        /// Sends my LSA to a single User, and Logs it
        /// </summary>
        /// <param name="neighbour">The Node to send to</param>
        private void SendAdvertisment(Node neighbour)
        {
            this.daemonUDPSocket.SendTo(
                            LSAUtility.GetByteArrayFromLSA(
                            DaemonBackEnd.Instance.GetLocalNodeLSA()),
                            (EndPoint)neighbour.Configuration.GetNodeEndPoint());

            // DEBUG: [BroadcastLSA] LSA sent to 127.0.0.1:9012
            Logger.Instance.Debug(string.Format("[BroadcastLSA] LSA sent to {0}", neighbour.Configuration.GetNodeEndPoint().ToString()));
            IRCLogger.IRClog(string.Format("[BroadcastLSA] LSA sent to {0}", neighbour.Configuration.GetNodeEndPoint().ToString()));
        }

        /// <summary>
        /// Waits for acknowledgment LSA from all neighbors.
        /// </summary>
        private void WaitForAck()
        {
            int sequanceNumber;
            List<Node> neighboursNotDown;

            try
            {
                sequanceNumber = DaemonBackEnd.Instance.LocalNode.LastSequenceNumber;

                while (sequanceNumber == DaemonBackEnd.Instance.LocalNode.LastSequenceNumber)
                {
                    // Get the neighbours, whom are notDown && notAck Yet
                    neighboursNotDown = DaemonBackEnd.Instance.LocalNode.Neighbors.FindAll(neighbour => neighbour.IsDown == false && neighbour.IsAcknowledged == false);

                    // INFO : [WaitForAck] Checking if all up neighbors have sent ACKs
                    Logger.Instance.Info(string.Format("[WaitForAck] Checking if all up neighbors have sent ACKs"));
                    IRCLogger.IRClog(string.Format("[WaitForAck] Checking if all up neighbors have sent ACKs"));

                    if (neighboursNotDown.Count == 0)
                    {
                        break;
                    }

                    neighboursNotDown.ForEach(upNeighbour => this.SendRetransmission(upNeighbour));

                    Thread.Sleep(RetransmissionTimeout);
                }
            }
            catch (Exception ex)
            {
                IRCLogger.IRClog(ex);
            }
        }

        /// <summary>
        /// Sends my LSA again as retransmission to a single User, and Logs it
        /// </summary>
        /// <param name="neighbour">The Node to send to</param>
        private void SendRetransmission(Node neighbour)
        {
            this.daemonUDPSocket.SendTo(
                        LSAUtility.GetByteArrayFromLSA(
                            DaemonBackEnd.Instance.GetLocalNodeLSA()),
                            (EndPoint)neighbour.Configuration.GetNodeEndPoint());

            // INFO : [WaitForAck] Retransmitting LSA to Node: 4
            Logger.Instance.Info(string.Format("[WaitForAck] Retransmitting LSA to Node: {0}", neighbour.NodeID));
            IRCLogger.IRClog(string.Format("[WaitForAck] Retransmitting LSA to Node: {0}", neighbour.NodeID));
        }

        /// <summary>
        /// Marks the neighbor as down.
        /// </summary>
        private void MarkNeighborAsDown()
        {
            List<Node> downNodes;

            try
            {
                while (true)
                {
                    downNodes = DaemonBackEnd.Instance.LocalNode.Neighbors.FindAll(
                        node => node.IsDown == true &&
                            (DateTime.Now - node.LastUpdateTime).TotalMilliseconds >= NeighborTimeout);

                    if (downNodes.Count > 0)
                    {
                        // DEBUG: [MarkNeighborAsDown] check initialized
                        Logger.Instance.Debug(string.Format("[MarkNeighborAsDown] check initialized"));
                        IRCLogger.IRClog(string.Format("[MarkNeighborAsDown] check initialized"));
                    }

                    downNodes.ForEach(downNode => this.MarkAsDown(downNode));

                    // TODO check this update if true or false
                    DaemonBackEnd.Instance.UpdateRoutingTable();

                    if (downNodes.Count > 0)
                    {
                        // DEBUG: [MarkNeighborAsDown] check finished.
                        Logger.Instance.Debug(string.Format("[MarkNeighborAsDown] check finished."));
                        IRCLogger.IRClog(string.Format("[MarkNeighborAsDown] check finished."));
                    }

                    Thread.Sleep(RetransmissionTimeout);
                }
            }
            catch (Exception ex)
            {
                IRCLogger.IRClog(ex);
            }
        }

        /// <summary>
        /// Marks a Specific Node as Down
        /// </summary>
        /// <param name="daemonNode">Node to Mark as Down</param>
        private void MarkAsDown(Node daemonNode)
        {
            daemonNode.IsDown = true;

            // ERROR: [MarkNeighborAsDown] Marking Node 5 as down
            Logger.Instance.Error(string.Format("[MarkNeighborAsDown] Marking Node {0} as down", daemonNode.NodeID));
            IRCLogger.IRClog(string.Format("[MarkNeighborAsDown] Marking Node {0} as down", daemonNode.NodeID));
        }
    }
}