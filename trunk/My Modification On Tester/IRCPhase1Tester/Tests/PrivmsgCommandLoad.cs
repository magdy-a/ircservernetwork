using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandLoad : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 6;
        }
        public override bool RunTest()
        {
            bool success = true;

            client.Send("NICK user1");
            success = success ? client.Receive().ToLower() == "ok" : false;
            client.Send("USER user1 r r r");
            success = success ? client.Receive().ToLower() == "ok" : false;

            Client.Client client2 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client2.Send("NICK user2");
            success = success ? client2.Receive().ToLower() == "ok" : false;
            client2.Send("USER user2 m m m");
            success =success ?  client2.Receive().ToLower() == "ok" : false;

            Client.Client client3 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client3.Send("NICK user3");
            success = success ? client3.Receive().ToLower() == "ok" : false;
            client3.Send("USER user3 m m m");
            success = success ? client3.Receive().ToLower() == "ok" : false;

            Client.Client client4 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client4.Send("NICK user4");
            success = success ? client4.Receive().ToLower() == "ok" : false;
            client4.Send("USER user4 m m m");
            success = success ? client4.Receive().ToLower() == "ok" : false;

            Client.Client client5 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client5.Send("NICK user5");
            success = success ? client5.Receive().ToLower() == "ok" : false;
            client5.Send("USER user5 m m m");
            success = success ? client5.Receive().ToLower() == "ok" : false;

            client.Send("PRIVMSG user2 :Hey1");
            if (client.Receive().ToLower() != "ok" || client2.Receive().ToLower() != ":user1 privmsg :hey1")
            {
                success = false;
            }

            client2.Send("PRIVMSG user3 :Hey2");
            if (client2.Receive().ToLower() != "ok" || client3.Receive().ToLower() != ":user2 privmsg :hey2")
            {
                success = false;
            }

            client3.Send("PRIVMSG user4 :Hey3");
            if (client3.Receive().ToLower() != "ok" || client4.Receive().ToLower() != ":user3 privmsg :hey3")
            {
                success = false;
            }

            client4.Send("PRIVMSG user5 :Hey4");
            if (client4.Receive().ToLower() != "ok" || client5.Receive().ToLower() != ":user4 privmsg :hey4")
            {
                success = false;
            }

            client5.Send("PRIVMSG user1 :Hey5");
            if (client5.Receive().ToLower() != "ok" || client.Receive().ToLower() != ":user5 privmsg :hey5")
            {
                success = false;
            }



            client2.Close();
            client3.Close();
            client4.Close();
            client5.Close();
            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command Load";
        }

        public override int NumberOfMinutes()
        {
            return 3;
        }
    }
}
