using MikeRobbins.Seshat.DataAccess;
using MikeRobbins.Seshat.Mapper;
using MikeRobbins.Seshat.Utilities;

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
            For<Interfaces.IConfigurationReader>().Use<ConfigurationReader>();
        }
    }
}