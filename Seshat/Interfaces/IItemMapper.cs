using Sitecore.Data.Items;

namespace MikeRobbins.Seshat.Interfaces
{
    public interface IItemMapper
    {
        T MapItem<T>(Item source) where T : class;
        T Map<T, S>(S source) where T : class where S : class;
    }
}