using System.Text.Json.Serialization;
using ProgettoIndustriale.Service.Api;
using ProgettoIndustriale.Type;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ElmahCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        new MySqlServerVersion(new Version(8, 0, 23)), //TODO: CHECK versione
        options => options.EnableRetryOnFailure());
    opt.EnableSensitiveDataLogging();
    opt.EnableDetailedErrors();
});

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

app.MapControllers().RequireAuthorization("ApiScope");

app.UseElmah();

app.Run();