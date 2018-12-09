﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_WebApp.Interfaces;
using Demo_WebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo_WebApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IConfig, ConfigSvc>();
            services.AddSingleton<IWeather, WeatherSvc>();
            services.AddSingleton<ITimeZone, TimeZoneSvc>();
            services.AddSingleton<IElevation, ElevationSvc>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger, IConfig config)
        {
            if (string.IsNullOrEmpty(config.WeatherAppID)) {
                logger.LogCritical("Missing Weather App ID");
            }
            if (string .IsNullOrEmpty(config.GoogleAppID)) {
                logger.LogCritical("Missing TimeZone App ID");
            }
            logger.LogInformation($"Weather: {config.WeatherAppID}, Time Zone: {config.GoogleAppID}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

    } // end of class
}
