using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
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
            brochure.Date = dateField.DateTime;
            brochure.Id = item.ID.ToString();
            brochure.Url = item.Paths.ContentPath;

            return brochure;
        }

        public Brochure GetBrochure(SearchResultItem searchResultItem)
        {

        }
    }
}