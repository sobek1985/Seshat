using MikeRobbins.Seshat.Models;
using MikeRobbins.Seshat.Repositories;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace MikeRobbins.Seshat.Controllers
{
    [ServicesController]
    public class BrochureController : EntityService<Brochure>
    {
        public BrochureController(IRepository<Brochure> repository)
            : base(repository)
        {
        }

        public BrochureController()
            : this(new BrochureRespository())
        {
        }
    }
}