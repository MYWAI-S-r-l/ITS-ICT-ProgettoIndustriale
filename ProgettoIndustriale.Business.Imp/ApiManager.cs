using ProgettoIndustriale.Type;
using ProgettoIndustriale.Data;
using Dto = ProgettoIndustriale.Type.Dto;
using Domain = ProgettoIndustriale.Type.Domain;
using ProgettoIndustriale.Type.Dto;

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
using ProgettoIndustriale.Data;

namespace ProgettoIndustriale.Business.Imp;

public class ApiManager : IApiManager
{
    private readonly ProgettoIndustrialeContext _context;
    public ApiManager(ProgettoIndustrialeContext context)
    {
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
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            return null;
        }
        
    }

    public async Task RunCalls(Dto.JsonApiConfig config)
    {
        //check that the Json starts reading where it should (in this case, skip the first template call
        foreach (var apiCall in config.apiCalls.Skip(1))
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
                if ((DateTime.Now - log.LastSuccessfulRun).TotalHours >= 24)
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

            if (apiCall.callFrequency.Equals("once", StringComparison.OrdinalIgnoreCase))
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

    //might change void into ActionResult, depending on the check function
    public void UpdateTable(object dtoObject, Dto.JsonApiTemplate template)
    {
        System.Type? domainType = System.Type.GetType(template.domainClass);

        if (domainType != null)
        {
            //Deserializes the content of the API call into a domain object
            object? domainObject = System.Text.Json.JsonSerializer.Deserialize(
                System.Text.Json.JsonSerializer.Serialize(dtoObject), domainType);

            // Get the DbSet corresponding to the table dynamically.
            var dbSetProperty = _context.GetType().GetProperty(template.tableName);
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
        Domain.ApiCallsLogs? domainApiCallLog = _context.ApiCallsLogs.FirstOrDefault(
            domainApiCall => domainApiCall.ApiCallName == apiCall.apiCallName);
        return domainApiCallLog;
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
                    request.AddParameter(key, value, ParameterType.GetOrPost);
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
                //occhio che senza system va a prendere il namespace (vedi esplora soluzioni)
                System.Type? dtoType = System.Type.GetType(apiCall.dtoClass);
                if (dtoType != null)
                {
                    var deserializedContent = System.Text.Json.JsonSerializer.Deserialize(responseContent, dtoType);

                    UpdateTable(deserializedContent, apiCall);

                    //return the object needed to check that the data was added/updated. ApiCall CRUD run on ApiCall/JsonApiTemplate
                    //How?
                    //Either check that the number of records is what I expected
                    //Or simply that I get a 200 Active Directory message
                }
            }
        }
        
    }

}
