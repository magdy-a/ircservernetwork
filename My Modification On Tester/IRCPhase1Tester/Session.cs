using System.Collections.Generic;
using IRCPhase1Tester.Tests;

namespace IRCPhase1Tester
{
    public class Session
    {
        private Session()
        {
            PassedTests = new List<ITest>();
            FailedTests = new List<ITest>();
        }

        private static Session instance;

        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }

        public string ServerPath { get; set; }

        public int PortNumber { get; set; }

        public List<ITest> PassedTests { get; set; }

        public List<ITest> FailedTests { get; set; }

        public string SecretKey { get; set; }
    }
}