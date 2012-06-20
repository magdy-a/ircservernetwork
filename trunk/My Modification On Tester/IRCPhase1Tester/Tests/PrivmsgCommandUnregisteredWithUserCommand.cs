using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandUnregisteredWithUserCommand : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 15;
        }

        public override bool RunTest()
        {
            client.Send("USER Menna m m m");
            if (client.Receive().ToLower()=="ok")
            {
                client.Send("PRIVMSG Ramy :Hello");
                return (client.Receive().ToLower() == "404 :unknown command");
            }
            return false;
        }

        public override string Title()
        {
            return "PRIVMSG command unregistered (client sent user command only)";
        }
    }


}
