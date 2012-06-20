using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandHappy : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 5;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("NICK Ramy");
            success =success ?  client.Receive().ToLower() == "ok" : false;
            client.Send("USER Ramy r r r");
            success =success ?  client.Receive().ToLower() == "ok" : false;

            Client.Client client2 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client2.Send("NICK Menna");
            success = success ? client2.Receive().ToLower() == "ok" : false;
            client2.Send("USER Menna m m m");
            success =success ?  client2.Receive().ToLower() == "ok" : false;

            client.Send("PRIVMSG Menna :Hey");

            if (client.Receive().ToLower() != "ok" || client2.Receive().ToLower() != ":ramy privmsg :hey")
            {
                success = false;
            }

            client2.Close();
            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command Happy Scenario";
        }
    }
}
