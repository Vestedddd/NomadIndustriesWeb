using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace NomadIndustriesWeb.Pages
{
    public class CorreoPageModel : PageModel
    {
        protected readonly IConfiguration _configuration;

        public CorreoPageModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected async Task<JsonResult> EnviarCorreoAsync(string asunto, string correo, string nombre, string telefono, string mensaje)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(smtpSettings["FromName"], smtpSettings["FromEmail"]));
                email.To.Add(new MailboxAddress("Prueba formulario", "andresherrerasanteli@gmail.com"));
                email.Subject = $"Nuevo mensaje del sitio web: {asunto}";

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $@"
                        <h3>Nuevo mensaje desde el sitio web</h3>
                        <p><strong>Asunto:</strong> {asunto}</p>
                        <p><strong>De:</strong> {nombre ?? "No especificado"} ({correo})</p>
                        <p><strong>Teléfono:</strong> {telefono ?? "No especificado"}</p>
                        <p><strong>Mensaje:</strong></p>
                        <p>{mensaje.Replace("\n", "<br>")}</p>
                        <hr>
                        <p><small>Enviado desde el formulario de contacto del sitio web</small></p>
                    "
                };

                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(smtpSettings["Host"], int.Parse(smtpSettings["Port"]), SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(smtpSettings["Username"], smtpSettings["Password"]);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return new JsonResult(new { success = true, message = "Correo enviado correctamente" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Error al enviar correo: " + ex.Message });
            }
        }
    }
}