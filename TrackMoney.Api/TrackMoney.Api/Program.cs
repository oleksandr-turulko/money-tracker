using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TrackMoney.BLL.BL.Transaction;
using TrackMoney.BLL.BL.User;
using TrackMoney.Data;
using TrackMoney.Data.Repos.Repos.TransactionsRepo;
using TrackMoney.Data.Repos.Repos.UsersRepo;

var builder = WebApplication.CreateBuilder(args);



var issuer = builder.Configuration["Jwt:Issuer"];
var secret = builder.Configuration["Jwt:Key"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = false,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddDbContext<TrackMoneyDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("mssql")));

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserRepo, SqlUserRepo>();
builder.Services.AddScoped<IUserBl, UserBl>();

builder.Services.AddScoped<ITransactionsRepo, SqlTransactionsRepo>();
builder.Services.AddScoped<ITransactionBl, TransactionBl>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
});

builder.Services.AddCors(o =>
{
    o.AddPolicy("DefPolicy", b =>
    {
        b.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseCors("DefPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
