using System;
using System.IO;

namespace IRCPhase1Tester
{
    // TODO new Class here

    public enum ExtensionsType
    {
        EXE,
        SLN,
        UNKNOWN
    }

    public class Configuration
    {
        public string ExePath { get; set; }

        public string SlnPath { get; set; }

        public Configuration()
        {
            ExePath = string.Empty;
            SlnPath = string.Empty;
        }

        public void SetPath(string path, ExtensionsType type)
        {
            switch (type)
            {
                case ExtensionsType.EXE:
                    ExePath = path;
                    break;
                case ExtensionsType.SLN:
                    SlnPath = path;
                    break;
            }
        }

        public static ExtensionsType GetFileExtensionType(string path)
        {
            try
            {
                return (ExtensionsType)Enum.Parse(typeof(ExtensionsType), Path.GetExtension(path).ToUpper().Remove(0, 1));
            }
            catch
            {
                return ExtensionsType.UNKNOWN;
            }
        }
    }
}