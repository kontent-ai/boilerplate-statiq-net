using Kontent.Ai.Delivery.Abstractions;
using Kontent.Ai.Boilerplate.Statiq.Models;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Kontent.Ai.Urls.Delivery.QueryParameters.Filters;
using Kontent.Ai.Urls.Delivery.QueryParameters;

namespace Kontent.Ai.Boilerplate.Statiq
{
    public class HeroPipeline : Pipeline
    {
        public HeroPipeline(IDeliveryClient client)
        {
            ProcessModules = new ModuleList
            {
                new Kontent<Home>(client)
                    .WithQuery(
                        new EqualsFilter("system.codename", "home"),
                        new LimitParameter(1)
                    ),
                new MergeContent(
                    new ReadFiles(patterns: "_Hero.cshtml")
                ),
                new RenderRazor()
                    .WithModel(KontentConfig.As<Home>()),
                new SetDestination(new NormalizedPath("index.html")),
                new WriteFiles()
            };
        }
    }
}