using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace MikeRobbins.Seshat.DataAccess
{
    public class ConfigurationReader : IConfigurationReader
    {
        private static readonly ID _configurationTemplateId = new ID("{8669D564-8405-4980-9782-F551FB3A89E8}");
        private ISearcher _searcher;
        private IItemMapper _itemMapper;

        public ConfigurationReader(ISearcher searcher, IItemMapper itemMapper)
        {
            _searcher = searcher;
            _itemMapper = itemMapper;
        }

        public ApplicationConfiguration GetConfiguration()
        {
            var result = _searcher.SearchSingleItemByTemplate("sitecore_master_index", _configurationTemplateId);

            return _itemMapper.Map<ApplicationConfiguration, SearchResultItem>(result);
        }


    }
}