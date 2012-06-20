using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandSendToUnregisteredClient : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 12;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("NICK Ramy");
            success = success ? client.Receive().ToLower() == "ok" : false;
            client.Send("USER Ramy r r r");
            success = success ? client.Receive().ToLower() == "ok" : false;

            Client.Client client2 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client2.Send("NICK Menna");
            success = success ? client2.Receive().ToLower() == "ok" : false;

            client.Send("PRIVMSG Menna :Hey");

            if (client.Receive().ToLower() != "401 menna :no such nick/channel" )
            {
                success = false;
            }

            client2.ClientSocket.ReceiveTimeout = 100;
            try
            {
                client2.Receive();
                success = false;
            }
            catch(SocketException)
            {

            }
            client2.Close();
            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command Send to unregistered user";
        }
    }
}
