var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
   
    options.Conventions.AddPageRoute("/Products/Sensores-iot", "/productos/lista");
    options.Conventions.AddPageRoute("/Products/Sensores-iot", "/productos");

    
    options.Conventions.AddPageRoute("/Products/Detalle", "/productos/ver/{id}");
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();