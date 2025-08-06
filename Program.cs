var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages(options =>
{
    // productos
    options.Conventions.AddPageRoute("/Products/Sensores-iot", "/productos");
    options.Conventions.AddPageRoute("/Products/Sensores-iot", "/productos/sensores-iot");
    

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