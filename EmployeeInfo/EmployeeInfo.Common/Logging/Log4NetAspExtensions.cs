using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeInfo.Common.Logging
{
    public static class Log4netExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile)
        {
            factory.AddProvider(new Log4NetProvider(log4NetConfigFile));
            return factory;
        }

        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, IHostingEnvironment env)
        {
            // todo: refactor name
            factory.AddProvider(new Log4NetProvider($@"{env.ContentRootPath}\log4net.xml"));
            return factory;
        }
    }
}
