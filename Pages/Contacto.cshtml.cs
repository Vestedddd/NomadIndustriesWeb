using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NomadIndustriesWeb.Pages
{
    public class ContactoModel : CorreoPageModel
    {
        public ContactoModel(IConfiguration configuration) : base(configuration)
        {
        }

        public void OnGet()
        {
         
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Obtener datos del formulario
                string asunto = Request.Form["asunto"];
                string correo = Request.Form["correo"];
                string nombre = Request.Form["nombre"];
                string telefono = Request.Form["telefono"];
                string mensaje = Request.Form["mensaje"];

                // Validaciones básicas del lado del servidor
                if (string.IsNullOrWhiteSpace(asunto))
                {
                    return new JsonResult(new { success = false, message = "El asunto es obligatorio" });
                }

                if (string.IsNullOrWhiteSpace(correo))
                {
                    return new JsonResult(new { success = false, message = "El correo es obligatorio" });
                }

                if (string.IsNullOrWhiteSpace(mensaje))
                {
                    return new JsonResult(new { success = false, message = "El mensaje es obligatorio" });
                }

                // Validación de formato de email
                if (!IsValidEmail(correo))
                {
                    return new JsonResult(new { success = false, message = "El formato del correo no es válido" });
                }

                // Enviar correo usando el método heredado
                var resultado = await EnviarCorreoAsync(asunto, correo, nombre, telefono, mensaje);

                return resultado;
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Error interno del servidor: " + ex.Message });
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}