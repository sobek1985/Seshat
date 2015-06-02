using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface IItemReader
    {
        Item GetItem(ID id);
    }
}