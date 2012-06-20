namespace IRCPhase2
{
    using System;
    using System.Collections.Generic;
    using Backend;
    using IRC.Utilities;
    using Utilities;

    /// <summary>
    /// Program (Main) Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main Function that stats the Application
        /// </summary>
        /// <param name="args">The Arguments to send to the Main function at startup</param>
        private static void Main(string[] args)
        {
            Logger.Instance.Verbose = true;
            Dictionary<ArgumentKey, object> arguments;

            Logger.Instance.Info("Starting Routing Daemon...");

            try
            {
                // Load arguments
                arguments = ArgumentsParser.GetArguments(args);
            }
            catch
            {
                Logger.Instance.Error("Invalid arguments");
                IRCLogger.IRClog("Invalid arguments");
                return;
            }

            // Set the local node ID.
            DaemonBackEnd.Instance.LocalNode.NodeID = (int)arguments[ArgumentKey.NodeID];

            string line = "==================================================================================================================";
            IRCLogger.IRClog(line + Environment.NewLine + "========================================Starting New Session=====================================" + Environment.NewLine + line + Environment.NewLine);

            try
            {
                // Load configuration file.
                DaemonBackEnd.Instance.Configuration = ConfigFileParser.LoadConfigurationFromPath((string)arguments[ArgumentKey.ConfigFilePath]);
            }
            catch
            {
                return;
            }

            Logger.Instance.Debug("Loaded configuration file");
            IRCLogger.IRClog("Loaded configuration file");

            // Configure all the neighbors of the local node
            DaemonBackEnd.Instance.ConfigureLocalNode(DaemonBackEnd.Instance.Configuration);

            IRCPhase2 daemon = new IRCPhase2(DaemonBackEnd.Instance.LocalNode.Configuration.RoutingPort, DaemonBackEnd.Instance.LocalNode.Configuration.LocalPort);

            // Start the daemon
            daemon.Start();

            Logger.Instance.Info("Daemon Started Successfully");
            IRCLogger.IRClog("Daemon Started Successfully");

            // Infinite Loop till the application exits.
            while (true)
            {
                System.Threading.Thread.Sleep(100000);
            }
        }
    }
}