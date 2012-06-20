using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandNoSuchNick : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 10;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("NICK Ramy");
            success = success ? client.Receive().ToLower() == "ok" : false;
            client.Send("USER Ramy r r r");
            success = success ? client.Receive().ToLower() == "ok" : false;

            client.Send("PRIVMSG Menna :Hey");

            if (client.Receive().ToLower() != "401 menna :no such nick/channel")
            {
                success = false;
            }

            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command No such nick";
        }
    }
}
