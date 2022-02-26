using System;

namespace Master.Utilities
{
    public static class EnvironmentSettings
    {
        public static string ConnectionString
        {
            get { return Environment.GetEnvironmentVariable("ConnectionString"); }
        }
    }
}
