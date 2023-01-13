using Api.Context;
using Api.Setting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Api.Service.DataService;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.COVENTAF
{
    public class Startup
    {
        //declarar esta variable para el cors
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region inyectando el servicio JWT
            //inyectando servicio
            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            #endregion

         

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api.COVENTAF", Version = "v1" });
            //});


            services.AddScoped<ICliente, DataCliente>();
            services.AddScoped<IFactura, FacturaService>();
            services.AddScoped<IArticulo, DataArticulo>();
            services.AddScoped<IBodega, DataBodega>();
            services.AddScoped<IMoneda_Hist, DataMoneda_Hist>();
            services.AddScoped<IFormaPago, DataFormaPago>();
            services.AddScoped<ISecurityUsuarios, ServiceSecurityUsuario>();
            services.AddScoped<ISecurityRoles, ServiceSecurityRoles>();
            services.AddScoped<ISecurityFunciones, ServiceSecurityFunciones>();
            services.AddScoped<IGrupo, ServiceGrupo>();

         

            services.Configure<CookiePolicyOptions>(Options => { Options.CheckConsentNeeded = Context => true; Options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None; });

            #region cadena de conexion
            //declara una variable (conection) que esta llamando a la clase ConectionContext (dicha clase se encuentra en Api.Setting)
            ConectionContext conection = Configuration.GetSection("conectionContext").Get<ConectionContext>();
            string strConection = $"Server={conection.server}; Database={conection.databse}; user id={conection.user}; password={conection.password}";

            //configurar para la cadena de conexion
            services.AddDbContext<CoreDBContext>(options => options.UseSqlServer(strConection));
            //asignar la cadena de conexion para adonet
            ADONET.strConnect = strConection;
            #endregion


            //configuracion del cors
            #region configuracion de los cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:9090", "http://172.16.20.202:9090", "http://localhost:50947")                        
                        //que permite cualquier cabecera
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddControllers();
            
            #endregion


            #region configuracion JWT
            //***** Configuracion de servicios para JWT *****
            //autorizacion
            services.AddAuthorization(options =>
                options.DefaultPolicy =
                new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build()
            );
            //estos valores los obtenemos de nuestro appsettings
            var issuer = Configuration["AuthenticationSettings:Issuer"];
            var audience = Configuration["AuthenticationSettings:Audience"];
            var signinKey = Configuration["AuthenticationSettings:SigningKey"];
            //autenticacion
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signinKey))
                };
            }
            );
            #endregion

            //serealizador de Microsoft.AspNetCore.Mvc.NewtonsoftJson para eliminar la referencia circular
            services.AddControllers().AddNewtonsoftJson(options =>
                                                        options.SerializerSettings.ReferenceLoopHandling = 
                                                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region configuracion de la aplicacion para JWT
            //Configurando la aplicación para JWT
            app.UseAuthentication();

            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               /* app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api.COVENTAF v1"));*/
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //configuracion del cors
            #region configuracion del cors           
            app.UseCors(MyAllowSpecificOrigins);
            #endregion

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
