using MikeRobbins.Seshat.DataAccess;
using MikeRobbins.Seshat.Mapper;

namespace MikeRobbins.Seshat.IoC
{
    public class Registry : StructureMap.Configuration.DSL.Registry
    {
        public Registry()
        {
            For<Interfaces.IBrochureMapper>().Use<BrochureMapper>();
            For<Interfaces.IBrochureReader>().Use<BrochureReader>();
        }
    }
}