//*****************************************************************************************************************
// AX 2012 AIF proxy service sample
// Author : Tayfun Sertan Yaman
// Version : 1.1.1
//https://github.com/sertanyaman/ax2012-aif-aspnetcore-proxyservice-sample
// MIT License
//*****************************************************************************************************************
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AX2012AIFProxySample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    /*Enable these lines for relay listener option*/
                    /*.UseAzureRelay(options =>
                     {
                         options.UrlPrefixes.Add("<<your primary relay connection string>>");

                     })*/;
                    /*Enable this line for +windows service option*/
                })/*.UseWindowsService()*/;
    }
}
