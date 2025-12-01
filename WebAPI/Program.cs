using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI.Application.Profiles;
using WebAPI.Application.UseCase;
using WebAPI.Application.UseCase.Interfaces;
using WebAPI.Domain.IRepositories;
using WebAPI.Domain.Services;
using WebAPI.Infrastructure.Profiles;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");


var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<InfrastructureProfile>();
    cfg.AddProfile<ApplicationProfile>();
    cfg.AddExpressionMapping();
});

builder.Services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEstadoUseCase, EstadoUseCase>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IModelTypeRepository, ModelTypeRepository>();
builder.Services.AddScoped<IModelTypeUseCase, ModelTypeUseCase>();
builder.Services.AddScoped<ISourceConfigRepository, SourceConfigRepository>();
builder.Services.AddScoped<ISourceConfigUseCase, SourceConfigUseCase>();
builder.Services.AddScoped<ISourceModelFieldsRepository, SourceModelFieldsRepository>();
builder.Services.AddScoped<ISourceModelFieldsUseCase, SourceModelFieldsUseCase>();
builder.Services.AddScoped<ISourceModelRepository, SourceModelRepository>();
builder.Services.AddScoped<ISourceModelUseCase, SourceModelUseCase>();
builder.Services.AddScoped<IConfiguracionesRepository, ConfiguracionesRepository>();
builder.Services.AddScoped<IConfiguracionesUseCase, ConfiguracionesUseCase>();
builder.Services.AddScoped<IConsultaUseCase, ConsultaUseCase>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();

builder.Services.AddScoped<EstadoService>();
builder.Services.AddScoped<ModelTypeService>();
builder.Services.AddScoped<SourceConfigService>();
builder.Services.AddScoped<SourceModelFieldsService>();
builder.Services.AddScoped<SourceModelService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<LdapService>();
builder.Services.AddScoped<ConfiguracionesService>();
builder.Services.AddScoped<ConsultaService>();

builder.Services.AddDbContext<WebAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlserverConnection"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "GateWay API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en este formato: **Bearer {token}**"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseAuthentication(); 
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();

bool IsDevelopmentEnvironment(string env) => env == "Development";

bool IsStagingEnvironment(string env) => env == "Staging";

bool IsProductionEnvironment(string env) => env == "Production";

