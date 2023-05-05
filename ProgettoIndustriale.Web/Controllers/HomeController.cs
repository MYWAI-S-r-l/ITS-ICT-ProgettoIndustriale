using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Ansaldo.Protocollo.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ProgettoIndustriale.Web.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ClaimsWeb()
    {
        return View();
    }

    public async Task<IActionResult> ClaimsApi()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");

        string urlToCall = $"{_configuration["BaseUrls:WebApiBaseUrl"]}Identity";
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var content = await client.GetStringAsync(urlToCall);

        ViewBag.Json = JArray.Parse(content).ToString();
        return View("json");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }
    
    [AllowAnonymous]
    public IActionResult Exc()
    {
        throw new Exception("Eccezione di TEST per ELMAH");
    }
}
