using System;
using System.IO;
using IRCPhase1Tester.Tests;

namespace IRCPhase1Tester
{
    public static class Logger
    {
        private static string LogFilePath { get; set; }

        private const string defaultFilePath = "log.txt";

        public static void LogRun()
        {
            if (string.IsNullOrEmpty(LogFilePath))
            {
                LogFilePath = defaultFilePath;
            }

            string message = "-----------------------------------------------------" + Environment.NewLine;
            message += "DateTime: " + DateTime.Now.ToString() + Environment.NewLine;
            message += string.Format("For {0} Test Case(s) :: {1} passed testObject(s), {2} failed testObject(s).", Session.Instance.PassedTests.Count + Session.Instance.FailedTests.Count, Session.Instance.PassedTests.Count.ToString(), Session.Instance.FailedTests.Count.ToString()) + Environment.NewLine;
            if (Session.Instance.PassedTests.Count > 0)
            {
                message += "Passed:" + Environment.NewLine;
                foreach (ITest test in Session.Instance.PassedTests)
                {
                    message += test.Title() + Environment.NewLine;
                }
            }
            if (Session.Instance.FailedTests.Count > 0)
            {
                message += "Failed:" + Environment.NewLine;
                foreach (ITest test in Session.Instance.FailedTests)
                {
                    message += test.Title() + Environment.NewLine;
                }
            }
            message += Environment.NewLine + ((Session.Instance.PassedTests.Count == TestUtility.NumOfTests) ? "Congratulations" : "") + Environment.NewLine;

            FileStream fileStream;
            StreamWriter streamWriter;
            try
            {
                fileStream = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                streamWriter = new StreamWriter(fileStream);

                if (fileStream.CanWrite == true)
                {
                    streamWriter.Write(message + Environment.NewLine);
                }

                streamWriter.Close();
                fileStream.Close();
            }
            catch
            {
            }

            streamWriter = null;
            fileStream = null;
        }
    }
}