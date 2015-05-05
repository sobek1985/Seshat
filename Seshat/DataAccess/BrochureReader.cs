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
        private IConfigurationReader _configurationReader;

        public BrochureReader(IBrochureMapper iBrochureMapper, ISearcher iSearcher, IConfigurationReader iConfigurationReader)
        {
            _brochureMapper = iBrochureMapper;
            _searcher = iSearcher;
            _configurationReader = iConfigurationReader;
        }

        public Item GetBrochureItem(ID id)
        {
            return Sitecore.Data.Database.GetDatabase("master").GetItem(id);
        }

        public List<Brochure> GetAllBrochures()
        {
            var brochures = new List<Brochure>();

            var searchResults = _searcher.SearchByTemplate("sitecore_master_index", );

            foreach (var searchResultItem in searchResults)
            {
                brochures.Add(_brochureMapper.GetBrochure(searchResultItem));
            }

            return brochures;
        }

        public Brochure GetBrochure(ID id)
        {
            var item = GetBrochureItem(id);
            return _brochureMapper.GetBrochure(item);
        }

    }
}