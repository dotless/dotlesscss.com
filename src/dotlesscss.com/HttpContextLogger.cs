namespace dotlesscss.com
{
    using System.Web;
    using dotless.Core.Abstractions;
    using dotless.Core.Loggers;

    public class HttpContextLogger : Logger
    {
        protected const string Key = "dotlesscss.com.log";

        public HttpContextLogger(LogLevel level)
            : base(level)
        {
        }

        protected override void Log(string message)
        {
            var log = GetLog();

            log += message + "\n";

            HttpContext.Current.Items[Key] = log;
        }

        public static string GetLog()
        {
            if (HttpContext.Current.Items.Contains(Key))
                return (string) HttpContext.Current.Items[Key];

            return "";
        }
    }
}