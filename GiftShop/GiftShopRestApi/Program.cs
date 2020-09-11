using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftShopBusinessLogic.BusinessLogics;
using GiftShopBusinessLogic.HelperModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;

namespace GiftShopRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MailLogic.MailConfig(new MailConfig

            {

                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],

                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),

                MailLogin = ConfigurationManager.AppSettings["MailLogin"],

                MailPassword = ConfigurationManager.AppSettings["MailPassword"],

            });
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
