namespace dotlesscss.com
{
    using System.Web;
    using dotless.Core.Abstractions;
    using dotless.Core.Loggers;

    public class HttpContextLogger : Logger
    {
        public IHttp Http { get; set; }
        protected const string Key = "dotlesscss.com.log";

        public HttpContextLogger(IHttp http,LogLevel level)
            : base(level)
        {
            Http = http;
        }

        protected override void Log(string message)
        {
            var log = GetLog(Http.Context);

            log += message + "\n";

            Http.Context.Items[Key] = log;
        }

        public static string GetLog(HttpContextBase context)
        {
            if (context.Items.Contains(Key))
                return (string) context.Items[Key];

            return "";
        }
    }
}