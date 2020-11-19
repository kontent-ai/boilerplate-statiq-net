using FromZeroToHero.Models;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace FromZeroToHero
{
    public class HeroPipeline : Pipeline
    {
        public HeroPipeline(IDeliveryClient client)
        {
            ProcessModules = new ModuleList
            {
                new Kontent<Hero>(client)
                    .WithQuery(
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
            };
        }
    }
}