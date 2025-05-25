
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseDefaultFiles(); // This serves index.html by default
app.UseStaticFiles();  // This serves CSS, JS, images
app.Run();