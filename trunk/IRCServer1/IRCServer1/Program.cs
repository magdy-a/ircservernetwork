using System.Threading;

namespace IRCServer1
{
    internal class Program
    {
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

            //int port = 9000;

            IRCServer1 server = new IRCServer1(port);

            server.Start();

            while (true)
            {
                Thread.Sleep(3000);
            }
        }
    }
}