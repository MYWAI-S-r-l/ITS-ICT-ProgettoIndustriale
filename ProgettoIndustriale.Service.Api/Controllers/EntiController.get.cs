using Dto = ProgettoIndustriale.Type.Dto;
using Microsoft.AspNetCore.Mvc;
using ProgettoIndustriale.Type.Dto;

namespace ProgettoIndustriale.Service.Api.Controllers;

public partial class EntiController
{
    [HttpGet("get/{id:int}")]
    public Dto.Ente? GetEnte(int id)
    {
        return _entiManager.GetEnte(id);
    }
    
    [HttpGet("getAll")]
    public List<Dto.Ente> GetEnti()
    {
        return _entiManager.GetAllEnti();
    }

    [HttpGet("getPathParam/{name}")]
    public string getPathParam(string name)
    {
        return "hello, " + name;
    }

    [HttpGet("helloWorld")]
    public string GetHelloWorld()
    {
        return "Ciao Mondo";
    }

    [HttpGet("getMyName/{number:int}")]
    public string GetMyName(int number)
    {
        if (number == 0)
            return "Pippo";
        if (number == 1)
            return "Pluto";
        return "Paperino";
    }
    
    [HttpGet("getTestString")]
    public String GetTestString(string inputString)
    {
        return "Ciao " + inputString;
    }

    [HttpGet("getTestObject")]
    public TestObject GetTestObject()
    {
        TestObject testObject = new TestObject();
        testObject.campo1 = "io sono il campo 1";
        testObject.campo2 = "e io sono il campo 2";
        return testObject;
    }
}