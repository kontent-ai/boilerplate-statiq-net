using System.Threading.Tasks;
using FromZeroToHero.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace FromZeroToHero
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>
          await Bootstrapper
            .Factory
            .CreateWeb(args)
            .ConfigureServices((services, config) =>
            {
                // Add the type provider
                services.AddSingleton<ITypeProvider, CustomTypeProvider>();
                // Configure Delivery SDK
                services.AddDeliveryClient((IConfiguration)config);
            })
            .RunAsync();
    }
}