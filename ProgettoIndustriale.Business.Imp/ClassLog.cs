using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Logging;

namespace Ansaldo.Protocollo.Business.Imp
{
    public static partial class ClassLog
    {
        public static readonly Serilog.ILogger _log =
            new LoggerConfiguration().WriteTo.File("Log/logs.txt").CreateLogger();
    }
}
