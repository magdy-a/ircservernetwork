using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    public abstract class SingleClientSingleServerTest: ITest
    {
        protected Server server;
        protected Client.Client client;

        #region ITest Members

        public void BuildUp()
        {
            server = new Server();
            server.Start();

            client = new IRCPhase1Tester.Client.Client(Session.Instance.PortNumber);
        }

        public abstract bool RunTest();

        public virtual void TearDown()
        {
            client.Close();
            server.Kill();
        }

        public virtual int NumberOfMinutes()
        {
            return 1;
        }

        public abstract string Title();

        public virtual string Description()
        {
            return string.Empty;
        }

        public virtual string ExpectedOutput()
        {
            return string.Empty;
        }

        public abstract int TestID();

        #endregion
    }
}
