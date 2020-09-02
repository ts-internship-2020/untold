using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    static class Program
    {

        public static string EnteredEmailAddress;
        public static string qrCode;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();


            //Application.Run(ServiceProvider.GetService<MainPage>());
            Application.Run(new EmailForm(ServiceProvider));
            //e posibil sa deschidem de aici ServiceProvider.GetService<MainPage>()
        }


        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<MainPage>();
            services.AddScoped<IConferenceRepository, ConferenceRepository>();
            services.AddScoped<IAttendeeButtonsRepository, AttendeeButtonsRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<IGetDemoRepository, GetDemoRepository>();
            services.AddScoped<ICountyRepository, CountyRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICategoryRepository, CategoryReposity>();
            services.AddSingleton<SqlConnection>(a =>
            {
               
                    SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
                    sqlConnection.Open();
                    return sqlConnection;
                
            
            });
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
