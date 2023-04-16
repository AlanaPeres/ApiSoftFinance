using ApiSoftFinance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(connectionString,
ServerVersion.AutoDetect(connectionString)));

string conn = "Server=soft-finance.mysql.database.azure.com;Port=3306;Database=db_softfinance;Uid=soft@softfinance;Pwd=soft2023finance;Connect Timeout=60;SslMode=Required;";

MySqlConnection connection = new MySqlConnection(conn);

try
{
    connection.Open();
}
catch(Exception ex)
{
    Console.WriteLine("erro", ex.ToString());
}

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
