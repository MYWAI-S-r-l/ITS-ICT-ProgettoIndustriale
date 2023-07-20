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
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProgettoIndustriale.Business.Imp
{
    public partial class ClassLog:Serilog.ILogger
    {
        public Serilog.ILogger log { get; set; }
        private string? _path;
        
        public ClassLog(IConfiguration config)
        {
            var loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .ReadFrom.Configuration(config)
            .CreateLogger();

            log = loggerConfiguration;
            //template --> data-ora manager errore

        }
        public void logMessageTemplate(string path="", string logType="information", string message="", Exception? e=null)
        {
            if (path != "") _path = path;


            if(e!=null)//nel caso è un errore
            {
                //in error puà essere inserita direttamente presa l' eccezione ed essa poi viene gestita
                log.Error("{_path}:  {Message}", _path, e.Message);
                return;
            }
            else if(logType == "error")
            {
                //in error può essere inserito nel messaggio come stringa
                log.Error("{_path}:  {Message}", _path, message);
                return;
            }
            else if(logType == "debug")
            {
                //nel caso si vuole in modo specifico un log di tipo debug
                log.Debug("{_path}:  {Message}", _path, message);
                return;
            }
            log.Information("{_path}:  {Message}", _path, message);//default information
            
        }

        public void Write(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
