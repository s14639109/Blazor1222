using BlazorAppTest_First.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAppTest_First.Service;
using BlazorAppTest_First.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppTest_First
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            /*�i��DI�e�����U*/
            //services.AddScoped<IMyNoteService, MyNoteService>();
            services.AddScoped<IMyNoteService, MyNoteDBService>();
            /*�ŧi�ϥ�SQLite��Ʈw*/
            services.AddDbContext<MyNoteDBContent>(options =>
            {
                options.UseSqlite("Data Source=MyNote.db");
            });
            /*�s�W����MAPI�����\�઺�䴩�A�����|�[�JViews or Pages*/
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //�s�W�ݩʸ��ѱ�����䴩
                endpoints.MapControllers();
                //��l�ƭ������a��A�Ҧ�Pages ���|�ɤJ�ܦ�
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
