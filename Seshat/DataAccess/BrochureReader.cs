using System.Collections.Generic;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.DataAccess
{
    public class BrochureReader : IBrochureReader
    {
        private IBrochureMapper _brochureMapper;
        private ISearcher _searcher;

        public BrochureReader(IBrochureMapper iBrochureMapper, ISearcher iSearcher)
        {
            _brochureMapper = iBrochureMapper;
            _searcher = iSearcher;
        }

        public Item GetBrochureItem(ID id)
        {
            return Sitecore.Data.Database.GetDatabase("master").GetItem(id);
        }

        public List<Brochure> GetAllBrochures()
        {
            _searcher.SearchByTemplate("sitecore_master_index",)

            var brochures = new List<Brochure>();

            var master = Sitecore.Data.Database.GetDatabase("master");

            var folder = master.GetItem(new ID("{CA002812-8C24-4AD5-8843-00492FAEC74D}"));

            foreach (Item item in folder.Children)
            {
                var brochure = new Brochure()
                {
                    Id = item.ID.ToString(),
                    ImagePath = "~/icon/Office/48x48/document_attachment.png",
                    Title = item["Title"],
                    Introduction = item["Introduction"],
                    CaseStudy = ((Sitecore.Data.Fields.LookupField)item.Fields["Case Study"]).TargetID.Guid,
                    ImageGallery = item["Image Gallery"],
                };

                brochures.Add(brochure);
            }
        }

        public Brochure GetBrochure(ID id)
        {
            var item = GetBrochureItem(id);
            return _brochureMapper.GetBrochure(item);
        }

    }
}