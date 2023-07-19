using System.Text.Json.Serialization;
using ProgettoIndustriale.Service.Api;
using ProgettoIndustriale.Type;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ElmahCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoIndustriale.Data;
using Serilog;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(cb => cb.RegisterModule(new MyAutofacModule()));

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

});

builder.Services.AddDbContext<ProgettoIndustrialeContext>(opt =>
{
    opt.UseMySql(
        builder.Configuration["ConnectionStrings:ProgettoIndustriale"],
        new MariaDbServerVersion(new Version(10, 11, 2)), //TODO: CHECK versione
        options => options.EnableRetryOnFailure());
    opt.EnableSensitiveDataLogging();
    opt.EnableDetailedErrors();
});
var allowedUrlsForCors = builder.Configuration["AllowedUrlsForCors"].Split(',');
builder.Services.ConfigureCors("CORSPolicy", allowedUrlsForCors);




builder.Services.AddElmah();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");

app.MapControllers();
app.UseElmah();

app.Run();