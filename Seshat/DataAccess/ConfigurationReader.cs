using MikeRobbins.Seshat.Interfaces;
using MikeRobbins.Seshat.Models;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace MikeRobbins.Seshat.DataAccess
{
    public class ConfigurationReader : IConfigurationReader
    {
        private static readonly ID _configurationTemplateId = new ID("{2D68C098-7645-4AFB-9010-610839618FC4}");
        private ISearcher _searcher;
        private IItemMapper _itemMapper;

        public ConfigurationReader(ISearcher searcher, IItemMapper itemMapper)
        {
            _searcher = searcher;
            _itemMapper = itemMapper;
        }

        public ApplicationConfiguration GetConfiguration()
        {
            ApplicationConfiguration applicationConfig = null;

            var result = _searcher.SearchSingleItemByTemplate("sitecore_master_index", _configurationTemplateId);

            if (result!=null)
            {
                var item = result.GetItem();
                applicationConfig= _itemMapper.MapItem<ApplicationConfiguration>(item);
            }

            return applicationConfig;
        }


    }
}