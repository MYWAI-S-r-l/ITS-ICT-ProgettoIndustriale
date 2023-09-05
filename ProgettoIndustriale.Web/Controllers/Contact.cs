using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Ansaldo.Protocollo.Web.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost] // Specifica che accetta richieste POST
    public IActionResult HandleFetch([FromBody] JObject jsonObject) // Usa JObject per rappresentare il jsonObject
    {
        // Manipola il jsonObject come preferisci
        string name = jsonObject["name"].ToString();
        string cognome = jsonObject["cognome"].ToString();
        string mail = jsonObject["mail"].ToString();
        string cell = jsonObject["cell"].ToString();
        string testo = jsonObject["testo"].ToString();

        // Restituisci una risposta al client usando Ok() o altri metodi simili
        return Ok(new { message = "Grazie per aver inviato i tuoi dati, " + name + " " + cognome });
    }

}