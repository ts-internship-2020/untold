using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConferencePlanner.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string dateString = "2020-09-16 21:57:33";
            //string format = "yyyy-MM-dd HH:mm:ss";
            //DateTime dateTime;
            //if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture,
            //    DateTimeStyles.None, out dateTime))
            //{
            //    Console.WriteLine(dateTime);
            //}
            //else
            //{
            //    Console.WriteLine("Not a date");
            //}

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//--