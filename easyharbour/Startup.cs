using easyharbour.Servico;
using easyharbour.Repositorio;
using VLI.SIOP.Operacao.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using easyharbour.Common;
using easyharbour.Dados.Repositorios;

namespace easyharbour
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AplicacaoContexto>(options => options.UseSqlServer(Configuration["StringConexao:Padrao"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            InstanciarConfiguracoesPadrao(services);
        }

        private void InstanciarConfiguracoesPadrao(IServiceCollection services)
        {
            services.AddTransient<TabuaMareRepositorio, TabuaMareRepositorio>();
            services.AddTransient<ImportacaoRepositorio, ImportacaoRepositorio>();
            services.AddTransient<AtracacaoRepositorio, AtracacaoRepositorio>();
            services.AddTransient<BercoGraoRepositorio, BercoGraoRepositorio>();            

            services.AddTransient<ImportacaoServico, ImportacaoServico>();
            services.AddTransient<TabuaMareServico, TabuaMareServico>();
            services.AddTransient<AtracacaoServico, AtracacaoServico>();
            services.AddTransient<BercoGraoServico, BercoGraoServico>();
            services.AddTransient<DadosAtracaoServico, DadosAtracaoServico>();
            services.AddTransient<ImportacaoServico, ImportacaoServico>();

            services.AddTransient<ClimaServico, ClimaServico>(options => new ClimaServico(Configuration["Clima:Url"], Configuration));

            services.AddResponseCompression();

            // Swagger
            services.AddSwaggerGen(options =>
            {
               
                options.DescribeAllEnumsAsStrings();
                options.EnableAnnotations();
                options.SwaggerDoc("v1",
                    new Info
                    {
                         
                        Title = "easyharbour.Api",
                        Version = GetType().Assembly.GetName().Version.ToString(),
                        Description = "Api de controle Easy Harbour",
                        Contact = new Contact
                        {
                            Name = "Glaydson Freitas",
                            Url = ""
                        }
                    }
                );
            });

            // Habilita Cross-Domain. Libera aplicação para ser consumida por outros domínios.
            var configOrigens = Configuration["OrigensPermitidas"];
            var origensPermitidas = configOrigens?.Split(',').Select(a => a.Trim()).ToArray();
            services.AddCors(options =>
            {
                options.AddPolicy(Constantes.EasyHarbour, builder =>
                {
                    builder.WithOrigins(origensPermitidas)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configura politicas de Cookies
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            // Configura politicas de cabecalhos HTTP
            var politicasCabecalhos = new HeaderPolicyCollection()
                .AddDefaultSecurityHeaders()
                .AddCustomHeader("Cache-Control", "no-cache, no-store, must-revalidate, private")
                .AddCustomHeader("Pragma", "no-cache");

            app.UseSecurityHeaders(politicasCabecalhos);

            //app.ValidaHeadersAcesso();

            //Globalizacao en-US
            var defaultDateCulture = "en-US";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            ci.NumberFormat.NumberDecimalDigits = 2;
            // Configure the Localization middleware
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
                {
                    ci,
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    ci,
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value);
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "easyharbour.Api");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseResponseCompression();
            app.UseCors(Constantes.EasyHarbour);

            app.UseMvc();
        }
    }
}
