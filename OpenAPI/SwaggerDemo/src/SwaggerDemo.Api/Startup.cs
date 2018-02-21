using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

// TODO: 1)
using Swashbuckle.AspNetCore.Swagger;
// using NSwag.AspNetCore;
using SwaggerDemo.Api.Services;
using System;
using System.IO;
using SwaggerDemo.Api.Controllers;
using System.Collections.Generic;
using SwaggerDemo.Api.Filter;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace SwaggerDemo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureAuthService(services);

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "1.0.0",
                        Title = "SSwagger Petstore",
                        Description = "This is a sample server Petstore server.  You can find out more about     Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).      For this sample, you can use the api key `special-key` to test the authorization     filters.",
                        TermsOfService = "http://swagger.io/terms/",
                        License = new License()
                            {
                                Name = "Apache 2.0",
                                Url = "http://www.apache.org/licenses/LICENSE-2.0.html"
                            },
                        Contact= new Contact() { Email = "apiteam@swagger.io" }
                    }
                );

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "SwaggerDemo.Api.xml");
                options.IncludeXmlComments(xmlPath);

                options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = $"{Configuration.GetValue<string>("IdentityUrl")}/connect/authorize",
                    TokenUrl = $"{Configuration.GetValue<string>("IdentityUrl")}/connect/token",
                    Scopes = new Dictionary<string, string>()
                    {
                        { "demo1", "Demo API" }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();

            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddScoped<IApiController, CrossController>();
            services.AddScoped<IPetApiController, PetController>();
            services.AddScoped<IStoreApiController, StoreController>();
            services.AddScoped<IUserApiController, UserController>();

            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IUserService, UserService>();

            services.AddOptions();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // TODO: (2) for NSwag.AspNetCore;
            //app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, new SwaggerUiSettings()
            //{
            //    Description = "This is a sample server Petstore server.  You can find out more about     Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).      For this sample, you can use the api key `special-key` to test the authorization     filters.",
            //    Title = "Swagger Petstore",
            //    Version = "1.0.0"
            //});

            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            ConfigureAuth(app);

            // TODO: (2) for Swashbuckle.AspNetCore.Swagger
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoApi V1");                
                // options.SwaggerEndpoint("/swagger/v2/swagger.json", "DemoApi V2");

                options.ConfigureOAuth2(clientId: "demoapiswaggerui", clientSecret: "", realm: "",  appName: "DemoApi Swagger UI");
            });          

            app.UseMvc();
        }

        private void ConfigureAuthService(IServiceCollection services)
        {
            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var identityUrl = Configuration.GetValue<string>("IdentityUrl");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;                

            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "demo1";
            });
        }

        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            if (Configuration.GetValue<bool>("UseTest"))
            {
                app.UseMiddleware<ByPassAuthMiddleware>();
            }

            app.UseAuthentication();
        }
    }
}
