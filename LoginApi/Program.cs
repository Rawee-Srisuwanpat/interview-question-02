using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LoginApi.Data;
using LoginApi.Services.Interfaces;
using LoginApi.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Controller
builder.Services.AddControllers();


// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


// Database
builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseSqlServer(
        builder.Configuration
        .GetConnectionString("DefaultConnection"));

});


// JWT

var jwtSetting = builder.Configuration.GetSection("Jwt");




builder.Services
.AddAuthentication(
JwtBearerDefaults.AuthenticationScheme)

.AddJwtBearer(options =>
{

    options.TokenValidationParameters =
    new TokenValidationParameters
    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,


        ValidIssuer =
        jwtSetting["Issuer"],


        ValidAudience =
        jwtSetting["Audience"],


        IssuerSigningKey =
        new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(
        jwtSetting["Key"]!
        )),
        ClockSkew = TimeSpan.Zero

    };

});


// Authorization

builder.Services.AddAuthorization();


// CORS สำหรับ Angular

builder.Services.AddCors(options =>
{

    options.AddPolicy("AngularPolicy",
    policy =>
    {

        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();

    });

});



var app = builder.Build();



if (app.Environment.IsDevelopment())
{

    app.UseSwagger();

    app.UseSwaggerUI();

}



app.UseHttpsRedirection();

app.UseCors("AngularPolicy");

app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();


app.Run();