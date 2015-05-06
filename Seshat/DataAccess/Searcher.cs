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
                var culture = Sitecore.Context.Language.CultureInfo;

                var queryable = context.GetQueryable<SearchResultItem>(new CultureExecutionContext(culture));

                var query = queryable.Where(x => x.TemplateId == templateId);

                return query.ToList();
            }
        }

        public SearchResultItem SearchSingleItemByTemplate(string indexName, ID templateId)
        {
            using (var context = Sitecore.ContentSearch.ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            {
                var culture = Sitecore.Context.Language.CultureInfo;

                var queryable = context.GetQueryable<SearchResultItem>(new CultureExecutionContext(culture));

                var result = queryable.FirstOrDefault(x => x.TemplateId == templateId);

                return result;
            }
        }
    }
}