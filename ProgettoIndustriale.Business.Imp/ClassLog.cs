using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog.Core;
using Microsoft.Extensions.Configuration;

namespace ProgettoIndustriale.Business.Imp
{
    public partial class ClassLog:Serilog.ILogger
    {
        private readonly Serilog.ILogger log;
        public string TemplateMessage { get; set; }
        /*public static Serilog.ILogger _log =
            new LoggerConfiguration().WriteTo.File("Log/logs.txt")
                                     .CreateLogger();
        */
        public ClassLog(IConfiguration config)
        {
            var loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            /*
            .WriteTo.Console()
            .WriteTo.File("Log/log.txt", outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:"+message+"}{NewLine}{Exception}\"")
            */
            .ReadFrom.Configuration(config)
            .CreateLogger();

            log = loggerConfiguration;
            //template --> data-ora manager errore

        }
        public void logInformation(string info)
        { 
            log.Information(info);
        }
        public void logError(string error)
        {
            log.Error(error);
        }
        public void logDebug(string debug)
        {
            log.Debug(debug);
        }

        public void dispose()
        {
            
        }

        public void Write(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
