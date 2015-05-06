using MikeRobbins.Seshat.DataAccess;
using MikeRobbins.Seshat.Mapper;
using MikeRobbins.Seshat.Utilities;
using Sitecore.Services.Core;

namespace MikeRobbins.Seshat.IoC
{
    public class Registry : StructureMap.Configuration.DSL.Registry
    {
        public Registry()
        {
            For<Interfaces.IBrochureMapper>().Use<BrochureMapper>();
            For<Interfaces.IBrochureReader>().Use<BrochureReader>();
            For<Interfaces.ISearcher>().Use<Searcher>();
            For<Interfaces.ISitecoreUtilities>().Use<SitecoreUtilities>();
            For<Interfaces.IConfigurationReader>().Use<ConfigurationReader>().Singleton();
            For<Interfaces.IItemMapper>().Use<ItemMapper>();
            For(typeof(IRepository<>)).Use(typeof(MikeRobbins.Seshat.Repositories.BrochureRespository));
        }
    }
}