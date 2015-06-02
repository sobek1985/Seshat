using MikeRobbins.Seshat.Interfaces;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.DataAccess
{
    public class ItemReader : IItemReader
    {
        public Item GetItem(ID id)
        {
            return Sitecore.Data.Database.GetDatabase("master").GetItem(id);
        }
    }
}