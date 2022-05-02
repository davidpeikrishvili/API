using Microsoft.EntityFrameworkCore;
using AnimeAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AnimeAPIDBContext>();

var app = builder.Build();
if(builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();  
app.UseAuthorization();
app.MapControllers();
app.Run();