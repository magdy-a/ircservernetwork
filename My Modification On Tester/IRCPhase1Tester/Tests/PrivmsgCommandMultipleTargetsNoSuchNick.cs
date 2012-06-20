using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace IRCPhase1Tester.Tests
{
    class PrivmsgCommandMultipleTargetsNoSuchNick : SingleClientSingleServerTest
    {
        public override int TestID()
        {
            return 8;
        }

        public override bool RunTest()
        {
            bool success = true;
            client.Send("NICK Ramy");
            success =success ?  client.Receive().ToLower() == "ok" : false;
            client.Send("USER Ramy r r r");
            success =success ?  client.Receive().ToLower() == "ok" : false;

            Client.Client client2 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client2.Send("NICK Menna");
            success = success ? client2.Receive().ToLower() == "ok" : false;
            client2.Send("USER Menna m m m");
            success =success ?  client2.Receive().ToLower() == "ok" : false;

            Client.Client client3 = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
            client3.Send("NICK xyz");
            success =success ?  client3.Receive().ToLower() == "ok" : false;
            client3.Send("USER Xyz m m m");
            success =success ?  client3.Receive().ToLower() == "ok" : false;

            client.Send("PRIVMSG Menna,xyz,abc :Hey");

            
            if (client.Receive().ToLower() != "401 abc :no such nick/channel")
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

            client3.ClientSocket.ReceiveTimeout = 100;
            
            try
            {
                client3.Receive();
                success = false;
            }
            catch (SocketException)
            { 
            }
          
            client2.Close();
            client3.Close();
            return success;
        }

        public override string Title()
        {
            return "PRIVMSG command to multiple targets with non-existing nick.";
        }


        public override int NumberOfMinutes()
        {
            return 3;
        }
    }
}
