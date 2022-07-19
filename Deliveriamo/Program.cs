using Microsoft.AspNetCore.Authentication.JwtBearer;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Deliveriamo.Entity;
using Microsoft.EntityFrameworkCore;

namespace DeliveriamoMain
{
    public class Program {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue(typeof(string), "JwtEncryptionKey").ToString());

            // Add services to the container.

            builder.Services.AddDbContext<DeliveriamoContext>(options => options.UseSqlServer(builder.Configuration
                                       .GetConnectionString("DeliveriamoDB")
                                        .Replace("@machine", Environment.MachineName)));

            builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);

            builder.Services.AddTransient<ILoginService, LoginService>();
            builder.Services.AddTransient<IRegisterService, RegisterService>();
            builder.Services.AddTransient<ICryptoService, CryptoService>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Deliveriamo", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() //cofigurazione di un pulsante nello swagger
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
            });
            builder.Services.AddAuthentication(x =>  // configurazione autorizzazione nei service in base a Jwt Bearer
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => // configurazione Jwt Bearer
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}