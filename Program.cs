using System.Threading.Tasks;
using FromZeroToHero.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Builders.DeliveryClient;
using Kentico.Kontent.Delivery.Extensions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using Kontent.Statiq;
using Microsoft.Extensions.DependencyInjection;
using Statiq.App;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
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
            .AddPipeline("Root", new ModuleList
            {
                new Kontent<Hero>(DeliveryClientBuilder // I would like to use DI container
                    .WithOptions(builder => builder
                        .WithProjectId("cee1708b-4db8-0045-5b86-0135b747a1d4")
                        .UseProductionApi()
                        .Build())
                    .WithTypeProvider(new CustomTypeProvider())
                    .Build()
                ).WithQuery(
                        new EqualsFilter("system.codename", "hero"),
                        new LimitParameter(1)
                ),
                new MergeContent(
                    new ReadFiles(patterns: "_Hero.cshtml")
                ),
                new RenderRazor()
                    .WithModel(KontentConfig.As<Hero>()),
                new SetDestination(new NormalizedPath("index.html")),
                new WriteFiles()
            })
            .RunAsync();
    }
}