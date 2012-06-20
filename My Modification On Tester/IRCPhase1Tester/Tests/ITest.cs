using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCPhase1Tester.Tests
{
    public interface ITest
    {
        int NumberOfMinutes();

        string Title();

        string Description();

        string ExpectedOutput();

        void BuildUp();

        bool RunTest();

        void TearDown();

        int TestID();
    }
}
