using MikeRobbins.Seshat.Interfaces;
using Sitecore.Data;

namespace MikeRobbins.Seshat.Utilities
{
    public class SitecoreUtilities : ISitecoreUtilities
    {
        public ID ParseId(string id)
        {
            var sID = ID.Null;

            ID.TryParse(id, out sID);

            return sID;
        }

    }
}