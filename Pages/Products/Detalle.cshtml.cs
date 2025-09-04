using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NomadIndustriesWeb.Pages.Products
{
    public class DetalleModel : PageModel
    {
        public ProductoInfo Producto { get; set; }

        public IActionResult OnGet(string id)
        {
            Console.WriteLine($"*** MÉTODO OnGet EJECUTADO - ID: '{id}' ***");
            System.Diagnostics.Debug.WriteLine($"*** MÉTODO OnGet EJECUTADO - ID: '{id}' ***");

            Producto = ObtenerProducto(id);
            if (Producto == null)
            {
                Console.WriteLine($"*** PRODUCTO NO ENCONTRADO PARA ID: '{id}' ***");
                return NotFound();
            }
            ViewData["Title"] = $"{Producto.Nombre} - Nomad Industrial";
            return Page();
        }

        private ProductoInfo ObtenerProducto(string id)
        {
            var productos = new Dictionary<string, ProductoInfo>
            {
                ["sensor1"] = new ProductoInfo
                {
                    Id = "sensor1",
                    Nombre = "AT-R1",
                    Categoria = "Sensores IoT Industriales",
                    ImagenPrincipal = "/images/Productos/SensoresIot/sensor1.png",
                    DescripcionCorta = "Sensor industrial avanzado para monitoreo continuo",
                    DescripcionDetallada = "El AT-R1 es un sensor IoT de última generación...",
                    Caracteristicas = { "Conectividad IoT", "Monitoreo en tiempo real", "Alta precisión" },
                    Aplicaciones = { "Equipos industriales", "Maquinaria pesada", "Sistemas críticos" }
                },
                
                ["sensor2"] = new ProductoInfo
                {
                    Id = "sensor2",
                    Nombre = "ND-ATOMS-N1 AT-R",
                    Categoria = "Sensores IoT Industriales",
                    ImagenPrincipal = "/images/Productos/SensoresIot/sensor2.png",
                    DescripcionCorta = "Sensor especializado con tecnología ATOMS",
                    DescripcionDetallada = "El ND-ATOMS-N1 AT-R integra tecnología ATOMS de vanguardia para análisis predictivo avanzado de equipos industriales.",
                    Caracteristicas = { "Tecnología ATOMS", "Análisis predictivo", "Multi-parámetro" },
                    Aplicaciones = { "Mantenimiento predictivo", "Control de calidad", "Automatización" }
                },
                ["lubricacion1"] = new ProductoInfo
                {
                    Id = "lubricacion1",
                    Nombre = "QW3100",
                    Categoria = "Sensores de Monitoreo Lubricación IoT",
                    ImagenPrincipal = "/images/Productos/SensoresLubricación/lubricacion1.png",
                    DescripcionCorta = "Sensor de calidad de aceite",
                    DescripcionDetallada = "El QW3100 es el sensor de calidad de aceite en línea más avanzado del mundo y el único capaz de reemplazar el muestreo periódico de aceite.",
                    Caracteristicas = { "Análisis en línea", "Reduce muestreo", "Alta precisión" },
                    Aplicaciones = { "Motores industriales", "Sistemas hidráulicos", "Equipos móviles" }
                },
                ["lubricacion2"] = new ProductoInfo
                {
                    Id = "lubricacion2",
                    Nombre = "LH2500",
                    Categoria = "Sensores de Monitoreo Lubricación IoT",
                    ImagenPrincipal = "/images/Productos/SensoresLubricación/lubricacion2.png",
                    DescripcionCorta = "Monitorea nivel de aceite y contaminación del agua",
                    DescripcionDetallada = "El LH2500 monitorea el nivel de aceite y la contaminación del agua en tiempo real sin necesidad de visitar el equipo.",
                    Caracteristicas = { "Monitoreo de nivel", "Detección de agua", "Tiempo real" },
                    Aplicaciones = { "Sistemas hidráulicos", "Cajas de engranajes", "Motores industriales" }
                },
                ["lubricacion3"] = new ProductoInfo
                {
                    Id = "lubricacion3",
                    Nombre = "VB1100",
                    Categoria = "Sensores de Monitoreo Lubricación IoT",
                    ImagenPrincipal = "/images/Productos/SensoresLubricación/lubricacion3.png",
                    DescripcionCorta = "Monitorea vibración, flujo magnético y temperatura",
                    DescripcionDetallada = "El VB1100 monitorea la vibración, flujo magnético y temperatura de los activos industriales para diagnóstico predictivo.",
                    Caracteristicas = { "Vibración triaxial", "Campo magnético", "Temperatura" },
                    Aplicaciones = { "Motores", "Generadores", "Equipos rotativos" }
                }
            };

            return productos.GetValueOrDefault(id);
        }
    }

    public class ProductoInfo
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string ImagenPrincipal { get; set; }
        public string DescripcionCorta { get; set; }
        public string DescripcionDetallada { get; set; }
        public List<string> Caracteristicas { get; set; } = new();
        public List<string> Aplicaciones { get; set; } = new();
    }
}
