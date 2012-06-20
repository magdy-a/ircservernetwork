namespace IRCPhase2
{
    using System;
    using System.IO;
    using Backend;

    /// <summary>
    /// IRCLogger Class
    /// </summary>
    public static class IRCLogger
    {
        /// <summary>
        /// Gets the Log File Path according to the NodeID
        /// </summary>
        private static string LogFilePath
        {
            get { return string.Format("Node{0}.txt", DaemonBackEnd.Instance.LocalNode.NodeID); }
        }

        /// <summary>
        /// Log a logObject that could be a string or an Exception
        /// </summary>
        /// <param name="logObject">The logObject to Log</param>
        public static void IRClog(object logObject)
        {
            FileStream fileStream;
            StreamWriter streamWriter;

            string message = string.Empty;

            if (logObject is Exception)
            {
                Exception x = (Exception)logObject;
                string line = "-----------------------------------------------------" + Environment.NewLine;
                message += line + "DateTime: " + DateTime.Now.ToString() + Environment.NewLine;
                message += string.Format("Message : {0}{3}Stacktrace : {1}{3}  {2}. " + line, x.Message, x.StackTrace, x.InnerException == null ? string.Empty : "Innerexception : " + x.InnerException + Environment.NewLine, Environment.NewLine);
            }
            else
            {
                string logstring = (string)logObject;
                message += "DateTime: " + DateTime.Now.ToString() + Environment.NewLine;
                message += string.Format("Message : {0}{1} ", logstring, Environment.NewLine);
            }

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