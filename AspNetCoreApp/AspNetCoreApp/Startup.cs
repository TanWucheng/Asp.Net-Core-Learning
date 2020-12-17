using System.Text;
using AspNetCoreApp.Data;
using AspNetCoreApp.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreApp
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
            services.AddRazorPages();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddDbContext<BookContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("BookContext"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 注册 Encoding.RegisterProvider,以支持 GB2312 编码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRequestIp();

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=86400");
                },
                ServeUnknownFileTypes = true,
                DefaultContentType = "text/plain"
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/plain";
                await context.HttpContext.Response.WriteAsync(
                    "Status code page, 状态码: " +
                    context.HttpContext.Response.StatusCode, Encoding.GetEncoding("GB2312"));
            });

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}