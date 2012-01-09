namespace IRCPhase2.Backend
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities;

    /// <summary>
    /// Network mapper using Dijkstra.
    /// </summary>
    public class DijkstraMapper
    {
        /// <summary>
        /// The Rank of the Dijkstra
        /// </summary>
        private int rank = 0;

        /// <summary>
        /// List of All Nodes in the Network
        /// </summary>
        private IList<Node> allNodes;

        /// <summary>
        /// 2D array that carries the links between each 2 nodes
        /// </summary>
        private int[,] links;

        /// <summary>
        /// 1D array that carries the Current Nodes
        /// </summary>
        private int[] currentNodes;

        /// <summary>
        /// 1D array that carries the Previous Nodes
        /// </summary>
        private int[] previousNodes;

        /// <summary>
        /// 1D array that carries the Distances
        /// </summary>
        private int[] distances;

        /// <summary>
        /// The trank of the Dijkstra
        /// </summary>
        private int trank = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="DijkstraMapper"/> class.
        /// </summary>
        /// <param name="allNodes">All nodes.</param>
        public DijkstraMapper(IList<Node> allNodes)
        {
            this.allNodes = allNodes.Where(x => !x.IsDown).ToList();
            int count = this.allNodes.Count;

            this.links = new int[count, count];
            this.currentNodes = new int[count];
            this.distances = new int[count];
            this.previousNodes = new int[count];

            this.rank = count;

            // Initializes the links matrix.
            for (int i = 0; i < this.rank; i++)
            {
                for (int j = 0; j < this.rank; j++)
                {
                    this.links[i, j] = this.allNodes[i].Neighbors.Contains(this.allNodes[j]) ? 1 : -1;
                }
            }

            // Initializes the current node array, and the previous node array.
            for (int i = 0; i < this.rank; i++)
            {
                this.currentNodes[i] = i;
                this.previousNodes[i] = -1;
            }

            this.currentNodes[0] = -1;

            // Updates the distance array with the distances of the neighbors to the root node.
            for (int i = 1; i < this.rank; i++)
            {
                this.distances[i] = this.links[0, i];
                this.previousNodes[i] = (this.distances[i] == -1) ? -1 : 0;
            }
        }

        /// <summary>
        /// Runs the mapper to calculate the shortest paths.
        /// </summary>
        public void Run()
        {
            for (this.trank = 1; this.trank < this.rank; this.trank++)
            {
                this.DijkstraSolving();
            }
        }

        /// <summary>
        /// Gets the routing table.
        /// </summary>
        /// <returns>Routing table based on the mapped network.</returns>
        public List<RoutingTableEntry> GetRoutingTable()
        {
            List<RoutingTableEntry> routingTable = new List<RoutingTableEntry>();

            for (int i = 1; i < this.rank; i++)
            {
                RoutingTableEntry entry = new RoutingTableEntry();
                entry.Node = this.allNodes[i];
                entry.Distance = this.distances[i];

                if (entry.Distance == -1)
                {
                    continue;
                }

                int currentNode = i;

                while (this.previousNodes[currentNode] != 0)
                {
                    currentNode = this.previousNodes[currentNode];
                }

                entry.NextHop = this.allNodes[currentNode];

                routingTable.Add(entry);
            }

            return routingTable;
        }

        /// <summary>
        /// Solves one iteration of the Dijkstra algorithm.
        /// </summary>
        private void DijkstraSolving()
        {
            int minValue = Int32.MaxValue;
            int minNode = 0;
            for (int i = 0; i < this.rank; i++)
            {
                if (this.currentNodes[i] == -1)
                {
                    continue;
                }

                if (this.distances[i] > 0 && this.distances[i] < minValue)
                {
                    minValue = this.distances[i];
                    minNode = i;
                }
            }

            this.currentNodes[minNode] = -1;
            for (int i = 0; i < this.rank; i++)
            {
                if (this.links[minNode, i] < 0)
                {
                    continue;
                }

                if (this.distances[i] < 0)
                {
                    this.distances[i] = minValue + this.links[minNode, i];
                    this.previousNodes[i] = minNode;
                    continue;
                }

                if ((this.distances[minNode] + this.links[minNode, i]) < this.distances[i])
                {
                    this.distances[i] = minValue + this.links[minNode, i];
                    this.previousNodes[i] = minNode;
                }
            }
        }
    }
}