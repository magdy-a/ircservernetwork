using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class NickCommandHappy : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 1;
        }
        public override bool RunTest()
        {
            client.Send("NICK menna");
            return client.Receive().ToLower() == "ok";
        }

        public override string Title()
        {
            return "NICK Command Happy Scenario";
        }
    }
}
