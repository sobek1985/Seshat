using System.Linq;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;

namespace MikeRobbins.Seshat.DataAccess
{
    public class BrochureCreator : IBrochureCreator
    {
        private IFieldUpdater _iFieldUpdater;

        public BrochureCreator(IFieldUpdater iFieldUpdater)
        {
            _iFieldUpdater = iFieldUpdater;
        }

        //Todo: Remove these
        private readonly ID _brochureFolder = new ID("{96101BB9-9BE0-40DB-9DC7-478B8A6CC72D}");
        private readonly TemplateID _template = new TemplateID(new ID("{0CCF0C35-3A08-4695-9F0D-F25150CC5DF4}"));

        public void CreateBrochure(Brochure brochure)
        {
            var master = Sitecore.Data.Database.GetDatabase("master");
            var folder = master.GetItem(_brochureFolder);

            var newItem = folder.Add(brochure.Title.Trim(), _template);

            brochure.Id = newItem.ID.ToString();

            _iFieldUpdater.AddFieldsToItem(newItem, brochure);
        }
    }
}