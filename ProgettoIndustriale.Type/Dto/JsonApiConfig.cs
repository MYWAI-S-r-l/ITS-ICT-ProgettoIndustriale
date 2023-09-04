using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto
{
    public class JsonApiConfig
    {
        public List<JsonApiTemplate>? apiCalls { get; set; }
        public JsonApiTemplate? template { get; set; }

        public List<JsonApiTemplate>? tokenCalls { get; set; }
    }
}
