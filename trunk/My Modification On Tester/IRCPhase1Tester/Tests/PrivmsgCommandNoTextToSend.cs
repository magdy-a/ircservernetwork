using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandNoTextToSend: SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 11;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("NICK Ramy");
            success = success ? client.Receive().ToLower() == "ok":false;
            client.Send("USER Ramy r r r");
            success =success ?  client.Receive().ToLower() == "ok":false;

            client.Send("PRIVMSG Menna");

            if (client.Receive().ToLower() != "412 :no text to send")
            {
                success = false;
            }

            // To check no special handling for the colon.
            client.Send("PRIVMSG :msg");

            if (client.Receive().ToLower() != "412 :no text to send")
            {
                success = false;
            }

            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command No text to send";
        }
    }
}
