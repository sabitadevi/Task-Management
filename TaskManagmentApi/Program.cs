var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();
// Below code to make sure our local api can be called from the front end of any origin
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();// In Program.cs or Startup.cs

