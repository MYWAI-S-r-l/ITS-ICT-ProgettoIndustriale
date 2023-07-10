using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto
{
    public class RequestActiveIndustries
    {
        public RequestActiveIndustries() { }
        public List <string> provincesList { get; set; }
        public List <string> categoriesList { get; set; }
        

    }
}
