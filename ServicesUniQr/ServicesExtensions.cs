using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceUniQr;

namespace ServicesUniQr
{
    public static class ServicesExtensions
    {
        public static void AddUniQr(this IServiceCollection servicies, IConfiguration configuration)
        {
            servicies.Configure<Manager>(configuration.GetSection("UniQr"));
        }
    }
}
