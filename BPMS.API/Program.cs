using BPMS.BasicAuthentication;
using BPMS.Business.IServices;
using BPMS.Business.Services;
using BPMS.Domain.Context;
using BPMS.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//----- some option added to "AddSwaggerGen" by Omid :) ------
// AddSecurityDefinition && AddSecurityRequirement
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(BasicAuthenticationDefaults.AuthenticationScheme,
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "Basic",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Basic Authorization Header"
        });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = BasicAuthenticationDefaults.AuthenticationScheme
                }
            },
            new string[]{"BPMS-Admin"}
        }
    });
});

//-----this block of code added by Omid :) ------
// Basic Authentication
builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
        BasicAuthenticationDefaults.AuthenticationScheme, null
    );


//-----this block of code added by Omid :) ------
// dependency injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IGenericRepository<IDsaudctService>, GenericRepository<IDsaudctService>>();
//builder.Services.AddScoped<IGenericRepository<IDsauddtService>, GenericRepository<IDsauddtService>>();
//builder.Services.AddScoped<IGenericRepository<IDsaudmtService>, GenericRepository<IDsaudmtService>>();
//builder.Services.AddScoped<IGenericRepository<IDsddertService>, GenericRepository<IDsddertService>>();
//builder.Services.AddScoped<IGenericRepository<IDsiradtService>, GenericRepository<IDsiradtService>>();
//builder.Services.AddScoped<IGenericRepository<IDsisdstService>, GenericRepository<IDsisdstService>>();
builder.Services.AddScoped<IDsaudctService, DsaudctService>();
builder.Services.AddScoped<IDsauddtService, DsauddtService>();
builder.Services.AddScoped<IDsaudmtService, DsaudmtService>();
builder.Services.AddScoped<IDsddertService, DsddertService>();
builder.Services.AddScoped<IDsiradtService, DsiradtService>();
builder.Services.AddScoped<IDsisdstService, DsisdstService>();


//-----this block of code added by Omid :) ------
// "dbCintext" is implemented in the 'appsettings.json' file , by Omid :)
builder.Services.AddDbContext<BPMS_Context>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("dbContext"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
