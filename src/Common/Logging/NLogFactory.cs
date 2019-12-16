using NLog.Web;
using System.IO;

namespace Common.Logging
{
    public static class NLogFactory
    {

        public static void CreateLogger()
        {
            var logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "nlog.config").GetCurrentClassLogger();
        }

    }
}
