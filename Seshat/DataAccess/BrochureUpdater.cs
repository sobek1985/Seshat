using System.Collections.Generic;
using System.Linq;
using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.DataAccess
{
    public class BrochureUpdater : IBrochureUpdater
    {
        private ISitecoreUtilities _iSitecoreUtilities;
        private IItemReader _iItemReader;
        private IFieldUpdater _iFieldUpdater;

        public BrochureUpdater(ISitecoreUtilities iSitecoreUtilities, IItemReader iItemReader, IFieldUpdater iFieldUpdater)
        {
            _iSitecoreUtilities = iSitecoreUtilities;
            _iItemReader = iItemReader;
            _iFieldUpdater = iFieldUpdater;
        }

        public void UpdateBrochure(Brochure brochure)
        {
            var id = _iSitecoreUtilities.ParseId(brochure.Id);

            if (!id.IsNull)
            {
                var item = _iItemReader.GetItem(id);

                _iFieldUpdater.AddFieldsToItem(item, brochure);
            }
        }

        public void DeleteBrochure(Brochure brochure)
        {
            var id = _iSitecoreUtilities.ParseId(brochure.Id);

            var item = _iItemReader.GetItem(id);

            item.Delete();
        }
    }

}