using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandNoRecipient : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 9;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("NICK Ramy");
            success = success ? client.Receive().ToLower() == "ok":false;
            client.Send("USER Ramy r r r");
            success = success ? client.Receive().ToLower() == "ok" : false;

            client.Send("PRIVMSG");

            if (client.Receive().ToLower() != "411 :no recipient given (privmsg)")
            {
                success = false;
            }

            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command No Recipient";
        }
    }
}
