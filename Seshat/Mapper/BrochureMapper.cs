using System.Linq;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.Mapper
{
    public class BrochureMapper : IBrochureMapper
    {
        public Brochure GetBrochure(Item item)
        {
            var brochure = new Brochure();

            var dateField = (Sitecore.Data.Fields.DateField)item.Fields["Date"];

            brochure.Title = item["Title"];

            if (dateField != null)
            {
                brochure.Date = dateField.DateTime;
            }

            brochure.Id = item.ID.ToString();
            brochure.Url = item.Paths.ContentPath;
            brochure.CaseStudy = ((Sitecore.Data.Fields.LookupField)item.Fields["CaseStudy"]).TargetID.Guid;
            brochure.Image = ((Sitecore.Data.Fields.LookupField)item.Fields["Images"]).TargetID.Guid;
            brochure.Introduction = item["Introduction"];
            brochure.Icon = "/temp/IconCache/" + item.Appearance.Icon;

            return brochure;
        }

        public Brochure GetBrochure(SearchResultItem searchResultItem)
        {
            Brochure brochure = null;

            var item = searchResultItem.GetItem();

            brochure = GetBrochure(item);

            return brochure;
        }
    }
}