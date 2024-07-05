using Microsoft.OpenApi.Models;
using FaturasAPI.DB;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Oracle.EntityFrameworkCore.Internal;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.Sources.Clear();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
                                    {
                                        c.SwaggerDoc("v1", new OpenApiInfo
                                        {
                                            Title = "Faturas API",
                                            Version = "v1",
                                            Description = "API para registo das faturas em Base de dados",
                                            TermsOfService = new Uri("https://example.com/terms"),
                                            Contact = new OpenApiContact
                                            {
                                                Name = "Nelson Branquinho",
                                                Email = string.Empty,
                                                Url = new Uri("https://ha.branquinhotech.eu"),
                                            },
                                            License = new OpenApiLicense
                                            {
                                                Name = "Use under LICX",
                                                Url = new Uri("https://example.com/license"),
                                            }


                                        });
                                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                                        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                                        c.IncludeXmlComments(xmlPath);
                                    });


#region DATABASE CONFIGURATION
#region MySql Database Configuration examples (commented to use Oracle DB )
/*
  //var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
  builder.Services.AddDbContext<FaturaContext>(opt =>
                                                    opt.UseMySql(builder.Configuration.GetConnectionString("MariaDbConnectionString"), serverVersion));
*/

#endregion 




OracleConfiguration.TnsAdmin = Path.Combine(Directory.GetCurrentDirectory(), "Properties","Wallet_nbranquinhoDB");
OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

/*    trace for oracle connection debug */
/*OracleConfiguration.TraceFileLocation = @"c:\temp\traces";
OracleConfiguration.TraceLevel = 7;*/


/* Context Model Database configuration */
builder.Services.AddDbContext<FaturaContext>(opt =>
                                                    opt.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnectionString")));

#endregion


var env = builder.Environment;

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
/*else
{
    app.UseExceptionHandler();
}*/


app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(/*c =>
{
    //c.SwaggerEndpoint("v1/FaturasAPI.json", "Faturas API V1");
    c.SwaggerEndpoint("/swagger/v1/FaturasAPI.json", "Faturas API V1");
}*/);


#region Configuration for database migration
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<FaturaContext>();


try
{
    dbContext.Database.Migrate();
}
catch (Exception)
{
    //esta mensagem aparece no EventViewer do windows!
    app.Logger.LogWarning("If an error occurred when connecting to the Oracle DB, check whether the application pool identity is \"NetworkService\" !!");
    throw;
}
#endregion


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
