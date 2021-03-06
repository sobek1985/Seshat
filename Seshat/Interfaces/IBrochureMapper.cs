﻿using MikeRobbins.Seshat.Models;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface IBrochureMapper
    {
        Brochure GetBrochure(Item item);
        Brochure GetBrochure(SearchResultItem searchResultItem);
    }
}