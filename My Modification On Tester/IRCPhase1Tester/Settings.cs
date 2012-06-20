using System;
using System.IO;
using System.Text;

namespace IRCPhase1Tester
{
    public static class Settings
    {
        public const string SettingsFilePath = "settings.txt";

        // TODO be aware, some pathes have spaces in their folder names
        private static char[] separators = new char[] { '\r', '\n', '\t' };

        public static Configuration GetConfigurationFromFile()
        {
            FileStream fs = null;
            Configuration config;

            try
            {
                fs = new FileStream(Settings.SettingsFilePath, FileMode.Open);

                byte[] file = new byte[(int)fs.Length];

                string[] paramters;

                if (fs.Length == 0)
                {
                    return null;
                }

                // Read the file
                fs.Read(file, 0, file.Length);

                // split on separators
                paramters = Encoding.ASCII.GetString(file).Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (paramters.Length == 0)
                {
                    return null;
                }

                // Create new Object
                config = new Configuration();

                // foreach Token, check the type, and set it's value
                foreach (string param in paramters)
                {
                    config.SetPath(param, Configuration.GetFileExtensionType(param));
                }

                fs.Close();
            }

            catch
            {
                if (fs != null && fs.CanRead)
                {
                    fs.Close();
                }

                return null;
            }

            return config;
        }

        public static void UpdateSettingsFile(string path)
        {
            UpdateSettingsFile(path, Configuration.GetFileExtensionType(path));
        }

        public static void UpdateSettingsFile(string path, ExtensionsType type)
        {
            FileStream fs = null;

            Configuration config;

            if (type == ExtensionsType.UNKNOWN)
            {
                return;
            }

            config = GetConfigurationFromFile();

            if (config == null)
            {
                config = new Configuration();
            }

            switch (type)
            {
                case ExtensionsType.EXE:
                    config.ExePath = path;
                    break;
                case ExtensionsType.SLN:
                    config.SlnPath = path;
                    break;
            }

            try
            {
                if (File.Exists(SettingsFilePath))
                {
                    File.Delete(SettingsFilePath);
                }

                fs = new FileStream(SettingsFilePath, FileMode.Append);

                byte[] file = Encoding.ASCII.GetBytes(config.ExePath + "\r\n" + config.SlnPath);

                fs.Write(file, 0, file.Length);

                fs.Close();
            }
            catch
            {
                if (fs != null && (fs.CanRead || fs.CanWrite))
                {
                    fs.Close();
                }
            }
        }
    }
}