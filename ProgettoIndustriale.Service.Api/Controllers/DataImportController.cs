
using global::ProgettoIndustriale.Business;

namespace ProgettoIndustriale.Service.Api.Controllers
{
    public class DataImportController
    {
        private readonly IDataImportManager dataImportManager;

        public DataImportController(IDataImportManager dataImportManager)
        {
            this.dataImportManager = dataImportManager;
        }

        public void ImportData(string tableName)
        {
            dataImportManager.ImportData(tableName);
        }
    }
}

