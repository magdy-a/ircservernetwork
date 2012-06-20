using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class UnknownCommand : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 16;
        }

        public override bool RunTest()
        {
            client.Send("command path");
            return (client.Receive().ToLower() == "404 :unknown command");
        }

        public override string Title()
        {
            return "Unknown Command";
        }
    }
}
