using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandUnregisteredWithNickCommand : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 14;
        }

        public override bool RunTest()
        {
            client.Send("NICK Menna"); if (client.Receive().ToLower() == "ok")
            {
                client.Send("PRIVMSG Ramy :Hello");
                return (client.Receive().ToLower() == "404 :unknown command");
            }
            return false;
        }

        public override string Title()
        {
            return "PRIVMSG command unregistered (client sent nick command only)";
        }
    }


}

