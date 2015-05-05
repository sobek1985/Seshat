using System.Web.Http;
using MikeRobbins.Seshat.IoC;
using Sitecore.Pipelines;
using StructureMap;

namespace MikeRobbins.Seshat.Pipelines.Initialize
{
    public class RegisterIoC
    {
        public void Process(PipelineArgs args)
        {
            var config = GlobalConfiguration.Configuration;
            var container = new Container(new Registry());
            config.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}