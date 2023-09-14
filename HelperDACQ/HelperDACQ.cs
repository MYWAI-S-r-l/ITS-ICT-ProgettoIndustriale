//using System;

//using ProgettoIndustriale.Data;

//using Microsoft.Extensions.Configuration;
using ProgettoIndustriale.Business.Imp;

namespace ProgettoIndustriale.HelperDACQ
{
    public class HelperManager
    {
        private List<string> _filepaths;
        private ApiManager _apiManager;
        //Constructor
        public HelperManager()
        {
            //Default Constructor
        }

        //parameterized constructor
        public HelperManager(List<string> filepaths, ApiManager apiManager)
        {
            _filepaths = filepaths;
            _apiManager = apiManager;
        }

        public void CallsRunner()
        {
            foreach(string path in _filepaths) 
            {
                var config = _apiManager.ProcessConfigFile(path);

                if (config != null)
                {
                    _apiManager.RunCalls(config).GetAwaiter().GetResult();
                }
            }

        }
    }
}