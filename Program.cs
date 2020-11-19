using System.Threading.Tasks;
using FromZeroToHero.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Extensions;
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
                services.AddDeliveryClient(opts =>
                    opts.WithProjectId("cee1708b-4db8-0045-5b86-0135b747a1d4")
                        .UseProductionApi()
                        .Build());
            })
            .RunAsync();
    }
}