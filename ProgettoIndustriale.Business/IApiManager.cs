using System.Collections.Generic;
using ProgettoIndustriale.Type;
using ProgettoIndustriale.Type.Domain;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;
using System.Collections;
using System.Reflection;

namespace ProgettoIndustriale.Business;

public interface IApiManager
{
    
    Task RetrieveData(Dto.JsonApiTemplate template);
    void UpdateTable(object dtoObject, Dto.JsonApiTemplate apiCall);
    Task RunCalls(Dto.JsonApiConfig config);

    Dto.JsonApiConfig? ProcessConfigFile(string jsonConfig);

    Domain.Token? GetToken(string tokenName);
    void UpdateToken(Domain.Token domainInstance);

    Domain.Date? GetDate(string filterDate, bool date = true);
    Domain.MacroZone? GetMacroZone(string macrozone, bool bidding = false);
    Domain.Province? GetProvince(string lat, string longit);


    object? GetClassInstance(string strFullyQualifiedName);
    IList GetList(string strFullyQualifiedName);

    Dto.ApiCallsLogs? GetApiLog(Dto.JsonApiTemplate apiCall);
    Domain.ApiCallsLogs? GetDomainApiLog(Dto.JsonApiTemplate apiCall);
    Dto.ApiCallsLogs? UpdateApiLog(Dto.JsonApiTemplate apiCall);
    Dto.ApiCallsLogs? AddApiLog(Dto.JsonApiTemplate apiCall);

    bool CheckDailyCommodityRecord(string commodityName, int dateId);
    bool CheckDailyPriceLoadRecord(int macrozoneId, int dateId);
    bool CheckWeatherRecord(int provinceId, int dateId);

    string ExtractSubstring(string input);
    void PropertyMatcher(List<PropertyInfo> properties, object dtoObject,
        object domainInstance);
    string FirstCharToUpper(string input);

}