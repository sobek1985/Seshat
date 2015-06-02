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
        private IItemReader _itemReader;

        public BrochureReader(IBrochureMapper iBrochureMapper, ISearcher iSearcher, IConfigurationReader iConfigurationReader, IItemReader iItemReader)
        {
            _brochureMapper = iBrochureMapper;
            _searcher = iSearcher;
            _configurationReader = iConfigurationReader;
            _itemReader = iItemReader;
        }

        public List<Brochure> GetAllBrochures()
        {
            var config = _configurationReader.GetConfiguration();

            var searchResults = _searcher.SearchByTemplate(config.SearchIndex, config.BrochureTemplateId);

            return searchResults.Select(searchResultItem => _brochureMapper.GetBrochure(searchResultItem)).ToList();
        }

        public Brochure GetBrochure(ID id)
        {
            var item = _itemReader.GetItem(id);

            return item != null ? _brochureMapper.GetBrochure(item) : null;
        }

        public bool BrochureExists(ID id)
        {
            var item = _itemReader.GetItem(id);

            return item != null;
        }
    }
}