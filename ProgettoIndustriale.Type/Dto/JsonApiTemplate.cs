using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto;

public class JsonApiTemplate
{
    public string apiCallName { get; set; }
    public string tableName { get; set; }
    public string client { get; set; }
    public string request { get; set; }
    public string callFrequency { get; set; }
    public string method { get; set; }
    public bool auth { get; set; }
    public string authType { get; set; }
    public List<Dictionary<string, string>> parameters { get; set; }
    public string param_type { get; set; }
    public List<Dictionary<string, string>> headers { get; set; }
    public string dtoClass { get; set; }
    public string domainClass { get; set; }
}
