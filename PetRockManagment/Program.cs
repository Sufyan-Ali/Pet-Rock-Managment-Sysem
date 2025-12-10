using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using PetRockManagment.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<PetRockDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}
// app.MapGet("/",()=>"hi");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
