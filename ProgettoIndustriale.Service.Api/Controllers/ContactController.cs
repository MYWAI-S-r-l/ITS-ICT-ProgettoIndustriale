using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Net;
using System.Text.Json.Nodes;
using System.Text;

namespace ProgettoIndustriale.Service.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public partial class ContactController : ControllerBase
{


    [HttpPost("SendContactData")] // Specifica che accetta richieste POST
    public object Prova([FromBody] ContactData contactData) // Usa JObject per rappresentare il jsonObject
    {
        // Configurazione mail
        
        try
        {
            MailMessage mail = new MailMessage();
            // Set the sender and recipient addresses.
            mail.From = new MailAddress(contactData.mail);
            mail.To.Add("be.progetto.industriale.11.2@accademiadigitaleliguria.it");
            // Set the subject and body of the message.
            mail.Subject = "This is a test email.";
            //Costruzione corpo mail con stringa di testo
            StringBuilder body = new StringBuilder();
            body.AppendLine("Nome: " + contactData.name);
            body.AppendLine("Cognome: " + contactData.cognome);
            body.AppendLine("From: " + contactData.mail);
            body.AppendLine();
            body.AppendLine();
            body.AppendLine(contactData.testo);
            mail.Body = body.ToString();
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("be.progetto.industriale.11.2@accademiadigitaleliguria.it", "BE_pi.23");
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            return Ok(new {messagge= "prova", ris=true});

        }
        catch (Exception e)
        {

            return Ok(new { messagge = e.Message, ris = false });
        }
        

        // Restituisci una risposta al client usando Ok() o altri metodi simili
        
    }
   
    public class ContactData
    {
        public string name { get; set; }
        public string cognome { get; set; }
        public string mail { get; set; }
        public string cell { get; set; }
        public string testo { get; set; }
    }

}