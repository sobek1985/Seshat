using MikeRobbins.Seshat.IoC;
using MikeRobbins.Seshat.Models;
using MikeRobbins.Seshat.Repositories;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;
using StructureMap;

namespace MikeRobbins.Seshat.Controllers
{
    [ServicesController]
    public class BrochureController : EntityService<Brochure>
    {
        private Container _container;

        public static Container Container
        {
            get
            {
                return new Container(new Registry());
            }
        }

        public BrochureController(IRepository<Brochure> repository)
            : base(repository)
        {
        }

        public BrochureController()
            : this(Container.GetInstance<IRepository<Brochure>>())
        {
        }

    }
}