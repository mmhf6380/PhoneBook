﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phonbook.Core.Contracts.People;
using Phonbook.Core.Contracts.Phones;
using Phonebook.DAL.EF.Common;
using Phonebook.DAL.EF.People;
using Phonebook.DAL.EF.Phones;
using Phonebook.Services.ApplicationServices;
using Swashbuckle.AspNetCore.Swagger;

namespace PhoneBook.API.WebAPI
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
            services.AddDbContext<PhoneBookContext>();
            services.AddTransient<IPersonService, PersonSevice>();
            services.AddTransient<IPersonRepository, EfPersonRepository>();
            services.AddTransient<IPhoneRepository, EfPhoneRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("PhoneBookAPI.v1", new Info { Title = "PhoneBook API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/PhoneBookAPI.v1/swagger.json", "PhoneBook API V1");
            });
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
