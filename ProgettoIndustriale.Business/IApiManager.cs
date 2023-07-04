//using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;

namespace ProgettoIndustriale.Business;

public interface IApiManager
{
    
    Task RetrieveData(Dto.JsonApiTemplate template);

    Dto.JsonApiConfig? ProcessConfigFile(string jsonConfig);

    Dto.ApiCallsLogs? GetApiLog(Dto.JsonApiTemplate apiCall);
    Domain.ApiCallsLogs? GetDomainApiLog(Dto.JsonApiTemplate apiCall);
    Dto.ApiCallsLogs? UpdateApiLog(Dto.JsonApiTemplate apiCall);
    Dto.ApiCallsLogs? AddApiLog(Dto.JsonApiTemplate apiCall);



}