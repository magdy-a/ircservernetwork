using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandMultipleTargetsHappy : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 7;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("NICK Ramy");
            success = success ? client.Receive().ToLower() == "ok" : false;
            client.Send("USER Ramy r r r");
            success = success ? client.Receive().ToLower() == "ok" : false;

            Client.Client client2 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client2.Send("NICK Menna");
            success = success ? client2.Receive().ToLower() == "ok" : false;
            client2.Send("USER Menna m m m");
            success = success ? client2.Receive().ToLower() == "ok" : false;

            Client.Client client3 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client3.Send("NICK xyz");
            success = success ? client3.Receive().ToLower() == "ok" : false;
            client3.Send("USER Xyz m m m");
            success = success ? client3.Receive().ToLower() == "ok" : false;

            client.Send("PRIVMSG Menna,xyz :Hey");

            if (client.Receive().ToLower() != "ok" || client2.Receive().ToLower() != ":ramy privmsg :hey" || client3.Receive().ToLower() != ":ramy privmsg :hey")
            {
                success = false;
            }

            client2.Close();
            client3.Close();
            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command with multiple targets Happy Scenario";
        }
    }
}
