using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class NickCommandNickInUse : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 2;
        }
        public override bool RunTest()
        {
            Client.Client client2 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client.Send("NICK Ramy");
            bool success=false;
            if (client.Receive().ToLower() == "ok")
            {
                client2.Send("NICK Ramy");
                success=client2.Receive().ToLower() == "433 ramy :nickname is already in use";
            }
            client2.Close();
            return success;

        }

        public override string Title()
        {
            return "NICK Command Nick in Use";
        }
    }

    
}
