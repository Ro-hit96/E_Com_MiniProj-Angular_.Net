using E_ComMIniProj.Data;
using E_ComMIniProj.Repository;
using E_ComMIniProj.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//

builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));
var connectionString = builder.Configuration.GetConnectionString("defaultConection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();//Dependencies Injection  

builder.Services.AddScoped<IcategoryRepositorycs, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IRegisterService, RegisterService>();

//


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E_ComMIniProj", Version = "v1" });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();//Builds the WebApplication instance.

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseAuthentication();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "E_ComMIniProj v1"));//Configures middleware components for authorization,
                                                                                         //authentication, CORS, Swagger documentation, and Swagger UI.

app.MapControllers();//Maps controllers to handle incoming HTTP requests.

app.Run();//Runs the application.
