namespace IRCPhase2.Utilities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ArgumentKey Enum
    /// </summary>
    public enum ArgumentKey
    {
        /// <summary>
        /// The Argument is NodeID
        /// </summary>
        NodeID,

        /// <summary>
        /// The Argument is Configuration File Path
        /// </summary>
        ConfigFilePath,

        /// <summary>
        /// The Argument is Advertisement Cycle Time
        /// </summary>
        AdvertisementCycle,

        /// <summary>
        /// The Argument is Neighbour Timeout, that is the Time for the Node to response, else it'll be set as Down
        /// </summary>
        NeighborTimeout,

        /// <summary>
        /// The Argument is Retransmission Timeout, that is the Time for the Node to response, else it'll send the LSA Again
        /// </summary>
        RetransmissionTimeout,

        /// <summary>
        /// The Argument is LSA Time Out
        /// </summary>
        LSATimeout
    }

    /// <summary>
    /// The Arguments Parser Class
    /// </summary>
    public static class ArgumentsParser
    {
        /// <summary>
        /// The NodeID Key
        /// </summary>
        private const string NodeIDKey = "-i";

        /// <summary>
        /// The Configuration File Path Key
        /// </summary>
        private const string ConfigFileKey = "-c";

        /// <summary>
        /// The Advertisement Cycle Timeout Key
        /// </summary>
        private const string AdvertisementCycleKey = "-a";

        /// <summary>
        /// The Neighbour Timeour Cycle Timeout Key
        /// </summary>
        private const string NeighborTimeoutKey = "-node";

        /// <summary>
        /// The Retransmission Timeout Key
        /// </summary>
        private const string RetransmissionTimeoutKey = "-r";

        /// <summary>
        /// The LSA Timeout Key
        /// </summary>
        private const string LSATimeoutKey = "-t";

        /// <summary>
        /// Gets the arguments passed to the router daemon in a dictionary.
        /// </summary>
        /// <param name="args">The args array passed to main().</param>
        /// <returns>Dictionary of the configuration key and value.</returns>
        public static Dictionary<ArgumentKey, object> GetArguments(string[] args)
        {
            if (args.Length % 2 != 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Dictionary<ArgumentKey, object> arguments = new Dictionary<ArgumentKey, object>();

            for (int i = 0; i < args.Length; i += 2)
            {
                string arg = args[i].ToLower();

                switch (arg)
                {
                    case NodeIDKey:
                        arguments.Add(ArgumentKey.NodeID, int.Parse(args[i + 1]));
                        break;
                    case ConfigFileKey:
                        arguments.Add(ArgumentKey.ConfigFilePath, args[i + 1]);
                        break;
                    case AdvertisementCycleKey:
                        arguments.Add(ArgumentKey.AdvertisementCycle, int.Parse(args[i + 1]));
                        break;
                    case NeighborTimeoutKey:
                        arguments.Add(ArgumentKey.NeighborTimeout, int.Parse(args[i + 1]));
                        break;
                    case RetransmissionTimeoutKey:
                        arguments.Add(ArgumentKey.RetransmissionTimeout, int.Parse(args[i + 1]));
                        break;
                    case LSATimeoutKey:
                        arguments.Add(ArgumentKey.LSATimeout, int.Parse(args[i + 1]));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (!arguments.ContainsKey(ArgumentKey.NodeID))
            {
                throw new ArgumentNullException();
            }

            if (!arguments.ContainsKey(ArgumentKey.ConfigFilePath))
            {
                throw new ArgumentNullException();
            }

            if (!arguments.ContainsKey(ArgumentKey.AdvertisementCycle))
            {
                arguments.Add(ArgumentKey.AdvertisementCycle, 30);
            }

            if (!arguments.ContainsKey(ArgumentKey.NeighborTimeout))
            {
                arguments.Add(ArgumentKey.NeighborTimeout, 120);
            }

            if (!arguments.ContainsKey(ArgumentKey.RetransmissionTimeout))
            {
                arguments.Add(ArgumentKey.RetransmissionTimeout, 3);
            }

            if (!arguments.ContainsKey(ArgumentKey.LSATimeout))
            {
                arguments.Add(ArgumentKey.LSATimeout, 120);
            }

            return arguments;
        }
    }
}