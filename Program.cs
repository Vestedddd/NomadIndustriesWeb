var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{

    options.Conventions.AddPageRoute("/Sensores-Iot", "/Productos");
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