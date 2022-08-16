using System.Threading.Tasks;
using Kontent.Ai.Boilerplate.Statiq.Models;
using Kontent.Ai.Delivery.Abstractions;
using Kontent.Ai.Delivery.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace Kontent.Ai.Boilerplate.Statiq
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