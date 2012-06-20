using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    public class UserCommandMissingParams : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 19;
        }

        public override bool RunTest()
        {
            client.Send("USER menna menna");
            return client.Receive().ToLower() == "461 user :need more params";
        }

        public override string Title()
        {
            return "USER Command Missing Params";
        }
    }
}
