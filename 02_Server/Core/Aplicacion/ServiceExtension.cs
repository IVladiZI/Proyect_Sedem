using Aplicacion.Behaviours;
using Aplicacion.Helpers.Function;
using Aplicacion.Interfaces;
using Aplicacion.Interfaces.Repositories;
using Aplicacion.Services.MethodsPayment;
using Dominio.Settings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesUniQr;
using ServiceUniQr;
using System.Reflection;

namespace Aplicacion
{
    public static class ServiceExtension
    {
        public static void AddAplicacionLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IFunction, Function>();
            services.AddTransient<IManager, Manager>();
            services.AddTransient<IPaymentQr, PaymentQr>();
            services.Configure<UniQRSettings>(configuration.GetSection("UniQRSettings"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaivours<,>));
            services.AddLocalization();
        }
    }
}
