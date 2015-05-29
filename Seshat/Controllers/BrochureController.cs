using System.Web;
using System.Web.Http;
using MikeRobbins.Seshat.Interfaces;
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
        public BrochureController(IRepository<Brochure> repository) : base(repository)
        {
        }

        [HttpPost]
        public string GeneratePdf(Brochure brochure)
        {
            var export = (IExport)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IExport));
           
            return export.GenerateExport(brochure);
        }
    }
}