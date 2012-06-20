using System;
using System.Threading;
using IRCPhase1Tester.Tests;

namespace IRCPhase1Tester
{
    public class TestingContext
    {
        private Thread thread;
        private ITest test;
        private bool result;

        public TestingContext(ITest test)
        {
            this.test = test;
        }

        public bool ExecuteTest()
        {
            thread = new Thread(new ThreadStart(ExecuteThreadAsync));

            DateTime start = DateTime.Now;
            thread.Start();

            int graceMinutes = test.NumberOfMinutes();

            while ((thread.ThreadState == ThreadState.Running || thread.ThreadState == ThreadState.WaitSleepJoin) &&
                ((DateTime.Now - start) < new TimeSpan(0, graceMinutes, 0)))
            {
                System.Threading.Thread.Sleep(5000);
            }

            thread.Abort();

            if (!Session.Instance.FailedTests.Contains(test) && !Session.Instance.PassedTests.Contains(test))
            {
                Session.Instance.FailedTests.Add(test);
            }

            try
            {
                test.TearDown();
            }
            catch
            {
            }

            return result;
        }

        private void ExecuteThreadAsync()
        {
            try
            {
                test.BuildUp();
                result = test.RunTest();
                test.TearDown();
            }
            catch (Exception ex)
            {
                result = false;
            }

            if (result)
            {
                Session.Instance.PassedTests.Add(test);
            }
            else
            {
                Session.Instance.FailedTests.Add(test);
            }
        }
    }
}