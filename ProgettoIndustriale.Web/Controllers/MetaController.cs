using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoIndustriale.Web.Controllers;

public class MetaController : ControllerBase
{
    [HttpGet("/info")]
    public ActionResult<string> Info()
    {
        var assembly = GetType().Assembly;
        var lastWriteTime = System.IO.File.GetLastWriteTime(assembly.Location);
        return Ok($"Assembly: {assembly.FullName}, Last Updated: {lastWriteTime}");
    }
}