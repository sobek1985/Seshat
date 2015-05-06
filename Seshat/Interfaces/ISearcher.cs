using System.Collections.Generic;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface ISearcher
    {
        List<SearchResultItem> SearchByTemplate(string indexName, ID templateId);
        SearchResultItem SearchSingleItemByTemplate(string indexName, ID templateId);
    }
}