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

        catch (JsonException ex)
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

    public async Task RunCalls(Dto.JsonApiConfig config)
    {
        //check that the Json starts reading where it should (in this case, skip the first template call
        foreach (var apiCall in config.apiCalls)
        {
            //check whether apiCall is daily or once.
            //Depending on, interact with apiCallsLogs table
            if (apiCall.callFrequency.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                //check that LastSucessfulRun <= 24h
                Dto.ApiCallsLogs? log = GetApiLog(apiCall);
                if(log == null)
                {
                    try
                    {
                        await RetrieveData(apiCall);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine($"Error during apiCall {apiCall.apiCallName}: {ex.Message}");
                        //return null;
                    }

                    AddApiLog(apiCall);
                }
                else if ((DateTime.Now - log.LastSuccessfulRun).TotalHours >= 24)
                {
                    try
                    {
                        await RetrieveData(apiCall);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine($"Error during apiCall {apiCall.apiCallName}: {ex.Message}");
                        //return null;
                    }
                    
                    UpdateApiLog(apiCall);
                }
            }

            else if (apiCall.callFrequency.Equals("once", StringComparison.OrdinalIgnoreCase))
            {
                Dto.ApiCallsLogs? log = GetApiLog(apiCall);
                if(log == null)
                {
                    try
                    {
                        await RetrieveData(apiCall);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine($"Error during apiCall {apiCall.apiCallName}: {ex.Message}");
                        //return null;
                    }

                    //check that data was successfully updated
                    //if so, add log in table
                    AddApiLog(apiCall);
                }
                //check if the log exists. If not, run the func. 

            }
            
        }
    }

    public Dto.TernaToken? GetToken()
    {
        //update Dto and Domain objects to be aspecific to tokenType --> maybe add TokenProvider field in db (using url?)?
        Domain.TernaToken? domainToken = _context.TernaToken.FirstOrDefault();
        Dto.TernaToken? dtoToken = MyMapper<Domain.TernaToken, Dto.TernaToken>.Map(domainToken);
        return dtoToken;

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
        
        catch(System.NullReferenceException ex)
        {
            Console.WriteLine($"DB Error during apiCall {apiCall.apiCallName}: {ex.Message}");
            return null;
        }
        
    }

    //return type could change to ActionResult, depending on what's needed
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
        if (apiCall.headers != null)
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
            //Abstract it further if time remains to set up, should other type of auth-dependant APIs be added later
            if (apiCall.authType.Equals("OATH2", StringComparison.OrdinalIgnoreCase))
            {
                // Get the OATH2 token from the database table
                Dto.TernaToken? token = GetToken();

                if (token != null)
                {
                    // Add the token values to the API call
                    request.AddHeader("Authorization", $"{token.TokenType} {token.AccessToken}");
                }
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

                if (apiCall.param_type.Equals("url", StringComparison.OrdinalIgnoreCase))
                {
                    request.AddParameter(key, value, ParameterType.QueryString);
                }
                else if (apiCall.param_type.Equals("body", StringComparison.OrdinalIgnoreCase))
                {
                    //possible issue with parameter Type
                    request.AddParameter(key, value, RestSharp.ParameterType.RequestBody);
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

                var deserializedContent = System.Text.Json.JsonSerializer
                    .Deserialize(responseContent, dtoInstance.GetType());

                UpdateTable(deserializedContent, apiCall);
            }
        }
        
    }

    public object? GetClassInstance(string strFullyQualifiedName)
    {
        var reflectedType = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetType(strFullyQualifiedName) != null);
        System.Type ? type = reflectedType.GetType(strFullyQualifiedName);
        return Activator.CreateInstance(type);
    }

    public void UpdateTable(object dtoObject, Dto.JsonApiTemplate apiCall)
    {

        //ToDO:
        //Data JOIN check and condition
        //Add new records and don't touch old one rather than replace everything
        //By date_id, probably

        //Alphavantage and APIs that don't take start/end date
        //Filter after the request by date (could have to update class with "extra_parameters"
        //E.g. once --> start and end date for historical data
        // daily --> use current date & granularity depending on extra_parameters

        string? fullyQualifiedName = string.Join(".", "ProgettoIndustriale.Type", apiCall.domainClass);

        var domainInstance = GetClassInstance(fullyQualifiedName);


        //Commodity Checks
        if (apiCall.tableName == "Commodity")
        {
            var properties = dtoObject.GetType().GetProperties();

            //frequency check
            if (apiCall.callFrequency == "daily")
            {

                var filterDate = DateTime.Today.AddDays(-7);

                foreach (var property in properties)
                {
                    if (property.Name == "Data")
                    {
                        var dtoData = dtoObject.GetType().GetProperty("Data");
                        var domainDate = domainInstance.GetType().GetProperty("Date");
                        var domainValue = domainInstance.GetType().GetProperty("ValueUsd");

                        if (dtoData != null && domainDate != null && domainValue != null)
                        {
                            //this contains all the data couples from 1980 onwards
                            List<Dto.CommodityData>? dtoDataValues = dtoData.GetValue(dtoObject) as List<Dto.CommodityData>;

                            Dto.CommodityData? filteredDataValue = dtoDataValues
                                .FirstOrDefault(dataItem => dataItem.GetType()
                                .GetProperty("Date").GetValue(dataItem) > filterDate);

                            var dateValue = filteredDataValue.Date;
                            var valueUsd = filteredDataValue.Value;

                            domainDate.SetValue(domainInstance, dateValue);
                            domainValue.SetValue(domainInstance, valueUsd);

                            Console.WriteLine("Test");
                        }
                    }
                    else
                    {
                        var dtoValue = dtoObject.GetType().GetProperty(property.Name);
                        var domainValue = domainInstance.GetType().GetProperty(property.Name);

                        if (dtoValue != null && domainValue != null)
                        {
                            var value = dtoValue.GetValue(dtoObject);
                            domainValue.SetValue(domainInstance, value);
                        }
                    }

                }

            }

            else if (apiCall.callFrequency == "once")
            {

            }


        }


        //Deserializes the content of the API call into a domain object
        object? domainObject = System.Text.Json.JsonSerializer.Deserialize(
            System.Text.Json.JsonSerializer
            .Serialize(dtoObject), domainInstance.GetType());

        // Get the DbSet corresponding to the table dynamically.
        var dbSetProperty = _context.GetType().GetProperty(apiCall.tableName);
        if (dbSetProperty != null && dbSetProperty.PropertyType.IsGenericType)
        {
            //obtains dbSet object
            var dbSet = dbSetProperty.GetValue(_context);
            if (dbSet != null)
            {
                // Add the domainObject to the DbSet.
                MethodInfo? addMethod = dbSet.GetType().GetMethod("Add");
                addMethod.Invoke(dbSet, new[] { domainObject });
                _context.SaveChanges();
            }

            //return dtoObject;
            //needs to be some type of return to say it worked, or to feed the func that checks it worked
            //create another log table?
        }

    }
}

//To Do:
//When inserting data that has a date_id / COD_date, need to work in JOINs using the date values of the data & the the DATE
//column of the date table to insert the date_id / COD_date?
// How? 
// Raw SQL query on insertion
// Entity Framework
