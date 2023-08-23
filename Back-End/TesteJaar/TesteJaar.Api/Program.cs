using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TesteJaar.Api.Configuration;
using TesteJaar.Domain.Mapping;
using TesteJaar.Domain.Service;
using TesteJaar.Domain.Service.Generic;
using TesteJaar.Infra.Context;
using TesteJaar.Infra.Repositories;
using TesteJaar.Infra.Repositories.Interfaces;
using TesteJaar.Infra.Repository;
using TesteJaar.Infra.UnitofWork;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("clienteDB");

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ClientContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IveiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<IUnitofWork, UnitOfWork>();

builder.Services.AddScoped(typeof(VeiculoService<,>), typeof(VeiculoService<,>));
builder.Services.AddScoped(typeof(GenericServiceAsync<,>), typeof(GenericServiceAsync<,>));
builder.Services.AddScoped(typeof(IServiceAsync<,>), typeof(GenericServiceAsync<,>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient();


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors();

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var key = Encoding.ASCII.GetBytes(appSettings.Secret ?? "");
builder.Services.AddEndpointsApiExplorer();
builder.Services
.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = appSettings.ValidoEm,
        ValidIssuer = appSettings.Emissor,
    };
});
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();