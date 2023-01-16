using Microsoft.Extensions.Configuration;

namespace ConsultaCEP
{
    public class Program
    {
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            new Services.ConsultaService().ConsultaAPI();
        }
    }
}