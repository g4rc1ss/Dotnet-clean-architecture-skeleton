﻿using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestIntegracion.Initializers
{
    public class TestApiConnectionInitializer
    {
        public HttpClient ApiClient { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }

        public TestApiConnectionInitializer()
        {
            try
            {
                var webHost = new WebApplicationFactoryConfiguration();
                ServiceProvider = webHost.Services;
                ApiClient = webHost.CreateClient();
                Configuration = ServiceProvider.GetRequiredService<IConfiguration>();
            }
            finally
            {

            }
        }
    }
}
