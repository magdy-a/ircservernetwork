using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class UserCommandAlreadyRegistered : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 17;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("USER menna menna menna menna");
            success = success ? client.Receive().ToLower() == "ok" : false;
            client.Send("USER Ramy ramy ramy ramy");
            success = success ? client.Receive().ToLower() == "462 :you are already registered" : false;
            return success;
        }

        public override string Title()
        {
            return "USER Command Already registered";
        }
    }
}