using ProgettoIndustriale.Type;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Type.Dto;
using ProgettoIndustriale.Data;

//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Globalization;
using System.Xml;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Collections;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.CodeDom;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Reflection.Metadata;
using System.ComponentModel;

namespace ProgettoIndustriale.Business.Imp;

public class ApiManager : IApiManager
{
    private readonly IConfiguration _configuration;
    private readonly ProgettoIndustrialeContext _context;
    public ApiManager(ProgettoIndustrialeContext context, IConfiguration configuration)
    {
        _configuration = configuration;
        _context = context;
    }

    public Dto.JsonApiConfig? ProcessConfigFile(string jsonConfigLocation)
    {
        //the location of the jsonConfig file must be passed to the program

        try
        {
            var jsonConfig = System.IO.File.ReadAllText(jsonConfigLocation);
            JsonApiConfig? config = System.Text.Json.JsonSerializer.Deserialize<Dto.JsonApiConfig>(jsonConfig);

            return config;
        }

        catch (Exception ex) when (ex is JsonException)
        {
            Console.WriteLine($"Error Deserializing JSON: {ex.Message}");
            return null;
        }

        catch (System.IO.DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Error with filepath: {ex.Message}");
            return null;
        }

    }
   

    //=========================== CRUD ====================================

    public Domain.Token? GetToken(string tokenName)
    {
        Domain.Token? domainToken = _context.Token.FirstOrDefault(token => token.Provider == tokenName);
        //Dto.Token? dtoToken = MyMapper<Domain.Token, Dto.Token>.Map(domainToken!);
        return domainToken;

    }

    public void UpdateToken(Domain.Token domainInstance)
    {
        Domain.Token? domainToken = GetToken(domainInstance.Provider);
        domainToken.AccessToken = domainInstance.AccessToken;
        _context.Update(domainToken);
        _context.SaveChanges();
    }

    public Domain.Date? GetDate(string filterDate, bool date = true)
    {
        DateTime filterDateTime;
        if (date) { filterDateTime = DateTime.Parse(filterDate).Date; }
        else { filterDateTime = DateTime.Parse(filterDate); }
        
        Domain.Date? domainDate = _context.Date.Where(dateItem =>
            dateItem.DateTime == filterDateTime).FirstOrDefault();

        return domainDate;
    }

    public Domain.MacroZone? GetMacroZoneId(string macrozone)
    {
        Domain.MacroZone? domainMacroZone = _context.MacroZone.Where(item => 
        item.Name == macrozone).FirstOrDefault();

        return domainMacroZone;
    }

    public Dto.ApiCallsLogs? GetApiLog(Dto.JsonApiTemplate apiCall)
    {
        Domain.ApiCallsLogs? domainApiCallLog = GetDomainApiLog(apiCall);
        Dto.ApiCallsLogs? dtoApiLog = MyMapper<Domain.ApiCallsLogs, Dto.ApiCallsLogs>.Map(domainApiCallLog);
        return dtoApiLog;
    }

    public Domain.ApiCallsLogs? GetDomainApiLog(Dto.JsonApiTemplate apiCall)
    {
        try
        {
            Domain.ApiCallsLogs? domainApiCallLog = _context.ApiCallsLogs.FirstOrDefault(
            domainApiCall => domainApiCall.ApiCallName == apiCall.apiCallName);
            return domainApiCallLog;
        }

        catch (System.NullReferenceException ex)
        {
            Console.WriteLine($"DB Error during apiCall {apiCall.apiCallName}: {ex.Message}");
            return null;
        }
    }

    //return type could change to ActionResult, depending on what's needed
    //Update to exclude return type and use Domain objects, simplify and align with Token functions
    public Dto.ApiCallsLogs? UpdateApiLog(Dto.JsonApiTemplate? apiCall)
    {
        if (apiCall.apiCallName == null)
            return null;

        //insert a try here
        Domain.ApiCallsLogs? domainApiCallLog = GetDomainApiLog(apiCall);

        if (domainApiCallLog == null)
            return null;

        domainApiCallLog.LastSuccessfulRun = DateTime.Now;

        _context.Update(domainApiCallLog);
        _context.SaveChanges();
        return MyMapper<Domain.ApiCallsLogs, Dto.ApiCallsLogs>.Map(domainApiCallLog);

    }

    //return type could change to ActionResult, depending on what's needed
    public Dto.ApiCallsLogs? AddApiLog(Dto.JsonApiTemplate apiCall)
    {
        if (apiCall.apiCallName == null)
            return null;
        var domainApiCallLog = new Domain.ApiCallsLogs
        {
            ApiCallName = apiCall.apiCallName,
            CallFrequency = apiCall.callFrequency,
            LastSuccessfulRun = DateTime.Now
        };
        _context.ApiCallsLogs.Add(domainApiCallLog);
        _context.SaveChanges();
        Dto.ApiCallsLogs? dtoApiLog = MyMapper<Domain.ApiCallsLogs, Dto.ApiCallsLogs>.Map(domainApiCallLog);
        return dtoApiLog;

    }

    public object? GetClassInstance(string strFullyQualifiedName)
    {
        var reflectedType = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetType(strFullyQualifiedName) != null);
        System.Type? type = reflectedType.GetType(strFullyQualifiedName);
        return Activator.CreateInstance(type!);
    }

    public IList GetList(string strFullyQualifiedName)
    {
        var domainInstance = GetClassInstance(strFullyQualifiedName);

        System.Type domainType = domainInstance!.GetType();

        return Activator.CreateInstance(typeof(List<>).MakeGenericType(domainType)) as IList;
    }

    public IList? GetDtoList(string dtoDataQualifiedName, object dtoObject)
    {
        System.Type dtoObjectType = dtoObject.GetType();
        PropertyInfo listParameterProperty = dtoObjectType.GetProperties()
            .FirstOrDefault(prop => typeof(IEnumerable).IsAssignableFrom(prop.PropertyType));

        if(listParameterProperty != null)
        {
            IEnumerable listParameterValue = (IEnumerable)listParameterProperty.GetValue(dtoObject);

            IList dtoList = GetList(dtoDataQualifiedName);

            if(listParameterValue != null)
            {
                foreach (var item in listParameterValue)
                {
                    var dtoDataItem = GetClassInstance(dtoDataQualifiedName);
                    System.Type? targetType = dtoDataItem!.GetType();

                    if (targetType != null)
                    {
                        foreach (var prop in targetType.GetProperties())
                        {
                            var sourceProp = item.GetType().GetProperty(prop.Name);
                            if (sourceProp != null && prop.CanWrite)
                            {
                                prop.SetValue(dtoDataItem, sourceProp.GetValue(item));
                            }
                        }

                        dtoList.Add(dtoDataItem);

                    }

                }
            }

            return dtoList;
        }

        return null;

    }

    public bool CheckDailyCommodityRecord(string commodityName, int dateId)
    {
        Domain.Commodity? domainRecord = _context.Commodity.FirstOrDefault(
            dataItem => dataItem.Name.Contains(commodityName) && dataItem.IdDate == dateId);
        if (domainRecord is null) { return false; };
        return true;
    }

    public bool CheckDailyGenerationRecord(string generationType, int dateId)
    {
        Domain.Generation? domainRecord = _context.Generation.FirstOrDefault(
    dataItem => dataItem.Type.Contains(generationType) && dataItem.IdDate == dateId);
        if (domainRecord is null) { return false; };
        return true;
    }

    //extracts from apiCallName what's necessary for labelling in the db
    public string ExtractSubstring(string input)
    {
        const string prefix = "Dto.";
        if(input.StartsWith(prefix))
        {
            return input.Substring(prefix.Length);
        }
        else
        {
            Regex regex = new Regex(@"_(.*?)_");
            Match match = regex.Match(input);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return string.Empty;
        }
    }

    public void PropertyMatcher(List<PropertyInfo> properties, object dtoObject,
        object domainInstance)
    {
        foreach (var property in properties)
        {
            var dtoValue = dtoObject.GetType().GetProperty(property.Name)?.GetValue(dtoObject);
            var domainValue = domainInstance!.GetType().GetProperty(property.Name);

            if (dtoValue != null && domainValue != null)
            {
                System.Type targetType = domainValue.PropertyType;
                var convertedValue = Convert.ChangeType(dtoValue, targetType);
                domainValue.SetValue(domainInstance, convertedValue);
            }
        }
    }

    public string FirstCharToUpper(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
        return $"{char.ToUpper(input[0])}{input[1..]}";
    }


    /*======================= THE BIG BAD (MAIN) FUNCTIONS ==================*/

    public void UpdateTable(object dtoObject, Dto.JsonApiTemplate apiCall)
    {

        string? fullyQualifiedName = string.Join(".", "ProgettoIndustriale.Type", apiCall.domainClass);

        var properties = dtoObject.GetType().GetProperties().ToList();


        // ======================= Token Checks ================================

        if (apiCall.tableName == "Token")
        {
            var domainInstance = GetClassInstance(fullyQualifiedName);

            //match properties between dto object and domainInstance
            PropertyMatcher(properties, dtoObject, domainInstance!);

            var provider = domainInstance!.GetType().GetProperty("Provider");

            provider!.SetValue(domainInstance, apiCall.apiCallName);

            if (GetToken(apiCall.apiCallName) == null)
            {
                _context.Token.Add((Domain.Token)domainInstance);
                _context.SaveChanges();
                //Write Log
                Console.WriteLine($"Token {apiCall.apiCallName} Created");
            }

            else if (GetToken(apiCall.apiCallName) != null)
            {
                UpdateToken((Domain.Token)domainInstance);
                //Write Log
                Console.WriteLine($"Token {apiCall.apiCallName} updated");
            }
            //to make dynamic, later test the method using dbSet to get the tableName

;

        }

        var domainList = GetList(fullyQualifiedName);
        int valueId = -1;

        // ======================= Generation Checks ==========================

        if (apiCall.tableName == "Generation")
        {
            //dtoObject already should already contain deserialized data
            var dtoData = dtoObject.GetType().GetProperty("GenerationData");

            if (dtoData != null)
            {
                //this contains all the data couples from 1980 onwards
                List<Dto.GenerationData>? dtoDataValues = dtoData.GetValue(dtoObject) as List<Dto.GenerationData>;

                foreach (var value in dtoDataValues!)
                {
                    var domainInstance = GetClassInstance(fullyQualifiedName);
                    var dataId = domainInstance!.GetType().GetProperty("IdDate");
                    var dataGen = domainInstance!.GetType().GetProperty("GenerationGhw");
                    var dataType = domainInstance!.GetType().GetProperty("Type");

                    Domain.Date? domainDateInstance = GetDate(value.Date!, false);
                    valueId = domainDateInstance!.Id;

                    double valueGen = 0.0;

                    if (!value.Generation_gwh.IsNullOrEmpty()){
                        valueGen = double.Parse(value.Generation_gwh!, CultureInfo.GetCultureInfo("en-US"));
                    }

                    dataId!.SetValue(domainInstance, valueId);
                    dataGen!.SetValue(domainInstance, valueGen);
                    dataType!.SetValue(domainInstance, value.Type);

                    domainList.Add(domainInstance);
                }
            }

            foreach(Domain.Generation? gen in domainList)
            {
                if(!CheckDailyGenerationRecord(gen.Type, gen.IdDate))
                {
                    _context.Generation.Add(gen);
                    _context.SaveChanges();

                    //WriteLog
                    Console.WriteLine($"Daily Generation Data added for Energy Type: {gen.Type} on COD_Date: {gen.IdDate}");
                }
            }
        }

        // ======================= Load Checks =================================

        if (apiCall.tableName == "Load") 
        {
            //download historical data, get daily
        }

        // ======================= Price Checks ================================

        if (apiCall.tableName == "Price")
        {
            //need both daily and historical
            string propertyName = ExtractSubstring(apiCall.dtoDataClass);
            var dtoData = dtoObject.GetType().GetProperty(propertyName);

            if(dtoData != null)
            {
                string? dtoDataQualifiedName = string.Join(".", "ProgettoIndustriale.Type", apiCall.dtoDataClass);
                var dtoList = GetDtoList(dtoDataQualifiedName, dtoObject);

                List<PropertyInfo> nonIdProperties = new List<PropertyInfo>();

                if(dtoList!.Count != 0)
                {
                    foreach (var prop in dtoList[0].GetType().GetProperties().ToList())
                    {
                        if (!prop.Name.Contains("id"))
                        {
                            nonIdProperties.Add(prop);
                        }
                    }

                    //each item is dtoDailyPrice
                    foreach (var value in dtoList!)
                    {
                        var domainInstance = GetClassInstance(fullyQualifiedName);

                        PropertyMatcher(nonIdProperties, value, domainInstance!);

                        string valueDate = (string)value!.GetType().GetProperty("Date")?.GetValue(value, null);
                        Domain.Date? domainDate = GetDate(valueDate!, false);
                        int domainDateId = domainDate!.Id;

                        string valueMacroZone = (string)value!.GetType().GetProperty("Macrozone")?.GetValue(value, null);
                        Domain.MacroZone? domainMacroZone = GetMacroZoneId(valueMacroZone);
                        int domainMacroZoneId = domainMacroZone!.Id;

                        var dataId = domainInstance!.GetType().GetProperty("IdDate");
                        var macrozoneId = domainInstance!.GetType().GetProperty("IdMacrozone");

                        dataId!.SetValue(domainInstance, domainDateId);
                        macrozoneId!.SetValue(domainInstance, domainMacroZoneId);

                        domainList.Add(domainInstance);
                        //remember to cast
                    }
                }

                else
                {
                    //Write Log
                    Console.WriteLine($"Empty Price record for {DateTime.Today.AddDays(-apiCall.lag)}");
                }

                
            }
        }

        // ======================= Weather Checks ==============================

        if (apiCall.tableName == "Weather")
        {
            //check if api docs give historical data, otherwise both daily and historical
            //remember to cast everything and their dog to double
            string propertyName = ExtractSubstring(apiCall.dtoDataClass);
            var dtoData = dtoObject.GetType().GetProperty(propertyName);

            if(dtoData != null)
            {
                string? dtoDataQualifiedName = string.Join(".", "ProgettoIndustriale.Type", apiCall.dtoDataClass);
                //returns null
                var dtoList = GetDtoList(dtoDataQualifiedName, dtoObject);
            }

        }

        // ======================= Commodity Checks ============================

        if (apiCall.tableName == "Commodity")
        {
            //Watch that the datetime value is in the API response

            List<PropertyInfo> nonDataProperties = new List<PropertyInfo>();

            foreach (var property in properties)
            {
                if (property.Name != "CommodityData")
                {
                    nonDataProperties.Add(property);
                }
            }

            string? commodityName = ExtractSubstring(apiCall.apiCallName);

            var dtoData = dtoObject.GetType().GetProperty("CommodityData");

            if (dtoData != null)
            {
                //this contains all the data couples from 1980 onwards
                List<Dto.CommodityData>? dtoDataValues = dtoData.GetValue(dtoObject) as List<Dto.CommodityData>;

                if (apiCall.callFrequency == "daily")
                {
                    DateTime filterDate = DateTime.Today.AddDays(-7);
                    //get "today's" value by filterDate
                    Dto.CommodityData? filteredDataValue = dtoDataValues!.FirstOrDefault(dataItem =>
                    {
                        DateTime dataItemDate = DateTime.Parse(dataItem!.GetType().GetProperty("Date")!.GetValue(dataItem)!.ToString()!);
                        return dataItemDate.Date == filterDate.Date;
                    });

                    if (filteredDataValue is null)
                    {
                        //Write log
                        Console.WriteLine($"Commodity Log Not Found for {commodityName} on {filterDate}");
                        dtoDataValues!.Clear();
                    }

                    if (filteredDataValue != null)
                    {
                        dtoDataValues!.Clear();
                        dtoDataValues.Add(filteredDataValue); // Add the filteredDataValue as the only element
                    }
                }

                else if (apiCall.callFrequency == "once")
                {
                    string startDate = "2021-01-01";
                    DateTime filterDate = DateTime.Parse(startDate);

                    List<Dto.CommodityData> filteredData = dtoDataValues!
                        .Where(dataItem =>
                        {
                            DateTime dataItemDate = DateTime.Parse(dataItem.GetType().GetProperty("Date")!.GetValue(dataItem)!.ToString()!);
                            return dataItemDate.Date >= filterDate.Date;
                        })
                        .ToList();

                    if (!filteredData.IsNullOrEmpty())
                    {
                        dtoDataValues!.Clear();
                        dtoDataValues!.AddRange(filteredData);
                    }

                }

                foreach (var value in dtoDataValues!)
                {
                    var domainInstance = GetClassInstance(fullyQualifiedName);
                    var dataId = domainInstance!.GetType().GetProperty("IdDate");
                    var dataValue = domainInstance!.GetType().GetProperty("ValueUsd");

                    //if it works, update to PropertyMatcher
                    foreach (var property in nonDataProperties)
                    {
                        var dtoValue = dtoObject.GetType().GetProperty(property.Name);
                        var domainValue = domainInstance!.GetType().GetProperty(property.Name);

                        if (dtoValue != null && domainValue != null)
                        {
                            var v = dtoValue.GetValue(dtoObject);
                            domainValue.SetValue(domainInstance, v);
                        }
                    }

                    //call function to get the dateId from date table based on filterDate
                    Domain.Date? domainDateInstance;
                    double valueUsd;

                    try
                    {   //could be replaced with include and linq (later)

                        domainDateInstance = GetDate(value.Date!);
                        valueId = domainDateInstance!.Id;
                        //var valueDate = domainDateInstance!.DateTime;
                        if (!value.Value.IsNullOrEmpty() && value.Value != ".")
                        {
                            //watch for the , or . in the apiValue format
                            double doubleValue = double.Parse(value.Value!, CultureInfo.GetCultureInfo("en-US"));
                            valueUsd = doubleValue;
                        }
                        else
                        {
                            continue;
                        }

                        dataId!.SetValue(domainInstance, valueId);
                        dataValue.SetValue(domainInstance, valueUsd);

                        //Add new domainObject to list
                        domainList!.Add(domainInstance);

                    }
                    catch (ArgumentNullException ex)
                    {
                        //Placeholder, write log
                        Console.WriteLine($"Error during GetDate call: {ex.Message}");
                        continue;
                    }
                }
            }

            //maybe find a way to pass the type dynamically here and below
            foreach (Domain.Commodity? commodity in domainList!)
            {
                //loop through list of domain.Commodities
                if (!CheckDailyCommodityRecord(commodityName, commodity.IdDate))
                {
                    _context.Commodity.Add((Domain.Commodity)commodity);
                    _context.SaveChanges();
                    //Write Log
                    Console.WriteLine($"Commodity Data added for {commodityName} COD_Date: {commodity.IdDate}");
                }
            }


            // Get the DbSet corresponding to the table dynamically. --> could replace last bit
            //var dbSetProperty = _context.GetType().GetProperty(apiCall.tableName);
            //if (dbSetProperty != null && dbSetProperty.PropertyType.IsGenericType)
            //{
            //    //obtains dbSet object
            //    var dbSet = dbSetProperty.GetValue(_context);
            //    if (dbSet != null)
            //    {
            //        // Add the domainObject to the DbSet. --> what if I have to do this multiple times (multiple records?)
            //        MethodInfo? addMethod = dbSet.GetType().GetMethod("Add");
            //        addMethod.Invoke(dbSet, new[] { domainInstance }); <-- still possible issue with domainInstance's type
            //        _context.SaveChanges();

            //    }

            //    //Write Log of results
            //}

        }
    }

        public async Task RetrieveData(Dto.JsonApiTemplate? apiCall)
        {
            if (apiCall == null)
            {
                throw new ArgumentNullException(nameof(apiCall));
            }

            var options = new RestClientOptions(apiCall.client)
            {
                MaxTimeout = -1
            };
            var client = new RestClient(options);

            //use method
            var request = new RestRequest(apiCall.request, Enum.Parse<Method>(apiCall.method, true));

            //header handling
            if (!apiCall.headers.IsNullOrEmpty())
            {
                var header = apiCall.headers[0];
                foreach (var entry in header)
                {
                    string key = entry.Key;
                    string value = entry.Value;
                    request.AddHeader(key, value);
                }
            }

            //Authorization Handling
            if (apiCall.auth)
            {
                // Get the OATH2 token from the database table
                Domain.Token? token = GetToken(apiCall.authType);

                if (token != null)
                {
                    // Problem seems to be capitalization
                    string upTokenType = FirstCharToUpper(token.TokenType);
                    request.AddHeader("Authorization", $"{upTokenType} {token.AccessToken}");
                }
            }

            //Parameters Handling
            if (apiCall.parameters != null)
            {
                var parameter = apiCall.parameters[0];
                foreach (var entry in parameter)
                {
                    string key = entry.Key;
                    string value = entry.Value;

                    if (apiCall.callFrequency == "daily" && apiCall.lag != 0)
                    {
                        int lag = apiCall.lag;
                        if (key == "dateFrom" && value.IsNullOrEmpty())
                        {
                            DateTime dateFrom = DateTime.Today.AddDays(-lag);
                            value = dateFrom.ToString("d");
                        }
                        else if (key == "dateTo" && value.IsNullOrEmpty())
                        {
                            DateTime dateTo = DateTime.Today.AddDays(-lag+1);
                            value = dateTo.ToString("d");
                        }
                    }

                    if (apiCall.param_type.Equals("url", StringComparison.OrdinalIgnoreCase))
                    {
                        request.AddParameter(key, value, ParameterType.QueryString);
                    }
                    else if (apiCall.param_type.Equals("body", StringComparison.OrdinalIgnoreCase))
                    {
                        request.AddParameter(key, value);
                    }
                }
            }

            var response = await client.ExecuteAsync(request);
            string? responseContent = response.Content;

            //Check that the StatusCode is 200
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(apiCall.dtoClass))
                {
                    string? fullyQualifiedName = string.Join(".", "ProgettoIndustriale.Type", apiCall.dtoClass);

                    var dtoInstance = GetClassInstance(fullyQualifiedName);

                    object dtoObject = System.Text.Json.JsonSerializer
                        .Deserialize(responseContent, dtoInstance.GetType());

                    UpdateTable(dtoObject, apiCall);

                    //return StatusCode and check through that?
                }
            }

        }

        public async Task RunCalls(Dto.JsonApiConfig config)
        {
            var tokenCalls = config.tokenCalls;
            //check that the Json starts reading where it should (in this case, skip the first template call
            foreach (var apiCall in config.apiCalls)
            {
                //the historical series only run once, so no need for an extra condition
                Dto.ApiCallsLogs? log = GetApiLog(apiCall);

                if (log == null && apiCall.auth)
                {
                    var tokenCall = tokenCalls!.FirstOrDefault(call => call.apiCallName == apiCall.authType);

                    await Task.Delay(TimeSpan.FromSeconds(2));

                    await RetrieveData(tokenCall);

                    Dto.ApiCallsLogs? tokenLog = GetApiLog(tokenCall);

                    if (tokenLog == null) { AddApiLog(tokenCall!); }
                    else { UpdateApiLog(tokenCall); };

                    await Task.Delay(TimeSpan.FromSeconds(2));

                    await RetrieveData(apiCall);

                    AddApiLog(apiCall);
                }

                else if (log == null)
                {
                    await RetrieveData(apiCall);

                    AddApiLog(apiCall);
                }

                //check that LastSucessfulRun <= 24h
                //might need to adjust the >= 24 depending on how long it takes to run
                else if (apiCall.callFrequency.Equals("daily", StringComparison.OrdinalIgnoreCase) &&
                    (DateTime.Now - log.LastSuccessfulRun).TotalHours >= 24)
                {
                    await RetrieveData(apiCall);

                    UpdateApiLog(apiCall);
                }
            }
        }
} 


