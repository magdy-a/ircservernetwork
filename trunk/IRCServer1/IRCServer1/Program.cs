namespace IRCServer1
{
    using System.Threading;

    /// <summary>
    /// The Program class that will contain the main and the starting point of the program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main Function That Sets Accsess To Start Programs
        /// </summary>
        /// <param name="args">Arguments Recived From The CMD (Window Console) That Will be the port for this program</param>
        private static void Main(string[] args)
        {
            if (args.Length > 2 || args.Length == 0)
            {
                args = new string[] { "9000" };
            }

            int port;

            if (!int.TryParse(args[args.Length - 1], out port))
            {
                port = 9000;
            }

            IRCServer1 server = new IRCServer1(port);

            server.Start();

            while (true)
            {
                Thread.Sleep(3000);
            }
        }
    }
}