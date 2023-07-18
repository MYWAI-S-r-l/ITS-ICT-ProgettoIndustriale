using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
namespace Ansaldo.Protocollo.Business.Imp
{
    public partial class ClassLog
    {
        public readonly Serilog.ILogger _logger;
        public ClassLog(Serilog.ILogger logger)
        {
            _logger = logger;
        }

    }
}
