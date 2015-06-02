using System.Linq;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;

namespace MikeRobbins.Seshat.DataAccess
{
    public class BrochureWriter : IBrochureWriter
    {
        //Todo: Remove these
        private ID _brochureFolder = new ID("{96101BB9-9BE0-40DB-9DC7-478B8A6CC72D}");
        private TemplateID _template = new TemplateID(new ID("{0CCF0C35-3A08-4695-9F0D-F25150CC5DF4}"));

        public void SaveBrochure(Brochure brochure)
        {
            var master = Sitecore.Data.Database.GetDatabase("master");
            var folder = master.GetItem(_brochureFolder);

            var newItem = folder.Add(brochure.Title, _template);

            newItem.Editing.BeginEdit();

            newItem["Title"] = brochure.Title;
            newItem["Introduction"] = brochure.Introduction;
            newItem["Case Study"] = brochure.CaseStudy.ToString();
            newItem["Image Gallery"] = brochure.Images.Select(x => x.ToString()).Aggregate((c, n) => c + "|" + n);

            newItem.Editing.EndEdit();
        }
    }
}