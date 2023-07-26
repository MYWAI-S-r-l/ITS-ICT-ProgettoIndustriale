using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoIndustriale.Type.Dto
{
    public class RequestActiveIndustries
    {
        public RequestActiveIndustries(List<string> categoriesList, List<string> provincesList)
        {
            this.categoriesList = categoriesList;
            this.provincesList = provincesList;
        }

        [BindRequired]
        public List <string> provincesList { get; set; }
        [BindRequired]
        public List <string> categoriesList { get; set; }
        

    }
}
