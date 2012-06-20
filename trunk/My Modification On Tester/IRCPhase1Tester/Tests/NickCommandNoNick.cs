using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class NickCommandNoNick : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 3;
        }
        public override bool RunTest()
        {
            client.Send("NICK");
            return client.Receive().ToLower() == "431 :no nickname given";
        }

        public override string Title()
        {
            return "NICK Command No Nick Given";
        }
    }
}
