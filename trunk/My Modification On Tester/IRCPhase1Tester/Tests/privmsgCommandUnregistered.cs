using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandUnregistered : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 13;
        }

        public override bool RunTest()
        {
            client.Send("PRIVMSG Ramy :Hello");
            return (client.Receive().ToLower() == "404 :unknown command");
        }

        public override string Title()
        {
            return "PRIVMSG command unregistered";
        }
    }


}
