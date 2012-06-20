using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    public class UserCommandHappy: SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 18;
        }

        public override bool RunTest()
        {
            client.Send("USER menna menna menna menna");
            return client.Receive().ToLower() == "ok";
        }

        public override string Title()
        {
            return "USER Command Happy Scenario";
        }
    }
}
