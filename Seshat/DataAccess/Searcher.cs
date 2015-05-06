using System.Collections.Generic;
using System.Linq;
using MikeRobbins.Seshat.Interfaces;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace MikeRobbins.Seshat.DataAccess
{
    public class Searcher : ISearcher
    {
        public List<SearchResultItem> SearchByTemplate(string indexName, ID templateId)
        {
            using (var context = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            {
                var queryable = context.GetQueryable<SearchResultItem>();

                var query = queryable.Where(x => x.TemplateId == templateId && x.Name != "__Standard Values");

                return query.ToList();
            }
        }

        public SearchResultItem SearchSingleItemByTemplate(string indexName, ID templateId)
        {
            using (var context = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            {
                var queryable = context.GetQueryable<SearchResultItem>();

                var result = queryable.FirstOrDefault(x => x.TemplateId == templateId && x.Name != "__Standard Values");

                return result;
            }
        }
    }
}