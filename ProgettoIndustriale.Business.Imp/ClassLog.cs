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
            
            .WriteTo.File("Log/log.txt"
            ,outputTemplate: "{Timestamp: yyyy-m-dd hh:mm:ss} [{Level:u3}] {Message:lj}{NewLine}"
            ,shared: true
            , rollingInterval: RollingInterval.Day)            
            .CreateLogger();

            log = loggerConfiguration;
            //template --> data-ora manager errore

        }

        /********************************************************************************************************
         *                                           USO DEI LOG
         * log di information: da non usare praticamente perché c'è già quello automatico
         * 
         * log di debug: da usare per dire quando una funzione ha terminato il suo ciclo e cosa sta ritornando
         * 
         * log di errore: per leggere l' errore dato da un exception oppure 
         * da qualcosa andato male ma che per qualche motivo non siamo entrati nell' exception 
         * volendo comunque riportare l' errore e spiegarlo all'utente e chi toccherà il codice in futuro
         *
         *********************************************************************************************************/
        public void logMessageTemplate(string path="", string logType="information", string message="", Exception? e=null)
        {
            if (path != "") _path = path;


            if (e != null)//nel caso è un errore
            {
                //in error puà essere inserita direttamente presa l' eccezione ed essa poi viene gestita
                log.Error("{_path}:  {Message}", _path, e.Message);
                return;
            }
            else if (logType == "error")
            {
                //in error può essere inserito nel messaggio come stringa
                log.Error("{_path}:  {Message}", _path, message);
                return;
            }
            else if (logType == "debug")
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
