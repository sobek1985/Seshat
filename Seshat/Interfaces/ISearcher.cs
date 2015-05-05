using System.Collections.Generic;
using Sitecore.Data;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface ISearcher
    {
        List<SearchResultItem> SearchByTemplate(string indexName, ID templateId);
    }
}