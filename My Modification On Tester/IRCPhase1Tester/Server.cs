using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace IRCPhase1Tester
{
    public class Server
    {
        Process process;

        public Server()
        {
            
        }

        public void Start()
        {
            process = Process.Start(Session.Instance.ServerPath, Session.Instance.PortNumber.ToString());
            System.Threading.Thread.Sleep(5000);
        }

        public void Kill()
        {
            if (!process.HasExited)
                process.Kill();
        }
    }
}
