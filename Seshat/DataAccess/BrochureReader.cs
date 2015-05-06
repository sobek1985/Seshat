using System.Collections.Generic;
using System.Linq;
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
            var config = _configurationReader.GetConfiguration();

            var searchResults = _searcher.SearchByTemplate(config.SearchIndex, config.BrochureTemplateId);

            return searchResults.Select(searchResultItem => _brochureMapper.GetBrochure(searchResultItem)).ToList();
        }

        public Brochure GetBrochure(ID id)
        {
            var item = GetBrochureItem(id);

            return item != null ? _brochureMapper.GetBrochure(item) : null;
        }
    }
}